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

        #region 字段

        //要盘存的宣传品信息
        private IList<PreInfoData> preInfoList;
        //盘存后的记录
        private BindingList<CheckTableInfo> checkTableList = new BindingList<CheckTableInfo>();
        //导航
        private int index = 0;
        //第几次盘存
        private int check_no = 0;
        //本次盘存时间
        private DateTime thisTime = DateTime.Now;

        #endregion

        #region 构造函数
        
        
        public ReSetPreInfoForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件


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
                    MessageBox.Show("请输入实存数量", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                int factqnt = 0;
                try
                {
                    factqnt = Int32.Parse(fact_qnt);
                }
                catch
                {
                    MessageBox.Show("实存数量应为整数", "注意", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string p_no = this.txtP_no.Text.Trim();
                string p_name = this.txtP_name.Text.Trim();
                int acc_qnt = Int32.Parse(this.txtAcc_qnt.Text.Trim());
                int diffqnt = acc_qnt - factqnt;
                string chckmemo = this.txtChck_memo.Text.Trim();
                if (chckmemo == "")
                {
                    chckmemo = "无";
                }
                CheckTableInfo data = new CheckTableInfo(this.check_no, this.thisTime, p_no, p_name, acc_qnt, factqnt, diffqnt, chckmemo);
                this.checkTableList.Add(data);
                this.dataGridViewCheckTable.DataSource = this.checkTableList;
                dataGridViewCheckTable.CurrentCell = dataGridViewCheckTable.Rows[index].Cells[0];


                //下一条
                if (this.index < this.preInfoList.Count - 1)
                {
                    this.index = this.index + 1;
                    setTextByIndex();
                    setGroupBoxText();
                }
                else
                {
                    //提示
                    if (MessageBox.Show("恭喜！本次盘存已完成，保存入库？", "完成", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                        == DialogResult.OK)
                    {
                        //保存
                        if (saveCheckTable())
                        {
                            MessageBox.Show("数据已保存", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("数据保存出错", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("盘存",ex);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //提示
                if (MessageBox.Show("本次盘存未完成，现在保存入库？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    == DialogResult.OK)
                {
                    //保存
                    if (saveCheckTable())
                    {
                        MessageBox.Show("数据已保存", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("数据保存出错", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowErrorMessageBox("盘存", ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("本次盘存未完成，现在退出？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
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
                MyMessageBox.ShowErrorMessageBox("盘存", ex);
            }
        }

        #endregion

        #region 私有方法

        private void setGroupBoxText()
        {
            this.groupBoxCheckTable.Text = "这是第" + this.check_no + "次盘存  已盘存" + (index) + "条，共" + this.preInfoList.Count + "条";
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