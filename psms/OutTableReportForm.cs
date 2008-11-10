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
    /// ����ͳ�Ʊ���
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

                //Ϊ�ؼ������,��������Ϊ:�б���,ģʽ(1Ϊtextbox,2Ϊcombox),�п�,�Ƿ�����༭
                //this.axlgxgridOutTableReport.hadd("����ʱ��", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("��ȡ����", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("���ͷ���", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("����Ʒ���", 1, 1000, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("����Ʒ����", 1, 1500, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("����", 1, 800, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("��������", 1, 800, false, ReportUtil.hfont);
                //axlgxgridOutTableReport.hadd("������", 1, 800, false, ReportUtil.hfont);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("���ⱨ�����",ex);
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
                    string scrpNo = "����ƾ֤��ţ�" + ReportUtil.getScrpNoStr(getScrpNoSql[0], getScrpNoSql[1]);
                    if (this.radioButtonThisPreInfo.Checked || this.radioButtonSelectPreType.Checked)
                    {
                        scrpNo = strCond;
                    }

                    string sumOutQnt = "����������" +��ReportUtil.getDataFromDataTable(dt, 6, 2);
                    string sumOutPrice = "�����ܽ�" + ReportUtil.getDataFromDataTable(dt, 7, 1);
                    string titleStr = title + "����Ʒ����ͳ�Ʊ���";

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
                    MyMessageBox.ShowInfoMessageBox("���ȵ����ѯ������ݺ��ٵ����ӡ");
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("����Ʒ���ⱨ���ӡ", ex);
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
                this.btext = "�������䣺";
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
                    string mon = m < 10 ? "" + m.ToString() : m.ToString();
                    endTime = this.comboBoxYear.Text.Trim() + "-" + mon + "-01";
                    endTime = DateTime.Parse(endTime).AddDays(-1).ToShortDateString();
                    this.title = this.comboBoxYear.Text.Trim() + "��" + this.comboBoxMonth.Text.Trim() + "��";
                }
                else if (this.radioButtonDate.Checked)
                {
                    startTime = this.dateTimePicker1.Value.ToShortDateString();
                    endTime = this.dateTimePicker2.Value.ToShortDateString();
                    this.title = this.dateTimePicker1.Value.ToShortDateString() + "��" + this.dateTimePicker2.Value.ToShortDateString();
                }
                this.btext = this.btext + startTime + "��" + endTime;
                if (this.radioButtonThisPreInfo.Checked)
                {
                    this.conditon.Append(" and preinfo.p_no = '").Append(((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Value).Append("'");
                    this.strCond = "����Ʒ��" + ((util.ValueObject)this.comboBoxPreInfo.SelectedItem).Text + "��";
                }
                if (this.radioButtonSelectPreType.Checked)
                {
                    this.conditon.Append(" and preinfo.pretype = '").Append(this.comboBoxPreType.Text.Trim()).Append("'");
                    this.strCond = strCond + "����Ʒϵ�У�" + this.comboBoxPreType.Text.Trim();
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
                MyMessageBox.ShowErrorMessageBox("����ƾ֤����",ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

        //��ʼ������Ʒ���������б�
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

        //��ʼ������Ʒϵ�������б�
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