using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.BLL;
using psms.Model;
using psms.util;

namespace psms
{
    public partial class StoreReportForm : Form
    {
        DataTable dt;

        string title;
        string startTime = "1900-01-01";
        string endTime = "3000-01-01";
        StringBuilder conditon = new StringBuilder();
        public StoreReportForm()
        {
            InitializeComponent();
        }

        private void StoreReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                setComboBoxPno(this.comboBoxStatInOutTablePreType);
                setComboBoxPno(this.comboBoxSateInOutTableP_no, "");

                ReportUtil.setYearList(this.comboBoxYear);

                ReportUtil.setMonthList(this.comboBoxMonth);

                //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
                

                //this.axlgxgridInOutReport.hadd("宣传品编号", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("宣传品名称", 1, 2000, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("销售价", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("前库存量", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("入库数量", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("入库金额", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("出库数量", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("出库金额", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("库存量", 1, 600, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("库存金额", 1, 800, false, ReportUtil.hfont);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品进销存报表", ex);
            }
        }

        private void InOutReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //util.SumData sumDataIn = util.SumData.getSumData(new BLL.InTable().GetInTableForReport2(startTime,
                //    endTime, conditon.ToString()));
                //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(startTime,
                //    endTime, conditon.ToString()));
                //string Ltext = "    日期区间：" + startTime + " -- " + endTime + "\n" +
                //    "             入库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 5, 2) + "\n" +
                //    "             出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 7, 2) + "\n" +
                //    "             入库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 6, 1) + "\n" +
                //    "             出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 8, 1);




                //string Btext = "库存总数量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 9, 2) +
                //               "          库存总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 10, 1);
                //string Rtext = DateTime.Now.ToShortDateString();

                //string title2 = "动态";
                //if (!this.radioButtonThisPreInfo.Checked)
                //{
                //    title2 = "";
                //    Ltext = "     入库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 5, 2) + "\n" +
                //    "             出库总量：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 7, 2) + "\n" +
                //    "             入库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 6, 1) + "\n" +
                //    "             出库总金额：" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 8, 1);
                //}
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridInOutReport, title + "宣传品" + title2 + "进销存统计报表", Ltext, Btext, Rtext);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品进销存报表",ex);
            }
        }

        string [] getScrpNoSql = new string[4];
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //this.conditon.Remove(0, this.conditon.Length);
                if (this.radioButtonYear.Checked)
                {
                    startTime = this.comboBoxYear.Text.Trim() + "-01-01";
                    endTime = this.comboBoxYear.Text.Trim() + "-12-31";
                    this.title = this.comboBoxYear.Text.Trim() + "年度";
                }
                else if (this.radioButtonMonth.Checked)
                {
                    startTime = this.comboBoxYear.Text.Trim() + "-" + this.comboBoxMonth.Text.Trim() + "-01";
                    int m = Int32.Parse(this.comboBoxMonth.Text.Trim()) + 1;
                    if (m == 13)
                    {
                        endTime = (Int32.Parse(this.comboBoxYear.Text.Trim()) + 1).ToString() + "-01-01";
                    }
                    else
                    {
                        string mon = m < 10 ? "0" + m.ToString() : m.ToString();
                        endTime = this.comboBoxYear.Text.Trim() + "-" + mon + "-01";
                    }
                    endTime = DateTime.Parse(endTime).AddDays(-1).ToShortDateString();
                    this.title = this.comboBoxYear.Text.Trim() + "年度" + this.comboBoxMonth.Text.Trim() + "月";
                }
                else if (this.radioButtonDate.Checked)
                {
                    startTime = this.dateTimePicker1.Value.ToShortDateString();
                    endTime = this.dateTimePicker2.Value.ToShortDateString();
                    this.title = this.dateTimePicker1.Value.ToShortDateString() + "至" + this.dateTimePicker2.Value.ToShortDateString();
                }

                this.title = this.title + "宣传品";
                string cond = "";// this.conditon.ToString();
                if (this.radioButtonThisPreInfo.Checked)
                {
                    cond = cond + " and (i_amount<>0) or (o_amount<>0)";
                    this.title = this.title + "动态";
                }
                else
                {
                    //cond = cond + "";
                }
                this.title = this.title + "进销存统计报表";
                //IList<IList<string>> list = new BLL.PreInfo().GetDataTablePreInfoForStatInOutSumspStoreqnt1(startTime, endTime, cond);
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridInOutReport, 1);
                //sumDataIn = util.SumData.getSumData(new BLL.InTable().GetInTableForReport2(startTime,
                //    endTime, cond));
                //sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(startTime,
                //    endTime, cond));
                startTime = startTime + " 00:00:00.000";
                endTime = endTime + " 23:59:59.990";
                dt = new BLL.PreInfo().GetDataTablePreInfoForStatInOutSumspStoreqnt1(startTime, endTime, cond);
                this.dataGridViewInOutReport.DataSource = dt;

                getScrpNoSql[0] = "select top 1 in_scrpno from intable where in_date >= '" + startTime + "' and in_date <='" + endTime + "' order by in_date asc,in_scrpno asc";
                getScrpNoSql[1] = "select top 1 in_scrpno from intable where in_date >= '" + startTime + "' and in_date <='" + endTime + "' order by in_date desc,in_scrpno desc";
                getScrpNoSql[2] = "select top 1 out_scrpno from outtable where out_date >= '" + startTime + "' and out_date <='" + endTime + "' order by out_date asc,out_scrpno asc";
                getScrpNoSql[3] = "select top 1 out_scrpno from outtable where out_date >= '" + startTime + "' and out_date <='" + endTime + "' order by out_date desc,out_scrpno desc";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品进销存报表",ex);
            }
        }

        private void radioButtonYear_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonYear.Checked)
            {
                this.comboBoxMonth.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                this.dateTimePicker2.Enabled = false;
                this.comboBoxYear.Enabled = true;
            }
        }

        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonMonth.Checked)
            {
                this.comboBoxMonth.Enabled = true;
                this.dateTimePicker1.Enabled = false;
                this.dateTimePicker2.Enabled = false;
                this.comboBoxYear.Enabled = true;
            }
        }

        private void radioButtonDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonDate.Checked)
            {
                this.comboBoxMonth.Enabled = false;
                this.dateTimePicker1.Enabled = true;
                this.dateTimePicker2.Enabled = true;
                this.comboBoxYear.Enabled = false;
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       

        private void setYearList()
        {
            for (int i = 2000; i < 2020; i++)
            {
                this.comboBoxYear.Items.Add(i.ToString());
            }
            this.comboBoxYear.SelectedIndex = 0;
        }

        private void setMonthList()
        {
            for (int i = 1; i <= 12; i++)
            {
                this.comboBoxMonth.Items.Add(i.ToString());
            }
            this.comboBoxMonth.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    BLL.PreInfo bllPreInfo = new PreInfo();
                    string scrpNo1 = "入库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    string scrpNo2 = "出库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[2], getScrpNoSql[3]); 
            
                    string sumInQnt = "入库总量：" + ReportUtil.getDataFromDataTable(dt, 4, 2);
                    string sumInPrice = "入库总金额：" + ReportUtil.getDataFromDataTable(dt, 5, 1);
                    string sumOutQnt = "出库总量：" + ReportUtil.getDataFromDataTable(dt, 6, 2);
                    string sumOutPrice = "出库总金额：" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                    string[] sumCount = bllPreInfo.GetPreInfoCount();
 
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridViewInOutReport, this.title, "", "",
                        sumInQnt, sumInPrice,
                        sumOutQnt, sumOutPrice, 
                        "库存总量：" + sumCount[0], "库存总金额：" + sumCount[1],
                        scrpNo1,scrpNo2,"",
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
                MyMessageBox.ShowErrorMessageBox("进销存报表打印",ex);
            }

        }

        //初始化宣传品名称下拉列表
        private void setComboBoxPno(CheckedListBox combo,string condition)
        {
            IList<PreInfoData> preInfoList = new BLL.PreInfo().GetPreInfoByCondition(condition);
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preInfoList.Count; i++)
            {
                PreInfoData data = preInfoList[i];
                valueList.Add(new util.ValueObject(data.P_no, data.P_no + inStrbypnoLength(data.P_no) + " | " + data.P_name));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";

            setComboBoxChecked(combo, this.checkBoxSateInOutTableAllPreInfo.Checked);
            
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

        private string inStrbypnoLength(string p_no)
        {
            int length = 25;
            StringBuilder str = new StringBuilder("");
            for (int i = 0; i < length - p_no.Length; i++)
            {
                str.Append(" ");
            }
            return str.ToString();
        }

        private void setComboBoxChecked(CheckedListBox combo, bool chk)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                combo.SetItemChecked(i, chk);
            }
        }

        private void checkBoxStatInOutTablePreTypeed_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxStatInOutTablePreTypeed.Checked)
            {
                this.comboBoxStatInOutTablePreType.Enabled = true;
                setComboBoxPno(this.comboBoxSateInOutTableP_no, "");
                //this.checkBoxSateInOutTableAllPreInfo.Enabled = false;
                //this.checkBoxSateInOutTableAllPreInfo.Checked = false;
            }
            else
            {
                this.comboBoxStatInOutTablePreType.Enabled = false;
                //this.comboBoxSateInOutTableP_no.Enabled = false;
                //this.checkBoxSateInOutTableAllPreInfo.Enabled = true;
                this.checkBoxSateInOutTableAllPreInfo.Checked = true;
                setComboBoxPno(this.comboBoxSateInOutTableP_no, " and pretype = '" + this.comboBoxStatInOutTablePreType.SelectedValue + "'");
            }
        }

        private void comboBoxStatInOutTablePreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setComboBoxPno(this.comboBoxSateInOutTableP_no, " and pretype = '" + this.comboBoxStatInOutTablePreType.SelectedValue + "'");
        }

        private void checkBoxSateInOutTableAllPreInfo_CheckedChanged(object sender, EventArgs e)
        {
            setComboBoxChecked(this.comboBoxSateInOutTableP_no, this.checkBoxSateInOutTableAllPreInfo.Checked);
        }


    }
}
