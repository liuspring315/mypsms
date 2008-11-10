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
    /// 出库统计报表
    /// </summary>
    public partial class OutTableReportForm : Form
    {

        string title = "";
        string btext = "";
        string strCond = "";
        string startTime = "1900-01-01";
        string endTime = "3000-01-01";
        StringBuilder conditon = new StringBuilder();
        DataTable dt;

        public OutTableReportForm()
        {
            InitializeComponent();
        }

        private void OutTableReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                setComboBoxPreType(this.comboBoxPreType);

                setComboBoxPno(this.comboBoxPreInfo);

                ReportUtil.setYearList(this.comboBoxYear);

                ReportUtil.setMonthList(this.comboBoxMonth);

                //为控件添加列,参数依次为:列标题,模式(1为textbox,2为combox),列宽,是否允许编辑
                //this.axlgxgridOutTableReport.hadd("出库时间", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("领取部门", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("赠送分类", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("宣传品编号", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("宣传品名称", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("单价", 1, 800, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("出库数量", 1, 800, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("出库金额", 1, 800, false, ReportUtil.hfont);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库报表加载",ex);
            }
        }

        private void OutTableReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    BLL.PreInfo bllPreInfo = new PreInfo();
                    string scrpNo = "出库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    if (this.radioButtonThisPreInfo.Checked || this.radioButtonSelectPreType.Checked)
                    {
                        scrpNo = strCond;
                    }

                    string sumOutQnt = "出库总量：" +　ReportUtil.getDataFromDataTable(dt, 6, 2);
                    string sumOutPrice = "出库总金额：" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                    string titleStr = title + "宣传品出库统计报表";

                    //this.progressBar1.Visible = true;
                    //this.labelWait.Visible = true;
                    //WordHelper.ToWordFormInReportDataTable("outreport.doc", dt, titleStr, sumOutQnt, sumOutPrice, this.btext, progressBar1);
                    //this.labelWait.Visible = false;
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView1, titleStr, "", "",
                        sumOutQnt, sumOutPrice, "",
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
                MyMessageBox.ShowErrorMessageBox("宣传品出库报表打印", ex);
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
            }
            else
            {
                this.comboBoxPreInfo.Enabled = true;
            }
        }

        string[] getScrpNoSql = new string[2];
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
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
                    string mon = m < 10 ? "" + m.ToString() : m.ToString();
                    endTime = this.comboBoxYear.Text.Trim() + "-" + mon + "-01";
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
                if (this.radioButtonSelectPreType.Checked)
                {
                    this.conditon.Append(" and preinfo.pretype = '").Append(this.comboBoxPreType.Text.Trim()).Append("'");
                    this.strCond = strCond + "宣传品系列：" + this.comboBoxPreType.Text.Trim();
                }

                //IList<IList<string>> list = new BLL.OutTable().GetOutTableForStatQntSum(startTime, endTime, conditon.ToString());
                //util.ReportUtil.setDataForAxlgxgrid(list, this.axlgxgridOutTableReport, 1);
                dt = new BLL.OutTable().GetOutTableDataTableForStatQntSum(startTime, endTime, conditon.ToString());
                this.dataGridView1.DataSource = dt;

                getScrpNoSql[0] = "select top 1 outtable.out_scrpno from outtable,outscrp,preinfo where preinfo.p_no=outscrp.p_no and outscrp.out_scrpno = outtable.out_scrpno and out_date >= '" + startTime + "' and out_date <='" + endTime + "' " + conditon.ToString() + " order by outtable.out_scrpno asc";
                getScrpNoSql[1] = "select top 1 outtable.out_scrpno from outtable,outscrp,preinfo where preinfo.p_no=outscrp.p_no and outscrp.out_scrpno = outtable.out_scrpno and out_date >= '" + startTime + "' and out_date <='" + endTime + "' " + conditon.ToString() + " order by outtable.out_scrpno desc";
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库凭证报表",ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


        



    }
}