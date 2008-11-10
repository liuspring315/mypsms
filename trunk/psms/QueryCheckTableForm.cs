using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.util;

namespace psms
{
    public partial class QueryCheckTableForm : Form
    {
        public QueryCheckTableForm()
        {
            InitializeComponent();
        }

        private void QueryCheckTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        #region 事件
        
       

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //throw new System.Exception("The method or operation is not implemented.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.dateTimePicker1.Enabled = true;
            }
            else
            {
                this.dateTimePicker1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.dateTimePicker2.Enabled = true;
            }
            else
            {
                this.dateTimePicker2.Enabled = false;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder condition = new StringBuilder();

                //盘库次数
                if (this.txtCheck_no.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtCheck_no.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("盘库次数请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and chck_no = ").Append(this.txtCheck_no.Text.Trim());
                }


                //盘库日期
                if (this.checkBox1.Checked)
                {
                    if (this.checkBox2.Checked)
                    {
                        condition.Append(" and chck_date >= cast('").Append(this.dateTimePicker1.Value.ToShortDateString()).Append("'as datetime) ");
                        condition.Append(" and chck_date <= cast('").Append(this.dateTimePicker2.Value.ToShortDateString()).Append("'as datetime) ");
                    }
                    else
                    {
                        condition.Append(" and chck_date = cast('").Append(this.dateTimePicker1.Value.ToShortDateString()).Append("'as datetime) ");
                    }
                }


                //宣传品编号
                if (this.comboBoxP_no.Text != "")
                {
                    condition.Append(" and CHECKTABLE.p_no = '").Append(this.comboBoxP_no.Text.Trim()).Append("'");
                }


                //帐存数量
                if (this.txtAcc_qnt1.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtAcc_qnt1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("帐存数量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxAcc_qnt.Checked)
                    {
                        try
                        {
                            Int32.Parse(this.txtAcc_qnt2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("帐存数量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and CHECKTABLE.acc_qnt >= ").Append(this.txtAcc_qnt1.Text.Trim());
                        condition.Append(" and CHECKTABLE.acc_qnt <= ").Append(this.txtAcc_qnt2.Text.Trim());

                    }
                    else
                    {
                        condition.Append(" and CHECKTABLE.acc_qnt = ").Append(this.txtAcc_qnt1.Text.Trim());
                    }
                }



                //实存储量
                if (this.txtFact_qnt1.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtFact_qnt1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("实存储量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxFact_qnt.Checked)
                    {
                        try
                        {
                            Int32.Parse(this.txtFact_qnt2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("实存储量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and CHECKTABLE.fact_qnt >= ").Append(this.txtFact_qnt1.Text.Trim());
                        condition.Append(" and CHECKTABLE.fact_qnt <= ").Append(this.txtFact_qnt2.Text.Trim());

                    }
                    else
                    {
                        condition.Append(" and CHECKTABLE.fact_qnt = ").Append(this.txtFact_qnt1.Text.Trim());
                    }
                }

                //帐物数量差
                if (this.txtDiff_qnt1.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtDiff_qnt1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("帐物数量差请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxDiff_qnt.Checked)
                    {
                        try
                        {
                            Int32.Parse(this.txtDiff_qnt2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("帐物数量差请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and CHECKTABLE.diff_qnt >= ").Append(this.txtDiff_qnt1.Text.Trim());
                        condition.Append(" and CHECKTABLE.diff_qnt <= ").Append(this.txtDiff_qnt2.Text.Trim());

                    }
                    else
                    {
                        condition.Append(" and CHECKTABLE.diff_qnt = ").Append(this.txtDiff_qnt1.Text.Trim());
                    }
                }

                //查询
                this.dataGridView1.DataSource = new BLL.CheckTable().GetCheckTableInfoByCondition(condition.ToString());
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("盘存查询",ex);
            }
        }

        private void btnAllQuery_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.CheckTable checkTableBll = new BLL.CheckTable();
                this.dataGridView1.DataSource = checkTableBll.GetAllCheckTableInfo();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("盘存查询", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxAcc_qnt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAcc_qnt.Checked)
            {
                this.txtAcc_qnt2.Visible = true;
            }
            else
            {
                this.txtAcc_qnt2.Visible = false;
            }
        }

        private void checkBoxFact_qnt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxFact_qnt.Checked)
            {
                this.txtFact_qnt2.Visible = true;
            }
            else
            {
                this.txtFact_qnt2.Visible = false;
            }
        }

        private void checkBoxDiff_qnt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDiff_qnt.Checked)
            {
                this.txtDiff_qnt2.Visible = true;
            }
            else
            {
                this.txtDiff_qnt2.Visible = false;
            }
        }

       

        private void QueryCheckTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                setDataGridColumnName();
                this.comboBoxP_no.DataSource = new BLL.PreInfo().GetAllPreInfo();
                this.comboBoxP_no.DisplayMember = "p_no";
                this.comboBoxP_no.ValueMember = "p_no";

                BLL.CheckTable checkTableBll = new BLL.CheckTable();
                int checkNo = checkTableBll.GetCheckNo();
                this.dataGridView1.DataSource = checkTableBll.GetCheckTableInfoByCheckNo(checkNo);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("盘存查询", ex);
            }
        }

        #endregion




        #region 私有方法

        private void setDataGridColumnName()
        {
            this.dataGridView1.Columns["ColumnCheck_no"].DisplayIndex = 0;
            this.dataGridView1.Columns["ColumnCheck_date"].DisplayIndex = 1;
            this.dataGridView1.Columns["ColumnP_no"].DisplayIndex = 2;
            this.dataGridView1.Columns["ColumnP_name"].DisplayIndex = 3;
            this.dataGridView1.Columns["ColumnAcc_qnt"].DisplayIndex = 4;
            this.dataGridView1.Columns["ColumnFact_qnt"].DisplayIndex = 5;
            this.dataGridView1.Columns["ColumnDiff_qnt"].DisplayIndex = 6;
            this.dataGridView1.Columns["ColumnCheck_memo"].DisplayIndex = 7;
            this.dataGridView1.AutoGenerateColumns = false;

        }
        #endregion



    }
}