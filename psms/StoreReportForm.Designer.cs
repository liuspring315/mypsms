namespace psms
{
    partial class StoreReportForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSateInOutTableP_no = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSateInOutTableAllPreInfo = new System.Windows.Forms.CheckBox();
            this.comboBoxStatInOutTablePreType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewInOutReport = new System.Windows.Forms.DataGridView();
            this.p_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxIncludeQnt0 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxIncludeQnt0);
            this.groupBox2.Controls.Add(this.comboBoxSateInOutTableP_no);
            this.groupBox2.Controls.Add(this.checkBoxSateInOutTableAllPreInfo);
            this.groupBox2.Controls.Add(this.comboBoxStatInOutTablePreType);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 214);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表宣传品范围";
            // 
            // comboBoxSateInOutTableP_no
            // 
            this.comboBoxSateInOutTableP_no.CheckOnClick = true;
            this.comboBoxSateInOutTableP_no.FormattingEnabled = true;
            this.comboBoxSateInOutTableP_no.Location = new System.Drawing.Point(77, 54);
            this.comboBoxSateInOutTableP_no.Name = "comboBoxSateInOutTableP_no";
            this.comboBoxSateInOutTableP_no.Size = new System.Drawing.Size(498, 148);
            this.comboBoxSateInOutTableP_no.TabIndex = 14;
            this.comboBoxSateInOutTableP_no.SelectedIndexChanged += new System.EventHandler(this.comboBoxSateInOutTableP_no_SelectedIndexChanged);
            this.comboBoxSateInOutTableP_no.Click += new System.EventHandler(this.comboBoxSateInOutTableP_no_Click);
            // 
            // checkBoxSateInOutTableAllPreInfo
            // 
            this.checkBoxSateInOutTableAllPreInfo.AutoSize = true;
            this.checkBoxSateInOutTableAllPreInfo.Checked = true;
            this.checkBoxSateInOutTableAllPreInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSateInOutTableAllPreInfo.Location = new System.Drawing.Point(221, 32);
            this.checkBoxSateInOutTableAllPreInfo.Name = "checkBoxSateInOutTableAllPreInfo";
            this.checkBoxSateInOutTableAllPreInfo.Size = new System.Drawing.Size(108, 16);
            this.checkBoxSateInOutTableAllPreInfo.TabIndex = 13;
            this.checkBoxSateInOutTableAllPreInfo.Text = "统计全部宣传品";
            this.checkBoxSateInOutTableAllPreInfo.UseVisualStyleBackColor = true;
            this.checkBoxSateInOutTableAllPreInfo.Click += new System.EventHandler(this.checkBoxSateInOutTableAllPreInfo_Click);
            // 
            // comboBoxStatInOutTablePreType
            // 
            this.comboBoxStatInOutTablePreType.FormattingEnabled = true;
            this.comboBoxStatInOutTablePreType.Location = new System.Drawing.Point(77, 28);
            this.comboBoxStatInOutTablePreType.Name = "comboBoxStatInOutTablePreType";
            this.comboBoxStatInOutTablePreType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStatInOutTablePreType.TabIndex = 12;
            this.comboBoxStatInOutTablePreType.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatInOutTablePreType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "宣传品系列";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(630, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退  出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(630, 21);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "打  印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewInOutReport
            // 
            this.dataGridViewInOutReport.AllowUserToAddRows = false;
            this.dataGridViewInOutReport.AllowUserToDeleteRows = false;
            this.dataGridViewInOutReport.AllowUserToOrderColumns = true;
            this.dataGridViewInOutReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInOutReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_no,
            this.p_name,
            this.unit_price,
            this.cost_price,
            this.acc_qnt,
            this.e_price});
            this.dataGridViewInOutReport.Location = new System.Drawing.Point(12, 232);
            this.dataGridViewInOutReport.Name = "dataGridViewInOutReport";
            this.dataGridViewInOutReport.ReadOnly = true;
            this.dataGridViewInOutReport.RowHeadersWidth = 10;
            this.dataGridViewInOutReport.RowTemplate.Height = 23;
            this.dataGridViewInOutReport.Size = new System.Drawing.Size(707, 288);
            this.dataGridViewInOutReport.TabIndex = 7;
            // 
            // p_no
            // 
            this.p_no.DataPropertyName = "p_no";
            this.p_no.HeaderText = "宣传品编号";
            this.p_no.Name = "p_no";
            this.p_no.ReadOnly = true;
            this.p_no.Width = 170;
            // 
            // p_name
            // 
            this.p_name.DataPropertyName = "p_name";
            this.p_name.HeaderText = "宣传品名称";
            this.p_name.Name = "p_name";
            this.p_name.ReadOnly = true;
            this.p_name.Width = 350;
            // 
            // unit_price
            // 
            this.unit_price.DataPropertyName = "unit_price";
            this.unit_price.HeaderText = "销售价";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            // 
            // cost_price
            // 
            this.cost_price.DataPropertyName = "cost_price";
            this.cost_price.HeaderText = "成本价";
            this.cost_price.Name = "cost_price";
            this.cost_price.ReadOnly = true;
            this.cost_price.Width = 110;
            // 
            // acc_qnt
            // 
            this.acc_qnt.DataPropertyName = "acc_qnt";
            this.acc_qnt.HeaderText = "库存量";
            this.acc_qnt.Name = "acc_qnt";
            this.acc_qnt.ReadOnly = true;
            // 
            // e_price
            // 
            this.e_price.DataPropertyName = "e_price";
            this.e_price.HeaderText = "库存金额";
            this.e_price.Name = "e_price";
            this.e_price.ReadOnly = true;
            this.e_price.Width = 110;
            // 
            // checkBoxIncludeQnt0
            // 
            this.checkBoxIncludeQnt0.AutoSize = true;
            this.checkBoxIncludeQnt0.Checked = true;
            this.checkBoxIncludeQnt0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncludeQnt0.Location = new System.Drawing.Point(350, 32);
            this.checkBoxIncludeQnt0.Name = "checkBoxIncludeQnt0";
            this.checkBoxIncludeQnt0.Size = new System.Drawing.Size(132, 16);
            this.checkBoxIncludeQnt0.TabIndex = 15;
            this.checkBoxIncludeQnt0.Text = "包含库存为零的邮品";
            this.checkBoxIncludeQnt0.UseVisualStyleBackColor = true;
            // 
            // StoreReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 532);
            this.Controls.Add(this.dataGridViewInOutReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "StoreReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传品库存统计报表";
            this.Load += new System.EventHandler(this.StoreReportForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InOutReportForm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewInOutReport;
        private System.Windows.Forms.ComboBox comboBoxStatInOutTablePreType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox comboBoxSateInOutTableP_no;
        private System.Windows.Forms.CheckBox checkBoxSateInOutTableAllPreInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_price;
        private System.Windows.Forms.CheckBox checkBoxIncludeQnt0;
    }
}