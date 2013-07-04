using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using psms.BLL;
using psms.Model;
using psms.util;
using Excel = Microsoft.Office.Interop.Excel;

namespace psms
{
    /// <summary>
    /// 宣传品进销存报表
    /// </summary>
    public partial class InOutReportForm : Form
    {
        DataTable dt;

        string title;
        string startTime = "1900-01-01";
        string endTime = "3000-01-01";
        StringBuilder conditon = new StringBuilder();
        public InOutReportForm()
        {
            InitializeComponent();
        }

        private void InOutReportForm_Load(object sender, EventArgs e)
        {
            try
            {
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

                //初始化货源

                BLL.InInfo ininfo = new psms.BLL.InInfo();
                this.cobInTableIn_Ou.DataSource = ininfo.GetAllInInfo();
                this.cobInTableIn_Ou.DisplayMember = "in_ou";
                this.cobInTableIn_Ou.ValueMember = "in_ou";
                //this.cobInTableIn_Ou.SelectedItem = this.cobInTableIn_Ou.Items[this.cobInTableIn_Ou.FindString("市场部")];
        
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
                    cond = cond + " and ((i_amount<>0) or (o_amount<>0))";
                    this.title = this.title + "动态";
                }
                else
                {
                    //cond = cond + "";
                }
                if (!this.checkBoxQnt.Checked)
                {
                    cond = cond + " and (e_qnt<>0)";
                }
                //2013-02-19 添加查询条件
                string inou = null;
                if (this.checkBoxInOu.Checked)
                {
                    inou = this.cobInTableIn_Ou.Text.ToString();
                }
                string planin = null;
                if (this.radioButtonSelectPlan.Checked)
                {
                    planin = this.comboBoxPlan.Text.Trim();
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
                //dt = new BLL.PreInfo().GetDataTablePreInfoForStatInOutSumspStoreqnt1(startTime, endTime, cond);
                dt = new BLL.PreInfo().GetDataTablePreInfoForStatInOutSumspStoreqnt2(startTime, endTime, inou, planin, cond);
                this.dataGridViewInOutReport.DataSource = dt;

                getScrpNoSql[0] = "select top 1 in_scrpno from intable where in_date >= '" + startTime + "' and in_date <='" + endTime + "' order by in_scrpno asc,in_date asc";
                getScrpNoSql[1] = "select top 1 in_scrpno from intable where in_date >= '" + startTime + "' and in_date <='" + endTime + "' order by in_scrpno desc,in_date desc";
                getScrpNoSql[2] = "select top 1 out_scrpno from outtable where out_date >= '" + startTime + "' and out_date <='" + endTime + "' order by out_scrpno asc,out_date asc";
                getScrpNoSql[3] = "select top 1 out_scrpno from outtable where out_date >= '" + startTime + "' and out_date <='" + endTime + "' order by out_scrpno desc,out_date desc";
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
                if (dt!=null&&dt.Rows.Count > 0)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.label4.Visible = true;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    BLL.PreInfo bllPreInfo = new PreInfo();
                    string scrpNo1 = "入库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    string scrpNo2 = "出库凭证编号：" + ReportUtil.getScrpNoStr(getScrpNoSql[2], getScrpNoSql[3]);

                    string sumInQnt = "入库总量：" + ReportUtil.getDataFromDataTable(dt, 4, 2);
                    string sumInPrice = "入库总金额：" + ReportUtil.getDataFromDataTable(dt, 5, 1);
                    string sumOutQnt = "出库总量：" + ReportUtil.getDataFromDataTable(dt, 6, 2);
                    string sumOutPrice = "出库总金额：" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                    string[] sumCount = bllPreInfo.GetPreInfoCount();

              
                    ExportExcel(this.title, dataGridViewInOutReport,sumInQnt,sumOutQnt,"库存总量：" + sumCount[0],
                        sumInPrice,sumOutPrice,"库存总金额：" + sumCount[1],scrpNo1,scrpNo2);
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("请先点击查询获得数据后再点击导出Excel");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("进销存报表导出Excel", ex);
            }
            this.button2.Enabled = true;
            this.label4.Visible = false;
        }
             


