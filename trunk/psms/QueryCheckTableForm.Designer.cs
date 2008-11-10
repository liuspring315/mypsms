namespace psms
{
    partial class QueryCheckTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryCheckTableForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCheck_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheck_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnP_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnP_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAcc_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFact_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiff_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCheck_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnAllQuery = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtDiff_qnt2 = new System.Windows.Forms.TextBox();
            this.txtDiff_qnt1 = new System.Windows.Forms.TextBox();
            this.checkBoxDiff_qnt = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFact_qnt2 = new System.Windows.Forms.TextBox();
            this.txtFact_qnt1 = new System.Windows.Forms.TextBox();
            this.checkBoxFact_qnt = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAcc_qnt2 = new System.Windows.Forms.TextBox();
            this.txtAcc_qnt1 = new System.Windows.Forms.TextBox();
            this.checkBoxAcc_qnt = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxP_no = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtCheck_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck_no,
            this.ColumnCheck_date,
            this.ColumnP_no,
            this.ColumnP_name,
            this.ColumnAcc_qnt,
            this.ColumnFact_qnt,
            this.ColumnDiff_qnt,
            this.ColumnCheck_memo});
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(545, 502);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnCheck_no
            // 
            this.ColumnCheck_no.DataPropertyName = "Chck_no";
            this.ColumnCheck_no.HeaderText = "次数";
            this.ColumnCheck_no.Name = "ColumnCheck_no";
            this.ColumnCheck_no.ReadOnly = true;
            this.ColumnCheck_no.Width = 60;
            // 
            // ColumnCheck_date
            // 
            this.ColumnCheck_date.DataPropertyName = "Chck_date";
            this.ColumnCheck_date.HeaderText = "盘库日期";
            this.ColumnCheck_date.Name = "ColumnCheck_date";
            this.ColumnCheck_date.ReadOnly = true;
            this.ColumnCheck_date.Width = 80;
            // 
            // ColumnP_no
            // 
            this.ColumnP_no.DataPropertyName = "P_no";
            this.ColumnP_no.HeaderText = "宣传品编号";
            this.ColumnP_no.Name = "ColumnP_no";
            this.ColumnP_no.ReadOnly = true;
            // 
            // ColumnP_name
            // 
            this.ColumnP_name.DataPropertyName = "P_name";
            this.ColumnP_name.HeaderText = "宣传品名称";
            this.ColumnP_name.Name = "ColumnP_name";
            this.ColumnP_name.ReadOnly = true;
            // 
            // ColumnAcc_qnt
            // 
            this.ColumnAcc_qnt.DataPropertyName = "Acc_qnt";
            this.ColumnAcc_qnt.HeaderText = "帐存数量";
            this.ColumnAcc_qnt.Name = "ColumnAcc_qnt";
            this.ColumnAcc_qnt.ReadOnly = true;
            this.ColumnAcc_qnt.Width = 80;
            // 
            // ColumnFact_qnt
            // 
            this.ColumnFact_qnt.DataPropertyName = "Fact_qnt";
            this.ColumnFact_qnt.HeaderText = "实存数量";
            this.ColumnFact_qnt.Name = "ColumnFact_qnt";
            this.ColumnFact_qnt.ReadOnly = true;
            this.ColumnFact_qnt.Width = 80;
            // 
            // ColumnDiff_qnt
            // 
            this.ColumnDiff_qnt.DataPropertyName = "Diff_qnt";
            this.ColumnDiff_qnt.HeaderText = "帐物数量差";
            this.ColumnDiff_qnt.Name = "ColumnDiff_qnt";
            this.ColumnDiff_qnt.ReadOnly = true;
            // 
            // ColumnCheck_memo
            // 
            this.ColumnCheck_memo.DataPropertyName = "Chck_memo";
            this.ColumnCheck_memo.HeaderText = "备注";
            this.ColumnCheck_memo.Name = "ColumnCheck_memo";
            this.ColumnCheck_memo.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.btnAllQuery);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.txtDiff_qnt2);
            this.groupBox1.Controls.Add(this.txtDiff_qnt1);
            this.groupBox1.Controls.Add(this.checkBoxDiff_qnt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtFact_qnt2);
            this.groupBox1.Controls.Add(this.txtFact_qnt1);
            this.groupBox1.Controls.Add(this.checkBoxFact_qnt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAcc_qnt2);
            this.groupBox1.Controls.Add(this.txtAcc_qnt1);
            this.groupBox1.Controls.Add(this.checkBoxAcc_qnt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxP_no);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtCheck_no);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(553, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 502);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(51, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 23);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "退    出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(9, 362);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(204, 105);
            this.txtMemo.TabIndex = 23;
            // 
            // btnAllQuery
            // 
            this.btnAllQuery.Location = new System.Drawing.Point(127, 333);
            this.btnAllQuery.Name = "btnAllQuery";
            this.btnAllQuery.Size = new System.Drawing.Size(75, 23);
            this.btnAllQuery.TabIndex = 22;
            this.btnAllQuery.Text = "全部";
            this.btnAllQuery.UseVisualStyleBackColor = true;
            this.btnAllQuery.Click += new System.EventHandler(this.btnAllQuery_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(9, 333);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 21;
            this.btnQuery.Text = "查找";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtDiff_qnt2
            // 
            this.txtDiff_qnt2.Location = new System.Drawing.Point(94, 292);
            this.txtDiff_qnt2.Name = "txtDiff_qnt2";
            this.txtDiff_qnt2.Size = new System.Drawing.Size(68, 21);
            this.txtDiff_qnt2.TabIndex = 20;
            this.txtDiff_qnt2.Visible = false;
            // 
            // txtDiff_qnt1
            // 
            this.txtDiff_qnt1.Location = new System.Drawing.Point(9, 293);
            this.txtDiff_qnt1.Name = "txtDiff_qnt1";
            this.txtDiff_qnt1.Size = new System.Drawing.Size(68, 21);
            this.txtDiff_qnt1.TabIndex = 19;
            // 
            // checkBoxDiff_qnt
            // 
            this.checkBoxDiff_qnt.AutoSize = true;
            this.checkBoxDiff_qnt.Location = new System.Drawing.Point(78, 271);
            this.checkBoxDiff_qnt.Name = "checkBoxDiff_qnt";
            this.checkBoxDiff_qnt.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDiff_qnt.TabIndex = 18;
            this.checkBoxDiff_qnt.Text = "区间";
            this.checkBoxDiff_qnt.UseVisualStyleBackColor = true;
            this.checkBoxDiff_qnt.CheckedChanged += new System.EventHandler(this.checkBoxDiff_qnt_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "帐物数量差";
            // 
            // txtFact_qnt2
            // 
            this.txtFact_qnt2.Location = new System.Drawing.Point(94, 226);
            this.txtFact_qnt2.Name = "txtFact_qnt2";
            this.txtFact_qnt2.Size = new System.Drawing.Size(68, 21);
            this.txtFact_qnt2.TabIndex = 16;
            this.txtFact_qnt2.Visible = false;
            // 
            // txtFact_qnt1
            // 
            this.txtFact_qnt1.Location = new System.Drawing.Point(9, 227);
            this.txtFact_qnt1.Name = "txtFact_qnt1";
            this.txtFact_qnt1.Size = new System.Drawing.Size(68, 21);
            this.txtFact_qnt1.TabIndex = 15;
            // 
            // checkBoxFact_qnt
            // 
            this.checkBoxFact_qnt.AutoSize = true;
            this.checkBoxFact_qnt.Location = new System.Drawing.Point(78, 209);
            this.checkBoxFact_qnt.Name = "checkBoxFact_qnt";
            this.checkBoxFact_qnt.Size = new System.Drawing.Size(48, 16);
            this.checkBoxFact_qnt.TabIndex = 14;
            this.checkBoxFact_qnt.Text = "区间";
            this.checkBoxFact_qnt.UseVisualStyleBackColor = true;
            this.checkBoxFact_qnt.CheckedChanged += new System.EventHandler(this.checkBoxFact_qnt_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "实存数量";
            // 
            // txtAcc_qnt2
            // 
            this.txtAcc_qnt2.Location = new System.Drawing.Point(94, 168);
            this.txtAcc_qnt2.Name = "txtAcc_qnt2";
            this.txtAcc_qnt2.Size = new System.Drawing.Size(68, 21);
            this.txtAcc_qnt2.TabIndex = 12;
            this.txtAcc_qnt2.Visible = false;
            // 
            // txtAcc_qnt1
            // 
            this.txtAcc_qnt1.Location = new System.Drawing.Point(9, 169);
            this.txtAcc_qnt1.Name = "txtAcc_qnt1";
            this.txtAcc_qnt1.Size = new System.Drawing.Size(68, 21);
            this.txtAcc_qnt1.TabIndex = 11;
            // 
            // checkBoxAcc_qnt
            // 
            this.checkBoxAcc_qnt.AutoSize = true;
            this.checkBoxAcc_qnt.Location = new System.Drawing.Point(78, 152);
            this.checkBoxAcc_qnt.Name = "checkBoxAcc_qnt";
            this.checkBoxAcc_qnt.Size = new System.Drawing.Size(48, 16);
            this.checkBoxAcc_qnt.TabIndex = 10;
            this.checkBoxAcc_qnt.Text = "区间";
            this.checkBoxAcc_qnt.UseVisualStyleBackColor = true;
            this.checkBoxAcc_qnt.CheckedChanged += new System.EventHandler(this.checkBoxAcc_qnt_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "帐存数量";
            // 
            // comboBoxP_no
            // 
            this.comboBoxP_no.FormattingEnabled = true;
            this.comboBoxP_no.Location = new System.Drawing.Point(67, 112);
            this.comboBoxP_no.Name = "comboBoxP_no";
            this.comboBoxP_no.Size = new System.Drawing.Size(146, 20);
            this.comboBoxP_no.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "宣传品编号";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(99, 76);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(99, 49);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "盘库日期";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(67, 81);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(36, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "到";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(67, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(36, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "从";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtCheck_no
            // 
            this.txtCheck_no.Location = new System.Drawing.Point(67, 11);
            this.txtCheck_no.Name = "txtCheck_no";
            this.txtCheck_no.Size = new System.Drawing.Size(100, 21);
            this.txtCheck_no.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "盘库次数";
            // 
            // QueryCheckTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QueryCheckTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘存记录查询";
            this.Load += new System.EventHandler(this.QueryCheckTableForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueryCheckTableForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtCheck_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxP_no;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnAllQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtDiff_qnt2;
        private System.Windows.Forms.TextBox txtDiff_qnt1;
        private System.Windows.Forms.CheckBox checkBoxDiff_qnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFact_qnt2;
        private System.Windows.Forms.TextBox txtFact_qnt1;
        private System.Windows.Forms.CheckBox checkBoxFact_qnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAcc_qnt2;
        private System.Windows.Forms.TextBox txtAcc_qnt1;
        private System.Windows.Forms.CheckBox checkBoxAcc_qnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheck_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheck_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAcc_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFact_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiff_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCheck_memo;
    }
}