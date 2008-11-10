using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;

namespace psms.util
{
    public class DataGridViewPrinter
    {

        #region �ֶ�
        
       
        /// <summary>
        /// DataGridView
        /// </summary>
        private DataGridView dataGridView1;
        /// <summary>
        /// PrintDocument
        /// </summary>
        private PrintDocument printDocument;
        /// <summary>
        /// PageSetupDialog
        /// </summary>
        //private PageSetupDialog pageSetupDialog;
        /// <summary>
        /// PrintPreviewDialog
        /// </summary>
        private PrintPreviewDialog printPreviewDialog;

        /// <summary>
        /// PrintDialog
        /// </summary>
        private PrintDialog printDialog;



        /// <summary>
        /// ��������
        /// </summary>
        private string title = "";

        /// <summary>
        /// ��ǰҳ
        /// </summary>
        int currentPageIndex = 0;
        /// <summary>
        /// ����ҳ
        /// </summary>
        int endPageIndex = 0;
        /// <summary>
        /// ������
        /// </summary>
        int rowCount = 0;
        /// <summary>
        /// ÿҳ����
        /// </summary>
        int pageCount = 0;

        /// <summary>
        /// �����С Ĭ��20
        /// </summary>
        int titleSize = 20;
        /// <summary>
        /// �Ƿ��Զ���Header Ĭ��ֵfalse
        /// </summary>
        bool isCustomHeader = false;

        /// <summary>
        /// ��ˢ ��ɫ
        /// </summary>
        //Brush alertBrush = new SolidBrush(Color.Red);

        /// <summary>
        /// ����Զ���������ַ����������Ҫб�߷ָ�������\��ʾ�����磺����#���� ����#ΪsplitChar
        /// </summary>
        string[] header = null;

        /// <summary>
        /// ������������
        /// </summary>
        string[] uplineHeader = null;
        /// <summary>
        /// //���е�����index,���û�����о���Ϊ-1��
        /// </summary>
        int[] upLineHeaderIndex = null;
        /// <summary>
        /// //�Ƿ�ÿһҳ��Ҫ��ӡ���⡣Ĭ��false
        /// </summary>
        public bool isEveryPagePrintTitle = false;
        /// <summary>
        /// �����߶�
        /// </summary>
        public int headerHeight = 30;
        /// <summary>
        /// //���߾�
        /// </summary>
        public int topMargin = 20; 
        /// <summary>
        /// //��Ԫ�񶥱߾�
        /// </summary>
        public int cellTopMargin = 6;
        /// <summary>
        /// //��Ԫ����߾�
        /// </summary>
        public int cellLeftMargin = 4;
        /// <summary>
        /// //��headerҪ��б�߱�ʾ��ʱ��
        /// </summary>
        public char splitChar = '#';
        /// <summary>
        /// //�����������DataGridView���� false,����ת�����ַ���
        /// </summary>
        public string falseStr = "��";
        /// <summary>
        /// //�����������DataGridView���� true,����ת�����ַ���
        /// </summary>
        public string trueStr = "��";
        /// <summary>
        /// //ÿҳ����
        /// </summary>
        public int pageRowCount = 30;
        /// <summary>
        /// //�и�
        /// </summary>
        public int rowGap = 28;
        /// <summary>
        /// //ÿ�м��
        /// </summary>
        public int colGap = 5;
        /// <summary>
        /// //ҳ����߾�
        /// </summary>
        public int leftMargin = 80;
        /// <summary>
        /// //��������
        /// </summary>
        public Font titleFont = new Font("����", 24, FontStyle.Bold);
        /// <summary>
        /// //��������
        /// </summary>
        public Font font = new Font("����", 10);
        /// <summary>
        /// //������������
        /// </summary>
        public Font headerFont = new Font("����", 11, FontStyle.Bold);
        /// <summary>
        /// //ҳ����ʾҳ��������
        /// </summary>
        public Font footerFont = new Font("Arial", 8);
        /// <summary>
        /// //��header��������ʾ��ʱ��������ʾ�����塣
        /// </summary>
        public Font upLineFont = new Font("Arial", 9, FontStyle.Bold);
        /// <summary>
        /// //��header��������ʾ��ʱ��������ʾ�����塣
        /// </summary>
        public Font underLineFont = new Font("Arial", 8);
        /// <summary>
        /// //��ˢ
        /// </summary>
        public Brush brush = new SolidBrush(Color.Black);
        /// <summary>
        /// �Ƿ��Զ�����������
        /// </summary>
        public bool isAutoPageRowCount = true;
        /// <summary>
        /// //�ױ߾�
        /// </summary>
        public int buttomMargin = 80;
        /// <summary>
        /// //�Ƿ��ӡҳ��ҳ��
        /// </summary>
        public bool needPrintPageIndex = true;
        /// <summary>
        /// //�����Ƿ���ʾͳ��
        /// </summary>
        public bool setTongji = false;       

