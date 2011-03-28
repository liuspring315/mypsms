using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.util;
using psms.Model;

namespace psms
{
    public partial class QueryPreInfoForm : Form
    {

        public QueryPreInfoForm()
        {
            InitializeComponent();
        }

        private void QueryPreInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }


        #region 事件
        
        

        private void QueryPreInfoForm_Load(object sender, EventArgs e)
        {
            setDataGridColumnName();
            IList<PreInfoData> preInfoList = (new BLL.PreInfo().GetAllPreInfo());
            preInfoList.Insert(0, new PreInfoData("", "", 0));
            this.comboBoxP_no.DataSource = preInfoList;
            this.comboBoxP_no.DisplayMember = "p_no";
            this.comboBoxP_no.ValueMember = "p_no";
            this.dataGridView1.DataSource = new BLL.PreInfo().GetAllPreInfo();
            //初始化宣传品系列下拉列表
            BindingList < PreTypeInfo >  data = new BLL.PreType().GetAllPreTypeInfo();
            data.Add(new PreTypeInfo(0,""));
            this.cobPreType.DataSource = data;
            this.cobPreType.DisplayMember = "typeName";
            this.cobPreType.ValueMember = "typeName";
            this.cobPreType.SelectedIndex = data.Count - 1;
        }

        private void checkBoxUnti_price_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxUnti_price.Checked)
            {
                this.txtUnit_price2.Visible = true;
            }
            else
            {
                this.txtUnit_price2.Visible = false;
            }
        }

        private void checkBoxCost_price_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxCost_price.Checked)
            {
                this.txtCost_price2.Visible = true;
            }
            else
            {
                this.txtCost_price2.Visible = false;
            }
        }

        private void checkBoxQnt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxQnt.Checked)
            {
                this.txtQnt2.Visible = true;
            }
            else
            {
                this.txtQnt2.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.btnSave.Visible = true;
            this.btnCancel.Visible = true;
            this.txt_qnt.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //保存
                string pno = this.txtP_no.Text.Trim();
                if (pno != "")
                {
                    int accQnt = 0;
                    try
                    {
                        accQnt = Int32.Parse(this.txt_qnt.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("库存量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    new BLL.PreInfo().updatePreInfoAccQnt(pno, accQnt);
                    btnCancel_Click(sender, e);
                    IList<PreInfoData> preInfoList = new BLL.PreInfo().GetAllPreInfo();
                    this.comboBoxP_no.DataSource = preInfoList;
                    this.comboBoxP_no.DisplayMember = "p_no";
                    this.comboBoxP_no.ValueMember = "p_no";
                    this.dataGridView1.DataSource = preInfoList;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("库存量查询",ex);
            }

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnSave.Visible = false;
            this.btnCancel.Visible = false;
            this.txt_qnt.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder condition = new StringBuilder();
                //宣传品编号
                if (this.comboBoxP_no.Text.Trim() != "")
                {
                    condition.Append(" and p_no like '%").Append(this.comboBoxP_no.Text.Trim()).Append("%' ");
                }
                if (this.cobPreType.Text.Trim() != "")
                {
                    condition.Append(" and pretype = '").Append(this.cobPreType.Text.Trim()).Append("' ");
                }

                //销售价
                if (this.txtUnit_price1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnit_price1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("销售价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxUnti_price.Checked)
                    {
                        try
                        {
                            Decimal.Parse(this.txtUnit_price2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("销售价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and unit_price >= ").Append(this.txtUnit_price1.Text.Trim());
                        condition.Append(" and unit_price <= ").Append(this.txtUnit_price2.Text.Trim());
                    }
                    else
                    {
                        condition.Append(" and unit_price = ").Append(this.txtUnit_price1.Text.Trim());
                    }
                }

                //成本价
                if (this.txtCost_price1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCost_price1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("成本价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxCost_price.Checked)
                    {
                        try
                        {
                            Decimal.Parse(this.txtCost_price2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("成本价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and cost_price >= ").Append(this.txtCost_price1.Text.Trim());
                        condition.Append(" and cost_price <= ").Append(this.txtCost_price2.Text.Trim());
                    }
                    else
                    {
                        condition.Append(" and cost_price = ").Append(this.txtCost_price1.Text.Trim());
                    }
                }

                //库存量
                if (this.txtQnt1.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtQnt1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("库存量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.checkBoxQnt.Checked)
                    {
                        try
                        {
                            Int32.Parse(this.txtQnt2.Text.Trim());
                        }
                        catch
                        {
                            MessageBox.Show("库存量请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        condition.Append(" and acc_qnt >= ").Append(this.txtQnt1.Text.Trim());
                        condition.Append(" and acc_qnt <= ").Append(this.txtQnt2.Text.Trim());
                    }
                    else
                    {
                        condition.Append(" and acc_qnt = ").Append(this.txtQnt1.Text.Trim());
                    }
                }


                //查询
                this.dataGridView1.DataSource = new BLL.PreInfo().GetPreInfoByCondition(condition.ToString());
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("库存量查询", ex);
            }

        }

        private void btnAllQuery_Click(object sender, EventArgs e)
        {
            try
            {
                IList<PreInfoData> preInfoList = new BLL.PreInfo().GetAllPreInfo();
                this.dataGridView1.DataSource = preInfoList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("库存量查询", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region 私有方法
        private void setDataGridColumnName()
        {
            this.dataGridView1.Columns["ColChckBox"].DisplayIndex = 0;
            this.dataGridView1.Columns["ColumnP_no"].DisplayIndex = 1;
            this.dataGridView1.Columns["ColumnPretype"].DisplayIndex = 2;
            this.dataGridView1.Columns["ColumnP_name"].DisplayIndex = 3;
            this.dataGridView1.Columns["ColumnUnit"].DisplayIndex = 4;
            this.dataGridView1.Columns["ColumnUnit_price"].DisplayIndex = 5;
            this.dataGridView1.Columns["ColumnCost_price"].DisplayIndex = 6;
            this.dataGridView1.Columns["ColumnAcc_qnt"].DisplayIndex = 7;
            this.dataGridView1.AutoGenerateColumns = false;

        }


        #endregion

        private void btnResetQnt_Click(object sender, EventArgs e)
        {
            DateTime out_date = DateTime.Now;
            string out_scrpno = StrUtil.Next(new BLL.OutTable().GetTopOutScrpNo());
            string out_ou = "库存清零";
            string vip_ou = "库存清零";
            string out_memo = "库存清零生成的出库凭证";
            decimal outTableCast = 0;
            BindingList<OutScrpInfo> outScrpList = new BindingList<OutScrpInfo>();
            try
            {
                foreach (DataGridViewRow dgR in this.dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgR.Cells["ColChckBox"];
                    if ((bool)cbx.FormattedValue)
                    {
                        string pno = dgR.Cells["ColumnP_no"].Value.ToString().Trim();
                        decimal unit_price = decimal.Parse(dgR.Cells["ColumnUnit_price"].Value.ToString().Trim());
                        int qnt = Int32.Parse(dgR.Cells["ColumnAcc_qnt"].Value.ToString().Trim());

                        if (qnt == 0)
                        {
                            MessageBox.Show("'" + dgR.Cells["ColumnP_name"].Value.ToString().Trim() + "'的库存已经为零，无需清零，请取消选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgR.Selected = true;
                            dataGridView1.CurrentCell = dgR.Cells[0];
                            return;
                        }
                        decimal out_cost = unit_price * qnt;
                        outTableCast = outTableCast + out_cost;
                        OutScrpInfo outScrp = new OutScrpInfo(0, out_scrpno, pno, qnt, out_cost);
                        outScrpList.Add(outScrp);
                    }
                }
                if (outScrpList.Count == 0)
                {
                    MessageBox.Show("请选择要清零的油品", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("确认清零" + outScrpList.Count + "个选中邮品的库存？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //string out_scrpno, string out_ou, string out_date, decimal out_cost, string vip_ou,
                    //int out_acc,string out_memo

                    OutTableInfo aOutTableInfo = new OutTableInfo(out_scrpno, out_ou, out_date, outTableCast, vip_ou, 0, out_memo);
                    aOutTableInfo.OutScrpList = outScrpList;
                    
                    
                    if (new BLL.OutTable().insertOutTable(aOutTableInfo))
                    {
                        MessageBox.Show("清零库存成功，系统自动生成了一个凭证编号为" + out_scrpno + "的出库凭证", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("库存量查询", ex);
            }

        }


        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgR in this.dataGridView1.Rows)
            {
                try
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgR.Cells[0];
                    cbx.Value = true;

                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowErrorMessageBox("全选", ex);
                }


            }
        }



    }
}