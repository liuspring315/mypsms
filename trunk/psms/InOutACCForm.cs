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
    public partial class InOutACCForm : Form
    {

        private DataTable InscrpTable;
        private DataTable OutscrpTable;

        //先做入库 后作出库
        private bool ined = false;

        public InOutACCForm()
        {
            InitializeComponent();
        }

        private void InOutACCForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void InOutACCForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridViewInAcc.AutoGenerateColumns = false;
                this.dataGridViewOutAcc.AutoGenerateColumns = false;
                setDataGridData();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("做账窗口加载",ex);
            }
        }

        private void setDataGridData()
        {
            this.InscrpTable = new BLL.InScrp().GetInScrpForAcc();
            this.dataGridViewInAcc.DataSource = this.InscrpTable;
            if (this.InscrpTable.Rows.Count == 0)
            {
                this.ined = true;
            }

            this.OutscrpTable = new BLL.OutScrp().GetOutScrpForAcc();
            this.dataGridViewOutAcc.DataSource = this.OutscrpTable;

            this.labelInCount.Text = this.InscrpTable.Rows.Count.ToString();
            this.labelOutCount.Text = this.OutscrpTable.Rows.Count.ToString();
        }

        private void btnBeginInAcc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("请确认入库凭证信息，开始做入库帐吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (this.InscrpTable.Rows.Count == 0)
                    {
                        MessageBox.Show("没有要做账的入库信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        IList<PreAccInfo> list = new List<PreAccInfo>();
                        //SELECT INTABLE.IN_SCRPNO, IN_OU, IN_DATE, IN_COST, IN_ACC, IN_MEMO, INSCRP.P_NO, 6
                        //QNT, IN_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT
                        for (int i = 0; i < this.InscrpTable.Rows.Count; i++)
                        {

                            string scrpno = this.InscrpTable.Rows[i][0].ToString().Trim();
                            string pno = this.InscrpTable.Rows[i][6].ToString().Trim();
                            int qnt = Int32.Parse(this.InscrpTable.Rows[i][7].ToString().Trim());
                            decimal cost = decimal.Parse(this.InscrpTable.Rows[i][3].ToString());

                            int acc_qnt = Int32.Parse(this.InscrpTable.Rows[i][10].ToString());
                            int sqnt = acc_qnt + qnt;

                            decimal unit_price = decimal.Parse(this.InscrpTable.Rows[i][11].ToString());
                            decimal scost = unit_price * sqnt;
                            PreAccInfo data = new PreAccInfo("r", scrpno, pno, qnt, cost, sqnt, scost);
                            list.Add(data);
                        }
                        if (new BLL.PreAcc().insertPreAccForInTable(list))
                        {
                            MessageBox.Show("入库信息做账成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ined = true;
                            this.tabControlAcc.SelectedTab = this.tabPageOutAcc;
                            setDataGridData();

                        }
                        else
                        {
                            MessageBox.Show("入库信息做账失败", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("入库信息做账", ex);
            }
        }

        private void btnInClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOutClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBeginOutAcc_Click(object sender, EventArgs e)
        {
            try
            {
                if (ined)
                {
                    if (MessageBox.Show("请确认出库凭证信息，开始做出库帐吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (this.OutscrpTable.Rows.Count == 0)
                        {
                            MessageBox.Show("没有要做账的出库信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            IList<PreAccInfo> list = new List<PreAccInfo>();
                            for (int i = 0; i < this.OutscrpTable.Rows.Count; i++)
                            {
                                //OUTTABLE.OUT_SCRPNO, OUT_OU, VIP_OU, OUT_DATE, OUT_COST, OUT_ACC, OUT_MEMO,6
                                //OUTSCRP.P_NO, QNT, OUT_PRICE, PREINFO.P_NAME, PREINFO.ACC_QNT,UNIT_PRICE
                                string scrpno = this.OutscrpTable.Rows[i][0].ToString().Trim();
                                string pno = this.OutscrpTable.Rows[i][7].ToString().Trim();
                                int qnt = Int32.Parse(this.OutscrpTable.Rows[i][8].ToString().Trim());
                                decimal cost = decimal.Parse(this.OutscrpTable.Rows[i][4].ToString());

                                int acc_qnt = Int32.Parse(this.OutscrpTable.Rows[i][11].ToString());
                                int sqnt = acc_qnt - qnt;

                                decimal unit_price = decimal.Parse(this.OutscrpTable.Rows[i][12].ToString());
                                decimal scost = unit_price * sqnt;
                                PreAccInfo data = new PreAccInfo("c", scrpno, pno, qnt, cost, sqnt, scost);
                                list.Add(data);
                            }
                            if (new BLL.PreAcc().insertPreAccForOutTable(list))
                            {
                                MessageBox.Show("出库信息做账成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                setDataGridData();
                            }
                            else
                            {
                                MessageBox.Show("出库信息做账失败", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先做入库帐再做出库帐", "注意", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("出库信息做账",ex);
            }



        }










    }
}