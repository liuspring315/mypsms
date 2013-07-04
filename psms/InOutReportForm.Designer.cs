namespace psms
{
    partial class InOutReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InOutReportForm));
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
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonThisPreInfo = new System.Windows.Forms.RadioButton();
            this.radioButtonAllPreInfo = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewInOutReport = new System.Windows.Forms.DataGridView();
            this.p_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.o_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlan = new System.Windows.Forms.ComboBox();
            this.radioButtonSelectPlan = new System.Windows.Forms.RadioButton();
            this.radioButtonPlanAll = new System.Windows.Forms.RadioButton();
            this.cobInTableIn_Ou = new System.Windows.Forms.ComboBox();
            this.checkBoxQnt = new System.Windows.Forms.CheckBox();
            this.checkBoxInOu = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(437, 89);
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
            this.groupBox2.Controls.Add(this.checkBoxQnt);
            this.groupBox2.Controls.Add(this.radioButtonThisPreInfo);
            this.groupBox2.Controls.Add(this.radioButtonAllPreInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 48);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表宣传品范围";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "正在导出Excel,请稍后...";
            this.label4.Visible = false;
            // 
            // radioButtonThisPreInfo
            // 
            this.radioButtonThisPreInfo.AutoSize = true;
            this.radioButtonThisPreInfo.Checked = true;
            this.radioButtonThisPreInfo.Location = new System.Drawing.Point(103, 20);
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
            this.btnClose.Location = new System.Drawing.Point(644, 121);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "退  出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(644, 14);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查  询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 48);
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
            this.s_qnt,
            this.i_amount,
            this.i_total,
            this.o_amount,
            this.o_total,
            this.e_qnt,
            this.e_price});
            this.dataGridViewInOutReport.Location = new System.Drawing.Point(12, 148);
            this.dataGridViewInOutReport.Name = "dataGridViewInOutReport";
            this.dataGridViewInOutReport.ReadOnly = true;
            this.dataGridViewInOutReport.RowHeadersWidth = 10;
            this.dataGridViewInOutReport.RowTemplate.Height = 23;
            this.dataGridViewInOutReport.Size = new System.Drawing.Size(707, 372);
            this.dataGridViewInOutReport.TabIndex = 7;
            // 
            // p_no
            // 
            this.p_no.DataPropertyName = "p_no";
            this.p_no.HeaderText = "宣传品编号";
            this.p_no.Name = "p_no";
            this.p_no.ReadOnly = true;
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
            // s_qnt
            // 
            this.s_qnt.DataPropertyName = "s_qnt";
            this.s_qnt.HeaderText = "前库存量";
            this.s_qnt.Name = "s_qnt";
            this.s_qnt.ReadOnly = true;
            this.s_qnt.Width = 80;
            // 
            // i_amount
            // 
            this.i_amount.DataPropertyName = "i_amount";
            this.i_amount.HeaderText = "入库数量";
            this.i_amount.Name = "i_amount";
            this.i_amount.ReadOnly = true;
            this.i_amount.Width = 80;
            // 
            // i_total
            // 
            this.i_total.DataPropertyName = "i_total";
            this.i_total.HeaderText = "入库金额";
            this.i_total.Name = "i_total";
            this.i_total.ReadOnly = true;
            this.i_total.Width = 80;
            // 
            // o_amount
            // 
            this.o_amount.DataPropertyName = "o_amount";
            this.o_amount.HeaderText = "出库数量";
            this.o_amount.Name = "o_amount";
            this.o_amount.ReadOnly = true;
            this.o_amount.Width = 80;
            // 
            // o_total
            // 
            this.o_total.DataPropertyName = "o_total";
            this.o_total.HeaderText = "出库金额";
            this.o_total.Name = "o_total";
            this.o_total.ReadOnly = true;
            this.o_total.Width = 80;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(644, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "导出Excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxPlan);
            this.groupBox3.Controls.Add(this.radioButtonSelectPlan);
            this.groupBox3.Controls.Add(this.radioButtonPlanAll);
            this.groupBox3.Location = new System.Drawing.Point(455, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 89);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "计划范围";
            // 
            // comboBoxPlan
            // 
            this.comboBoxPlan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPlan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPlan.Enabled = false;
            this.comboBoxPlan.FormattingEnabled = true;
            this.comboBoxPlan.Items.AddRange(new object[] {
            "计划内",
            "计划外"});
            this.comboBoxPlan.Location = new System.Drawing.Point(16, 55);
            this.comboBoxPlan.Name = "comboBoxPlan";
            this.comboBoxPlan.Size = new System.Drawing.Size(148, 20);
            this.comboBoxPlan.TabIndex = 5;
            this.comboBoxPlan.Text = "计划内";
            // 
            // radioButtonSelectPlan
            // 
            this.radioButtonSelectPlan.AutoSize = true;
            this.radioButtonSelectPlan.Location = new System.Drawing.Point(93, 20);
            this.radioButtonSelectPlan.Name = "radioButtonSelectPlan";
            this.radioButtonSelectPlan.Size = new System.Drawing.Size(71, 16);
            this.radioButtonSelectPlan.TabIndex = 2;
            this.radioButtonSelectPlan.Text = "选中计划";
            this.radioButtonSelectPlan.UseVisualStyleBackColor = true;
            this.radioButtonSelectPlan.CheckedChanged += new System.EventHandler(this.radioButtonSelectPlan_CheckedChanged);
            // 
            // radioButtonPlanAll
            // 
            this.radioButtonPlanAll.AutoSize = true;
            this.radioButtonPlanAll.Checked = true;
            this.radioButtonPlanAll.Location = new System.Drawing.Point(16, 20);
            this.radioButtonPlanAll.Name = "radioButtonPlanAll";
            this.radioButtonPlanAll.Size = new System.Drawing.Size(71, 16);
            this.radioButtonPlanAll.TabIndex = 1;
            this.radioButtonPlanAll.TabStop = true;
            this.radioButtonPlanAll.Text = "全部计划";
            this.radioButtonPlanAll.UseVisualStyleBackColor = true;
            this.radioButtonPlanAll.CheckedChanged += new System.EventHandler(this.radioButtonPlanAll_CheckedChanged);
            // 
            // cobInTableIn_Ou
            // 
            this.cobInTableIn_Ou.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cobInTableIn_Ou.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cobInTableIn_Ou.FormattingEnabled = true;
            this.cobInTableIn_Ou.Location = new System.Drawing.Point(503, 109);
            this.cobInTableIn_Ou.Name = "cobInTableIn_Ou";
            this.cobInTableIn_Ou.Size = new System.Drawing.Size(121, 20);
            this.cobInTableIn_Ou.TabIndex = 11;
            // 
            // checkBoxQnt
            // 
            this.checkBoxQnt.AutoSize = true;
            this.checkBoxQnt.Location = new System.Drawing.Point(233, 19);
            this.checkBoxQnt.Name = "checkBoxQnt";
            this.checkBoxQnt.Size = new System.Drawing.Size(144, 16);
            this.checkBoxQnt.TabIndex = 5;
            this.checkBoxQnt.Text = "包含库存为零的宣传品";
            this.checkBoxQnt.UseVisualStyleBackColor = true;
            // 
            // checkBoxInOu
            // 
            this.checkBoxInOu.AutoSize = true;
            this.checkBoxInOu.Location = new System.Drawing.Point(455, 111);
            this.checkBoxInOu.Name = "checkBoxInOu";
            this.checkBoxInOu.Size = new System.Drawing.Size(48, 16);
            this.checkBoxInOu.TabIndex = 12;
            this.checkBoxInOu.Text = "货源";
            this.checkBoxInOu.UseVisualStyleBackColor = true;
            // 
            // InOutReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 532);
            this.Controls.Add(this.checkBoxInOu);
            this.Controls.Add(this.cobInTableIn_Ou);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewInOutReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InOutReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宣传品进销存报表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InOutReportForm_FormClosed);
            this.Load += new System.EventHandler(this.InOutReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInOutReport)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewTextBoxColumn s_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn o_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_price;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxPlan;
        private System.Windows.Forms.RadioButton radioButtonSelectPlan;
        private System.Windows.Forms.RadioButton radioButtonPlanAll;
        private System.Windows.Forms.ComboBox cobInTableIn_Ou;
        private System.Windows.Forms.CheckBox checkBoxQnt;
        private System.Windows.Forms.CheckBox checkBoxInOu;
    }
}