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
    public partial class UpdateInTableForm : Form
    {

        #region ˽���ֶ�
        
        #endregion
        private System.ComponentModel.BindingList<InScrpInfo> inScrpList = null;
        private System.ComponentModel.BindingList<InScrpInfo> newInScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        //���ƾ֤List
        private IList<InTableInfo> inTableList = null;
        //����
        private int index = 0;
        //���м�¼��
        private int count = 1;

        //ת����ѯ���ڱ�ʶ
        private bool showMain = true;
        
        public UpdateInTableForm()
        {
            InitializeComponent();
        }

        public UpdateInTableForm(InTableInfo data)
        {
            InitializeComponent();
            this.showMain = false;
            this.inTableList = new List<InTableInfo>();
            this.inTableList.Add(data);
            this.btnPrv.Enabled = false;
            this.btnOne.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
        }

        private void UpdateInTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (showMain)
            {
                MainForm.mainForm.Show();
                
            }
            else
            {
                if (QueryInTableForm.thisForm != null)
                {
                    QueryInTableForm.thisForm.Show();
                }
            }
        }

        private void UpdateInTableForm_Load(object sender, EventArgs e)
        { 
            try
            {
                setIn_OuList();
                setDataGridColumnName();
                setP_noList(this.lbInTable_P_no);

                if (this.inTableList == null)
                {
                    this.inTableList = new BLL.InTable().GetAllInTable();
                }
                count = this.inTableList.Count;
                setGroupUpdateIntableText();
                if(count > 0)
                    setTextByIntableInfo();
                if (count > 1)
                {
                    this.btnPrv.Enabled = false;
                    this.btnOne.Enabled = false;
                }
                else
                {
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ƾ֤�޸Ĵ��ڼ���",ex);
            }
        }

        //��ʼ������Ʒ���ListBox
        private void setP_noList(ListBox listBox)
        {
            BLL.PreInfo preInfo = new psms.BLL.PreInfo();
            preInfoList = preInfo.GetAllPreInfo();
            listBox.DataSource = preInfoList;
            listBox.DisplayMember = "p_no";
            listBox.ValueMember = "p_no";

        }

        //����ҳ��textBoxֵ
        private void setTextByIntableInfo()
        {
            InTableInfo data = this.inTableList[index];
            this.txtInTableIn_Scrpno.Text = data.In_scrpno;
            this.cobInTable_PlanIn.Text = data.Planin==null?"":data.Planin;
            this.cobInTableIn_Ou.Text = data.In_ou;
            this.cobInTableIn_Date.Value = data.In_date;
            this.txtInTable_Billno.Text = data.Billno==null?"":data.Billno;
            this.txtInTableIn_Cost.Text = data.In_cost.ToString();
            this.txtInTableIn_Memo.Text = data.In_memo;

            if (data.In_acc == 0)
            {
                //this.labAcc.Text = "δ����";
                this.btnInTable_addPreInfo.Enabled = true;
                this.btnInTable_NextTable.Enabled = true;
                this.btnInTable_SaveAndExit.Enabled = true;
            }
            else
            {
                //this.labAcc.Text = "������";
                this.btnInTable_addPreInfo.Enabled = true;
                this.btnInTable_NextTable.Enabled = true;
                this.btnInTable_SaveAndExit.Enabled = true;
            }
            if (data.GoodAcc == 0)
            {
                this.labGoodAcc.Text = "δȷ�����";
                this.btnGoodAcc.Enabled = true;
            }
            else
            {
                this.labGoodAcc.Text = "��ȷ�����";
                this.btnGoodAcc.Enabled = false;
            }
            //��ʼ����Ӧ����Ʒ

            IList<InScrpInfo> list = new BLL.InScrp().GetInScrpByInScrpno(data.In_scrpno);
            this.inScrpList = new BindingList<InScrpInfo>();
            this.newInScrpList = new BindingList<InScrpInfo>();
            for(int i = 0; i < list.Count;i++)
            {
                this.inScrpList.Add(list[i]);
                newInScrpList.Add(list[i]);
            }

            this.dataGridViewIntable_PreInfoList.DataSource = newInScrpList;
        }

        private void setDataGridColumnName()
        {
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnIN_SCRPNO"].DisplayIndex = 0;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnP_no"].DisplayIndex = 1;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnP_name"].DisplayIndex = 2;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnUnit"].DisplayIndex = 3;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnUnit_price"].DisplayIndex = 4;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnCost_price"].DisplayIndex = 5;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnQnt"].DisplayIndex = 6;
            this.dataGridViewIntable_PreInfoList.Columns["dataGridViewTextBoxColumnIn_price"].DisplayIndex = 7;
            this.dataGridViewIntable_PreInfoList.Columns["Id"].Visible = false;
            this.dataGridViewIntable_PreInfoList.AutoGenerateColumns = false;

        }

        //��ʼ����Դ
        private void setIn_OuList()
        {
            BLL.InInfo ininfo = new psms.BLL.InInfo();
            this.cobInTableIn_Ou.DataSource = ininfo.GetAllInInfo();
            this.cobInTableIn_Ou.DisplayMember = "in_ou";
            this.cobInTableIn_Ou.ValueMember = "in_ou";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            try
            {
                index = 0;
                setTextByIntableInfo();
                this.btnPrv.Enabled = false;
                this.btnOne.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                setGroupUpdateIntableText();
            }
            catch 
            {
                MyMessageBox.ShowInfoMessageBox("û����");
            }
        }

        private void btnPrv_Click(object sender, EventArgs e)
        {
            try
            {
                index = index - 1;
                setTextByIntableInfo();

                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                if (this.index == 0)
                {
                    this.btnPrv.Enabled = false;
                    this.btnOne.Enabled = false;
                }
                setGroupUpdateIntableText();
            }
            catch 
            {
                MyMessageBox.ShowInfoMessageBox("û����");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                index = index + 1;
                setTextByIntableInfo();
                setGroupUpdateIntableText();

                this.btnPrv.Enabled = true;
                this.btnOne.Enabled = true;
                if (this.index == count - 1)
                {
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                }
            }
            catch 
            {
                MyMessageBox.ShowInfoMessageBox("û����");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                index = count - 1;
                setTextByIntableInfo();
                setGroupUpdateIntableText();
                this.btnPrv.Enabled = true;
                this.btnOne.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            catch 
            {
                MyMessageBox.ShowInfoMessageBox("û����");
            }
        }

        private void setGroupUpdateIntableText()
        {
            this.groupBoxUpdateIntable.Text = "ƾ֤��Ϣ   ��ǰ��" + (index + 1) + "�������м�¼��" + count;
        }



        private bool messageBoxReturn()
        {
            string message = "";
            for (int inScrpList_count = 0; inScrpList_count < inScrpList.Count; inScrpList_count++)
            {
                InScrpInfo oldData = inScrpList[inScrpList_count];
                bool haveNew = false;
                for (int newInScrpList_count = 0; newInScrpList_count < newInScrpList.Count; newInScrpList_count++)
                {
                    InScrpInfo newData = newInScrpList[newInScrpList_count];
                    if (oldData.P_no == newData.P_no)
                    {
                        haveNew = true;
                        message = message + "����Ʒ��ţ�" + oldData.P_no + "��ԭ�������Ϊ" + oldData.Qnt + "���޸ĺ��������Ϊ" + newData.Qnt + "\n";
                    }
                }
                if (!haveNew)
                {
                    message += "����Ʒ��ţ�" + oldData.P_no + "��ԭ�������Ϊ" + oldData.Qnt + "��ɾ��\n";
                }

            }
            for (int newInScrpList_count = 0; newInScrpList_count < newInScrpList.Count; newInScrpList_count++)
            {
                bool haveOld = false;
                InScrpInfo newData = newInScrpList[newInScrpList_count];
                for (int inScrpList_count = 0; inScrpList_count < inScrpList.Count; inScrpList_count++)
                {
                    
                    InScrpInfo oldData = inScrpList[inScrpList_count];
                    if (oldData.P_no == newData.P_no)
                    {
                        haveOld = true;
                    }
                }
                if (!haveOld)
                {
                    message += "����Ʒ��ţ�" + newData.P_no + "���������Ϊ" + newData.Qnt + "������\n";
                }
            }
            if (message == "")
            {
                MyMessageBox.ShowInfoMessageBox("����û�ж�ԭ�������޸ģ����޸ĺ��ٵ�����水ť");
                return false;
            }
            if (MessageBox.Show(message, "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        //����
        private bool updateInTableInfo()
        {
            
            //����ƾ֤-duixiang
            string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
            string planin = this.cobInTable_PlanIn.Text.ToString();
            string in_ou = this.cobInTableIn_Ou.Text.ToString();
            DateTime in_date = this.cobInTableIn_Date.Value;
            string billno = this.txtInTable_Billno.Text.Trim();
            decimal in_cost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
            string in_memo = this.txtInTableIn_Memo.Text.Trim();
            //(string in_scrpno, string billno, string in_ou,System.DateTime in_date ,decimal in_cost, string planin,
            //int goodsAcc,int in_acc,string in_memo)
            InTableInfo aInTableInfoaInTableInfo = new InTableInfo(in_scrpno, billno, in_ou, in_date, in_cost, planin, 0, 0, in_memo);
            aInTableInfoaInTableInfo.InScrpList = this.newInScrpList;
            return new BLL.InTable().updateInTable(aInTableInfoaInTableInfo);


        }

        private void btnInTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "������")
                //{
                //    MessageBox.Show("������ƾ֤�����޸�", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //else
               // {
                    if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                    {
                        MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //����
                    if (messageBoxReturn())
                    {
                        if (updateInTableInfo())
                        {
                            MessageBox.Show("�޸����ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inScrpList = newInScrpList;
                        }
                        else
                        {
                            MessageBox.Show("�޸����ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.Close();
                    }
               // }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸����ƾ֤", ex);
            }
        }

        private void btnInTable_NextTable_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "������")
                //{
                //    MessageBox.Show("������ƾ֤�����޸�", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //����

                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (messageBoxReturn())
                {
                    if (updateInTableInfo())
                    {
                        MessageBox.Show("�޸����ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inScrpList = newInScrpList;
                    }
                    else
                    {
                        MessageBox.Show("�޸����ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //inScrpList = null;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸����ƾ֤", ex);
            }
        }

        private void btnInTable_addPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInTable_Unit_Price.Text == "")
                {
                    MessageBox.Show("����ѡ������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.errorProvider.SetError(this.txtInTable_P_no, "����ѡ������Ʒ");
                    return;
                }
                this.errorProvider.SetError(this.txtInTable_P_no, "");
                //����ƾ֤������
                int qntTxt = 0;
                decimal unit_priceTxt = 0;
                decimal in_price = 0;
                try
                {
                    qntTxt = Int32.Parse(this.txtInTable_Qnt.Text.Trim());
                    unit_priceTxt = decimal.Parse(this.txtInTable_Unit_Price.Text.Trim());
                    in_price = unit_priceTxt * qntTxt;
                    this.txtInTableIn_Cost.Text = (in_price + decimal.Parse(this.txtInTableIn_Cost.Text.Trim())).ToString();
                }
                catch
                {
                    MessageBox.Show("��������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.errorProvider.SetError(this.txtInTable_Qnt, "��������������");
                    return;
                }
                this.errorProvider.SetError(this.txtInTable_Qnt, "");

                //�������������Ʒ
                string p_no = this.txtInTable_P_no.Text.Trim();

                bool findpno = false;
                for (int i = 0; i < newInScrpList.Count; i++)
                {
                    if (newInScrpList[i].P_no == p_no)
                    {
                        findpno = true;
                        break;
                    }
                }
                if (findpno)
                {
                    MessageBox.Show("���������Ʒ���Ϊ" + p_no + "�벻Ҫ�ظ����", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.errorProvider.SetError(this.txtInTable_P_no, "���������Ʒ���Ϊ" + p_no + "�벻Ҫ�ظ����");
                    return;
                }
                this.errorProvider.SetError(this.txtInTable_P_no, "");


                string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
                string pname = this.txtInTable_P_Name.Text.Trim();
                string unit = this.txtInTable_unit.Text.Trim();
                decimal unitprice = decimal.Parse(this.txtInTable_Unit_Price.Text.Trim());
                decimal costprice = decimal.Parse(this.txtInTableCost_price.Text.Trim());
                InScrpInfo data = new InScrpInfo(inScrpList.Count, in_scrpno, p_no, pname, unit, unitprice, costprice, qntTxt, in_price);
                newInScrpList.Add(data);
                //���°�ƾ֤��������Ʒ�б�
                this.dataGridViewIntable_PreInfoList.DataSource = newInScrpList;
                this.txtInTable_P_no.Text = "";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸����ƾ֤", ex);
            }

        }

        private void dataGridViewIntable_PreInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridViewIntable_PreInfoList.Columns[e.ColumnIndex].Name == "deleteColumn")
                {
                    int id = Int32.Parse(this.dataGridViewIntable_PreInfoList.Rows[e.RowIndex].Cells["Id"].Value.ToString().Trim());
                    for (int i = 0; i < inScrpList.Count; i++)
                    {
                        InScrpInfo data = inScrpList[i];
                        if (data.Id == id)
                        {
                            //���б����Ƴ�
                            newInScrpList.Remove(data);
                            //���¼���ƾ֤������
                            decimal incost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
                            this.txtInTableIn_Cost.Text = (incost - data.In_price).ToString();
                            break;
                        }
                    }
                    //
                    //���°�ƾ֤��������Ʒ�б�
                    this.dataGridViewIntable_PreInfoList.DataSource = newInScrpList;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸����ƾ֤", ex);
            }
        }

        private void lbInTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtInTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString();
        }

        private void txtInTable_P_no_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //���������б�
                string pno = this.txtInTable_P_no.Text.Trim();
                this.lbInTable_P_no.DataSource = queryPreInfoListbyPno(pno);
                this.lbInTable_P_no.DisplayMember = "p_no";
                this.lbInTable_P_no.ValueMember = "p_no";
                //����TextBox
                setPreInfoTextValue(pno);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸����ƾ֤", ex);
            }
        }


        //��ѯListBox
        private IList<PreInfoData> queryPreInfoListbyPno(string txtpno)
        {
            if (txtpno == "")
                return this.preInfoList;
            IList<PreInfoData> returnList = new List<PreInfoData>();
            for (int i = 0; i < this.preInfoList.Count; i++)
            {
                PreInfoData data = this.preInfoList[i];
                string pno = data.P_no;
                if (pno.Contains(txtpno))
                {
                    returnList.Add(data);
                }
            }
            return returnList;
        }

        //����p_noָ��TextBox��ֵ
        private void setPreInfoTextValue(string txtpno)
        {
            if (txtpno == "")
            {
                setPreInfoTextBoxValueFromProInfo(null);
            }
            else
            {
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string pno = data.P_no;
                    if (pno.Trim() == txtpno.Trim())
                    {
                        setPreInfoTextBoxValueFromProInfo(data);
                        break;
                    }
                }
            }

        }



        //��������Ʒ�ı���ֵ
        private void setPreInfoTextBoxValueFromProInfo(PreInfoData data)
        {
            if (data == null)
            {
                this.txtInTable_P_no.Text = "";
                this.txtInTable_P_Name.Text = "";
                this.txtInTable_unit.Text = "";
                this.txtInTable_Unit_Price.Text = "";
                this.txtInTableCost_price.Text = "";
            }
            else
            {
                this.txtInTable_P_no.Text = data.P_no;
                this.txtInTable_P_Name.Text = data.P_name;
                this.txtInTable_unit.Text = data.Unit;
                this.txtInTable_Unit_Price.Text = data.Unit_price.ToString();
                this.txtInTableCost_price.Text = data.Cost_price.ToString();
            }
        }

        private void btnInTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryInTableForm queryForm = QueryInTableForm.thisForm;
                if (queryForm == null || queryForm.IsDisposed)
                {
                    queryForm = new QueryInTableForm();
                }
                queryForm.Show();
                //this.showMain = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ѯ",ex);
            }
        }

        private void btnGoodAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
                if (MessageBox.Show("ȷ�������", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.InTable().setGoodAcc(in_scrpno))
                    {
                        MessageBox.Show("ȷ������ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.labGoodAcc.Text = "��ȷ�����";
                        this.btnGoodAcc.Enabled = false;
                    }
                    //else
                    //{
                    //    MessageBox.Show("ȷ������ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("ȷ�����",ex);
            }
        }

        private void txtInTable_P_Name_TextChanged(object sender, EventArgs e)
        {
            //���������б�
            string pname = this.txtInTable_P_Name.Text.Trim();
            this.listBoxPreName.DataSource = queryPreInfoListbyPname(pname);
            this.listBoxPreName.DisplayMember = "p_name";
            this.listBoxPreName.ValueMember = "p_name";
            //����TextBox
            setPreInfoTextValueByPname(pname);
            this.listBoxPreName.Visible = true;
        }


        //��ѯListBox
        private IList<PreInfoData> queryPreInfoListbyPname(string pname)
        {
            if (pname == "")
                return this.preInfoList;
            IList<PreInfoData> returnList = new List<PreInfoData>();
            for (int i = 0; i < this.preInfoList.Count; i++)
            {
                PreInfoData data = this.preInfoList[i];
                string p_name = data.P_name;
                if (p_name.Contains(pname))
                {
                    returnList.Add(data);
                }
            }
            return returnList;
        }


        //����p_noָ��TextBox��ֵ
        private void setPreInfoTextValueByPname(string pname)
        {
            if (pname == "")
            {
                setPreInfoTextBoxValueFromProInfo(null);
            }
            else
            {
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string p_name = data.P_name;
                    if (p_name.Trim() == pname.Trim())
                    {
                        setPreInfoTextBoxValueFromProInfo(data);
                        break;
                    }
                }
            }

        }

        private void listBoxPreName_Click(object sender, EventArgs e)
        {
            setPreInfoTextValueByPname(this.listBoxPreName.SelectedValue.ToString());
            this.listBoxPreName.Visible = false;
        }


        /// <summary>
        /// ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
                if (MessageBox.Show("ȷ��ɾ����", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.InTable().deleteIntable(in_scrpno))
                    {
                        MyMessageBox.ShowInfoMessageBox("ɾ���ɹ�������ѻָ�");
                        if (this.showMain)
                        {
                            if (this.btnLast.Enabled)
                            {
                                btnNext_Click(sender, e);
                            }
                            else
                            {
                                btnOne_Click(sender, e);
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MyMessageBox.ShowInfoMessageBox("ɾ��������");
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ƾ֤ɾ��������", ex);
            }
        }


        /// <summary>
        /// �˿�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";
                for (int inScrpList_count = 0; inScrpList_count < inScrpList.Count; inScrpList_count++)
                {
                    InScrpInfo oldData = inScrpList[inScrpList_count];
                    bool haveNew = false;
                    for (int newInScrpList_count = 0; newInScrpList_count < newInScrpList.Count; newInScrpList_count++)
                    {
                        InScrpInfo newData = newInScrpList[newInScrpList_count];
                        
                        if (oldData.P_no == newData.P_no)
                        {
                            if (oldData.Qnt < newData.Qnt)
                            {
                                MyMessageBox.ShowInfoMessageBox("�˿�������˿������Ӧ��С���˿�ǰ����\n" + "����Ʒ��ţ�" + oldData.P_no + "��ԭ�������Ϊ" + oldData.Qnt + "���˿������Ϊ" + newData.Qnt + "���˿�����Ϊ" + (oldData.Qnt - newData.Qnt));
                                return;
                            }
                            haveNew = true;
                            if (oldData.Qnt > newData.Qnt)
                                message = message + "����Ʒ��ţ�" + oldData.P_no + "��ԭ�������Ϊ" + oldData.Qnt + "���˿������Ϊ" + newData.Qnt + "���˿�����Ϊ" + (oldData.Qnt - newData.Qnt) + "\n";
                        }
                    }
                    if (!haveNew)
                    {
                        MyMessageBox.ShowInfoMessageBox("�˿�����벻Ҫɾ������Ʒ");
                        return;
                    }
                }
                for (int newInScrpList_count = 0; newInScrpList_count < newInScrpList.Count; newInScrpList_count++)
                {
                    bool haveOld = false;
                    InScrpInfo newData = newInScrpList[newInScrpList_count];
                    for (int inScrpList_count = 0; inScrpList_count < inScrpList.Count; inScrpList_count++)
                    {

                        InScrpInfo oldData = inScrpList[inScrpList_count];
                        if (oldData.P_no == newData.P_no)
                        {
                            haveOld = true;
                        }
                    }
                    if (!haveOld)
                    {
                        MyMessageBox.ShowInfoMessageBox("�˿�����벻Ҫ��������Ʒ");
                        return;
                    }
                }

                if (message == "")
                {
                    MyMessageBox.ShowInfoMessageBox("����û�ж�ԭ�������޸ģ����޸ĺ��ٵ���˿ⰴť");
                    return;
                }

                if (MessageBox.Show(message, "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    if (tuikuInTableInfo())
                    {
                        MessageBox.Show("�˿�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inScrpList = newInScrpList;
                    }
                    else
                    {
                        MessageBox.Show("�˿����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�˿�", ex);
            }
        }


        //�˿����
        private bool tuikuInTableInfo()
        {

            //����ƾ֤-duixiang
            string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
            string planin = this.cobInTable_PlanIn.Text.ToString();
            string in_ou = this.cobInTableIn_Ou.Text.ToString();
            DateTime in_date = this.cobInTableIn_Date.Value;
            string billno = this.txtInTable_Billno.Text.Trim();
            decimal in_cost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
            string in_memo = this.txtInTableIn_Memo.Text.Trim();
            //(string in_scrpno, string billno, string in_ou,System.DateTime in_date ,decimal in_cost, string planin,
            //int goodsAcc,int in_acc,string in_memo)
            InTableInfo aInTableInfoaInTableInfo = new InTableInfo(in_scrpno, billno, in_ou, in_date, in_cost, planin, 0, 0, in_memo);
            aInTableInfoaInTableInfo.InScrpList = this.newInScrpList;
            return new BLL.InTable().UnInTable(aInTableInfoaInTableInfo,this.inScrpList);


        }

        private void buttonPrintIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.chk_word_in.Checked)
                    WordHelper.OpenAndWriteWordForIn1(this.inScrpList, this.cobInTableIn_Date.Value,
                        this.txtInTable_Billno.Text.Trim(), this.txtInTableIn_Scrpno.Text.Trim());
                else
                    WordHelper.OpenAndWriteWordForIn2(this.inScrpList, this.cobInTableIn_Date.Value,
                   this.txtInTable_Billno.Text.Trim(), this.txtInTableIn_Scrpno.Text.Trim());
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ӡ��ⵥ",ex);
            }

        }

        private void groupBoxUpdateIntable_Enter(object sender, EventArgs e)
        {

        }

    }
}