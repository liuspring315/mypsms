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

    /// <summary>
    /// 宣传品赠送统计报表
    /// </summary>
    public partial class VipOuReportForm : Form
    {
        string title;
        string startTime = "1900-01-01";
        string endTime = "3000-01-01";
        StringBuilder conditon = new StringBuilder();
        DataTable dt;
        string btext = "";

        public VipOuReportForm()
        {
            InitializeComponent();
        }

        private void VipOuReportForm_Load(object sender, EventArgs e)
        {
            setComboBoxPno(this.comboBoxPreInfo);

            ReportUtil.setYearList(this.comboBoxYear);

            ReportUtil.setMonthList(this.comboBoxMonth);

            setHeadForReport1();
        }

        private void VipOuReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    //util.SumData sumDataOut = util.SumData.getSumData(new BLL.OutTable().GetOutTableForSUM(startTime,
                    //    endTime, this.conditon.ToString()));
                    string outCount = "0";
                    string outdemcal = "0.00";
                    //this.progressBar1.Visible = true;
                    //this.labelWait.Visible = true;
                    //string outOu = "";
                    if (this.radioButtonAllPreInfo.Checked)
                    {
                        outCount = "出库数量：" + ReportUtil.getDataFromDataTable(dt, 1, 2);
                        outdemcal = "出库金额：" + ReportUtil.getDataFromDataTable(dt, 2, 1);
                        DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView1, this.title, "", "",
                        outCount, outdemcal, "",
                        "", btext, "",
                        true);
                        dgp.Print();
                        //WordHelper.ToWordFormInReportDataTable("vipou1.doc", dt, this.title, outCount, outdemcal, btext, progressBar1);
                        
                    }
                    else
                    {
                        outCount = "出库数量：" + ReportUtil.getDataFromDataTable(dt, 6, 2);
                        outdemcal = "出库金额：" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                        //WordHelper.ToWordFormInReportDataTable("vipou2.doc", dt, this.title, outCount, outdemcal, btext, progressBar1);
                        DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView2, this.title, "", "",
                        outCount, outdemcal, "",
                        "", btext, "",
                        true);
                        dgp.Print();
                       
                    }

                    
                   
                    //this.labelWait.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品赠送统计报表", ex);
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

        private void radioButtonAllPreInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonAllPreInfo.Checked)
            {
                this.comboBoxPreInfo.Enabled = false;
                setHeadForReport1();
            }
            else
            {
                this.comboBoxPreInfo.Enabled = true;
                setHeadForReport2();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.conditon.Remove(0, this.conditon.Length);
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
                    this.title = this.comboBoxYear.Text.Trim() + "年" + this.comboBoxMonth.Text.Trim() + "月";
                }
                else if (this.radioButtonDate.Checked)
                {
                    startTime = this.dateTimePicker1.Value.ToShortDateString();
                    endTime = this.dateTimePicker2.Value.ToShortDateString();
                    this.title = this.dateTimePicker1.Value.ToShortDateString() + "至" + this.dateTimePicker2.Value.ToShortDateString();
                }

                this.btext = startTime + "至" + endTime;
                if (this.radioButtonThisPreInfo.Checked)
                {
                    this.conditon.Append(" and outtable.vip_ou = '").Append(((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Value).Append("'");
                    this.title = this.title + ((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Text;
                    dt = new BLL.OutTable().GetOutTableDataTableForStatQntSum(startTime, endTime, conditon.ToString());
                    //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridVipOuReport, 1);
                    this.dataGridView2.Visible = true;
                    this.dataGridView1.Visible = false;
                    this.dataGridView2.DataSource = dt;
                }
                else
                {
                    //IList<IList<string>> list = new BLL.OutTable().GetStatVipOuGroupByOutOuByCon(startTime, endTime, conditon.ToString());
                    //util.ReportUtil.setDataForAxlgxgridAddCount(list, this.axlgxgridVipOuReport, 1);

                    conditon.Append(" and out_date >= '").Append(startTime).Append("' and out_date <= '").Append(endTime).Append("' ");
                    dt = new BLL.OutTable().GetStatVipOuGroupByOutOuByCon(conditon.ToString());
                    
                    this.dataGridView2.Visible = false;
                    this.dataGridView1.Visible = true;
                    this.dataGridView1.DataSource = dt;
                }
                this.title = this.title + "宣传品赠送情况统计报表";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品赠送统计报表", ex);
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

        //初始化danwei下拉列表
        private void setComboBoxPno(ComboBox combo)
        {
            IList<VipInfoData> preInfoList = new BLL.VipInfo().GetAllVipInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preInfoList.Count; i++)
            {
                VipInfoData data = preInfoList[i];
                valueList.Add(new util.ValueObject(data.Vip_ou, data.Vip_ou));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }



        private void setHeadForReport1()
        {
            //util.ReportUtil.removeDataForAxlgxgrid(this.axlgxgridVipOuReport);
            ////为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //this.axlgxgridVipOuReport.hadd("序号", 1, 500, false, ReportUtil.hfont);
            //this.axlgxgridVipOuReport.hadd("赠送分类", 1, 2000, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("合计赠送数量", 1, 1500, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("合计赠送金额", 1, 1500, false, ReportUtil.hfont);
            this.dataGridView1.Visible = true;
            this.dataGridView2.Visible = false;
        }

        private void setHeadForReport2()
        {
            //util.ReportUtil.removeDataForAxlgxgrid(this.axlgxgridVipOuReport);
            ////为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
            //this.axlgxgridVipOuReport.hadd("出库日期", 1, 900, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("请领单位", 1, 1200, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("赠送分类", 1, 1200, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("宣传品编号", 1, 800, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("宣传品名称", 1, 1200, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("单位", 1, 300, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("数量", 1, 600, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("成本价", 1, 800, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("销售价", 1, 800, false, ReportUtil.hfont);
            //axlgxgridVipOuReport.hadd("出库金额", 1, 800, false, ReportUtil.hfont);
            this.dataGridView1.Visible = false;
            this.dataGridView2.Visible = true;
        }


    }
}