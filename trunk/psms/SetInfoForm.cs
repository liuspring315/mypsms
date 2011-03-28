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
    public partial class SetInfoForm : Form
    {

        public SetInfoForm()
        {
            InitializeComponent();
        }

        //tabControl标签属性
        public TabControl SetInfoTabControl
        {
            get { return this.setInfotabControl; }
        }

        //Form_load
        private void SetInfoForm_Load(object sender, EventArgs e)
        {
            //初始化数据
            DataLoadBySelectTab();
        }

        //当改变标签选中时事件
        private void setInfotabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化数据
            DataLoadBySelectTab();
        }

        //初始化数据
        private void DataLoadBySelectTab()
        {
            //打开宣传品信息标签 初始化数据
            if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[0])
            {
                setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                setTextValueFromDataGrid();
            }
            //打开宣传品系列标签 初始化数据
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[1])
            {
                setPreTypeDataGridViewDataSource();
                setPreTypeTextValueFromDataGrid();
            }
            //打开入库单位标签 初始化数据
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[2])
            {
                setInInfoDataGridViewDataSource();
                setInInfoTextValueFromDataGrid();
            }
            //打开收货单位标签 初始化数据
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[3])
            {
                setOutInfoDataGridViewDataSource();
                setOutInfoTextValueFromDataGrid();
            }
            //打开请领单位标签 初始化数据
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[4])
            {
                setVipInfoDataGridViewDataSource();
                setVipInfoTextValueFromDataGrid();
            }
            //打开用户信息标签 初始化数据
            else if (this.setInfotabControl.SelectedTab == this.setInfotabControl.TabPages[5])
            {
                setLoginUserDataGridViewLoginUserDataSource();
                setLoginUserTextValueFromDataGrid();
            }
            
        }

        //当此窗口关闭显示父窗口
        private void SetInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        #region 宣传品信息维护

        #region 宣传品信息私有字段
        //宣传品id
        private int preId;
        //修改、新增标志
        private string upOrAdd = "";
        #endregion

        #region 为宣传品信息DataGridView绑定数据源
        private void setPreDataGridViewDataSource(IList<PreInfoData> data)
        {
            try
            {
                this.PreDataGridView.DataSource = data;
                this.PreDataGridView.Columns["p_no"].DisplayIndex = 0;
                this.PreDataGridView.Columns["pretype"].DisplayIndex = 1;
                this.PreDataGridView.Columns["p_name"].DisplayIndex = 2;
                this.PreDataGridView.Columns["unit"].DisplayIndex = 3;
                this.PreDataGridView.Columns["unit_price"].DisplayIndex = 4;
                this.PreDataGridView.Columns["cost_price"].DisplayIndex = 5;
                this.PreDataGridView.Columns["acc_qnt"].DisplayIndex = 6;
                this.PreDataGridView.Columns["id"].DisplayIndex = 7;

                //记录数
                this.groupBoxPreInfo.Text = "共有宣传品记录" + data.Count + "条";

                //初始化宣传品系列下拉列表
                this.cobPreType.DataSource = new BLL.PreType().GetAllPreTypeInfo();
                this.cobPreType.DisplayMember = "typeName";
                this.cobPreType.ValueMember = "typeName";

                BindingList < PreTypeInfo >  preTypeList = new BLL.PreType().GetAllPreTypeInfo();
                preTypeList.Add(new PreTypeInfo(0,""));
                this.comboBoxQueryPreType.DataSource = preTypeList;
                this.comboBoxQueryPreType.DisplayMember = "typeName";
                this.comboBoxQueryPreType.ValueMember = "typeName";
                this.comboBoxQueryPreType.SelectedIndex = preTypeList.Count - 1;

            }
            catch (Exception ex)
            {
                Log.WriteLog("为宣传品信息DataGridView绑定数据源，错误信息：" + ex.ToString());
            }
            
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void PageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnPrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.PreDataGridView, DataGirdViewUtil.LAST);
                }

                setTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                Log.WriteLog("导航按钮单击事件，错误信息：" + ex.ToString());
            }


        }

        //修改按钮
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.PreDataGridView.RowCount > 0)
                {
                    this.upOrAdd = StrUtil.UP;
                    //TextBox Enabled
                    setTxtEnabled(true);
                    //RowBtn Enabled
                    setBtnRow(false);
                    //Save and Cancel Button
                    setBtnSaveCancel(true);

                    this.txtP_no.Enabled = false;
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("没有要修改的记录");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("修改按钮，错误信息：" + ex.ToString());
            }

        }

        //删除按钮事件
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.preId == 0)
                {
                    MessageBox.Show("请选择要删除的宣传品", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此宣传品记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        BLL.PreInfo preInfoBll = new BLL.PreInfo();
                        if (preInfoBll.haveInOutScrpByPno(this.preId))
                        {
                            MessageBox.Show("要删除的宣传品在入库凭证或在出库凭证中有记录，不能被删除", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        preInfoBll.deletePerInfo(this.preId);
                        MessageBox.Show("删除宣传品记录成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                        setTextValueFromDataGrid();
                        btnCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("删除宣传品记录", ex);
            }
        }

        //新增按钮事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //TextBox Enabled
                setTxtEnabled(true);
                //RowBtn Enabled
                setBtnRow(false);
                //Save and Cancel Button
                setBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setTxtEmpty();
                this.upOrAdd = StrUtil.ADD;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("新增按钮事件", ex);
                return;
            }
        }

        //保存按钮事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatePreInfoText())
                {

                    string p_no = this.txtP_no.Text.Trim();
                    string p_name = this.txtP_name.Text.Trim();
                    string unit = this.comboUnit.Text.ToString().Trim();
                    string unit_price = this.txtUnit_price.Text.Trim();
                    string cost_price = this.txtCost_price.Text.Trim();
                    string acc_qnt = this.txtAcc_qnt.Text.Trim();
                    string pretype = this.cobPreType.Text.ToString();

                    //
                    PreInfoData data = new PreInfoData(preId, p_no, pretype, p_name, unit, Decimal.Parse(unit_price), Decimal.Parse(cost_price), 0);


                    BLL.PreInfo preInfoBll = new psms.BLL.PreInfo();
                    if (this.upOrAdd == StrUtil.UP)
                    {
                        try
                        {
                            data.Acc_qnt = Int32.Parse(acc_qnt);
                            preInfoBll.updatePreInfo(data);
                            MessageBox.Show("修改宣传品成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowErrorMessageBox("修改宣传品", ex);
                            return;
                        }

                    }
                    else if (this.upOrAdd == StrUtil.ADD)
                    {
                        try
                        {
                            preInfoBll.insertPreInfo(data);
                            this.preId = 0;
                            MessageBox.Show("新增宣传品成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowErrorMessageBox("新增宣传品", ex);
                            return;
                        }
                    }

                    try
                    {
                        //重新绑定数据
                        setPreDataGridViewDataSource(new BLL.PreInfo().GetAllPreInfo());
                        btnCancel_Click(sender, e);
                        //选中更新的行
                        DataGirdViewUtil.selectedRowByValue(this.PreDataGridView, "p_no", data.P_no);
                    }
                    catch (Exception ex)
                    {
                        MyMessageBox.ShowErrorMessageBox("重新绑定数据", ex);
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("保存宣传品", ex);
                return;
            }
            
        }

        //取消按钮事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.upOrAdd = "";
                //TextBox Enabled
                setTxtEnabled(false);
                //RowBtn Enabled
                setBtnRow(true);
                //Save and Cancel Button
                setBtnSaveCancel(false);

                this.btnUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.getRowById(this.PreDataGridView, preId, "id");
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("取消按钮事件", ex);
                return;
            }

        }

        //单击DataGrid单元格事件
        private void PreDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setTextValueFromDataGrid();
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("取消按钮事件", ex);
                return;
            }
        }

        //搜索框获得焦点
        private void txtPreInfoQueryPNo_Enter(object sender, EventArgs e)
        {
            if (this.txtPreInfoQueryPNo.Text == "输入宣传品编号模糊搜索")
            {
                this.txtPreInfoQueryPNo.Text = "";
            }
        }
        //搜索按钮事件
        private void btnPreInfoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                
                //IList<PreInfoData> data = new List<PreInfoData>();
                string pno = this.txtPreInfoQueryPNo.Text.Trim();
                StringBuilder condition = new StringBuilder(" where 1=1 ");
                if (pno != "" && pno != "输入宣传品编号模糊搜索")
                {
                    condition.Append(" and  (P_NO + p_NAME LIKE '%").Append(pno).Append("%')");

                }
                if (comboBoxQueryPreType.Text.Trim() != "")
                {
                    condition.Append(" and  (pretype = '").Append(comboBoxQueryPreType.Text.Trim()).Append("')");
                }
                //成本价
                if (this.txtCostPrice1.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCostPrice1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("成本价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.cost_price >= ").Append(this.txtCostPrice1.Text.Trim());
                }
                if (this.txtCostPrice2.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtCostPrice2.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("成本价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.cost_price <= ").Append(this.txtCostPrice2.Text.Trim());
                }
                //销售价
                if (this.txtUnitPrice1.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnitPrice1.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("销售价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.unit_price >= ").Append(this.txtUnitPrice1.Text.Trim());
                }
                if (this.txtUnitPrice2.Text.Trim() != "")
                {
                    try
                    {
                        Decimal.Parse(this.txtUnitPrice2.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("销售价请输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    condition.Append(" and p.unit_price <= ").Append(this.txtUnitPrice2.Text.Trim());
                }
                BLL.PreInfo preInfoBll = new psms.BLL.PreInfo();
                IList<PreInfoData> preInfoData = preInfoBll.GetAllPreInfoByCondition(condition.ToString());
                setPreDataGridViewDataSource(preInfoData);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("搜索", ex);
                return;
            }
        }

        #endregion
        
        #region 输入验证
        private void txtP_no_Validating(object sender, CancelEventArgs e)
        {
        }
        private bool validatePreInfoText()
        {
            string p_no = this.txtP_no.Text.Trim();
            if (p_no == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_no, "宣传品编号不能空");
                MessageBox.Show("宣传品编号不能空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (new BLL.PreInfo().GetPreInfoByNo(p_no, preId) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "此宣传品编号已经存在");
                    MessageBox.Show("此宣传品编号已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (p_no.Length > 20)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "宣传品编号不能多于20字");
                    MessageBox.Show("宣传品编号不能多于20字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtP_no, "");
                }
            }
            string p_name = this.txtP_name.Text.Trim();
            if (p_name == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "宣传品名称不能为空");
                MessageBox.Show("宣传品名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(p_name.Length > 50)
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "宣传品名称不能多于50字");
                MessageBox.Show("宣传品名称不能多于50字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.SetPreInfoerrorProvider.SetError(this.txtP_name, "");
            }
            try
            {
                Double.Parse(this.txtUnit_price.Text.Trim());
                this.SetPreInfoerrorProvider.SetError(this.txtUnit_price, "");
            }
            catch
            {
                this.SetPreInfoerrorProvider.SetError(this.txtUnit_price, "销售价应输入数字");
                MessageBox.Show("销售价应输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                Double.Parse(this.txtCost_price.Text.Trim());
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "");
            }
            catch
            {
                this.SetPreInfoerrorProvider.SetError(this.txtCost_price, "成本价应输入数字");
                MessageBox.Show("成本价应输入数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnSave_Validating(object sender, CancelEventArgs e)
        {
            txtP_no_Validating(sender, e);
        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setTextValueFromDataGrid()
        {
            try
            {
                if (this.PreDataGridView.RowCount > 0)
                {
                    this.txtP_no.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "p_no").Trim();
                    this.txtP_name.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "p_name").Trim();
                    this.comboUnit.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "unit").Trim();
                    this.txtUnit_price.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "unit_price").Trim();
                    this.txtCost_price.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "cost_price").Trim();
                    this.txtAcc_qnt.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "acc_qnt").Trim();
                    this.cobPreType.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "pretype").Trim();
                    this.preId = Int32.Parse(DataGirdViewUtil.getSelectedRowsCellValue(this.PreDataGridView, "id").Trim());
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("DataGrid数据导航显示在TextBox", ex);
            }
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setBtnSaveCancel(bool enable)
        {
            this.btnSave.Enabled = enable;
            this.btnCancel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setTxtEnabled(bool enable)
        {
            this.txtP_no.Enabled = enable;
            this.txtP_name.Enabled = enable;
            this.comboUnit.Enabled = enable;
            this.txtUnit_price.Enabled = enable;
            this.txtCost_price.Enabled = enable;
            this.txtAcc_qnt.Enabled = enable;
            this.cobPreType.Enabled = enable;
        }

        #endregion

        #region 使文本框为空
        private void setTxtEmpty()
        {
            this.txtP_no.Text = "";
            this.txtP_name.Text = "";
            this.comboUnit.SelectedItem = this.comboUnit.Items[this.comboUnit.FindString("套")];
            this.txtUnit_price.Text = "";
            this.txtCost_price.Text = "0.00";
            this.txtAcc_qnt.Text = "0";
            this.cobPreType.SelectedIndex = 0;
        }
        #endregion

        #region 当航按钮的启用设置
        private void setBtnRow(bool enable)
        {
            this.btnLast.Enabled = enable;
            this.btnNext.Enabled = enable;
            this.btnOne.Enabled = enable;
            this.btnPrv.Enabled = enable;
            this.btnUpdate.Enabled = enable;
            this.btnAdd.Enabled = enable;
            this.btnDel.Enabled = enable;
            this.PreDataGridView.Enabled = enable;
            
        }
        #endregion
        
        #endregion

        #region 入库单位信息维护

        private string inInfoUpOrAdd = "";

        #region 为入库单位信息DataGridView绑定数据源

        private void setInInfoDataGridViewDataSource()
        {
            BLL.InInfo inInfoBll = new psms.BLL.InInfo();
            IList<InInfoData> data = inInfoBll.GetAllInInfo();
            this.dataGridViewInInfo.DataSource = data;
            this.dataGridViewInInfo.Columns["in_ou"].DisplayIndex = 0;

            this.groupBoxInInfo.Text = "共有入库单位记录" + data.Count + "条";
        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setInInfoTextValueFromDataGrid()
        {
            this.txtIn_ou.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInInfo, "in_ou").Trim();
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void InInfoPageButton_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (btnName == "btnInInfoOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.ONE);
            }
            else if (btnName == "btnInInfoPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.PRV);
            }
            else if (btnName == "btnInInfoNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.NEXT);
            }
            else if (btnName == "btnInInfoLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo, DataGirdViewUtil.LAST);
            }

            setInInfoTextValueFromDataGrid();


        }

        //修改按钮
        private void btnInInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setInInfoTxtEnabled(true);
                //RowBtn Enabled
                setInInfoBtnRow(false);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库单位信息维护修改按钮单击事件", ex);
            }

        }

        //删除按钮事件
        private void btnInInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIn_ou.Text.Trim() == "")
                {
                    MessageBox.Show("请选择要删除的入库单位", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此入库单位记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.InInfo().deleteInInfo(this.txtIn_ou.Text.Trim());
                        MessageBox.Show("删除入库单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setInInfoDataGridViewDataSource();
                        btnInInfoCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库单位删除事件", ex);
            }
        }

        //新增按钮事件
        private void btnInInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setInInfoTxtEnabled(true);
                //RowBtn Enabled
                setInInfoBtnRow(false);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setInInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库单位新增事件", ex);
            }
        }

        //保存按钮事件
        private void btnInInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                string in_ou = this.txtIn_ou.Text.Trim();
                if (in_ou == "")
                {
                    MessageBox.Show("入库单位名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (in_ou.Length > 10)
                {
                    MessageBox.Show("入库单位名称不能多于10个字，现在是" + in_ou.Length + "个字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.InInfo inInfoBll = new psms.BLL.InInfo();
                if (inInfoBll.GetInInfoByInou(in_ou) > 0)
                {
                    MessageBox.Show("入库单位名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.inInfoUpOrAdd == StrUtil.UP)
                {
                    string in_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewInInfo, "in_ou").Trim();
                    inInfoBll.updateInInfo(in_ou, in_ou_old);
                    MessageBox.Show("修改入库单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.inInfoUpOrAdd == StrUtil.ADD)
                {
                    inInfoBll.insertInInfo(in_ou);
                    MessageBox.Show("新增入库单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //重新绑定数据
                setInInfoDataGridViewDataSource();
                btnInInfoCancel_Click(sender, e);
                //选中记录
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewInInfo, "in_ou",in_ou);
                setInInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库单位保存事件", ex);
            }
        }

        //取消按钮事件
        private void btnInInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.inInfoUpOrAdd = "";
                //TextBox Enabled
                setInInfoTxtEnabled(false);
                //RowBtn Enabled
                setInInfoBtnRow(true);
                //Save and Cancel Button
                setInInfoBtnSaveCancel(false);

                this.btnInInfoUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewInInfo,-1);
                setInInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库单位取消事件", ex);
            }

        }
        //单击DataGrid单元格事件
        private void dataGridViewInInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setInInfoTextValueFromDataGrid();
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setInInfoBtnSaveCancel(bool enable)
        {
            this.btnInInfoSave.Enabled = enable;
            this.btnInInfoCancel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setInInfoTxtEnabled(bool enable)
        {
            this.txtIn_ou.Enabled = enable;
        }

        #endregion

        #region 使文本框为空
        private void setInInfoTxtEmpty()
        {
            this.txtIn_ou.Text = "";
        }
        #endregion

        #region dao航按钮的启用设置
        private void setInInfoBtnRow(bool enable)
        {
            this.btnInInfoLast.Enabled = enable;
            this.btnInInfoNext.Enabled = enable;
            this.btnInInfoOne.Enabled = enable;
            this.btnInInfoPrv.Enabled = enable;
            this.btnInInfoAdd.Enabled = enable;
            this.btnInInfoUpdate.Enabled = enable;
            this.btnInInfoDelete.Enabled = enable;
            this.dataGridViewInInfo.Enabled = enable;
        }
        #endregion

        #endregion

        #region 宣传品系列信息维护

        private string preTypeUpOrAdd = "";

        #region 为宣传品系列信息DataGridView绑定数据源

        private void setPreTypeDataGridViewDataSource()
        {
            BLL.PreType preTypeBll = new psms.BLL.PreType();
            
            IList<PreTypeInfo> data = preTypeBll.GetAllPreTypeInfo();
            this.dataGridViewPreType.DataSource = data;
            this.dataGridViewPreType.Columns["typeName"].DisplayIndex = 0;
            this.dataGridViewPreType.Columns["code"].DisplayIndex = 1;

            this.groupBoxPerType.Text = "共有宣传品系列记录" + data.Count +"条";
        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setPreTypeTextValueFromDataGrid()
        {
            this.txtPreType.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "typename").Trim();
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void preTypePageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnPreTypeOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnPreTypePrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnPreTypeNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnPreTypeLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewPreType, DataGirdViewUtil.LAST);
                }

                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("导航按钮单击事件", ex);
            }


        }

        //修改按钮
        private void btnPreTypeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setPreTypeTxtEnabled(true);
                //RowBtn Enabled
                setPreTypeBtnRow(false);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("修改按钮", ex);
            }

        }

        //删除按钮事件
        private void btnPreTypeDel_Click(object sender, EventArgs e)
        {
            try
            {
                string typeid = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "code").Trim();
                if (typeid == "")
                {
                    MessageBox.Show("请选择要删除的宣传品系列", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此宣传品系列记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.PreType().deletePerType(Int32.Parse(typeid));
                        MessageBox.Show("删除宣传品系列成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setPreTypeDataGridViewDataSource();
                        btnPreTypeCancel_Click(sender, e);
                        setPreTypeTextValueFromDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品系列删除按钮事件", ex);
            }
        }

        //新增按钮事件
        private void btnPreTypeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setPreTypeTxtEnabled(true);
                //RowBtn Enabled
                setPreTypeBtnRow(false);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setPreTypeTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品系列新增按钮事件", ex);
            }
        }

        //保存按钮事件
        private void btnPreTypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                string pretype = this.txtPreType.Text.Trim();
                if (pretype == "")
                {
                    MessageBox.Show("宣传品系列名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (pretype.Length > 10)
                {
                    MessageBox.Show("宣传品系列名称不能多于10个字，现在是" + pretype.Length + "个字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.PreType preTypeBll = new psms.BLL.PreType();
                if (preTypeBll.GetPreTypeByTypeName(pretype) > 0)
                {
                    MessageBox.Show("宣传品系列名称已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.preTypeUpOrAdd == StrUtil.UP)
                {
                    string typeid = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewPreType, "code").Trim();
                    preTypeBll.updatePreType(pretype, Int32.Parse(typeid));
                    MessageBox.Show("修改宣传品系列成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.preTypeUpOrAdd == StrUtil.ADD)
                {
                    preTypeBll.insertPreType(pretype);
                    MessageBox.Show("新增宣传品系列成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //重新绑定数据
                setPreTypeDataGridViewDataSource();
                btnPreTypeCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewPreType, "typename", pretype);
                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品系列保存按钮事件", ex);
            }
        }

        //取消按钮事件
        private void btnPreTypeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.preTypeUpOrAdd = "";
                //TextBox Enabled
                setPreTypeTxtEnabled(false);
                //RowBtn Enabled
                setPreTypeBtnRow(true);
                //Save and Cancel Button
                setPreTypeBtnSaveCancel(false);

                this.btnPreTypeUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.getRowById(this.dataGridViewPreType, 0, "typeid");
                setPreTypeTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品系列取消按钮事件", ex);
            }

        }
        //单击DataGrid单元格事件
        private void dataGridViewPreType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setPreTypeTextValueFromDataGrid();
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品系列单击DataGrid单元格事件", ex);
            }
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setPreTypeBtnSaveCancel(bool enable)
        {
            this.btnPreTypeSave.Enabled = enable;
            this.btnPreTypeConcel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setPreTypeTxtEnabled(bool enable)
        {
            this.txtPreType.Enabled = enable;
        }

        #endregion

        #region 使文本框为空
        private void setPreTypeTxtEmpty()
        {
            this.txtPreType.Text = "";
        }
        #endregion

        #region dao航按钮的启用设置
        private void setPreTypeBtnRow(bool enable)
        {
            this.btnPreTypeLast.Enabled = enable;
            this.btnPreTypeNext.Enabled = enable;
            this.btnPreTypeOne.Enabled = enable;
            this.btnPreTypePrv.Enabled = enable;
            this.btnPreTypeAdd.Enabled = enable;
            this.btnPreTypeDel.Enabled = enable;
            this.btnPreTypeUpdate.Enabled = enable;
            this.dataGridViewPreType.Enabled = enable;
        }
        #endregion



        #endregion

        #region 收货单位信息维护

        private string outInfoUpOrAdd = "";

        #region 为请领单位信息DataGridView绑定数据源

        private void setOutInfoDataGridViewDataSource()
        {
            BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
            IList<OutInfoData> data = outInfoBll.GetAllOutInfo();
            this.dataGridViewOutInfo.DataSource = data;
            this.dataGridViewOutInfo.Columns["out_ou"].DisplayIndex = 0;

            this.groupBoxOutInfo.Text = "共有请领单位记录" + data.Count + "条";
        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setOutInfoTextValueFromDataGrid()
        {
            this.txtOutInfo.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewOutInfo, "out_ou").Trim();
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void OutInfoPageButton_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (btnName == "btnOutInfoOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.ONE);
            }
            else if (btnName == "btnOutInfoPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.PRV);
            }
            else if (btnName == "btnOutInfoNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.NEXT);
            }
            else if (btnName == "btnOutInfoLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, DataGirdViewUtil.LAST);
            }

            setOutInfoTextValueFromDataGrid();


        }

        //修改按钮
        private void btnOutInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setOutInfoTxtEnabled(true);
                //RowBtn Enabled
                setOutInfoBtnRow(false);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("请领单位修改按钮单击事件", ex);
            }

        }

        //删除按钮事件
        private void btnOutInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtOutInfo.Text.Trim() == "")
                {
                    MessageBox.Show("请选择要删除的请领单位", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此请领单位记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.OutInfo().deleteOutInfo(this.txtOutInfo.Text.Trim());
                        MessageBox.Show("删除请领单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setOutInfoDataGridViewDataSource();
                        btnOutInfoCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("请领单位删除按钮单击事件", ex);
            }
        }

        //新增按钮事件
        private void btnOutInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setOutInfoTxtEnabled(true);
                //RowBtn Enabled
                setOutInfoBtnRow(false);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setOutInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("请领单位新增按钮单击事件", ex);
            }
        }

        //保存按钮事件
        private void btnOutInfoSave_Click(object sender, EventArgs e)
        {
            try
            {
                string out_ou = this.txtOutInfo.Text.Trim();
                if (out_ou == "")
                {
                    MessageBox.Show("请领单位名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (out_ou.Length > 10)
                {
                    MessageBox.Show("请领单位名称不能多于10个字，现在是" + out_ou.Length + "个字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.OutInfo outInfoBll = new psms.BLL.OutInfo();
                if (outInfoBll.GetOutInfoByOutou(out_ou) > 0)
                {
                    MessageBox.Show("请领单位名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.outInfoUpOrAdd == StrUtil.UP)
                {
                    string out_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewOutInfo, "out_ou").Trim();
                    outInfoBll.updateOutInfo(out_ou, out_ou_old);
                    MessageBox.Show("修改请领单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.outInfoUpOrAdd == StrUtil.ADD)
                {
                    outInfoBll.insertOutInfo(out_ou);
                    MessageBox.Show("新增请领单位成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //重新绑定数据
                setOutInfoDataGridViewDataSource();
                btnOutInfoCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewOutInfo, "out_ou", out_ou);
                setOutInfoTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("请领单位保存按钮单击事件", ex);
            }
        }

        //取消按钮事件
        private void btnOutInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.outInfoUpOrAdd = "";
                //TextBox Enabled
                setOutInfoTxtEnabled(false);
                //RowBtn Enabled
                setOutInfoBtnRow(true);
                //Save and Cancel Button
                setOutInfoBtnSaveCancel(false);

                this.btnOutInfoUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewOutInfo, -1);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("请领单位取消按钮单击事件", ex);
            }

        }
        //单击DataGrid单元格事件
        private void dataGridViewOutInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setOutInfoTextValueFromDataGrid();
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setOutInfoBtnSaveCancel(bool enable)
        {
            this.btnOutInfoSave.Enabled = enable;
            this.btnOutInfoCancel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setOutInfoTxtEnabled(bool enable)
        {
            this.txtOutInfo.Enabled = enable;
        }

        #endregion

        #region 使文本框为空
        private void setOutInfoTxtEmpty()
        {
            this.txtOutInfo.Text = "";
        }
        #endregion

        #region dao航按钮的启用设置
        private void setOutInfoBtnRow(bool enable)
        {
            this.btnOutInfoLast.Enabled = enable;
            this.btnOutInfoNext.Enabled = enable;
            this.btnOutInfoOne.Enabled = enable;
            this.btnOutInfoPrv.Enabled = enable;
            this.btnOutInfoAdd.Enabled = enable;
            this.btnOutInfoUpdate.Enabled = enable;
            this.btnOutInfoDel.Enabled = enable;
            this.dataGridViewOutInfo.Enabled = enable;
        }
        #endregion

        #endregion

        #region 请领单位信息维护

        private string vipInfoUpOrAdd = "";

        #region 为请领单位信息DataGridView绑定数据源

        private void setVipInfoDataGridViewDataSource()
        {
            BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
            IList<VipInfoData> data = vipInfoBll.GetAllVipInfo();
            this.dataGridViewVipInfo.DataSource = data;
            this.dataGridViewVipInfo.Columns["vip_ou"].DisplayIndex = 0;

            this.groupBoxVipInfo.Text = "共有赠送分类记录" + data.Count + "条";
        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setVipInfoTextValueFromDataGrid()
        {
            this.txtVipInfo.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewVipInfo, "vip_ou").Trim();
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void VipInfoPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string btnName = ((Button)sender).Name;
                if (btnName == "btnVipInfoOne")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.ONE);
                }
                else if (btnName == "btnVipInfoPrv")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.PRV);
                }
                else if (btnName == "btnVipInfoNext")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.NEXT);
                }
                else if (btnName == "btnVipInfoLast")
                {
                    DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo, DataGirdViewUtil.LAST);
                }

                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类导航单击事件", ex);
            }


        }

        //修改按钮
        private void btnVipInfoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setVipInfoTxtEnabled(true);
                //RowBtn Enabled
                setVipInfoBtnRow(false);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类修改按钮单击事件", ex);
            }
        }

        //删除按钮事件
        private void btnVipInfoDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtVipInfo.Text.Trim() == "")
                {
                    MessageBox.Show("请选择要删除的赠送分类", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此赠送分类记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.VipInfo().deleteVipInfo(this.txtVipInfo.Text.Trim());
                        MessageBox.Show("删除赠送分类成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setVipInfoDataGridViewDataSource();
                        btnVipInfoCancel_Click(sender, e);
                        setVipInfoTextValueFromDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类删除按钮单击事件", ex);
            }
        }

        //新增按钮事件
        private void btnVipInfoAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = StrUtil.ADD;
                //TextBox Enabled
                setVipInfoTxtEnabled(true);
                //RowBtn Enabled
                setVipInfoBtnRow(false);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(true);

                this.btnUpdate.Enabled = false;
                setVipInfoTxtEmpty();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类新增按钮单击事件", ex);
            }
        }

        //保存按钮事件
        private void btnVipInfoSave_Click(object sender, EventArgs e)
        {
            try
            {

                string vip_ou = this.txtVipInfo.Text.Trim();
                if (vip_ou == "")
                {
                    MessageBox.Show("赠送分类名称不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (vip_ou.Length > 10)
                {
                    MessageBox.Show("赠送分类名称不能多于10个字，现在是" + vip_ou.Length + "个字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BLL.VipInfo vipInfoBll = new psms.BLL.VipInfo();
                if (vipInfoBll.GetVipInfoByVipou(vip_ou) > 0)
                {
                    MessageBox.Show("赠送分类名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.vipInfoUpOrAdd == StrUtil.UP)
                {
                    string vip_ou_old = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewVipInfo, "vip_ou").Trim();
                    vipInfoBll.updateVipInfo(vip_ou, vip_ou_old);
                    MessageBox.Show("修改赠送分类成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.vipInfoUpOrAdd == StrUtil.ADD)
                {
                    vipInfoBll.insertVipInfo(vip_ou);
                    MessageBox.Show("新增赠送分类成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //重新绑定数据
                setVipInfoDataGridViewDataSource();
                btnVipInfoCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewVipInfo, "vip_ou", vip_ou);
                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类保存按钮单击事件", ex);
            }
        }

        //取消按钮事件
        private void btnVipInfoCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.vipInfoUpOrAdd = "";
                //TextBox Enabled
                setVipInfoTxtEnabled(false);
                //RowBtn Enabled
                setVipInfoBtnRow(true);
                //Save and Cancel Button
                setVipInfoBtnSaveCancel(false);

                this.btnVipInfoUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewVipInfo,-1);
                setVipInfoTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类取消按钮单击事件", ex);
            }

        }
        //单击DataGrid单元格事件
        private void dataGridViewVipInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setVipInfoTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("赠送分类单击单元格按钮单击事件", ex);
            }
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setVipInfoBtnSaveCancel(bool enable)
        {
            this.btnVipInfoSave.Enabled = enable;
            this.btnVipInfoCancel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setVipInfoTxtEnabled(bool enable)
        {
            this.txtVipInfo.Enabled = enable;
        }

        #endregion

        #region 使文本框为空
        private void setVipInfoTxtEmpty()
        {
            this.txtVipInfo.Text = "";
        }
        #endregion

        #region dao航按钮的启用设置
        private void setVipInfoBtnRow(bool enable)
        {
            this.btnVipInfoLast.Enabled = enable;
            this.btnVipInfoNext.Enabled = enable;
            this.btnVipInfoOne.Enabled = enable;
            this.btnVipInfoPrv.Enabled = enable;
            this.btnVipInfoAdd.Enabled = enable;
            this.btnVipInfoUpdate.Enabled = enable;
            this.btnVipInfoDel.Enabled = enable;
            this.dataGridViewVipInfo.Enabled = enable;
        }
        #endregion


        #endregion

        #region 用户信息维护

        #region 用户信息私有字段
        //用户id
        private int userId;
        //修改、新增标志
        private string loginUserUpOrAdd = "";
        #endregion

        #region 为用户信息DataGridView绑定数据源
        private void setLoginUserDataGridViewLoginUserDataSource()
        {
            BLL.UserInfo userInfoBll = new psms.BLL.UserInfo();
            IList<UserInfoData> data = userInfoBll.GetAllUserInfo();
            this.dataGridViewLoginUser.DataSource = data;
            this.dataGridViewLoginUser.Columns["name"].DisplayIndex = 0;
            this.dataGridViewLoginUser.Columns["username"].DisplayIndex = 1;
            this.dataGridViewLoginUser.Columns["power"].DisplayIndex = 2;
            this.dataGridViewLoginUser.Columns["password"].DisplayIndex = 3;
            this.dataGridViewLoginUser.Columns["loginUserId"].DisplayIndex = 4;

            this.groupBoxLoginUser.Text = "共有用户记录" + data.Count + "条";

            //初始化用户quanxian下拉列表
           
        }
        #endregion

        #region 事件
        //导航按钮单击事件
        private void UserLoginPageButton_Click(object sender, EventArgs e)
        {
            string btnLoginUserName = ((Button)sender).Name;
            if (btnLoginUserName == "btnLoginUserOne")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.ONE);
            }
            else if (btnLoginUserName == "btnLoginUserPrv")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.PRV);
            }
            else if (btnLoginUserName == "btnLoginUserNext")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.NEXT);
            }
            else if (btnLoginUserName == "btnLoginUserLast")
            {
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, DataGirdViewUtil.LAST);
            }

            setLoginUserTextValueFromDataGrid();


        }

        //修改按钮
        private void btnLoginUserUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.loginUserUpOrAdd = StrUtil.UP;
                //TextBox Enabled
                setLoginUserTxtEnabled(true);
                //RowBtn Enabled
                setLoginUserBtnRow(false);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理修改按钮单击事件", ex);
            }

        }

        //删除按钮事件
        private void btnLoginUserDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.userId == 0)
                {
                    MessageBox.Show("请选择要删除的用户", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (MessageBox.Show("确认删除此用户记录？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        new BLL.UserInfo().deleteUserInfo(this.userId);
                        MessageBox.Show("删除用户成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新绑定数据
                        setLoginUserDataGridViewLoginUserDataSource();
                        btnLoginUserCancel_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理删除按钮单击事件", ex);
            }
        }

        //新增按钮事件
        private void btnLoginUserAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //TextBox Enabled
                setLoginUserTxtEnabled(true);
                //RowBtn Enabled
                setLoginUserBtnRow(false);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(true);

                this.btnLoginUserUpdate.Enabled = false;
                setLoginUserTxtEmpty();
                this.loginUserUpOrAdd = StrUtil.ADD;
                this.userId = 0;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理新增按钮单击事件", ex);
            }
        }

        //保存按钮事件
        private void btnLoginUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.txtLoginName.Text.Trim();
                string name = this.txtUserName.Text.Trim();
                string power = this.cobUserPower.Text.ToString();
                string password = this.txtPassword.Text.ToString().Trim();
                string password2 = this.txtPassword2.Text.ToString().Trim();
                if (password != password2)
                {
                    MessageBox.Show("两次密码输入不一致", "出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (new BLL.UserInfo().GetUserInfoByNo(username, userId) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "此用户姓名已经存在");
                    MessageBox.Show("此用户姓名已经存在", "出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "");
                }

                UserInfoData data = new UserInfoData(userId, username, name,password, power);
                BLL.UserInfo userInfoBll = new psms.BLL.UserInfo();
                if (this.loginUserUpOrAdd == StrUtil.UP)
                {
                    userInfoBll.updateUserInfo(data);
                    MessageBox.Show("修改用户成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.loginUserUpOrAdd == StrUtil.ADD)
                {
                    userInfoBll.insertUserInfo(data);
                    this.userId = 0;
                    MessageBox.Show("新增用户成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //重新绑定数据
                setLoginUserDataGridViewLoginUserDataSource();
                btnLoginUserCancel_Click(sender, e);
                DataGirdViewUtil.selectedRowByValue(this.dataGridViewLoginUser, "username", username);
                setLoginUserTextValueFromDataGrid();

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理保存按钮单击事件", ex);
            }
        }

        //取消按钮事件
        private void btnLoginUserCancel_Click(object sender, EventArgs e)
        {
            try
            {

                this.loginUserUpOrAdd = "";
                //TextBox Enabled
                setLoginUserTxtEnabled(false);
                //RowBtn Enabled
                setLoginUserBtnRow(true);
                //Save and Cancel Button
                setLoginUserBtnSaveCancel(false);

                this.btnLoginUserUpdate.Enabled = true;
                //选中记录
                DataGirdViewUtil.selectedDataGridViewRow(this.dataGridViewLoginUser, -1);
                setLoginUserTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理取消按钮单击事件", ex);
            }

        }

        //单击DataGrid单元格事件
        private void DataGridViewLoginUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                setLoginUserTextValueFromDataGrid();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("用户管理单元格按钮单击事件", ex);
            }
        }

        #endregion

        #region 输入验证
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            if (username == "")
            {
                this.SetPreInfoerrorProvider.SetError(this.txtUserName, "用户编号不能空");
            }
            else
            {
                if (new BLL.UserInfo().GetUserInfoByNo(username, userId) > 0)
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "此用户编号已经存在");
                }
                else
                {
                    this.SetPreInfoerrorProvider.SetError(this.txtUserName, "");
                }
            }



        }
        #endregion

        #region DataGrid数据导航显示在TextBox
        private void setLoginUserTextValueFromDataGrid()
        {
            this.txtLoginName.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "username").Trim();
            this.txtUserName.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "name").Trim();
            
            this.cobUserPower.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "power").Trim();
            this.txtPassword.Text = DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "password").Trim();
            this.txtPassword2.Text = "";
            this.userId = Int32.Parse(DataGirdViewUtil.getSelectedRowsCellValue(this.dataGridViewLoginUser, "loginUserId").Trim());
        }
        #endregion

        #region 保存 取消按钮的启用设置
        private void setLoginUserBtnSaveCancel(bool enable)
        {
            this.btnLoginUserSave.Enabled = enable;
            this.btnLoginUserCancel.Enabled = enable;
        }

        #endregion

        #region 文本框的启用设置
        private void setLoginUserTxtEnabled(bool enable)
        {
            this.txtLoginName.Enabled = enable;
            this.txtUserName.Enabled = enable;
            this.cobUserPower.Enabled = enable;
            this.txtPassword.Enabled = enable;
            this.txtPassword2.Enabled = enable;

        }

        #endregion

        #region 使文本框为空
        private void setLoginUserTxtEmpty()
        {
            this.txtUserName.Text = "";
            this.txtLoginName.Text = "";
            this.txtPassword2.Text = "";
            this.txtPassword.Text = "";
            this.cobUserPower.Text = "";
        }
        #endregion

        #region 当航按钮的启用设置
        private void setLoginUserBtnRow(bool enable)
        {
            this.btnLoginUserLast.Enabled = enable;
            this.btnLoginUserNext.Enabled = enable;
            this.btnLoginUserOne.Enabled = enable;
            this.btnLoginUserPrv.Enabled = enable;
            this.btnLoginUserAdd.Enabled = enable;
            this.btnLoginUserDel.Enabled = enable;
            this.btnLoginUserUpdate.Enabled = enable;
            this.dataGridViewLoginUser.Enabled = enable;
        }
        #endregion


        #endregion



    }
}