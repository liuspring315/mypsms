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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryData();
        }


        private void queryData()
        {
            StringBuilder sql = new StringBuilder("select a.in_out,a.scrp_no,a.p_no,b.p_name,a.qnt,a.cost,a.s_qnt,a.s_cost,a.adddate from preacc a,preinfo b where a.p_no = b.p_no and adddate >= '");
            sql.Append(this.dateTimePicker1.Value.ToShortDateString() + " 00:00:00' and adddate <= '");
            sql.Append(this.dateTimePicker2.Value.ToShortDateString() + " 23:59:59' order by adddate");
            this.dataGridView1.DataSource = new BLL.PreInfo().GetDataTableBySql(sql.ToString());
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            queryData();
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount > 0)
            {
                DataGridViewPrinter dgp = new DataGridViewPrinter(this.dataGridView1, "操作历史日志", "", "",
                            "", "", "",
                            "", this.dateTimePicker1.Value.ToShortDateString() + "--" + this.dateTimePicker2.Value.ToShortDateString(), "",
                            true);
                dgp.Print();
            }
        }






    }
}