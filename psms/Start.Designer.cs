namespace psms
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.tabLogin = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.tabPageUpPass = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.labelNewPass2 = new System.Windows.Forms.Label();
            this.labelNewPass = new System.Windows.Forms.Label();
            this.labelOldPass = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxNewPass2 = new System.Windows.Forms.TextBox();
            this.textBoxNewPass1 = new System.Windows.Forms.TextBox();
            this.textBoxPassOld = new System.Windows.Forms.TextBox();
            this.comboBoxUserName2 = new System.Windows.Forms.ComboBox();
            this.tabLogin.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageUpPass.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.tabPageLogin);
            this.tabLogin.Controls.Add(this.tabPageUpPass);
            this.tabLogin.Location = new System.Drawing.Point(-2, 0);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.SelectedIndex = 0;
            this.tabLogin.Size = new System.Drawing.Size(338, 273);
            this.tabLogin.TabIndex = 4;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.btnClose);
            this.tabPageLogin.Controls.Add(this.btnLogin);
            this.tabPageLogin.Controls.Add(this.groupBox1);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 21);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(330, 248);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "登录系统";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(177, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(62, 203);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登  录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.comboBoxUserName);
            this.groupBox1.Location = new System.Drawing.Point(34, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 145);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入用户名和密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 21);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Location = new System.Drawing.Point(94, 41);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUserName.TabIndex = 1;
            // 
            // tabPageUpPass
            // 
            this.tabPageUpPass.Controls.Add(this.groupBox2);
            this.tabPageUpPass.Location = new System.Drawing.Point(4, 21);
            this.tabPageUpPass.Name = "tabPageUpPass";
            this.tabPageUpPass.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpPass.Size = new System.Drawing.Size(330, 248);
            this.tabPageUpPass.TabIndex = 1;
            this.tabPageUpPass.Text = "修改密码";
            this.tabPageUpPass.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Controls.Add(this.labelNewPass2);
            this.groupBox2.Controls.Add(this.labelNewPass);
            this.groupBox2.Controls.Add(this.labelOldPass);
            this.groupBox2.Controls.Add(this.labelUserName);
            this.groupBox2.Controls.Add(this.textBoxNewPass2);
            this.groupBox2.Controls.Add(this.textBoxNewPass1);
            this.groupBox2.Controls.Add(this.textBoxPassOld);
            this.groupBox2.Controls.Add(this.comboBoxUserName2);
            this.groupBox2.Location = new System.Drawing.Point(19, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 209);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请先输入用户名和旧口令";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(152, 171);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "重  置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(47, 171);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "确  定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // labelNewPass2
            // 
            this.labelNewPass2.AutoSize = true;
            this.labelNewPass2.Location = new System.Drawing.Point(29, 143);
            this.labelNewPass2.Name = "labelNewPass2";
            this.labelNewPass2.Size = new System.Drawing.Size(77, 12);
            this.labelNewPass2.TabIndex = 11;
            this.labelNewPass2.Text = "确认新密码：";
            // 
            // labelNewPass
            // 
            this.labelNewPass.AutoSize = true;
            this.labelNewPass.Location = new System.Drawing.Point(29, 104);
            this.labelNewPass.Name = "labelNewPass";
            this.labelNewPass.Size = new System.Drawing.Size(53, 12);
            this.labelNewPass.TabIndex = 10;
            this.labelNewPass.Text = "新密码：";
            // 
            // labelOldPass
            // 
            this.labelOldPass.AutoSize = true;
            this.labelOldPass.Location = new System.Drawing.Point(29, 67);
            this.labelOldPass.Name = "labelOldPass";
            this.labelOldPass.Size = new System.Drawing.Size(53, 12);
            this.labelOldPass.TabIndex = 9;
            this.labelOldPass.Text = "旧密码：";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(29, 28);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(53, 12);
            this.labelUserName.TabIndex = 8;
            this.labelUserName.Text = "用户名：";
            // 
            // textBoxNewPass2
            // 
            this.textBoxNewPass2.Location = new System.Drawing.Point(106, 134);
            this.textBoxNewPass2.Name = "textBoxNewPass2";
            this.textBoxNewPass2.Size = new System.Drawing.Size(121, 21);
            this.textBoxNewPass2.TabIndex = 7;
            this.textBoxNewPass2.UseSystemPasswordChar = true;
            // 
            // textBoxNewPass1
            // 
            this.textBoxNewPass1.Location = new System.Drawing.Point(106, 95);
            this.textBoxNewPass1.Name = "textBoxNewPass1";
            this.textBoxNewPass1.Size = new System.Drawing.Size(121, 21);
            this.textBoxNewPass1.TabIndex = 6;
            this.textBoxNewPass1.UseSystemPasswordChar = true;
            // 
            // textBoxPassOld
            // 
            this.textBoxPassOld.Location = new System.Drawing.Point(106, 58);
            this.textBoxPassOld.Name = "textBoxPassOld";
            this.textBoxPassOld.Size = new System.Drawing.Size(121, 21);
            this.textBoxPassOld.TabIndex = 5;
            this.textBoxPassOld.UseSystemPasswordChar = true;
            // 
            // comboBoxUserName2
            // 
            this.comboBoxUserName2.FormattingEnabled = true;
            this.comboBoxUserName2.Location = new System.Drawing.Point(106, 20);
            this.comboBoxUserName2.Name = "comboBoxUserName2";
            this.comboBoxUserName2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxUserName2.TabIndex = 4;
            // 
            // StartForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(332, 270);
            this.Controls.Add(this.tabLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传品管理系统--登录";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.tabLogin.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageUpPass.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLogin;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageUpPass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label labelNewPass2;
        private System.Windows.Forms.Label labelNewPass;
        private System.Windows.Forms.Label labelOldPass;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxNewPass2;
        private System.Windows.Forms.TextBox textBoxNewPass1;
        private System.Windows.Forms.TextBox textBoxPassOld;
        private System.Windows.Forms.ComboBox comboBoxUserName2;
    }
}