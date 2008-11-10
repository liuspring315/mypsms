namespace psms
{
    partial class InOutPieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InOutPieForm));
            this.comboBoxInOut = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPieShow = new System.Windows.Forms.Button();
            this.btnBarShow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxInOut
            // 
            this.comboBoxInOut.FormattingEnabled = true;
            this.comboBoxInOut.Location = new System.Drawing.Point(51, 62);
            this.comboBoxInOut.Name = "comboBoxInOut";
            this.comboBoxInOut.Size = new System.Drawing.Size(121, 20);
            this.comboBoxInOut.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "统计出库量还是入库量？";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "按宣传品系列统计";
            // 
            // btnPieShow
            // 
            this.btnPieShow.Location = new System.Drawing.Point(27, 104);
            this.btnPieShow.Name = "btnPieShow";
            this.btnPieShow.Size = new System.Drawing.Size(75, 23);
            this.btnPieShow.TabIndex = 4;
            this.btnPieShow.Text = "输出饼形图";
            this.btnPieShow.UseVisualStyleBackColor = true;
            this.btnPieShow.Click += new System.EventHandler(this.btnPieShow_Click);
            // 
            // btnBarShow
            // 
            this.btnBarShow.Location = new System.Drawing.Point(104, 104);
            this.btnBarShow.Name = "btnBarShow";
            this.btnBarShow.Size = new System.Drawing.Size(75, 23);
            this.btnBarShow.TabIndex = 5;
            this.btnBarShow.Text = "输出柱形图";
            this.btnBarShow.UseVisualStyleBackColor = true;
            this.btnBarShow.Click += new System.EventHandler(this.btnBarShow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InOutPieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 139);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBarShow);
            this.Controls.Add(this.btnPieShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxInOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InOutPieForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择统计条件";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InOutPieForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxInOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPieShow;
        private System.Windows.Forms.Button btnBarShow;
        private System.Windows.Forms.Button btnCancel;
    }
}