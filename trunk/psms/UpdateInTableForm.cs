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

        #region 私有字段
        
        #endregion
        private System.ComponentModel.BindingList<InScrpInfo> inScrpList = null;
        private System.ComponentModel.BindingList<InScrpInfo> newInScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        //入库凭证List
        private IList<InTableInfo> inTableList = null;
        //索引
        private int index = 0;
        //共有记录数
        private int count = 1;

        //转到查询窗口标识
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
                MyMessageBox.ShowErrorMessageBox("入库凭证修改窗口加载",ex);
            }
        }

        //初始化宣传品编号ListBox
        private void setP_noList(ListBox listBox)
        {
            BLL.PreInfo preInfo = new psms.BLL.PreInfo();
            preInfoList = preInfo.GetAllPreInfo();
            listBox.DataSource = preInfoList;
            listBox.DisplayMember = "p_no";
            listBox.ValueMember = "p_no";

        }

        //设置页面textBox值
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
                //this.labAcc.Text = "未作帐";
                this.btnInTable_addPreInfo.Enabled = true;
                this.btnInTable_NextTable.Enabled = true;
                this.btnInTable_SaveAndExit.Enabled = true;
            }
            else
            {
                //this.labAcc.Text = "已作帐";
                this.btnInTable_addPreInfo.Enabled = true;
                this.btnInTable_NextTable.Enabled = true;
                this.btnInTable_SaveAndExit.Enabled = true;
            }
            if (data.GoodAcc == 0)
            {
                this.labGoodAcc.Text = "未确认提货";
                this.btnGoodAcc.Enabled = true;
            }
            else
            {
                this.labGoodAcc.Text = "已确认提货";
                this.btnGoodAcc.Enabled = false;
            }
            //初始化相应宣传品

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

        //初始化货源
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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
            }
        }

        private void setGroupUpdateIntableText()
        {
            this.groupBoxUpdateIntable.Text = "凭证信息   当前第" + (index + 1) + "条，共有记录数" + count;
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
                        message = message + "宣传品编号：" + oldData.P_no + "；原入库数量为" + oldData.Qnt + "；修改后入库数量为" + newData.Qnt + "\n";
                    }
                }
                if (!haveNew)
                {
                    message += "宣传品编号：" + oldData.P_no + "；原入库数量为" + oldData.Qnt + "；删除\n";
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
                    message += "宣传品编号：" + newData.P_no + "；入库数量为" + newData.Qnt + "；新增\n";
                }
            }
            if (message == "")
            {
                MyMessageBox.ShowInfoMessageBox("您并没有对原有做出修改，请修改后再点击保存按钮");
                return false;
            }
            if (MessageBox.Show(message, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        //保存
        private bool updateInTableInfo()
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
            aInTableInfoaInTableInfo.InScrpList = this.newInScrpList;
            return new BLL.InTable().updateInTable(aInTableInfoaInTableInfo);


        }

        private void btnInTable_SaveAndExit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "已作帐")
                //{
                //    MessageBox.Show("已作帐凭证不能修改", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //else
               // {
                    if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                    {
                        MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //保存
                    if (messageBoxReturn())
                    {
                        if (updateInTableInfo())
                        {
                            MessageBox.Show("修改入库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inScrpList = newInScrpList;
                        }
                        else
                        {
                            MessageBox.Show("修改入库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.Close();
                    }
               // }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改入库凭证", ex);
            }
        }

        private void btnInTable_NextTable_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "已作帐")
                //{
                //    MessageBox.Show("已作帐凭证不能修改", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //保存

                if (this.dataGridViewIntable_PreInfoList.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (messageBoxReturn())
                {
                    if (updateInTableInfo())
                    {
                        MessageBox.Show("修改入库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inScrpList = newInScrpList;
                    }
                    else
                    {
                        MessageBox.Show("修改入库凭证出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //inScrpList = null;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改入库凭证", ex);
            }
        }

        private void btnInTable_addPreInfo_Click(object sender, EventArgs e)
        {
            try
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
                newInScrpList.Add(data);
                //重新绑定凭证包含宣传品列表
                this.dataGridViewIntable_PreInfoList.DataSource = newInScrpList;
                this.txtInTable_P_no.Text = "";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改入库凭证", ex);
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
                            //从列表中移除
                            newInScrpList.Remove(data);
                            //重新计算凭证结算金额
                            decimal incost = decimal.Parse(this.txtInTableIn_Cost.Text.Trim());
                            this.txtInTableIn_Cost.Text = (incost - data.In_price).ToString();
                            break;
                        }
                    }
                    //
                    //重新绑定凭证包含宣传品列表
                    this.dataGridViewIntable_PreInfoList.DataSource = newInScrpList;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改入库凭证", ex);
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
                //更新下拉列表
                string pno = this.txtInTable_P_no.Text.Trim();
                this.lbInTable_P_no.DataSource = queryPreInfoListbyPno(pno);
                this.lbInTable_P_no.DisplayMember = "p_no";
                this.lbInTable_P_no.ValueMember = "p_no";
                //更新TextBox
                setPreInfoTextValue(pno);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改入库凭证", ex);
            }
        }


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



        //设置宣传品文本框值
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
                MyMessageBox.ShowErrorMessageBox("查询",ex);
            }
        }

        private void btnGoodAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
                if (MessageBox.Show("确认提货？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.InTable().setGoodAcc(in_scrpno))
                    {
                        MessageBox.Show("确认提货成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.labGoodAcc.Text = "已确认提货";
                        this.btnGoodAcc.Enabled = false;
                    }
                    //else
                    //{
                    //    MessageBox.Show("确认提货成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("确认提货",ex);
            }
        }

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
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string in_scrpno = this.txtInTableIn_Scrpno.Text.Trim();
                if (MessageBox.Show("确认删除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.InTable().deleteIntable(in_scrpno))
                    {
                        MyMessageBox.ShowInfoMessageBox("删除成功，库存已恢复");
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
                        MyMessageBox.ShowInfoMessageBox("删除出错了");
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库凭证删除出错了", ex);
            }
        }


        /// <summary>
        /// 退库
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
                                MyMessageBox.ShowInfoMessageBox("退库操作，退库后数量应当小于退库前数量\n" + "宣传品编号：" + oldData.P_no + "；原入库数量为" + oldData.Qnt + "；退库后数量为" + newData.Qnt + "；退库数量为" + (oldData.Qnt - newData.Qnt));
                                return;
                            }
                            haveNew = true;
                            if (oldData.Qnt > newData.Qnt)
                                message = message + "宣传品编号：" + oldData.P_no + "；原入库数量为" + oldData.Qnt + "；退库后数量为" + newData.Qnt + "；退库数量为" + (oldData.Qnt - newData.Qnt) + "\n";
                        }
                    }
                    if (!haveNew)
                    {
                        MyMessageBox.ShowInfoMessageBox("退库操作请不要删除宣传品");
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
                        MyMessageBox.ShowInfoMessageBox("退库操作请不要新增宣传品");
                        return;
                    }
                }

                if (message == "")
                {
                    MyMessageBox.ShowInfoMessageBox("您并没有对原有做出修改，请修改后再点击退库按钮");
                    return;
                }

                if (MessageBox.Show(message, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    if (tuikuInTableInfo())
                    {
                        MessageBox.Show("退库成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inScrpList = newInScrpList;
                    }
                    else
                    {
                        MessageBox.Show("退库出错", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("退库", ex);
            }
        }


        //退库操作
        private bool tuikuInTableInfo()
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
                MyMessageBox.ShowErrorMessageBox("打印入库单",ex);
            }

        }

        private void groupBoxUpdateIntable_Enter(object sender, EventArgs e)
        {

        }

    }
}