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

        //请领单位
        IList<OutInfoData> outInfoList = null;
        //请领单位
        IList<VipInfoData> vipInfoList = null;

        private System.ComponentModel.BindingList<OutScrpInfo> outScrpList = null;
        private System.ComponentModel.BindingList<OutScrpInfo> newOutScrpList = null;
        private IList<PreInfoData> preInfoList = null;
        //出库凭证List
        private IList<OutTableInfo> outTableList = null;
        //索引
        private int index = 0;
        //共有记录数
        private int count = 1;

        //转到查询页面标示
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
                //初始化请领单位
                setOut_ouList();
                //初始化赠送分类
                setVip_ouList();
                //设置DataGrid列顺序
                setDataGridColumnName();
                //初始化宣传品编号ListBox
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
                MyMessageBox.ShowErrorMessageBox("出库凭证修改窗口加载",ex);
            }

        }





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

        private void setGroupUpdateOutTableText()
        {
            this.groupBoxUpdateOuttable.Text = "凭证信息   当前第" + (index + 1) + "条，共有记录数" + count;
        }

        //设置页面textBox值
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
                    // this.labAcc.Text = "未作帐";
                    this.btnOutTable_SaveAndExit.Enabled = true;
                    this.btnOutTable_NextOutTable.Enabled = true;
                    this.btnOutTable_AddPreInfo.Enabled = true;
                }
                else
                {
                    //this.labAcc.Text = "已作帐";

                    this.btnOutTable_SaveAndExit.Enabled = false;
                    this.btnOutTable_NextOutTable.Enabled = false;
                    this.btnOutTable_AddPreInfo.Enabled = false;

                }
                //初始化相应宣传品

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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
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
                MyMessageBox.ShowInfoMessageBox("没有了");
            }
        }

        private void listBoxOutTable_P_no_Click(object sender, EventArgs e)
        {
            this.txtOutTable_P_no.Text = ((ListBox)sender).SelectedValue.ToString().Trim();
        }

        private void txtOutTable_P_no_TextChanged(object sender, EventArgs e)
        {
            //更新下拉列表
            string pno = this.txtOutTable_P_no.Text.Trim();
            this.listBoxOutTable_P_no.DataSource = queryPreInfoListbyPno(pno);
            this.listBoxOutTable_P_no.DisplayMember = "p_no";
            this.listBoxOutTable_P_no.ValueMember = "p_no";
            //更新TextBox
            setOutTable_PreInfoTextValue(pno);
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

        //设置宣传品文本框值
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

        //初始化宣传品编号ListBox
        private void setP_noList(ListBox listBox)
        {
            BLL.PreInfo preInfo = new psms.BLL.PreInfo();
            preInfoList = preInfo.GetAllPreInfo();
            listBox.DataSource = preInfoList;
            listBox.DisplayMember = "p_no";
            listBox.ValueMember = "p_no";

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
                        //从列表中移除
                        newOutScrpList.Remove(data);
                        //重新计算凭证结算金额
                        decimal outcost = decimal.Parse(this.txtOutTable_Out_cost.Text.Trim());
                        this.txtOutTable_Out_cost.Text = (outcost - data.Out_price).ToString();
                        break;
                    }
                }
                //
                //重新绑定凭证包含宣传品列表
                this.dataGridViewOutTable_PreInfo.DataSource = newOutScrpList;
            }
        }

        private void btnOutTable_NextOutTable_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.labAcc.Text == "已作帐")
                //{
                //    MessageBox.Show("已作帐凭证不能修改", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                {
                    MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //保存
                if (this.messageBoxReturn())
                {
                    if (updateOutTableInfo())
                    {
                        MessageBox.Show("修改出库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        outScrpList = newOutScrpList;
                    }
                    else
                    {
                        MessageBox.Show("修改出库凭证出错,注意不要重复保存", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改出库凭证", ex);
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
                //if (this.labAcc.Text == "已作帐")
                //{
                //    MessageBox.Show("已作帐凭证不能修改", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                //else
                //{
                    if (this.dataGridViewOutTable_PreInfo.RowCount == 0)
                    {
                        MessageBox.Show("请给凭证添加宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //保存
                    if (messageBoxReturn())
                    {
                        if (updateOutTableInfo())
                        {
                            MessageBox.Show("修改出库凭证成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            outScrpList = newOutScrpList;
                        }
                        else
                        {
                            MessageBox.Show("修改出库凭证出错,注意不要重复保存", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        this.Close();
                    }
                //}
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改出库凭证", ex);
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
                MyMessageBox.ShowErrorMessageBox("出库查询",ex);
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
                        message = message + "宣传品编号：" + oldData.P_no + "；原出库数量为" + oldData.Qnt + "；修改后出库数量为" + newData.Qnt + "\n";
                    }
                }
                if (!haveNew)
                {
                    message += "宣传品编号：" + oldData.P_no + "；原出库数量为" + oldData.Qnt + "；删除\n";
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
                    message += "宣传品编号：" + newData.P_no + "；出库数量为" + newData.Qnt + "；新增\n";
                }
            }
            if (MessageBox.Show(message, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        //保存
        private bool updateOutTableInfo()
        {
            
            if (this.outScrpList != null)
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
                //        MessageBox.Show("请先输入凭证编号", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "请先输入凭证编号");
                //    }
                //    else
                //    {
                //        this.errorProvider.SetError(this.txtOutTable_Out_scrpno, "");
                //        //启用添加宣传品
                //        setOutTable_AddPreInfoEnable(true);
                //        //初始化宣传品ArrayList

                //        //设置outTable_isFirstAddPreInfo = false;
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
                        MessageBox.Show("数量请输入整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.errorProvider.SetError(this.txtOutTable_Qnt, "数量请输入整数");
                        Log.WriteLog("出库修改行636：" + ex);
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
                    newOutScrpList.Add(data);
                    //重新绑定凭证包含宣传品列表
                    this.dataGridViewOutTable_PreInfo.DataSource = newOutScrpList;


                    //清空TextBox等待用户下一输入
                    setOutTable_PreInfoTextBoxValueFromProInfo(null);
                    this.txtOutTable_P_no.Text = "";
                //}
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库添加宣传品",ex);
            }
        }

        //设出库宣传品各个控件是否启用
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
            //更新下拉列表
            string pname = this.txtOutTable_P_name.Text.Trim();
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
                if (this.chk_word_out.Checked)
                    WordHelper.OpenAndWriteWordForOut1(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                else
                    WordHelper.OpenAndWriteWordForOut2(this.outScrpList, outUn, vipUn, remark, outscrpNo, outDate);
                


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("打印出库单",ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                string out_scrpno = this.txtOutTable_Out_scrpno.Text.Trim();
                if (MessageBox.Show("确认删除？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new BLL.OutTable().deleteOutTable(out_scrpno))
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
                MyMessageBox.ShowErrorMessageBox("出库凭证删除出错了", ex);
            }
        }






    }
}