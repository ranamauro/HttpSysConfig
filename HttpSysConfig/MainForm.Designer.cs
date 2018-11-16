namespace CodePlex.Tools.HttpSysConfig
{
    partial class MainForm
    {
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox aclAccounts;
        private System.Windows.Forms.Button aclAdd;
        private System.Windows.Forms.Button aclApply;
        private System.Windows.Forms.Button aclCancel;
        private System.Windows.Forms.Button aclCreate;
        private System.Windows.Forms.Button aclDelete;
        private System.Windows.Forms.Button aclEdit;
        private System.Windows.Forms.ComboBox aclHostname;
        private System.Windows.Forms.Label aclLabelAccounts;
        private System.Windows.Forms.Label aclLabelHostname;
        private System.Windows.Forms.Label aclLabelPath;
        private System.Windows.Forms.Label aclLabelPort;
        private System.Windows.Forms.ListBox aclList;
        private System.Windows.Forms.TabPage aclListTab;
        private System.Windows.Forms.TextBox aclPath;
        private System.Windows.Forms.TextBox aclPort;
        private System.Windows.Forms.Button aclRemove;
        private System.Windows.Forms.SplitContainer aclSplitContainer;
        private System.Windows.Forms.CheckBox aclSsl;

        private System.Windows.Forms.TabControl aclTab;
        private System.Windows.Forms.TabPage aclTabPage;
        private System.Windows.Forms.TreeView aclTree;
        private System.Windows.Forms.TabPage aclTreeTab;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howDoIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;

        private System.Windows.Forms.TabControl mainTab;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ComboBox sslAddress;
        private System.Windows.Forms.TextBox sslAppId;
        private System.Windows.Forms.Button sslApply;
        private System.Windows.Forms.Button sslBrowse;
        private System.Windows.Forms.Button sslCancel;
        private System.Windows.Forms.CheckBox sslCeckUsage;
        private System.Windows.Forms.ComboBox sslCertHash;
        private System.Windows.Forms.ComboBox sslCertStore;
        private System.Windows.Forms.CheckBox sslCheckFresh;
        private System.Windows.Forms.CheckBox sslCheckOnlyCached;
        private System.Windows.Forms.CheckBox sslCheckRevocation;
        private System.Windows.Forms.Button sslCreate;
        private System.Windows.Forms.Button sslDelete;
        private System.Windows.Forms.TextBox sslDownload;
        private System.Windows.Forms.Button sslEdit;
        private System.Windows.Forms.TextBox sslFreshness;
        private System.Windows.Forms.GroupBox sslGroupBoxClientCert;
        private System.Windows.Forms.GroupBox sslGroupBoxRevocation;
        private System.Windows.Forms.Label sslLabelAddress;
        private System.Windows.Forms.Label sslLabelAppID;
        private System.Windows.Forms.Label sslLabelCertHash;
        private System.Windows.Forms.Label sslLabelCertStore;
        private System.Windows.Forms.Label sslLabelDownloadTimeout;
        private System.Windows.Forms.Label sslLabelFreshness;
        private System.Windows.Forms.Label sslLabelPort;
        private System.Windows.Forms.ListBox sslList;
        private System.Windows.Forms.TabPage sslListTab;
        private System.Windows.Forms.CheckBox sslNegotiateClientCert;
        private System.Windows.Forms.TextBox sslPort;
        private System.Windows.Forms.CheckBox sslRawFilter;
        private System.Windows.Forms.SplitContainer sslSplitContainer;

        private System.Windows.Forms.TabControl sslTab;
        private System.Windows.Forms.TabPage sslTabPage;
        private System.Windows.Forms.TreeView sslTree;
        private System.Windows.Forms.TabPage sslTreeTab;
        private System.Windows.Forms.CheckBox sslUseDSMapper;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howDoIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.aclTabPage = new System.Windows.Forms.TabPage();
            this.aclSplitContainer = new System.Windows.Forms.SplitContainer();
            this.aclTab = new System.Windows.Forms.TabControl();
            this.aclListTab = new System.Windows.Forms.TabPage();
            this.aclList = new System.Windows.Forms.ListBox();
            this.aclTreeTab = new System.Windows.Forms.TabPage();
            this.aclTree = new System.Windows.Forms.TreeView();
            this.aclDelete = new System.Windows.Forms.Button();
            this.aclLabelAccounts = new System.Windows.Forms.Label();
            this.aclCancel = new System.Windows.Forms.Button();
            this.aclApply = new System.Windows.Forms.Button();
            this.aclEdit = new System.Windows.Forms.Button();
            this.aclRemove = new System.Windows.Forms.Button();
            this.aclAdd = new System.Windows.Forms.Button();
            this.aclLabelPath = new System.Windows.Forms.Label();
            this.aclLabelPort = new System.Windows.Forms.Label();
            this.aclLabelHostname = new System.Windows.Forms.Label();
            this.aclHostname = new System.Windows.Forms.ComboBox();
            this.aclPath = new System.Windows.Forms.TextBox();
            this.aclPort = new System.Windows.Forms.TextBox();
            this.aclSsl = new System.Windows.Forms.CheckBox();
            this.aclCreate = new System.Windows.Forms.Button();
            this.aclAccounts = new System.Windows.Forms.ListBox();
            this.sslTabPage = new System.Windows.Forms.TabPage();
            this.sslSplitContainer = new System.Windows.Forms.SplitContainer();
            this.sslTab = new System.Windows.Forms.TabControl();
            this.sslListTab = new System.Windows.Forms.TabPage();
            this.sslList = new System.Windows.Forms.ListBox();
            this.sslTreeTab = new System.Windows.Forms.TabPage();
            this.sslTree = new System.Windows.Forms.TreeView();
            this.sslLabelAppID = new System.Windows.Forms.Label();
            this.sslAppId = new System.Windows.Forms.TextBox();
            this.sslGroupBoxClientCert = new System.Windows.Forms.GroupBox();
            this.sslCheckRevocation = new System.Windows.Forms.CheckBox();
            this.sslGroupBoxRevocation = new System.Windows.Forms.GroupBox();
            this.sslCheckFresh = new System.Windows.Forms.CheckBox();
            this.sslCheckOnlyCached = new System.Windows.Forms.CheckBox();
            this.sslLabelDownloadTimeout = new System.Windows.Forms.Label();
            this.sslDownload = new System.Windows.Forms.TextBox();
            this.sslLabelFreshness = new System.Windows.Forms.Label();
            this.sslFreshness = new System.Windows.Forms.TextBox();
            this.sslCeckUsage = new System.Windows.Forms.CheckBox();
            this.sslUseDSMapper = new System.Windows.Forms.CheckBox();
            this.sslCertStore = new System.Windows.Forms.ComboBox();
            this.sslNegotiateClientCert = new System.Windows.Forms.CheckBox();
            this.sslBrowse = new System.Windows.Forms.Button();
            this.sslRawFilter = new System.Windows.Forms.CheckBox();
            this.sslLabelCertStore = new System.Windows.Forms.Label();
            this.sslDelete = new System.Windows.Forms.Button();
            this.sslCancel = new System.Windows.Forms.Button();
            this.sslApply = new System.Windows.Forms.Button();
            this.sslEdit = new System.Windows.Forms.Button();
            this.sslLabelCertHash = new System.Windows.Forms.Label();
            this.sslLabelPort = new System.Windows.Forms.Label();
            this.sslLabelAddress = new System.Windows.Forms.Label();
            this.sslAddress = new System.Windows.Forms.ComboBox();
            this.sslCertHash = new System.Windows.Forms.ComboBox();
            this.sslPort = new System.Windows.Forms.TextBox();
            this.sslCreate = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.aclTabPage.SuspendLayout();
            this.aclSplitContainer.Panel1.SuspendLayout();
            this.aclSplitContainer.Panel2.SuspendLayout();
            this.aclSplitContainer.SuspendLayout();
            this.aclTab.SuspendLayout();
            this.aclListTab.SuspendLayout();
            this.aclTreeTab.SuspendLayout();
            this.sslTabPage.SuspendLayout();
            this.sslSplitContainer.Panel1.SuspendLayout();
            this.sslSplitContainer.Panel2.SuspendLayout();
            this.sslSplitContainer.SuspendLayout();
            this.sslTab.SuspendLayout();
            this.sslListTab.SuspendLayout();
            this.sslTreeTab.SuspendLayout();
            this.sslGroupBoxClientCert.SuspendLayout();
            this.sslGroupBoxRevocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(683, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exportToolStripMenuItem.Text = "Import Settings...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.importToolStripMenuItem.Text = "Export Settings...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howDoIToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howDoIToolStripMenuItem
            // 
            this.howDoIToolStripMenuItem.Name = "howDoIToolStripMenuItem";
            this.howDoIToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.howDoIToolStripMenuItem.Text = "How Do I";
            this.howDoIToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aboutToolStripMenuItem.Text = "About HttpSysConfig";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.aclTabPage);
            this.mainTab.Controls.Add(this.sslTabPage);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Location = new System.Drawing.Point(0, 24);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(683, 512);
            this.mainTab.TabIndex = 12;
            // 
            // aclTabPage
            // 
            this.aclTabPage.Controls.Add(this.aclSplitContainer);
            this.aclTabPage.Location = new System.Drawing.Point(4, 22);
            this.aclTabPage.Name = "aclTabPage";
            this.aclTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aclTabPage.Size = new System.Drawing.Size(675, 486);
            this.aclTabPage.TabIndex = 3;
            this.aclTabPage.Text = "Url Acl";
            this.aclTabPage.UseVisualStyleBackColor = true;
            // 
            // aclSplitContainer
            // 
            this.aclSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aclSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.aclSplitContainer.Name = "aclSplitContainer";
            // 
            // aclSplitContainer.Panel1
            // 
            this.aclSplitContainer.Panel1.Controls.Add(this.aclTab);
            // 
            // aclSplitContainer.Panel2
            // 
            this.aclSplitContainer.Panel2.Controls.Add(this.aclDelete);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclLabelAccounts);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclCancel);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclApply);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclEdit);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclRemove);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclAdd);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclLabelPath);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclLabelPort);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclLabelHostname);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclHostname);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclPath);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclPort);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclSsl);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclCreate);
            this.aclSplitContainer.Panel2.Controls.Add(this.aclAccounts);
            this.aclSplitContainer.Size = new System.Drawing.Size(669, 480);
            this.aclSplitContainer.SplitterDistance = 280;
            this.aclSplitContainer.TabIndex = 1;
            // 
            // aclTab
            // 
            this.aclTab.Controls.Add(this.aclListTab);
            this.aclTab.Controls.Add(this.aclTreeTab);
            this.aclTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aclTab.Location = new System.Drawing.Point(0, 0);
            this.aclTab.Name = "aclTab";
            this.aclTab.SelectedIndex = 0;
            this.aclTab.Size = new System.Drawing.Size(280, 480);
            this.aclTab.TabIndex = 4;
            // 
            // aclListTab
            // 
            this.aclListTab.Controls.Add(this.aclList);
            this.aclListTab.Location = new System.Drawing.Point(4, 22);
            this.aclListTab.Name = "aclListTab";
            this.aclListTab.Padding = new System.Windows.Forms.Padding(3);
            this.aclListTab.Size = new System.Drawing.Size(272, 454);
            this.aclListTab.TabIndex = 2;
            this.aclListTab.Text = "List View";
            this.aclListTab.UseVisualStyleBackColor = true;
            // 
            // aclList
            // 
            this.aclList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aclList.FormattingEnabled = true;
            this.aclList.Location = new System.Drawing.Point(3, 3);
            this.aclList.Name = "aclList";
            this.aclList.Size = new System.Drawing.Size(266, 446);
            this.aclList.TabIndex = 0;
            this.aclList.SelectedIndexChanged += new System.EventHandler(this.aclList_SelectedIndexChanged);
            // 
            // aclTreeTab
            // 
            this.aclTreeTab.Controls.Add(this.aclTree);
            this.aclTreeTab.Location = new System.Drawing.Point(4, 22);
            this.aclTreeTab.Name = "aclTreeTab";
            this.aclTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.aclTreeTab.Size = new System.Drawing.Size(272, 454);
            this.aclTreeTab.TabIndex = 1;
            this.aclTreeTab.Text = "Tree View";
            this.aclTreeTab.UseVisualStyleBackColor = true;
            // 
            // aclTree
            // 
            this.aclTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aclTree.Location = new System.Drawing.Point(3, 3);
            this.aclTree.Name = "aclTree";
            this.aclTree.Size = new System.Drawing.Size(266, 448);
            this.aclTree.TabIndex = 20;
            this.aclTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.aclTree_AfterSelect);
            // 
            // aclDelete
            // 
            this.aclDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aclDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.aclDelete.Location = new System.Drawing.Point(143, 452);
            this.aclDelete.Name = "aclDelete";
            this.aclDelete.Size = new System.Drawing.Size(75, 23);
            this.aclDelete.TabIndex = 35;
            this.aclDelete.Text = "Delete";
            this.aclDelete.UseVisualStyleBackColor = true;
            this.aclDelete.Click += new System.EventHandler(this.aclDelete_Click);
            // 
            // aclLabelAccounts
            // 
            this.aclLabelAccounts.AutoSize = true;
            this.aclLabelAccounts.Location = new System.Drawing.Point(0, 108);
            this.aclLabelAccounts.Name = "aclLabelAccounts";
            this.aclLabelAccounts.Size = new System.Drawing.Size(55, 13);
            this.aclLabelAccounts.TabIndex = 57;
            this.aclLabelAccounts.Text = "Accounts:";
            // 
            // aclCancel
            // 
            this.aclCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aclCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.aclCancel.Location = new System.Drawing.Point(305, 423);
            this.aclCancel.Name = "aclCancel";
            this.aclCancel.Size = new System.Drawing.Size(75, 23);
            this.aclCancel.TabIndex = 55;
            this.aclCancel.Text = "Cancel";
            this.aclCancel.UseVisualStyleBackColor = true;
            this.aclCancel.Click += new System.EventHandler(this.aclCancel_Click);
            // 
            // aclApply
            // 
            this.aclApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aclApply.Cursor = System.Windows.Forms.Cursors.Default;
            this.aclApply.Location = new System.Drawing.Point(224, 423);
            this.aclApply.Name = "aclApply";
            this.aclApply.Size = new System.Drawing.Size(75, 23);
            this.aclApply.TabIndex = 50;
            this.aclApply.Text = "Apply";
            this.aclApply.UseVisualStyleBackColor = true;
            this.aclApply.Click += new System.EventHandler(this.aclApply_Click);
            // 
            // aclEdit
            // 
            this.aclEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aclEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.aclEdit.Location = new System.Drawing.Point(224, 452);
            this.aclEdit.Name = "aclEdit";
            this.aclEdit.Size = new System.Drawing.Size(75, 23);
            this.aclEdit.TabIndex = 40;
            this.aclEdit.Text = "Edit";
            this.aclEdit.UseVisualStyleBackColor = true;
            this.aclEdit.Click += new System.EventHandler(this.aclEdit_Click);
            // 
            // aclRemove
            // 
            this.aclRemove.Location = new System.Drawing.Point(84, 238);
            this.aclRemove.Name = "aclRemove";
            this.aclRemove.Size = new System.Drawing.Size(75, 23);
            this.aclRemove.TabIndex = 30;
            this.aclRemove.Text = "Remove";
            this.aclRemove.UseVisualStyleBackColor = true;
            this.aclRemove.Click += new System.EventHandler(this.aclRemove_Click);
            // 
            // aclAdd
            // 
            this.aclAdd.Location = new System.Drawing.Point(0, 238);
            this.aclAdd.Name = "aclAdd";
            this.aclAdd.Size = new System.Drawing.Size(75, 23);
            this.aclAdd.TabIndex = 25;
            this.aclAdd.Text = "Add";
            this.aclAdd.UseVisualStyleBackColor = true;
            this.aclAdd.Click += new System.EventHandler(this.aclAdd_Click);
            // 
            // aclLabelPath
            // 
            this.aclLabelPath.AutoSize = true;
            this.aclLabelPath.Location = new System.Drawing.Point(0, 84);
            this.aclLabelPath.Name = "aclLabelPath";
            this.aclLabelPath.Size = new System.Drawing.Size(32, 13);
            this.aclLabelPath.TabIndex = 50;
            this.aclLabelPath.Text = "Path:";
            // 
            // aclLabelPort
            // 
            this.aclLabelPort.AutoSize = true;
            this.aclLabelPort.Location = new System.Drawing.Point(0, 60);
            this.aclLabelPort.Name = "aclLabelPort";
            this.aclLabelPort.Size = new System.Drawing.Size(53, 13);
            this.aclLabelPort.TabIndex = 49;
            this.aclLabelPort.Text = "TCP Port:";
            // 
            // aclLabelHostname
            // 
            this.aclLabelHostname.AutoSize = true;
            this.aclLabelHostname.Location = new System.Drawing.Point(0, 36);
            this.aclLabelHostname.Name = "aclLabelHostname";
            this.aclLabelHostname.Size = new System.Drawing.Size(58, 13);
            this.aclLabelHostname.TabIndex = 48;
            this.aclLabelHostname.Text = "Hostname:";
            // 
            // aclHostname
            // 
            this.aclHostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aclHostname.FormattingEnabled = true;
            this.aclHostname.ItemHeight = 13;
            this.aclHostname.Location = new System.Drawing.Point(64, 32);
            this.aclHostname.Name = "aclHostname";
            this.aclHostname.Size = new System.Drawing.Size(316, 21);
            this.aclHostname.TabIndex = 8;
            // 
            // aclPath
            // 
            this.aclPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aclPath.Location = new System.Drawing.Point(64, 80);
            this.aclPath.Name = "aclPath";
            this.aclPath.Size = new System.Drawing.Size(316, 20);
            this.aclPath.TabIndex = 15;
            // 
            // aclPort
            // 
            this.aclPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aclPort.Location = new System.Drawing.Point(64, 56);
            this.aclPort.Name = "aclPort";
            this.aclPort.Size = new System.Drawing.Size(316, 20);
            this.aclPort.TabIndex = 12;
            // 
            // aclSsl
            // 
            this.aclSsl.AutoSize = true;
            this.aclSsl.Location = new System.Drawing.Point(3, 9);
            this.aclSsl.Name = "aclSsl";
            this.aclSsl.Size = new System.Drawing.Size(82, 17);
            this.aclSsl.TabIndex = 5;
            this.aclSsl.Text = "Enable SSL";
            this.aclSsl.UseVisualStyleBackColor = true;
            this.aclSsl.CheckedChanged += new System.EventHandler(this.aclSsl_CheckedChanged);
            // 
            // aclCreate
            // 
            this.aclCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aclCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.aclCreate.Location = new System.Drawing.Point(305, 452);
            this.aclCreate.Name = "aclCreate";
            this.aclCreate.Size = new System.Drawing.Size(75, 23);
            this.aclCreate.TabIndex = 45;
            this.aclCreate.Text = "Create";
            this.aclCreate.UseVisualStyleBackColor = true;
            this.aclCreate.Click += new System.EventHandler(this.aclCreate_Click);
            // 
            // aclAccounts
            // 
            this.aclAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aclAccounts.FormattingEnabled = true;
            this.aclAccounts.Location = new System.Drawing.Point(0, 132);
            this.aclAccounts.Name = "aclAccounts";
            this.aclAccounts.Size = new System.Drawing.Size(380, 95);
            this.aclAccounts.TabIndex = 20;
            // 
            // sslTabPage
            // 
            this.sslTabPage.Controls.Add(this.sslSplitContainer);
            this.sslTabPage.Location = new System.Drawing.Point(4, 22);
            this.sslTabPage.Name = "sslTabPage";
            this.sslTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sslTabPage.Size = new System.Drawing.Size(675, 486);
            this.sslTabPage.TabIndex = 4;
            this.sslTabPage.Text = "Ssl";
            this.sslTabPage.UseVisualStyleBackColor = true;
            // 
            // sslSplitContainer
            // 
            this.sslSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sslSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.sslSplitContainer.Name = "sslSplitContainer";
            // 
            // sslSplitContainer.Panel1
            // 
            this.sslSplitContainer.Panel1.Controls.Add(this.sslTab);
            // 
            // sslSplitContainer.Panel2
            // 
            this.sslSplitContainer.Panel2.Controls.Add(this.sslLabelAppID);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslAppId);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslGroupBoxClientCert);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslCertStore);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslNegotiateClientCert);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslBrowse);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslRawFilter);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslLabelCertStore);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslDelete);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslCancel);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslApply);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslEdit);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslLabelCertHash);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslLabelPort);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslLabelAddress);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslAddress);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslCertHash);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslPort);
            this.sslSplitContainer.Panel2.Controls.Add(this.sslCreate);
            this.sslSplitContainer.Size = new System.Drawing.Size(669, 480);
            this.sslSplitContainer.SplitterDistance = 280;
            this.sslSplitContainer.TabIndex = 1;
            // 
            // sslTab
            // 
            this.sslTab.Controls.Add(this.sslListTab);
            this.sslTab.Controls.Add(this.sslTreeTab);
            this.sslTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sslTab.Location = new System.Drawing.Point(0, 0);
            this.sslTab.Name = "sslTab";
            this.sslTab.SelectedIndex = 0;
            this.sslTab.Size = new System.Drawing.Size(280, 480);
            this.sslTab.TabIndex = 4;
            // 
            // sslListTab
            // 
            this.sslListTab.Controls.Add(this.sslList);
            this.sslListTab.Location = new System.Drawing.Point(4, 22);
            this.sslListTab.Name = "sslListTab";
            this.sslListTab.Padding = new System.Windows.Forms.Padding(3);
            this.sslListTab.Size = new System.Drawing.Size(272, 454);
            this.sslListTab.TabIndex = 2;
            this.sslListTab.Text = "List View";
            this.sslListTab.UseVisualStyleBackColor = true;
            // 
            // sslList
            // 
            this.sslList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sslList.FormattingEnabled = true;
            this.sslList.Location = new System.Drawing.Point(3, 3);
            this.sslList.Name = "sslList";
            this.sslList.Size = new System.Drawing.Size(266, 446);
            this.sslList.TabIndex = 0;
            this.sslList.SelectedIndexChanged += new System.EventHandler(this.sslList_SelectedIndexChanged);
            // 
            // sslTreeTab
            // 
            this.sslTreeTab.Controls.Add(this.sslTree);
            this.sslTreeTab.Location = new System.Drawing.Point(4, 22);
            this.sslTreeTab.Name = "sslTreeTab";
            this.sslTreeTab.Padding = new System.Windows.Forms.Padding(3);
            this.sslTreeTab.Size = new System.Drawing.Size(272, 454);
            this.sslTreeTab.TabIndex = 1;
            this.sslTreeTab.Text = "Tree View";
            this.sslTreeTab.UseVisualStyleBackColor = true;
            // 
            // sslTree
            // 
            this.sslTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sslTree.Location = new System.Drawing.Point(3, 3);
            this.sslTree.Name = "sslTree";
            this.sslTree.Size = new System.Drawing.Size(266, 448);
            this.sslTree.TabIndex = 20;
            // 
            // sslLabelAppID
            // 
            this.sslLabelAppID.AutoSize = true;
            this.sslLabelAppID.Location = new System.Drawing.Point(3, 60);
            this.sslLabelAppID.Name = "sslLabelAppID";
            this.sslLabelAppID.Size = new System.Drawing.Size(41, 13);
            this.sslLabelAppID.TabIndex = 78;
            this.sslLabelAppID.Text = "App Id:";
            // 
            // sslAppId
            // 
            this.sslAppId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslAppId.Location = new System.Drawing.Point(89, 57);
            this.sslAppId.Name = "sslAppId";
            this.sslAppId.Size = new System.Drawing.Size(291, 20);
            this.sslAppId.TabIndex = 77;
            // 
            // sslGroupBoxClientCert
            // 
            this.sslGroupBoxClientCert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslGroupBoxClientCert.Controls.Add(this.sslCheckRevocation);
            this.sslGroupBoxClientCert.Controls.Add(this.sslGroupBoxRevocation);
            this.sslGroupBoxClientCert.Controls.Add(this.sslCeckUsage);
            this.sslGroupBoxClientCert.Controls.Add(this.sslUseDSMapper);
            this.sslGroupBoxClientCert.Location = new System.Drawing.Point(3, 183);
            this.sslGroupBoxClientCert.Name = "sslGroupBoxClientCert";
            this.sslGroupBoxClientCert.Size = new System.Drawing.Size(377, 200);
            this.sslGroupBoxClientCert.TabIndex = 76;
            this.sslGroupBoxClientCert.TabStop = false;
            this.sslGroupBoxClientCert.Text = "Client Certificate Settings";
            // 
            // sslCheckRevocation
            // 
            this.sslCheckRevocation.AutoSize = true;
            this.sslCheckRevocation.Checked = true;
            this.sslCheckRevocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sslCheckRevocation.Location = new System.Drawing.Point(6, 63);
            this.sslCheckRevocation.Name = "sslCheckRevocation";
            this.sslCheckRevocation.Size = new System.Drawing.Size(130, 17);
            this.sslCheckRevocation.TabIndex = 92;
            this.sslCheckRevocation.Text = "Check for Revocation";
            this.sslCheckRevocation.UseVisualStyleBackColor = true;
            this.sslCheckRevocation.CheckedChanged += new System.EventHandler(this.sslCheckRevocation_CheckedChanged);
            // 
            // sslGroupBoxRevocation
            // 
            this.sslGroupBoxRevocation.Controls.Add(this.sslCheckFresh);
            this.sslGroupBoxRevocation.Controls.Add(this.sslCheckOnlyCached);
            this.sslGroupBoxRevocation.Controls.Add(this.sslLabelDownloadTimeout);
            this.sslGroupBoxRevocation.Controls.Add(this.sslDownload);
            this.sslGroupBoxRevocation.Controls.Add(this.sslLabelFreshness);
            this.sslGroupBoxRevocation.Controls.Add(this.sslFreshness);
            this.sslGroupBoxRevocation.Location = new System.Drawing.Point(6, 86);
            this.sslGroupBoxRevocation.Name = "sslGroupBoxRevocation";
            this.sslGroupBoxRevocation.Size = new System.Drawing.Size(364, 108);
            this.sslGroupBoxRevocation.TabIndex = 87;
            this.sslGroupBoxRevocation.TabStop = false;
            this.sslGroupBoxRevocation.Text = "Revocation Check Settings";
            // 
            // sslCheckFresh
            // 
            this.sslCheckFresh.AutoSize = true;
            this.sslCheckFresh.Location = new System.Drawing.Point(6, 59);
            this.sslCheckFresh.Name = "sslCheckFresh";
            this.sslCheckFresh.Size = new System.Drawing.Size(186, 17);
            this.sslCheckFresh.TabIndex = 94;
            this.sslCheckFresh.Text = "Cache URLs with Freshness Time";
            this.sslCheckFresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sslCheckFresh.UseVisualStyleBackColor = true;
            // 
            // sslCheckOnlyCached
            // 
            this.sslCheckOnlyCached.AutoSize = true;
            this.sslCheckOnlyCached.Location = new System.Drawing.Point(6, 38);
            this.sslCheckOnlyCached.Name = "sslCheckOnlyCached";
            this.sslCheckOnlyCached.Size = new System.Drawing.Size(151, 17);
            this.sslCheckOnlyCached.TabIndex = 93;
            this.sslCheckOnlyCached.Text = "Only Check Cached URLs";
            this.sslCheckOnlyCached.UseVisualStyleBackColor = true;
            // 
            // sslLabelDownloadTimeout
            // 
            this.sslLabelDownloadTimeout.AutoSize = true;
            this.sslLabelDownloadTimeout.Location = new System.Drawing.Point(3, 21);
            this.sslLabelDownloadTimeout.Name = "sslLabelDownloadTimeout";
            this.sslLabelDownloadTimeout.Size = new System.Drawing.Size(145, 13);
            this.sslLabelDownloadTimeout.TabIndex = 90;
            this.sslLabelDownloadTimeout.Text = "CRL Download Timeout (ms):";
            // 
            // sslDownload
            // 
            this.sslDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslDownload.Location = new System.Drawing.Point(154, 19);
            this.sslDownload.Name = "sslDownload";
            this.sslDownload.Size = new System.Drawing.Size(201, 20);
            this.sslDownload.TabIndex = 89;
            // 
            // sslLabelFreshness
            // 
            this.sslLabelFreshness.AutoSize = true;
            this.sslLabelFreshness.Location = new System.Drawing.Point(22, 80);
            this.sslLabelFreshness.Name = "sslLabelFreshness";
            this.sslLabelFreshness.Size = new System.Drawing.Size(122, 13);
            this.sslLabelFreshness.TabIndex = 88;
            this.sslLabelFreshness.Text = "CRL Freshness Time (s):";
            // 
            // sslFreshness
            // 
            this.sslFreshness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslFreshness.Location = new System.Drawing.Point(154, 77);
            this.sslFreshness.Name = "sslFreshness";
            this.sslFreshness.Size = new System.Drawing.Size(201, 20);
            this.sslFreshness.TabIndex = 87;
            // 
            // sslCeckUsage
            // 
            this.sslCeckUsage.AutoSize = true;
            this.sslCeckUsage.Location = new System.Drawing.Point(6, 19);
            this.sslCeckUsage.Name = "sslCeckUsage";
            this.sslCeckUsage.Size = new System.Drawing.Size(91, 17);
            this.sslCeckUsage.TabIndex = 84;
            this.sslCeckUsage.Text = "Check Usage";
            this.sslCeckUsage.UseVisualStyleBackColor = true;
            // 
            // sslUseDSMapper
            // 
            this.sslUseDSMapper.AutoSize = true;
            this.sslUseDSMapper.Location = new System.Drawing.Point(6, 41);
            this.sslUseDSMapper.Name = "sslUseDSMapper";
            this.sslUseDSMapper.Size = new System.Drawing.Size(145, 17);
            this.sslUseDSMapper.TabIndex = 81;
            this.sslUseDSMapper.Text = "Map to NT User Account";
            this.sslUseDSMapper.UseVisualStyleBackColor = true;
            // 
            // sslCertStore
            // 
            this.sslCertStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslCertStore.FormattingEnabled = true;
            this.sslCertStore.ItemHeight = 13;
            this.sslCertStore.Location = new System.Drawing.Point(89, 85);
            this.sslCertStore.Name = "sslCertStore";
            this.sslCertStore.Size = new System.Drawing.Size(210, 21);
            this.sslCertStore.TabIndex = 73;
            this.sslCertStore.SelectedIndexChanged += new System.EventHandler(this.sslCertStore_SelectedIndexChanged);
            // 
            // sslNegotiateClientCert
            // 
            this.sslNegotiateClientCert.AutoSize = true;
            this.sslNegotiateClientCert.Location = new System.Drawing.Point(2, 160);
            this.sslNegotiateClientCert.Name = "sslNegotiateClientCert";
            this.sslNegotiateClientCert.Size = new System.Drawing.Size(151, 17);
            this.sslNegotiateClientCert.TabIndex = 67;
            this.sslNegotiateClientCert.Text = "Negotiate Client Certificate";
            this.sslNegotiateClientCert.UseVisualStyleBackColor = true;
            this.sslNegotiateClientCert.CheckedChanged += new System.EventHandler(this.sslNegotiateClientCert_CheckedChanged);
            // 
            // sslBrowse
            // 
            this.sslBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sslBrowse.Location = new System.Drawing.Point(305, 83);
            this.sslBrowse.Name = "sslBrowse";
            this.sslBrowse.Size = new System.Drawing.Size(75, 23);
            this.sslBrowse.TabIndex = 66;
            this.sslBrowse.Text = "Browse";
            this.sslBrowse.UseVisualStyleBackColor = true;
            this.sslBrowse.Click += new System.EventHandler(this.sslBrowse_Click);
            // 
            // sslRawFilter
            // 
            this.sslRawFilter.AutoSize = true;
            this.sslRawFilter.Location = new System.Drawing.Point(2, 136);
            this.sslRawFilter.Name = "sslRawFilter";
            this.sslRawFilter.Size = new System.Drawing.Size(182, 17);
            this.sslRawFilter.TabIndex = 80;
            this.sslRawFilter.Text = "No Raw Filter (IIS 6.0 and below)";
            this.sslRawFilter.UseVisualStyleBackColor = true;
            // 
            // sslLabelCertStore
            // 
            this.sslLabelCertStore.AutoSize = true;
            this.sslLabelCertStore.Location = new System.Drawing.Point(3, 88);
            this.sslLabelCertStore.Name = "sslLabelCertStore";
            this.sslLabelCertStore.Size = new System.Drawing.Size(85, 13);
            this.sslLabelCertStore.TabIndex = 57;
            this.sslLabelCertStore.Text = "Certificate Store:";
            // 
            // sslDelete
            // 
            this.sslDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sslDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.sslDelete.Location = new System.Drawing.Point(143, 450);
            this.sslDelete.Name = "sslDelete";
            this.sslDelete.Size = new System.Drawing.Size(75, 23);
            this.sslDelete.TabIndex = 35;
            this.sslDelete.Text = "Delete";
            this.sslDelete.UseVisualStyleBackColor = true;
            this.sslDelete.Click += new System.EventHandler(this.sslDelete_Click);
            // 
            // sslCancel
            // 
            this.sslCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sslCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.sslCancel.Location = new System.Drawing.Point(305, 421);
            this.sslCancel.Name = "sslCancel";
            this.sslCancel.Size = new System.Drawing.Size(75, 23);
            this.sslCancel.TabIndex = 55;
            this.sslCancel.Text = "Cancel";
            this.sslCancel.UseVisualStyleBackColor = true;
            this.sslCancel.Click += new System.EventHandler(this.sslCancel_Click);
            // 
            // sslApply
            // 
            this.sslApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sslApply.Cursor = System.Windows.Forms.Cursors.Default;
            this.sslApply.Location = new System.Drawing.Point(224, 421);
            this.sslApply.Name = "sslApply";
            this.sslApply.Size = new System.Drawing.Size(75, 23);
            this.sslApply.TabIndex = 50;
            this.sslApply.Text = "Apply";
            this.sslApply.UseVisualStyleBackColor = true;
            this.sslApply.Click += new System.EventHandler(this.sslApply_Click);
            // 
            // sslEdit
            // 
            this.sslEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sslEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.sslEdit.Location = new System.Drawing.Point(224, 450);
            this.sslEdit.Name = "sslEdit";
            this.sslEdit.Size = new System.Drawing.Size(75, 23);
            this.sslEdit.TabIndex = 40;
            this.sslEdit.Text = "Edit";
            this.sslEdit.UseVisualStyleBackColor = true;
            this.sslEdit.Click += new System.EventHandler(this.sslEdit_Click);
            // 
            // sslLabelCertHash
            // 
            this.sslLabelCertHash.AutoSize = true;
            this.sslLabelCertHash.Location = new System.Drawing.Point(3, 110);
            this.sslLabelCertHash.Name = "sslLabelCertHash";
            this.sslLabelCertHash.Size = new System.Drawing.Size(85, 13);
            this.sslLabelCertHash.TabIndex = 50;
            this.sslLabelCertHash.Text = "Certificate Hash:";
            // 
            // sslLabelPort
            // 
            this.sslLabelPort.AutoSize = true;
            this.sslLabelPort.Location = new System.Drawing.Point(3, 34);
            this.sslLabelPort.Name = "sslLabelPort";
            this.sslLabelPort.Size = new System.Drawing.Size(53, 13);
            this.sslLabelPort.TabIndex = 49;
            this.sslLabelPort.Text = "TCP Port:";
            // 
            // sslLabelAddress
            // 
            this.sslLabelAddress.AutoSize = true;
            this.sslLabelAddress.Location = new System.Drawing.Point(3, 9);
            this.sslLabelAddress.Name = "sslLabelAddress";
            this.sslLabelAddress.Size = new System.Drawing.Size(61, 13);
            this.sslLabelAddress.TabIndex = 48;
            this.sslLabelAddress.Text = "IP Address:";
            // 
            // sslAddress
            // 
            this.sslAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslAddress.FormattingEnabled = true;
            this.sslAddress.ItemHeight = 13;
            this.sslAddress.Location = new System.Drawing.Point(89, 6);
            this.sslAddress.Name = "sslAddress";
            this.sslAddress.Size = new System.Drawing.Size(291, 21);
            this.sslAddress.TabIndex = 8;
            // 
            // sslCertHash
            // 
            this.sslCertHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslCertHash.Location = new System.Drawing.Point(89, 110);
            this.sslCertHash.Name = "sslCertHash";
            this.sslCertHash.Size = new System.Drawing.Size(291, 21);
            this.sslCertHash.TabIndex = 15;
            // 
            // sslPort
            // 
            this.sslPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sslPort.Location = new System.Drawing.Point(89, 31);
            this.sslPort.Name = "sslPort";
            this.sslPort.Size = new System.Drawing.Size(291, 20);
            this.sslPort.TabIndex = 12;
            // 
            // sslCreate
            // 
            this.sslCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sslCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.sslCreate.Location = new System.Drawing.Point(305, 450);
            this.sslCreate.Name = "sslCreate";
            this.sslCreate.Size = new System.Drawing.Size(75, 23);
            this.sslCreate.TabIndex = 45;
            this.sslCreate.Text = "Create";
            this.sslCreate.UseVisualStyleBackColor = true;
            this.sslCreate.Click += new System.EventHandler(this.sslCreate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 536);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.Text = "HttpSysConfig";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.aclTabPage.ResumeLayout(false);
            this.aclSplitContainer.Panel1.ResumeLayout(false);
            this.aclSplitContainer.Panel2.ResumeLayout(false);
            this.aclSplitContainer.Panel2.PerformLayout();
            this.aclSplitContainer.ResumeLayout(false);
            this.aclTab.ResumeLayout(false);
            this.aclListTab.ResumeLayout(false);
            this.aclTreeTab.ResumeLayout(false);
            this.sslTabPage.ResumeLayout(false);
            this.sslSplitContainer.Panel1.ResumeLayout(false);
            this.sslSplitContainer.Panel2.ResumeLayout(false);
            this.sslSplitContainer.Panel2.PerformLayout();
            this.sslSplitContainer.ResumeLayout(false);
            this.sslTab.ResumeLayout(false);
            this.sslListTab.ResumeLayout(false);
            this.sslTreeTab.ResumeLayout(false);
            this.sslGroupBoxClientCert.ResumeLayout(false);
            this.sslGroupBoxClientCert.PerformLayout();
            this.sslGroupBoxRevocation.ResumeLayout(false);
            this.sslGroupBoxRevocation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
