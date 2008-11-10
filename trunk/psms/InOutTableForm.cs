using System;
using System.Collections;
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

    public partial class InOutTableForm : Form
    {

        //
        public ListBox ListBoxInTableP_no
        {
            get
            {
                return this.lbInTable_P_no;
            }
        }



        public InOutTableForm()
        {
            InitializeComponent();
        }

        //tabControl��ǩ����
        public TabControl InOutTabletabControl
        {
            get { return this.inOutTabletabControl; }
        }

        private void InOutTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                //��ʼ������
                DataLoadBySelectTab();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("¼������ƾ֤",ex);
            }

        }
        
        //���ı��ǩѡ��ʱ�¼�
        private void inOutTabletabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��ʼ������
            DataLoadBySelectTab();
        }
        
        //��ʼ������
        private void DataLoadBySelectTab()
        {
            //�����ƾ֤¼���ǩ ��ʼ������
            if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[0])
            {
                setIn_OuList();
                setP_noList(this.lbInTable_P_no);
                this.txtInTableIn_Scrpno.Text = StrUtil.Next(new BLL.InTable().GetTopInScrpno());
            }
            //�򿪳���ƾ֤¼���ǩ ��ʼ������
            else if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[1])
            {
                setOut_ouList();
                setVip_ouList();
                setP_noList(this.listBoxOutTable_P_no);
                this.txtOutTable_Out_scrpno.Text = StrUtil.Next(new BLL.OutTable().GetTopOutScrpNo());
            }
            //�����ƾ֤�˿��ǩ ��ʼ������
            else if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[2])
            {
                
            }
            

        }

        //���˴��ڹر���ʾ������
        private void InOutTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        #region ����˽�з���
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
        private void setP_noList(ListBox listBox)
        {
            BLL.PreInfo preInfo = new psms.BLL.PreInfo();
            preInfoList = preInfo.GetAllPreInfo();
            listBox.DataSource = preInfoList;
            listBox.DisplayMember = "p_no";
            listBox.ValueMember = "p_no";

        }

        #endregion

        #region ���ƾ֤¼��

        #region ˽���ֶ�
        private bool isFirstAddPreInfo = true;
       
        private System.ComponentModel.BindingList<InScrpInfo> inScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        #endregion

        #region �¼�

        //ȡ���¼�
        private void btnInTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //����Ʒ����ı����ı��ı��¼�
        private void txtInTable_P_no_TextChanged(object sender, EventArgs e)
        {
            //���������б�
            string pno = this.txtInTable_P_no.Text.Trim();
            this.lbInTable_P_no.DataSource = queryPreInfoListbyPno(pno);
            this.lbInTable_P_no.DisplayMember = "p_no";
            this.lbInTable_P_no.ValueMember = "p_no";
            //����TextBox
            setPreInfoTextValue(pno);

        }
       
        //ѡ�������б�������Ʒ����¼�
        private void lbInTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtInTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString();
        }
        
        //�������Ʒ��ť�¼�
        private void btnInTable_addPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirstAddPreInfo)
                {
                    if (this.txtInTableIn_Scrpno.Text.Trim() == "")
                    {
                        MessageBox.Show("��������ƾ֤���", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "��������ƾ֤���");
                    }
                    else if (this.txtInTable_Billno.Text.Trim() == "")
                    {
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "");
                        MessageBox.Show("���������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTable_Billno, "���������������");
                    }
                    else
                    {
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "");
                        this.errorProvider.SetError(this.txtInTable_Billno, "");

                        //�����������Ʒ
                        setAddPreInfoToInTableEnable(true);
                        //��ʼ������ƷArrayList
                        inScrpList = new System.ComponentModel.BindingList<InScrpInfo>();
                        //����isFirstAddPreInfo = false;
                        isFirstAddPreInfo = false;

                        //this.setDataGridColumnName();
                        this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;
                        setDataGridColumnName();
                    }
                }
                else   //��ƾ֤���������Ʒ
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
                    for (int i = 0; i < inScrpList.Count; i++)
                    {
                        if (inScrpList[i].P_no == p_no)
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
                    inScrpList.Add(data);
                    //���°�ƾ֤��������Ʒ�б�
                    this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;


                    //���TextBox�ȴ��û���һ����
                    setPreInfoTextBoxValueFromProInfo(null);
                    this.txtInTable_P_no.Text = "";
                    this.txtInTable_Qnt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ƱƷ��ť",ex);
            }


        }

        //DataGridView��ť�д����¼�
        private void dataGridViewIntable_PreInfoList_CellClick(object sender, DataGridViewCellEventArgs e)
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
                        inScrpList.Remove(data);
                        //���¼���ƾ֤������
                        decimal incost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
                        this.txtInTableIn_Cost.Text = (incost - data.In_price).ToString();
                        break;
                    }
                }
                //
                //���°�ƾ֤��������Ʒ�б�
                this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;
            }
        }

        //�����ı��¼�
        private void txtInTable_Qnt_TextChanged(object sender, EventArgs e)
        {
            //if (this.txtInTable_Qnt.Text.Trim() == "")
            //    return;
            //try
            //{
            //    int qnt = Int32.Parse(this.txtInTable_Qnt.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("����������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        //���沢�˳���ť�¼�
        private void btnInTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //����
                if (saveNewInTableInfo())
                {
                    MessageBox.Show("�������ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("�������ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //�˳�
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�������ƾ֤", ex);
            }
        }

        //���沢¼����һ��ƾ֤
        private void btnInTable_NextTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //����
                if (saveNewInTableInfo())
                {
                    MessageBox.Show("�������ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //��ԭĬ�Ͻ���
                    //�����������Ʒ
                    setAddPreInfoToInTableEnable(false);
                    //����ƷArrayListֵnull
                    inScrpList = null;
                    //����isFirstAddPreInfo = ftrue;
                    isFirstAddPreInfo = true;
                    //���TextBox�ȴ��û���һ����
                    setPreInfoTextBoxValueFromProInfo(null);
                    this.txtInTable_P_no.Text = "";

                    //���ƾ֤����
                    string old_scrpno = this.txtInTableIn_Scrpno.Text;
                    
                    this.txtInTableIn_Scrpno.Text = StrUtil.Next(old_scrpno.Trim());
                    this.txtInTableIn_Memo.Text = "";
                    this.cobInTable_PlanIn.SelectedItem = this.cobInTable_PlanIn.Items[0];
                    this.cobInTableIn_Date.Value = DateTime.Now;
                    this.cobInTableIn_Ou.SelectedItem = this.cobInTableIn_Ou.Items[this.cobInTableIn_Ou.FindString("�г���")];
                    this.txtInTable_Billno.Text = "";
                    this.txtInTableCost_price.Text = "";
                    this.txtInTable_Qnt.Text = "";
                    this.txtInTableCost_price.Text = "0";
                    this.txtInTableIn_Cost.Text = "0";
                    this.dataGridViewIntable_PreInfoList.DataSource = null;

                    this.errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("�������ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�������ƾ֤",ex);
            }
            
           
        }

        //����
        private bool saveNewInTableInfo()
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
            aInTableInfoaInTableInfo.InScrpList = this.inScrpList;
            return new BLL.InTable().insertInTable(aInTableInfoaInTableInfo);
           
            
        }

        //��������Ʒ ��������
        private void btnInTable_AddNewPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                AddPreInfoForm addPerInfoForm = new AddPreInfoForm();
                addPerInfoForm.SelectionChanged += new AddPreInfoForm.SelectionChangedEventHandler(addPerInfoForm_SelectionChanged);
                addPerInfoForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��������Ʒ��������",ex);
            }
        }

        void addPerInfoForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setP_noList(this.lbInTable_P_no);
            this.lbInTable_P_no.SelectedItem = this.lbInTable_P_no.Items[this.lbInTable_P_no.FindString(e.Selection)];
            this.txtInTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString();
        }

        #endregion

        #region ˽�з���
        //��ʼ����Դ
        private void setIn_OuList()
        {
            BLL.InInfo ininfo = new psms.BLL.InInfo();
            this.cobInTableIn_Ou.DataSource = ininfo.GetAllInInfo();
            this.cobInTableIn_Ou.DisplayMember = "in_ou";
            this.cobInTableIn_Ou.ValueMember = "in_ou";
            this.cobInTableIn_Ou.SelectedItem = this.cobInTableIn_Ou.Items[this.cobInTableIn_Ou.FindString("�г���")];
        }

       


        //��ʩ����Ʒ�����ؼ��Ƿ�����
        private void setAddPreInfoToInTableEnable(bool enable)
        {
            this.btnInTable_AddNewPreInfo.Enabled = enable;
            this.txtInTable_P_no.Enabled = enable;
            this.lbInTable_P_no.Enabled = enable;
            this.txtInTable_Qnt.Enabled = enable;
            this.txtInTableIn_Scrpno.Enabled = !enable;
            this.txtInTable_P_Name.Enabled = enable;
        }

        //��������Ʒ�ı���ֵ
        private void setPreInfoTextBoxValueFromProInfo(PreInfoData data)
        {
            if (data == null)
            {
                this.txtInTable_P_Name.Text = "";
                this.txtInTable_unit.Text = "";
                this.txtInTable_Unit_Price.Text = "";
                this.txtInTableCost_price.Text = "";
            }
            else
            {
                this.txtInTable_P_Name.Text = data.P_name;
                this.txtInTable_unit.Text = data.Unit;
                this.txtInTable_Unit_Price.Text = data.Unit_price.ToString();
                this.txtInTableCost_price.Text = data.Cost_price.ToString();
                this.txtInTable_P_no.Text = data.P_no;
            }
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

        #endregion

        

        
        
        #endregion

        #region ����ƾ֤¼��

        #region ˽���ֶ�

        private bool outTable_isFirstAddPreInfo = true;
		 
            //���쵥λ
        IList<OutInfoData> outInfoList = null;
            //���쵥λ
        IList<VipInfoData> vipInfoList = null;
            //��������ƷArraylist
        BindingList<OutScrpInfo> outScrpList = null;

	    #endregion

        #region ˽�з���
        
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

        //���������Ʒ�����ؼ��Ƿ�����
        private void setOutTable_AddPreInfoEnable(bool enable)
        {
            this.txtOutTable_P_no.Enabled = enable;
            this.txtOutTable_P_name.Enabled = enable;
            this.listBoxOutTable_P_no.Enabled = enable;
            this.txtOutTable_Qnt.Enabled = enable;
            this.txtOutTable_Out_scrpno.Enabled = !enable;
        }
        
        //��������Ʒ�ı���ֵ
        private void setOutTable_PreInfoTextBoxValueFromProInfo(PreInfoData data)
        {
            if (data == null)
            {
                this.txtOutTable_P_name.Text = "";
                this.txtOutTable_unit.Text = "";
                this.txtOutTable_Unit_price.Text = "";
                this.txtOutTable_Cost_price.Text = "";
                this.txtOutTable_P_no.Text = "";
            }
            else
            {
                this.txtOutTable_P_no.Text = data.P_no.Trim();
                this.txtOutTable_P_name.Text = data.P_name.Trim();
                this.txtOutTable_unit.Text = data.Unit.Trim();
                this.txtOutTable_Unit_price.Text = data.Unit_price.ToString().Trim();
                this.txtOutTable_Cost_price.Text = data.Cost_price.ToString().Trim();
            }
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
        
        //����DataGrid��˳��
        private void setOutTable_DataGridColumnName()
        {
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_In_scrpno"].DisplayIndex = 0;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_P_no"].DisplayIndex = 1;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_P_name"].DisplayIndex = 2;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Unit"].DisplayIndex = 3;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Unit_price"].DisplayIndex = 4;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Cost_price"].DisplayIndex = 5;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Qnt"].DisplayIndex = 6;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_In_price"].DisplayIndex = 7;
            this.dataGridViewOutTable_PreInfo.Columns["dataGridViewTextBoxColumnOutTable_Id"].Visible = false;
            this.dataGridViewOutTable_PreInfo.AutoGenerateColumns = false;

        }

        //����
        private bool saveNewOutTableInfo()
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
            OutTableInfo aOutTableInfo = new OutTableInfo(out_scrpno, out_ou, out_date, out_cost, vip_ou, 0,out_memo);
            aOutTableInfo.OutScrpList = this.outScrpList;
            return new BLL.OutTable().insertOutTable(aOutTableInfo);


        }

        #endregion

        #region �¼�
        //��ListBox��ѡ������Ʒ����¼�
        private void listBoxOutTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtOutTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString().Trim();
        }

        //�������Ʒ
        private void btnOutTable_AddPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (outTable_isFirstAddPreInfo)
                {
                    if (this.txtOutTable_Out_scrpno.Text.Trim() == "")
                    {
                        MessageBox.Show("��������ƾ֤���", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "��������ƾ֤���");
                    }
                    else
                    {
                        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "");
                        //�����������Ʒ
                        setOutTable_AddPreInfoEnable(true);
                        //��ʼ������ƷArrayList
                        outScrpList = new System.ComponentModel.BindingList<OutScrpInfo>();
                        //����outTable_isFirstAddPreInfo = false;
                        outTable_isFirstAddPreInfo = false;

                        //this.setDataGridColumnName();
                        this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;
                        setOutTable_DataGridColumnName();
                    }
                }
                else
                {
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
                                if (preInfoList[i].Acc_qnt >= Int32.Parse(this.txtOutTable_Qnt.Text.Trim()))
                                    ishavefull = true;
                                nowqnt = preInfoList[i].Acc_qnt;
                                break;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("��������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "��������������");
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
                    for (int i = 0; i < outScrpList.Count; i++)
                    {
                        if (outScrpList[i].P_no == p_no)
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
                    outScrpList.Add(data);
                    //���°�ƾ֤��������Ʒ�б�
                    this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;


                    //���TextBox�ȴ��û���һ����
                    setOutTable_PreInfoTextBoxValueFromProInfo(null);
                    this.txtOutTable_P_no.Text = "";
                    this.txtOutTable_Qnt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�����������Ʒ��ť",ex);
            }
        }
        
        //���沢����
        private void btnOutTable_NextOutTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //����
                if (saveNewOutTableInfo())
                {
                    MessageBox.Show("��������ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //��ԭĬ�Ͻ���
                    //�����������Ʒ
                    setOutTable_AddPreInfoEnable(false);
                    //����ƷArrayListֵnull
                    outScrpList = null;
                    //����isFirstAddPreInfo = ftrue;

                    outTable_isFirstAddPreInfo = true;
                    //���TextBox�ȴ��û���һ����
                    setOutTable_PreInfoTextValue("");
                    this.txtOutTable_P_no.Text = "";

                    //���ƾ֤����
                    string old_scrpno = this.txtOutTable_Out_scrpno.Text;
                    this.txtOutTable_Out_scrpno.Text = StrUtil.Next(old_scrpno.Trim());
                    this.txtOutTable_Out_memo.Text = "";
                    this.cobOutTable_Out_date.Value = DateTime.Now;
                    this.cobOutTable_Out_ou.SelectedItem = this.cobOutTable_Out_ou.Items[0];
                    this.cobOutTable_Vip_ou.SelectedItem = this.cobOutTable_Vip_ou.Items[0];
                    this.txtOutTable_Out_cost.Text = "0";
                    this.dataGridViewOutTable_PreInfo.DataSource = null;

                    this.errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("��������ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��������ƾ֤", ex);
            }

            //��ԭĬ�Ͻ���
        }

        //�˳�
        private void btnOutTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //������˳�
        private void btnOutTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("���ƾ֤�������Ʒ", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //����
                if (saveNewOutTableInfo())
                {
                    MessageBox.Show("��������ƾ֤�ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("��������ƾ֤����", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //�˳�
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��������ƾ֤", ex);
            }
            
        }
       
        //����Ʒ����ı����ı��ı��¼�
        private void txtOutTable_P_no_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //���������б�
                string pno = this.txtOutTable_P_no.Text.Trim();
                this.listBoxOutTable_P_no.DataSource = queryPreInfoListbyPno(pno);
                this.listBoxOutTable_P_no.DisplayMember = "p_no";
                this.listBoxOutTable_P_no.ValueMember = "p_no";
                //����TextBox
                setOutTable_PreInfoTextValue(pno);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���������б�", ex);
            }
        }

        //����ƷDataGirdView��ť�д����¼�
        private void dataGridViewOutTable_PreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewOutTable_PreInfo.Columns[e.ColumnIndex].Name == "dataGridViewButtonColumnDelButton")
            {
                int id = Int32.Parse(this.dataGridViewOutTable_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnOutTable_Id"].Value.ToString().Trim());
                for (int i = 0; i < outScrpList.Count; i++)
                {
                    OutScrpInfo data = outScrpList[i];
                    if (data.Id == id)
                    {
                        //���б����Ƴ�
                        outScrpList.Remove(data);
                        //���¼���ƾ֤������
                        decimal outcost = decimal.Parse(this.txtOutTable_Out_cost.Text.Trim());
                        this.txtOutTable_Out_cost.Text = (outcost - data.Out_price).ToString();
                        break;
                    }
                }
                //
                //���°�ƾ֤��������Ʒ�б�
                this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;
            }
        }

        //�����ı䴦���¼�
        private void txtOutTable_Qnt_TextChanged(object sender, EventArgs e)
        {
            if (this.txtOutTable_Qnt.Text.Trim() == "")
                return;
            try
            {
                int qnt = Int32.Parse(this.txtOutTable_Qnt.Text.Trim());
            }
            catch
            {
                MessageBox.Show("����������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.errorProvider.SetError(this.txtOutTable_Qnt, "����������");
            }
        }


        #endregion

       
       

       

       

        #endregion

        //#region ���ƾ֤�˿�


        //#region �¼�

        ////ƾ֤��Ÿı��¼�
        //private void txtInTableReOut_P_scrpno_TextChanged(object sender, EventArgs e)
        //{
        //    //���������б�
        //    string pscrpno = this.txtInTableReOut_P_scrpno.Text.Trim();
        //    IList<InTableInfo> list = queryInTableInfoListbyPscrptno(pscrpno);
        //    if (list.Count > 0)
        //    {
        //        this.listBoxInTableReOut_In_scrpno.DataSource = list;
        //        this.listBoxInTableReOut_In_scrpno.DisplayMember = "in_scrpno";
        //        this.listBoxInTableReOut_In_scrpno.ValueMember = "in_scrpno";
        //        this.listBoxInTableReOut_In_scrpno.Visible = true;
        //    }
        //    else
        //    {
        //        this.listBoxInTableReOut_In_scrpno.Visible = false;
        //    }
        //}

        ////����ListBox�¼�
        //private void listBoxInTableReOut_In_scrpno_Click(object sender, EventArgs e)
        //{
        //    this.txtInTableReOut_P_scrpno.Text = this.listBoxInTableReOut_In_scrpno.SelectedValue.ToString();
        //}
        //private void dataGridViewInTableReOut_PreInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (this.dataGridViewInTableReOut_PreInfo.Columns[e.ColumnIndex].Name == "dataGridViewButtonColumnInTableReOut_UpdateButton")
        //    {
        //        //int id = Int32.Parse(this.dataGridViewIntable_PreInfoList.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_Id"].Value.ToString().Trim());
        //        string p_no = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_P_no"].Value.ToString().Trim();
        //        string p_name = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_P_name"].Value.ToString().Trim();
        //        string unit = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_Unit"].Value.ToString().Trim();
        //        string unit_price = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_Unit_price"].Value.ToString().Trim();
        //        string cost_price = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_Cost_price"].Value.ToString().Trim();
        //        string qnt = this.dataGridViewInTableReOut_PreInfo.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnInTableReOut_Qnt"].Value.ToString().Trim();
        //        this.txtInTableReOut_P_no.Text = p_no;
        //        this.txtInTableReOut_P_name.Text = p_name;
        //        this.txtInTableReOut_Unit.Text = unit;
        //        this.txtInTableReOut_Unit_price.Text = unit_price;
        //        this.txtInTableReOut_Cost_price.Text = cost_price;
        //        this.txtInTableReOut_Qnt.Text = qnt;
        //    }
        //}
        
        ////�˳�
        //private void btnInTableReOut_Exit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

     
        //#endregion

        //#region ˽���ֶ�

        //private IList<InTableInfo> inTableList = new BLL.InTable().GetAllInTable();
        //#endregion



        //#region ˽�з���

        ////��ѯListBox
        //private IList<InTableInfo> queryInTableInfoListbyPscrptno(string txtpscrpno)
        //{
        //    IList<InTableInfo> returnList = new List<InTableInfo>();
        //    if (txtpscrpno == "")
        //        return returnList;
        //    for (int i = 0; i < this.inTableList.Count; i++)
        //    {
        //        InTableInfo data = this.inTableList[i];
        //        string pscrpno = data.In_scrpno;
        //        //������
        //        if (data.In_acc == 1)
        //        {
        //            if (pscrpno.Contains(txtpscrpno))
        //            {
        //                returnList.Add(data);
        //            }
        //        }
        //    }
        //    return returnList;
        //}
        //private void setInTableReOut_DataGridColumnName()
        //{
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_In_scrpno"].DisplayIndex = 0;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_P_no"].DisplayIndex = 1;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_P_name"].DisplayIndex = 2;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_Unit"].DisplayIndex = 3;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_Unit_price"].DisplayIndex = 4;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_Cost_price"].DisplayIndex = 5;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_Qnt"].DisplayIndex = 6;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_In_price"].DisplayIndex = 7;
        //    this.dataGridViewInTableReOut_PreInfo.Columns["dataGridViewTextBoxColumnInTableReOut_Id"].Visible = false;
        //    this.dataGridViewInTableReOut_PreInfo.AutoGenerateColumns = false;

        //}


        //#endregion

        //private void btnQueryPreInfo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string inscrpno = this.txtInTableReOut_P_scrpno.Text.Trim();
        //        if (inscrpno == "")
        //        {
        //            MessageBox.Show("������Ҫ��ѯ�����ƾ֤���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            return;
        //        }

        //        for (int i = 0; i < this.inTableList.Count; i++)
        //        {
        //            InTableInfo data = this.inTableList[i];
        //            if (inscrpno == data.In_scrpno)
        //            {
        //                if (data.In_acc == 0)
        //                {
        //                    MessageBox.Show("��ƾ֤��δ���ˣ��������ƾ֤�޸���ֱ���޸�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                    return;
        //                }
        //                else
        //                {
        //                    this.txtInTableReOut_In_cost.Text = data.In_cost.ToString();
        //                }
        //                break;
        //            }
        //        }
        //        setInTableReOut_DataGridColumnName();
        //        BLL.InScrp inScrpBLL = new psms.BLL.InScrp();
        //        IList<InScrpInfo> list = inScrpBLL.GetInScrpByInScrpno(this.txtInTableReOut_P_scrpno.Text.Trim());
        //        BindingList<InScrpInfo> bindingList = new BindingList<InScrpInfo>();
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            bindingList.Add(list[i]);
        //        }
        //        this.dataGridViewInTableReOut_PreInfo.DataSource = bindingList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyMessageBox.ShowErrorMessageBox("���ƾ֤�˿�",ex);
        //    }
        //}

       

        //#endregion

        //private void btnInTableReOut_ReOut_Click(object sender, EventArgs e)
        //{
        //    string pno = this.txtInTableReOut_P_no.Text;
        //    string pname = this.txtInTableReOut_P_name.Text;
        //    string inscrpno = util.DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInTableReOut_PreInfo, "dataGridViewTextBoxColumnInTableReOut_In_scrpno");
        //    string qnt1 = util.DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInTableReOut_PreInfo, "dataGridViewTextBoxColumnInTableReOut_Qnt").Trim();

        //    try
        //    {
        //        Int32.Parse(this.txtInTableReOut_Qnt.Text.Trim());
        //    }
        //    catch
        //    {
        //        MessageBox.Show("��������������","����",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        //        return;
        //    }
        //    string qnt2 = this.txtInTableReOut_Qnt.Text.Trim();
        //    if (Int32.Parse(qnt2) >= Int32.Parse(qnt1))
        //    {
        //        MessageBox.Show("�˿�������Ӧ��С��Ŀǰ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return;
        //    }
        //    string incost1 = this.txtInTableReOut_In_cost.Text.Trim();
        //    string unitprice = util.DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInTableReOut_PreInfo, "dataGridViewTextBoxColumnInTableReOut_Unit_price").Trim();
        //    decimal incost2 = (decimal.Parse(incost1) - (decimal.Parse(unitprice) * (Int32.Parse(qnt1) - Int32.Parse(qnt2))));
        //    UnInTableForm unIntableForm = new UnInTableForm(pno, pname, inscrpno, incost1, incost2.ToString(), qnt1, qnt2);
        //    unIntableForm.ShowDialog(this);
        //}

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
                //bool is_select = false;
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string p_name = data.P_name;
                    if (p_name.Trim() == pname.Trim())
                    {
                        setPreInfoTextBoxValueFromProInfo(data);
                        //is_select = true;
                        break;
                    }
                }
                //if (!is_select)
                //{
                //    setPreInfoTextBoxValueFromProInfo(null);
                //}
            }
        }

        private void listBoxPreName_Click(object sender, EventArgs e)
        {
            setPreInfoTextValueByPname(this.listBoxPreName.SelectedValue.ToString());
            this.listBoxPreName.Visible = false;
        }

        private void txtInTable_P_Name_Leave(object sender, EventArgs e)
        {
            //this.listBoxPreName.Visible = false;
        }

        private void txtOutTable_P_name_TextChanged(object sender, EventArgs e)
        {
            //���������б�
            string pname = this.txtOutTable_P_name.Text.Trim();
            this.listBoxOutTable_PreName.DataSource = queryPreInfoListbyPname(pname);
            this.listBoxOutTable_PreName.DisplayMember = "p_name";
            this.listBoxOutTable_PreName.ValueMember = "p_name";
            //����TextBox
            setOutTablePreInfoTextValueByPname(pname);
            this.listBoxOutTable_PreName.Visible = true;
            
        }




        //����pnameָ��TextBox��ֵ
        private void setOutTablePreInfoTextValueByPname(string pname)
        {
            if (pname == "")
            {
                setPreInfoTextBoxValueFromProInfo(null);
            }
            else
            {
                //bool is_select = false;
                for (int i = 0; i < this.preInfoList.Count; i++)
                {
                    PreInfoData data = this.preInfoList[i];
                    string p_name = data.P_name;
                    if (p_name.Trim() == pname.Trim())
                    {
                        setOutTable_PreInfoTextBoxValueFromProInfo(data);
                        //is_select = true;
                        break;
                    }
                }
                //if (!is_select)
                //{
                //    setPreInfoTextBoxValueFromProInfo(null);
                //}
            }
        }

        private void listBoxOutTable_PreName_Click(object sender, EventArgs e)
        {
            setOutTablePreInfoTextValueByPname(this.listBoxOutTable_PreName.SelectedValue.ToString());
            this.listBoxOutTable_PreName.Visible = false;
        }

        private void txtInTable_P_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //���������б�
                string pname = this.txtOutTable_P_name.Text.Trim();
                this.listBoxOutTable_PreName.DataSource = queryPreInfoListbyPname(pname);
                this.listBoxOutTable_PreName.DisplayMember = "p_name";
                this.listBoxOutTable_PreName.ValueMember = "p_name";
                //����TextBox
                setOutTablePreInfoTextValueByPname(pname);
                this.listBoxOutTable_PreName.Visible = true;
            }
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
                if(this.chk_word_out.Checked)
                    WordHelper.OpenAndWriteWordForOut1(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                else
                    WordHelper.OpenAndWriteWordForOut2(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);



                ////������
                //System.DateTime now = DateTime.Now;
                //string year = now.Date.Year.ToString();
                //string month = now.Month.ToString();
                //string day = now.Day.ToString();

                ////���쵥λ
                //string outUn = cobOutTable_Out_ou.Text.ToString();

                ////���ͷ���
                //string vipUn = cobOutTable_Vip_ou.Text.ToString();


                ////����Ʒ����  outScrpList
                //if (outScrpList.Count == 0)
                //{
                //    MyMessageBox.ShowInfoMessageBox("û���������Ʒ���������������Ʒ");
                //    return;
                //}
                //if (outScrpList.Count > 8)
                //{
                //    MyMessageBox.ShowInfoMessageBox("��ӡģ��������������Ʒ8�������ڶ���˸�");
                //    return;
                //}


                ////��ע
                //string remark = txtOutTable_Out_memo.Text.ToString();



                //object oMissing = System.Reflection.Missing.Value;
                //Microsoft.Office.Interop.Word._Application oWord;
                //Microsoft.Office.Interop.Word._Document oDoc;
                //oWord = new Microsoft.Office.Interop.Word.Application();
                ////��ʾword�ĵ�
                //oWord.Visible = true;
                ////ȡ��word�ļ�ģ��
                //object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\word.do";
                ////����ģ������һ�����ĵ����൱�����Ϊ
                //oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                //                ref oMissing, ref oMissing);
                ////�������������е��ı�

                ////

                ////������
                ////  ��    ��                   ��     ��\r
                ////oDoc.Tables[1].Cell(1, 1).Range.Text = "cell11";
                //oDoc.Content.Paragraphs[2].Range.Text = year + "�� " + month + " �� " + day + " ��                   ��     ��";

                ////���쵥λ
                //oDoc.Tables[1].Cell(2, 2).Range.Text = outUn;

                ////���ͷ���
                //oDoc.Tables[1].Cell(3, 2).Range.Text = vipUn;


                ////����Ʒ����  outScrpList
                //if (outScrpList.Count > 8)
                //{
                //    MyMessageBox.ShowInfoMessageBox("��ӡģ��������������Ʒ8�������ڶ���8��");
                //    return;
                //}
                //for (int i = 0; i < outScrpList.Count; i++)
                //{
                //    OutScrpInfo data = outScrpList[i];
                //    oDoc.Tables[1].Cell(6 + i, 1).Range.Text = data.P_no;
                //    oDoc.Tables[1].Cell(6 + i, 2).Range.Text = data.P_name;
                //    oDoc.Tables[1].Cell(6 + i, 3).Range.Text = data.Unit_price.ToString();
                //    oDoc.Tables[1].Cell(6 + i, 4).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                //    oDoc.Tables[1].Cell(6 + i, 5).Range.Text = data.Out_price.ToString();

                //}
                ////���С��8���������һ�м�"----------"
                //if (outScrpList.Count < 8)
                //{
                //    oDoc.Tables[1].Cell(6 + outScrpList.Count, 2).Range.Text = "----------";
                //}

                ////��ע
                ////MessageBox.Show(oDoc.Content.Paragraphs[85].Range.Text);
                ////MessageBox.Show(oDoc.Tables[1].Rows[16].ToString());
                ////string remarkText = oDoc.Content.Paragraphs[86].Range.Text;
                //oDoc.Content.Paragraphs[86].Range.Text = "��ע��" + remark;


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("��ӡ���ⵥ", ex);
            }
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
                MyMessageBox.ShowErrorMessageBox("��ӡ��ⵥ", ex);
            }
        }




    }
}