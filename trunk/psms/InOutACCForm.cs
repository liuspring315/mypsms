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

        //������� ��������
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
                MyMessageBox.ShowErrorMessageBox("���˴��ڼ���",ex);
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
                if (MessageBox.Show("��ȷ�����ƾ֤��Ϣ����ʼ���������", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (this.InscrpTable.Rows.Count == 0)
                    {
                        MessageBox.Show("û��Ҫ���˵������Ϣ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("�����Ϣ���˳ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ined = true;
                            this.tabControlAcc.SelectedTab = this.tabPageOutAcc;
                            setDataGridData();

                        }
                        else
                        {
                            MessageBox.Show("�����Ϣ����ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�����Ϣ����", ex);
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
                    if (MessageBox.Show("��ȷ�ϳ���ƾ֤��Ϣ����ʼ����������", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (this.OutscrpTable.Rows.Count == 0)
                        {
                            MessageBox.Show("û��Ҫ���˵ĳ�����Ϣ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("������Ϣ���˳ɹ�", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                setDataGridData();
                            }
                            else
                            {
                                MessageBox.Show("������Ϣ����ʧ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("���������������������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("������Ϣ����",ex);
            }



        }










    }
}