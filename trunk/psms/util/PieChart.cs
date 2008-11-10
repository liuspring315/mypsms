/*自定义类，通过输入不同的参数，这些类可以画不同的图形   */

using System;
using System.IO;//用于文件存取    
using System.Data;//用于数据访问    
using System.Drawing;//提供画GDI+图形的基本功能    
using System.Drawing.Text;//提供画GDI+图形的高级功能    
using System.Drawing.Drawing2D;//提供画高级二维，矢量图形功能    
using System.Drawing.Imaging;//提供画GDI+图形的高级功能    
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace psms.util
{
    public class PieChart
    {

        #region 格式参数
		 
        
        /// <summary>
        /// //标题字体 -->
        /// </summary>
        static Font titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
                     float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
                     ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="黑体"/>


        /// <summary>
        /// //副标题字体 -->
        /// </summary>
        static Font dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                    float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                    ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


        /// <summary>
        /// // 正文字体-->
        /// </summary>
        static Font font = new Font(ConfigurationManager.AppSettings["font"],
                    float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                    ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

        /// <summary>
        /// //顶边距 -->
        /// </summary>
        static int topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

        /// <summary>
        /// // 页面左边距-->
        /// </summary>
        static int leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>

        private static void setConfig()
        {
             titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
            float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
            ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="黑体"/>


            /// <summary>
            /// //副标题字体 -->
            /// </summary>
             dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                       float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                       ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


            /// <summary>
            /// // 正文字体-->
            /// </summary>
             font = new Font(ConfigurationManager.AppSettings["font"],
                       float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                       ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

            /// <summary>
            /// //顶边距 -->
            /// </summary>
             topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

            /// <summary>
            /// // 页面左边距-->
            /// </summary>
             leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>
        }
        #endregion


        /// <summary>
        /// 画饼形图
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

            //通过输入参数，取得饼图中的总基数    
            float sumData = 0;
            for (int i = 0; i < dt.Count; i++)
            {
                sumData += Convert.ToSingle(dt[i][2]);
            }
            //产生一个image对象，并由此产生一个Graphics对象    
            Bitmap bm = new Bitmap(width, height);
            bm.SetResolution(72, 72);
            Graphics g = Graphics.FromImage(bm);
            //设置对象g的属性    
            //g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH, (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            //画布和边的设定    
            g.Clear(Color.White);
            //g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //画饼图标题
      
            g.DrawString(title, titleFont, Brushes.Black, new PointF(leftMargin + 200, topMargin));
            topMargin = topMargin + (int)g.MeasureString(title,titleFont).Height + 20;
            //画饼图的副标题   
            g.DrawString(st1, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st1, dateFont).Height + 10;
            g.DrawString(st2, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st2, dateFont).Height + 10;
            g.DrawString(st3, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
            topMargin = topMargin + (int)g.MeasureString(st3, dateFont).Height + 10;

            //画饼图    
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
            //画图例框及其文字    
            //g.DrawRectangle(Pens.Black, 200, 300, 199, 99);
            //g.DrawString("Legend", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new PointF(200, 300));

            //画图例各项    
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
            //通过Response.OutputStream，将图形的内容发送到浏览器    
            //bm.Save(target, ImageFormat.Gif);
            //回收资源    
            //bm.Dispose();
            g.Dispose();

            return bm;
        }


        


    }

    //画条形图    
    public class BarChart
    {

        #region 格式参数
        
        

        /// <summary>
        /// //标题字体 -->
        /// </summary>
        static Font titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
                     float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
                     ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="黑体"/>


        /// <summary>
        /// //副标题字体 -->
        /// </summary>
        static Font dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                    float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                    ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


        /// <summary>
        /// // 正文字体-->
        /// </summary>
        static Font font = new Font(ConfigurationManager.AppSettings["font"],
                    float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                    ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

        /// <summary>
        /// //顶边距 -->
        /// </summary>
        static int topMargin = 15;//int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

        /// <summary>
        /// // 页面左边距-->
        /// </summary>
        static int leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>


        private static void setConfig()
        {
            titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
           float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
           ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="黑体"/>


            /// <summary>
            /// //副标题字体 -->
            /// </summary>
            dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                      float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                      ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


            /// <summary>
            /// // 正文字体-->
            /// </summary>
            font = new Font(ConfigurationManager.AppSettings["font"],
                      float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                      ConfigurationManager.AppSettings["fontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);

            /// <summary>
            /// //顶边距 -->
            /// </summary>
            topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>

            /// <summary>
            /// // 页面左边距-->
            /// </summary>
            leftMargin = 20;//int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>
        }

        #endregion

        /// <summary>
        /// 得到柱形图的图片
        /// </summary>
        /// <param name="title"></param>
        /// <param name="subTitle"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Bitmap GreateImage(string title, string st1,string st2,string st3, IList<IList<string>> dt)
        {
            setConfig();

            //标题高度
            int titleSize = 200;
            //标题x坐标
            //int titleX = 180;


           

            //y轴
            String[] m = {" 0%"," 10%"," 20%"," 30%"," 40%", " 50%", " 60%", " 70%"," 80%"," 90%", "100%" };


            int barWidth = 30;

            //原点 0 0
            int x = leftMargin * 2;
            int y = titleSize + 10 + barWidth * m.Length;


            //int height = y +dt.Count * 12, width = 200 + dt.Count * 40;
            

            //System.Drawing.Bitmap image = new System.Drawing.Bitmap(dt.Count < 10 ? 820 : width + 100, dt.Count < 10 ? 660 : height + 100);
            int width = 842;
            int height = 595;
            //产生一个image对象，并由此产生一个Graphics对象    
            Bitmap image = new Bitmap(width, height);
            image.SetResolution(72, 72);
            //创建Graphics类对象
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            try
            {
                //清空图片背景色
                g.Clear(Color.White);

                //Font font = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
                //Font font1 = new System.Drawing.Font("宋体", 20, FontStyle.Regular);
                //Font fontTitle = new System.Drawing.Font("宋体", 20, FontStyle.Regular);

                //System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Blue, 1.2f, true);
                //g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);

                Brush brush1 = new SolidBrush(Color.Blue);
                //画标题的刷子
                Brush brushTitle = new SolidBrush(Color.Black);

                g.DrawString(title, titleFont, Brushes.Black, new PointF(leftMargin + 200, topMargin));
                topMargin = topMargin + 30;
                //画副标题   
                g.DrawString(st1, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                topMargin = topMargin + 15;
                g.DrawString(st2, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                topMargin = topMargin + 15;
                g.DrawString(st3, dateFont, Brushes.Black, new PointF(leftMargin + 60, topMargin));
                //topMargin = topMargin + 10;
                //画图片的边框线
                //g.DrawRectangle(new Pen(Color.Blue), 0, 0, image.Width - 4, image.Height - 4);

                //画坐标系的笔
                Pen mypen = new Pen(Brushes.Black, 1);
                //绘制线条
                //绘制纵线条 百分比坐标
                y = topMargin + barWidth * m.Length;
                int beginx = x;
                for (int i = 0; i < dt.Count; i++)
                {
                    g.DrawLine(mypen, beginx, topMargin + 20, beginx, y);
                    beginx = beginx + barWidth;
                }
                //Pen mypen1 = new Pen(Color.Blue, 2);
                //g.DrawLine(mypen1, x - 480, 80, x - 480, 340);

                //绘制横向线条
                int beginy = y;
                for (int i = 0; i < m.Length; i++)
                {
                    g.DrawLine(mypen, x, beginy, x + dt.Count * barWidth, beginy);
                    g.DrawString(m[i].ToString(), font, Brushes.Red, x - g.MeasureString(m[i].ToString(),font).Width, beginy - g.MeasureString(m[i].ToString(),font).Height); //设置文字内容及输出位置
                    beginy = beginy - barWidth;
                }
                //g.DrawLine(mypen1, 60, y, 540, y);

       

                //名称
                String[] n = new String[dt.Count];
                //总和
                float number = 0;
                //百分比
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
                
                ////显示柱状效果

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

//代码分析：

//1.引入一些namespace
//using System;
//using System.IO;//用于文件存取
//using System.Data;//用于数据访问
//using System.Drawing;//提供画GDI+图形的基本功能
//using System.Drawing.Text;//提供画GDI+图形的高级功能
//using System.Drawing.Drawing2D;//提供画高级二维，矢量图形功能
//using System.Drawing.Imaging;//提供画GDI+图形的高级功能
//这些namespace将在后面被应用。

//2.自定义一个namespace为Insight_cs.WebCharts，其中包括了两个类PieChart和BarChart，很清楚， class PieChart是为画饼图而建，class BarChart是为画条形图而建。由于class PieChart和class BarChar差不多，所以下面我们以饼图为例，进行代码分析。

//3.类PieChart建立一个方法Render，此方法可以含一些参数。简单说明如下：
//参数title，表示饼图上方的大标题文字。
//参数subtitle，表示饼图上方的小标题文字。
//参数width，height，表示了整个图形的大小。
//参数charData是一个DataSet对象实例，用于画图使用。
//参数target是Stream对象的实例，用于图形输出时使用。

//4.为了增加可读性，定义一些常量：
//const int SIDE_LENGTH = 400;//画布边长
//const int PIE_DIAMETER = 200;//饼图直径

//5.定义一个DataTable，它是DataSet中的一个数据表。其中存放了饼图的各个数据。

//6.通过计算，得出饼图中的总基数sumData。

//7.建立了一个BitMap对象，它为要创建的图形提供了内存空间。并由此产生一个Graphics对象，它封装了GDI+画图接口。

//8.调用Graphics对象的方法ScaleTransform()，它是用来设定图形比例的。

//9.调用方法SmoothingMode()，TextRenderingHint()等来设置文字和图形的相关属性。

//10.设置画布和边。

//11.设置文字标题，图例，画饼图自身。 

//12.通过Stream，将图形的内容发送到浏览器。 
//13.最后回收资源。 

//至此画饼图的类就完成了。画条形图的方法和画饼图的方法大同小异，这里就不展开讲了。总体看来，构建画图的类没有我们想象的那样难，并没有多么高深的算法。其实整体思路，就好像我们用笔在纸上画图是一摸一样的。关键是各个方法的使用和参数设置。

//我们在前面已经完成了饼图和条形图的自定义类，下面我们将要应用这些类了。    
//      使用vs.net新建一个名为Insight_cs的Web应用程序，并且添加到刚才的Insight工程中。删除默认的webform1.aspx文件，新建一个名为SalesChart.aspx文件。打开此文件，在代码模式下，将第一行替换为：    
//      <%@   Page   ContentType="image/gif"   Language="c#"   AutoEventWireup="false"   Codebehind="SalesChart.aspx.cs"   Inherits="Insight_cs.SalesChart"   %>    
//      打开文件SalesChart.aspx.cs，其中代码如下所示：    
//      using   System;    
//      using   System.Data;    
//      using   System.Web;    
//      using   System.IO;    
//      using   System.Data.SqlClient;    
//      using   Insight_cs.WebCharts;//这是自定义的名字空间    
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
//        //从数据库中取得数据，用于画图    
//        string   sql   =   "SELECT   "   +"Year(sa.ord_date)   As   [Year],   "   +"SUM(sa.qty)   As   [Qty]   "   +"FROM   "   +"sales   sa   "   +"inner   join   stores   st   on(sa.stor_id   =   st.stor_id)   "   +"GROUP   BY   "   +"Year(sa.ord_date)   "   +   "ORDER   BY   "   +   "[Year]";    
//        string   connectString   =   "Password=ben;   User   ID=sa;   DataBase=pubs;Data   Source=localhost";    
//        SqlDataAdapter   da   =   new   SqlDataAdapter(sql,connectString);    
//        DataSet   ds   =   new   DataSet();    
//        int   rows   =   da.Fill(ds,"chartData");    
//        //设定产生图的类型（pie   or   bar）    
//        string   type   =   "";    
//        if(null==Request["type"])    
//        {    
//        type   =   "PIE";    
//        }    
//        else    
//        {    
//        type   =   Request["type"].ToString().ToUpper();    
//        }    
//        //设置图大小    
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
//        //设置图表标题    
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
//      以上的代码并没有什么难的，这里就不做分析了。    
//      在vs.net中，打开Insight_cs   solution，右击”引用“，将出现”添加引用“，将组件文件Insight_cs.WebCharts.dll加入，使其成为项目中的namespace。    
//      下面我们就可以浏览结果了。    
//      首先建立一个demochart.aspx文件，在其代码中，加入一下内容：    
//      <IMG   alt="Sales   Data   -   Pie"    
//      src="SalesChart.aspx?type=pie&width=300&height=30    
//      0&title=Sales+by+Year&subtitle=Books">    
//      <IMG   alt="Sales   Data   -   Bar"    
//      src="SalesChart.aspx?type=bar&width=300&height=30    
//      0&title=Sales+by+Year&subtitle=Books">    
//      type表示显示图形的类型，是饼图pie，还是条形图bar。    
//      width，height表示图形的大小。    
//      title表示大标题文字。    
//      subtitle表示小标题文字。    
//      其结果显示如图1（图片在文章《ASP.NET画图全攻略（上）》）。    
         
//      由此，我们完成了利用asp.net技术画图的过程。    
//      综合起来，可以总结出以下几点：1.利用ASP.NET技术，可以在不使用第三方组件的情况下，画出理想的图形。2.画图核心是构造一个BitMap（位图）对象，它为要创建的图形提供了内存空间。然后，利用有关namespace提供的类和方法画出图形。最后就可以调用Bitmap对象的“Save”方法，将其发送到任何.NET的输出流中，这里是直接将图形的内容发送到浏览器，而没有将其保存到磁盘中。