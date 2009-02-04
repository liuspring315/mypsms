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
    public partial class StatInOutTableForm : Form
    {

        #region 字段

        private StringBuilder InOutStatcondition = new StringBuilder("");
        private StringBuilder OutStatcondition = new StringBuilder("");
        private StringBuilder VipOutStatcondition = new StringBuilder("");
        private StringBuilder ScrpOutStatcondition = new StringBuilder("");
        DataTable dtOutOu;
        string btextOutOu = "";
        DataTable dbVipOu;
        string btextVipOu = "";
        DataTable dtInOut;


        #endregion


        public StatInOutTableForm()
        {
            InitializeComponent();
        }

        public TabControl TabControlStat
        {
            get
            {
                return this.tabControlStat;
            }
        }


        #region 事件


        private void StatInOutTableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void StatInOutTableForm_Load(object sender, EventArgs e)
        {
            //初始化数据
            DataLoadBySelectTab();
        }

        private void tabControlStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //初始化数据
            DataLoadBySelectTab();
        }

        #region 宣传品出入库总量统计

        private void checkBoxSateInOutTableAllPreInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxSateInOutTableAllPreInfo.Checked)
            {
                this.comboBoxSateInOutTableP_no.Enabled = true;
            }
            else
            {
                this.comboBoxSateInOutTableP_no.Enabled = false;
            }
        }

        private void checkBoxStatInOutTablePreTypeed_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxStatInOutTablePreTypeed.Checked)
            {
                this.comboBoxStatInOutTablePreType.Enabled = true;
                this.checkBoxSateInOutTableAllPreInfo.Enabled = false;
                //this.checkBoxSateInOutTableAllPreInfo.Checked = false;
            }
            else
            {
                this.comboBoxStatInOutTablePreType.Enabled = false;
                this.comboBoxSateInOutTableP_no.Enabled = false;
                this.checkBoxSateInOutTableAllPreInfo.Enabled = true;
                this.checkBoxSateInOutTableAllPreInfo.Checked = true;
            }
        }

        string inoutMess = "";
        private void btnSateInOutTableStat_Click(object sender, EventArgs e)
        {
            try
            {
                InOutStatcondition.Remove(0, InOutStatcondition.Length);
                //InOutStatcondition = new StringBuilder();
                if (!this.checkBoxStatInOutTablePreTypeed.Checked)
                {
                    InOutStatcondition.Append(" and c.pretype = '").Append(((util.ValueObject)this.comboBoxStatInOutTablePreType.SelectedItem).Value).Append("' ");
                    inoutMess = "宣传品系列：" + ((util.ValueObject)this.comboBoxStatInOutTablePreType.SelectedItem).Text;
                }
                else if (!this.checkBoxSateInOutTableAllPreInfo.Checked)
                {
                    if (comboBoxSateInOutTableP_no.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要统计的宣传品或者选中统计全部礼品");
                        return;
                    }
                    InOutStatcondition.Append(" and (");
                    for (int x = 0; x < comboBoxSateInOutTableP_no.CheckedItems.Count - 1; x++)
                    {
                        InOutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[x]).Value).Append("' or ");
                        inoutMess = inoutMess + ((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[x]).Text.Replace(" ", "") + "、";
                    }
                    InOutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[comboBoxSateInOutTableP_no.CheckedItems.Count - 1]).Value).Append("') ");
                    inoutMess = inoutMess + (((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[comboBoxSateInOutTableP_no.CheckedItems.Count - 1]).Value) + ("；");
                }

                if (inoutMess == "")
                {
                    inoutMess = "全部宣传品";
                }
                dtInOut = new BLL.PreInfo().GetPreInfoForStatInOutSum(this.dateTimePickerSateInOutTable1.Value.ToShortDateString() + " 00:00:00.000",
                    this.dateTimePickerSateInOutTable2.Value.ToShortDateString() + " 23:59:59.990", InOutStatcondition.ToString());
                ////输出到报表控件
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridInOutStat, 1);
                this.dataGridView3.DataSource = dtInOut;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库统计", ex);
            }
        }

        private void btnSateInOutTablePrint_Click(object sender, EventArgs e)
        {
            try
            {
                //util.SumData sumDataIn = util.SumData.getSumData(new BLL.InTable().GetInTableForReport2(this.dateTimePickerSateInOutTable1.Value.ToShortDateString(),
                //    this.dateTimePickerSateInOutTable2.Value.ToShortDateString(), InOutStatcondition.ToString()));
                //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(this.dateTimePickerSateInOutTable1.Value.ToShortDateString(),
                //    this.dateTimePickerSateInOutTable2.Value.ToShortDateString(), InOutStatcondition.ToString()));


                //string title = "宣传品出入库总量统计报表";
                //string Ltext = "日期区间：" + this.dateTimePickerSateInOutTable1.Value.ToShortDateString() + " -- " + this.dateTimePickerSateInOutTable2.Value.ToShortDateString() +
                //    "      入库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutStat, 4, 2) +
                //    "   入库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutStat, 5, 1) + "          " +
                //    "出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutStat, 6, 2) +
                //    "   出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutStat, 7, 1);

                //string Btext = "";

                //string Rtext = DateTime.Now.ToShortDateString();
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridInOutStat, title, Ltext, Btext, Rtext);
                if (dtInOut.Rows.Count > 0)
                {
                    string sumInQnt = "入库总量：" + ReportUtil.getDataFromDataTable(dtInOut, 4, 2);
                    string sumInPrice = "入库总金额：" + ReportUtil.getDataFromDataTable(dtInOut, 5, 1);
                    string sumOutQnt = "出库总量：" + ReportUtil.getDataFromDataTable(dtInOut, 6, 2);
                    string sumOutPrice = "出库总金额：" + ReportUtil.getDataFromDataTable(dtInOut, 7, 1);
                    string title = this.dateTimePickerSateInOutTable1.Value.ToShortDateString() + "至" +
                    this.dateTimePickerSateInOutTable2.Value.ToShortDateString();

                    //this.progressBar3.Visible = true;
                    //this.labelWait.Visible = true;
                    //WordHelper.ToWordFormInOutDataTable("inout.doc", dtInOut, title + "宣传品出入库统计报表", sumInQnt, sumInPrice, sumOutQnt, sumOutPrice, progressBar3);
                    //this.labelWait.Visible = false;
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView3, "总公司业务宣传品出入库情况统计表", this.dateTimePickerSateInOutTable1.Value.ToShortDateString(), this.dateTimePickerSateInOutTable2.Value.ToShortDateString(),
                        sumInQnt, sumInPrice,
                        sumOutQnt, sumOutPrice,
                        "统计的内容：" + inoutMess, "",
                        true);
                    dgp.Print();
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("请先点击查询获得数据后再点击打印");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出入库统计打印", ex);
            }
        }

        private void btnSateInOutTableClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region 各部门领取宣传品统计


        private void checkBoxBoxStatOutInfoPreType_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxBoxStatOutInfoPreType.Checked)
            {
                this.comboBoxBoxStatOutInfo.Enabled = true;
                this.checkBoxStatOutInfoAllPreInfo.Enabled = false;
            }
            else
            {
                this.comboBoxBoxStatOutInfo.Enabled = false;
                this.checkedListBoxStatOutInfoP_no.Enabled = false;
                this.checkBoxStatOutInfoAllPreInfo.Enabled = true;
                this.checkBoxStatOutInfoAllPreInfo.Checked = true;
            }
        }

        private void checkBoxStatOutInfoAllPreInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxStatOutInfoAllPreInfo.Checked)
            {
                this.checkedListBoxStatOutInfoP_no.Enabled = true;
            }
            else
            {
                this.checkedListBoxStatOutInfoP_no.Enabled = false;
            }
        }

        private void btnStatOutInfoStat_Click(object sender, EventArgs e)
        {
            try
            {
                //OutStatcondition.Remove(0, OutStatcondition.Length);
                //if (!this.checkBoxBoxStatOutInfoPreType.Checked)
                //{
                //    OutStatcondition.Append(" and preinfo.pretype = '").Append(((util.ValueObject)this.comboBoxBoxStatOutInfo.SelectedItem).Value).Append("' ");
                //}
                //else if (!this.checkBoxStatOutInfoAllPreInfo.Checked)
                //{
                //    OutStatcondition.Append(" and (");
                //    for (int x = 0; x < checkedListBoxStatOutInfoP_no.CheckedItems.Count - 1; x++)
                //    {
                //        OutStatcondition.Append(" preinfo.p_no = '").Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[x]).Value).Append("' or ");
                //    }
                //    OutStatcondition.Append(" preinfo.p_no = '").Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[checkedListBoxStatOutInfoP_no.CheckedItems.Count - 1]).Value).Append("') ");
                //}

                //IList<IList<string>> list = new BLL.OutInfo().GetOutInfoForStatOutSum(this.dateTimePickerStatOutInfo1.Value.ToShortDateString(),
                //    this.dateTimePickerStatOutInfo2.Value.AddDays(1).ToShortDateString(), OutStatcondition.ToString());
                ////输出到报表控件
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridOutInfoStat, 1);
                string[] cond = this.getOutOuCondition();
                dtOutOu = new BLL.OutTable().GetStatOutOuGroupByOutOuByCon(cond[0]);
                this.btextOutOu = cond[1];
                this.dataGridView1.DataSource = dtOutOu;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各部门领取宣传品统计", ex);
            }
        }

        private void btnStatOutInfoPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(this.dateTimePickerStatOutInfo1.Value.ToShortDateString(),
                //    this.dateTimePickerStatOutInfo2.Value.ToShortDateString(), OutStatcondition.ToString()));


                //string title = "各公司各部门领取宣传品情况统计报表";
                //string Ltext = "日期区间：" + this.dateTimePickerStatOutInfo1.Value.ToShortDateString() + " -- " + this.dateTimePickerStatOutInfo2.Value.ToShortDateString() +
                //    "      出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridOutInfoStat, 2, 2) +
                //    "   出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridOutInfoStat, 3, 1);

                //string Btext = "";

                //string Rtext = DateTime.Now.ToShortDateString();
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridOutInfoStat, title, Ltext, Btext, Rtext);
                if (this.dtOutOu != null && dtOutOu.Rows.Count > 0)
                {
                    //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(startTime,
                    //    endTime, this.conditon.ToString()));
                    string outCount = "0";
                    string outdemcal = "0.00";
                    //this.progressBar1.Visible = true;
                    //this.labelWait.Visible = true;

                    outCount = "出库总量：" + ReportUtil.getDataFromDataTable(dtOutOu, 1, 2);
                    outdemcal = "出库总金额：" + ReportUtil.getDataFromDataTable(dtOutOu, 2, 1);
                    //WordHelper.ToWordFormInReportDataTable("outou1.doc", dtOutOu, "各公司各部门领取宣传品情况统计报表", outCount, outdemcal, btextOutOu, progressBar1);
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView1, "总公司业务宣传品领取情况统计表", "", "",
                        outCount, outdemcal,
                        "", "",
                        "统计的内容：" + btextOutOu, "",
                        true);
                    dgp.Print();

                    //DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView2, "总公司业务宣传品赠送情况统计表", "", "",
                    //    outCount, outdemcal, "",
                    //    "", "统计的内容：" + btextVipOu, "",
                    //    true);
                    //dgp.Print();



                    //this.labelWait.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各部门领取宣传品统计", ex);
            }
        }

        private void btnStatOutInfoClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion


        #region 各单位赠送宣传品统计



        private void checkBoxVipOuStatPreType_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxVipOuStatPreType.Checked)
            {
                this.comboBoxVipOuStatPreType.Enabled = true;
                this.checkBoxVipOuStat.Enabled = false;
            }
            else
            {
                this.comboBoxVipOuStatPreType.Enabled = false;
                this.checkedListBoxVipOuStatP_no.Enabled = false;
                this.checkBoxVipOuStat.Enabled = true;
                this.checkBoxVipOuStat.Checked = true;
            }
        }

        private void checkBoxVipOuStat_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxVipOuStat.Checked)
            {
                this.checkedListBoxVipOuStatP_no.Enabled = true;
            }
            else
            {
                this.checkedListBoxVipOuStatP_no.Enabled = false;
            }
        }

        private void btnVipOuStat_Click(object sender, EventArgs e)
        {
            try
            {
                string mess = getConditioinVipOu();
                btextVipOu = this.dateTimePickerVipOuStat1.Value.ToShortDateString() + "至" + this.dateTimePickerVipOuStat2.Value.ToShortDateString() +
                    mess;
                dbVipOu = new BLL.OutTable().GetStatVipOuGroupByOutOuByCon(VipOutStatcondition.ToString());
                //输出到报表控件
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridVipInfoStat, 1);
                this.dataGridView2.DataSource = dbVipOu;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各单位赠送宣传品统计", ex);
            }
        }


        private string getConditioinVipOu()
        {
            string mess = "";
            VipOutStatcondition.Remove(0, VipOutStatcondition.Length);
            if (!this.checkBoxVipOuStatPreType.Checked)
            {
                VipOutStatcondition.Append(" and c.pretype = '").Append(((util.ValueObject)this.comboBoxVipOuStatPreType.SelectedItem).Value).Append("' ");
                mess = "宣传品系列：" + ((util.ValueObject)this.comboBoxVipOuStatPreType.SelectedItem).Value + "；";
            }
            else if (!this.checkBoxVipOuStat.Checked)
            {
                mess = mess + "宣传品名称：";
                VipOutStatcondition.Append(" and (");
                for (int x = 0; x < this.checkedListBoxVipOuStatP_no.CheckedItems.Count - 1; x++)
                {
                    VipOutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.checkedListBoxVipOuStatP_no.CheckedItems[x]).Value).Append("' or ");
                    mess = mess + ((util.ValueObject)this.checkedListBoxVipOuStatP_no.CheckedItems[x]).Text.Replace(" ","") + "、";
                }
                VipOutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.checkedListBoxVipOuStatP_no.CheckedItems[checkedListBoxVipOuStatP_no.CheckedItems.Count - 1]).Value).Append("') ");
                mess = mess + ((util.ValueObject)this.checkedListBoxVipOuStatP_no.CheckedItems[checkedListBoxVipOuStatP_no.CheckedItems.Count - 1]).Value + "；";
            }
            if (!this.checkBoxStatVipOu.Checked)
            {
                VipOutStatcondition.Append(" and vip_ou = '").Append(((util.ValueObject)this.comboBoxVipOu.SelectedItem).Value).Append("' ");
                mess = mess + "赠送分类：" + ((util.ValueObject)this.comboBoxVipOu.SelectedItem).Value;
            }

            VipOutStatcondition.Append(" and out_date >= '").Append(this.dateTimePickerVipOuStat1.Value.ToShortDateString()).Append(" 00:00:00.000' ");
            VipOutStatcondition.Append(" and out_date <= '").Append(this.dateTimePickerVipOuStat2.Value.AddDays(1).ToShortDateString()).Append(" 23:59:59.990' ");
            return mess == "" ? "全部宣传品" : mess;
        }

        private void btnVipOuStatPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(this.dateTimePickerVipOuStat2.Value.ToShortDateString(),
                //    this.dateTimePickerVipOuStat1.Value.ToShortDateString(), VipOutStatcondition.ToString()));


                //string title = "各公司各部门赠送宣传品情况统计报表";
                //string Ltext = "日期区间：" + this.dateTimePickerVipOuStat1.Value.ToShortDateString() + " -- " + this.dateTimePickerVipOuStat2.Value.ToShortDateString() +
                //    "      出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridVipInfoStat, 2, 2) +
                //    "   出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridVipInfoStat, 3, 1);

                //string Btext = "";

                //string Rtext = DateTime.Now.ToShortDateString();
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridVipInfoStat, title, Ltext, Btext, Rtext);

                if (this.dbVipOu != null && dbVipOu.Rows.Count > 0)
                {

                    string outCount = "0";
                    string outdemcal = "0.00";
                    //this.progressBar2.Visible = true;
                    //this.labelWait.Visible = true;

                    outCount = "出库总量：" + ReportUtil.getDataFromDataTable(dbVipOu, 1, 2);
                    outdemcal = "出库总金额：" + ReportUtil.getDataFromDataTable(dbVipOu, 2, 1);
                    //WordHelper.ToWordFormInReportDataTable("vipou1.doc", dbVipOu, "各公司各部门赠送宣传品情况统计报表", outCount, outdemcal, btextVipOu, progressBar2);
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView2, "总公司业务宣传品赠送情况统计表", "", "",
                        outCount, outdemcal, "",
                        "", "统计的内容：" + btextVipOu, "",
                        true);
                    dgp.Print();



                    //this.labelWait.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各单位赠送宣传品统计打印", ex);
            }
        }

        private void btnVipOuStatClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region 凭证数据统计

        DataTable scrpStatDt = new DataTable();

        private void btnScrpStat_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtScrpStatCost.Text = "0.00";
                this.txtScrpStatQnt.Text = "0";
                this.txtScrpStatScrpQnt.Text = "0";
                if(hashTable != null)
                    hashTable.Clear();
                scrpStatDt = new BLL.OutTable().GetOutTableForStatQntSum(this.dateTimePickerScrpStat1.Value.ToShortDateString() + " 00:00:00.000",
                    this.dateTimePickerScrpStat2.Value.ToShortDateString() + " 23:59:59.990");

                ////输出到报表控件
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridScrpStat, 1);
                this.dataGridView4.DataSource = scrpStatDt;


            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("凭证数据统计", ex);
            }
        }

        private void btnScrpStatPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(this.dateTimePickerScrpStat1.Value.ToShortDateString(),
                //    this.dateTimePickerScrpStat2.Value.ToShortDateString(), OutStatcondition.ToString()));


                //string title = "出库凭证数据统计报表";
                //string Ltext = "日期区间：" + this.dateTimePickerScrpStat1.Value.ToShortDateString() + " -- " + this.dateTimePickerScrpStat2.Value.ToShortDateString() +
                //    "      出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridScrpStat, 6, 2)
                //    + "   出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridScrpStat, 5, 1);

                //string Btext = "";

                //string Rtext = DateTime.Now.ToShortDateString();
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridScrpStat, title, Ltext, Btext, Rtext);

                //if (this.scrpStatDt != null && scrpStatDt.Rows.Count > 0)
                //{
                if (hashTable.Count > 0)
                {
                    string condition = " and OUTTABLE.OUT_SCRPNO in (";
                    foreach (System.Collections.DictionaryEntry objDE in hashTable)
                    {
                        condition = condition + "'" + objDE.Key.ToString() + "',";
                    }
                    condition = condition.Remove(condition.Length - 1);
                    condition = condition + ")";
                    scrpStatDt = new BLL.OutTable().GetOutTableForStatQntSum(condition);
                    if (scrpStatDt.Rows.Count > 0)
                    {
                        this.dataGridView4.DataSource = scrpStatDt;

                        string outCount = "0";
                        string outdemcal = "0.00";
                        //this.progressBar2.Visible = true;
                        //this.labelWait.Visible = true;

                        outCount = "";//"出库总量：" + ReportUtil.getDataFromDataTable(scrpStatDt, 5, 2);
                        outdemcal = "";//"出库总金额：" + ReportUtil.getDataFromDataTable(scrpStatDt, 4, 1);

                        DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView4, "出库凭证数据统计报表", this.dateTimePickerScrpStat1.Value.ToShortDateString(), this.dateTimePickerScrpStat2.Value.ToShortDateString(),
                            "选中凭证数：" + this.txtScrpStatScrpQnt.Text, "",
                            "选中凭证合计数量：" + this.txtScrpStatQnt.Text, "选中凭证合计金额：" + this.txtScrpStatCost.Text, outCount, outdemcal,
                            true);
                        dgp.Print();
                    }

                    //btnScrpStat_Click(sender, e);

                }

                //this.labelWait.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("凭证数据统计打印", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #endregion

        #region 私有方法

        //初始化数据
        private void DataLoadBySelectTab()
        {
            //打开宣传品出入库总量统计标签 初始化数据
            if (this.tabControlStat.SelectedTab == this.tabControlStat.TabPages[0])
            {
                setAxlgxgridInOutStat();
                setComboBoxPno(this.comboBoxSateInOutTableP_no);
                setComboBoxPno(this.comboBoxStatInOutTablePreType);
            }
            //打开各部门领取宣传品统计标签 初始化数据
            else if (this.tabControlStat.SelectedTab == this.tabControlStat.TabPages[1])
            {
                setAxlgxgridOutInfoStat();
                setComboBoxPno(this.checkedListBoxStatOutInfoP_no);
                setComboBoxPno(this.comboBoxBoxStatOutInfo);
                setComboBoxOutOu(this.comboBoxOutou);
            }
            //打开各单位赠送宣传品统计标签 初始化数据
            else if (this.tabControlStat.SelectedTab == this.tabControlStat.TabPages[2])
            {
                setAxlgxgridVipInfoStat();
                setComboBoxPno(this.checkedListBoxVipOuStatP_no);
                setComboBoxPno(this.comboBoxVipOuStatPreType);
                setComboBoxVipOu(this.comboBoxVipOu);
            }
            //打开凭证数据统计标签 初始化数据
            else if (this.tabControlStat.SelectedTab == this.tabControlStat.TabPages[3])
            {
                setAxlgxgridScrpStat();
            }


        }

        //宣传品出入库总量统计 报表控件初始化
        //private bool InOutStatInited = false;
        private void setAxlgxgridInOutStat()
        {
            //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //if (!InOutStatInited)
            //{
            //    this.axlgxgridInOutStat.hadd("宣传品编号", 1, 800, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("宣传品系列", 1, 800, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("宣传品名称", 1, 1500, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("入库宣传品数量", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("入库宣传品金额", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("出库宣传品数量", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridInOutStat.hadd("出库宣传品金额", 1, 1000, false, ReportUtil.hfont);
            //    InOutStatInited = true;
            //}
        }

        //各部门领取宣传品统计 报表控件初始化
        //private bool OutInfoStatInited = false;
        private void setAxlgxgridOutInfoStat()
        {
            //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //if (!OutInfoStatInited)
            //{
            //    this.axlgxgridOutInfoStat.hadd("收货单位", 1, 4000, false, ReportUtil.hfont);
            //    this.axlgxgridOutInfoStat.hadd("合计数量", 1, 1500, false, ReportUtil.hfont);
            //    this.axlgxgridOutInfoStat.hadd("合计金额", 1, 1500, false, ReportUtil.hfont);
            //    OutInfoStatInited = true;
            //}
        }

        //各单位赠送宣传品统计 报表控件初始化
        //private bool VipInfoStatInited = false;
        private void setAxlgxgridVipInfoStat()
        {
            //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //if (!VipInfoStatInited)
            //{
            //    this.axlgxgridVipInfoStat.hadd("赠送分类", 1, 4000, false, ReportUtil.hfont);
            //    this.axlgxgridVipInfoStat.hadd("合计数量", 1, 1500, false, ReportUtil.hfont);
            //    this.axlgxgridVipInfoStat.hadd("合计金额", 1, 1500, false, ReportUtil.hfont);
            //    VipInfoStatInited = true;
            //}
        }

        //凭证数据统计 报表控件初始化
        //private bool ScrpStatInited = false;
        private void setAxlgxgridScrpStat()
        {
            //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //if (!ScrpStatInited)
            //{
            //    //this.axlgxgridScrpStat.hadd("选中", 1, 300, false, null);
            //    this.axlgxgridScrpStat.hadd("凭证编号", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("收货单位", 1, 1500, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("赠送分类", 1, 1500, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("出库日期", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("出库金额", 1, 1000, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("数量", 1, 800, false, ReportUtil.hfont);
            //    this.axlgxgridScrpStat.hadd("备注", 1, 1500, false, ReportUtil.hfont);
            //    ScrpStatInited = true;
            //}
        }

        //初始化宣传品名称下拉列表
        private void setComboBoxPno(CheckedListBox combo)
        {
            IList<PreInfoData> preInfoList = new BLL.PreInfo().GetAllPreInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preInfoList.Count; i++)
            {
                PreInfoData data = preInfoList[i];
                valueList.Add(new util.ValueObject(data.P_no, data.P_no + inStrbypnoLength(data.P_no) + " | " + data.P_name));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        private string inStrbypnoLength(string p_no)
        {
            int length = 20;
            StringBuilder str = new StringBuilder("");
            for (int i = 0; i < length - p_no.Length; i++)
            {
                str.Append(" ");
            }
            return str.ToString();
        }

        //初始化宣传品系列下拉列表
        private void setComboBoxPno(ComboBox combo)
        {
            IList<PreTypeInfo> preTypeList = new BLL.PreType().GetAllPreTypeInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preTypeList.Count; i++)
            {
                PreTypeInfo data = preTypeList[i];
                valueList.Add(new util.ValueObject(data.TypeName, data.TypeName));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        //初始化领取单位下拉列表
        private void setComboBoxOutOu(ComboBox combo)
        {
            IList<OutInfoData> outInfoData = new BLL.OutInfo().GetAllOutInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < outInfoData.Count; i++)
            {
                OutInfoData data = outInfoData[i];
                valueList.Add(new util.ValueObject(data.Out_ou, data.Out_ou));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        //初始化赠送分类下拉列表
        private void setComboBoxVipOu(ComboBox combo)
        {
            IList<VipInfoData> vipInfoData = new BLL.VipInfo().GetAllVipInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < vipInfoData.Count; i++)
            {
                VipInfoData data = vipInfoData[i];
                valueList.Add(new util.ValueObject(data.Vip_ou, data.Vip_ou));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }



        #endregion

        private void buttonChar_Click(object sender, EventArgs e)
        {
            try
            {
                //InOutStatcondition.Append(" and ");
                InOutPieForm inOutPieForm = new InOutPieForm(InOutStatcondition.ToString(),inoutMess, this.dateTimePickerSateInOutTable1.Value.ToShortDateString(),
                    this.dateTimePickerSateInOutTable2.Value.ToShortDateString());
                inOutPieForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("总公司业务宣传品入库情况统计表", ex);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int row = 0;
        //        for (int j = 1; j <= this.axlgxgridOutInfoStat.rows; j++)
        //        {

        //            if (axlgxgridOutInfoStat.GetData(j, 1) != null && axlgxgridOutInfoStat.GetData(j, 1) != "")
        //            {
        //                row++;
        //            }

        //        }
        //        string[] d2 = new string[row];
        //        double[] d1 = new double[row];

        //        for (int j = 1; j <= row; j++)
        //        {
        //            d2[j - 1] = axlgxgridOutInfoStat.GetData(j, 1);
        //            d1[j - 1] = double.Parse(axlgxgridOutInfoStat.GetData(j, axlgxgridOutInfoStat.Nlist));
        //        }

        //        CharForm charForm = new CharForm(d1, d2);
        //        charForm.ShowDialog(this);
        //    }
        //    catch(Exception ex)
        //    {
        //        Log.WriteLog(ex.ToString());
        //        MessageBox.Show("请先点击统计按钮得到统计数据并选中要输出图形的统计列，再输出图形", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //int row = 0;
                //for (int j = 1; j <= this.axlgxgridVipInfoStat.rows; j++)
                //{

                //    if (axlgxgridVipInfoStat.GetData(j, 1) != null && axlgxgridVipInfoStat.GetData(j, 1) != "")
                //    {
                //        row++;
                //    }

                //}
                //string[] d2 = new string[row];
                //double[] d1 = new double[row];

                //for (int j = 1; j <= row; j++)
                //{
                //    d2[j - 1] = axlgxgridVipInfoStat.GetData(j, 1);
                //    d1[j - 1] = double.Parse(axlgxgridVipInfoStat.GetData(j, axlgxgridVipInfoStat.Nlist));
                //}

                //CharForm charForm = new CharForm(d1, d2);
                //charForm.ShowDialog(this);

                string mess = getConditioinVipOu();
                //btextVipOu = this.dateTimePickerVipOuStat1.Value.ToShortDateString() + "至" + this.dateTimePickerVipOuStat2.Value.ToShortDateString() + mess;
                BLL.OutTable outTableBll = new BLL.OutTable();
                dbVipOu = outTableBll.GetStatVipOuGroupByOutOuByCon(VipOutStatcondition.ToString());
                //int allSum = outTableBll.GetStatOutTableAllOutOuByCon(VipOutStatcondition.ToString());
                 int allSum = 0;
                decimal allPrice = 0M;  
                foreach (DataRow dr in dbVipOu.Rows)
                {
                    allSum = allSum + Convert.ToInt32(dr[1].ToString());
                    allPrice = allPrice + Convert.ToDecimal(dr[2].ToString());
                }
                string st = "总公司业务宣传品赠送情况统计图";
                string st1 = this.dateTimePickerVipOuStat1.Value.ToShortDateString() + "至" + this.dateTimePickerVipOuStat2.Value.ToShortDateString();
                string st2 = "赠送数量：" + allSum + "         总金额：" + allPrice;
                string st3 = mess;
                if (dbVipOu != null && dbVipOu.Rows.Count > 0 && allSum > 0)
                {
                    PieForm pie = new PieForm(st,st1,st2,st3, dbVipOu, 1);
                    pie.ShowDialog(this);
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("指定的查询条件查询无记录，请重新指定查询条件");
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                //MessageBox.Show("请先点击统计按钮得到统计数据并选中要输出图形的统计列，再输出图形", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //private void buttonPretypeToPage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string[] d2 = new string[this.comboBoxStatInOutTablePreType.Items.Count];
        //        for (int x = 0; x < this.comboBoxStatInOutTablePreType.Items.Count; x++)
        //            {
        //                d2[x] = ((util.ValueObject)this.comboBoxStatInOutTablePreType.Items[x]).Value;
        //            }
        //            double[] d1 = new double[d2.Length];
        //            for (int i = 0; i < d2.Length; i++)
        //            {
        //                for (int j = 1; j <= this.axlgxgridInOutStat.rows; j++)
        //                {
        //                    if (axlgxgridInOutStat.GetData(j, 2) == d2[i])
        //                    {
        //                        d1[i] = d1[i] + double.Parse(axlgxgridInOutStat.GetData(j, axlgxgridInOutStat.Nlist));
        //                    }
        //                }
        //            }
        //            CharForm charForm = new CharForm(d1, d2);
        //            charForm.ShowDialog(this);


        //    }
        //    catch (Exception ex)
        //    {
        //        MyMessageBox.ShowErrorMessageBox("首先要确定按哪一列生成饼型图，请首先点击一下要生成饼型图的列", ex);
        //    }
        //}

        //private void buttonSelectedPreInfoToPage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!this.checkBoxSateInOutTableAllPreInfo.Checked)
        //        {

        //            string[] d2 = new string[comboBoxSateInOutTableP_no.CheckedItems.Count];
        //            for (int x = 0; x < comboBoxSateInOutTableP_no.CheckedItems.Count; x++)
        //            {
        //                d2[x] = ((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[x]).Value;
        //            }
        //            double[] d1 = new double[d2.Length];
        //            for (int i = 0; i < d2.Length; i++)
        //            {
        //                for (int j = 1; j <= this.axlgxgridInOutStat.rows; j++)
        //                {
        //                    if (axlgxgridInOutStat.GetData(j, 1) == d2[i])
        //                    {
        //                        d1[i] = double.Parse(axlgxgridInOutStat.GetData(j, axlgxgridInOutStat.Nlist));
        //                        break;
        //                    }
        //                }
        //            }
        //            CharForm charForm = new CharForm(d1, d2);
        //            charForm.ShowDialog(this);


        //        }
        //        else
        //        {
        //            MessageBox.Show("请选择几个宣传品进行统计输出图形", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MyMessageBox.ShowErrorMessageBox("首先要确定按哪一列生成饼型图，请首先点击一下要生成饼型图的列", ex);
        //    }
        //}

        /// <summary>
        /// 按所选宣传品输出饼型图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    string[] d2 = new string[this.axlgxgridOutInfoStat.rows];
        //    //    double[] d1 = new double[d2.Length];

        //    //    for (int j = 1; j <= this.axlgxgridOutInfoStat.rows; j++)
        //    //    {
        //    //        d2[j - 1] = axlgxgridOutInfoStat.GetData(j, 1);
        //    //        d1[j - 1] = double.Parse(axlgxgridOutInfoStat.GetData(j, axlgxgridOutInfoStat.Nlist));
        //    //    }

        //    //    CharForm charForm = new CharForm(d1, d2);
        //    //    charForm.ShowDialog(this);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Log.WriteLog(ex.ToString());
        //    //    MessageBox.Show("请先点击统计按钮得到统计数据并选中要输出图形的统计列，再输出图形", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //}
        //    try
        //    {
        //        if (!this.checkBoxSateInOutTableAllPreInfo.Checked)
        //        {

        //            string[] d2 = new string[comboBoxSateInOutTableP_no.CheckedItems.Count];
        //            for (int x = 0; x < comboBoxSateInOutTableP_no.CheckedItems.Count; x++)
        //            {
        //                d2[x] = ((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[x]).Value;
        //            }
        //            double[] d1 = new double[d2.Length];
        //            for (int i = 0; i < d2.Length; i++)
        //            {
        //                for (int j = 1; j <= this.axlgxgridInOutStat.rows; j++)
        //                {
        //                    if (axlgxgridInOutStat.GetData(j, 1) == d2[i])
        //                    {
        //                        d1[i] = double.Parse(axlgxgridInOutStat.GetData(j, axlgxgridInOutStat.Nlist));
        //                        break;
        //                    }
        //                }
        //            }
        //            CharForm charForm = new CharForm(d1, d2);
        //            charForm.ShowDialog(this);


        //        }
        //        else
        //        {
        //            MessageBox.Show("请选择几个宣传品进行统计输出图形", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MyMessageBox.ShowErrorMessageBox("首先要确定按哪一列生成饼型图，请首先点击一下要生成饼型图的列", ex);
        //    }
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string[] d2 = new string[this.comboBoxStatInOutTablePreType.Items.Count];
        //        for (int x = 0; x < this.comboBoxStatInOutTablePreType.Items.Count; x++)
        //        {
        //            d2[x] = ((util.ValueObject)this.comboBoxStatInOutTablePreType.Items[x]).Value;
        //        }
        //        double[] d1 = new double[d2.Length];
        //        for (int i = 0; i < d2.Length; i++)
        //        {
        //            for (int j = 1; j <= this.axlgxgridInOutStat.rows; j++)
        //            {
        //                if (axlgxgridInOutStat.GetData(j, 2) == d2[i])
        //                {
        //                    d1[i] = d1[i] + double.Parse(axlgxgridInOutStat.GetData(j, axlgxgridInOutStat.Nlist));
        //                }
        //            }
        //        }
        //        CharForm charForm = new CharForm(d1, d2);
        //        charForm.ShowDialog(this);


        //    }
        //    catch (Exception ex)
        //    {
        //        MyMessageBox.ShowErrorMessageBox("首先要确定按哪一列生成饼型图，请首先点击一下要生成饼型图的列", ex);
        //    }
        //}

        private void buttonPieShow_Click(object sender, EventArgs e)
        {
            try
            {
                string[] condtion = getOutOuCondition();
                BLL.OutTable outTableBll = new BLL.OutTable();
                //int allSum = outTableBll.GetStatOutTableAllOutOuByCon(condtion[0]);
                IList<IList<string>> list = outTableBll.GetStatOutTableGroupByOutOuByCon(condtion[0]);

                int allSum = 0;
                decimal allPrice = 0M;
                for(int i = 0; i < list.Count;i++)
                {
                    allSum = allSum + Convert.ToInt32(list[i][1].ToString());
                    allPrice = allPrice + Convert.ToDecimal(list[i][2].ToString());
                }
                string st = "总公司业务宣传品领取情况统计图";
                string st1 = this.dateTimePickerStatOutInfo1.Value.ToShortDateString() + "至" + this.dateTimePickerStatOutInfo2.Value.ToShortDateString();
                string st2 = "领取数量：" + allSum + "         总金额：" + allPrice;
                string st3 = condtion[1];
                if (list.Count > 0 && allSum > 0)
                {
                    PieForm pie = new PieForm(st,st1,st2,st3, list, 1);
                    pie.ShowDialog(this);
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("指定的查询条件查询无记录，请重新指定查询条件");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各部门领取宣传品统计", ex);
            }
        }


        private string[] getOutOuCondition()
        {
            StringBuilder mess = new StringBuilder("");
            OutStatcondition.Remove(0, OutStatcondition.Length);
            OutStatcondition.Append(" and out_date  >= '").Append(this.dateTimePickerStatOutInfo1.Value.ToShortDateString()).Append(" 00:00:00.000' ");
            OutStatcondition.Append(" and out_date  <= '").Append(this.dateTimePickerStatOutInfo2.Value.ToShortDateString()).Append(" 23:59:59.990' ");
            mess.Append(this.dateTimePickerStatOutInfo1.Value.ToShortDateString()).Append("至");
            mess.Append(this.dateTimePickerStatOutInfo2.Value.ToShortDateString());
            if (!this.checkBoxBoxStatOutInfoPreType.Checked)
            {
                OutStatcondition.Append(" and c.pretype = '").Append(((util.ValueObject)this.comboBoxBoxStatOutInfo.SelectedItem).Value).Append("' ");
                mess.Append("宣传品系列为：").Append(((util.ValueObject)this.comboBoxBoxStatOutInfo.SelectedItem).Value).Append("；");
            }

            if (!this.checkBoxStatOutInfoAllPreInfo.Checked)
            {
                mess.Append("宣传品为：");
                OutStatcondition.Append(" and (");
                for (int x = 0; x < checkedListBoxStatOutInfoP_no.CheckedItems.Count - 1; x++)
                {
                    OutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[x]).Value).Append("' or ");
                    mess.Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[x]).Text.Replace(" ", "")).Append("、");
                }
                OutStatcondition.Append(" c.p_no = '").Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[checkedListBoxStatOutInfoP_no.CheckedItems.Count - 1]).Value).Append("') ");
                mess.Append(((util.ValueObject)this.checkedListBoxStatOutInfoP_no.CheckedItems[checkedListBoxStatOutInfoP_no.CheckedItems.Count - 1]).Value).Append("；");
            }
            else if (!this.checkBoxOutou.Checked)
            {
                OutStatcondition.Append(" and out_ou = '").Append(((util.ValueObject)this.comboBoxOutou.SelectedItem).Value).Append("' ");
                mess.Append("领取单位为：").Append(((util.ValueObject)this.comboBoxOutou.SelectedItem).Value);
            }

            return new string[] { OutStatcondition.ToString(), mess.ToString() == "" ? "全部宣传品" : mess.ToString() };

        }

        private void checkBoxOutou_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxOutou.Checked)
            {
                this.comboBoxOutou.Enabled = true;
            }
            else
            {
                this.comboBoxOutou.Enabled = false;
            }
        }

        private void checkBoxStatVipOu_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxStatVipOu.Checked)
            {
                this.comboBoxVipOu.Enabled = true;
            }
            else
            {
                this.comboBoxVipOu.Enabled = false;
            }
        }

        private void buttonBarChart_Click(object sender, EventArgs e)
        {
            try
            {
                string[] condtion = getOutOuCondition();
                BLL.OutTable outTableBll = new BLL.OutTable();
                //int allSum = outTableBll.GetStatOutTableAllOutOuByCon(condtion[0]);
                IList<IList<string>> list = outTableBll.GetStatOutTableGroupByOutOuByCon(condtion[0]);
                int allSum = 0;
                decimal allPrice = 0M;
                for (int i = 0; i < list.Count; i++)
                {
                    allSum = allSum + Convert.ToInt32(list[i][1].ToString());
                    allPrice = allPrice + Convert.ToDecimal(list[i][2].ToString());
                }
                if (list.Count > 0)
                {
                    string st = "总公司业务宣传品领取情况统计图";
                    string st1 = this.dateTimePickerStatOutInfo1.Value.ToShortDateString() + "至" + this.dateTimePickerStatOutInfo2.Value.ToShortDateString();
                    string st2 = "领取数量：" + allSum + "         总金额：" + allPrice;
                    string st3 = condtion[1];
                    BarForm bar = new BarForm(st, st1, st2, st3, list);
                    bar.ShowDialog(this);
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("指定的查询条件查询无结果，请重新指定查询条件");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各部门领取宣传品统计", ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mess = getConditioinVipOu();
                btextVipOu = this.dateTimePickerVipOuStat1.Value.ToShortDateString() + "至" + this.dateTimePickerVipOuStat2.Value.ToShortDateString() +
                    mess;
                dbVipOu = new BLL.OutTable().GetStatVipOuGroupByOutOuByCon(VipOutStatcondition.ToString());
                int allSum = 0;
                decimal allPrice = 0M;
                for (int i = 0; i < dbVipOu.Rows.Count; i++)
                {
                    allSum = allSum + Convert.ToInt32(dbVipOu.Rows[i][1].ToString());
                    allPrice = allPrice + Convert.ToDecimal(dbVipOu.Rows[i][2].ToString());
                }
                if (dbVipOu != null && dbVipOu.Rows.Count > 0)
                {
                    //BarForm bar = new BarForm("各公司各部门赠送宣传品情况统计", btextVipOu, dbVipOu);
                    string st = "总公司业务宣传品赠送情况统计图";
                    string st1 = this.dateTimePickerVipOuStat1.Value.ToShortDateString() + "至" + this.dateTimePickerVipOuStat2.Value.ToShortDateString();
                    string st2 = "赠送数量：" + allSum + "         总金额：" + allPrice;
                    string st3 = mess;
                    BarForm bar = new BarForm(st, st1, st2, st3, dbVipOu);
                    bar.ShowDialog(this);
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("指定的查询条件查询无记录，请重新指定查询条件");
                }

            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("各公司各部门赠送宣传品情况统计", ex);
            }
        }

        System.Collections.Hashtable hashTable = new System.Collections.Hashtable();

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (((DataGridViewCheckBoxCell)this.dataGridView4.Rows[e.RowIndex].Cells["ColChckBox"]).Value == null)
                {
                    ((DataGridViewCheckBoxCell)this.dataGridView4.Rows[e.RowIndex].Cells["ColChckBox"]).Value = true;
                    if (!hashTable.Contains(this.dataGridView4.Rows[e.RowIndex].Cells["scrpno"].Value))
                        hashTable.Add(this.dataGridView4.Rows[e.RowIndex].Cells["scrpno"].Value, null);
                }
                else if (((DataGridViewCheckBoxCell)this.dataGridView4.Rows[e.RowIndex].Cells["ColChckBox"]).Value.ToString() == "True")
                {
                    ((DataGridViewCheckBoxCell)this.dataGridView4.Rows[e.RowIndex].Cells["ColChckBox"]).Value = false;
                    hashTable.Remove(this.dataGridView4.Rows[e.RowIndex].Cells["scrpno"].Value);
                }
                else
                {
                    ((DataGridViewCheckBoxCell)this.dataGridView4.Rows[e.RowIndex].Cells["ColChckBox"]).Value = true;
                    if (!hashTable.Contains(this.dataGridView4.Rows[e.RowIndex].Cells["scrpno"].Value))
                        hashTable.Add(this.dataGridView4.Rows[e.RowIndex].Cells["scrpno"].Value, null);
                }
                setStatTextBoxValue();
            }
            catch { }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgR in this.dataGridView4.Rows)
            {
                try
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgR.Cells[0];
                   
                    cbx.Value = true;
                    if (!hashTable.Contains(this.dataGridView4.Rows[dgR.Index].Cells["scrpno"].Value))
                        hashTable.Add(this.dataGridView4.Rows[dgR.Index].Cells["scrpno"].Value, null);

                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowErrorMessageBox("全选", ex);
                }


            }
            setStatTextBoxValue();
        }

        private void setStatTextBoxValue()
        {

            int count = 0;
            int qnt = 0;
            decimal cost = 0;

            foreach (DataGridViewRow dgR in this.dataGridView4.Rows)
            {
                try
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgR.Cells[0];
                    if ((bool)cbx.FormattedValue)
                    {
                        try
                        {

                            qnt = qnt + Int32.Parse(this.dataGridView4.Rows[dgR.Index].Cells[6].Value.ToString());
                            cost = cost + decimal.Parse(this.dataGridView4.Rows[dgR.Index].Cells[5].Value.ToString());
                            count++;
                        }
                        catch { }
                    }

                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowErrorMessageBox("全选", ex);
                }


            }

            this.txtScrpStatCost.Text = cost.ToString();
            this.txtScrpStatQnt.Text = qnt.ToString();
            this.txtScrpStatScrpQnt.Text = count.ToString();
        }





    }
}