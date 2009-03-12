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
        public StoreReportForm()
        {
            InitializeComponent();
        }

        private void StoreReportForm_Load(object sender, EventArgs e)
        {
            try
            {     
                setComboBoxPno(this.comboBoxStatInOutTablePreType);
                setComboBoxPno(this.comboBoxSateInOutTableP_no, " and pretype = '" +
                    this.comboBoxStatInOutTablePreType.SelectedValue.ToString() + "'");
                
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品库存统计报表", ex);
            }
        }

        private void InOutReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }


        string [] getScrpNoSql = new string[4];
        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {


                StringBuilder cond = new StringBuilder("SELECT p_no,p_name,unit_price,cost_price,acc_qnt,acc_qnt*unit_price as e_price FROM PREINFO p where 1=1 ");
                if (!this.checkBoxIncludeQnt0.Checked)
                {
                    cond.Append(" and acc_qnt <> 0");
                }
                if (this.checkBoxSateInOutTableAllPreInfo.Checked)
                {
                    cond.Append(" and preType = '").Append(this.comboBoxStatInOutTablePreType.SelectedValue).Append("'");
                    this.title = this.comboBoxStatInOutTablePreType.SelectedValue + "统计报表";
                }
                else
                {
                    if (comboBoxSateInOutTableP_no.CheckedItems.Count > 0)
                    {
                        cond.Append(" and p_no in (");
                        for (int x = 0; x < comboBoxSateInOutTableP_no.CheckedItems.Count - 1; x++)
                        {
                            cond.Append("'").Append(((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[x]).Value).Append("',");
                        }
                        cond.Append("'").Append(((util.ValueObject)this.comboBoxSateInOutTableP_no.CheckedItems[comboBoxSateInOutTableP_no.CheckedItems.Count - 1]).Value).Append("') ");
                        this.title = this.comboBoxStatInOutTablePreType.SelectedValue + "统计报表";
                    }
                    else
                    {
                        this.title = "所有系列统计报表";
                    }
                }
                
                dt = new BLL.PreInfo().GetDataTableBySql(cond.ToString());
                this.dataGridViewInOutReport.DataSource = dt;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("宣传品库存统计报表",ex);
            }
        }

        


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string sumQnt = "库存总量：" + ReportUtil.getDataFromDataTable(dt, 4, 2);
                    string sumPrice = "库存总金额：" + ReportUtil.getDataFromDataTable(dt, 5, 1);
 
                    DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridViewInOutReport, this.title, "", "",
                        "", "",
                        " ", " ", 
                        sumQnt, sumPrice,
                        " "," " , "",
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

        private void comboBoxStatInOutTablePreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setComboBoxPno(this.comboBoxSateInOutTableP_no, " and pretype = '" + 
                this.comboBoxStatInOutTablePreType.SelectedValue.ToString() + "'");
        }



        private void comboBoxSateInOutTableP_no_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBoxSateInOutTableAllPreInfo_Click(object sender, EventArgs e)
        {
            setComboBoxChecked(this.comboBoxSateInOutTableP_no, this.checkBoxSateInOutTableAllPreInfo.Checked);
        }

        private void comboBoxSateInOutTableP_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkBoxSateInOutTableAllPreInfo.Checked)
            {
                if (this.comboBoxSateInOutTableP_no.CheckedItems.Count != this.comboBoxSateInOutTableP_no.Items.Count)
                {
                    this.checkBoxSateInOutTableAllPreInfo.Checked = false;
                }
            }
            else
            {
                if (this.comboBoxSateInOutTableP_no.CheckedItems.Count == this.comboBoxSateInOutTableP_no.Items.Count)
                {
                    this.checkBoxSateInOutTableAllPreInfo.Checked = true;
                }
            }
        }


    }
}
