namespace psms
{
    partial class TuiKuTableReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuiKuTableReportForm));
            this.btnPrint = new System.Windows.Forms.Button();
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
            this.comboBoxPreInfo = new System.Windows.Forms.ComboBox();
            this.radioButtonThisPreInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPreInfo = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxPreType = new System.Windows.Forms.ComboBox();
            this.radioButtonSelectPreType = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPreType = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxQueryThisIn_scrpno = new System.Windows.Forms.CheckedListBox();
            this.checkBoxQueryAllInTable = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(602, 62);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打  印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(409, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报表日期范围";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "月";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "年";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(257, 50);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker2.TabIndex = 6;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Enabled = false;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(257, 20);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(121, 20);
            this.comboBoxMonth.TabIndex = 4;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(117, 20);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(121, 20);
            this.comboBoxYear.TabIndex = 3;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            // 
            // radioButtonDate
            // 
            this.radioButtonDate.AutoSize = true;
            this.radioButtonDate.Location = new System.Drawing.Point(16, 55);
            this.radioButtonDate.Name = "radioButtonDate";
            this.radioButtonDate.Size = new System.Drawing.Size(95, 16);
            this.radioButtonDate.TabIndex = 2;
            this.radioButtonDate.Text = "指定日期报表";
            this.radioButtonDate.UseVisualStyleBackColor = true;
            this.radioButtonDate.CheckedChanged += new System.EventHandler(this.radioButtonDate_CheckedChanged_1);
            // 
            // radioButtonMonth
            // 
            this.radioButtonMonth.AutoSize = true;
            this.radioButtonMonth.Location = new System.Drawing.Point(16, 35);
            this.radioButtonMonth.Name = "radioButtonMonth";
            this.radioButtonMonth.Size = new System.Drawing.Size(95, 16);
            this.radioButtonMonth.TabIndex = 1;
            this.radioButtonMonth.Text = "指定月份报表";
            this.radioButtonMonth.UseVisualStyleBackColor = true;
            this.radioButtonMonth.CheckedChanged += new System.EventHandler(this.radioButtonMonth_CheckedChanged_1);
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Checked = true;
            this.radioButtonYear.Location = new System.Drawing.Point(16, 13);
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
            this.groupBox2.Controls.Add(this.comboBoxPreInfo);
            this.groupBox2.Controls.Add(this.radioButtonThisPreInfo);
            this.groupBox2.Controls.Add(this.radioButtonAllPreInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 74);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表宣传品范围";
            // 
            // comboBoxPreInfo
            // 
            this.comboBoxPreInfo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPreInfo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPreInfo.Enabled = false;
            this.comboBoxPreInfo.FormattingEnabled = true;
            this.comboBoxPreInfo.Location = new System.Drawing.Point(6, 42);
            this.comboBoxPreInfo.Name = "comboBoxPreInfo";
            this.comboBoxPreInfo.Size = new System.Drawing.Size(222, 20);
            this.comboBoxPreInfo.TabIndex = 5;
            // 
            // radioButtonThisPreInfo
            // 
            this.radioButtonThisPreInfo.AutoSize = true;
            this.radioButtonThisPreInfo.Location = new System.Drawing.Point(93, 20);
            this.radioButtonThisPreInfo.Name = "radioButtonThisPreInfo";
            this.radioButtonThisPreInfo.Size = new System.Drawing.Size(71, 16);
            this.radioButtonThisPreInfo.TabIndex = 2;
            this.radioButtonThisPreInfo.Text = "选中宣传品";
            this.radioButtonThisPreInfo.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllPreInfo
            // 
            this.radioButtonAllPreInfo.AutoSize = true;
            this.radioButtonAllPreInfo.Checked = true;
            this.radioButtonAllPreInfo.Location = new System.Drawing.Point(16, 20);
            this.radioButtonAllPreInfo.Name = "radioButtonAllPreInfo";
            this.radioButtonAllPreInfo.Size = new System.Drawing.Size(71, 16);
            this.radioButtonAllPreInfo.TabIndex = 1;
            this.radioButtonAllPreInfo.TabStop = true;
            this.radioButtonAllPreInfo.Text = "全部宣传品";
            this.radioButtonAllPreInfo.UseVisualStyleBackColor = true;
            this.radioButtonAllPreInfo.CheckedChanged += new System.EventHandler(this.radioButtonAllPreInfo_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(602, 97);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退  出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(602, 29);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxPreType);
            this.groupBox4.Controls.Add(this.radioButtonSelectPreType);
            this.groupBox4.Controls.Add(this.radioButtonAllPreType);
            this.groupBox4.Location = new System.Drawing.Point(252, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 74);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "宣传品系列";
            // 
            // comboBoxPreType
            // 
            this.comboBoxPreType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPreType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPreType.Enabled = false;
            this.comboBoxPreType.FormattingEnabled = true;
            this.comboBoxPreType.Items.AddRange(new object[] {
            "计划内",
            "计划外"});
            this.comboBoxPreType.Location = new System.Drawing.Point(16, 42);
            this.comboBoxPreType.Name = "comboBoxPreType";
            this.comboBoxPreType.Size = new System.Drawing.Size(148, 20);
            this.comboBoxPreType.TabIndex = 5;
            // 
            // radioButtonSelectPreType
            // 
            this.radioButtonSelectPreType.AutoSize = true;
            this.radioButtonSelectPreType.Location = new System.Drawing.Point(93, 20);
            this.radioButtonSelectPreType.Name = "radioButtonSelectPreType";
            this.radioButtonSelectPreType.Size = new System.Drawing.Size(71, 16);
            this.radioButtonSelectPreType.TabIndex = 2;
            this.radioButtonSelectPreType.Text = "选中系列";
            this.radioButtonSelectPreType.UseVisualStyleBackColor = true;
            // 
            // radioButtonAllPreType
            // 
            this.radioButtonAllPreType.AutoSize = true;
            this.radioButtonAllPreType.Checked = true;
            this.radioButtonAllPreType.Location = new System.Drawing.Point(16, 20);
            this.radioButtonAllPreType.Name = "radioButtonAllPreType";
            this.radioButtonAllPreType.Size = new System.Drawing.Size(71, 16);
            this.radioButtonAllPreType.TabIndex = 1;
            this.radioButtonAllPreType.TabStop = true;
            this.radioButtonAllPreType.Text = "全部系列";
            this.radioButtonAllPreType.UseVisualStyleBackColor = true;
            this.radioButtonAllPreType.CheckedChanged += new System.EventHandler(this.radioButtonAllPreType_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(12, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(665, 355);
            this.dataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "undate";
            this.Column1.HeaderText = "退库日期";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "inscrpno";
            this.Column2.HeaderText = "凭证编号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "p_no";
            this.Column3.HeaderText = "宣传品编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "p_name";
            this.Column4.HeaderText = "宣传品名称";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 230;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "unit";
            this.Column5.HeaderText = "单位";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "unit_price";
            this.Column6.HeaderText = "单价";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "uninnum";
            this.Column7.HeaderText = "退库数量";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "allprice";
            this.Column8.HeaderText = "退库金额";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 90;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "IN_OU";
            this.Column9.HeaderText = "进货渠道";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // comboBoxQueryThisIn_scrpno
            // 
            this.comboBoxQueryThisIn_scrpno.CheckOnClick = true;
            this.comboBoxQueryThisIn_scrpno.Enabled = false;
            this.comboBoxQueryThisIn_scrpno.FormattingEnabled = true;
            this.comboBoxQueryThisIn_scrpno.Location = new System.Drawing.Point(427, 29);
            this.comboBoxQueryThisIn_scrpno.Name = "comboBoxQueryThisIn_scrpno";
            this.comboBoxQueryThisIn_scrpno.Size = new System.Drawing.Size(169, 132);
            this.comboBoxQueryThisIn_scrpno.TabIndex = 13;
            // 
            // checkBoxQueryAllInTable
            // 
            this.checkBoxQueryAllInTable.AutoSize = true;
            this.checkBoxQueryAllInTable.Checked = true;
            this.checkBoxQueryAllInTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxQueryAllInTable.Location = new System.Drawing.Point(427, 7);
            this.checkBoxQueryAllInTable.Name = "checkBoxQueryAllInTable";
            this.checkBoxQueryAllInTable.Size = new System.Drawing.Size(120, 16);
            this.checkBoxQueryAllInTable.TabIndex = 12;
            this.checkBoxQueryAllInTable.Text = "查询全部入库凭证";
            this.checkBoxQueryAllInTable.UseVisualStyleBackColor = true;
            this.checkBoxQueryAllInTable.CheckedChanged += new System.EventHandler(this.checkBoxQueryAllInTable_CheckedChanged);
            // 
            // TuiKuTableReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 532);
            this.Controls.Add(this.comboBoxQueryThisIn_scrpno);
            this.Controls.Add(this.checkBoxQueryAllInTable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TuiKuTableReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传品退库报表";
            this.Load += new System.EventHandler(this.InTableReportForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InTableReportForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
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
        private System.Windows.Forms.ComboBox comboBoxPreInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxPreType;
        private System.Windows.Forms.RadioButton radioButtonSelectPreType;
        private System.Windows.Forms.RadioButton radioButtonAllPreType;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox comboBoxQueryThisIn_scrpno;
        private System.Windows.Forms.CheckBox checkBoxQueryAllInTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}