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


        //�ֶ�
        private IList<OutTableInfo> queryOutTableList;

        public static QueryOutTableForm thisForm;


        public QueryOutTableForm()
        {
            InitializeComponent();
            thisForm = this;
        }


        #region �¼�
        
        
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
                //ƾ֤���
                if (this.txtOut_scrpno1.Text != "")
                {
                    if (this.checkBoxOut_scrpno.Checked)
                    {
                        if (this.txtOut_scrpno2.Text.Trim() == "")
                        {
                            MyMessageBox.ShowInfoMessageBox("ƾ֤��ŵ�����ѡ�ѡ�У���������ɵ�ƾ֤�����������");
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


                //��������
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


                //������
                if (this.txtOut_cost1.Text != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtOut_cost1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("����������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("����������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                //���쵥λ
                if (this.comboBoxOut_ou.Text != "")
                {
                    condition.Append(" and out_ou = '").Append(this.comboBoxOut_ou.Text.ToString().Trim()).Append("'");
                }



                //���ͷ���
                if (this.comboBoxVip_ou.Text != "")
                {
                    condition.Append(" and vip_ou = '").Append(this.comboBoxVip_ou.Text.ToString().Trim()).Append("'");
                }



                //����Ʒ��Ϣ
                if (this.txtPreInfo.Text != "")
                {
                    condition.Append(" and p_name like '%").Append(this.txtPreInfo.Text.Trim()).Append("%'");
                }



                //��ע
                if (this.txtOut_memo.Text != "")
                {
                    condition.Append(" and out_memo like '%").Append(this.txtOut_memo.Text.ToString().Trim()).Append("%'");
                }


                //�������
                if (this.comboBoxOut_acc.SelectedIndex >= 0)
                {
                    if (((util.ValueObject)this.comboBoxOut_acc.SelectedItem).Value.ToString() != "")
                    {
                        condition.Append(" and out_acc = ").Append(((util.ValueObject)this.comboBoxOut_acc.SelectedItem).Value.ToString()).Append(" ");
                    }
                }


                //��ѯ
                this.queryOutTableList = new BLL.OutTable().GetOutTableByCondition(condition.ToString());
                this.dataGridView1.DataSource = this.queryOutTableList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����������ѯ�¼�",ex);
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
                MyMessageBox.ShowErrorMessageBox("����ȫ����ѯ�¼�", ex);
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
                MyMessageBox.ShowErrorMessageBox("�����ѯ�鿴��ϸ�¼�", ex);
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
            this.comboBoxOut_acc.Items.Add(new util.ValueObject("0", "δ����"));
            this.comboBoxOut_acc.Items.Add(new util.ValueObject("1", "������"));

            this.comboBoxOut_acc.ValueMember = "value";
            this.comboBoxOut_acc.DisplayMember = "text";
            this.comboBoxOut_acc.SelectedIndex = 0;
        }

        #endregion






        #region ˽�з���


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

        //��ʼ�����쵥λ
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

        //��ʼ�����ͷ���
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