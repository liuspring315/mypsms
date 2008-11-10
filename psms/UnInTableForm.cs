using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using psms.Model;

namespace psms
{
    public partial class UnInTableForm : Form
    {
        private string p_no;
        private string in_scrpno;

        public UnInTableForm(string pno,string pname,string inscrpno,string incost1,string incost2,string qnt1,string qnt2)
        {
            InitializeComponent();
            this.p_no = pno;
            this.in_scrpno = inscrpno;

            this.labP_name.Text = pname;
            this.labIn_scrpno.Text = inscrpno;
            this.labIn_cost1.Text = incost1;
            this.labIn_Cost2.Text = incost2;
            this.labQnt1.Text = qnt1;
            this.labQnt2.Text = qnt2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PreInfoData preInfoData = new BLL.PreInfo().GetPreInfoByNo(this.p_no);
            decimal in_cost = decimal.Parse(this.labIn_Cost2.Text.Trim());
            int qnt = Int32.Parse(this.labQnt2.Text.Trim());
            decimal in_price = qnt * preInfoData.Unit_price;
            
            int uninnum = Int32.Parse(this.labQnt1.Text.Trim()) - Int32.Parse(this.labQnt2.Text.Trim());
            int acc_qnt = preInfoData.Acc_qnt - uninnum;
            decimal s_cost = acc_qnt * preInfoData.Unit_price;
            string remark = this.txtRemark.Text;

            //if (new BLL.InTable().UnInTable(in_cost, this.in_scrpno, qnt, in_price, this.p_no, acc_qnt, s_cost, uninnum, remark))
            //{
            //    MessageBox.Show("退库成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("退库出错", "出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }
}