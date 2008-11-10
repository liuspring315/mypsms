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

        //tabControl标签属性
        public TabControl InOutTabletabControl
        {
            get { return this.inOutTabletabControl; }
        }

        private void InOutTableForm_Load(object sender, EventArgs e)
        {
            try
            {
                //初始化数据
                DataLoadBySelectTab();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("录入出入库凭证",ex);
            }

        }
        
        //当改变标签选中时事件
        private void inOutTabletabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化数据
            DataLoadBySelectTab();
        }
        
        //初始化数据
        private void DataLoadBySelectTab()
        {
            //打开入库凭证录入标签 初始化数据
            if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[0])
            {
                setIn_OuList();
                setP_noList(this.lbInTable_P_no);
                this.txtInTableIn_Scrpno.Text = StrUtil.Next(new BLL.InTable().GetTopInScrpno());
            }
            //打开出库凭证录入标签 初始化数据
            else if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[1])
            {
                setOut_ouList();
                setVip_ouList();
                setP_noList(this.listBoxOutTable_P_no);
                this.txtOutTable_Out_scrpno.Text = StrUtil.Next(new BLL.OutTable().GetTopOutScrpNo());
            }
            //打开入库凭证退库标签 初始化数据
            else if (this.inOutTabletabControl.SelectedTab == this.inOutTabletabControl.TabPages[2])
            {
                
            }
            

        }

        //当此窗口关闭显示父窗口
        private void InOutTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        #region 公共私有方法
        //查询ListBox
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

        #region 入库凭证录入

        #region 私有字段
        private bool isFirstAddPreInfo = true;
       
        private System.ComponentModel.BindingList<InScrpInfo> inScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        #endregion

        #region 事件

        //取消事件
        private void btnInTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //宣传品编号文本框文本改变事件
        private void txtInTable_P_no_TextChanged(object sender, EventArgs e)
        {
            //更新下拉列表
            string pno = this.txtInTable_P_no.Text.Trim();
            this.lbInTable_P_no.DataSource = queryPreInfoListbyPno(pno);
            this.lbInTable_P_no.DisplayMember = "p_no";
            this.lbInTable_P_no.ValueMember = "p_no";
            //更新TextBox
            setPreInfoTextValue(pno);

        }
       
        //选择下拉列表中宣传品编号事件
        private void lbInTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtInTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString();
        }
        
        //添加宣传品按钮事件
        private void btnInTable_addPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (isFirstAddPreInfo)
                {
                    if (this.txtInTableIn_Scrpno.Text.Trim() == "")
                    {
                        MessageBox.Show("请先输入凭证编号", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "请先输入凭证编号");
                    }
                    else if (this.txtInTable_Billno.Text.Trim() == "")
                    {
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "");
                        MessageBox.Show("请先输入提货单号", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTable_Billno, "请先输入提货单号");
                    }
                    else
                    {
                        this.errorProvider.SetError(this.txtInTableIn_Scrpno, "");
                        this.errorProvider.SetError(this.txtInTable_Billno, "");

                        //启用添加宣传品
                        setAddPreInfoToInTableEnable(true);
                        //初始化宣传品ArrayList
                        inScrpList = new System.ComponentModel.BindingList<InScrpInfo>();
                        //设置isFirstAddPreInfo = false;
                        isFirstAddPreInfo = false;

                        //this.setDataGridColumnName();
                        this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;
                        setDataGridColumnName();
                    }
                }
                else   //先凭证中添加宣传品
                {
                    if (this.txtInTable_Unit_Price.Text == "")
                    {
                        MessageBox.Show("请先选定宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTable_P_no, "请先选定宣传品");
                        return;
                    }
                    this.errorProvider.SetError(this.txtInTable_P_no, "");
                    //更新凭证结算金额
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
                        MessageBox.Show("数量请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTable_Qnt, "数量请输入整数");
                        return;
                    }
                    this.errorProvider.SetError(this.txtInTable_Qnt, "");

                    //保存包含的宣传品
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
                        MessageBox.Show("已添加宣传品编号为" + p_no + "请不要重复添加", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtInTable_P_no, "已添加宣传品编号为" + p_no + "请不要重复添加");
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
                    //重新绑定凭证包含宣传品列表
                    this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;


                    //清空TextBox等待用户下一输入
                    setPreInfoTextBoxValueFromProInfo(null);
                    this.txtInTable_P_no.Text = "";
                    this.txtInTable_Qnt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("添加票品按钮",ex);
            }


        }

        //DataGridView按钮列处理事件
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
                        //从列表中移除
                        inScrpList.Remove(data);
                        //重新计算凭证结算金额
                        decimal incost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
                        this.txtInTableIn_Cost.Text = (incost - data.In_price).ToString();
                        break;
                    }
                }
                //
                //重新绑定凭证包含宣传品列表
                this.dataGridViewIntable_PreInfoList.DataSource = inScrpList;
            }
        }

        //数量改变事件
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
            //    MessageBox.Show("请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        //保存并退出按钮事件
        private void btnInTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //保存
                if (saveNewInTableInfo())
                {
                    MessageBox.Show("新增入库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("新增入库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //退出
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("新增入库凭证", ex);
            }
        }

        //保存并录入下一个凭证
        private void btnInTable_NextTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //保存
                if (saveNewInTableInfo())
                {
                    MessageBox.Show("新增入库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //还原默认界面
                    //禁用添加宣传品
                    setAddPreInfoToInTableEnable(false);
                    //宣传品ArrayList值null
                    inScrpList = null;
                    //设置isFirstAddPreInfo = ftrue;
                    isFirstAddPreInfo = true;
                    //清空TextBox等待用户下一输入
                    setPreInfoTextBoxValueFromProInfo(null);
                    this.txtInTable_P_no.Text = "";

                    //清空凭证输入
                    string old_scrpno = this.txtInTableIn_Scrpno.Text;
                    
                    this.txtInTableIn_Scrpno.Text = StrUtil.Next(old_scrpno.Trim());
                    this.txtInTableIn_Memo.Text = "";
                    this.cobInTable_PlanIn.SelectedItem = this.cobInTable_PlanIn.Items[0];
                    this.cobInTableIn_Date.Value = DateTime.Now;
                    this.cobInTableIn_Ou.SelectedItem = this.cobInTableIn_Ou.Items[this.cobInTableIn_Ou.FindString("市场部")];
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
                    MessageBox.Show("新增入库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("新增入库凭证",ex);
            }
            
           
        }

        //保存
        private bool saveNewInTableInfo()
        {
            
            //保存凭证-duixiang
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

        //新增宣传品 弹出窗口
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
                MyMessageBox.ShowErrorMessageBox("新增宣传品弹出窗口",ex);
            }
        }

        void addPerInfoForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setP_noList(this.lbInTable_P_no);
            this.lbInTable_P_no.SelectedItem = this.lbInTable_P_no.Items[this.lbInTable_P_no.FindString(e.Selection)];
            this.txtInTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString();
        }

        #endregion

        #region 私有方法
        //初始化货源
        private void setIn_OuList()
        {
            BLL.InInfo ininfo = new psms.BLL.InInfo();
            this.cobInTableIn_Ou.DataSource = ininfo.GetAllInInfo();
            this.cobInTableIn_Ou.DisplayMember = "in_ou";
            this.cobInTableIn_Ou.ValueMember = "in_ou";
            this.cobInTableIn_Ou.SelectedItem = this.cobInTableIn_Ou.Items[this.cobInTableIn_Ou.FindString("市场部")];
        }

       


        //设施宣传品各个控件是否启用
        private void setAddPreInfoToInTableEnable(bool enable)
        {
            this.btnInTable_AddNewPreInfo.Enabled = enable;
            this.txtInTable_P_no.Enabled = enable;
            this.lbInTable_P_no.Enabled = enable;
            this.txtInTable_Qnt.Enabled = enable;
            this.txtInTableIn_Scrpno.Enabled = !enable;
            this.txtInTable_P_Name.Enabled = enable;
        }

        //设置宣传品文本框值
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

        

        //根据p_no指定TextBox的值
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

        #region 出库凭证录入

        #region 私有字段

        private bool outTable_isFirstAddPreInfo = true;
		 
            //请领单位
        IList<OutInfoData> outInfoList = null;
            //请领单位
        IList<VipInfoData> vipInfoList = null;
            //出库宣传品Arraylist
        BindingList<OutScrpInfo> outScrpList = null;

	    #endregion

        #region 私有方法
        
        //初始化请领单位
        private void setOut_ouList()
        {
            BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
            outInfoList = outInfoBll.GetAllOutInfo();
            this.cobOutTable_Out_ou.DataSource = this.outInfoList;
            this.cobOutTable_Out_ou.DisplayMember = "out_ou";
            this.cobOutTable_Out_ou.ValueMember = "out_ou";
        }

        //初始化赠送分类
        private void setVip_ouList()
        {
            BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
            vipInfoList = vipInfoBll.GetAllVipInfo();
            this.cobOutTable_Vip_ou.DataSource = this.vipInfoList;
            this.cobOutTable_Vip_ou.DisplayMember = "vip_ou";
            this.cobOutTable_Vip_ou.ValueMember = "vip_ou";
        }

        //设出库宣传品各个控件是否启用
        private void setOutTable_AddPreInfoEnable(bool enable)
        {
            this.txtOutTable_P_no.Enabled = enable;
            this.txtOutTable_P_name.Enabled = enable;
            this.listBoxOutTable_P_no.Enabled = enable;
            this.txtOutTable_Qnt.Enabled = enable;
            this.txtOutTable_Out_scrpno.Enabled = !enable;
        }
        
        //设置宣传品文本框值
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
        
        //根据p_no指定TextBox的值
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
        
        //设置DataGrid列顺序
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

        //保存
        private bool saveNewOutTableInfo()
        {
           
            //保存凭证-duixiang
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

        #region 事件
        //从ListBox中选择宣传品编号事件
        private void listBoxOutTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtOutTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString().Trim();
        }

        //添加宣传品
        private void btnOutTable_AddPreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (outTable_isFirstAddPreInfo)
                {
                    if (this.txtOutTable_Out_scrpno.Text.Trim() == "")
                    {
                        MessageBox.Show("请先输入凭证编号", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "请先输入凭证编号");
                    }
                    else
                    {
                        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "");
                        //启用添加宣传品
                        setOutTable_AddPreInfoEnable(true);
                        //初始化宣传品ArrayList
                        outScrpList = new System.ComponentModel.BindingList<OutScrpInfo>();
                        //设置outTable_isFirstAddPreInfo = false;
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
                        MessageBox.Show("请先选定宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_P_no, "请先选定宣传品");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_P_no, "");

                    string p_no = this.txtOutTable_P_no.Text.Trim();
                    //验证是否库存足量
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
                        MessageBox.Show("数量请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "数量请输入整数");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");
                    if (!ishavefull)
                    {
                        if (MessageBox.Show("宣传品编号为：" + p_no + "的现有库存为：" + nowqnt + "，库存不足，确认出库？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //继续
                        }
                        else
                        {
                            //返回
                            this.errorProvider.SetError(this.txtOutTable_Qnt, "库存不足，现有库存" + nowqnt);
                            return;
                        }
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");

                    //验证是否已添加过
                    

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
                        MessageBox.Show("已添加宣传品编号为" + p_no + "请不要重复添加", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_P_no, "已添加宣传品编号为" + p_no + "请不要重复添加");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_P_no, "");

                    //更新凭证结算金额
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
                        MessageBox.Show("数量请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "数量请输入整数");
                        return;
                    }
                    this.errorProvider.SetError(this.txtOutTable_Qnt, "");
                    //保存包含的宣传品
                    

                    string out_scrpno = this.txtOutTable_Out_scrpno.Text.Trim();
                    string pname = this.txtOutTable_P_name.Text.Trim();
                    string unit = this.txtOutTable_unit.Text.Trim();
                    decimal unitprice = decimal.Parse(this.txtOutTable_Unit_price.Text.Trim());
                    decimal costprice = decimal.Parse(this.txtOutTable_Cost_price.Text.Trim());
                    OutScrpInfo data = new OutScrpInfo(outScrpList.Count, out_scrpno, p_no, pname, unit, unitprice, costprice, qntTxt, out_price);
                    outScrpList.Add(data);
                    //重新绑定凭证包含宣传品列表
                    this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;


                    //清空TextBox等待用户下一输入
                    setOutTable_PreInfoTextBoxValueFromProInfo(null);
                    this.txtOutTable_P_no.Text = "";
                    this.txtOutTable_Qnt.Text = "";
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库添加宣传品按钮",ex);
            }
        }
        
        //保存并继续
        private void btnOutTable_NextOutTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //保存
                if (saveNewOutTableInfo())
                {
                    MessageBox.Show("新增出库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //还原默认界面
                    //禁用添加宣传品
                    setOutTable_AddPreInfoEnable(false);
                    //宣传品ArrayList值null
                    outScrpList = null;
                    //设置isFirstAddPreInfo = ftrue;

                    outTable_isFirstAddPreInfo = true;
                    //清空TextBox等待用户下一输入
                    setOutTable_PreInfoTextValue("");
                    this.txtOutTable_P_no.Text = "";

                    //清空凭证输入
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
                    MessageBox.Show("新增出库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("新增出库凭证", ex);
            }

            //还原默认界面
        }

        //退出
        private void btnOutTable_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //保存后退出
        private void btnOutTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //保存
                if (saveNewOutTableInfo())
                {
                    MessageBox.Show("新增出库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("新增出库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //退出
                this.Close();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("新增出库凭证", ex);
            }
            
        }
       
        //宣传品编号文本框文本改变事件
        private void txtOutTable_P_no_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //更新下拉列表
                string pno = this.txtOutTable_P_no.Text.Trim();
                this.listBoxOutTable_P_no.DataSource = queryPreInfoListbyPno(pno);
                this.listBoxOutTable_P_no.DisplayMember = "p_no";
                this.listBoxOutTable_P_no.ValueMember = "p_no";
                //更新TextBox
                setOutTable_PreInfoTextValue(pno);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("更新下拉列表", ex);
            }
        }

        //宣传品DataGirdView按钮列处理事件
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
                        //从列表中移除
                        outScrpList.Remove(data);
                        //重新计算凭证结算金额
                        decimal outcost = decimal.Parse(this.txtOutTable_Out_cost.Text.Trim());
                        this.txtOutTable_Out_cost.Text = (outcost - data.Out_price).ToString();
                        break;
                    }
                }
                //
                //重新绑定凭证包含宣传品列表
                this.dataGridViewOutTable_PreInfo.DataSource = outScrpList;
            }
        }

        //数量改变处理事件
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
                MessageBox.Show("请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.errorProvider.SetError(this.txtOutTable_Qnt, "请输入整数");
            }
        }


        #endregion

       
       

       

       

        #endregion

        //#region 入库凭证退库


        //#region 事件

        ////凭证编号改变事件
        //private void txtInTableReOut_P_scrpno_TextChanged(object sender, EventArgs e)
        //{
        //    //更新下拉列表
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

        ////单击ListBox事件
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
        
        ////退出
        //private void btnInTableReOut_Exit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

     
        //#endregion

        //#region 私有字段

        //private IList<InTableInfo> inTableList = new BLL.InTable().GetAllInTable();
        //#endregion



        //#region 私有方法

        ////查询ListBox
        //private IList<InTableInfo> queryInTableInfoListbyPscrptno(string txtpscrpno)
        //{
        //    IList<InTableInfo> returnList = new List<InTableInfo>();
        //    if (txtpscrpno == "")
        //        return returnList;
        //    for (int i = 0; i < this.inTableList.Count; i++)
        //    {
        //        InTableInfo data = this.inTableList[i];
        //        string pscrpno = data.In_scrpno;
        //        //已做账
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
        //            MessageBox.Show("请输入要查询的入库凭证编号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            return;
        //        }

        //        for (int i = 0; i < this.inTableList.Count; i++)
        //        {
        //            InTableInfo data = this.inTableList[i];
        //            if (inscrpno == data.In_scrpno)
        //            {
        //                if (data.In_acc == 0)
        //                {
        //                    MessageBox.Show("该凭证还未做账，请在入库凭证修改中直接修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        //        MyMessageBox.ShowErrorMessageBox("入库凭证退库",ex);
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
        //        MessageBox.Show("数量请输入整数","错误",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        //        return;
        //    }
        //    string qnt2 = this.txtInTableReOut_Qnt.Text.Trim();
        //    if (Int32.Parse(qnt2) >= Int32.Parse(qnt1))
        //    {
        //        MessageBox.Show("退库后的数量应该小于目前的数量", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            //更新下拉列表
            string pname = this.txtInTable_P_Name.Text.Trim();
            this.listBoxPreName.DataSource = queryPreInfoListbyPname(pname);
            this.listBoxPreName.DisplayMember = "p_name";
            this.listBoxPreName.ValueMember = "p_name";
            //更新TextBox
            setPreInfoTextValueByPname(pname);
            this.listBoxPreName.Visible = true;
        }

        //查询ListBox
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

        //根据p_no指定TextBox的值
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
            //更新下拉列表
            string pname = this.txtOutTable_P_name.Text.Trim();
            this.listBoxOutTable_PreName.DataSource = queryPreInfoListbyPname(pname);
            this.listBoxOutTable_PreName.DisplayMember = "p_name";
            this.listBoxOutTable_PreName.ValueMember = "p_name";
            //更新TextBox
            setOutTablePreInfoTextValueByPname(pname);
            this.listBoxOutTable_PreName.Visible = true;
            
        }




        //根据pname指定TextBox的值
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
                //更新下拉列表
                string pname = this.txtOutTable_P_name.Text.Trim();
                this.listBoxOutTable_PreName.DataSource = queryPreInfoListbyPname(pname);
                this.listBoxOutTable_PreName.DisplayMember = "p_name";
                this.listBoxOutTable_PreName.ValueMember = "p_name";
                //更新TextBox
                setOutTablePreInfoTextValueByPname(pname);
                this.listBoxOutTable_PreName.Visible = true;
            }
        }

        private void buttonPrintOut_Click(object sender, EventArgs e)
        {
            try
            {

                //请领单位
                string outUn = cobOutTable_Out_ou.Text.ToString();

                //赠送分类
                string vipUn = cobOutTable_Vip_ou.Text.ToString();

                //出库编号
                string outscrpNo = this.txtOutTable_Out_scrpno.Text.ToString();

                //出库日期
                string outDate = this.cobOutTable_Out_date.Value.ToShortDateString();

                //备注
                string remark = txtOutTable_Out_memo.Text.ToString();
                if(this.chk_word_out.Checked)
                    WordHelper.OpenAndWriteWordForOut1(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                else
                    WordHelper.OpenAndWriteWordForOut2(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);



                ////年月日
                //System.DateTime now = DateTime.Now;
                //string year = now.Date.Year.ToString();
                //string month = now.Month.ToString();
                //string day = now.Day.ToString();

                ////请领单位
                //string outUn = cobOutTable_Out_ou.Text.ToString();

                ////赠送分类
                //string vipUn = cobOutTable_Vip_ou.Text.ToString();


                ////宣传品所有  outScrpList
                //if (outScrpList.Count == 0)
                //{
                //    MyMessageBox.ShowInfoMessageBox("没有添加宣传品，请首先添加宣传品");
                //    return;
                //}
                //if (outScrpList.Count > 8)
                //{
                //    MyMessageBox.ShowInfoMessageBox("打印模板中最多添加宣传品8个，现在多余八个");
                //    return;
                //}


                ////备注
                //string remark = txtOutTable_Out_memo.Text.ToString();



                //object oMissing = System.Reflection.Missing.Value;
                //Microsoft.Office.Interop.Word._Application oWord;
                //Microsoft.Office.Interop.Word._Document oDoc;
                //oWord = new Microsoft.Office.Interop.Word.Application();
                ////显示word文档
                //oWord.Visible = true;
                ////取得word文件模板
                //object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\word.do";
                ////根据模板生成一个新文档，相当于另存为
                //oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                //                ref oMissing, ref oMissing);
                ////在这里操作表格中的文本

                ////

                ////年月日
                ////  月    日                   第     号\r
                ////oDoc.Tables[1].Cell(1, 1).Range.Text = "cell11";
                //oDoc.Content.Paragraphs[2].Range.Text = year + "年 " + month + " 月 " + day + " 日                   第     号";

                ////请领单位
                //oDoc.Tables[1].Cell(2, 2).Range.Text = outUn;

                ////赠送分类
                //oDoc.Tables[1].Cell(3, 2).Range.Text = vipUn;


                ////宣传品所有  outScrpList
                //if (outScrpList.Count > 8)
                //{
                //    MyMessageBox.ShowInfoMessageBox("打印模板中最多添加宣传品8个，现在多余8个");
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
                ////如果小于8个就在最后一行加"----------"
                //if (outScrpList.Count < 8)
                //{
                //    oDoc.Tables[1].Cell(6 + outScrpList.Count, 2).Range.Text = "----------";
                //}

                ////备注
                ////MessageBox.Show(oDoc.Content.Paragraphs[85].Range.Text);
                ////MessageBox.Show(oDoc.Tables[1].Rows[16].ToString());
                ////string remarkText = oDoc.Content.Paragraphs[86].Range.Text;
                //oDoc.Content.Paragraphs[86].Range.Text = "备注：" + remark;


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("打印出库单", ex);
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
                MyMessageBox.ShowErrorMessageBox("打印入库单", ex);
            }
        }




    }
}