using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.Model;
using psms.BLL;
using psms.util;

namespace psms
{
    /// <summary>
    /// 宣传品入库报表
    /// </summary>
    public partial class InTableReportForm : Form
    {
        string title;
        string btext = "";
        string strCond = "";
        string startTime = "1900-01-01";
        string endTime = "3000-01-01";
        StringBuilder conditon = new StringBuilder();
        DataTable dt;

        public InTableReportForm()
        {
            InitializeComponent();
        }

        private void InTableReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                setComboBoxPreType(this.comboBoxPreType);

                setComboBoxPno(this.comboBoxPreInfo);

                ReportUtil.setYearList(this.comboBoxYear);

                ReportUtil.setMonthList(this.comboBoxMonth);

                //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
                //axlgxgridInTableReport.hadd("入库时间", 1, 900, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("提货单号", 1, 900, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("宣传品编号", 1, 900, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("宣传品名称", 1, 2000, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("单位", 1, 400, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("单价", 1, 600, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("入库数量", 1, 800, false, ReportUtil.hfont);
                ////axlgxgridInTableReport.hadd("成本价", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("入库金额", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInTableReport.hadd("进货渠道", 1, 800, false, ReportUtil.hfont);

                setComboBoxQueryThisIn_scrpno();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品入库报表", ex);
            }
        }

        private void setComboBoxQueryThisIn_scrpno()
        {
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
            IList<InTableInfo> list = new BLL.InTable().GetInTableByCondition("and i.in_date >= '" + startTime + "' and i.in_date <= '" + endTime + "'");
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < list.Count; i++)
            {
                InTableInfo data = list[i];
                valueList.Add(new util.ValueObject(data.In_scrpno.ToString(), data.In_scrpno));
            }
            this.comboBoxQueryThisIn_scrpno.DataSource = valueList;
            this.comboBoxQueryThisIn_scrpno.DisplayMember = "text";
            this.comboBoxQueryThisIn_scrpno.ValueMember = "value";
            

        }

        private void InTableReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                if (dt!=null && dt.Rows.Count > 0)
                {
                    BLL.PreInfo bllPreInfo = new PreInfo();
                    string scrpNo = "";//"入库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    if (this.radioButtonThisPreInfo.Checked || this.radioButtonSelectPreType.Checked || this.radioButtonSelectPlan.Checked)
                    {
                        scrpNo = strCond;
                    }

                    string sumInQnt = "入库总量：" + ReportUtil.getDataFromDataTable(dt, 7, 2);
                    string sumInPrice = "入库总金额：" + ReportUtil.getDataFromDataTable(dt, 8, 1);
                    string titleStr = title + "宣传品入库统计报表";

                    //this.progressBar1.Visible = true;
                    //this.labelWait.Visible = true;
                    //WordHelper.ToWordFormInReportDataTable("inreport.doc", dt, titleStr, sumInQnt, sumInPrice,this.btext, progressBar1);
                    //this.labelWait.Visible = false;
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView1, titleStr, "", "",
                        sumInQnt, sumInPrice, "",
                        "", btext, scrpNo,
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
                MyMessageBox.ShowErrorMessageBox("宣传品入库报表打印", ex);
            }
        }

        //初始化宣传品名称下拉列表
        private void setComboBoxPno(ComboBox combo)
        {
            IList<PreInfoData> preInfoList = new BLL.PreInfo().GetAllPreInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preInfoList.Count; i++)
            {
                PreInfoData data = preInfoList[i];
                valueList.Add(new util.ValueObject(data.P_no, data.P_no + " | " + data.P_name));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        string[] getScrpNoSql = new string[2];
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.strCond = "";
                this.conditon.Remove(0, this.conditon.Length);
                this.btext = "日期区间：";
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
                this.btext = this.btext + startTime + "至" + endTime;
                if (this.radioButtonThisPreInfo.Checked)
                {
                    this.conditon.Append(" and preinfo.p_no = '").Append(((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Value).Append("'");
                    this.strCond = "宣传品：" + ((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Text + "；";
                }
                if (this.radioButtonSelectPlan.Checked)
                {
                    this.conditon.Append(" and intable.planin = '").Append(this.comboBoxPlan.Text.Trim()).Append("'");
                    this.strCond = strCond + "计划：" + this.comboBoxPlan.Text.Trim() + "；";
                }
                if (this.radioButtonSelectPreType.Checked)
                {
                    this.conditon.Append(" and preinfo.pretype = '").Append(this.comboBoxPreType.Text.Trim()).Append("'");
                    this.strCond = strCond + "宣传品系列：" + this.comboBoxPreType.Text.Trim();
                }
                if (!this.checkBoxQueryAllInTable.Checked)
                {
                    if (this.comboBoxQueryThisIn_scrpno.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("请选择要查询的入库凭证编号或者选中查询全部入库凭证");
                        return;
                    }
                    conditon.Append(" and (");
                    for (int x = 0; x < comboBoxQueryThisIn_scrpno.CheckedItems.Count - 1; x++)
                    {
                        conditon.Append(" intable.in_scrpno = '").Append(((util.ValueObject)this.comboBoxQueryThisIn_scrpno.CheckedItems[x]).Value).Append("' or ");
                    }
                    conditon.Append(" intable.in_scrpno = '").Append(((util.ValueObject)this.comboBoxQueryThisIn_scrpno.CheckedItems[comboBoxQueryThisIn_scrpno.CheckedItems.Count - 1]).Value).Append("') ");
                }
                startTime = startTime + " 00:00:00.000";
                endTime = endTime + " 23:59:59.999";
                dt = new BLL.InTable().GetDataTableInTableForReport(startTime, endTime, conditon.ToString());
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridInTableReport, 1);
                this.dataGridView1.DataSource = dt;

                getScrpNoSql[0] = "select top 1 intable.in_scrpno from intable,inscrp,preinfo where intable.in_scrpno = inscrp.in_scrpno and inscrp.p_no=preinfo.p_no and in_date >= '" + startTime + "' and in_date <='" + endTime + "' " + conditon.ToString() + " order by intable.in_date asc,intable.in_scrpno asc";
                getScrpNoSql[1] = "select top 1 intable.in_scrpno from intable,inscrp,preinfo where intable.in_scrpno = inscrp.in_scrpno and inscrp.p_no=preinfo.p_no and in_date >= '" + startTime + "' and in_date <='" + endTime + "' " + conditon.ToString() + " order by intable.in_date desc,intable.in_scrpno desc";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库统计报表",ex);
            }
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

        private void radioButtonYear_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonYear.Checked)
            {
                this.comboBoxMonth.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                this.dateTimePicker2.Enabled = false;
                this.comboBoxYear.Enabled = true;
            }
            dateTimePicker2_ValueChanged(sender,e);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dateTimePicker2_ValueChanged(sender, e);
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
            dateTimePicker2_ValueChanged(sender, e);
        }

        private void radioButtonAllPreInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonAllPreInfo.Checked)
            {
                this.comboBoxPreInfo.Enabled = false;
            }
            else
            {
                this.comboBoxPreInfo.Enabled = true;
            }
        }

        private void radioButtonPlanAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonPlanAll.Checked)
            {
                this.comboBoxPlan.Enabled = false;
            }
            else
            {
                this.comboBoxPlan.Enabled = true;
            }
        }

        private void radioButtonAllPreType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonSelectPreType.Checked)
            {
                this.comboBoxPreType.Enabled = true;
            }
            else
            {
                this.comboBoxPreType.Enabled = false;
            }
        }

        //初始化宣传品系列下拉列表
        private void setComboBoxPreType(ComboBox combo)
        {
            IList<PreTypeInfo> preTypeList = new BLL.PreType().GetAllPreTypeInfo();
            IList<util.ValueObject> valueList = new List<util.ValueObject>();
            for (int i = 0; i < preTypeList.Count; i++)
            {
                PreTypeInfo data = preTypeList[i];
                valueList.Add(new util.ValueObject(data.Code.ToString(), data.TypeName));
            }
            combo.DataSource = valueList;
            combo.DisplayMember = "text";
            combo.ValueMember = "value";
        }

        private void checkBoxQueryAllInTable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxQueryAllInTable.Checked)
            {
                this.comboBoxQueryThisIn_scrpno.Enabled = false;
            }
            else
            {
                this.comboBoxQueryThisIn_scrpno.Enabled = true;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            this.setComboBoxQueryThisIn_scrpno();
        }







    }
}