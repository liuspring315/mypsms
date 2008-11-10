namespace psms
{
    partial class QueryOutTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryOutTableForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnOut_scrpno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVip_ou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_ou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_Acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConditionDate = new System.Windows.Forms.CheckBox();
            this.txtPreInfo = new System.Windows.Forms.TextBox();
            this.comboBoxVip_ou = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAllQuery = new System.Windows.Forms.Button();
            this.btnConditionQuery = new System.Windows.Forms.Button();
            this.txtOut_cost2 = new System.Windows.Forms.TextBox();
            this.dateTimePickerOut_date2 = new System.Windows.Forms.DateTimePicker();
            this.txtOut_scrpno2 = new System.Windows.Forms.TextBox();
            this.comboBoxOut_acc = new System.Windows.Forms.ComboBox();
            this.comboBoxOut_ou = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerOut_date1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOut_memo = new System.Windows.Forms.TextBox();
            this.txtOut_cost1 = new System.Windows.Forms.TextBox();
            this.txtOut_scrpno1 = new System.Windows.Forms.TextBox();
            this.checkBoxOut_cost = new System.Windows.Forms.CheckBox();
            this.checkBoxOut_date = new System.Windows.Forms.CheckBox();
            this.checkBoxOut_scrpno = new System.Windows.Forms.CheckBox();
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
            this.ColumnOut_scrpno,
            this.ColumnVip_ou,
            this.ColumnOut_ou,
            this.ColumnOut_date,
            this.ColumnOut_cost,
            this.ColumnOut_Acc,
            this.ColumnOut_memo,
            this.ColumnButton});
            this.dataGridView1.Location = new System.Drawing.Point(12, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(767, 289);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnOut_scrpno
            // 
            this.ColumnOut_scrpno.DataPropertyName = "Out_scrpno";
            this.ColumnOut_scrpno.HeaderText = "凭证编号";
            this.ColumnOut_scrpno.Name = "ColumnOut_scrpno";
            this.ColumnOut_scrpno.ReadOnly = true;
            // 
            // ColumnVip_ou
            // 
            this.ColumnVip_ou.DataPropertyName = "vip_ou";
            this.ColumnVip_ou.HeaderText = "赠送分类";
            this.ColumnVip_ou.Name = "ColumnVip_ou";
            this.ColumnVip_ou.ReadOnly = true;
            // 
            // ColumnOut_ou
            // 
            this.ColumnOut_ou.DataPropertyName = "Out_ou";
            this.ColumnOut_ou.HeaderText = "请领单位";
            this.ColumnOut_ou.Name = "ColumnOut_ou";
            this.ColumnOut_ou.ReadOnly = true;
            // 
            // ColumnOut_date
            // 
            this.ColumnOut_date.DataPropertyName = "Out_date";
            this.ColumnOut_date.HeaderText = "出库日期";
            this.ColumnOut_date.Name = "ColumnOut_date";
            this.ColumnOut_date.ReadOnly = true;
            // 
            // ColumnOut_cost
            // 
            this.ColumnOut_cost.DataPropertyName = "Out_cost";
            this.ColumnOut_cost.HeaderText = "结算金额";
            this.ColumnOut_cost.Name = "ColumnOut_cost";
            this.ColumnOut_cost.ReadOnly = true;
            // 
            // ColumnOut_Acc
            // 
            this.ColumnOut_Acc.DataPropertyName = "strOutacc";
            this.ColumnOut_Acc.HeaderText = "做账";
            this.ColumnOut_Acc.Name = "ColumnOut_Acc";
            this.ColumnOut_Acc.ReadOnly = true;
            this.ColumnOut_Acc.Visible = false;
            this.ColumnOut_Acc.Width = 70;
            // 
            // ColumnOut_memo
            // 
            this.ColumnOut_memo.DataPropertyName = "Out_memo";
            this.ColumnOut_memo.HeaderText = "备注";
            this.ColumnOut_memo.Name = "ColumnOut_memo";
            this.ColumnOut_memo.ReadOnly = true;
            // 
            // ColumnButton
            // 
            this.ColumnButton.HeaderText = "详细";
            this.ColumnButton.Name = "ColumnButton";
            this.ColumnButton.ReadOnly = true;
            this.ColumnButton.Text = "详细";
            this.ColumnButton.ToolTipText = "详细";
            this.ColumnButton.UseColumnTextForButtonValue = true;
            this.ColumnButton.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxConditionDate);
            this.groupBox1.Controls.Add(this.txtPreInfo);
            this.groupBox1.Controls.Add(this.comboBoxVip_ou);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAllQuery);
            this.groupBox1.Controls.Add(this.btnConditionQuery);
            this.groupBox1.Controls.Add(this.txtOut_cost2);
            this.groupBox1.Controls.Add(this.dateTimePickerOut_date2);
            this.groupBox1.Controls.Add(this.txtOut_scrpno2);
            this.groupBox1.Controls.Add(this.comboBoxOut_acc);
            this.groupBox1.Controls.Add(this.comboBoxOut_ou);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePickerOut_date1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOut_memo);
            this.groupBox1.Controls.Add(this.txtOut_cost1);
            this.groupBox1.Controls.Add(this.txtOut_scrpno1);
            this.groupBox1.Controls.Add(this.checkBoxOut_cost);
            this.groupBox1.Controls.Add(this.checkBoxOut_date);
            this.groupBox1.Controls.Add(this.checkBoxOut_scrpno);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 206);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // checkBoxConditionDate
            // 
            this.checkBoxConditionDate.AutoSize = true;
            this.checkBoxConditionDate.Location = new System.Drawing.Point(38, 74);
            this.checkBoxConditionDate.Name = "checkBoxConditionDate";
            this.checkBoxConditionDate.Size = new System.Drawing.Size(84, 16);
            this.checkBoxConditionDate.TabIndex = 26;
            this.checkBoxConditionDate.Text = "按日期查询";
            this.checkBoxConditionDate.UseVisualStyleBackColor = true;
            this.checkBoxConditionDate.CheckedChanged += new System.EventHandler(this.checkBoxConditionDate_CheckedChanged);
            // 
            // txtPreInfo
            // 
            this.txtPreInfo.Location = new System.Drawing.Point(408, 90);
            this.txtPreInfo.Name = "txtPreInfo";
            this.txtPreInfo.Size = new System.Drawing.Size(179, 21);
            this.txtPreInfo.TabIndex = 25;
            // 
            // comboBoxVip_ou
            // 
            this.comboBoxVip_ou.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxVip_ou.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxVip_ou.FormattingEnabled = true;
            this.comboBoxVip_ou.Location = new System.Drawing.Point(408, 57);
            this.comboBoxVip_ou.Name = "comboBoxVip_ou";
            this.comboBoxVip_ou.Size = new System.Drawing.Size(179, 20);
            this.comboBoxVip_ou.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "赠送分类";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 145);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAllQuery
            // 
            this.btnAllQuery.Location = new System.Drawing.Point(640, 99);
            this.btnAllQuery.Name = "btnAllQuery";
            this.btnAllQuery.Size = new System.Drawing.Size(75, 23);
            this.btnAllQuery.TabIndex = 21;
            this.btnAllQuery.Text = "全部查询";
            this.btnAllQuery.UseVisualStyleBackColor = true;
            this.btnAllQuery.Click += new System.EventHandler(this.btnAllQuery_Click);
            // 
            // btnConditionQuery
            // 
            this.btnConditionQuery.Location = new System.Drawing.Point(640, 56);
            this.btnConditionQuery.Name = "btnConditionQuery";
            this.btnConditionQuery.Size = new System.Drawing.Size(75, 23);
            this.btnConditionQuery.TabIndex = 20;
            this.btnConditionQuery.Text = "条件查询";
            this.btnConditionQuery.UseVisualStyleBackColor = true;
            this.btnConditionQuery.Click += new System.EventHandler(this.btnConditionQuery_Click);
            // 
            // txtOut_cost2
            // 
            this.txtOut_cost2.Location = new System.Drawing.Point(151, 168);
            this.txtOut_cost2.Name = "txtOut_cost2";
            this.txtOut_cost2.Size = new System.Drawing.Size(113, 21);
            this.txtOut_cost2.TabIndex = 19;
            this.txtOut_cost2.Visible = false;
            // 
            // dateTimePickerOut_date2
            // 
            this.dateTimePickerOut_date2.Enabled = false;
            this.dateTimePickerOut_date2.Location = new System.Drawing.Point(151, 111);
            this.dateTimePickerOut_date2.Name = "dateTimePickerOut_date2";
            this.dateTimePickerOut_date2.Size = new System.Drawing.Size(113, 21);
            this.dateTimePickerOut_date2.TabIndex = 18;
            this.dateTimePickerOut_date2.Visible = false;
            // 
            // txtOut_scrpno2
            // 
            this.txtOut_scrpno2.Location = new System.Drawing.Point(151, 56);
            this.txtOut_scrpno2.Name = "txtOut_scrpno2";
            this.txtOut_scrpno2.Size = new System.Drawing.Size(113, 21);
            this.txtOut_scrpno2.TabIndex = 17;
            this.txtOut_scrpno2.Visible = false;
            // 
            // comboBoxOut_acc
            // 
            this.comboBoxOut_acc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxOut_acc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxOut_acc.FormattingEnabled = true;
            this.comboBoxOut_acc.Location = new System.Drawing.Point(408, 153);
            this.comboBoxOut_acc.Name = "comboBoxOut_acc";
            this.comboBoxOut_acc.Size = new System.Drawing.Size(179, 20);
            this.comboBoxOut_acc.TabIndex = 16;
            this.comboBoxOut_acc.Visible = false;
            // 
            // comboBoxOut_ou
            // 
            this.comboBoxOut_ou.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxOut_ou.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxOut_ou.FormattingEnabled = true;
            this.comboBoxOut_ou.Location = new System.Drawing.Point(408, 21);
            this.comboBoxOut_ou.Name = "comboBoxOut_ou";
            this.comboBoxOut_ou.Size = new System.Drawing.Size(179, 20);
            this.comboBoxOut_ou.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "作帐情况";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "备    注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "宣传品信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "请领单位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "结算金额";
            // 
            // dateTimePickerOut_date1
            // 
            this.dateTimePickerOut_date1.Enabled = false;
            this.dateTimePickerOut_date1.Location = new System.Drawing.Point(151, 84);
            this.dateTimePickerOut_date1.Name = "dateTimePickerOut_date1";
            this.dateTimePickerOut_date1.Size = new System.Drawing.Size(113, 21);
            this.dateTimePickerOut_date1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "出库日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "凭证编号";
            // 
            // txtOut_memo
            // 
            this.txtOut_memo.Location = new System.Drawing.Point(408, 120);
            this.txtOut_memo.Name = "txtOut_memo";
            this.txtOut_memo.Size = new System.Drawing.Size(179, 21);
            this.txtOut_memo.TabIndex = 5;
            // 
            // txtOut_cost1
            // 
            this.txtOut_cost1.Location = new System.Drawing.Point(151, 141);
            this.txtOut_cost1.Name = "txtOut_cost1";
            this.txtOut_cost1.Size = new System.Drawing.Size(113, 21);
            this.txtOut_cost1.TabIndex = 4;
            // 
            // txtOut_scrpno1
            // 
            this.txtOut_scrpno1.Location = new System.Drawing.Point(151, 29);
            this.txtOut_scrpno1.Name = "txtOut_scrpno1";
            this.txtOut_scrpno1.Size = new System.Drawing.Size(113, 21);
            this.txtOut_scrpno1.TabIndex = 3;
            // 
            // checkBoxOut_cost
            // 
            this.checkBoxOut_cost.AutoSize = true;
            this.checkBoxOut_cost.Location = new System.Drawing.Point(38, 150);
            this.checkBoxOut_cost.Name = "checkBoxOut_cost";
            this.checkBoxOut_cost.Size = new System.Drawing.Size(48, 16);
            this.checkBoxOut_cost.TabIndex = 2;
            this.checkBoxOut_cost.Text = "区间";
            this.checkBoxOut_cost.UseVisualStyleBackColor = true;
            this.checkBoxOut_cost.CheckedChanged += new System.EventHandler(this.checkBoxOut_cost_CheckedChanged);
            // 
            // checkBoxOut_date
            // 
            this.checkBoxOut_date.AutoSize = true;
            this.checkBoxOut_date.Enabled = false;
            this.checkBoxOut_date.Location = new System.Drawing.Point(38, 93);
            this.checkBoxOut_date.Name = "checkBoxOut_date";
            this.checkBoxOut_date.Size = new System.Drawing.Size(48, 16);
            this.checkBoxOut_date.TabIndex = 1;
            this.checkBoxOut_date.Text = "区间";
            this.checkBoxOut_date.UseVisualStyleBackColor = true;
            this.checkBoxOut_date.CheckedChanged += new System.EventHandler(this.checkBoxOut_date_CheckedChanged);
            // 
            // checkBoxOut_scrpno
            // 
            this.checkBoxOut_scrpno.AutoSize = true;
            this.checkBoxOut_scrpno.Location = new System.Drawing.Point(38, 37);
            this.checkBoxOut_scrpno.Name = "checkBoxOut_scrpno";
            this.checkBoxOut_scrpno.Size = new System.Drawing.Size(48, 16);
            this.checkBoxOut_scrpno.TabIndex = 0;
            this.checkBoxOut_scrpno.Text = "区间";
            this.checkBoxOut_scrpno.UseVisualStyleBackColor = true;
            this.checkBoxOut_scrpno.CheckedChanged += new System.EventHandler(this.checkBoxOut_scrpno_CheckedChanged);
            // 
            // QueryOutTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 538);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QueryOutTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出库信息查询";
            this.Load += new System.EventHandler(this.QueryOutTableForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QueryOutTableForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxVip_ou;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAllQuery;
        private System.Windows.Forms.Button btnConditionQuery;
        private System.Windows.Forms.TextBox txtOut_cost2;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut_date2;
        private System.Windows.Forms.TextBox txtOut_scrpno2;
        private System.Windows.Forms.ComboBox comboBoxOut_acc;
        private System.Windows.Forms.ComboBox comboBoxOut_ou;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut_date1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOut_memo;
        private System.Windows.Forms.TextBox txtOut_cost1;
        private System.Windows.Forms.TextBox txtOut_scrpno1;
        private System.Windows.Forms.CheckBox checkBoxOut_cost;
        private System.Windows.Forms.CheckBox checkBoxOut_date;
        private System.Windows.Forms.CheckBox checkBoxOut_scrpno;
        private System.Windows.Forms.TextBox txtPreInfo;
        private System.Windows.Forms.CheckBox checkBoxConditionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_scrpno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVip_ou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_ou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_Acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_memo;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButton;
    }
}