        /// <summary>
        /// DataGridView导出Excel
        /// </summary>
        /// <param name="strCaption">Excel文件中的标题</param>
        /// <param name="myDGV">DataGridView 控件</param>
        private void ExportExcel(string strCaption, DataGridView dgv,string sumInQnt,string sumOutQnt,string sumCount,
                        string sumInPrice, string sumOutPrice, string sumPrice, string scrpNo1, string scrpNo2)
        {
            Excel.Application excel;
            Excel._Workbook objBook;
            SaveFileDialog dg = new SaveFileDialog();//保存文件对话框，选择导出文件的存放位置
            dg.Filter = "xls files(*.xls)|*.xls";//保存为xls格式
            if (dg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dg.FileName.ToString();//保存文件的路径

                Excel.Workbooks objBooks;//接口 workbooks
                Excel.Sheets objSheets;// 接口 sheets
                Excel._Worksheet objSheet;//接口 worksheet
                excel = new Excel.Application();
                objBooks = excel.Workbooks;
                Object miss = System.Reflection.Missing.Value;
                objBook = objBooks.Add(miss);
                objSheets = objBook.Sheets;
                objSheet = (Excel._Worksheet)objSheets[1];

                excel.Visible = false; //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写 

                // 设置标题
                Microsoft.Office.Interop.Excel.Range range = objSheet.get_Range(excel.Cells[1, 1], excel.Cells[1, dgv.Columns.Count]); //标题所占的单元格数与DataGridView中的列数相同
                range.MergeCells = true;
                excel.ActiveCell.FormulaR1C1 = strCaption;
                excel.ActiveCell.Font.Size = 24;
                excel.ActiveCell.Font.Name = "隶书";
                excel.ActiveCell.Font.Bold = true;
               
                excel.ActiveCell.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;


                Microsoft.Office.Interop.Excel.Range range_title1 = objSheet.get_Range(excel.Cells[2, 1], excel.Cells[2, 2]);
                range_title1.MergeCells = true;
                range_title1.Font.Name = "黑体";
                range_title1.Font.Size = 12;     //设置字体大小
                range_title1.Font.Bold = true;
                range_title1.FormulaR1C1 = sumInQnt;
                Microsoft.Office.Interop.Excel.Range range_title2 = objSheet.get_Range(excel.Cells[3, 1], excel.Cells[3, 2]);
                range_title2.MergeCells = true;
                range_title2.Font.Name = "黑体";
                range_title2.Font.Size = 12;     //设置字体大小
                range_title2.Font.Bold = true;
                range_title2.FormulaR1C1 = sumOutQnt;
                Microsoft.Office.Interop.Excel.Range range_title3 = objSheet.get_Range(excel.Cells[4, 1], excel.Cells[4, 2]);
                range_title3.MergeCells = true;
                range_title3.Font.Name = "黑体";
                range_title3.Font.Size = 12;     //设置字体大小
                range_title3.Font.Bold = true;
                range_title3.FormulaR1C1 = sumCount;

                Microsoft.Office.Interop.Excel.Range range_title5 = objSheet.get_Range(excel.Cells[2, 3], excel.Cells[2, 6]);
                range_title5.MergeCells = true;
                range_title5.Font.Name = "黑体";
                range_title5.Font.Size = 12;     //设置字体大小
                range_title5.Font.Bold = true;
                range_title5.FormulaR1C1 = sumInPrice;
                Microsoft.Office.Interop.Excel.Range range_title6 = objSheet.get_Range(excel.Cells[3, 3], excel.Cells[3, 6]);
                range_title6.MergeCells = true;
                range_title6.Font.Name = "黑体";
                range_title6.Font.Size = 12;     //设置字体大小
                range_title6.Font.Bold = true;
                range_title6.FormulaR1C1 = sumOutPrice;
                Microsoft.Office.Interop.Excel.Range range_title7 = objSheet.get_Range(excel.Cells[4, 3], excel.Cells[4, 6]);
                range_title7.MergeCells = true;
                range_title7.Font.Name = "黑体";
                range_title7.Font.Size = 12;     //设置字体大小
                range_title7.Font.Bold = true;
                range_title7.FormulaR1C1 = sumPrice;

                Microsoft.Office.Interop.Excel.Range range_title8 = objSheet.get_Range(excel.Cells[2, 7], excel.Cells[2, 10]);
                range_title8.MergeCells = true;
                range_title8.Font.Name = "黑体";
                range_title8.Font.Size = 12;     //设置字体大小
                range_title8.Font.Bold = true;
                range_title8.FormulaR1C1 = scrpNo1;
                Microsoft.Office.Interop.Excel.Range range_title9 = objSheet.get_Range(excel.Cells[3, 7], excel.Cells[3, 10]);
                range_title9.MergeCells = true;
                range_title9.Font.Name = "黑体";
                range_title9.Font.Size = 12;     //设置字体大小
                range_title9.Font.Bold = true;
                range_title9.FormulaR1C1 = scrpNo2;
                Microsoft.Office.Interop.Excel.Range range_title10 = objSheet.get_Range(excel.Cells[4, 7], excel.Cells[4, 10]);
                range_title7.MergeCells = true;

                for (int i = 0; i < dgv.Columns.Count; i++) //生成Excel中列头名称   
                {
                    objSheet.Cells[6, i + 1] = dgv.Columns[i].HeaderText;
                }

                for (int i = 0; i < dgv.Rows.Count; i++) //把DataGridView当前页的数据保存在Excel中   
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].ValueType == typeof(string))
                        {
                            objSheet.Cells[i + 7, j + 1] = "'" + dgv[j, i].Value.ToString();
                        }
                        else
                        {
                            objSheet.Cells[i + 7, j + 1] = dgv[j, i].Value.ToString();
                        }
                    }
                }
                Excel.Range range_text = (Excel.Range)objSheet.get_Range("A6", "J" + (dgv.Rows.Count+6));     //获取Excel多个单元格区域：本例做为Excel表头
                range_text.EntireColumn.AutoFit();     //自动调整列宽
                range_text.Font.Size = 10;     //设置字体大小
                range_text.Borders.LineStyle = 1;     //设置单元格边框的粗细
                //range_text.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic, System.Drawing.Color.Black.ToArgb());     //给单元格加边框
                range_text.RowHeight = 28;
                objBook.SaveCopyAs(filepath);
                //设置禁止弹出保存和覆盖的询问提示框   
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;

                //确保Excel进程关闭   
                objBooks.Close();
                excel.Workbooks.Close();
                excel.Quit();
                excel = null;
                GC.Collect();
                MessageBox.Show("数据导出完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (System.IO.File.Exists(filepath))
                    System.Diagnostics.Process.Start(filepath); //保存成功后打开此文件

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

        private void radioButtonSelectPlan_CheckedChanged(object sender, EventArgs e)
        {

        } 





    }
}