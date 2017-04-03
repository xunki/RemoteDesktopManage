namespace 远程桌面管理器
{
    partial class IpAddressForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelAdd = new Wisder.W3Common.WMetroControl.Controls.MetroPanel();
            this.btnShowManage = new Wisder.W3Common.WControl.WButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.metroLabel3 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.metroLabel2 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.metroLabel1 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.btnCancel = new Wisder.W3Common.WControl.WButton();
            this.btnSave = new Wisder.W3Common.WControl.WButton();
            this.panelManage = new Wisder.W3Common.WMetroControl.Controls.MetroPanel();
            this.grid = new Wisder.W3Common.WMetroControl.Controls.MetroGrid();
            this.menuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.确认无误删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new Wisder.W3Common.WControl.WButton();
            this.btnClose = new Wisder.W3Common.WControl.WButton();
            this.btnShowAdd = new Wisder.W3Common.WControl.WButton();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.panelManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.btnShowManage);
            this.panelAdd.Controls.Add(this.label1);
            this.panelAdd.Controls.Add(this.txtIp);
            this.panelAdd.Controls.Add(this.txtPwd);
            this.panelAdd.Controls.Add(this.txtUser);
            this.panelAdd.Controls.Add(this.metroLabel4);
            this.panelAdd.Controls.Add(this.metroLabel3);
            this.panelAdd.Controls.Add(this.numPort);
            this.panelAdd.Controls.Add(this.metroLabel2);
            this.panelAdd.Controls.Add(this.metroLabel1);
            this.panelAdd.Controls.Add(this.btnCancel);
            this.panelAdd.Controls.Add(this.btnSave);
            this.panelAdd.HorizontalScrollbarBarColor = true;
            this.panelAdd.HorizontalScrollbarHighlightOnWheel = false;
            this.panelAdd.HorizontalScrollbarSize = 10;
            this.panelAdd.Location = new System.Drawing.Point(23, 57);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(285, 180);
            this.panelAdd.TabIndex = 14;
            this.panelAdd.VerticalScrollbarBarColor = true;
            this.panelAdd.VerticalScrollbarHighlightOnWheel = false;
            this.panelAdd.VerticalScrollbarSize = 10;
            // 
            // btnShowManage
            // 
            this.btnShowManage.BackColor = System.Drawing.Color.Transparent;
            this.btnShowManage.Image = global::远程桌面管理器.Properties.Resources.左;
            this.btnShowManage.Location = new System.Drawing.Point(4, 146);
            this.btnShowManage.Name = "btnShowManage";
            this.btnShowManage.Size = new System.Drawing.Size(35, 30);
            this.btnShowManage.TabIndex = 15;
            this.btnShowManage.Text = "";
            this.btnShowManage.UseVisualStyleBackColor = false;
            this.btnShowManage.Click += new System.EventHandler(this.btnShowManage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(157, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "零表示默认端口号";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(67, 13);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(123, 21);
            this.txtIp.TabIndex = 23;
            this.txtIp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIp_KeyDown);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(67, 106);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '●';
            this.txtPwd.Size = new System.Drawing.Size(123, 21);
            this.txtPwd.TabIndex = 26;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(67, 75);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(123, 21);
            this.txtUser.TabIndex = 25;
            this.txtUser.Text = "Administrator";
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(17, 105);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(37, 19);
            this.metroLabel4.TabIndex = 20;
            this.metroLabel4.Text = "密码";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(17, 75);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(37, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "用户";
            // 
            // numPort
            // 
            this.numPort.InterceptArrowKeys = false;
            this.numPort.Location = new System.Drawing.Point(67, 44);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(70, 21);
            this.numPort.TabIndex = 24;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numPort_KeyDown);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(17, 43);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(37, 19);
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "端口";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(17, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(37, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "地址";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(157, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Image = null;
            this.btnSave.Location = new System.Drawing.Point(76, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelManage
            // 
            this.panelManage.Controls.Add(this.grid);
            this.panelManage.Controls.Add(this.btnRefresh);
            this.panelManage.Controls.Add(this.btnClose);
            this.panelManage.Controls.Add(this.btnShowAdd);
            this.panelManage.HorizontalScrollbarBarColor = true;
            this.panelManage.HorizontalScrollbarHighlightOnWheel = false;
            this.panelManage.HorizontalScrollbarSize = 10;
            this.panelManage.Location = new System.Drawing.Point(23, 57);
            this.panelManage.Name = "panelManage";
            this.panelManage.Size = new System.Drawing.Size(285, 180);
            this.panelManage.TabIndex = 27;
            this.panelManage.VerticalScrollbarBarColor = true;
            this.panelManage.VerticalScrollbarHighlightOnWheel = false;
            this.panelManage.VerticalScrollbarSize = 10;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.ContextMenuStrip = this.menuGrid;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid.EnableHeadersVisualStyles = false;
            this.grid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grid.Location = new System.Drawing.Point(4, 4);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.Height = 23;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(276, 137);
            this.grid.TabIndex = 17;
            // 
            // menuGrid
            // 
            this.menuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.menuGrid.Name = "menu";
            this.menuGrid.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuGrid.Size = new System.Drawing.Size(101, 48);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.确认无误删除ToolStripMenuItem});
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // 确认无误删除ToolStripMenuItem
            // 
            this.确认无误删除ToolStripMenuItem.Name = "确认无误删除ToolStripMenuItem";
            this.确认无误删除ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.确认无误删除ToolStripMenuItem.Text = "确认无误，删除！";
            this.确认无误删除ToolStripMenuItem.Click += new System.EventHandler(this.确认无误删除ToolStripMenuItem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = null;
            this.btnRefresh.Location = new System.Drawing.Point(106, 147);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = null;
            this.btnClose.Location = new System.Drawing.Point(187, 147);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnShowAdd
            // 
            this.btnShowAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAdd.Image = global::远程桌面管理器.Properties.Resources.右;
            this.btnShowAdd.Location = new System.Drawing.Point(4, 146);
            this.btnShowAdd.Name = "btnShowAdd";
            this.btnShowAdd.Size = new System.Drawing.Size(35, 30);
            this.btnShowAdd.TabIndex = 15;
            this.btnShowAdd.Text = "";
            this.btnShowAdd.UseVisualStyleBackColor = false;
            this.btnShowAdd.Click += new System.EventHandler(this.btnShowAdd_Click);
            // 
            // IpAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 270);
            this.ControlBox = false;
            this.Controls.Add(this.panelAdd);
            this.Controls.Add(this.panelManage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IpAddressForm";
            this.Text = "连接地址配置";
            this.Load += new System.EventHandler(this.IpAddressForm_Load);
            this.panelAdd.ResumeLayout(false);
            this.panelAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.panelManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisder.W3Common.WMetroControl.Controls.MetroPanel panelAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUser;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel4;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.NumericUpDown numPort;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel2;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel1;
        private Wisder.W3Common.WControl.WButton btnCancel;
        private Wisder.W3Common.WControl.WButton btnSave;
        private Wisder.W3Common.WControl.WButton btnShowManage;
        private Wisder.W3Common.WMetroControl.Controls.MetroPanel panelManage;
        private Wisder.W3Common.WControl.WButton btnShowAdd;
        private Wisder.W3Common.WControl.WButton btnClose;
        private Wisder.W3Common.WMetroControl.Controls.MetroGrid grid;
        private System.Windows.Forms.ContextMenuStrip menuGrid;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 确认无误删除ToolStripMenuItem;
        private Wisder.W3Common.WControl.WButton btnRefresh;

    }
}