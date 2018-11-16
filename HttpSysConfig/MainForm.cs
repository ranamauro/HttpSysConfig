namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.ComponentModel;
    using System.Security.Principal;
    using System.Windows.Forms;
    using System.Security.Cryptography.X509Certificates;
    using System.Net;
    using System.Security.Cryptography;
    using System.Net.NetworkInformation;

    public partial class MainForm : Form
    {

        HttpConfigUrlAclEntry aclEditedEntry = null;

        HttpConfigSslEntry sslEditedEntry = null;
        public MainForm()
        {
            InitializeComponent();
        }

        public static bool IsValidForHttps(X509Certificate2 cert)
        {
            bool hasUsage = false;
            bool serverAuth = false;
            foreach (X509Extension extension in cert.Extensions)
            {
                X509KeyUsageExtension ku = extension as X509KeyUsageExtension;
                if (ku != null)
                {
                    hasUsage = true;
                    continue;
                }
                X509EnhancedKeyUsageExtension eku = extension as X509EnhancedKeyUsageExtension;
                if (eku == null)
                {
                    continue;
                }
                hasUsage = true;
                foreach (Oid oid in eku.EnhancedKeyUsages)
                {
                    if (oid.Value.Equals("1.3.6.1.5.5.7.3.1"))
                    {
                        serverAuth = true;
                        break;
                    }
                }
            }
            if (hasUsage && !serverAuth)
            {
                return false;
            }
            if (!cert.HasPrivateKey)
            {
                return false;
            }
            if (cert.NotBefore > DateTime.Now)
            {
                return false;
            }
            if (cert.NotAfter <= DateTime.Now)
            {
                return false;
            }
            return true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented :(", "Coming Soon...", MessageBoxButtons.OK);
        }

#region ACL

        private void aclAdd_Click(object sender, EventArgs e)
        {
            AccountPicker ap = new AccountPicker();
            DialogResult result = ap.ShowDialog();
            if (result == DialogResult.Cancel || string.IsNullOrEmpty(ap.AccountPicked))
            {
                return;
            }
            try
            {
                SecurityIdentifier sid = new NTAccount(ap.AccountPicked).Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
                if (!this.aclAccounts.Items.Contains(ap.AccountPicked))
                {
                    this.aclAccounts.Items.Add(ap.AccountPicked);
                }
                else
                {
                    MessageBox.Show("The account you requested (" + ap.AccountPicked + ") already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occurred while adding the account you requested (" + ap.AccountPicked + "). The error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AclSetEditing(true);
        }

        private void aclApply_Click(object sender, EventArgs e)
        {
            string urlPrefix = (this.aclSsl.Checked ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + "://" + this.aclHostname.Text;
            ushort port;
            if (!string.IsNullOrEmpty(this.aclPort.Text))
            {
                port = ushort.Parse(this.aclPort.Text);
            }
            else
            {
                port = this.aclSsl.Checked ? (ushort)443 : (ushort)80;
            }
            urlPrefix += ":" + port.ToString();
            string path = this.aclPath.Text;
            if (string.IsNullOrEmpty(path) || path[0] != '/')
            {
                path = '/' + path;
            }
            if (path[path.Length - 1] != '/')
            {
                path += '/';
            }
            urlPrefix += path;
            string sddl = "D:";
            foreach (string account in this.aclAccounts.Items)
            {
                SecurityIdentifier sid = new NTAccount(account).Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
                sddl += "(A;;GX;;;" + sid.Value + ")";
            }
            bool deleted = false;
            if (aclEditedEntry != null)
            {
                try
                {
                    aclEditedEntry.Delete();
                    deleted = true;
                }
                catch (Win32Exception exception)
                {
                    DialogResult result = MessageBox.Show("An error occurred while attempting to perform the requested change. The error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Abort)
                    {
                        Reload();
                    }
                    if (result != DialogResult.Ignore)
                    {
                        return;
                    }
                }
            }
            HttpConfigUrlAclEntry entry = new HttpConfigUrlAclEntry(urlPrefix, sddl);
            try
            {
                entry.Create();
            }
            catch (Win32Exception exception)
            {
                DialogResult result = MessageBox.Show("An error occurred while attempting to perform the requested change. The error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort)
                {
                    Reload();
                }
                if (result != DialogResult.Ignore)
                {
                    return;
                }
                if (deleted && aclEditedEntry != null)
                {
                    try
                    {
                        aclEditedEntry.Create();
                    }
                    catch (Win32Exception)
                    {
                    }
                }
            }
            aclEditedEntry = null;
            Reload();
        }

        private void aclCancel_Click(object sender, EventArgs e)
        {
            aclEditedEntry = null;
            AclPopulate();
            AclSetEditing(false);
        }

        void AclClear()
        {
            this.aclSsl.Checked = false;
            this.aclHostname.Items.Clear();
            this.aclAccounts.Items.Clear();
            this.aclPort.Text = null;
            this.aclPath.Text = null;
        }

        private void aclCreate_Click(object sender, EventArgs e)
        {
            AclClear();
            this.aclAccounts.Items.Add(WindowsIdentity.GetCurrent().Name);
            this.aclAccounts.Items.Add("NT AUTHORITY\\NETWORK SERVICE");
            AclPopulateHosts(null);
            AclSetEditing(true);
        }

        private void aclDelete_Click(object sender, EventArgs e)
        {
            HttpConfigUrlAclEntry entry = AclFindCurrentEntry();
            if (entry != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the following UrlAcl?\r\n\r\n" + entry.UriPrefix, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        entry.Delete();
                    }
                    catch (Win32Exception exception)
                    {
                        MessageBox.Show("An error occurred while attempting to delete, the error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Reload();
        }

        private void aclEdit_Click(object sender, EventArgs e)
        {
            aclEditedEntry = AclFindCurrentEntry();
            AclSetEditing(true);
        }

        HttpConfigUrlAclEntry AclFindCurrentEntry()
        {
            if (this.aclTab.SelectedTab == this.aclListTab)
            {
                return this.aclList.SelectedItem as HttpConfigUrlAclEntry;
            }
            TreeNode node = this.aclTree.SelectedNode;
            if (node == null)
            {
                return null;
            }
            for (;;) // walk up
            {
                HttpConfigUrlAclEntry entry = node.Tag as HttpConfigUrlAclEntry;
                if (entry != null)
                {
                    return entry;
                }
                node = node.Parent;
                if (node == null)
                {
                    break;
                }
            }
            node = this.aclTree.SelectedNode;
            for (;;) // walk down
            {
                if (node.Nodes.Count != 1)
                {
                    break;
                }
                node = node.FirstNode;
                HttpConfigUrlAclEntry entry = node.Tag as HttpConfigUrlAclEntry;
                if (entry != null)
                {
                    return entry;
                }
            }
            return null;
        }

        private void aclList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AclPopulate();
        }

        void AclPopulate()
        {
            HttpConfigUrlAclEntry entry = AclFindCurrentEntry();
            if (entry != null)
            {
                this.aclEdit.Enabled = true;
                this.aclSsl.Checked = entry.Uri.Scheme == Uri.UriSchemeHttps;
                AclPopulateHosts(entry);
                this.aclPort.Text = entry.Uri.Port.ToString();
                this.aclPath.Text = entry.Uri.AbsolutePath;
                this.aclAccounts.Items.Clear();
                foreach (NTAccount account in entry.Accounts)
                {
                    this.aclAccounts.Items.Add(account.Value);
                }
            }
            else
            {
                this.aclEdit.Enabled = false;
                AclClear();
            }
        }

        void AclPopulateHosts(HttpConfigUrlAclEntry entry)
        {
            this.aclHostname.Items.Clear();
            this.aclHostname.Items.Add("+");
            this.aclHostname.SelectedIndex = 0;
            this.aclHostname.Items.Add("*");
            this.aclHostname.Items.Add("localhost");
            string computer = Environment.GetEnvironmentVariable("COMPUTERNAME");
            if (!string.IsNullOrEmpty(computer))
            {
                computer = computer.ToLowerInvariant();
                this.aclHostname.Items.Add(computer);
                string domain = Environment.GetEnvironmentVariable("USERDNSDOMAIN");
                if (!string.IsNullOrEmpty(domain))
                {
                    domain = domain.ToLowerInvariant();
                    this.aclHostname.Items.Add(computer + "." + domain);
                }
            }
            if (entry != null)
            {
                if (!this.aclHostname.Items.Contains(entry.Host))
                {
                    this.aclHostname.Items.Add(entry.Host);
                }
                this.aclHostname.SelectedItem = entry.Host;
            }
        }

        void AclReload()
        {
            this.aclList.Items.Clear();
            this.aclTree.Nodes.Clear(); // orphans all children

            HttpConfigUrlAcl httpConfigUrlAcl = HttpConfigUrlAcl.GetHttpReservations();
            foreach (HttpConfigUrlAclEntry entry in httpConfigUrlAcl.Values)
            {
                string accounts = entry.Accounts[0].Value;
                for (int i = 1; i < entry.Accounts.Count; i++)
                {
                    accounts += ", " + entry.Accounts[i].Value;
                }
                this.aclList.Items.Add(entry);
            }
            if (this.aclList.Items.Count > 0)
            {
                this.aclList.SelectedIndex = 0;
            }

            foreach (int port in httpConfigUrlAcl.GetPorts())
            {
                TreeNode portNode = new TreeNode(port.ToString());
                this.aclTree.Nodes.Add(portNode);
                foreach (string host in httpConfigUrlAcl.GetHosts(port))
                {
                    TreeNode hostNode = new TreeNode(host);
                    portNode.Nodes.Add(hostNode);
                    foreach (HttpConfigUrlAclEntry entry in httpConfigUrlAcl.GetEntries(port, host))
                    {
                        TreeNode pathNode = new TreeNode(entry.Uri.AbsolutePath);
                        pathNode.Tag = entry;
                        hostNode.Nodes.Add(pathNode);
                        foreach (NTAccount account in entry.Accounts)
                        {
                            pathNode.Nodes.Add(new TreeNode(account.Value));
                        }
                    }
                }
                this.aclTree.ExpandAll();
            }

            AclSetEditing(false);
            AclPopulate();
        }

        private void aclRemove_Click(object sender, EventArgs e)
        {
            int index = this.aclAccounts.SelectedIndex;
            this.aclAccounts.Items.RemoveAt(index);
            if (this.aclAccounts.Items.Count > 0)
            {
                if (index == this.aclAccounts.Items.Count)
                {
                    index--;
                }
                this.aclAccounts.SelectedIndex = index;
            }
        }

        void AclSetEditing(bool editing)
        {
            this.aclDelete.Enabled = !editing;
            this.aclEdit.Enabled = !editing;
            this.aclCreate.Enabled = !editing;
            this.aclApply.Enabled = editing && this.aclAccounts.Items.Count > 0 && !string.IsNullOrEmpty(this.aclHostname.Text);
            this.aclCancel.Enabled = editing;

            this.aclAdd.Enabled = editing;
            this.aclRemove.Enabled = editing && this.aclAccounts.SelectedItem != null;

            this.aclSsl.Enabled = editing;
            this.aclHostname.Enabled = editing;
            this.aclAccounts.Enabled = editing;
            this.aclPort.Enabled = editing;
            this.aclPath.Enabled = editing;
            this.aclTree.Enabled = !editing;
        }

        private void aclSsl_CheckedChanged(object sender, EventArgs e)
        {
            this.aclSsl.Text = "Enable SSL: " + (this.aclSsl.Checked ? Uri.UriSchemeHttps : Uri.UriSchemeHttp) + "://";
        }

#endregion ACL

#region SSL

        private void aclTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            AclPopulate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented :(", "Coming Soon...", MessageBoxButtons.OK);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented :(", "Coming Soon...", MessageBoxButtons.OK);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Yet Implemented :(", "Coming Soon...", MessageBoxButtons.OK);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                // only available up to 2k3
                this.sslRawFilter.Enabled = false;

                string sessionName = Environment.GetEnvironmentVariable("SESSIONNAME");
                if (!string.IsNullOrEmpty(sessionName))
                {
                    DialogResult result = MessageBox.Show("This tool will likely require elevation which you don't seem to currently have, would you like to run anyway?", "Tool Requires Elevation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        this.Close();
                        return;
                    }
                }
            }
            Reload();
        }

        void Reload()
        {
            AclReload();
            SslReload();
        }

        private void sslApply_Click(object sender, EventArgs e)
        {
            bool deleted = false;
            if (sslEditedEntry != null)
            {
                try
                {
                    sslEditedEntry.Delete();
                    deleted = true;
                }
                catch (Win32Exception exception)
                {
                    DialogResult result = MessageBox.Show("An error occurred while attempting to perform the requested change. The error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Abort)
                    {
                        Reload();
                    }
                    if (result != DialogResult.Ignore)
                    {
                        return;
                    }
                }
            }
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(this.sslAddress.Text), int.Parse(this.sslPort.Text));
            Guid guid = new Guid();
            try
            {
                guid = new Guid(this.sslAppId.Text);
            }
            catch (FormatException)
            {
            }
            HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK defaultCertCheckMode = 0;
            if (!this.sslCheckRevocation.Checked)
            {
                defaultCertCheckMode |= HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.NoCheck;
            }
            if (this.sslCheckOnlyCached.Checked)
            {
                defaultCertCheckMode |= HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.CachedOnly;
            }
            if (this.sslCheckFresh.Checked)
            {
                defaultCertCheckMode |= HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.UseDefaultRevocationFreshnessTime;
            }
            if (this.sslCeckUsage.Checked)
            {
                defaultCertCheckMode |= HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.NoUsage;
            }
            HTTP_SERVICE_CONFIG_SSL_FLAG defaultFlags = 0;
            if (this.sslNegotiateClientCert.Checked)
            {
                defaultFlags |= HTTP_SERVICE_CONFIG_SSL_FLAG.NegotiateClientCert;
            }
            if (this.sslRawFilter.Checked)
            {
                defaultFlags |= HTTP_SERVICE_CONFIG_SSL_FLAG.NoRawFilter;
            }
            if (this.sslUseDSMapper.Checked)
            {
                defaultFlags |= HTTP_SERVICE_CONFIG_SSL_FLAG.UseDsMapper;
            }
            double time;
            TimeSpan sslFreshness = TimeSpan.Zero;
            if (double.TryParse(this.sslFreshness.Text, out time))
            {
                sslFreshness = TimeSpan.FromSeconds(time);
            }
            TimeSpan sslDownload = TimeSpan.Zero;
            if (double.TryParse(this.sslDownload.Text, out time))
            {
                sslDownload = TimeSpan.FromMilliseconds(time);
            }
            HttpConfigSslEntry entry = new HttpConfigSslEntry(endpoint, this.sslCertHash.Text, guid, this.sslCertStore.Text, defaultCertCheckMode, sslFreshness, sslDownload, null, null, defaultFlags);
            try
            {
                entry.Create();
            }
            catch (Win32Exception exception)
            {
                DialogResult result = MessageBox.Show("An error occurred while attempting to perform the requested change. The error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (result == DialogResult.Abort)
                {
                    Reload();
                }
                if (result != DialogResult.Ignore)
                {
                    return;
                }
                if (deleted && sslEditedEntry != null)
                {
                    try
                    {
                        sslEditedEntry.Create();
                    }
                    catch (Win32Exception)
                    {
                    }
                }
            }
            sslEditedEntry = null;
            Reload();
        }

        private void sslBrowse_Click(object sender, EventArgs e)
        {
            CertificatePicker cp = new CertificatePicker();
            DialogResult result = cp.ShowDialog();
            if (result == DialogResult.Cancel || string.IsNullOrEmpty(cp.Store) || string.IsNullOrEmpty(cp.Hash))
            {
                return;
            }
            this.sslCertHash.Text = cp.Hash;
            this.sslCertStore.Text = cp.Store;
            SslSetEditing(true);
        }

        private void sslCancel_Click(object sender, EventArgs e)
        {
            sslEditedEntry = null;
            SslPopulate();
            SslSetEditing(false);
        }

        private void sslCertStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sslCertHash.Items.Clear();
            if (this.sslCertStore.SelectedItem == null)
            {
                this.sslCertStore.SelectedItem = StoreName.My;
            }
            X509Store store = new X509Store((StoreName)this.sslCertStore.SelectedItem, StoreLocation.LocalMachine);
            try
            {
                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (!IsValidForHttps(cert))
                    {
                        continue;
                    }
                    this.sslCertHash.Items.Add(cert.Thumbprint);
                }
                if (this.sslCertHash.Items.Count > 0)
                {
                    this.sslCertHash.SelectedIndex = 0;
                }
            }
            catch
            {
            }
            finally
            {
                store.Close();
            }
        }

        private void sslCheckRevocation_CheckedChanged(object sender, EventArgs e)
        {
            this.sslGroupBoxRevocation.Enabled = this.sslCheckRevocation.Checked;

            if (this.sslCheckRevocation.Enabled)
            {
                this.sslDownload.Enabled = this.sslCheckRevocation.Checked;
                this.sslFreshness.Enabled = this.sslCheckRevocation.Checked;
                this.sslCheckOnlyCached.Enabled = this.sslCheckRevocation.Checked;
                this.sslCheckFresh.Enabled = this.sslCheckRevocation.Checked;
            }
        }

#endregion SSL

        void SslClear()
        {
            this.sslAddress.Text = null;
            this.sslAppId.Text = null;
            this.sslCeckUsage.Checked = false;
            this.sslCertHash.Text = null;
            this.sslCertStore.Text = null;
            this.sslDownload.Text = null;
            this.sslFreshness.Text = null;
            this.sslPort.Text = null;
            this.sslNegotiateClientCert.Checked = false;
            this.sslRawFilter.Checked = false;
            this.sslUseDSMapper.Checked = false;
            this.sslCheckOnlyCached.Checked = false;
            this.sslCheckRevocation.Checked = false;
            this.sslCheckFresh.Checked = false;
        }

        private void sslCreate_Click(object sender, EventArgs e)
        {
            SslClear();
            SslPopulateCerts(null);
            SslPopulateIPs();
            this.sslPort.Text = "443";
            string store;
            this.sslCertHash.Text = CertificatePicker.FindFirstValidCert(out store);
            this.sslCertStore.Text = store;
            this.sslCheckRevocation.Checked = true;
            SslSetEditing(true);
        }

        private void sslDelete_Click(object sender, EventArgs e)
        {
            HttpConfigSslEntry entry = SslFindCurrentEntry();
            if (entry != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the following Ssl?\r\n\r\n" + entry.EndPoint, "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        entry.Delete();
                    }
                    catch (Win32Exception exception)
                    {
                        MessageBox.Show("An error occurred while attempting to delete, the error message was:\r\n\r\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Reload();
        }

        private void sslEdit_Click(object sender, EventArgs e)
        {
            sslEditedEntry = SslFindCurrentEntry();
            SslSetEditing(true);
        }

        HttpConfigSslEntry SslFindCurrentEntry()
        {
            if (this.sslTab.SelectedTab == this.sslListTab)
            {
                return this.sslList.SelectedItem as HttpConfigSslEntry;
            }
            TreeNode node = this.sslTree.SelectedNode;
            if (node == null)
            {
                return null;
            }
            for (;;) // walk up
            {
                HttpConfigSslEntry entry = node.Tag as HttpConfigSslEntry;
                if (entry != null)
                {
                    return entry;
                }
                node = node.Parent;
                if (node == null)
                {
                    break;
                }
            }
            node = this.sslTree.SelectedNode;
            for (;;) // walk down
            {
                if (node.Nodes.Count != 1)
                {
                    break;
                }
                node = node.FirstNode;
                HttpConfigSslEntry entry = node.Tag as HttpConfigSslEntry;
                if (entry != null)
                {
                    return entry;
                }
            }
            return null;
        }

        private void sslList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SslPopulate();
        }

        private void sslNegotiateClientCert_CheckedChanged(object sender, EventArgs e)
        {
            this.sslGroupBoxClientCert.Enabled = this.sslNegotiateClientCert.Checked;
            this.sslGroupBoxRevocation.Enabled = this.sslCheckRevocation.Checked;

            if (this.sslNegotiateClientCert.Enabled)
            {
                this.sslUseDSMapper.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslCeckUsage.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslDownload.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslFreshness.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslCheckOnlyCached.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslCheckFresh.Enabled = this.sslNegotiateClientCert.Checked;
                this.sslCheckRevocation.Enabled = this.sslNegotiateClientCert.Checked;
            }
        }

        void SslPopulate()
        {
            HttpConfigSslEntry entry = SslFindCurrentEntry();
            if (entry != null)
            {
                this.sslEdit.Enabled = true;
                SslPopulateCerts(entry);
                SslPopulateIPs();
                this.sslAddress.Text = entry.EndPoint.Address.ToString();
                this.sslAppId.Text = entry.AppId.ToString();
                this.sslCertHash.Text = HttpConfigSslEntry.CertHashToString(entry.SslHash);
                this.sslCertStore.Text = entry.SslCertStoreName;
                this.sslDownload.Text = entry.DefaultRevocationUrlRetrievalTimeout.Milliseconds.ToString();
                this.sslFreshness.Text = entry.DefaultRevocationFreshnessTime.Seconds.ToString();
                this.sslPort.Text = entry.EndPoint.Port.ToString();
                this.sslNegotiateClientCert.Checked = (entry.DefaultFlags & HTTP_SERVICE_CONFIG_SSL_FLAG.NegotiateClientCert) != 0;
                this.sslRawFilter.Checked = (entry.DefaultFlags & HTTP_SERVICE_CONFIG_SSL_FLAG.NoRawFilter) != 0;
                this.sslUseDSMapper.Checked = (entry.DefaultFlags & HTTP_SERVICE_CONFIG_SSL_FLAG.UseDsMapper) != 0;
                this.sslCheckRevocation.Checked = (entry.DefaultCertCheckMode & HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.NoCheck) == 0;
                this.sslCheckOnlyCached.Checked = (entry.DefaultCertCheckMode & HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.CachedOnly) != 0;
                this.sslCheckFresh.Checked = (entry.DefaultCertCheckMode & HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.UseDefaultRevocationFreshnessTime) != 0;
                this.sslCeckUsage.Checked = (entry.DefaultCertCheckMode & HTTP_SERVICE_CONFIG_SSL_CLIENT_CERT_CHECK.NoUsage) != 0;
            }
            else
            {
                this.sslEdit.Enabled = false;
                SslClear();
            }
        }

        void SslPopulateCerts(HttpConfigSslEntry entry)
        {
            this.sslCertStore.Items.Clear();
            foreach (StoreName store in Enum.GetValues(typeof(StoreName)))
            {
                this.sslCertStore.Items.Add(store);
            }
            this.sslCertStore.SelectedItem = StoreName.My;
        }

        void SslPopulateIPs()
        {
            this.sslAddress.Items.Clear();
            this.sslAddress.Items.Add(IPAddress.Any);
            this.sslAddress.SelectedIndex = 0;
            this.sslAddress.Items.Add(IPAddress.IPv6Any);
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.OperationalStatus != OperationalStatus.Up)
                {
                    continue;
                }
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                foreach (IPAddressInformation address in adapterProperties.AnycastAddresses)
                {
                    this.sslAddress.Items.Add(address.Address);
                }
                foreach (IPAddressInformation address in adapterProperties.UnicastAddresses)
                {
                    this.sslAddress.Items.Add(address.Address);
                }
            }
        }

        void SslReload()
        {
            this.sslList.Items.Clear();
            HttpConfigSsl httpConfigSsl = HttpConfigSsl.GetHttpSslConfig();
            foreach (HttpConfigSslEntry entry in httpConfigSsl)
            {
                this.sslList.Items.Add(entry);
            }
            if (this.sslList.Items.Count > 0)
            {
                this.sslList.SelectedIndex = 0;
            }
            SslPopulate();
            SslSetEditing(false);
        }

        void SslSetEditing(bool editing)
        {
            this.sslDelete.Enabled = !editing;
            this.sslEdit.Enabled = !editing;
            this.sslCreate.Enabled = !editing;
            this.sslApply.Enabled = editing && !string.IsNullOrEmpty(this.sslPort.Text) && !string.IsNullOrEmpty(this.sslAddress.Text) && !string.IsNullOrEmpty(this.sslCertStore.Text) && !string.IsNullOrEmpty(this.sslCertHash.Text);
            this.sslCancel.Enabled = editing;

            this.sslBrowse.Enabled = editing;
            this.sslPort.Enabled = editing;
            this.sslAddress.Enabled = editing;
            this.sslAppId.Enabled = editing;
            this.sslRawFilter.Enabled = editing && Environment.OSVersion.Version.Major < 6;
            this.sslNegotiateClientCert.Enabled = editing;

            this.sslGroupBoxClientCert.Enabled = editing && this.sslNegotiateClientCert.Checked;
            this.sslUseDSMapper.Enabled = editing;
            this.sslCeckUsage.Enabled = editing;
            this.sslCertHash.Enabled = editing;
            this.sslCertStore.Enabled = editing;
            this.sslDownload.Enabled = editing;
            this.sslCheckRevocation.Enabled = editing;

            this.sslGroupBoxRevocation.Enabled = editing && this.sslCheckRevocation.Checked;
            this.sslFreshness.Enabled = editing;
            this.sslCheckOnlyCached.Enabled = editing;
            this.sslCheckFresh.Enabled = editing;
        }

        private void sslTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SslPopulate();
        }
    }
}
