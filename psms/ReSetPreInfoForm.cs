using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using psms.Model;
using psms.util;

namespace psms
{
    public partial class ReSetPreInfoForm : Form
    {

        #region �ֶ�

        //Ҫ�̴������Ʒ��Ϣ
        private IList<PreInfoData> preInfoList;
        //�̴��ļ�¼
        private BindingList<CheckTableInfo> checkTableList = new BindingList<CheckTableInfo>();
        //����
        private int index = 0;
        //�ڼ����̴�
        private int check_no = 0;
        //�����̴�ʱ��
        private DateTime thisTime = DateTime.Now;

        #endregion

        #region ���캯��
        
        
        public ReSetPreInfoForm()
        {
            InitializeComponent();
        }

        #endregion

        #region �¼�


        private void ReSetPreInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string fact_qnt = this.txtFact_qnt.Text.Trim();
                if (fact_qnt == "")
                {
                    MessageBox.Show("������ʵ������", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                int factqnt = 0;
                try
                {
                    factqnt = Int32.Parse(fact_qnt);
                }
                catch
                {
                    MessageBox.Show("ʵ������ӦΪ����", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string p_no = this.txtP_no.Text.Trim();
                string p_name = this.txtP_name.Text.Trim();
                int acc_qnt = Int32.Parse(this.txtAcc_qnt.Text.Trim());
                int diffqnt = acc_qnt - factqnt;
                string chckmemo = this.txtChck_memo.Text.Trim();
                if (chckmemo == "")
                {
                    chckmemo = "��";
                }
                CheckTableInfo data = new CheckTableInfo(this.check_no, this.thisTime, p_no, p_name, acc_qnt, factqnt, diffqnt, chckmemo);
                this.checkTableList.Add(data);
                this.dataGridViewCheckTable.DataSource = this.checkTableList;
                dataGridViewCheckTable.CurrentCell = dataGridViewCheckTable.Rows[index].Cells[0];


                //��һ��
                if (this.index < this.preInfoList.Count - 1)
                {
                    this.index = this.index + 1;
                    setTextByIndex();
                    setGroupBoxText();
                }
                else
                {
                    //��ʾ
                    if (MessageBox.Show("��ϲ�������̴�����ɣ�������⣿", "���", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                        == DialogResult.OK)
                    {
                        //����
                        if (saveCheckTable())
                        {
                            MessageBox.Show("�����ѱ���", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("���ݱ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�̴�",ex);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //��ʾ
                if (MessageBox.Show("�����̴�δ��ɣ����ڱ�����⣿", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    //����
                    if (saveCheckTable())
                    {
                        MessageBox.Show("�����ѱ���", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("���ݱ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�̴�", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�����̴�δ��ɣ������˳���", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
               == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dataGridViewCheckTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        private void ReSetPreInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.preInfoList = new BLL.PreInfo().GetPreInfoForCheckTable();
                index = 0;
                setTextByIndex();

                this.check_no = new BLL.CheckTable().GetCheckNo() + 1;

                this.dataGridViewCheckTable.Columns["ColumnP_no"].DisplayIndex = 0;
                this.dataGridViewCheckTable.Columns["ColumnP_name"].DisplayIndex = 1;
                this.dataGridViewCheckTable.Columns["ColumnAcc_qnt"].DisplayIndex = 2;
                this.dataGridViewCheckTable.Columns["ColumnFact_qnt"].DisplayIndex = 3;
                this.dataGridViewCheckTable.AutoGenerateColumns = false;

                setGroupBoxText();
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("�̴�", ex);
            }
        }

        #endregion

        #region ˽�з���

        private void setGroupBoxText()
        {
            this.groupBoxCheckTable.Text = "���ǵ�" + this.check_no + "���̴�  ���̴�" + (index) + "������" + this.preInfoList.Count + "��";
        }
        private void setTextByIndex()
        {
            PreInfoData data = this.preInfoList[index];
            this.txtP_no.Text = data.P_no;
            this.txtP_name.Text = data.P_name;
            this.txtAcc_qnt.Text = data.Acc_qnt.ToString();
        }

        private bool saveCheckTable()
        {
            return new BLL.CheckTable().insertCheckTableInfo(this.checkTableList);
        }

        #endregion




    }
}