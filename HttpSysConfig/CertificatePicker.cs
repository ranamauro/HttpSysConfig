namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;

    public partial class CertificatePicker : Form
    {
        List < CertWithStore > certificates;

        public CertificatePicker()
        {
            InitializeComponent();
        }

        public string Hash
        {
            get
            {
                CertWithStore certificate = listCertificates.SelectedItem as CertWithStore;
                return certificate.Cert.Thumbprint;
            }
        }

        public string Store
        {
            get
            {
                CertWithStore certificate = listCertificates.SelectedItem as CertWithStore;
                return certificate.Store.ToString();
            }
        }

        public static string FindFirstValidCert(out string store)
        {
            List < CertWithStore > certificates = new List < CertWithStore >();
            FindValidCerts(certificates);
            foreach (CertWithStore certificate in certificates)
            {
                store = certificate.Store.ToString();
                return certificate.Cert.Thumbprint;
            }
            store = null;
            return null;
        }

        static void FindValidCerts(List < CertWithStore > certificates)
        {
            foreach (StoreName storeName in Enum.GetValues(typeof(StoreName)))
            {
                X509Store store = new X509Store(storeName, StoreLocation.LocalMachine);
                try
                {
                    store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                    foreach (X509Certificate2 cert in store.Certificates)
                    {
                        if (!MainForm.IsValidForHttps(cert))
                        {
                            continue;
                        }
                        certificates.Add(new CertWithStore(cert, storeName));
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
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.type.Text = null;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CertificatePicker_Load(object sender, EventArgs e)
        {
            this.certificates = new List < CertWithStore >();
            FindValidCerts(this.certificates);
            type_TextChanged(null, null);
        }

        private void listCertificates_DoubleClick(object sender, System.EventArgs e)
        {
            MouseEventArgs m = e as MouseEventArgs;
            if (m != null)
            {
                int index = this.listCertificates.IndexFromPoint(m.Location);
                if (index != -1)
                {
                    this.listCertificates.SelectedIndex = index;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void type_TextChanged(object sender, EventArgs e)
        {
            this.listCertificates.Items.Clear();
            if (this.certificates == null)
            {
                return;
            }
            foreach (CertWithStore certificate in this.certificates)
            {
                if (string.IsNullOrEmpty(type.Text) || certificate.Cert.ToString().ToLowerInvariant().Contains(type.Text.ToLowerInvariant()))
                {
                    this.listCertificates.Items.Add(certificate);
                }
            }
        }

        class CertWithStore
        {
            X509Certificate2 cert;
            StoreName store;

            public CertWithStore(X509Certificate2 cert, StoreName store)
            {
                this.cert = cert;
                this.store = store;
            }

            public X509Certificate2 Cert
            {
                get { return cert; }
            }

            public StoreName Store
            {
                get { return store; }
            }

            public override string ToString()
            {
                return store.ToString() + ": " + cert.Thumbprint + " - " + cert.ToString();
            }

        }
    }
}
