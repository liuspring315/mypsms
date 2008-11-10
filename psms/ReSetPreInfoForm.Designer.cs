namespace psms
{
    partial class ReSetPreInfoForm
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
            this.dataGridViewCheckTable = new System.Windows.Forms.DataGridView();
            this.ColumnP_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnP_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAcc_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFact_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCheckTable = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtChck_memo = new System.Windows.Forms.TextBox();
            this.txtFact_qnt = new System.Windows.Forms.TextBox();
            this.txtAcc_qnt = new System.Windows.Forms.TextBox();
            this.txtP_name = new System.Windows.Forms.TextBox();
            this.txtP_no = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckTable)).BeginInit();
            this.groupBoxCheckTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCheckTable
            // 
            this.dataGridViewCheckTable.AllowUserToAddRows = false;
            this.dataGridViewCheckTable.AllowUserToDeleteRows = false;
            this.dataGridViewCheckTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheckTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnP_no,
            this.ColumnP_name,
            this.ColumnAcc_qnt,
            this.ColumnFact_qnt});
            this.dataGridViewCheckTable.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCheckTable.Name = "dataGridViewCheckTable";
            this.dataGridViewCheckTable.ReadOnly = true;
            this.dataGridViewCheckTable.RowHeadersWidth = 10;
            this.dataGridViewCheckTable.RowTemplate.Height = 23;
            this.dataGridViewCheckTable.Size = new System.Drawing.Size(495, 494);
            this.dataGridViewCheckTable.TabIndex = 0;
            this.dataGridViewCheckTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCheckTable_CellClick);
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
            this.ColumnP_name.Width = 180;
            // 
            // ColumnAcc_qnt
            // 
            this.ColumnAcc_qnt.DataPropertyName = "Acc_qnt";
            this.ColumnAcc_qnt.HeaderText = "帐存数量";
            this.ColumnAcc_qnt.Name = "ColumnAcc_qnt";
            this.ColumnAcc_qnt.ReadOnly = true;
            // 
            // ColumnFact_qnt
            // 
            this.ColumnFact_qnt.DataPropertyName = "Fact_qnt";
            this.ColumnFact_qnt.HeaderText = "实存数量";
            this.ColumnFact_qnt.Name = "ColumnFact_qnt";
            this.ColumnFact_qnt.ReadOnly = true;
            // 
            // groupBoxCheckTable
            // 
            this.groupBoxCheckTable.Controls.Add(this.btnClose);
            this.groupBoxCheckTable.Controls.Add(this.btnCancel);
            this.groupBoxCheckTable.Controls.Add(this.btnNext);
            this.groupBoxCheckTable.Controls.Add(this.txtChck_memo);
            this.groupBoxCheckTable.Controls.Add(this.txtFact_qnt);
            this.groupBoxCheckTable.Controls.Add(this.txtAcc_qnt);
            this.groupBoxCheckTable.Controls.Add(this.txtP_name);
            this.groupBoxCheckTable.Controls.Add(this.txtP_no);
            this.groupBoxCheckTable.Controls.Add(this.label5);
            this.groupBoxCheckTable.Controls.Add(this.label4);
            this.groupBoxCheckTable.Controls.Add(this.label3);
            this.groupBoxCheckTable.Controls.Add(this.label2);
            this.groupBoxCheckTable.Controls.Add(this.label1);
            this.groupBoxCheckTable.Location = new System.Drawing.Point(520, 13);
            this.groupBoxCheckTable.Name = "groupBoxCheckTable";
            this.groupBoxCheckTable.Size = new System.Drawing.Size(265, 493);
            this.groupBoxCheckTable.TabIndex = 1;
            this.groupBoxCheckTable.TabStop = false;
            this.groupBoxCheckTable.Text = "要清零的宣传品";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(29, 454);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(216, 33);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "退    出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(29, 414);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(135, 34);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "下一项";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtChck_memo
            // 
            this.txtChck_memo.Location = new System.Drawing.Point(17, 204);
            this.txtChck_memo.Multiline = true;
            this.txtChck_memo.Name = "txtChck_memo";
            this.txtChck_memo.Size = new System.Drawing.Size(242, 203);
            this.txtChck_memo.TabIndex = 9;
            // 
            // txtFact_qnt
            // 
            this.txtFact_qnt.Location = new System.Drawing.Point(74, 139);
            this.txtFact_qnt.Name = "txtFact_qnt";
            this.txtFact_qnt.Size = new System.Drawing.Size(185, 21);
            this.txtFact_qnt.TabIndex = 8;
            // 
            // txtAcc_qnt
            // 
            this.txtAcc_qnt.Enabled = false;
            this.txtAcc_qnt.Location = new System.Drawing.Point(74, 98);
            this.txtAcc_qnt.Name = "txtAcc_qnt";
            this.txtAcc_qnt.Size = new System.Drawing.Size(185, 21);
            this.txtAcc_qnt.TabIndex = 7;
            // 
            // txtP_name
            // 
            this.txtP_name.Enabled = false;
            this.txtP_name.Location = new System.Drawing.Point(74, 59);
            this.txtP_name.Name = "txtP_name";
            this.txtP_name.Size = new System.Drawing.Size(185, 21);
            this.txtP_name.TabIndex = 6;
            // 
            // txtP_no
            // 
            this.txtP_no.Enabled = false;
            this.txtP_no.Location = new System.Drawing.Point(74, 20);
            this.txtP_no.Name = "txtP_no";
            this.txtP_no.Size = new System.Drawing.Size(185, 21);
            this.txtP_no.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "备    注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "实存数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "帐存数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "宣传品名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "宣传品编号";
            // 
            // ReSetPreInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 518);
            this.Controls.Add(this.groupBoxCheckTable);
            this.Controls.Add(this.dataGridViewCheckTable);
            this.MaximizeBox = false;
            this.Name = "ReSetPreInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存清零";
            this.Load += new System.EventHandler(this.ReSetPreInfoForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReSetPreInfoForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckTable)).EndInit();
            this.groupBoxCheckTable.ResumeLayout(false);
            this.groupBoxCheckTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCheckTable;
        private System.Windows.Forms.GroupBox groupBoxCheckTable;
        private System.Windows.Forms.TextBox txtAcc_qnt;
        private System.Windows.Forms.TextBox txtP_name;
        private System.Windows.Forms.TextBox txtP_no;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAcc_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFact_qnt;
        private System.Windows.Forms.TextBox txtChck_memo;
        private System.Windows.Forms.TextBox txtFact_qnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}