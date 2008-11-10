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
    public partial class BarForm : Form
    {
        IList<IList<string>> list;
        string title;
        //string subTitle;
        string st1 = "时间段：";
        string st2 = "";
        string st3 = "统计的内容：";

        public BarForm(string title,string st1,string st2,string st3,IList<IList<string>> dt)
        {
            InitializeComponent();
            this.title = title;
            
            this.list = dt;

            this.st1 = this.st1 + st1;
            this.st2 = st2;
            this.st3 = this.st3 + st3;
        }

        public BarForm(string title, string st1, string st2, string st3, DataTable dt)
        {
            InitializeComponent();
            this.title = title;
            //this.subTitle = subTitle;
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
            this.st1 = this.st1 + st1;
            this.st2 = st2;
            this.st3 = this.st3 + st3;
        }

        private void BarForm_Load(object sender, EventArgs e)
        {
            Bitmap bmp = BarChart.GreateImage(title, st1,st2,st3, list);
            this.panel1.Width = bmp.Width;
            this.panel1.Height = bmp.Height;
            this.panel1.BackgroundImage = bmp;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintPage();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(this.panel1.BackgroundImage, 0, 0);
            //DoPrint(e);
        }

        //protected Bitmap memoryImage;
        //protected void DoPrint(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    //float leftMargin = this.panel1.Left;//e.MarginBounds.Left;
        //    //float topMargin = this.panel1.Top;// e.MarginBounds.Top;
        //    //e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, e.MarginBounds.Width, e.MarginBounds.Height);
        //    //e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, this.axLgxChar1.Width, this.axLgxChar1.Height);
        //}

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