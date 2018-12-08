namespace RdpTest
{
    partial class GlobalSettingForm
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
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chShareClipboard = new MetroFramework.Controls.MetroToggle();
            this.gbDisks = new System.Windows.Forms.GroupBox();
            this.flpDisks = new System.Windows.Forms.FlowLayoutPanel();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chShareAllDisk = new MetroFramework.Controls.MetroToggle();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.gbDisks.SuspendLayout();
            this.flpDisks.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(207, 80);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(37, 19);
            this.metroLabel7.TabIndex = 39;
            this.metroLabel7.Text = "密码";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(19, 80);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(37, 19);
            this.metroLabel6.TabIndex = 38;
            this.metroLabel6.Text = "用户";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(246, 80);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '●';
            this.txtPwd.Size = new System.Drawing.Size(122, 21);
            this.txtPwd.TabIndex = 37;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(57, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(121, 21);
            this.txtUser.TabIndex = 36;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(209, 132);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 41;
            this.metroLabel1.Text = "共享剪切板";
            // 
            // chShareClipboard
            // 
            this.chShareClipboard.DisplayStatus = false;
            this.chShareClipboard.Location = new System.Drawing.Point(293, 131);
            this.chShareClipboard.Name = "chShareClipboard";
            this.chShareClipboard.Size = new System.Drawing.Size(75, 24);
            this.chShareClipboard.TabIndex = 40;
            this.chShareClipboard.Text = "~StatusOff";
            this.chShareClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chShareClipboard.UseSelectable = true;
            this.chShareClipboard.UseVisualStyleBackColor = true;
            // 
            // gbDisks
            // 
            this.gbDisks.Controls.Add(this.flpDisks);
            this.gbDisks.Location = new System.Drawing.Point(21, 180);
            this.gbDisks.Name = "gbDisks";
            this.gbDisks.Size = new System.Drawing.Size(347, 90);
            this.gbDisks.TabIndex = 42;
            this.gbDisks.TabStop = false;
            this.gbDisks.Text = "单独设置共享磁盘";
            // 
            // flpDisks
            // 
            this.flpDisks.Controls.Add(this.metroCheckBox1);
            this.flpDisks.Location = new System.Drawing.Point(6, 20);
            this.flpDisks.Name = "flpDisks";
            this.flpDisks.Size = new System.Drawing.Size(332, 64);
            this.flpDisks.TabIndex = 0;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(3, 3);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(31, 15);
            this.metroCheckBox1.TabIndex = 0;
            this.metroCheckBox1.Text = "C";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(19, 132);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.TabIndex = 44;
            this.metroLabel2.Text = "共享所有磁盘";
            // 
            // chShareAllDisk
            // 
            this.chShareAllDisk.DisplayStatus = false;
            this.chShareAllDisk.Location = new System.Drawing.Point(118, 131);
            this.chShareAllDisk.Name = "chShareAllDisk";
            this.chShareAllDisk.Size = new System.Drawing.Size(60, 24);
            this.chShareAllDisk.TabIndex = 43;
            this.chShareAllDisk.Text = "~StatusOff";
            this.chShareAllDisk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chShareAllDisk.UseSelectable = true;
            this.chShareAllDisk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(209, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 31);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(76, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 31);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "保存";
            this.btnSave.UseSelectable = true;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GlobalSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 357);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.chShareAllDisk);
            this.Controls.Add(this.gbDisks);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chShareClipboard);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Name = "GlobalSettingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "全局设置";
            this.Load += new System.EventHandler(this.GlobalSettingForm_Load);
            this.gbDisks.ResumeLayout(false);
            this.flpDisks.ResumeLayout(false);
            this.flpDisks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUser;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle chShareClipboard;
        private System.Windows.Forms.GroupBox gbDisks;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle chShareAllDisk;
        private System.Windows.Forms.FlowLayoutPanel flpDisks;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}