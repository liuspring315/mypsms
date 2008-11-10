/*�Զ����࣬ͨ�����벻ͬ�Ĳ�������Щ����Ի���ͬ��ͼ��   */

using System;
using System.IO;//�����ļ���ȡ    
using System.Data;//�������ݷ���    
using System.Drawing;//�ṩ��GDI+ͼ�εĻ�������    
using System.Drawing.Text;//�ṩ��GDI+ͼ�εĸ߼�����    
using System.Drawing.Drawing2D;//�ṩ���߼���ά��ʸ��ͼ�ι���    
using System.Drawing.Imaging;//�ṩ��GDI+ͼ�εĸ߼�����    
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace psms.util
{
    public class PieChart
    {

        #region ��ʽ����
		 
        
        /// <summary>
        /// //�������� -->
        /// </summary>
        static Font titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
                     float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
                     ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="����"/>


        /// <summary>
        /// //���������� -->
        /// </summary>
        static Font dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                    float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                    ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


        /// <summary>
        /// // ��������-->
        /// </summary>
        static Font font = new Font(ConfigurationManager.AppSettings["font"],
                    float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                    ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

        /// <summary>
        /// //���߾� -->
        /// </summary>
        static int topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

        /// <summary>
        /// // ҳ����߾�-->
        /// </summary>
        static int leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>

        private static void setConfig()
        {
             titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
            float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
            ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="����"/>


            /// <summary>
            /// //���������� -->
            /// </summary>
             dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                       float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                       ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


            /// <summary>
            /// // ��������-->
            /// </summary>
             font = new Font(ConfigurationManager.AppSettings["font"],
                       float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                       ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

            /// <summary>
            /// //���߾� -->
            /// </summary>
             topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

            /// <summary>
            /// // ҳ����߾�-->
            /// </summary>
             leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>
        }
        #endregion


        /// <summary>
        /// ������ͼ
        /// </summary>
        /// <param name="title"></param>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <param name="st3"></param>
        /// <param name="dt"></param>
        /// <param name="tuli"></param>
        /// <returns></returns>
        public static Bitmap GreateImage(string title, string st1, string st2, string st3, IList<IList<string>> dt, int tuli)
        {
            setConfig();
        
            //const int SIDE_LENGTH = 400;
            const int PIE_DIAMETER = 380;

            int width = 842;
            int height = 595;

            //ͨ�����������ȡ�ñ�ͼ�е��ܻ���    
            float sumData = 0;
            for (int i = 0; i < dt.Count; i++)
            {
                sumData += Convert.ToSingle(dt[i][2]);
            }
            //����һ��image���󣬲��ɴ˲���һ��Graphics����    
            Bitmap bm = new Bitmap(width, height);
            bm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(bm);
            //���ö���g������    
            //g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH, (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //�����ͱߵ��趨    
            g.Clear(Color.White);
            //g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //����ͼ����
      
            g.DrawString(title, titleFont, Brushes.Black, new PointF(leftMargin + 200, topMargin));
            topMargin = topMargin + (int)g.MeasureString(title,titleFont).Height + 20;
            //����ͼ�ĸ�����   
            g.DrawString(st1, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st1, dateFont).Height + 10;
            g.DrawString(st2, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st2, dateFont).Height + 10;
            g.DrawString(st3, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st3, dateFont).Height + 10;

            //����ͼ    
            float curAngle = 0;
            float totalAngle = 0;
            Hashtable tmp = new Hashtable();
            Random rnd = new Random();
            for (int i = 0; i < dt.Count; i++)
            {
                string pie = (Convert.ToDouble(dt[i][2]) / sumData).ToString();
                curAngle = Convert.ToSingle(pie) * 360;

                int a = rnd.Next(255);
                int b = rnd.Next(255);
                int c = rnd.Next(255);
    
                g.FillPie(new SolidBrush(Color.FromArgb(a, b, c)), leftMargin, topMargin, PIE_DIAMETER, PIE_DIAMETER, totalAngle, curAngle);

                tmp.Add(dt[i][0].ToString(), Color.FromArgb(a, b, c));

                totalAngle += curAngle;
            }

            

            //topMargin = topMargin + PIE_DIAMETER;
            //��ͼ����������    
            //g.DrawRectangle(Pens.Black, 200, 300, 199, 99);
            //g.DrawString("Legend", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new PointF(200, 300));

            //��ͼ������    
            //PointF boxOrigin = new PointF(210, 330);
            //PointF textOrigin = new PointF(235, 326);
            float percent = 0;
            if (tuli == 1)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    string keyname1 = dt[i][0].ToString();
                    g.FillRectangle(new SolidBrush((Color)tmp[keyname1]), leftMargin + PIE_DIAMETER + 60, topMargin, 20, 10);
                    //g.DrawRectangle(Pens.Black, topMargin, leftMargin, 20, 10);
                    string pie = (Convert.ToDouble(dt[i][2]) / sumData).ToString();
                    percent = Convert.ToSingle((Convert.ToDouble(dt[i][2]) / sumData * 100).ToString());

                    g.DrawString(dt[i][0].ToString() + " - " + dt[i][2].ToString() + " (" + percent.ToString("0.00") + "%)", dateFont, Brushes.Black, leftMargin + PIE_DIAMETER + 80, topMargin);
                    topMargin = topMargin + 15;
                }
            }
            else
            {
                for (int i = 0; i < dt.Count; i = i + 2)
                {
                    string keyname1 = dt[i][0].ToString();
                    g.FillRectangle(new SolidBrush((Color)tmp[keyname1]), leftMargin + PIE_DIAMETER + 20, topMargin, 20, 10);
                    //g.DrawRectangle(Pens.Black, topMargin, leftMargin, 20, 10);
                    percent = Convert.ToSingle(dt[i][2]) / sumData * 100;

                    g.DrawString(dt[i][0].ToString() + " - " + dt[i][2].ToString() + " (" + percent.ToString("0") + "%)", dateFont, Brushes.Black, leftMargin + PIE_DIAMETER + 40, topMargin);
                    if (i + 1 < dt.Count)
                    {
                        keyname1 = dt[i + 1][0].ToString();
                        g.FillRectangle(new SolidBrush((Color)tmp[keyname1]), leftMargin + PIE_DIAMETER + 250, topMargin, 20, 10);
                        //g.DrawRectangle(Pens.Black, topMargin, leftMargin, 20, 10);
                        percent = Convert.ToSingle(dt[i + 1][2]) / sumData * 100;

                        g.DrawString(dt[i + 1][0].ToString() + " - " + dt[i + 1][2].ToString() + " (" + percent.ToString("0") + "%)", dateFont, Brushes.Black, leftMargin + PIE_DIAMETER + 270, topMargin);
                    }
                    topMargin = topMargin + 15;
                }
            }
            //ͨ��Response.OutputStream����ͼ�ε����ݷ��͵������    
            //bm.Save(target, ImageFormat.Gif);
            //������Դ    
            //bm.Dispose();
            g.Dispose();

            return bm;
        }


        


    }

    //������ͼ    
    public class BarChart
    {

        #region ��ʽ����
        
        

        /// <summary>
        /// //�������� -->
        /// </summary>
        static Font titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
                     float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
                     ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="����"/>


        /// <summary>
        /// //���������� -->
        /// </summary>
        static Font dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                    float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                    ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


        /// <summary>
        /// // ��������-->
        /// </summary>
        static Font font = new Font(ConfigurationManager.AppSettings["font"],
                    float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                    ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

        /// <summary>
        /// //���߾� -->
        /// </summary>
        static int topMargin = 15;//int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

        /// <summary>
        /// // ҳ����߾�-->
        /// </summary>
        static int leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>


        private static void setConfig()
        {
            titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
           float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
           ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="����"/>


            /// <summary>
            /// //���������� -->
            /// </summary>
            dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                      float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                      ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


            /// <summary>
            /// // ��������-->
            /// </summary>
            font = new Font(ConfigurationManager.AppSettings["font"],
                      float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                      ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

            /// <summary>
            /// //���߾� -->
            /// </summary>
            topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

            /// <summary>
            /// // ҳ����߾�-->
            /// </summary>
            leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>
        }

        #endregion

        /// <summary>
        /// �õ�����ͼ��ͼƬ
        /// </summary>
        /// <param name="title"></param>
        /// <param name="subTitle"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Bitmap GreateImage(string title, string st1,string st2,string st3, IList<IList<string>> dt)
        {
            setConfig();

            //����߶�
            int titleSize = 200;
            //����x����
            //int titleX = 180;


           

            //y��
            String[] m = {" 0%"," 10%"," 20%"," 30%"," 40%", " 50%", " 60%", " 70%"," 80%"," 90%", "100%" };


            int barWidth = 30;

            //ԭ�� 0 0
            int x = leftMargin * 2;
            int y = titleSize + 10 + barWidth * m.Length;


            //int height = y +dt.Count * 12, width = 200 + dt.Count * 40;
            

            //System.Drawing.Bitmap image = new System.Drawing.Bitmap(dt.Count < 10 ? 820 : width + 100, dt.Count < 10 ? 660 : height + 100);
            int width = 842;
            int height = 595;
            //����һ��image���󣬲��ɴ˲���һ��Graphics����    
            Bitmap image = new Bitmap(width, height);
            image.SetResolution(72, 72);
            //����Graphics�����
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            try
            {
                //���ͼƬ����ɫ
                g.Clear(Color.White);

                //Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
                //Font font1 = new System.Drawing.Font("����", 20, FontStyle.Regular);
                //Font fontTitle = new System.Drawing.Font("����", 20, FontStyle.Regular);

                //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                //g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);

                Brush brush1 = new SolidBrush(Color.Blue);
                //�������ˢ��
                Brush brushTitle = new SolidBrush(Color.Black);

                g.DrawString(title, titleFont, Brushes.Black, new PointF(leftMargin + 200, topMargin));
                topMargin = topMargin + 30;
                //��������   
                g.DrawString(st1, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                topMargin = topMargin + 15;
                g.DrawString(st2, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                topMargin = topMargin + 15;
                g.DrawString(st3, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                //topMargin = topMargin + 10;
                //��ͼƬ�ı߿���
                //g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 4, image.Height - 4);

                //������ϵ�ı�
                Pen mypen = new Pen(Brushes.Black, 1);
                //��������
                //���������� �ٷֱ�����
                y = topMargin + barWidth * m.Length;
                int beginx = x;
                for (int i = 0; i < dt.Count; i++)
                {
                    g.DrawLine(mypen, beginx, topMargin + 20, beginx, y);
                    beginx = beginx + barWidth;
                }
                //Pen mypen1 = new Pen(Color.Blue, 2);
                //g.DrawLine(mypen1, x - 480, 80, x - 480, 340);

                //���ƺ�������
                int beginy = y;
                for (int i = 0; i < m.Length; i++)
                {
                    g.DrawLine(mypen, x, beginy, x + dt.Count * barWidth, beginy);
                    g.DrawString(m[i].ToString(), font, Brushes.Red, x - g.MeasureString(m[i].ToString(),font).Width, beginy - g.MeasureString(m[i].ToString(),font).Height); //�����������ݼ����λ��
                    beginy = beginy - barWidth;
                }
                //g.DrawLine(mypen1, 60, y, 540, y);

       

                //����
                String[] n = new String[dt.Count];
                //�ܺ�
                float number = 0;
                //�ٷֱ�
                float[] Count = new float[dt.Count];
                for (int i = 0; i < dt.Count; i++)
                {
                    n[i] = dt[i][0];
                    number = number + float.Parse(dt[i][2].ToString());
                }

                for (int i = 0; i < dt.Count; i++)
                {
                    //string value = (Convert.ToDecimal(dt[i][2].ToString()) * 100 / number).ToString();
                    Count[i] = Convert.ToSingle(dt[i][2].ToString()) * 100 / number;
                }
                
                ////��ʾ��״Ч��

                Hashtable tmp = new Hashtable();
                Random rnd = new Random();
                int beginn = x;
                for (int i = 0; i < dt.Count; i++)
                {
                    int a = rnd.Next(255);
                    int b = rnd.Next(255);
                    int c = rnd.Next(255);
                    SolidBrush mybrush = new SolidBrush(Color.FromArgb(a, b, c));
                    g.FillRectangle(mybrush, beginn, y - Count[i] * barWidth / 10, 25, Count[i] * barWidth / 10);
                    string strPrice = dt[i][2].ToString();
                    Font priceFont = new Font("Tahoma", 8);
                    //g.DrawString(strPrice, priceFont, mybrush, beginn, y - Count[i] * barWidth / 10 - g.MeasureString(strPrice, priceFont).Height);
                    beginn = beginn + barWidth;

                    tmp.Add(dt[i][0].ToString(), Color.FromArgb(a, b, c));
                }
                y = y + 10;
                for (int i = 0; i < dt.Count; i = i + 4)
                {
                    Font keyFont = new Font("Tahoma", 8);
                    string lin = " - ";

                    string keyname1 = dt[i][0].ToString();

                    int xSize = 210;
                    int xSize2 = 20;

                    int yy = y + 0 + i * 3;///(int)g.MeasureString(keyname1, keyFont).Height;
                    g.FillRectangle(new SolidBrush((Color)tmp[keyname1]), x, yy, 20, 10);    //e.Graphics.MeasureString(sTongJi01, dateFont).Width
                    keyname1 = keyname1 + lin + dt[i][2].ToString() + lin + Count[i].ToString("0.00") + "%";
                    g.DrawString(keyname1, keyFont, Brushes.Black, x + xSize2, yy);
                    if (i + 1 < dt.Count)
                    {
                        string keyname2 = dt[i + 1][0].ToString();
                        g.FillRectangle(new SolidBrush((Color)tmp[keyname2]), x + xSize, yy, 20, 10);
                        keyname2 = keyname2 + lin + dt[i + 1][2].ToString() + lin + Count[i + 1].ToString("0.00") + "%";
                        g.DrawString(keyname2, keyFont, Brushes.Black, x + xSize + xSize2, yy);
                    }
                    if (i + 2 < dt.Count)
                    {
                        string keyname3 = dt[i + 2][0].ToString();
                        g.FillRectangle(new SolidBrush((Color)tmp[keyname3]), x + xSize * 2, yy, 20, 10);
                        keyname3 = keyname3 + lin + dt[i + 2][2].ToString() + lin + Count[i + 1].ToString("0.00") + "%";
                        g.DrawString(keyname3, keyFont, Brushes.Black, x + xSize * 2 + xSize2, yy);
                    }
                    if (i + 3 < dt.Count)
                    {
                        string keyname4 = dt[i + 3][0].ToString();
                        g.FillRectangle(new SolidBrush((Color)tmp[keyname4]), x + xSize * 3, yy, 20, 10);
                        keyname4 = keyname4 + lin + dt[i + 2][2].ToString() + lin + Count[i + 1].ToString("0.00") + "%";
                        g.DrawString(keyname4, keyFont, Brushes.Black, x + xSize * 3 + xSize2, yy);
                    }
                    //if (i + 4 < dt.Count)
                    //{
                    //    string keyname5 = dt[i + 4][0].ToString();
                    //    g.FillRectangle(new SolidBrush((Color)tmp[keyname5]), x + 680, yy, 20, 10);
                    //    keyname5 = keyname5 + lin + dt[i + 2][2].ToString() + lin + Count[i + 1].ToString("0.00") + "%";
                    //    g.DrawString(keyname5, keyFont, Brushes.Black, x + 680 + 30, yy);
                    //}
                }
                
            }
            catch 
            {
                
            }

            return image;
        }




    }
    
















}



/////////==============================================================================================

//���������

//1.����һЩnamespace
//using System;
//using System.IO;//�����ļ���ȡ
//using System.Data;//�������ݷ���
//using System.Drawing;//�ṩ��GDI+ͼ�εĻ�������
//using System.Drawing.Text;//�ṩ��GDI+ͼ�εĸ߼�����
//using System.Drawing.Drawing2D;//�ṩ���߼���ά��ʸ��ͼ�ι���
//using System.Drawing.Imaging;//�ṩ��GDI+ͼ�εĸ߼�����
//��Щnamespace���ں��汻Ӧ�á�

//2.�Զ���һ��namespaceΪInsight_cs.WebCharts�����а�����������PieChart��BarChart��������� class PieChart��Ϊ����ͼ������class BarChart��Ϊ������ͼ����������class PieChart��class BarChar��࣬�������������Ա�ͼΪ�������д��������

//3.��PieChart����һ������Render���˷������Ժ�һЩ��������˵�����£�
//����title����ʾ��ͼ�Ϸ��Ĵ�������֡�
//����subtitle����ʾ��ͼ�Ϸ���С�������֡�
//����width��height����ʾ������ͼ�εĴ�С��
//����charData��һ��DataSet����ʵ�������ڻ�ͼʹ�á�
//����target��Stream�����ʵ��������ͼ�����ʱʹ�á�

//4.Ϊ�����ӿɶ��ԣ�����һЩ������
//const int SIDE_LENGTH = 400;//�����߳�
//const int PIE_DIAMETER = 200;//��ͼֱ��

//5.����һ��DataTable������DataSet�е�һ�����ݱ����д���˱�ͼ�ĸ������ݡ�

//6.ͨ�����㣬�ó���ͼ�е��ܻ���sumData��

//7.������һ��BitMap������ΪҪ������ͼ���ṩ���ڴ�ռ䡣���ɴ˲���һ��Graphics��������װ��GDI+��ͼ�ӿڡ�

//8.����Graphics����ķ���ScaleTransform()�����������趨ͼ�α����ġ�

//9.���÷���SmoothingMode()��TextRenderingHint()�����������ֺ�ͼ�ε�������ԡ�

//10.���û����ͱߡ�

//11.�������ֱ��⣬ͼ��������ͼ���� 

//12.ͨ��Stream����ͼ�ε����ݷ��͵�������� 
//13.��������Դ�� 

//���˻���ͼ���������ˡ�������ͼ�ķ����ͻ���ͼ�ķ�����ͬС�죬����Ͳ�չ�����ˡ����忴����������ͼ����û����������������ѣ���û�ж�ô������㷨����ʵ����˼·���ͺ��������ñ���ֽ�ϻ�ͼ��һ��һ���ġ��ؼ��Ǹ���������ʹ�úͲ������á�

//������ǰ���Ѿ�����˱�ͼ������ͼ���Զ����࣬�������ǽ�ҪӦ����Щ���ˡ�    
//      ʹ��vs.net�½�һ����ΪInsight_cs��WebӦ�ó��򣬲�����ӵ��ղŵ�Insight�����С�ɾ��Ĭ�ϵ�webform1.aspx�ļ����½�һ����ΪSalesChart.aspx�ļ����򿪴��ļ����ڴ���ģʽ�£�����һ���滻Ϊ��    
//      <%@   Page   ContentType="image/gif"   Language="c#"   AutoEventWireup="false"   Codebehind="SalesChart.aspx.cs"   Inherits="Insight_cs.SalesChart"   %>    
//      ���ļ�SalesChart.aspx.cs�����д���������ʾ��    
//      using   System;    
//      using   System.Data;    
//      using   System.Web;    
//      using   System.IO;    
//      using   System.Data.SqlClient;    
//      using   Insight_cs.WebCharts;//�����Զ�������ֿռ�    
//      namespace   Insight_cs    
//      {    
//        public   class   SalesChart   :   System.Web.UI.Page    
//        {    
//        public   SalesChart()    
//        {    
//        Page.Init   +=   new   System.EventHandler(Page_Init);    
//        }    
//        private   void   Page_Load(object   sender,   System.EventArgs   e)    
//        {    
//        //�����ݿ���ȡ�����ݣ����ڻ�ͼ    
//        string   sql   =   "SELECT   "   +"Year(sa.ord_date)   As   [Year],   "   +"SUM(sa.qty)   As   [Qty]   "   +"FROM   "   +"sales   sa   "   +"inner   join   stores   st   on(sa.stor_id   =   st.stor_id)   "   +"GROUP   BY   "   +"Year(sa.ord_date)   "   +   "ORDER   BY   "   +   "[Year]";    
//        string   connectString   =   "Password=ben;   User   ID=sa;   DataBase=pubs;Data   Source=localhost";    
//        SqlDataAdapter   da   =   new   SqlDataAdapter(sql,connectString);    
//        DataSet   ds   =   new   DataSet();    
//        int   rows   =   da.Fill(ds,"chartData");    
//        //�趨����ͼ�����ͣ�pie   or   bar��    
//        string   type   =   "";    
//        if(null==Request["type"])    
//        {    
//        type   =   "PIE";    
//        }    
//        else    
//        {    
//        type   =   Request["type"].ToString().ToUpper();    
//        }    
//        //����ͼ��С    
//        int   width   =   0;    
//        if(null==Request["width"])    
//        {    
//        width   =   400;    
//        }    
//        else    
//        {    
//        width   =   Convert.ToInt32(Request["width"]);    
//        }    
//        int   height   =   0;    
//        if(null==Request["height"])    
//        {    
//        height   =   400;    
//        }    
//        else    
//        {    
//        height   =   Convert.ToInt32(Request["height"]);    
//        }    
//        //����ͼ�����    
//        string   title   =   "";    
//        if(null!=Request["title"])    
//        {    
//        title   =   Request["title"].ToString();    
//        }    
//        string   subTitle   =   "";    
//        if(null!=Request["subtitle"])    
//        {    
//        subTitle   =   Request["subtitle"].ToString();    
//        }    
//        if(0<rows)    
//        {    
//        switch(type)    
//        {    
//        case   "PIE":    
//        PieChart   pc   =   new   PieChart();    
//        pc.Render(title,subTitle,width,height,ds,Response.OutputStream);    
//        break;    
//        case   "BAR":    
//        BarChart   bc   =   new   BarChart();    
//        bc.Render(title,subTitle,width,height,ds,Response.OutputStream);    
//        break;    
//        default:    
         
//        break;    
//        }    
//        }    
//        }    
//        private   void   Page_Init(object   sender,   EventArgs   e)    
//        {    
//        //    
//        //   CODEGEN:   This   call   is   required   by   the   ASP.NET   Web   Form   Designer.    
//        //    
//        InitializeComponent();    
//        }    
//        #region   Web   Form   Designer   generated   code    
//        ///   <summary>    
//        ///   Required   method   for   Designer   support   -   do   not   modify    
//        ///   the   contents   of   this   method   with   the   code   editor.    
//        ///   </summary>    
//        private   void   InitializeComponent()    
//        {    
//        this.Load   +=   new   System.EventHandler(this.Page_Load);    
//        }    
//        #endregion    
//        }    
//      }    
//      ���ϵĴ��벢û��ʲô�ѵģ�����Ͳ��������ˡ�    
//      ��vs.net�У���Insight_cs   solution���һ������á��������֡�������á���������ļ�Insight_cs.WebCharts.dll���룬ʹ���Ϊ��Ŀ�е�namespace��    
//      �������ǾͿ����������ˡ�    
//      ���Ƚ���һ��demochart.aspx�ļ�����������У�����һ�����ݣ�    
//      <IMG   alt="Sales   Data   -   Pie"    
//      src="SalesChart.aspx?type=pie&width=300&height=30    
//      0&title=Sales+by+Year&subtitle=Books">    
//      <IMG   alt="Sales   Data   -   Bar"    
//      src="SalesChart.aspx?type=bar&width=300&height=30    
//      0&title=Sales+by+Year&subtitle=Books">    
//      type��ʾ��ʾͼ�ε����ͣ��Ǳ�ͼpie����������ͼbar��    
//      width��height��ʾͼ�εĴ�С��    
//      title��ʾ��������֡�    
//      subtitle��ʾС�������֡�    
//      ������ʾ��ͼ1��ͼƬ�����¡�ASP.NET��ͼȫ���ԣ��ϣ�������    
         
//      �ɴˣ��������������asp.net������ͼ�Ĺ��̡�    
//      �ۺ������������ܽ�����¼��㣺1.����ASP.NET�����������ڲ�ʹ�õ��������������£����������ͼ�Ρ�2.��ͼ�����ǹ���һ��BitMap��λͼ��������ΪҪ������ͼ���ṩ���ڴ�ռ䡣Ȼ�������й�namespace�ṩ����ͷ�������ͼ�Ρ����Ϳ��Ե���Bitmap����ġ�Save�����������䷢�͵��κ�.NET��������У�������ֱ�ӽ�ͼ�ε����ݷ��͵����������û�н��䱣�浽�����С