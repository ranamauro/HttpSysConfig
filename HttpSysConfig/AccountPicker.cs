namespace CodePlex.Tools.HttpSysConfig
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Windows.Forms;

    public partial class AccountPicker : Form
    {
        static List < string > accounts;

        static AccountPicker()
        {
            accounts = new List < string >();
            foreach (WellKnownSidType sid in Enum.GetValues(typeof(WellKnownSidType)))
            {
                try
                {
                    NTAccount account = new SecurityIdentifier(sid, null).Translate(typeof(NTAccount)) as NTAccount;
                    accounts.Add(account.Value);
                }
                catch (IdentityNotMappedException)
                {
                }
                catch (ArgumentException)
                {
                }
            }
            accounts.Sort();
            accounts.Insert(0, WindowsIdentity.GetCurrent().Name);
        }

        public AccountPicker()
        {
            InitializeComponent();
        }

        public string AccountPicked
        {
            get
            {
                return this.type.Text;
            }
        }

        private void AccountPicker_Load(object sender, EventArgs e)
        {
            foreach (string account in accounts)
            {
                if (string.IsNullOrEmpty(type.Text) || account.ToLowerInvariant().Contains(type.Text.ToLowerInvariant()))
                {
                    this.listAccounts.Items.Add(account);
                }
            }
            type_TextChanged(null, null);
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

        private void listAccounts_DoubleClick(object sender, System.EventArgs e)
        {
            MouseEventArgs m = e as MouseEventArgs;
            if (m != null)
            {
                int index = this.listAccounts.IndexFromPoint(m.Location);
                if (index != -1)
                {
                    this.listAccounts.SelectedIndex = index;
                    this.Close();
                }
            }
        }

        private void listAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.type.Text = listAccounts.SelectedItem as string;
        }

        private void type_TextChanged(object sender, EventArgs e)
        {
            this.listAccounts.Items.Clear();
            foreach (string account in accounts)
            {
                if (account.ToLowerInvariant().Contains(type.Text.ToLowerInvariant()))
                {
                    this.listAccounts.Items.Add(account);
                }
            }
        }
    }
}
