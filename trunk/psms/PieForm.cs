using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;


using psms.util;

namespace psms
{
    public partial class PieForm : Form
    {

        IList<IList<string>> list;

        int tuli = 1;

        string st = "";
        string st1 = "时间段：";
        string st2 = "";
        string st3 = "统计的内容：";
        /// <summary>
        /// 饼形图构造函数
        /// </summary>
        /// <param name="labText"></param>
        /// <param name="stat"></param>
        /// <param name="tuli"> 1，输出一列，2，输出两列，用于图例较多的情况</param>
        public PieForm(string st,string st1,string st2,string st3,IList<IList<string>> stat,int tuli)
        {
            InitializeComponent();

            //this.label1.Text = labText;
            this.list = stat;
            this.tuli = tuli;
            this.st1 = this.st1 + st1;
            this.st2 = st2;
            this.st3 = this.st3 + st3;
            this.st = st;

          
        }



        /// <summary>
        /// 饼形图构造函数
        /// </summary>
        /// <param name="labText"></param>
        /// <param name="stat"></param>
        /// <param name="tuli"> 1，输出一列，2，输出两列，用于图例较多的情况</param>
        public PieForm(string st,string st1,string st2,string st3, DataTable dt, int tuli)
        {
            InitializeComponent();

            //this.label1.Text = labText;
            this.list = new List<IList<string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IList<string> data = new List<string>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    data.Add(dt.Rows[i][j].ToString());
                }
                this.list.Add(data);
            }
            this.tuli = tuli;
            this.st1 = this.st1 + st1;
            this.st2 = st2;
            this.st3 = this.st3 + st3;
            this.st = st;
        }


        private void PieForm_Load(object sender, EventArgs e)
        {
            Bitmap bmp = PieChart.GreateImage(st, st1, st2, st3 , list,tuli);
            this.panel1.BackgroundImage = bmp;
            this.panel1.Width = bmp.Width;
            this.panel1.Height = bmp.Height;

            //if (list.Count > 0)
            //{
            //    Random rnd = new Random();

            //    //Graphics g = Graphics.FromImage(image2);
            //    int beginx = 520;
            //    Font fontv = new Font("Arial", 10, FontStyle.Regular | FontStyle.Bold);
            //    float[] flo = new float[list.Count];
            //    int T = 0;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        string pie = (Convert.ToDouble(list[i][1]) / allSum).ToString();
            //        flo[T] = Convert.ToSingle(pie.Length > 6 ? pie.Substring(0, 6) : pie);
            //        Brush Bru = new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            //        string v = (flo[T] * 100) + "%";
            //        string q = list[i][1];
            //        string n = list[i][0];
            //        string p = list[i][2];
            //        g.DrawString(v, fontv, Bru, beginx, 5 + T * 18);

            //        g.DrawString(q, fontv, Bru, beginx + g.MeasureString(v, fontv).Width + psms.util.StrUtil.inStrbyLength(g.MeasureString(v, fontv).Width, 45), 5 + T * 18);

            //        g.DrawString("￥" + p, fontv, Bru, beginx + g.MeasureString(v, fontv).Width + psms.util.StrUtil.inStrbyLength(g.MeasureString(v, fontv).Width, 45) +
            //            psms.util.StrUtil.inStrbyLength(g.MeasureString(q, fontv).Width, 20) 
            //            + g.MeasureString(q, fontv).Width, 5 + T * 18);

            //        g.DrawString(n, fontv, Bru, beginx + g.MeasureString(v, fontv).Width + psms.util.StrUtil.inStrbyLength(g.MeasureString(v, fontv).Width, 45) +
            //            psms.util.StrUtil.inStrbyLength(g.MeasureString(q, fontv).Width, 20) + g.MeasureString(q, fontv).Width +
            //            psms.util.StrUtil.inStrbyLength(g.MeasureString(p, fontv).Width, 80) + g.MeasureString(p, fontv).Width , 5 + T * 18);


            //        //g.DrawString(v + psms.util.StrUtil.inStrbyLength(g.MeasureString(v, fontv).Width, 45)
            //        //            + q + psms.util.StrUtil.inStrbyLength(g.MeasureString(q, fontv).Width, 10)
            //        //            + "￥" + p + psms.util.StrUtil.inStrbyLength(g.MeasureString(p, fontv).Width, 50)
            //        //            + n, fontv, Bru, 7, 5 + T * 18);
            //        showPic(flo[T], Bru);
            //        T++;
            //    }

            //    this.panel1.BackgroundImage = this.image;
            //    //this.panel2.BackgroundImage = this.image2;


            //}
        }




        //private void showPic(float f, Brush B)
        //{
           
        //    //创建Graphics类对象
           
        //    if (TimeNum == 0.0f)
        //    {
        //        g.FillPie(B, 40, 0, 460, 460, 0, f * 360);
        //    }
        //    else
        //    {
        //        g.FillPie(B, 40, 0, 460, 460, TimeNum, f * 360);
        //    }
        //    TimeNum += f * 360;
        //}

        private void PieForm_Paint(object sender, PaintEventArgs e)
        {

            //if (list.Count > 0)
            //{
            //    Random rnd = new Random();

            //    Graphics g = this.panel2.CreateGraphics();

            //    float[] flo = new float[list.Count];
            //    int T = 0;
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        string pie = (Convert.ToDouble(list[i][0]) / allSum).ToString();
            //        flo[T] = Convert.ToSingle(pie.Length > 6 ? pie.Substring(0, 6):pie);
            //        Brush Bru = new SolidBrush(Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            //        string v = (flo[T] * 100) + "%";
            //        string q = list[i][0];
            //        string n = list[i][1];
            //        string p = list[i][2];
            //        g.DrawString(v + psms.util.StrUtil.inStrbyLength(v , 8) 
            //                    + q + psms.util.StrUtil.inStrbyLength(q, 5)
            //                    + "￥"+p + psms.util.StrUtil.inStrbyLength(p, 10)
            //                    + n , new Font("Arial", 8, FontStyle.Regular | FontStyle.Bold), Bru, 7, 5 + T * 18);
            //        showPic(flo[T], Bru);
            //        T++;
            //    }
            //}

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintPage();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("Arial", 12, FontStyle.Regular | FontStyle.Bold);
            //e.Graphics.DrawString(this.label1.Text,f,new SolidBrush(Color.Black),20,10);
            e.Graphics.DrawImage(this.panel1.BackgroundImage, 0, 0 );
            //DoPrint(e);
        }

        protected Bitmap memoryImage;
        protected void DoPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //float leftMargin = this.panel3.Left;//e.MarginBounds.Left;
            //float topMargin = this.panel3.Top;// e.MarginBounds.Top;
            //e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, e.MarginBounds.Width, e.MarginBounds.Height);
            //e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, this.axLgxChar1.Width, this.axLgxChar1.Height);
        }

        //private void CaptureScreen(Control ctrl)
        //{
        //    Size s = ctrl.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height);
        //    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
        //    {
        //        Rectangle rectClient = new Rectangle(ctrl.Left, ctrl.Top, s.Width, s.Height);
        //        Rectangle rectScreen = this.RectangleToScreen(rectClient);
        //        memoryGraphics.CopyFromScreen(rectScreen.Left, rectScreen.Top, 0, 0, s);
        //    }
        //}

        public void PrintControl(Control ctrl)
        {
            //CaptureScreen(ctrl);
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.Print();
        }

        public void PrintPage()
        {
            PrintControl(this.panel1);
        }        











    }
}