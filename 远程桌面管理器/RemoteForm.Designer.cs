namespace 远程桌面管理器
{
    partial class RemoteForm
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
            this.chIsParent = new Wisder.W3Common.WMetroControl.Controls.MetroToggle();
            this.metroLabel1 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.numSort = new System.Windows.Forms.NumericUpDown();
            this.metroLabel2 = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            this.btnCancel = new Wisder.W3Common.WControl.WButton();
            this.btnSave = new Wisder.W3Common.WControl.WButton();
            this.cbParent = new Wisder.W3Common.WMetroControl.Controls.MetroComboBox();
            this.cbIpAddress = new Wisder.W3Common.WMetroControl.Controls.MetroComboBox();
            this.lbStatus = new Wisder.W3Common.WMetroControl.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numSort)).BeginInit();
            this.SuspendLayout();
            // 
            // chIsParent
            // 
            this.chIsParent.DisplayStatus = false;
            this.chIsParent.Location = new System.Drawing.Point(112, 80);
            this.chIsParent.Name = "chIsParent";
            this.chIsParent.Size = new System.Drawing.Size(76, 24);
            this.chIsParent.TabIndex = 0;
            this.chIsParent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chIsParent.UseSelectable = true;
            this.chIsParent.UseVisualStyleBackColor = true;
            this.chIsParent.CheckedChanged += new System.EventHandler(this.cbIsParent_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "是否为父级";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 126);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(122, 21);
            this.txtName.TabIndex = 11;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 126);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(37, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "名称";
            // 
            // numSort
            // 
            this.numSort.InterceptArrowKeys = false;
            this.numSort.Location = new System.Drawing.Point(66, 167);
            this.numSort.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSort.Name = "numSort";
            this.numSort.Size = new System.Drawing.Size(122, 21);
            this.numSort.TabIndex = 13;
            this.numSort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(28, 167);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(37, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "排序";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(302, 167);
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
            this.btnSave.Location = new System.Drawing.Point(221, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbParent
            // 
            this.cbParent.FormattingEnabled = true;
            this.cbParent.ItemHeight = 23;
            this.cbParent.Location = new System.Drawing.Point(221, 81);
            this.cbParent.Name = "cbParent";
            this.cbParent.Size = new System.Drawing.Size(156, 29);
            this.cbParent.TabIndex = 16;
            this.cbParent.UseSelectable = true;
            // 
            // cbIpAddress
            // 
            this.cbIpAddress.FormattingEnabled = true;
            this.cbIpAddress.ItemHeight = 23;
            this.cbIpAddress.Location = new System.Drawing.Point(221, 123);
            this.cbIpAddress.Name = "cbIpAddress";
            this.cbIpAddress.Size = new System.Drawing.Size(156, 29);
            this.cbIpAddress.TabIndex = 17;
            this.cbIpAddress.UseSelectable = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(219, 28);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(45, 19);
            this.lbStatus.TabIndex = 18;
            this.lbStatus.Text = "[新增]";
            // 
            // RemoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 206);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.cbIpAddress);
            this.Controls.Add(this.cbParent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numSort);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chIsParent);
            this.Name = "RemoteForm";
            this.Text = "远程主机配置";
            this.Load += new System.EventHandler(this.RemoteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisder.W3Common.WMetroControl.Controls.MetroToggle chIsParent;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txtName;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.NumericUpDown numSort;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel metroLabel2;
        private Wisder.W3Common.WControl.WButton btnCancel;
        private Wisder.W3Common.WControl.WButton btnSave;
        private Wisder.W3Common.WMetroControl.Controls.MetroComboBox cbParent;
        private Wisder.W3Common.WMetroControl.Controls.MetroComboBox cbIpAddress;
        private Wisder.W3Common.WMetroControl.Controls.MetroLabel lbStatus;
    }
}