        /// <summary>
        /// //��ʾ����
        /// </summary>
        //string sTitle = "";  
        /// <summary>
        /// //ͳ��01
        /// </summary>
        string sTongJi01 = ""; 
        /// <summary>
        ///  //ͳ��02
        /// </summary>
        string sTongJi02 = "";    
        /// <summary>
        /// //ͳ��03
        /// </summary>
        string sTongJi03 = "";
        /// <summary>
        /// //ͳ��04
        /// </summary>
        string sTongJi04 = "";
        /// <summary>
        ///  //ͳ��05
        /// </summary>
        string sTongJi05 = "";
        /// <summary>
        /// //ͳ��06
        /// </summary>
        string sTongJi06 = "";

        /// <summary>
        /// //ͳ��07
        /// </summary>
        string sTongJi07 = "";
        /// <summary>
        ///  //ͳ��08
        /// </summary>
        string sTongJi08 = "";
        /// <summary>
        /// //ͳ��09
        /// </summary>
        string sTongJi09 = "";
        /// <summary>
        /// //�Ƿ���ʾͳ��  
        /// </summary>
        //bool isTongji = false;     

        /// <summary>
        /// //����ʱ�����01
        /// </summary>
        string time01 = "";      
   
        /// <summary>
        /// //����ʱ�����02
        /// </summary>
        string time02 ="";

        /// <summary>
        /// //ͳ������
        /// </summary>
        //Font tongJiFont = new Font("����", 14);   
        /// <summary>
        /// //���ڱ�������
        /// </summary>
        Font dateFont = new Font("����", 12, FontStyle.Bold);
        #endregion

        /// <summary>
        /// ��ͳ�Ʊ����ӡ
        /// </summary>
        /// <param name="dGView">DataGridView</param>
        /// <param name="title">����</param>
        /// <param name="times01">��ʼʱ��</param>
        /// <param name="times02">��ֹʱ��</param>
        /// <param name="tj01">ͳ��01</param>
        /// <param name="tj02">ͳ��02</param>
        /// <param name="tj03">ͳ��03</param>
        /// <param name="tj">ȷ���Ƿ��ӡͳ��</param>
        /// <param name="iPrintType">��ӡ��ʽѡ��Ĭ��2</param>
        public DataGridViewPrinter(DataGridView dGView, string title, string times01, string times02, 
            string tj01, string tj02, string tj03,
            string tj04, string tj05, string tj06, 
            bool tj)
        {
            //��ȡ�����ļ��еı�������
            setSettings();


            this.title = title;
            this.sTongJi01 = tj01;
            this.sTongJi02 = tj02;
            this.sTongJi03 = tj03;
            this.sTongJi04 = tj04;
            this.sTongJi05 = tj05;
            this.sTongJi06 = tj06;

            this.time01 = times01;
            this.time02 = times02;

            this.setTongji = tj;

            this.dataGridView1 = dGView;
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);

            

        }


