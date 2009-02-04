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

namespace psms
{
    /// <summary>
    /// ����Ʒ�����汨��
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

                //Ϊ�ؼ������,��������Ϊ:�б���,ģʽ(1Ϊtextbox,2Ϊcombox),�п�,�Ƿ�����༭
                

                //this.axlgxgridInOutReport.hadd("����Ʒ���", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("����Ʒ����", 1, 2000, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("���ۼ�", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("ǰ�����", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("�������", 1, 700, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("�����", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("��������", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("������", 1, 800, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("�����", 1, 600, false, ReportUtil.hfont);
                //axlgxgridInOutReport.hadd("�����", 1, 800, false, ReportUtil.hfont);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒ�����汨��", ex);
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
                //string Ltext = "    �������䣺" + startTime + " -- " + endTime + "\n" +
                //    "             ���������" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 5, 2) + "\n" +
                //    "             ����������" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 7, 2) + "\n" +
                //    "             ����ܽ�" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 6, 1) + "\n" +
                //    "             �����ܽ�" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 8, 1);




                //string Btext = "�����������" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 9, 2) +
                //               "          ����ܽ�" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 10, 1);
                //string Rtext = DateTime.Now.ToShortDateString();

                //string title2 = "��̬";
                //if (!this.radioButtonThisPreInfo.Checked)
                //{
                //    title2 = "";
                //    Ltext = "     ���������" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 5, 2) + "\n" +
                //    "             ����������" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 7, 2) + "\n" +
                //    "             ����ܽ�" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 6, 1) + "\n" +
                //    "             �����ܽ�" + ReportUtil.getDataFromAxlgxgrid(axlgxgridInOutReport, 8, 1);
                //}
                //util.ReportUtil.setPrintInfoForAxlgxgrid(this.axlgxgridInOutReport, title + "����Ʒ" + title2 + "������ͳ�Ʊ���", Ltext, Btext, Rtext);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒ�����汨��",ex);
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
                    this.title = this.comboBoxYear.Text.Trim() + "���";
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
                    this.title = this.comboBoxYear.Text.Trim() + "���" + this.comboBoxMonth.Text.Trim() + "��";
                }
                else if (this.radioButtonDate.Checked)
                {
                    startTime = this.dateTimePicker1.Value.ToShortDateString();
                    endTime = this.dateTimePicker2.Value.ToShortDateString();
                    this.title = this.dateTimePicker1.Value.ToShortDateString() + "��" + this.dateTimePicker2.Value.ToShortDateString();
                }

                this.title = this.title + "����Ʒ";
                string cond = "";// this.conditon.ToString();
                if (this.radioButtonThisPreInfo.Checked)
                {
                    cond = cond + " and (i_amount<>0) or (o_amount<>0)";
                    this.title = this.title + "��̬";
                }
                else
                {
                    //cond = cond + "";
                }
                this.title = this.title + "������ͳ�Ʊ���";
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
                MyMessageBox.ShowErrorMessageBox("����Ʒ�����汨��",ex);
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
                    string scrpNo1 = "���ƾ֤��ţ�" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    string scrpNo2 = "����ƾ֤��ţ�" + ReportUtil.getScrpNoStr(getScrpNoSql[2], getScrpNoSql[3]); 
            
                    string sumInQnt = "���������" + ReportUtil.getDataFromDataTable(dt, 4, 2);
                    string sumInPrice = "����ܽ�" + ReportUtil.getDataFromDataTable(dt, 5, 1);
                    string sumOutQnt = "����������" + ReportUtil.getDataFromDataTable(dt, 6, 2);
                    string sumOutPrice = "�����ܽ�" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                    string[] sumCount = bllPreInfo.GetPreInfoCount();
 
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridViewInOutReport, this.title, "", "",
                        sumInQnt, sumInPrice,
                        sumOutQnt, sumOutPrice, 
                        "���������" + sumCount[0], "����ܽ�" + sumCount[1],
                        scrpNo1,scrpNo2,"",
                        true);
                    dgp.Print();
                }
                else
                {
                    MyMessageBox.ShowInfoMessageBox("���ȵ����ѯ������ݺ��ٵ����ӡ");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�����汨���ӡ",ex);
            }

        }


    }
}