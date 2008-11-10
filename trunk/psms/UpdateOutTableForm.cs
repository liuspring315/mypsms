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
    public partial class UpdateOutTableForm : Form
    {

        //���쵥λ
        IList<OutInfoData> outInfoList = null;
        //���쵥λ
        IList<VipInfoData> vipInfoList = null;

        private System.ComponentModel.BindingList<OutScrpInfo> outScrpList = null;
        private System.ComponentModel.BindingList<OutScrpInfo> newOutScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        //����ƾ֤List
        private IList<OutTableInfo> outTableList = null;
        //����
        private int index = 0;
        //���м�¼��
        private int count = 1;

        //ת����ѯҳ���ʾ
        private bool showMain = true;

        public UpdateOutTableForm()
        {
            InitializeComponent();
        }

        public UpdateOutTableForm(OutTableInfo data)
        {
            
            InitializeComponent();

            this.showMain = false;

            outTableList = new List<OutTableInfo>();
            outTableList.Add(data);
            this.btnPrv.Enabled = false;
            this.btnOne.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
        }

        private void UpdateOutTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.showMain)
            {
                MainForm.mainForm.Show();
                if (QueryOutTableForm.thisForm != null)
                {
                    QueryOutTableForm.thisForm.Close();
                }
            }
            else
            {
                if (QueryOutTableForm.thisForm != null)
                {
                    QueryOutTableForm.thisForm.Show();
                }
            }
        }

        private void UpdateOutTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                //��ʼ�����쵥λ
                setOut_ouList();
                //��ʼ�����ͷ���
                setVip_ouList();
                //����DataGrid��˳��
                setDataGridColumnName();
                //��ʼ������Ʒ���ListBox
                setP_noList(this.listBoxOutTable_P_no);

                if (this.outTableList == null)
                {
                    this.outTableList = new BLL.OutTable().GetAllOutTable();
                }
                count = this.outTableList.Count;
                setGroupUpdateOutTableText();
                if(count > 0)
                    setTextByOutTableInfo();
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
                MyMessageBox.ShowErrorMessageBox("����ƾ֤�޸Ĵ��ڼ���",ex);
            }

        }





        //��ʼ�����쵥λ
        private void setOut_ouList()
        {
            BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
            outInfoList = outInfoBll.GetAllOutInfo();
            this.cobOutTable_Out_ou.DataSource = this.outInfoList;
            this.cobOutTable_Out_ou.DisplayMember = "out_ou";
            this.cobOutTable_Out_ou.ValueMember = "out_ou";
        }

        //��ʼ�����ͷ���
        private void setVip_ouList()
        {
            BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
            vipInfoList = vipInfoBll.GetAllVipInfo();
            this.cobOutTable_Vip_ou.DataSource = this.vipInfoList;
            this.cobOutTable_Vip_ou.DisplayMember = "vip_ou";
            this.cobOutTable_Vip_ou.ValueMember = "vip_ou";
        }

        private void setGroupUpdateOutTableText()
        {
            this.groupBoxUpdateOuttable.Text = "ƾ֤��Ϣ   ��ǰ��" + (index + 1) + "�������м�¼��" + count;
        }

        //����ҳ��textBoxֵ
        private void setTextByOutTableInfo()
        {

                OutTableInfo data = this.outTableList[index];
                this.txtOutTable_Out_scrpno.Text = data.Out_scrpno;
                this.cobOutTable_Out_ou.Text = data.Out_ou;
                this.cobOutTable_Vip_ou.Text = data.Vip_ou;
                this.cobOutTable_Out_date.Value = data.Out_date;
                this.txtOutTable_Out_cost.Text = data.Out_cost.ToString();
                this.txtOutTable_Out_memo.Text = data.Out_memo;

                if (data.Out_acc == 0)
                {
                    // this.labAcc.Text = "δ����";
                    this.btnOutTable_SaveAndExit.Enabled = true;
                    this.btnOutTable_NextOutTable.Enabled = true;
                    this.btnOutTable_AddPreInfo.Enabled = true;
                }
                else
                {
                    //this.labAcc.Text = "������";

                    this.btnOutTable_SaveAndExit.Enabled = false;
                    this.btnOutTable_NextOutTable.Enabled = false;
                    this.btnOutTable_AddPreInfo.Enabled = false;

                }
                //��ʼ����Ӧ����Ʒ

                IList<OutScrpInfo> list = new BLL.OutScrp().GetOutScrpByOutScrpno(data.Out_scrpno);
                this.outScrpList = new BindingList<OutScrpInfo>();
                this.newOutScrpList = new BindingList<OutScrpInfo>();
                for (int i = 0; i < list.Count; i++)
                {
                    this.outScrpList.Add(list[i]);
                    this.newOutScrpList.Add(list[i]);
                }

                this.dataGridViewOutTable_PreInfo.DataSource = newOutScrpList;
           
        }

        private void setDataGridColumnName()
        {
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Out_scrpno"].DisplayIndex = 0;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_P_no"].DisplayIndex = 1;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_P_name"].DisplayIndex = 2;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Unit"].DisplayIndex = 3;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Unit_price"].DisplayIndex = 4;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Cost_price"].DisplayIndex = 5;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Qnt"].DisplayIndex = 6;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Out_price"].DisplayIndex = 7;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Id"].Visible = false;
            this.dataGridViewOutTable_PreInfo.AutoGenerateColumns = false;

        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            try
            {
                index = 0;
                setTextByOutTableInfo();
                this.btnPrv.Enabled = false;
                this.btnOne.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                setGroupUpdateOutTableText();
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
                setTextByOutTableInfo();

                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
                if (this.index == 0)
                {
                    this.btnPrv.Enabled = false;
                    this.btnOne.Enabled = false;
                }
                setGroupUpdateOutTableText();
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
                setTextByOutTableInfo();
                setGroupUpdateOutTableText();

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
                setTextByOutTableInfo();
                setGroupUpdateOutTableText();
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

        private void listBoxOutTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtOutTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString().Trim();
        }

        private void txtOutTable_P_no_TextChanged(object sender, EventArgs e)
        {
            //���������б�
            string pno = this.txtOutTable_P_no.Text.Trim();
            this.listBoxOutTable_P_no.DataSource = queryPreInfoListbyPno(pno);
            this.listBoxOutTable_P_no.DisplayMember = "p_no";
            this.listBoxOutTable_P_no.ValueMember = "p_no";
            //����TextBox
            setOutTable_PreInfoTextValue(pno);
        }

        //����p_noָ��TextBox��ֵ
        private void setOutTable_PreInfoTextValue(string txtpno)
        {
            if (txtpno == "")
            {
                setOutTable_PreInfoTextBoxValueFromProInfo(null);
            }
            else
            {
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string pno = data.P_no;
                    if (pno.Trim() == txtpno.Trim())
                    {
                        setOutTable_PreInfoTextBoxValueFromProInfo(data);
                        break;
                    }
                }
            }

        }

        //��������Ʒ�ı���ֵ
        private void setOutTable_PreInfoTextBoxValueFromProInfo(PreInfoData data)
        {
            if (data == null)
            {
                this.txtOutTable_P_no.Text = "";
                this.txtOutTable_P_name.Text = "";
                this.txtOutTable_unit.Text = "";
                this.txtOutTable_Unit_price.Text = "";
                this.txtOutTable_Cost_price.Text = "";
            }
            else
            {
                this.txtOutTable_P_no.Text = data.P_no;
                this.txtOutTable_P_name.Text = data.P_name.Trim();
                this.txtOutTable_unit.Text = data.Unit.Trim();
                this.txtOutTable_Unit_price.Text = data.Unit_price.ToString().Trim();
                this.txtOutTable_Cost_price.Text = data.Cost_price.ToString().Trim();
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

        private void dataGridViewOutTable_PreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewOutTable_PreInfo.Columns[e.ColumnIndex].Name == "dataGridViewButtonColumnDelButton")
            {
                int id = Int32.Parse(this.dataGridViewOutTable_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnOutTable_Id"].Value.ToString().Trim());
                for (int i = 0; i < newOutScrpList.Count; i++)
                {
                    OutScrpInfo data = newOutScrpList[i];
                    if (data.Id == id)
                    {
                        //���б����Ƴ�
                        newOutScrpList.Remove(data);
                        //���¼���ƾ֤������
                        decimal outcost = decimal.Parse(this.txtOutTable_Out_cost.Text.Trim());
                        this.txtOutTable_Out_cost.Text = (outcost - data.Out_price).ToString();
                        break;
                    }
                }
                //
                //���°�ƾ֤��������Ʒ�б�
                this.dataGridViewOutTable_PreInfo.DataSource = newOutScrpList;
            }
        }

        private void btnOutTable_NextOutTable_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "������")
                //{
                //    MessageBox.Show("������ƾ֤�����޸�", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //����
                if (this.messageBoxReturn())
                {
                    if (updateOutTableInfo())
                    {
                        MessageBox.Show("�޸ĳ���ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        outScrpList = newOutScrpList;
                    }
                    else
                    {
                        MessageBox.Show("�޸ĳ���ƾ֤����,ע�ⲻҪ�ظ�����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸ĳ���ƾ֤", ex);
            }
        }

        private void btnOutTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOutTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "������")
                //{
                //    MessageBox.Show("������ƾ֤�����޸�", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //else
                //{
                    if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                    {
                        MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //����
                    if (messageBoxReturn())
                    {
                        if (updateOutTableInfo())
                        {
                            MessageBox.Show("�޸ĳ���ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            outScrpList = newOutScrpList;
                        }
                        else
                        {
                            MessageBox.Show("�޸ĳ���ƾ֤����,ע�ⲻҪ�ظ�����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        this.Close();
                    }
                //}
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�޸ĳ���ƾ֤", ex);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                QueryOutTableForm queryForm = QueryOutTableForm.thisForm;
                if (queryForm == null || queryForm.IsDisposed)
                {
                    queryForm = new QueryOutTableForm();
                }
                queryForm.Show();
                this.showMain = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�����ѯ",ex);
            }
        }

        private bool messageBoxReturn()
        {
            string message = "";
            for (int outScrpList_count = 0; outScrpList_count < outScrpList.Count; outScrpList_count++)
            {
                OutScrpInfo oldData = outScrpList[outScrpList_count];
                bool haveNew = false;
                for (int newOutScrpList_count = 0; newOutScrpList_count < newOutScrpList.Count; newOutScrpList_count++)
                {
                    OutScrpInfo newData = newOutScrpList[newOutScrpList_count];
                    if (oldData.P_no == newData.P_no)
                    {
                        haveNew = true;
                        message = message + "����Ʒ��ţ�" + oldData.P_no + "��ԭ��������Ϊ" + oldData.Qnt + "���޸ĺ��������Ϊ" + newData.Qnt + "\n";
                    }
                }
                if (!haveNew)
                {
                    message += "����Ʒ��ţ�" + oldData.P_no + "��ԭ��������Ϊ" + oldData.Qnt + "��ɾ��\n";
                }

            }
            for (int newOutScrpList_count = 0; newOutScrpList_count < newOutScrpList.Count; newOutScrpList_count++)
            {
                bool haveOld = false;
                OutScrpInfo newData = newOutScrpList[newOutScrpList_count];
                for (int outScrpList_count = 0; outScrpList_count < outScrpList.Count; outScrpList_count++)
                {

                    OutScrpInfo oldData = outScrpList[outScrpList_count];
                    if (oldData.P_no == newData.P_no)
                    {
                        haveOld = true;
                    }
                }
                if (!haveOld)
                {
                    message += "����Ʒ��ţ�" + newData.P_no + "����������Ϊ" + newData.Qnt + "������\n";
                }
            }
            if (MessageBox.Show(message, "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        //����
        private bool updateOutTableInfo()
        {
            
            if (this.outScrpList != null)
            {
                //����ƾ֤-duixiang
                string out_scrpno = this.txtOutTable_Out_scrpno.Text.Trim();
                DateTime out_date = this.cobOutTable_Out_date.Value;
                decimal out_cost = decimal.Parse(this.txtOutTable_Out_cost.Text.Trim());
                string out_ou = this.cobOutTable_Out_ou.Text.ToString();
                string vip_ou = this.cobOutTable_Vip_ou.Text.ToString();
                string out_memo = this.txtOutTable_Out_memo.Text.Trim();
                //string out_scrpno, string out_ou, string out_date, decimal out_cost, string vip_ou,
                //int out_acc,string out_memo
                OutTableInfo aOutTableInfo = new OutTableInfo(out_scrpno, out_ou, out_date, out_cost, vip_ou, 0, out_memo);
                aOutTableInfo.OutScrpList = this.newOutScrpList;
                return new BLL.OutTable().updateOutTable(aOutTableInfo);
            }
            return false;


        }

       // private bool outTable_isFirstAddPreInfo = true;
        private void btnOutTable_AddPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //if (outTable_isFirstAddPreInfo)
                //{
                //    if (this.txtOutTable_Out_scrpno.Text.Trim() == "")
                //    {
                //        MessageBox.Show("��������ƾ֤���", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "��������ƾ֤���");
                //    }
                //    else
                //    {
                //        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "");
                //        //�����������Ʒ
                //        setOutTable_AddPreInfoEnable(true);
                //        //��ʼ������ƷArrayList

                //        //����outTable_isFirstAddPreInfo = false;
                //        outTable_isFirstAddPreInfo = false;

                //        //this.setDataGridColumnName();
                //        this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;
                //        setDataGridColumnName();
                //    }
                //}
                //else
                //{
                    if (this.txtOutTable_Unit_price.Text == "")
                    {
                        MessageBox.Show("����ѡ������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_P_no, "����ѡ������Ʒ");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_P_no, "");

                    string p_no = this.txtOutTable_P_no.Text.Trim();

                    //��֤�Ƿ�������
                    this.preInfoList = new BLL.PreInfo().GetAllPreInfo();
                    bool ishavefull = false;
                    int nowqnt = 0;
                    try
                    {
                        for (int i = 0; i < preInfoList.Count; i++)
                        {
                            if (preInfoList[i].P_no == p_no)
                            {
                                int thisAccqnt = preInfoList[i].Acc_qnt;
                                IList<OutScrpInfo> outList = new BLL.OutScrp().GetOutScrpByOutScrpno(this.txtOutTable_Out_scrpno.Text.Trim());
                                if (outList != null && outList.Count > 0)
                                {
                                    for (int j = 0; j < outList.Count; j++)
                                    {
                                        if (outList[j].P_no == p_no)
                                        {
                                            thisAccqnt = outList[j].Qnt + thisAccqnt;
                                            break;
                                        }
                                    }
                                }
                                if (thisAccqnt >= Int32.Parse(this.txtOutTable_Qnt.Text.Trim()))
                                    ishavefull = true;
                                nowqnt = thisAccqnt;
                                break;

                                    
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("��������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "��������������");
                        Log.WriteLog("�����޸���636��" + ex);
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");
                    if (!ishavefull)
                    {
                        if (MessageBox.Show("����Ʒ���Ϊ��" + p_no + "�����п��Ϊ��" + nowqnt + "����治�㣬ȷ�ϳ��⣿", "ע��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //����
                        }
                        else
                        {
                            //����
                            this.errorProvider.SetError(this.txtOutTable_Qnt, "��治�㣬���п��" + nowqnt);
                            return;
                        }
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");

                    //��֤�Ƿ�����ӹ�
                    bool findpno = false;
                    for (int i = 0; i < newOutScrpList.Count; i++)
                    {
                        if (newOutScrpList[i].P_no == p_no)
                        {
                            findpno = true;
                            break;
                        }
                    }
                    if (findpno)
                    {
                        MessageBox.Show("���������Ʒ���Ϊ" + p_no + "�벻Ҫ�ظ����", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_P_no, "���������Ʒ���Ϊ" + p_no + "�벻Ҫ�ظ����");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_P_no, "");


                    //����ƾ֤������
                    int qntTxt = 0;
                    decimal unit_priceTxt = 0;
                    decimal out_price = 0;
                    try
                    {
                        qntTxt = Int32.Parse(this.txtOutTable_Qnt.Text.Trim());
                        unit_priceTxt = decimal.Parse(this.txtOutTable_Unit_price.Text.Trim());
                        out_price = unit_priceTxt * qntTxt;
                        this.txtOutTable_Out_cost.Text = (out_price + decimal.Parse(this.txtOutTable_Out_cost.Text.Trim())).ToString();
                    }
                    catch
                    {
                        MessageBox.Show("��������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "��������������");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");
                    
                    //�������������Ʒ
                    
                    

                    string out_scrpno = this.txtOutTable_Out_scrpno.Text.Trim();
                    string pname = this.txtOutTable_P_name.Text.Trim();
                    string unit = this.txtOutTable_unit.Text.Trim();
                    decimal unitprice = decimal.Parse(this.txtOutTable_Unit_price.Text.Trim());
                    decimal costprice = decimal.Parse(this.txtOutTable_Cost_price.Text.Trim());
                    OutScrpInfo data = new OutScrpInfo(outScrpList.Count, out_scrpno, p_no, pname, unit, unitprice, costprice, qntTxt, out_price);
                    newOutScrpList.Add(data);
                    //���°�ƾ֤��������Ʒ�б�
                    this.dataGridViewOutTable_PreInfo.DataSource = newOutScrpList;


                    //���TextBox�ȴ��û���һ����
                    setOutTable_PreInfoTextBoxValueFromProInfo(null);
                    this.txtOutTable_P_no.Text = "";
                //}
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�����������Ʒ",ex);
            }
        }

        //���������Ʒ�����ؼ��Ƿ�����
        private void setOutTable_AddPreInfoEnable(bool enable)
        {
            this.txtOutTable_P_no.Enabled = enable;
            this.listBoxOutTable_P_no.Enabled = enable;
            this.txtOutTable_Qnt.Enabled = enable;
            this.txtOutTable_Out_scrpno.Enabled = !enable;
            this.txtOutTable_P_name.Enabled = enable;
        }

        private void txtOutTable_P_name_TextChanged(object sender, EventArgs e)
        {
            //���������б�
            string pname = this.txtOutTable_P_name.Text.Trim();
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
                setOutTable_PreInfoTextBoxValueFromProInfo(null);
            }
            else
            {
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string p_name = data.P_name;
                    if (p_name.Trim() == pname.Trim())
                    {
                        setOutTable_PreInfoTextBoxValueFromProInfo(data);
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

        private void buttonPrintOut_Click(object sender, EventArgs e)
        {
            try
            {
                //���쵥λ
                string outUn = cobOutTable_Out_ou.Text.ToString();

                //���ͷ���
                string vipUn = cobOutTable_Vip_ou.Text.ToString();

                //������
                string outscrpNo = this.txtOutTable_Out_scrpno.Text.ToString();

                //��������
                string outDate = this.cobOutTable_Out_date.Value.ToShortDateString();

                //��ע
                string remark = txtOutTable_Out_memo.Text.ToString();
                if (this.chk_word_out.Checked)
                    WordHelper.OpenAndWriteWordForOut1(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                else
                    WordHelper.OpenAndWriteWordForOut2(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ӡ���ⵥ",ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string out_scrpno = this.txtOutTable_Out_scrpno.Text.Trim();
                if (MessageBox.Show("ȷ��ɾ����", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.OutTable().deleteOutTable(out_scrpno))
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
                MyMessageBox.ShowErrorMessageBox("����ƾ֤ɾ��������", ex);
            }
        }






    }
}