using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using psms.util;

namespace psms
{
    public partial class InOutPieForm : Form
    {
        string condition = "1=1";
        string startTime;
        string endTime;
        string conMess;
        public InOutPieForm(string condition,string conMess,string s,string e)
        {
            InitializeComponent();
            this.condition = condition;
            this.startTime = s;
            this.endTime = e;
            this.conMess = conMess;
        }

        private void InOutPieForm_Load(object sender, EventArgs e)
        {
            //IList<util.ValueObject> valueList = new List<util.ValueObject>();
            //valueList.Add(new util.ValueObject("c.pretype", "������Ʒϵ��ͳ��"));
            //valueList.Add(new util.ValueObject("o.p_no", "������Ʒ���ͳ��"));
            //this.comboBoxPreTypePno.DataSource = valueList;
            //comboBoxPreTypePno.DisplayMember = "text";
            //comboBoxPreTypePno.ValueMember = "value";

            IList<util.ValueObject> valueList2 = new List<util.ValueObject>();
            valueList2.Add(new util.ValueObject("outscrp", "��������"));
            valueList2.Add(new util.ValueObject("inscrp", "�������"));
            this.comboBoxInOut.DataSource = valueList2;
            comboBoxInOut.DisplayMember = "text";
            comboBoxInOut.ValueMember = "value";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPieShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new BLL.PreInfo().GetDataTableBySql(getSql());
            int all = 0;
            decimal allPrice = 0M;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                all = all + int.Parse(dt.Rows[i][1].ToString());
                allPrice = allPrice + decimal.Parse(dt.Rows[i][2].ToString());
            }
            if (all > 0)
            {
                string st = "�ܹ�˾ҵ������Ʒ������ͳ��ͼ";
                string st2_1 = "�����������";
                string st2_2 = "������";
                string inorout = ((util.ValueObject)this.comboBoxInOut.SelectedItem).Value;
                if (inorout == "outscrp")
                {
                    st = "�ܹ�˾ҵ������Ʒ�������ͳ��ͼ";
                    st2_1 = "�ܳ���������";
                    st2_2 = "�ܳ����";
                }
                string st1 = startTime + "��" + endTime;
                string st2 = st2_1 + all + "         " + st2_2 + allPrice;
                string st3 = "����Ʒϵ��";
                PieForm pie = new PieForm(st,st1,st2,st3, dt, 1);
                pie.Show();
                this.Close();
            }
            else
            {
                MyMessageBox.ShowInfoMessageBox("ָ���Ĳ�ѯ������ѯ�޼�¼��������ָ����ѯ����");
            }

        }

        private void btnBarShow_Click(object sender, EventArgs e)
        {
            DataTable dt = new BLL.PreInfo().GetDataTableBySql(getSql());
            int all = 0;
            decimal allPrice = 0M;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                all = all + int.Parse(dt.Rows[i][1].ToString());
                allPrice = allPrice + decimal.Parse(dt.Rows[i][2].ToString());
            }
            if (all > 0)
            {
                string st = "�ܹ�˾ҵ������Ʒ������ͳ��ͼ";
                string st2_1 = "�����������";
                string st2_2 = "������";
                string inorout = ((util.ValueObject)this.comboBoxInOut.SelectedItem).Value;
                if (inorout == "outscrp")
                {
                    st = "�ܹ�˾ҵ������Ʒ�������ͳ��ͼ";
                    st2_1 = "�ܳ���������";
                    st2_2 = "�ܳ����";
                }
                string st1 = startTime + "��" + endTime;
                string st2 = st2_1 + all + "         " + st2_2 + allPrice;
                string st3 = conMess;
                BarForm bar = new BarForm(st, st1,st2,st3, dt);
                bar.Show();
                this.Close();
            }
            else
            {
                MyMessageBox.ShowInfoMessageBox("ָ���Ĳ�ѯ������ѯ�޼�¼��������ָ����ѯ����");
            }
        }

        private string getSql()
        {
            //select p_no,sum(qnt),sum(out_price) from outscrp group by p_no

            //select pretype,sum(qnt),sum(out_price) from outscrp o,preinfo p
            //where o.p_no = p.p_no group by p.pretype

            //select p_no,sum(qnt),sum(in_price) from inscrp group by p_no

            //select pretype,sum(qnt),sum(in_price) from inscrp o,preinfo p
            //where o.p_no = p.p_no group by p.pretype
            StringBuilder sql = new StringBuilder("select ");

            string pretypeorpno = "c.pretype";//((util.ValueObject)this.comboBoxPreTypePno.SelectedItem).Value;
            //if (pretypeorpno == "c.pretype")
            //{
                sql.Append(pretypeorpno).Append(",");
            //}
            //else
            //{
            //    sql.Append(" (select p_name from preinfo where p_no = o.p_no) as pname").Append(",");
            //}
            
            sql.Append("sum(qnt),sum(");
            string inorout = ((util.ValueObject)this.comboBoxInOut.SelectedItem).Value;
            if (inorout == "outscrp")
            {
                sql.Append("out_price) as allprice from outscrp o,outtable t ");
            }
            else
            {
                sql.Append("in_price) as allprice from inscrp o,intable t ");
            }

            if (pretypeorpno == "c.pretype")
            {
                sql.Append(",preinfo c where o.p_no = c.p_no ");
            }
            else
            {
                sql.Append(" where 1=1 ");
            }
            if (inorout == "outscrp")
            {
                sql.Append(" and t.out_scrpno = o.out_scrpno and out_date >= '").Append(startTime).Append("' and out_date <= '").Append(endTime).Append("'");
            }
            else
            {
                sql.Append(" and t.in_scrpno = o.in_scrpno and in_date >= '").Append(startTime).Append("' and in_date <= '").Append(endTime).Append("'");
            }

            sql.Append(condition);

            if (pretypeorpno == "c.pretype")
            {
                sql.Append(" group by c.pretype order by allprice desc");
            }
            else
            {
                sql.Append(" group by o.p_no order by allprice desc");
            }
            return sql.ToString();

            
        }


    }
}