        public DataGridViewPrinter(DataGridView dGView, string title, string times01, string times02,
            string tj01, string tj02, string tj03,
            string tj04, string tj05, string tj06,
            string tj07, string tj08, string tj09,
            bool tj)
        {
            //��ȡ�����ļ��еı�������
            setSettings();


            this.title = title;
            this.sTongJi01 = tj01;
            this.sTongJi02 = tj02;
            this.sTongJi03 = tj03;
            this.sTongJi04 = tj04;
            this.sTongJi05 = tj05;
            this.sTongJi06 = tj06;

            this.sTongJi07 = tj07;
            this.sTongJi08 = tj08;
            this.sTongJi09 = tj09;

            this.time01 = times01;
            this.time02 = times02;

            this.setTongji = tj;

            this.dataGridView1 = dGView;
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);



        }




        

        private void setSettings()
        {
            //string test = ConfigurationManager.AppSettings["test"];
            try
            {
                // ��ͷ�߶�-->
                this.titleSize = int.Parse(ConfigurationManager.AppSettings["titleSize"]); // ="20"/>
                // �Ƿ�ÿһҳ��Ҫ��ӡ���⡣Ĭ��false-->
                this.isEveryPagePrintTitle = ConfigurationManager.AppSettings["isEveryPagePrintTitle"] == "true"; // ="fasle"/>
                //�����߶� -->
                this.headerHeight = int.Parse(ConfigurationManager.AppSettings["headerHeight"]); // ="30"/>
                //���߾� -->
                this.topMargin = int.Parse(ConfigurationManager.AppSettings["topMargin"]); // ="20"/>
                //��Ԫ�񶥱߾� -->
                this.cellTopMargin = int.Parse(ConfigurationManager.AppSettings["cellTopMargin"]); // ="6"/>
                //��Ԫ����߾� -->
                this.cellLeftMargin = int.Parse(ConfigurationManager.AppSettings["cellLeftMargin"]); // ="4"/>
                //ÿҳ���� -->
                this.pageRowCount = int.Parse(ConfigurationManager.AppSettings["pageRowCount"]); // ="30"/>
                //�и� -->
                this.rowGap = int.Parse(ConfigurationManager.AppSettings["rowGap"]); // ="28"/>
                // ÿ�м��-->
                this.colGap = int.Parse(ConfigurationManager.AppSettings["colGap"]); // ="5"/>
                // ҳ����߾�-->
                this.leftMargin = int.Parse(ConfigurationManager.AppSettings["leftMargin"]); // ="80"/>


                //�������� -->
                this.titleFont = new Font(ConfigurationManager.AppSettings["titleFont"],
                    float.Parse(ConfigurationManager.AppSettings["titleFontSize"]),
                    ConfigurationManager.AppSettings["titleFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular); // ="����"/>


                //���������� -->
                this.dateFont = new Font(ConfigurationManager.AppSettings["dateFont"],
                    float.Parse(ConfigurationManager.AppSettings["dateFontSize"]),
                    ConfigurationManager.AppSettings["dateFontBold"] == "true" ? FontStyle.Bold : FontStyle.Regular);


                // ��������-->
                this.font = new Font(ConfigurationManager.AppSettings["font"],
                    float.Parse(ConfigurationManager.AppSettings["fontSize"]),
                    ConfigurationManager.AppSettings["fontBold"]  == "true" ? FontStyle.Bold : FontStyle.Regular);


                //������������ -->
                this.headerFont = new Font(ConfigurationManager.AppSettings["headerFont"],
                    float.Parse(ConfigurationManager.AppSettings["headerFontSize"]),
                    ConfigurationManager.AppSettings["headerFontBold"]  == "true" ? FontStyle.Bold : FontStyle.Regular);


                //ҳ����ʾҳ�������� -->
                this.footerFont = new Font(ConfigurationManager.AppSettings["footerFont"],
                    float.Parse(ConfigurationManager.AppSettings["footerFontSize"]),
                    ConfigurationManager.AppSettings["footerFontBold"]  == "true"  ? FontStyle.Bold : FontStyle.Regular);



                // �Ƿ��Զ���������-->
                this.isAutoPageRowCount = ConfigurationManager.AppSettings["isAutoPageRowCount"] == "true"; // ="true"/>

                //�ױ߾� -->
                this.buttomMargin = int.Parse(ConfigurationManager.AppSettings["buttomMargin"]); // ="80"/>

                // �Ƿ��ӡҳ��ҳ��-->
                this.needPrintPageIndex = ConfigurationManager.AppSettings["needPrintPageIndex"] == "true"; // ="true"/>

                //�����Ƿ���ʾͳ�� -->
                this.setTongji = ConfigurationManager.AppSettings["setTongji"] == "true"; // ="true"/> 
            }
            catch
            {
                //e.Message;
            }

        }


        public bool setTowLineHeader(string[] upLineHeader, int[] upLineHeaderIndex)
        {
            this.uplineHeader = upLineHeader;
            this.upLineHeaderIndex = upLineHeaderIndex;
            this.isCustomHeader = true;
            return true;
        }
        public bool setHeader(string[] header)
        {
            this.header = header;
            return true;

        }

        bool isTitle = true;
        bool isPageOne = true;
        int prevPageRowCount = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            #region ��ӡ --- ͳ�Ʊ���
            int width = e.PageBounds.Width;
            int height = e.PageBounds.Height;
            //this.leftMargin = 40;   //����������߾�

            //�Ƿ���ʾ������
            int TSize = int.Parse(ConfigurationManager.AppSettings["titleSize"]); //���ڳ�ʼ��this.titleSize
            if (isPageed && isTitle)
            {
                this.titleSize = this.titleSize + 75;

                isTitle = false;
            }
            else if (this.setTongji && (pageCount == 0 || pageCount == 1) && isTitle)
            {
                this.titleSize = this.titleSize + 75;

            }
            
            else
            {
                if (!isTitle)
                    this.titleSize = TSize + 75;
                else
                    this.titleSize = TSize;
            }
            if (this.isAutoPageRowCount)
            {
                pageRowCount = (int)((height - this.topMargin - this.titleSize - 25 - this.headerFont.Height - this.headerHeight - this.buttomMargin) / this.rowGap );
                //this.isAutoPageRowCount = false;
            }

            int startRow = 0;
            if (isPageOne)
            {
                pageCount = (int)(rowCount / (pageRowCount + 3));
                if (rowCount % (pageRowCount + 3) > 0)
                    pageCount++;
                isPageOne = false;
                this.prevPageRowCount = pageRowCount;

                //startRow = 0;
            }
            else
            {
                pageCount = (int)(rowCount / pageRowCount);
                if (rowCount % pageRowCount > 0)
                    pageCount++;

                startRow = currentPageIndex * pageRowCount - 3;
                
            }

            int endRow = startRow + this.pageRowCount < rowCount ? startRow + pageRowCount : rowCount;
            int currentPageRowCount = endRow - startRow;

            //if (this.setTongji && pageCount == 1)
            //{

            //    pageRowCount = (int)((height - this.topMargin - titleSize - 25 - this.headerFont.Height - this.headerHeight - 25 - this.buttomMargin) / this.rowGap);
            //    pageCount = (int)(rowCount / pageRowCount);
            //    if (rowCount % pageRowCount > 0)
            //        pageCount++;
            //}


            string sDateTitle = time01 == "" || time02 == "" ? "" : time01 + " �� " + time02;

            int xoffset = (int)((width - e.Graphics.MeasureString(this.title, this.titleFont).Width) / 2);
            int xoffset2 = (int)((width - e.Graphics.MeasureString(sDateTitle, dateFont).Width) / 2);

            int colCount = 0;
            int x = 0;
            int y = topMargin;
            string cellValue = "";

            //int startRow = currentPageIndex * pageRowCount;
            //int startRow = currentPageIndex * prevPageRowCount;
            //int endRow = startRow + this.pageRowCount < rowCount ? startRow + pageRowCount : rowCount;
            //int currentPageRowCount = endRow - startRow;



            if (this.currentPageIndex == 0 || this.isEveryPagePrintTitle)
            {

                e.Graphics.DrawString(this.title, titleFont, brush, xoffset, y);
                e.Graphics.DrawString(sDateTitle, dateFont, brush, this.leftMargin, y + 40);
                if (this.setTongji)
                {
                    int xoffsetTongJi = (int)((width - e.Graphics.MeasureString(sTongJi01, dateFont).Width) / 2);
                    e.Graphics.DrawString(this.sTongJi01, this.dateFont, brush, this.leftMargin, y + 65);          //ͳ��01
                    e.Graphics.DrawString(this.sTongJi03, this.dateFont, brush, this.leftMargin, y + 90);          //ͳ��03
                    e.Graphics.DrawString(this.sTongJi05, this.dateFont, brush, this.leftMargin, y + 115);       ��//ͳ��05
                    e.Graphics.DrawString(this.sTongJi02, this.dateFont, brush, this.leftMargin + 350, y + 65);    //ͳ��02
                    e.Graphics.DrawString(this.sTongJi04, this.dateFont, brush, this.leftMargin + 350, y + 90);    //ͳ��04
                    e.Graphics.DrawString(this.sTongJi06, this.dateFont, brush, this.leftMargin + 350, y + 115);   //ͳ��06

                    e.Graphics.DrawString(this.sTongJi07, this.dateFont, brush, this.leftMargin + 700, y + 65);    //ͳ��02
                    e.Graphics.DrawString(this.sTongJi08, this.dateFont, brush, this.leftMargin + 700, y + 90);    //ͳ��04
                    e.Graphics.DrawString(this.sTongJi09, this.dateFont, brush, this.leftMargin + 700, y + 115);   //ͳ��06
                }
                
                y += titleSize + 20;
            }

            try
            {

                colCount = dataGridView1.ColumnCount;

                y += rowGap;
                x = leftMargin;


                DrawLine(new Point(x, y), new Point(x, y + currentPageRowCount * rowGap + this.headerHeight), e.Graphics);//����ߵ�����

                int lastIndex = -1;
                int lastLength = 0;
                int indexj = -1;

                for (int j = 0; j < colCount; j++)
                {
                    int colWidth = dataGridView1.Columns[j].Width;
                    if (colWidth > 0)
                    {
                        indexj++;
                        if (this.header == null || this.header[indexj] == "")
                            cellValue = dataGridView1.Columns[j].HeaderText;
                        else
                            cellValue = header[indexj];

                        if (this.isCustomHeader)
                        {
                            if (this.upLineHeaderIndex[indexj] != lastIndex)
                            {

                                if (lastLength > 0 && lastIndex > -1)//��ʼ����һ��upline
                                {
                                    string upLineStr = this.uplineHeader[lastIndex];
                                    int upXOffset = (int)((lastLength - e.Graphics.MeasureString(upLineStr, this.upLineFont).Width) / 2);
                                    if (upXOffset < 0)
                                        upXOffset = 0;
                                    e.Graphics.DrawString(upLineStr, this.upLineFont, brush, x - lastLength + upXOffset, y + (int)(this.cellTopMargin / 2));

                                    DrawLine(new Point(x - lastLength, y + (int)(this.headerHeight / 2)), new Point(x, y + (int)(this.headerHeight / 2)), e.Graphics);//����
                                    DrawLine(new Point(x, y), new Point(x, y + (int)(this.headerHeight / 2)), e.Graphics);
                                }
                                lastIndex = this.upLineHeaderIndex[indexj];
                                lastLength = colWidth + colGap;
                            }
                            else
                            {
                                lastLength += colWidth + colGap;
                            }
                        }

                        //int currentY=y+cellTopMargin;


                        int Xoffset = 10;
                        int Yoffset = 20;
                        int leftWordIndex = cellValue.IndexOf(this.splitChar);
                        if (this.upLineHeaderIndex != null && this.upLineHeaderIndex[indexj] > -1)
                        {

                            if (leftWordIndex > 0)
                            {
                                string leftWord = cellValue.Substring(0, leftWordIndex);
                                string rightWord = cellValue.Substring(leftWordIndex + 1, cellValue.Length - leftWordIndex - 1);
                                //�������
                                Xoffset = (int)(colWidth + colGap - e.Graphics.MeasureString(rightWord, this.upLineFont).Width);
                                Yoffset = (int)(this.headerHeight / 2 - e.Graphics.MeasureString("a", this.underLineFont).Height);


                                Xoffset = 6;
                                Yoffset = 10;
                                e.Graphics.DrawString(rightWord, this.underLineFont, brush, x + Xoffset - 4, y + (int)(this.headerHeight / 2));
                                e.Graphics.DrawString(leftWord, this.underLineFont, brush, x + 2, y + (int)(this.headerHeight / 2) + (int)(this.cellTopMargin / 2) + Yoffset - 2);
                                DrawLine(new Point(x, y + (int)(this.headerHeight / 2)), new Point(x + colWidth + colGap, y + headerHeight), e.Graphics);
                                x += colWidth + colGap;
                                DrawLine(new Point(x, y + (int)(this.headerHeight / 2)), new Point(x, y + currentPageRowCount * rowGap + this.headerHeight), e.Graphics);
                            }
                            else
                            {

                                e.Graphics.DrawString(cellValue, headerFont, brush, x + (dataGridView1.Columns[j].Width - e.Graphics.MeasureString(cellValue, headerFont).Width) / 2, y + (int)(this.headerHeight / 2) + (int)(this.cellTopMargin / 2));
                                x += colWidth + colGap;
                                DrawLine(new Point(x, y + (int)(this.headerHeight / 2)), new Point(x, y + currentPageRowCount * rowGap + this.headerHeight), e.Graphics);
                            }

                        }
                        else
                        {
                            if (leftWordIndex > 0)
                            {
                                string leftWord = cellValue.Substring(0, leftWordIndex);
                                string rightWord = cellValue.Substring(leftWordIndex + 1, cellValue.Length - leftWordIndex - 1);
                                //�������
                                Xoffset = (int)(colWidth + colGap - e.Graphics.MeasureString(rightWord, this.upLineFont).Width);
                                Yoffset = (int)(this.headerHeight - e.Graphics.MeasureString("a", this.underLineFont).Height);

                                e.Graphics.DrawString(rightWord, this.headerFont, brush, x + Xoffset - 4, y + 2);
                                e.Graphics.DrawString(leftWord, this.headerFont, brush, x + 2, y + Yoffset - 4);
                                DrawLine(new Point(x, y), new Point(x + colWidth + colGap, y + headerHeight), e.Graphics);
                                x += colWidth + colGap;
                                DrawLine(new Point(x, y), new Point(x, y + currentPageRowCount * rowGap + this.headerHeight), e.Graphics);
                            }
                            else
                            {
                                e.Graphics.DrawString(cellValue, headerFont, brush, x + (dataGridView1.Columns[j].Width - e.Graphics.MeasureString(cellValue, headerFont).Width)/2, y + cellTopMargin);
                                x += colWidth + colGap;
                                DrawLine(new Point(x, y), new Point(x, y + currentPageRowCount * rowGap + this.headerHeight), e.Graphics);
                            }

                        }

                    }
                }
                
                ////ѭ�������������һ����upLine
                if (this.isCustomHeader)
                {

                    if (lastLength > 0 && lastIndex > -1)//��ʼ����һ��upline
                    {
                        string upLineStr = this.uplineHeader[lastIndex];
                        int upXOffset = (int)((lastLength - e.Graphics.MeasureString(upLineStr, this.upLineFont).Width) / 2);
                        if (upXOffset < 0)
                            upXOffset = 0;
                        e.Graphics.DrawString(upLineStr, this.upLineFont, brush, x - lastLength + upXOffset, y + (int)(this.cellTopMargin / 2));

                        DrawLine(new Point(x - lastLength, y + (int)(this.headerHeight / 2)), new Point(x, y + (int)(this.headerHeight / 2)), e.Graphics);//����
                        DrawLine(new Point(x, y), new Point(x, y + (int)(this.headerHeight / 2)), e.Graphics);
                    }
                   

                }

                int rightBound = x;

                DrawLine(new Point(leftMargin, y), new Point(rightBound, y), e.Graphics); //���������
                string now = DateTime.Now.ToShortDateString();
                e.Graphics.DrawString(now, this.dateFont, brush, 
                    rightBound - e.Graphics.MeasureString(now, dateFont).Width,
                    y - e.Graphics.MeasureString(now, dateFont).Height);       �� //��ӡʱ��
                //DrawLine(new Point(leftMargin,y+this.headerHeight),new Point(rightBound,y+this.headerHeight),e.Graphics);//�������������

                y += this.headerHeight;


                //print all rows
                for (int i = startRow; i < endRow; i++)
                {

                    x = leftMargin;
                    for (int j = 0; j < colCount; j++)
                    {
                        if (dataGridView1.Columns[j].Width > 0)
                        {
                            cellValue = dataGridView1.Rows[i].Cells[j].Value == null ? "True" : dataGridView1.Rows[i].Cells[j].Value.ToString();
                            if (cellValue == "False")
                                //break;
                                cellValue = falseStr;
                            if (cellValue == "True")
                                cellValue = trueStr;

                            if (isNumber(cellValue))
                            {

                                e.Graphics.DrawString(cellValue, font, brush, x + (dataGridView1.Columns[j].Width - e.Graphics.MeasureString(cellValue, font).Width), y + cellTopMargin);
                            }
                            else
                            {
                                e.Graphics.DrawString(cellValue, font, brush, x + this.cellLeftMargin, y + cellTopMargin);
                            }
                            x += dataGridView1.Columns[j].Width + colGap;
                            y = y + rowGap * (cellValue.Split(new char[] { '\r', '\n' }).Length - 1);
                        }
                    }
                    DrawLine(new Point(leftMargin, y), new Point(rightBound, y), e.Graphics);
                    y += rowGap;
                }
                DrawLine(new Point(leftMargin, y), new Point(rightBound, y), e.Graphics);

                currentPageIndex++;

                //if (this.setTongji && currentPageIndex == pageCount)
                //    this.isTongji = true;

                

                if (this.needPrintPageIndex)
                {
                    if (pageCount != 1)
                    {
                        e.Graphics.DrawString("�� " + pageCount.ToString() + " ҳ,��ǰ�� " + this.currentPageIndex.ToString() + " ҳ", this.footerFont, brush, xoffset + 200, (int)(height - this.buttomMargin / 2 - this.footerFont.Height));
                    }
                }

                string s = cellValue;
                string f3 = cellValue;



                if (currentPageIndex < pageCount && currentPageIndex < endPageIndex)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                    this.currentPageIndex = 0;
                    this.pageCount = 0;
                    this.isPageOne = true;
                    this.titleSize = int.Parse(ConfigurationManager.AppSettings["titleSize"]); // ="20"/>

                }
                //iPageNumber+=1;

            }
            catch
            {

            }

            #endregion

        }
        private void DrawLine(Point sp, Point ep, Graphics gp)
        {
            Pen pen = new Pen(Color.Black);
            gp.DrawLine(pen, sp, ep);
        }

        public PrintDocument GetPrintDocument()
        {
            return printDocument;
        }

        /// <summary>
        /// �ж������ֻ����ַ��� ����true,�ַ���false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isNumber(string str)
        {
            Regex r = new Regex(@"^(-|\+)?\d+(\.)?\d*$");
            if (r.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// ��ʼ��ӡDataGridView
        /// </summary>
        public void Print()
        {
            rowCount = 0;
            try
            {
                if (dataGridView1.DataSource.GetType().ToString() == "System.Data.DataSet")
                {
                    rowCount = ((DataSet)dataGridView1.DataSource).Tables[0].Rows.Count;
                }
                else if (dataGridView1.DataSource.GetType().ToString() == "System.Data.DataView")
                {
                    rowCount = ((DataView)dataGridView1.DataSource).Count;
                }
                else if (dataGridView1.DataSource.GetType().ToString() == "System.Data.DataTable")
                {
                    rowCount = ((DataTable)dataGridView1.DataSource).Rows.Count;
                }

                //pageSetupDialog = new PageSetupDialog();
                //pageSetupDialog.AllowOrientation = true;
                //pageSetupDialog.Document = printDocument;
                //pageSetupDialog.Document.DefaultPageSettings.Landscape = true;        //    ���ô�ӡΪ����

                printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                printDialog.AllowCurrentPage = true;
                printDialog.AllowSomePages = true;
                //printDialog.UseEXDialog = true;
                //printDialog.ShowDialog();
               
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    this.currentPageIndex = printDialog.PrinterSettings.FromPage == 0 ? 0 : printDialog.PrinterSettings.FromPage - 1;
                    this.endPageIndex = printDialog.PrinterSettings.ToPage == 0 ? 200000 : printDialog.PrinterSettings.ToPage;
                    if (printDialog.PrinterSettings.ToPage == 0)
                    {
                        isPageed = false;
                    }
                    else
                    {
                        isPageed = true;
                    }
                    printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.Height = 600;
                    printPreviewDialog.Width = 750;
                    printPreviewDialog.ClientSize = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size.Height);
                    printPreviewDialog.PrintPreviewControl.Zoom = 1;
                    printPreviewDialog.Document.DefaultPageSettings.Landscape = true;
                    
                    printPreviewDialog.ShowDialog();
                }

                

         
            }
            catch
            {
                //throw new Exception("Printer error." + e.Message);
            }

        }

        private bool isPageed = false;
    }
}