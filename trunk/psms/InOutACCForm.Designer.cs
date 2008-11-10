namespace psms
{
    partial class InOutACCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InOutACCForm));
            this.tabControlAcc = new System.Windows.Forms.TabControl();
            this.tabPageInAcc = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.labelInCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInClose = new System.Windows.Forms.Button();
            this.btnBeginInAcc = new System.Windows.Forms.Button();
            this.dataGridViewInAcc = new System.Windows.Forms.DataGridView();
            this.ColumnScrpno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn_ou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnP_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIn_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageOutAcc = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.labelOutCount = new System.Windows.Forms.Label();
            this.btnOutClose = new System.Windows.Forms.Button();
            this.btnBeginOutAcc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewOutAcc = new System.Windows.Forms.DataGridView();
            this.ColumnOut_scrpno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_ou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVip_ou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumOut_qnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOut_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlAcc.SuspendLayout();
            this.tabPageInAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInAcc)).BeginInit();
            this.tabPageOutAcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAcc
            // 
            this.tabControlAcc.Controls.Add(this.tabPageInAcc);
            this.tabControlAcc.Controls.Add(this.tabPageOutAcc);
            this.tabControlAcc.Location = new System.Drawing.Point(2, 2);
            this.tabControlAcc.Name = "tabControlAcc";
            this.tabControlAcc.SelectedIndex = 0;
            this.tabControlAcc.Size = new System.Drawing.Size(766, 514);
            this.tabControlAcc.TabIndex = 0;
            // 
            // tabPageInAcc
            // 
            this.tabPageInAcc.Controls.Add(this.label3);
            this.tabPageInAcc.Controls.Add(this.labelInCount);
            this.tabPageInAcc.Controls.Add(this.label6);
            this.tabPageInAcc.Controls.Add(this.btnInClose);
            this.tabPageInAcc.Controls.Add(this.btnBeginInAcc);
            this.tabPageInAcc.Controls.Add(this.dataGridViewInAcc);
            this.tabPageInAcc.Location = new System.Drawing.Point(4, 21);
            this.tabPageInAcc.Name = "tabPageInAcc";
            this.tabPageInAcc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInAcc.Size = new System.Drawing.Size(758, 489);
            this.tabPageInAcc.TabIndex = 0;
            this.tabPageInAcc.Text = "未做账入库凭证";
            this.tabPageInAcc.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "条";
            // 
            // labelInCount
            // 
            this.labelInCount.AutoSize = true;
            this.labelInCount.Location = new System.Drawing.Point(161, 452);
            this.labelInCount.Name = "labelInCount";
            this.labelInCount.Size = new System.Drawing.Size(0, 12);
            this.labelInCount.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 452);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "共有记录";
            // 
            // btnInClose
            // 
            this.btnInClose.Location = new System.Drawing.Point(601, 452);
            this.btnInClose.Name = "btnInClose";
            this.btnInClose.Size = new System.Drawing.Size(75, 23);
            this.btnInClose.TabIndex = 7;
            this.btnInClose.Text = "退出";
            this.btnInClose.UseVisualStyleBackColor = true;
            this.btnInClose.Click += new System.EventHandler(this.btnInClose_Click);
            // 
            // btnBeginInAcc
            // 
            this.btnBeginInAcc.Location = new System.Drawing.Point(447, 452);
            this.btnBeginInAcc.Name = "btnBeginInAcc";
            this.btnBeginInAcc.Size = new System.Drawing.Size(75, 23);
            this.btnBeginInAcc.TabIndex = 6;
            this.btnBeginInAcc.Text = "开始作帐";
            this.btnBeginInAcc.UseVisualStyleBackColor = true;
            this.btnBeginInAcc.Click += new System.EventHandler(this.btnBeginInAcc_Click);
            // 
            // dataGridViewInAcc
            // 
            this.dataGridViewInAcc.AllowUserToAddRows = false;
            this.dataGridViewInAcc.AllowUserToDeleteRows = false;
            this.dataGridViewInAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnScrpno,
            this.ColumnIn_ou,
            this.ColumnP_name,
            this.ColumnIn_date,
            this.ColumnQnt,
            this.ColumnIn_cost,
            this.ColumnIn_memo});
            this.dataGridViewInAcc.Location = new System.Drawing.Point(7, 13);
            this.dataGridViewInAcc.Name = "dataGridViewInAcc";
            this.dataGridViewInAcc.ReadOnly = true;
            this.dataGridViewInAcc.RowHeadersWidth = 20;
            this.dataGridViewInAcc.RowTemplate.Height = 23;
            this.dataGridViewInAcc.Size = new System.Drawing.Size(745, 413);
            this.dataGridViewInAcc.TabIndex = 4;
            // 
            // ColumnScrpno
            // 
            this.ColumnScrpno.DataPropertyName = "In_scrpno";
            this.ColumnScrpno.HeaderText = "凭证编号";
            this.ColumnScrpno.Name = "ColumnScrpno";
            this.ColumnScrpno.ReadOnly = true;
            // 
            // ColumnIn_ou
            // 
            this.ColumnIn_ou.DataPropertyName = "In_ou";
            this.ColumnIn_ou.HeaderText = "入库单位";
            this.ColumnIn_ou.Name = "ColumnIn_ou";
            this.ColumnIn_ou.ReadOnly = true;
            // 
            // ColumnP_name
            // 
            this.ColumnP_name.DataPropertyName = "P_name";
            this.ColumnP_name.HeaderText = "宣传品名称";
            this.ColumnP_name.Name = "ColumnP_name";
            this.ColumnP_name.ReadOnly = true;
            this.ColumnP_name.Width = 120;
            // 
            // ColumnIn_date
            // 
            this.ColumnIn_date.DataPropertyName = "In_date";
            this.ColumnIn_date.HeaderText = "入库日期";
            this.ColumnIn_date.Name = "ColumnIn_date";
            this.ColumnIn_date.ReadOnly = true;
            // 
            // ColumnQnt
            // 
            this.ColumnQnt.DataPropertyName = "qnt";
            this.ColumnQnt.HeaderText = "数量";
            this.ColumnQnt.Name = "ColumnQnt";
            this.ColumnQnt.ReadOnly = true;
            // 
            // ColumnIn_cost
            // 
            this.ColumnIn_cost.DataPropertyName = "In_cost";
            this.ColumnIn_cost.HeaderText = "入库金额";
            this.ColumnIn_cost.Name = "ColumnIn_cost";
            this.ColumnIn_cost.ReadOnly = true;
            // 
            // ColumnIn_memo
            // 
            this.ColumnIn_memo.DataPropertyName = "In_memo";
            this.ColumnIn_memo.HeaderText = "备注";
            this.ColumnIn_memo.Name = "ColumnIn_memo";
            this.ColumnIn_memo.ReadOnly = true;
            // 
            // tabPageOutAcc
            // 
            this.tabPageOutAcc.Controls.Add(this.label4);
            this.tabPageOutAcc.Controls.Add(this.labelOutCount);
            this.tabPageOutAcc.Controls.Add(this.btnOutClose);
            this.tabPageOutAcc.Controls.Add(this.btnBeginOutAcc);
            this.tabPageOutAcc.Controls.Add(this.label1);
            this.tabPageOutAcc.Controls.Add(this.dataGridViewOutAcc);
            this.tabPageOutAcc.Location = new System.Drawing.Point(4, 21);
            this.tabPageOutAcc.Name = "tabPageOutAcc";
            this.tabPageOutAcc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutAcc.Size = new System.Drawing.Size(758, 489);
            this.tabPageOutAcc.TabIndex = 1;
            this.tabPageOutAcc.Text = "未做账出库凭证";
            this.tabPageOutAcc.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "条";
            // 
            // labelOutCount
            // 
            this.labelOutCount.AutoSize = true;
            this.labelOutCount.Location = new System.Drawing.Point(144, 445);
            this.labelOutCount.Name = "labelOutCount";
            this.labelOutCount.Size = new System.Drawing.Size(0, 12);
            this.labelOutCount.TabIndex = 4;
            // 
            // btnOutClose
            // 
            this.btnOutClose.Location = new System.Drawing.Point(600, 445);
            this.btnOutClose.Name = "btnOutClose";
            this.btnOutClose.Size = new System.Drawing.Size(75, 23);
            this.btnOutClose.TabIndex = 3;
            this.btnOutClose.Text = "退出";
            this.btnOutClose.UseVisualStyleBackColor = true;
            this.btnOutClose.Click += new System.EventHandler(this.btnOutClose_Click);
            // 
            // btnBeginOutAcc
            // 
            this.btnBeginOutAcc.Location = new System.Drawing.Point(446, 445);
            this.btnBeginOutAcc.Name = "btnBeginOutAcc";
            this.btnBeginOutAcc.Size = new System.Drawing.Size(75, 23);
            this.btnBeginOutAcc.TabIndex = 2;
            this.btnBeginOutAcc.Text = "开始作帐";
            this.btnBeginOutAcc.UseVisualStyleBackColor = true;
            this.btnBeginOutAcc.Click += new System.EventHandler(this.btnBeginOutAcc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "共有记录";
            // 
            // dataGridViewOutAcc
            // 
            this.dataGridViewOutAcc.AllowUserToAddRows = false;
            this.dataGridViewOutAcc.AllowUserToDeleteRows = false;
            this.dataGridViewOutAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutAcc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOut_scrpno,
            this.ColumnOut_ou,
            this.ColumnVip_ou,
            this.ColumnOut_date,
            this.ColumOut_qnt,
            this.ColumnOut_cost,
            this.ColumnOut_memo});
            this.dataGridViewOutAcc.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewOutAcc.Name = "dataGridViewOutAcc";
            this.dataGridViewOutAcc.ReadOnly = true;
            this.dataGridViewOutAcc.RowTemplate.Height = 23;
            this.dataGridViewOutAcc.Size = new System.Drawing.Size(745, 413);
            this.dataGridViewOutAcc.TabIndex = 0;
            // 
            // ColumnOut_scrpno
            // 
            this.ColumnOut_scrpno.DataPropertyName = "Out_scrpno";
            this.ColumnOut_scrpno.HeaderText = "凭证编号";
            this.ColumnOut_scrpno.Name = "ColumnOut_scrpno";
            this.ColumnOut_scrpno.ReadOnly = true;
            // 
            // ColumnOut_ou
            // 
            this.ColumnOut_ou.DataPropertyName = "Out_ou";
            this.ColumnOut_ou.HeaderText = "收货单位";
            this.ColumnOut_ou.Name = "ColumnOut_ou";
            this.ColumnOut_ou.ReadOnly = true;
            // 
            // ColumnVip_ou
            // 
            this.ColumnVip_ou.DataPropertyName = "Vip_ou";
            this.ColumnVip_ou.HeaderText = "赠送分类";
            this.ColumnVip_ou.Name = "ColumnVip_ou";
            this.ColumnVip_ou.ReadOnly = true;
            // 
            // ColumnOut_date
            // 
            this.ColumnOut_date.DataPropertyName = "Out_date";
            this.ColumnOut_date.HeaderText = "出库日期";
            this.ColumnOut_date.Name = "ColumnOut_date";
            this.ColumnOut_date.ReadOnly = true;
            // 
            // ColumOut_qnt
            // 
            this.ColumOut_qnt.DataPropertyName = "qnt";
            this.ColumOut_qnt.HeaderText = "数量";
            this.ColumOut_qnt.Name = "ColumOut_qnt";
            this.ColumOut_qnt.ReadOnly = true;
            // 
            // ColumnOut_cost
            // 
            this.ColumnOut_cost.DataPropertyName = "Out_cost";
            this.ColumnOut_cost.HeaderText = "出库金额";
            this.ColumnOut_cost.Name = "ColumnOut_cost";
            this.ColumnOut_cost.ReadOnly = true;
            // 
            // ColumnOut_memo
            // 
            this.ColumnOut_memo.DataPropertyName = "Out_memo";
            this.ColumnOut_memo.HeaderText = "备注";
            this.ColumnOut_memo.Name = "ColumnOut_memo";
            this.ColumnOut_memo.ReadOnly = true;
            // 
            // InOutACCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 528);
            this.Controls.Add(this.tabControlAcc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InOutACCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "记宣传品库存帐";
            this.Load += new System.EventHandler(this.InOutACCForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InOutACCForm_FormClosed);
            this.tabControlAcc.ResumeLayout(false);
            this.tabPageInAcc.ResumeLayout(false);
            this.tabPageInAcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInAcc)).EndInit();
            this.tabPageOutAcc.ResumeLayout(false);
            this.tabPageOutAcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutAcc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAcc;
        private System.Windows.Forms.TabPage tabPageInAcc;
        private System.Windows.Forms.TabPage tabPageOutAcc;
        private System.Windows.Forms.Button btnInClose;
        private System.Windows.Forms.Button btnBeginInAcc;
        private System.Windows.Forms.DataGridView dataGridViewInAcc;
        private System.Windows.Forms.Button btnOutClose;
        private System.Windows.Forms.Button btnBeginOutAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnScrpno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn_ou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnP_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIn_memo;
        private System.Windows.Forms.DataGridView dataGridViewOutAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_scrpno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_ou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVip_ou;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumOut_qnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOut_memo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelOutCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelInCount;
        private System.Windows.Forms.Label label6;
    }
}