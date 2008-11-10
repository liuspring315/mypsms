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


        #region �¼�
        
        

        private void QueryPreInfoForm_Load(object sender, EventArgs e)
        {
            setDataGridColumnName();
            IList<PreInfoData> preInfoList = new BLL.PreInfo().GetAllPreInfo();
            this.comboBoxP_no.DataSource = preInfoList;
            this.comboBoxP_no.DisplayMember = "p_no";
            this.comboBoxP_no.ValueMember = "p_no";
            this.dataGridView1.DataSource = preInfoList;
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
                //����
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
                        MessageBox.Show("���������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MyMessageBox.ShowErrorMessageBox("�������ѯ",ex);
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
            try
            {
                this.txtP_no.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridView1, "ColumnP_no").Trim();
                this.txtP_name.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridView1, "ColumnP_name").Trim();
                this.txt_qnt.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridView1, "ColumnAcc_qnt").Trim();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�������ѯ", ex);
            }
        
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder condition = new StringBuilder();
                //����Ʒ���
                if (this.comboBoxP_no.Text.Trim() != "")
                {
                    condition.Append(" and p_no like '%").Append(this.comboBoxP_no.Text.Trim()).Append("%' ");
                }

                //���ۼ�
                if (this.txtUnit_price1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnit_price1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("���ۼ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("���ۼ�����������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //�ɱ���
                if (this.txtCost_price1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCost_price1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("�ɱ�������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("�ɱ�������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //�����
                if (this.txtQnt1.Text != "")
                {
                    try
                    {
                        Int32.Parse(this.txtQnt1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("���������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("���������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                //��ѯ
                this.dataGridView1.DataSource = new BLL.PreInfo().GetPreInfoByCondition(condition.ToString());
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�������ѯ", ex);
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
                MyMessageBox.ShowErrorMessageBox("�������ѯ", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region ˽�з���
        private void setDataGridColumnName()
        {
            this.dataGridView1.Columns["ColumnP_no"].DisplayIndex = 0;
            this.dataGridView1.Columns["ColumnP_name"].DisplayIndex = 1;
            this.dataGridView1.Columns["ColumnUnit"].DisplayIndex = 2;
            this.dataGridView1.Columns["ColumnUnit_price"].DisplayIndex = 3;
            this.dataGridView1.Columns["ColumnCost_price"].DisplayIndex = 4;
            this.dataGridView1.Columns["ColumnAcc_qnt"].DisplayIndex = 5;
            this.dataGridView1.AutoGenerateColumns = false;

        }


        #endregion

        private void btnResetQnt_Click(object sender, EventArgs e)
        {
            try
            {
                string pno = this.txtP_no.Text.Trim();
                if (pno == "")
                {
                    MessageBox.Show("��ѡ��һ������Ʒ","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }

                string out_scrpno = "reset_" + pno;
                DateTime out_date = DateTime.Now;
                decimal unit_price = decimal.Parse(util.DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridView1, "ColumnUnit_price").Trim());
                int qnt = Int32.Parse(util.DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridView1, "ColumnAcc_qnt").Trim());

                if (qnt == 0)
                {
                    MessageBox.Show("��ѡ����Ʒ�Ŀ���Ѿ�Ϊ�㣬��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                decimal out_cost = unit_price * qnt;
                string out_ou = "�������";
                string vip_ou = "�������";
                string out_memo = "����������ɵĳ���ƾ֤";
                if (MessageBox.Show("ȷ�������棿", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //string out_scrpno, string out_ou, string out_date, decimal out_cost, string vip_ou,
                    //int out_acc,string out_memo
                    OutTableInfo aOutTableInfo = new OutTableInfo(out_scrpno, out_ou, out_date, out_cost, vip_ou, 0, out_memo);
                    BindingList<OutScrpInfo> outScrpList = new BindingList<OutScrpInfo>();
                    OutScrpInfo outScrp = new OutScrpInfo(0, out_scrpno, pno, qnt, out_cost);
                    outScrpList.Add(outScrp);
                    aOutTableInfo.OutScrpList = outScrpList;
                    if (new BLL.OutTable().insertOutTable(aOutTableInfo))
                    {
                        MessageBox.Show("������ɹ���ϵͳ�Զ�������һ��ƾ֤���Ϊ" + out_scrpno + "�ĳ���ƾ֤", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�������ѯ", ex);
            }

        }


    }
}