using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.Model;
using psms.util;

namespace psms
{
    public partial class QueryOutTableForm : Form
    {


        //字段
        private IList<OutTableInfo> queryOutTableList;

        public static QueryOutTableForm thisForm;


        public QueryOutTableForm()
        {
            InitializeComponent();
            thisForm = this;
        }


        #region 事件
        
        
        private void QueryOutTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void checkBoxOut_scrpno_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtOut_scrpno2.Visible = true;
            }
            else
            {
                this.txtOut_scrpno2.Visible = false;
            }
        }

        private void checkBoxOut_date_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.dateTimePickerOut_date2.Visible = true;
            }
            else
            {
                this.dateTimePickerOut_date2.Visible = false;
            }
        }

        private void checkBoxOut_cost_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtOut_cost2.Visible = true;
            }
            else
            {
                this.txtOut_cost2.Visible = false;
            }
        }

        private void btnConditionQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder condition = new StringBuilder();
                //凭证编号
                if (this.txtOut_scrpno1.Text != "")
                {
                    if (this.checkBoxOut_scrpno.Checked)
                    {
                        if (this.txtOut_scrpno2.Text.Trim() == "")
                        {
                            MyMessageBox.ShowInfoMessageBox("凭证编号的区间选项被选中，请输入完成的凭证编号区间条件");
                            return;
                        }
                        condition.Append(" and o.out_scrpno >='").Append(this.txtOut_scrpno1.Text.Trim()).Append("' ");
                        condition.Append(" and o.out_scrpno <='").Append(this.txtOut_scrpno2.Text.Trim()).Append("' ");
                    }
                    else
                    {
                        condition.Append(" and o.out_scrpno like '%").Append(this.txtOut_scrpno1.Text.Trim()).Append("%' ");
                    }
                }


                //出入日期
                if (this.checkBoxConditionDate.Checked)
                {
                    if (this.checkBoxOut_date.Checked)
                    {
                        condition.Append(" and out_date >= '").Append(this.dateTimePickerOut_date1.Value.ToShortDateString()).Append("' ");
                        condition.Append(" and out_date <= '").Append(this.dateTimePickerOut_date2.Value.ToShortDateString()).Append("' ");
                    }
                    else
                    {
                        condition.Append(" and out_date >= '").Append(this.dateTimePickerOut_date1.Value.ToShortDateString()).Append("' ");
                        condition.Append(" and out_date <= '").Append(this.dateTimePickerOut_date1.Value.ToShortDateString()).Append("' ");
                    }
                }


                //结算金额
                if (this.txtOut_cost1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtOut_cost1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("结算金额请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxOut_cost.Checked)
                    {
                        try
                        {
                            Decimal.Parse(this.txtOut_cost2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("结算金额请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and out_cost >= ").Append(this.txtOut_cost1.Text.Trim());
                        condition.Append(" and out_cost <= ").Append(this.txtOut_cost2.Text.Trim());
                    }
                    else
                    {
                        condition.Append(" and out_cost = ").Append(this.txtOut_cost1.Text.Trim());
                    }
                }


                //请领单位
                if (this.comboBoxOut_ou.Text != "")
                {
                    condition.Append(" and out_ou = '").Append(this.comboBoxOut_ou.Text.ToString().Trim()).Append("'");
                }



                //赠送分类
                if (this.comboBoxVip_ou.Text != "")
                {
                    condition.Append(" and vip_ou = '").Append(this.comboBoxVip_ou.Text.ToString().Trim()).Append("'");
                }



                //宣传品信息
                if (this.txtPreInfo.Text != "")
                {
                    condition.Append(" and p_name like '%").Append(this.txtPreInfo.Text.Trim()).Append("%'");
                }



                //备注
                if (this.txtOut_memo.Text != "")
                {
                    condition.Append(" and out_memo like '%").Append(this.txtOut_memo.Text.ToString().Trim()).Append("%'");
                }


                //做帐情况
                if (this.comboBoxOut_acc.SelectedIndex >= 0)
                {
                    if (((util.ValueObject)this.comboBoxOut_acc.SelectedItem).Value.ToString() != "")
                    {
                        condition.Append(" and out_acc = ").Append(((util.ValueObject)this.comboBoxOut_acc.SelectedItem).Value.ToString()).Append(" ");
                    }
                }


                //查询
                this.queryOutTableList = new BLL.OutTable().GetOutTableByCondition(condition.ToString());
                this.dataGridView1.DataSource = this.queryOutTableList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库条件查询事件",ex);
            }
        }

        private void btnAllQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.queryOutTableList = new BLL.OutTable().GetOutTableByCondition("");
                this.dataGridView1.DataSource = this.queryOutTableList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库全部查询事件", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "ColumnButton")
                {
                    string out_scrpno = this.dataGridView1.Rows[e.RowIndex].Cells["ColumnOut_scrpno"].Value.ToString().Trim();
                    OutTableInfo data = getOutTableInfoByOutScrpno(out_scrpno);
                    if (data != null)
                    {
                        UpdateOutTableForm updateForm = new UpdateOutTableForm(data);
                        updateForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库查询查看详细事件", ex);
            }

        }

        private void checkBoxConditionDate_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.checkBoxOut_date.Enabled = true;
                this.dateTimePickerOut_date1.Enabled = true;
                this.dateTimePickerOut_date2.Enabled = true;
            }
            else
            {
                this.checkBoxOut_date.Enabled = false;
                this.dateTimePickerOut_date1.Enabled = false;
                this.dateTimePickerOut_date2.Enabled = false;
            }
        }
        

        private void QueryOutTableForm_Load(object sender, EventArgs e)
        {
            setDataGridColumnName();
            setOut_ouList();
            setVip_ouList();

            this.comboBoxOut_acc.Items.Add(new util.ValueObject("", ""));
            this.comboBoxOut_acc.Items.Add(new util.ValueObject("0", "未做帐"));
            this.comboBoxOut_acc.Items.Add(new util.ValueObject("1", "已做帐"));

            this.comboBoxOut_acc.ValueMember = "value";
            this.comboBoxOut_acc.DisplayMember = "text";
            this.comboBoxOut_acc.SelectedIndex = 0;
        }

        #endregion






        #region 私有方法


        private void setDataGridColumnName()
        {
            this.dataGridView1.Columns["ColumnOut_scrpno"].DisplayIndex = 0;
            this.dataGridView1.Columns["ColumnOut_ou"].DisplayIndex = 1;
            this.dataGridView1.Columns["ColumnOut_date"].DisplayIndex = 2;
            this.dataGridView1.Columns["ColumnOut_cost"].DisplayIndex = 3;
            this.dataGridView1.Columns["ColumnVip_ou"].DisplayIndex = 4;
            this.dataGridView1.Columns["ColumnOut_acc"].DisplayIndex = 5;
            this.dataGridView1.Columns["ColumnOut_memo"].DisplayIndex = 6;
            this.dataGridView1.AutoGenerateColumns = false;

        }

        private OutTableInfo getOutTableInfoByOutScrpno(string out_scrpno)
        {
            OutTableInfo data = null;
            for (int i = 0; i < this.queryOutTableList.Count; i++)
            {
                if (this.queryOutTableList[i].Out_scrpno == out_scrpno)
                {
                    data = this.queryOutTableList[i];
                    break;
                }
            }
            return data;
        }

        //初始化请领单位
        private void setOut_ouList()
        {
            BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
            IList<OutInfoData> list = outInfoBll.GetAllOutInfo();
            IList<ValueObject> objList = new List<ValueObject>();
            objList.Add(new ValueObject("",""));
            for (int i = 0; i < list.Count; i++)
            {
                OutInfoData data = list[i];
                objList.Add(new ValueObject(data.Out_ou,data.Out_ou));
            }
            this.comboBoxOut_ou.DataSource = objList;
            this.comboBoxOut_ou.DisplayMember = "text";
            this.comboBoxOut_ou.ValueMember = "value";
        }

        //初始化赠送分类
        private void setVip_ouList()
        {
            BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();

            IList<VipInfoData> list = vipInfoBll.GetAllVipInfo();
            IList<ValueObject> objList = new List<ValueObject>();
            objList.Add(new ValueObject("", ""));
            for (int i = 0; i < list.Count; i++)
            {
                VipInfoData data = list[i];
                objList.Add(new ValueObject(data.Vip_ou, data.Vip_ou));
            }


            this.comboBoxVip_ou.DataSource = objList;
            this.comboBoxVip_ou.DisplayMember = "text";
            this.comboBoxVip_ou.ValueMember = "value";
        }


        #endregion




    }
}