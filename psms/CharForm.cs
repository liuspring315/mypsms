using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace psms
{
    public partial class CharForm : Form
    {
        double[] D1;
        string[] D2;

        public CharForm(double[] d1, string[] d2)
        {
            InitializeComponent();
            this.D1 = d1;
            this.D2 = d2;
        }

        private void CharForm_Load(object sender, EventArgs e)
        {
            this.comboBoxChar.SelectedItem = this.comboBoxChar.Items[this.comboBoxChar.FindString("Ô²±ýÍ¼")];
            CharShow();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            CharShow();
        }


        private void CharShow()
        {

            //short Mode = 1;
            //switch (comboBoxChar.SelectedItem.ToString())
            //{
            //    case "ÕÛÏßÍ¼":
            //        Mode = 1;
            //        break;
            //    case "Ö±·½Í¼":
            //        Mode = 2;
            //        break;
            //    case "Ô²±ýÍ¼":
            //        Mode = 3;
            //        break;
            //}
            //axLgxChar1.ShowChar(D1, D2, this.textBoxUnit.Text.Trim(), Mode);
            //axLgxChar1.Visible = true;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //PrintPage();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //DoPrint(e); 
        }

        //protected Bitmap memoryImage;
        //protected void DoPrint(System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    float leftMargin = this.axLgxChar1.Left;//e.MarginBounds.Left;
        //    float topMargin = this.axLgxChar1.Top;// e.MarginBounds.Top;
        //    e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, e.MarginBounds.Width, e.MarginBounds.Height);
        //    //e.Graphics.DrawImage(memoryImage, leftMargin, topMargin, this.axLgxChar1.Width, this.axLgxChar1.Height);
        //}

        //private void CaptureScreen(Control ctrl)
        //{
        //    Size s = ctrl.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height);
        //    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
        //    {
        //        Rectangle rectClient = new Rectangle(this.axLgxChar1.Left, this.axLgxChar1.Top, s.Width, s.Height);
        //        Rectangle rectScreen = this.RectangleToScreen(rectClient);
        //        memoryGraphics.CopyFromScreen(rectScreen.Left, rectScreen.Top, 0, 0, s);
        //    }
        //}

        //public void PrintControl(Control ctrl)
        //{
        //    CaptureScreen(ctrl);
        //    printDocument1.DefaultPageSettings.Landscape = true;
        //    printDocument1.Print();
        //}

        //public void PrintPage()
        //{
        //    PrintControl(this.axLgxChar1);
        //}        


    }
}