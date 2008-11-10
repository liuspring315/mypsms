namespace psms
{
    partial class AddPreInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPreInfoForm));
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.cobPreType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAcc_qnt = new System.Windows.Forms.TextBox();
            this.txtCost_price = new System.Windows.Forms.TextBox();
            this.txtUnit_price = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtP_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtP_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SetPreInfoerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SetPreInfoerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // comboUnit
            // 
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Items.AddRange(new object[] {
            "册",
            "套",
            "张",
            "本",
            "个"});
            this.comboUnit.Location = new System.Drawing.Point(87, 180);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(101, 20);
            this.comboUnit.TabIndex = 40;
            this.comboUnit.Text = "套";
            // 
            // cobPreType
            // 
            this.cobPreType.FormattingEnabled = true;
            this.cobPreType.Location = new System.Drawing.Point(85, 143);
            this.cobPreType.Name = "cobPreType";
            this.cobPreType.Size = new System.Drawing.Size(103, 20);
            this.cobPreType.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "宣传品系列";
            // 
            // txtAcc_qnt
            // 
            this.txtAcc_qnt.Enabled = false;
            this.txtAcc_qnt.Location = new System.Drawing.Point(88, 289);
            this.txtAcc_qnt.Name = "txtAcc_qnt";
            this.txtAcc_qnt.Size = new System.Drawing.Size(100, 21);
            this.txtAcc_qnt.TabIndex = 37;
            this.txtAcc_qnt.Text = "0";
            // 
            // txtCost_price
            // 
            this.txtCost_price.Location = new System.Drawing.Point(87, 254);
            this.txtCost_price.Name = "txtCost_price";
            this.txtCost_price.Size = new System.Drawing.Size(100, 21);
            this.txtCost_price.TabIndex = 36;
            // 
            // txtUnit_price
            // 
            this.txtUnit_price.Location = new System.Drawing.Point(87, 216);
            this.txtUnit_price.Name = "txtUnit_price";
            this.txtUnit_price.Size = new System.Drawing.Size(100, 21);
            this.txtUnit_price.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "库存数量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "成 本 价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "销 售 价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "单    位";
            // 
            // txtP_name
            // 
            this.txtP_name.Location = new System.Drawing.Point(27, 105);
            this.txtP_name.Name = "txtP_name";
            this.txtP_name.Size = new System.Drawing.Size(207, 21);
            this.txtP_name.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "宣传品名称";
            // 
            // txtP_no
            // 
            this.txtP_no.Location = new System.Drawing.Point(25, 41);
            this.txtP_no.Name = "txtP_no";
            this.txtP_no.Size = new System.Drawing.Size(209, 21);
            this.txtP_no.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "宣传品编号";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SetPreInfoerrorProvider
            // 
            this.SetPreInfoerrorProvider.ContainerControl = this;
            // 
            // AddPreInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 347);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboUnit);
            this.Controls.Add(this.cobPreType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAcc_qnt);
            this.Controls.Add(this.txtCost_price);
            this.Controls.Add(this.txtUnit_price);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtP_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtP_no);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddPreInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增宣传品信息";
            this.Load += new System.EventHandler(this.AddPreInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SetPreInfoerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.ComboBox cobPreType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAcc_qnt;
        private System.Windows.Forms.TextBox txtCost_price;
        private System.Windows.Forms.TextBox txtUnit_price;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtP_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtP_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider SetPreInfoerrorProvider;
    }
}