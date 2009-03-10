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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.radioButtonDate = new System.Windows.Forms.RadioButton();
            this.radioButtonMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonThisPreInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPreInfo = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewInOutReport = new System.Windows.Forms.DataGridView();
            this.p_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxStatInOutTablePreType = new System.Windows.Forms.ComboBox();
            this.checkBoxStatInOutTablePreTypeed = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxSateInOutTableP_no = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSateInOutTableAllPreInfo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.comboBoxMonth);
            this.groupBox1.Controls.Add(this.comboBoxYear);
            this.groupBox1.Controls.Add(this.radioButtonDate);
            this.groupBox1.Controls.Add(this.radioButtonMonth);
            this.groupBox1.Controls.Add(this.radioButtonYear);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报表日期范围";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "月";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "年";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(286, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Enabled = false;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(286, 23);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMonth.TabIndex = 4;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(117, 23);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(121, 20);
            this.comboBoxYear.TabIndex = 3;
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Location = new System.Drawing.Point(16, 61);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(95, 16);
            this.radioButtonDate.TabIndex = 2;
            this.radioButtonDate.Text = "指定日期报表";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            this.radioButtonDate.CheckedChanged += new System.EventHandler(this.radioButtonDate_CheckedChanged);
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Location = new System.Drawing.Point(16, 38);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(95, 16);
            this.radioButtonMonth.TabIndex = 1;
            this.radioButtonMonth.Text = "指定月份报表";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.radioButtonMonth_CheckedChanged);
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Checked = true;
            this.radioButtonYear.Location = new System.Drawing.Point(16, 16);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(95, 16);
            this.radioButtonYear.TabIndex = 0;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "指定年份报表";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            this.radioButtonYear.CheckedChanged += new System.EventHandler(this.radioButtonYear_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSateInOutTableP_no);
            this.groupBox2.Controls.Add(this.checkBoxSateInOutTableAllPreInfo);
            this.groupBox2.Controls.Add(this.comboBoxStatInOutTablePreType);
            this.groupBox2.Controls.Add(this.checkBoxStatInOutTablePreTypeed);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.radioButtonThisPreInfo);
            this.groupBox2.Controls.Add(this.radioButtonAllPreInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(707, 189);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表宣传品范围";
            // 
            // radioButtonThisPreInfo
            // 
            this.radioButtonThisPreInfo.AutoSize = true;
            this.radioButtonThisPreInfo.Checked = true;
            this.radioButtonThisPreInfo.Location = new System.Drawing.Point(117, 20);
            this.radioButtonThisPreInfo.Name = "radioButtonThisPreInfo";
            this.radioButtonThisPreInfo.Size = new System.Drawing.Size(107, 16);
            this.radioButtonThisPreInfo.TabIndex = 2;
            this.radioButtonThisPreInfo.TabStop = true;
            this.radioButtonThisPreInfo.Text = "有出入库宣传品";
            this.radioButtonThisPreInfo.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllPreInfo
            // 
            this.radioButtonAllPreInfo.AutoSize = true;
            this.radioButtonAllPreInfo.Location = new System.Drawing.Point(16, 20);
            this.radioButtonAllPreInfo.Name = "radioButtonAllPreInfo";
            this.radioButtonAllPreInfo.Size = new System.Drawing.Size(83, 16);
            this.radioButtonAllPreInfo.TabIndex = 1;
            this.radioButtonAllPreInfo.Text = "全部宣传品";
            this.radioButtonAllPreInfo.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(612, 64);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退  出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(612, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 34);
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
            this.e_qnt,
            this.e_price});
            this.dataGridViewInOutReport.Location = new System.Drawing.Point(12, 301);
            this.dataGridViewInOutReport.Name = "dataGridViewInOutReport";
            this.dataGridViewInOutReport.ReadOnly = true;
            this.dataGridViewInOutReport.RowHeadersWidth = 10;
            this.dataGridViewInOutReport.RowTemplate.Height = 23;
            this.dataGridViewInOutReport.Size = new System.Drawing.Size(707, 219);
            this.dataGridViewInOutReport.TabIndex = 7;
            // 
            // p_no
            // 
            this.p_no.DataPropertyName = "p_no";
            this.p_no.HeaderText = "宣传品编号";
            this.p_no.Name = "p_no";
            this.p_no.ReadOnly = true;
            this.p_no.Width = 120;
            // 
            // p_name
            // 
            this.p_name.DataPropertyName = "p_name";
            this.p_name.HeaderText = "宣传品名称";
            this.p_name.Name = "p_name";
            this.p_name.ReadOnly = true;
            this.p_name.Width = 220;
            // 
            // unit_price
            // 
            this.unit_price.DataPropertyName = "unit_price";
            this.unit_price.HeaderText = "销售价";
            this.unit_price.Name = "unit_price";
            this.unit_price.ReadOnly = true;
            this.unit_price.Width = 80;
            // 
            // cost_price
            // 
            this.cost_price.DataPropertyName = "cost_price";
            this.cost_price.HeaderText = "成本价";
            this.cost_price.Name = "cost_price";
            this.cost_price.ReadOnly = true;
            this.cost_price.Width = 80;
            // 
            // e_qnt
            // 
            this.e_qnt.DataPropertyName = "e_qnt";
            this.e_qnt.HeaderText = "库存量";
            this.e_qnt.Name = "e_qnt";
            this.e_qnt.ReadOnly = true;
            this.e_qnt.Width = 80;
            // 
            // e_price
            // 
            this.e_price.DataPropertyName = "e_price";
            this.e_price.HeaderText = "库存金额";
            this.e_price.Name = "e_price";
            this.e_price.ReadOnly = true;
            this.e_price.Width = 80;
            // 
            // comboBoxStatInOutTablePreType
            // 
            this.comboBoxStatInOutTablePreType.Enabled = false;
            this.comboBoxStatInOutTablePreType.FormattingEnabled = true;
            this.comboBoxStatInOutTablePreType.Location = new System.Drawing.Point(85, 60);
            this.comboBoxStatInOutTablePreType.Name = "comboBoxStatInOutTablePreType";
            this.comboBoxStatInOutTablePreType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStatInOutTablePreType.TabIndex = 12;
            this.comboBoxStatInOutTablePreType.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatInOutTablePreType_SelectedIndexChanged);
            // 
            // checkBoxStatInOutTablePreTypeed
            // 
            this.checkBoxStatInOutTablePreTypeed.AutoSize = true;
            this.checkBoxStatInOutTablePreTypeed.Checked = true;
            this.checkBoxStatInOutTablePreTypeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStatInOutTablePreTypeed.Location = new System.Drawing.Point(15, 42);
            this.checkBoxStatInOutTablePreTypeed.Name = "checkBoxStatInOutTablePreTypeed";
            this.checkBoxStatInOutTablePreTypeed.Size = new System.Drawing.Size(96, 16);
            this.checkBoxStatInOutTablePreTypeed.TabIndex = 11;
            this.checkBoxStatInOutTablePreTypeed.Text = "统计全部系列";
            this.checkBoxStatInOutTablePreTypeed.UseVisualStyleBackColor = true;
            this.checkBoxStatInOutTablePreTypeed.CheckedChanged += new System.EventHandler(this.checkBoxStatInOutTablePreTypeed_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "宣传品系列";
            // 
            // comboBoxSateInOutTableP_no
            // 
            this.comboBoxSateInOutTableP_no.CheckOnClick = true;
            this.comboBoxSateInOutTableP_no.FormattingEnabled = true;
            this.comboBoxSateInOutTableP_no.Location = new System.Drawing.Point(230, 31);
            this.comboBoxSateInOutTableP_no.Name = "comboBoxSateInOutTableP_no";
            this.comboBoxSateInOutTableP_no.Size = new System.Drawing.Size(471, 148);
            this.comboBoxSateInOutTableP_no.TabIndex = 14;
            // 
            // checkBoxSateInOutTableAllPreInfo
            // 
            this.checkBoxSateInOutTableAllPreInfo.AutoSize = true;
            this.checkBoxSateInOutTableAllPreInfo.Checked = true;
            this.checkBoxSateInOutTableAllPreInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSateInOutTableAllPreInfo.Location = new System.Drawing.Point(230, 16);
            this.checkBoxSateInOutTableAllPreInfo.Name = "checkBoxSateInOutTableAllPreInfo";
            this.checkBoxSateInOutTableAllPreInfo.Size = new System.Drawing.Size(108, 16);
            this.checkBoxSateInOutTableAllPreInfo.TabIndex = 13;
            this.checkBoxSateInOutTableAllPreInfo.Text = "统计全部宣传品";
            this.checkBoxSateInOutTableAllPreInfo.UseVisualStyleBackColor = true;
            this.checkBoxSateInOutTableAllPreInfo.CheckedChanged += new System.EventHandler(this.checkBoxSateInOutTableAllPreInfo_CheckedChanged);
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
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "StoreReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传品库存统计报表";
            this.Load += new System.EventHandler(this.StoreReportForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InOutReportForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDate;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.RadioButton radioButtonThisPreInfo;
        private System.Windows.Forms.RadioButton radioButtonAllPreInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewInOutReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_price;
        private System.Windows.Forms.ComboBox comboBoxStatInOutTablePreType;
        private System.Windows.Forms.CheckBox checkBoxStatInOutTablePreTypeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox comboBoxSateInOutTableP_no;
        private System.Windows.Forms.CheckBox checkBoxSateInOutTableAllPreInfo;
    }
}