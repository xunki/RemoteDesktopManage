namespace 远程桌面管理器
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new Wisder.W3Common.WMetroControl.Controls.MetroTabControl();
            this.pageManage = new System.Windows.Forms.TabPage();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelSetting = new Wisder.W3Common.WMetroControl.Controls.MetroPanel();
            this.btnClear = new Wisder.W3Common.WMetroControl.Controls.MetroLink();
            this.btnAddRemoteHost = new Wisder.W3Common.WMetroControl.Controls.MetroLink();
            this.btnAddIpAddress = new Wisder.W3Common.WMetroControl.Controls.MetroLink();
            this.btnRefresh = new Wisder.W3Common.WMetroControl.Controls.MetroLink();
            this.btnSetStyle = new Wisder.W3Common.WMetroControl.Controls.MetroTile();
            this.menuTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.独立窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroStyleManager = new Wisder.W3Common.WMetroControl.Components.MetroStyleManager(this.components);
            this.menuTitle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.确认无误删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连同父级一起删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.pageManage.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.menuTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.menuTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Controls.Add(this.pageManage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(6, 8);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(756, 402);
            this.tabControl.TabIndex = 0;
            this.tabControl.UseSelectable = true;
            this.tabControl.DoubleClick += new System.EventHandler(this.tabControl_DoubleClick);
            this.tabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseDown);
            // 
            // pageManage
            // 
            this.pageManage.Controls.Add(this.panelBody);
            this.pageManage.Controls.Add(this.panelSetting);
            this.pageManage.Location = new System.Drawing.Point(4, 38);
            this.pageManage.Name = "pageManage";
            this.pageManage.Padding = new System.Windows.Forms.Padding(3);
            this.pageManage.Size = new System.Drawing.Size(748, 360);
            this.pageManage.TabIndex = 0;
            this.pageManage.Text = "可用";
            this.pageManage.UseVisualStyleBackColor = true;
            // 
            // panelBody
            // 
            this.panelBody.AutoScroll = true;
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(3, 3);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(742, 320);
            this.panelBody.TabIndex = 3;
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.btnClear);
            this.panelSetting.Controls.Add(this.btnAddRemoteHost);
            this.panelSetting.Controls.Add(this.btnAddIpAddress);
            this.panelSetting.Controls.Add(this.btnRefresh);
            this.panelSetting.Controls.Add(this.btnSetStyle);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSetting.HorizontalScrollbarBarColor = true;
            this.panelSetting.HorizontalScrollbarHighlightOnWheel = false;
            this.panelSetting.HorizontalScrollbarSize = 10;
            this.panelSetting.Location = new System.Drawing.Point(3, 323);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(742, 34);
            this.panelSetting.TabIndex = 2;
            this.panelSetting.VerticalScrollbarBarColor = true;
            this.panelSetting.VerticalScrollbarHighlightOnWheel = false;
            this.panelSetting.VerticalScrollbarSize = 10;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Location = new System.Drawing.Point(400, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 34);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清理无效项";
            this.btnClear.UseSelectable = true;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddRemoteHost
            // 
            this.btnAddRemoteHost.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddRemoteHost.Location = new System.Drawing.Point(306, 0);
            this.btnAddRemoteHost.Name = "btnAddRemoteHost";
            this.btnAddRemoteHost.Size = new System.Drawing.Size(94, 34);
            this.btnAddRemoteHost.TabIndex = 3;
            this.btnAddRemoteHost.Text = "添加远程主机";
            this.btnAddRemoteHost.UseSelectable = true;
            this.btnAddRemoteHost.UseVisualStyleBackColor = true;
            this.btnAddRemoteHost.Click += new System.EventHandler(this.btnAddRemoteHost_Click);
            // 
            // btnAddIpAddress
            // 
            this.btnAddIpAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddIpAddress.Location = new System.Drawing.Point(212, 0);
            this.btnAddIpAddress.Name = "btnAddIpAddress";
            this.btnAddIpAddress.Size = new System.Drawing.Size(94, 34);
            this.btnAddIpAddress.TabIndex = 2;
            this.btnAddIpAddress.Text = "管理地址库";
            this.btnAddIpAddress.UseSelectable = true;
            this.btnAddIpAddress.UseVisualStyleBackColor = true;
            this.btnAddIpAddress.Click += new System.EventHandler(this.btnAddIpAddress_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(118, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 34);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSetStyle
            // 
            this.btnSetStyle.ActiveControl = null;
            this.btnSetStyle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetStyle.Location = new System.Drawing.Point(0, 0);
            this.btnSetStyle.Name = "btnSetStyle";
            this.btnSetStyle.Size = new System.Drawing.Size(118, 34);
            this.btnSetStyle.TabIndex = 4;
            this.btnSetStyle.Text = "切换主题[15/15]";
            this.btnSetStyle.UseSelectable = true;
            this.btnSetStyle.UseVisualStyleBackColor = true;
            this.btnSetStyle.Click += new System.EventHandler(this.btnSetStyle_Click);
            // 
            // menuTabPage
            // 
            this.menuTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem,
            this.全屏ToolStripMenuItem,
            this.独立窗口ToolStripMenuItem});
            this.menuTabPage.Name = "menu";
            this.menuTabPage.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuTabPage.Size = new System.Drawing.Size(123, 70);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 全屏ToolStripMenuItem
            // 
            this.全屏ToolStripMenuItem.Name = "全屏ToolStripMenuItem";
            this.全屏ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.全屏ToolStripMenuItem.Text = "全屏";
            this.全屏ToolStripMenuItem.Click += new System.EventHandler(this.全屏ToolStripMenuItem_Click);
            // 
            // 独立窗口ToolStripMenuItem
            // 
            this.独立窗口ToolStripMenuItem.Name = "独立窗口ToolStripMenuItem";
            this.独立窗口ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.独立窗口ToolStripMenuItem.Text = "独立窗口";
            this.独立窗口ToolStripMenuItem.Click += new System.EventHandler(this.独立窗口ToolStripMenuItem_Click);
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // menuTitle
            // 
            this.menuTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.menuTitle.Name = "menu";
            this.menuTitle.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuTitle.Size = new System.Drawing.Size(99, 48);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确认无误删除ToolStripMenuItem,
            this.连同父级一起删除ToolStripMenuItem});
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 确认无误删除ToolStripMenuItem
            // 
            this.确认无误删除ToolStripMenuItem.Name = "确认无误删除ToolStripMenuItem";
            this.确认无误删除ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.确认无误删除ToolStripMenuItem.Text = "确认无误，删除！";
            this.确认无误删除ToolStripMenuItem.Click += new System.EventHandler(this.确认无误删除ToolStripMenuItem_Click);
            // 
            // 连同父级一起删除ToolStripMenuItem
            // 
            this.连同父级一起删除ToolStripMenuItem.Name = "连同父级一起删除ToolStripMenuItem";
            this.连同父级一起删除ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.连同父级一起删除ToolStripMenuItem.Text = "连同父级一起删除";
            this.连同父级一起删除ToolStripMenuItem.Click += new System.EventHandler(this.连同父级一起删除ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 482);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Default;
            this.Text = "远程桌面管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.tabControl.ResumeLayout(false);
            this.pageManage.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.menuTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.menuTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisder.W3Common.WMetroControl.Controls.MetroTabControl tabControl;
        private System.Windows.Forms.TabPage pageManage;
        private System.Windows.Forms.ContextMenuStrip menuTabPage;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 独立窗口ToolStripMenuItem;
        private Wisder.W3Common.WMetroControl.Controls.MetroPanel panelSetting;
        private System.Windows.Forms.Panel panelBody;
        private Wisder.W3Common.WMetroControl.Controls.MetroLink btnAddIpAddress;
        private Wisder.W3Common.WMetroControl.Controls.MetroLink btnAddRemoteHost;
        private Wisder.W3Common.WMetroControl.Controls.MetroTile btnSetStyle;
        private Wisder.W3Common.WMetroControl.Components.MetroStyleManager metroStyleManager;
        private Wisder.W3Common.WMetroControl.Controls.MetroLink btnRefresh;
        private System.Windows.Forms.ContextMenuStrip menuTitle;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 确认无误删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连同父级一起删除ToolStripMenuItem;
        private Wisder.W3Common.WMetroControl.Controls.MetroLink btnClear;
    }
}

