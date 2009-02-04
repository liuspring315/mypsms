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
    public partial class QueryInTableForm : Form
    {
        //�ֶ�
        private IList<InTableInfo> queryInTableList;

        public static QueryInTableForm thisForm;

        //���캯��
        public QueryInTableForm()
        {
            InitializeComponent();
            thisForm = this;
        }

        //���ڹرպ�
        private void QueryInTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        //������������
        private void checkBoxIn_Cost_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtIn_Cost2.Visible = true;
            }
            else
            {
                this.txtIn_Cost2.Visible = false;
            }
        }

        //����������
        private void checkBoxIn_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtIn_Date2.Visible = true;
            }
            else
            {
                this.txtIn_Date2.Visible = false;
            }
        }

        //��ƾ֤�������
        private void checkBoxIn_scpno_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtIn_scrpno2.Visible = true;
            }
            else
            {
                this.txtIn_scrpno2.Visible = false;
            }
        }

        //�˳�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //������ѯ
        private void btnConditionQuery_Click(object sender, EventArgs e)
        {
            StringBuilder condition = new StringBuilder();
            //ƾ֤���
            if (this.txtIn_scrpno1.Text.Trim() != "")
            {

                if (this.checkBoxIn_scpno.Checked)
                {
                    if (this.txtIn_scrpno2.Text.Trim() == "")
                    {
                        MyMessageBox.ShowInfoMessageBox("ƾ֤��ŵ�����ѡ�ѡ�У���������ɵ�ƾ֤�����������");
                        return;
                    }
                    condition.Append(" and i.in_scrpno >='").Append(this.txtIn_scrpno1.Text.Trim()).Append("' ");
                    condition.Append(" and i.in_scrpno <='").Append(this.txtIn_scrpno2.Text.Trim()).Append("' ");
                }
                else
                {
                    condition.Append(" and i.in_scrpno like '%").Append(this.txtIn_scrpno1.Text.Trim()).Append("%' ");
                }
            }

            //�������
            if (this.checkBoxConditionDate.Checked)
            {
                if (this.checkBoxIn_Date.Checked)
                {
                    //if (this.txtIn_Date2.Value.Trim() == "")
                    //{
                    //    MyMessageBox.ShowInfoMessageBox("������ڵ�����ѡ�ѡ�У���������ɵ����������������");
                    //    return;
                    //}
                    condition.Append(" and in_date >= '").Append(this.txtIn_Date1.Value.ToShortDateString()).Append(" 00:00:00.000' ");
                    condition.Append(" and in_date <= '").Append(this.txtIn_Date2.Value.ToShortDateString()).Append(" 23:59:59.990' ");
                }
                else
                {
                    condition.Append(" and in_date >= '").Append(this.txtIn_Date1.Value.ToShortDateString()).Append(" 00:00:00.000' ");
                    condition.Append(" and in_date <= '").Append(this.txtIn_Date1.Value.ToShortDateString()).Append(" 23:59:59.990' ");
                }
            }

            //������
            if (this.txtIn_Cost1.Text.Trim() != "")
            {
                try
                {
                    Decimal.Parse(this.txtIn_Cost1.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("����������������","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (this.checkBoxIn_Cost.Checked)
                {
                    try
                    {
                        Decimal.Parse(this.txtIn_Cost2.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("����������������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and in_cost >= ").Append(this.txtIn_Cost1.Text.Trim());
                    condition.Append(" and in_cost <= ").Append(this.txtIn_Cost2.Text.Trim());
                }
                else
                {
                    condition.Append(" and in_cost = ").Append(this.txtIn_Cost1.Text.Trim());
                }
            }

            //��Դ
            if (this.combIn_ou.Text.ToString() != "")
            {
                condition.Append(" and in_ou = '").Append(this.combIn_ou.Text.ToString().Trim()).Append("'");
            }

            //����Ʒ��Ϣ
            if (this.txtPreInfo.Text != "")
            {
                condition.Append(" and p_name like '%").Append(this.txtPreInfo.Text.Trim()).Append("%'");
            }

            //��ע
            if (this.txtIn_memo.Text.Trim() != "")
            {
                condition.Append(" and in_memo like '%").Append(this.txtIn_memo.Text.Trim()).Append("%' ") ;
            }

            //�������
            if (this.combIn_Acc.SelectedIndex >= 0)
            {
                if (((util.ValueObject)this.combIn_Acc.SelectedItem).Value.ToString() != "")
                {
                    condition.Append(" and in_acc = ").Append(((util.ValueObject)this.combIn_Acc.SelectedItem).Value.ToString()).Append(" ");
                }
            }
            //�ƻ�
            if (this.comboBoxPlanIn.Text.Trim() != "")
            {
                condition.Append(" and PLANIN = '").Append(this.comboBoxPlanIn.Text.Trim()).Append("' ");
            }
            //ȷ�����
            if (this.comboBoxGooded.SelectedIndex >= 0)
            {
                if (((util.ValueObject)this.comboBoxGooded.SelectedItem).Value.ToString() != "")
                {
                    condition.Append(" and goodsacc = ").Append(((util.ValueObject)this.comboBoxGooded.SelectedItem).Value.ToString()).Append(" ");
                }
            }
            //����������
            if (this.txtGoodNo.Text.Trim() != "")
            {
                condition.Append(" and billno = '").Append(this.txtGoodNo.Text.Trim()).Append("' ");
            }
            //ִ�в�ѯ
            try
            {
                this.queryInTableList = new BLL.InTable().GetInTableByCondition(condition.ToString());
                this.dataGridViewQueryInTable.DataSource = queryInTableList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ѯ����", ex); 
                
            }

        }

        //ȫ����ѯ
        private void btnAllQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.queryInTableList = new BLL.InTable().GetInTableByCondition("");
                this.dataGridViewQueryInTable.DataSource = queryInTableList;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ѯ����", ex); 
                
            }
        }

        //�Ƿ����ڲ�
        private void checkBoxConditionDate_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.checkBoxIn_Date.Enabled  = true;
                this.txtIn_Date1.Enabled = true;
                this.txtIn_Date2.Enabled = true;
            }
            else
            {
                this.checkBoxIn_Date.Enabled = false;
                this.txtIn_Date1.Enabled = false;
                this.txtIn_Date2.Enabled = false;
            }
        }

        //����DateGridViewʱ
        private void dataGridViewQueryInTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridViewQueryInTable.Columns[e.ColumnIndex].Name == "queryButton")
                {
                    string in_scrpno = this.dataGridViewQueryInTable.Rows[e.RowIndex].Cells["ColumnIn_scrpno"].Value.ToString().Trim();
                    InTableInfo data = getInTableInfoByInScrpno(in_scrpno);
                    if (data != null)
                    {
                        UpdateInTableForm updateForm = new UpdateInTableForm(data);
                        updateForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ѯ����", ex); 
                
            }
        }


        private void setDataGridColumnName()
        {
            this.dataGridViewQueryInTable.Columns["ColumnIn_scrpno"].DisplayIndex = 0;
            this.dataGridViewQueryInTable.Columns["ColumnBillno"].DisplayIndex = 1;
            this.dataGridViewQueryInTable.Columns["ColumnPlanin"].DisplayIndex = 2;
            this.dataGridViewQueryInTable.Columns["ColumnIn_cost"].DisplayIndex = 3;
            this.dataGridViewQueryInTable.Columns["ColumnIn_date"].DisplayIndex = 4;
            this.dataGridViewQueryInTable.Columns["ColumnIn_ou"].DisplayIndex = 5;
            this.dataGridViewQueryInTable.Columns["ColumnIn_acc"].DisplayIndex = 6;
            this.dataGridViewQueryInTable.Columns["ColumnGoodacc"].DisplayIndex = 7;
            this.dataGridViewQueryInTable.Columns["ColumnIn_memo"].DisplayIndex = 8;
            this.dataGridViewQueryInTable.AutoGenerateColumns = false;

        }

        private void QueryInTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                setDataGridColumnName();
                setIn_OuList();

                this.combIn_Acc.Items.Add(new util.ValueObject("", ""));
                this.combIn_Acc.Items.Add(new util.ValueObject("0", "δ����"));
                this.combIn_Acc.Items.Add(new util.ValueObject("1", "������"));

                this.combIn_Acc.ValueMember = "value";
                this.combIn_Acc.DisplayMember = "text";
                this.combIn_Acc.SelectedIndex = 0;

                this.comboBoxGooded.Items.Add(new util.ValueObject("", ""));
                this.comboBoxGooded.Items.Add(new util.ValueObject("0", "δȷ��"));
                this.comboBoxGooded.Items.Add(new util.ValueObject("1", "��ȷ��"));

                this.comboBoxGooded.ValueMember = "value";
                this.comboBoxGooded.DisplayMember = "text";
                this.comboBoxGooded.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ѯ����", ex);
            }
        }


        //��ʼ����Դ
        private void setIn_OuList()
        {
            BLL.InInfo ininfo = new psms.BLL.InInfo();
            
            IList<InInfoData> list = ininfo.GetAllInInfo();
            IList<util.ValueObject> obj = new List<util.ValueObject>();
            obj.Add(new util.ValueObject("", ""));
            for (int i = 0; i < list.Count; i++)
            {
                InInfoData data = list[i];
                obj.Add(new util.ValueObject(data.In_ou, data.In_ou));
            }

            this.combIn_ou.DataSource = obj;
            this.combIn_ou.ValueMember = "value";
            this.combIn_ou.DisplayMember = "text";
            this.combIn_ou.SelectedIndex = 0;


        }

        private InTableInfo getInTableInfoByInScrpno(string in_scrpno)
        {
            InTableInfo data = null;
            for (int i = 0; i < this.queryInTableList.Count; i++)
            {
                if (this.queryInTableList[i].In_scrpno == in_scrpno)
                {
                    data =  this.queryInTableList[i];
                    break;
                }
            }
            return data;
        }







    }
}