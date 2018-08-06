namespace RdpTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.tabMain = new MetroFramework.Controls.MetroTabControl();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.panelBody = new System.Windows.Forms.Panel();
            this.pnlSetting = new MetroFramework.Controls.MetroPanel();
            this.btnAbout = new MetroFramework.Controls.MetroLink();
            this.btnAddRemoteHost = new MetroFramework.Controls.MetroLink();
            this.btnRefresh = new MetroFramework.Controls.MetroLink();
            this.btnChangeStyle = new MetroFramework.Controls.MetroTile();
            this.menuTitle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteHost = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiCloseHost = new System.Windows.Forms.ToolStripMenuItem();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.menuTitle.SuspendLayout();
            this.menuTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageMain);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(20, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(6, 8);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(572, 354);
            this.tabMain.TabIndex = 0;
            this.tabMain.UseSelectable = true;
            this.tabMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseDown);
            this.tabMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseMove);
            this.tabMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseUp);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.panelBody);
            this.pageMain.Controls.Add(this.pnlSetting);
            this.pageMain.Location = new System.Drawing.Point(4, 38);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(564, 312);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "可用";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 3);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(558, 269);
            this.panelBody.TabIndex = 4;
            // 
            // pnlSetting
            // 
            this.pnlSetting.Controls.Add(this.btnAbout);
            this.pnlSetting.Controls.Add(this.btnAddRemoteHost);
            this.pnlSetting.Controls.Add(this.btnRefresh);
            this.pnlSetting.Controls.Add(this.btnChangeStyle);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSetting.HorizontalScrollbarBarColor = true;
            this.pnlSetting.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlSetting.HorizontalScrollbarSize = 10;
            this.pnlSetting.Location = new System.Drawing.Point(3, 272);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(558, 37);
            this.pnlSetting.TabIndex = 0;
            this.pnlSetting.VerticalScrollbarBarColor = true;
            this.pnlSetting.VerticalScrollbarHighlightOnWheel = false;
            this.pnlSetting.VerticalScrollbarSize = 10;
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAbout.Location = new System.Drawing.Point(268, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(67, 37);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseSelectable = true;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnAddRemoteHost
            // 
            this.btnAddRemoteHost.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddRemoteHost.Location = new System.Drawing.Point(152, 0);
            this.btnAddRemoteHost.Name = "btnAddRemoteHost";
            this.btnAddRemoteHost.Size = new System.Drawing.Size(116, 37);
            this.btnAddRemoteHost.TabIndex = 4;
            this.btnAddRemoteHost.Text = "添加远程主机";
            this.btnAddRemoteHost.UseSelectable = true;
            this.btnAddRemoteHost.UseVisualStyleBackColor = true;
            this.btnAddRemoteHost.Click += new System.EventHandler(this.btnAddRemoteHost_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(85, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 37);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnChangeStyle
            // 
            this.btnChangeStyle.ActiveControl = null;
            this.btnChangeStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChangeStyle.Location = new System.Drawing.Point(0, 0);
            this.btnChangeStyle.Name = "btnChangeStyle";
            this.btnChangeStyle.Size = new System.Drawing.Size(85, 37);
            this.btnChangeStyle.TabIndex = 2;
            this.btnChangeStyle.Text = "切换主题";
            this.btnChangeStyle.UseSelectable = true;
            this.btnChangeStyle.UseVisualStyleBackColor = true;
            this.btnChangeStyle.Click += new System.EventHandler(this.btnChangeStyle_Click);
            // 
            // menuTitle
            // 
            this.menuTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiEdit,
            this.tmiDelete});
            this.menuTitle.Name = "menu";
            this.menuTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuTitle.Size = new System.Drawing.Size(101, 48);
            // 
            // tmiEdit
            // 
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(100, 22);
            this.tmiEdit.Text = "编辑";
            this.tmiEdit.Click += new System.EventHandler(this.tmiEdit_Click);
            // 
            // tmiDelete
            // 
            this.tmiDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiDeleteHost,
            this.tmiDeleteAll});
            this.tmiDelete.Name = "tmiDelete";
            this.tmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tmiDelete.Text = "删除";
            // 
            // tmiDeleteHost
            // 
            this.tmiDeleteHost.Name = "tmiDeleteHost";
            this.tmiDeleteHost.Size = new System.Drawing.Size(172, 22);
            this.tmiDeleteHost.Text = "确认无误，删除！";
            this.tmiDeleteHost.Click += new System.EventHandler(this.tmiDeleteHost_Click);
            // 
            // tmiDeleteAll
            // 
            this.tmiDeleteAll.Name = "tmiDeleteAll";
            this.tmiDeleteAll.Size = new System.Drawing.Size(172, 22);
            this.tmiDeleteAll.Text = "连同父级一起删除";
            this.tmiDeleteAll.Click += new System.EventHandler(this.tmiDeleteAll_Click);
            // 
            // menuTabPage
            // 
            this.menuTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCloseHost});
            this.menuTabPage.Name = "menu";
            this.menuTabPage.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuTabPage.Size = new System.Drawing.Size(101, 26);
            // 
            // tmiCloseHost
            // 
            this.tmiCloseHost.Name = "tmiCloseHost";
            this.tmiCloseHost.Size = new System.Drawing.Size(100, 22);
            this.tmiCloseHost.Text = "关闭";
            this.tmiCloseHost.Click += new System.EventHandler(this.tmiCloseHost_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 434);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "远程桌面管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.tabMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            this.menuTitle.ResumeLayout(false);
            this.menuTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabMain;
        private System.Windows.Forms.TabPage pageMain;
        private MetroFramework.Controls.MetroPanel pnlSetting;
        private MetroFramework.Controls.MetroTile btnChangeStyle;
        private MetroFramework.Controls.MetroLink btnRefresh;
        private MetroFramework.Controls.MetroLink btnAddRemoteHost;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.ContextMenuStrip menuTitle;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteHost;
        private System.Windows.Forms.ToolStripMenuItem tmiDeleteAll;
        private System.Windows.Forms.ContextMenuStrip menuTabPage;
        private System.Windows.Forms.ToolStripMenuItem tmiCloseHost;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroLink btnAbout;
    }
}