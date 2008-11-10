using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using psms.Model;
using System.Configuration;

namespace psms.util
{
    class WordHelper
    {

        /// <summary>
        /// ���ɳ��ⵥword�ĵ� ���
        /// </summary>
        /// <param name="outScrpList">��������Ʒ����</param>
        /// <param name="outUn">���쵥λ</param>
        /// <param name="vipUn">���ͷ���</param>
        /// <param name="remark">��ע</param>
        /// <param name="outscrpNo">������</param>
        /// <param name="outDate">����ʱ��</param>
        public static void OpenAndWriteWordForOut1(System.ComponentModel.BindingList<OutScrpInfo> outScrpList,string outUn,string vipUn,
            string remark,string outscrpNo,string outDate)
        {
            //������
            System.DateTime now = DateTime.Now;
            string year = now.Date.Year.ToString();
            string month = now.Month.ToString();
            string day = now.Day.ToString();

            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            //��ʾword�ĵ�
            oWord.Visible = true;
            //ȡ��word�ļ�ģ��
            object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\���ⵥ���.doc";
            //����ģ������һ�����ĵ����൱�����Ϊ
            oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                            ref oMissing, ref oMissing);
            //�������������е��ı�

            string[] xyOutDate = ConfigurationManager.AppSettings["out_word_1_outDate"].ToString().Trim().Split(',');
            int xOutDate = Int32.Parse(xyOutDate[0]);
            int yOutDate = Int32.Parse(xyOutDate[1]);
            oDoc.Tables[1].Cell(xOutDate, yOutDate).Range.Text = year + "�� " + month + " �� " + day + " �� ";
            //���쵥λ
            string[] xyOutOu = ConfigurationManager.AppSettings["out_word_1_outOu"].ToString().Trim().Split(',');
            int xOutOu = Int32.Parse(xyOutOu[0]);
            int yOutOu = Int32.Parse(xyOutOu[1]);
            oDoc.Tables[1].Cell(xOutOu, yOutOu).Range.Text = outUn;

            //���ͷ���
            string[] xyVipOu = ConfigurationManager.AppSettings["out_word_1_vipOu"].ToString().Trim().Split(',');
            int xVipOu = Int32.Parse(xyVipOu[0]);
            int yVipOu = Int32.Parse(xyVipOu[1]);
            oDoc.Tables[1].Cell(xVipOu, yVipOu).Range.Text = vipUn;

            //������  ---===
            string[] xyOutscrpno = ConfigurationManager.AppSettings["out_word_1_outscrpno"].ToString().Trim().Split(',');
            int xOutscrpno = Int32.Parse(xyOutscrpno[0]);
            int yOutscrpno = Int32.Parse(xyOutscrpno[1]);
            oDoc.Tables[1].Cell(xOutscrpno, yOutscrpno).Range.Text = outscrpNo;

            //��ע
            string[] xyRemark = ConfigurationManager.AppSettings["out_word_1_remark"].ToString().Trim().Split(',');
            int xRemark = Int32.Parse(xyRemark[0]);
            int yRemark = Int32.Parse(xyRemark[1]);
            oDoc.Tables[1].Cell(xRemark, yRemark).Range.Text = remark;


            //ÿҳ��ʾ������Ʒ��
            int pageCount = Int32.Parse(ConfigurationManager.AppSettings["out_word_1_pageCount"].ToString().Trim());
            //��ʼ��
            int beginRow = Int32.Parse(ConfigurationManager.AppSettings["out_word_1_beginRow"].ToString().Trim());

            //����Ʒ����  outScrpList
            for (int i = 0; i < pageCount && i < outScrpList.Count; i++)
            {
                OutScrpInfo data = outScrpList[i];
                oDoc.Tables[1].Cell(beginRow + i, 1).Range.Text = data.P_no;
                oDoc.Tables[1].Cell(beginRow + i, 2).Range.Text = data.P_name;
                oDoc.Tables[1].Cell(beginRow + i, 3).Range.Text = data.Cost_price.ToString();
                oDoc.Tables[1].Cell(beginRow + i, 4).Range.Text = data.Unit_price.ToString();
                oDoc.Tables[1].Cell(beginRow + i, 5).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                oDoc.Tables[1].Cell(beginRow + i, 6).Range.Text = ((decimal)(data.Cost_price * data.Qnt)).ToString();
                oDoc.Tables[1].Cell(beginRow + i, 7).Range.Text = data.Out_price.ToString();

            }
            //���С��8���������һ�м�"----------"
            //if (outScrpList.Count < 8)
            //{
            //    oDoc.Tables[1].Cell(4 + outScrpList.Count, 2).Range.Text = "----------";
            //}

            
            int indexTable = 1;
            //���һҳ�зŲ��¾�ִ���������
            if (outScrpList.Count > pageCount)
            {

                //�ڶ������
                indexTable = 2;
                for (int i = pageCount; i < outScrpList.Count; i = i + pageCount)
                {
                    //����һҳ����һ���±��
                    //���Ƶ�һ�����
                    oDoc.Tables[1].Select();
                    oWord.Selection.Copy();
                    //��һҳ
                    object mymissing = System.Reflection.Missing.Value;
                    object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                    oWord.Selection.EndKey(ref myunit, ref mymissing);
                    object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                    oWord.Selection.InsertBreak(ref pBreak);

                    //ճ����һ�����
                    oWord.Selection.Paste();
                    //�������
                    
                    for (int j = 0; j < pageCount ; j++)
                    {
                        if (i + j < outScrpList.Count)
                        {
                            OutScrpInfo data = outScrpList[i + j];
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = data.P_no;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = data.P_name;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = data.Cost_price.ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = data.Unit_price.ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 6).Range.Text = ((decimal)(data.Cost_price * data.Qnt)).ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 7).Range.Text = data.Out_price.ToString();
                        }
                        else
                        {
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 6).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 7).Range.Text = "";
                        }
                    }
                    indexTable++;
                }

                oDoc.Tables[indexTable - 1].Cell(beginRow + outScrpList.Count % pageCount, 2).Range.Text = "----------";
                
            }
            decimal allPrice = 0M;
            decimal allCostPrice = 0M;
            for (int i = 0;  i < outScrpList.Count; i++)
            {
                allPrice = allPrice + outScrpList[i].Out_price;
                allCostPrice = allCostPrice + outScrpList[i].Cost_price * outScrpList[i].Qnt;
            }
            if (outScrpList.Count % pageCount == 0)
            {
                //����һҳ����һ���±��
                //���Ƶ�һ�����
                oDoc.Tables[1].Select();
                oWord.Selection.Copy();
                //��һҳ
                object mymissing = System.Reflection.Missing.Value;
                object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                oWord.Selection.EndKey(ref myunit, ref mymissing);
                object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                oWord.Selection.InsertBreak(ref pBreak);

                //ճ����һ�����
                oWord.Selection.Paste();
                if (outScrpList.Count == pageCount)
                    indexTable = indexTable + 1;

                for (int i = 0; i < pageCount; i++)
                {
                    oDoc.Tables[indexTable].Cell(beginRow + i, 1).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 2).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 3).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 4).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 5).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 6).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 7).Range.Text = "";
                }

                oDoc.Tables[indexTable].Cell(beginRow , 2).Range.Text = "----------";
                oDoc.Tables[indexTable].Cell(beginRow , 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[indexTable].Cell(beginRow , 7).Range.Text = "��:" + allPrice.ToString();

                
               
            }
            else if (outScrpList.Count > pageCount)
            {
                indexTable = indexTable - 1;
                oDoc.Tables[indexTable].Cell(beginRow + outScrpList.Count % pageCount, 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[indexTable].Cell(beginRow + outScrpList.Count % pageCount, 7).Range.Text = "��:" + allPrice.ToString();
            }
            else
            {
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 2).Range.Text = "----------";
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 7).Range.Text = "��:" + allPrice.ToString();
            }






        }

        /// <summary>
        /// ���ɳ��ⵥword�ĵ� ����
        /// </summary>
        /// <param name="outScrpList">��������Ʒ����</param>
        /// <param name="outUn">���쵥λ</param>
        /// <param name="vipUn">���ͷ���</param>
        /// <param name="remark">��ע</param>
        /// <param name="outscrpNo">������</param>
        /// <param name="outDate">����ʱ��</param>
        public static void OpenAndWriteWordForOut2(System.ComponentModel.BindingList<OutScrpInfo> outScrpList, string outUn, string vipUn,
            string remark, string outscrpNo, string outDate)
        {
            //������
            System.DateTime now = DateTime.Now;
            string year = now.Date.Year.ToString();
            string month = now.Month.ToString();
            string day = now.Day.ToString();

            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            //��ʾword�ĵ�
            oWord.Visible = true;
            //ȡ��word�ļ�ģ��
            object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\���ⵥ����.doc";
            //����ģ������һ�����ĵ����൱�����Ϊ
            oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                            ref oMissing, ref oMissing);
            //�������������е��ı�

            

            string[] xyOutDate = ConfigurationManager.AppSettings["out_word_2_outDate"].ToString().Trim().Split(',');
            int xOutDate = Int32.Parse(xyOutDate[0]);
            int yOutDate = Int32.Parse(xyOutDate[1]);
            oDoc.Tables[1].Cell(xOutDate, yOutDate).Range.Text = year + "�� " + month + " �� " + day + " �� ";
            //���쵥λ
            string[] xyOutOu = ConfigurationManager.AppSettings["out_word_2_outOu"].ToString().Trim().Split(',');
            int xOutOu = Int32.Parse(xyOutOu[0]);
            int yOutOu = Int32.Parse(xyOutOu[1]);
            oDoc.Tables[1].Cell(xOutOu, yOutOu).Range.Text = outUn;

            //���ͷ���
            string[] xyVipOu = ConfigurationManager.AppSettings["out_word_2_vipOu"].ToString().Trim().Split(',');
            int xVipOu = Int32.Parse(xyVipOu[0]);
            int yVipOu = Int32.Parse(xyVipOu[1]);
            oDoc.Tables[1].Cell(xVipOu, yVipOu).Range.Text = vipUn;

            //������  ---===
            string[] xyOutscrpno = ConfigurationManager.AppSettings["out_word_2_outscrpno"].ToString().Trim().Split(',');
            int xOutscrpno = Int32.Parse(xyOutscrpno[0]);
            int yOutscrpno = Int32.Parse(xyOutscrpno[1]);
            oDoc.Tables[1].Cell(xOutscrpno, yOutscrpno).Range.Text = outscrpNo;

            //��ע
            string[] xyRemark = ConfigurationManager.AppSettings["out_word_2_remark"].ToString().Trim().Split(',');
            int xRemark = Int32.Parse(xyRemark[0]);
            int yRemark = Int32.Parse(xyRemark[1]);
            oDoc.Tables[1].Cell(xRemark, yRemark).Range.Text = remark;


            //ÿҳ��ʾ������Ʒ��
            int pageCount = Int32.Parse(ConfigurationManager.AppSettings["out_word_2_pageCount"].ToString().Trim());
            //��ʼ��
            int beginRow = Int32.Parse(ConfigurationManager.AppSettings["out_word_2_beginRow"].ToString().Trim());

            //����Ʒ����  outScrpList
            for (int i = 0; i < pageCount && i < outScrpList.Count; i++)
            {
                OutScrpInfo data = outScrpList[i];
                oDoc.Tables[1].Cell(beginRow + i, 1).Range.Text = data.P_no;
                oDoc.Tables[1].Cell(beginRow + i, 2).Range.Text = data.P_name;
                oDoc.Tables[1].Cell(beginRow + i, 3).Range.Text = (data.Unit_price).ToString();
                oDoc.Tables[1].Cell(beginRow + i, 4).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                oDoc.Tables[1].Cell(beginRow + i, 5).Range.Text = data.Out_price.ToString();

            }
            //���С��8���������һ�м�"----------"
            //if (outScrpList.Count < 8)
            //{
            //    oDoc.Tables[1].Cell(4 + outScrpList.Count, 2).Range.Text = "----------";
            //}


            int indexTable = 1;
            //���һҳ�зŲ��¾�ִ���������
            if (outScrpList.Count > pageCount)
            {

                //�ڶ������
                indexTable = 2;
                for (int i = pageCount; i < outScrpList.Count; i = i + pageCount)
                {
                    //����һҳ����һ���±��
                    //���Ƶ�һ�����
                    oDoc.Tables[1].Select();
                    oWord.Selection.Copy();
                    //��һҳ
                    object mymissing = System.Reflection.Missing.Value;
                    object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                    oWord.Selection.EndKey(ref myunit, ref mymissing);
                    object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                    oWord.Selection.InsertBreak(ref pBreak);

                    //ճ����һ�����
                    oWord.Selection.Paste();
                    //�������

                    for (int j = 0; j < pageCount; j++)
                    {
                        if (i + j < outScrpList.Count)
                        {
                            OutScrpInfo data = outScrpList[i + j];
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = data.P_no;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = data.P_name;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = (data.Unit_price).ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = data.Out_price.ToString();
                        }
                        else
                        {
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = "";
                        }
                    }
                    indexTable++;
                }

                oDoc.Tables[indexTable - 1].Cell(beginRow + outScrpList.Count % pageCount, 2).Range.Text = "----------";

            }
            decimal allPrice = 0M;
            decimal allCostPrice = 0M;
            int allQnt = 0;
            for (int i = 0; i < outScrpList.Count; i++)
            {
                allPrice = allPrice + outScrpList[i].Out_price;
                allCostPrice = allCostPrice + outScrpList[i].Cost_price * outScrpList[i].Qnt;
                allQnt = allQnt + outScrpList[i].Qnt;
            }
            if (outScrpList.Count % pageCount == 0)
            {
                //����һҳ����һ���±��
                //���Ƶ�һ�����
                oDoc.Tables[1].Select();
                oWord.Selection.Copy();
                //��һҳ
                object mymissing = System.Reflection.Missing.Value;
                object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                oWord.Selection.EndKey(ref myunit, ref mymissing);
                object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                oWord.Selection.InsertBreak(ref pBreak);

                //ճ����һ�����
                oWord.Selection.Paste();
                if (outScrpList.Count == pageCount)
                    indexTable = indexTable + 1;

                for (int i = 0; i < pageCount; i++)
                {
                    oDoc.Tables[indexTable].Cell(beginRow + i, 1).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 2).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 3).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 4).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 5).Range.Text = "";
                }

                oDoc.Tables[indexTable].Cell(beginRow, 2).Range.Text = "----------";
                oDoc.Tables[indexTable].Cell(beginRow, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[indexTable].Cell(beginRow, 5).Range.Text = "��:" + allPrice.ToString();



            }
            else if (outScrpList.Count > pageCount)
            {
                indexTable = indexTable - 1;
                oDoc.Tables[indexTable].Cell(beginRow + outScrpList.Count % pageCount, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[indexTable].Cell(beginRow + outScrpList.Count % pageCount, 5).Range.Text = "��:" + allPrice.ToString();
            }
            else
            {
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 2).Range.Text = "----------";
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[1].Cell(beginRow + outScrpList.Count, 5).Range.Text = "��:" + allPrice.ToString();
            }






        }


        /// <summary>
        /// ������ⵥword�ĵ� ���
        /// </summary>
        /// <param name="inScrpList"></param>
        /// <param name="inDate"></param>
        /// <param name="goodsNo"></param>
        /// <param name="in_scrpno"></param>
        public static void OpenAndWriteWordForIn1(System.ComponentModel.BindingList<InScrpInfo> inScrpList, 
            DateTime inDate,string goodsNo,string in_scrpno)
        {
            //������
            //System.DateTime now = DateTime.Now;
            //string year = now.Date.Year.ToString();
            //string month = now.Month.ToString();
            //string day = now.Day.ToString();

            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            //��ʾword�ĵ�
            oWord.Visible = true;
            //ȡ��word�ļ�ģ��
            object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\���ƾ֤���.doc";
            //����ģ������һ�����ĵ����൱�����Ϊ
            oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                            ref oMissing, ref oMissing);
            //�������������е��ı�

            //������
            string[] xyInDate = ConfigurationManager.AppSettings["in_word_1_inDate"].ToString().Trim().Split(',');
            int xInDate = Int32.Parse(xyInDate[0]);
            int yInDate = Int32.Parse(xyInDate[1]);
            oDoc.Tables[1].Cell(xInDate, yInDate).Range.Text = inDate.ToShortDateString();//year + "�� " + month + " �� " + day + " �� ";
            //�������
            string[] xyGoodsNo = ConfigurationManager.AppSettings["in_word_1_goodsNo"].ToString().Trim().Split(',');
            int xGoodsNo = Int32.Parse(xyGoodsNo[0]);
            int yGoodsNo = Int32.Parse(xyGoodsNo[1]);
            oDoc.Tables[1].Cell(xGoodsNo, yGoodsNo).Range.Text = goodsNo;

            //�����  ---===
            string[] xyInscrpno = ConfigurationManager.AppSettings["in_word_1_inscrpno"].ToString().Trim().Split(',');
            int xInscrpno = Int32.Parse(xyInscrpno[0]);
            int yInscrpno = Int32.Parse(xyInscrpno[1]);
            oDoc.Tables[1].Cell(xInscrpno, yInscrpno).Range.Text = in_scrpno;

            //ÿҳ��ʾ������Ʒ��
            int pageCount = Int32.Parse(ConfigurationManager.AppSettings["in_word_1_pageCount"].ToString().Trim());
            //��ʼ��
            int beginRow = Int32.Parse(ConfigurationManager.AppSettings["in_word_1_beginRow"].ToString().Trim());

            //����Ʒ����  inScrpList
            for (int i = 0; i < pageCount && i < inScrpList.Count; i++)
            {
                InScrpInfo data = inScrpList[i];
                oDoc.Tables[1].Cell(beginRow + i, 1).Range.Text = data.P_no;
                oDoc.Tables[1].Cell(beginRow + i, 2).Range.Text = data.P_name;
                oDoc.Tables[1].Cell(beginRow + i, 3).Range.Text = data.Cost_price.ToString();
                oDoc.Tables[1].Cell(beginRow + i, 4).Range.Text = data.Unit_price.ToString();
                oDoc.Tables[1].Cell(beginRow + i, 5).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                oDoc.Tables[1].Cell(beginRow + i, 6).Range.Text = ((decimal)(data.Cost_price * data.Qnt)).ToString();
                oDoc.Tables[1].Cell(beginRow + i, 7).Range.Text = data.In_price.ToString();

            }



            int indexTable = 1;
            //���һҳ�зŲ��¾�ִ���������
            if (inScrpList.Count > pageCount)
            {

                //�ڶ������
                indexTable = 2;
                for (int i = pageCount; i < inScrpList.Count; i = i + pageCount)
                {
                    //����һҳ����һ���±��
                    //���Ƶ�һ�����
                    oDoc.Tables[1].Select();
                    oWord.Selection.Copy();
                    //��һҳ
                    object mymissing = System.Reflection.Missing.Value;
                    object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                    oWord.Selection.EndKey(ref myunit, ref mymissing);
                    object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                    oWord.Selection.InsertBreak(ref pBreak);

                    //ճ����һ�����
                    oWord.Selection.Paste();
                    //�������

                    for (int j = 0; j < pageCount; j++)
                    {
                        if (i + j < inScrpList.Count)
                        {
                            InScrpInfo data = inScrpList[i + j];
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = data.P_no;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = data.P_name;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = data.Cost_price.ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = data.Unit_price.ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = ConvertNumber.convertint(data.Qnt.ToString()) + data.Unit;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 6).Range.Text = ((decimal)(data.Cost_price * data.Qnt)).ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 7).Range.Text = data.In_price.ToString();
                        }
                        else
                        {
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 6).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 7).Range.Text = "";
                        }
                    }
                    indexTable++;
                }

                oDoc.Tables[indexTable - 1].Cell(beginRow + inScrpList.Count % pageCount, 2).Range.Text = "----------";

            }
            decimal allPrice = 0M;
            decimal allCostPrice = 0M;
            for (int i = 0; i < inScrpList.Count; i++)
            {
                allPrice = allPrice + inScrpList[i].In_price;
                allCostPrice = allCostPrice + inScrpList[i].Cost_price * inScrpList[i].Qnt;
            }
            if (inScrpList.Count % pageCount == 0)
            {
                //����һҳ����һ���±��
                //���Ƶ�һ�����
                oDoc.Tables[1].Select();
                oWord.Selection.Copy();
                //��һҳ
                object mymissing = System.Reflection.Missing.Value;
                object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                oWord.Selection.EndKey(ref myunit, ref mymissing);
                object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                oWord.Selection.InsertBreak(ref pBreak);

                //ճ����һ�����
                oWord.Selection.Paste();
                if (inScrpList.Count == pageCount)
                    indexTable = indexTable + 1;

                for (int i = 0; i < pageCount; i++)
                {
                    oDoc.Tables[indexTable].Cell(beginRow + i, 1).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 2).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 3).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 4).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 5).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 6).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 7).Range.Text = "";
                }

                oDoc.Tables[indexTable].Cell(beginRow, 2).Range.Text = "----------";
                oDoc.Tables[indexTable].Cell(beginRow, 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[indexTable].Cell(beginRow, 7).Range.Text = "��:" + allPrice.ToString();



            }
            else if (inScrpList.Count > pageCount)
            {
                indexTable = indexTable - 1;
                oDoc.Tables[indexTable].Cell(beginRow + inScrpList.Count % pageCount, 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[indexTable].Cell(beginRow + inScrpList.Count % pageCount, 7).Range.Text = "��:" + allPrice.ToString();
            }
            else
            {
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 2).Range.Text = "----------";
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 6).Range.Text = "��:" + allCostPrice.ToString();
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 7).Range.Text = "��:" + allPrice.ToString();
            }






        }

        /// <summary>
        /// ������ⵥword�ĵ� ����
        /// </summary>
        /// <param name="inScrpList"></param>
        /// <param name="inDate"></param>
        /// <param name="goodsNo"></param>
        /// <param name="in_scrpno"></param>
        public static void OpenAndWriteWordForIn2(System.ComponentModel.BindingList<InScrpInfo> inScrpList,
            DateTime inDate, string goodsNo, string in_scrpno)
        {
            //������
            //System.DateTime now = DateTime.Now;
            //string year = now.Date.Year.ToString();
            //string month = now.Month.ToString();
            //string day = now.Day.ToString();

            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            //��ʾword�ĵ�
            oWord.Visible = true;
            //ȡ��word�ļ�ģ��
            object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\���ƾ֤����.doc";
            //����ģ������һ�����ĵ����൱�����Ϊ
            oDoc = oWord.Documents.Add(ref fileName, ref oMissing,
                            ref oMissing, ref oMissing);
            //�������������е��ı�

            //������
            string[] xyInDate = ConfigurationManager.AppSettings["in_word_2_inDate"].ToString().Trim().Split(',');
            int xInDate = Int32.Parse(xyInDate[0]);
            int yInDate = Int32.Parse(xyInDate[1]);
            oDoc.Tables[1].Cell(xInDate, yInDate).Range.Text = inDate.ToShortDateString();//year + "�� " + month + " �� " + day + " �� ";
            //�������
            string[] xyGoodsNo = ConfigurationManager.AppSettings["in_word_2_goodsNo"].ToString().Trim().Split(',');
            int xGoodsNo = Int32.Parse(xyGoodsNo[0]);
            int yGoodsNo = Int32.Parse(xyGoodsNo[1]);
            oDoc.Tables[1].Cell(xGoodsNo, yGoodsNo).Range.Text = goodsNo;

            //�����  ---===
            string[] xyInscrpno = ConfigurationManager.AppSettings["in_word_2_inscrpno"].ToString().Trim().Split(',');
            int xInscrpno = Int32.Parse(xyInscrpno[0]);
            int yInscrpno = Int32.Parse(xyInscrpno[1]);
            oDoc.Tables[1].Cell(xInscrpno, yInscrpno).Range.Text = in_scrpno;

            //ÿҳ��ʾ������Ʒ��
            int pageCount = Int32.Parse(ConfigurationManager.AppSettings["in_word_2_pageCount"].ToString().Trim());
            //��ʼ��
            int beginRow = Int32.Parse(ConfigurationManager.AppSettings["in_word_2_beginRow"].ToString().Trim());

            //����Ʒ����  inScrpList
            for (int i = 0; i < pageCount && i < inScrpList.Count; i++)
            {
                InScrpInfo data = inScrpList[i];
                oDoc.Tables[1].Cell(beginRow + i, 1).Range.Text = data.P_no;
                oDoc.Tables[1].Cell(beginRow + i, 2).Range.Text = data.P_name;
                oDoc.Tables[1].Cell(beginRow + i, 3).Range.Text = data.Unit_price.ToString();
                oDoc.Tables[1].Cell(beginRow + i, 4).Range.Text = ConvertNumber.convertint(data.Qnt.ToString().Trim()) + data.Unit;
                oDoc.Tables[1].Cell(beginRow + i, 5).Range.Text = data.In_price.ToString();

            }



            int indexTable = 1;
            //���һҳ�зŲ��¾�ִ���������
            if (inScrpList.Count > pageCount)
            {

                //�ڶ������
                indexTable = 2;
                for (int i = pageCount; i < inScrpList.Count; i = i + pageCount)
                {
                    //����һҳ����һ���±��
                    //���Ƶ�һ�����
                    oDoc.Tables[1].Select();
                    oWord.Selection.Copy();
                    //��һҳ
                    object mymissing = System.Reflection.Missing.Value;
                    object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                    oWord.Selection.EndKey(ref myunit, ref mymissing);
                    object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                    oWord.Selection.InsertBreak(ref pBreak);

                    //ճ����һ�����
                    oWord.Selection.Paste();
                    //�������

                    for (int j = 0; j < pageCount; j++)
                    {
                        if (i + j < inScrpList.Count)
                        {
                            InScrpInfo data = inScrpList[i + j];
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = data.P_no;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = data.P_name;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = data.Unit_price.ToString();
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = ConvertNumber.convertint(data.Qnt.ToString().Trim()) + data.Unit;
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = data.In_price.ToString();
                        }
                        else
                        {
                            oDoc.Tables[indexTable].Cell(beginRow + j, 1).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 2).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 3).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 4).Range.Text = "";
                            oDoc.Tables[indexTable].Cell(beginRow + j, 5).Range.Text = "";

                        }
                    }
                    indexTable++;
                }

                oDoc.Tables[indexTable - 1].Cell(beginRow + inScrpList.Count % pageCount, 2).Range.Text = "----------";

            }
            decimal allPrice = 0M;
            decimal allCostPrice = 0M;
            int allQnt = 0;
            for (int i = 0; i < inScrpList.Count; i++)
            {
                allPrice = allPrice + inScrpList[i].In_price;
                allCostPrice = allCostPrice + inScrpList[i].Cost_price * inScrpList[i].Qnt;
                allQnt = allQnt + inScrpList[i].Qnt;
            }
            if (inScrpList.Count % pageCount == 0)
            {
                //����һҳ����һ���±��
                //���Ƶ�һ�����
                oDoc.Tables[1].Select();
                oWord.Selection.Copy();
                //��һҳ
                object mymissing = System.Reflection.Missing.Value;
                object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
                oWord.Selection.EndKey(ref myunit, ref mymissing);
                object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
                oWord.Selection.InsertBreak(ref pBreak);

                //ճ����һ�����
                oWord.Selection.Paste();
                if (inScrpList.Count == pageCount)
                    indexTable = indexTable + 1;

                for (int i = 0; i < pageCount; i++)
                {
                    oDoc.Tables[indexTable].Cell(beginRow + i, 1).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 2).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 3).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 4).Range.Text = "";
                    oDoc.Tables[indexTable].Cell(beginRow + i, 5).Range.Text = "";

                }

                oDoc.Tables[indexTable].Cell(beginRow, 2).Range.Text = "----------";
                oDoc.Tables[indexTable].Cell(beginRow, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[indexTable].Cell(beginRow, 5).Range.Text = "��:" + allPrice.ToString();



            }
            else if (inScrpList.Count > pageCount)
            {
                indexTable = indexTable - 1;
                oDoc.Tables[indexTable].Cell(beginRow + inScrpList.Count % pageCount, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[indexTable].Cell(beginRow + inScrpList.Count % pageCount, 5).Range.Text = "��:" + allPrice.ToString();
            }
            else
            {
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 2).Range.Text = "----------";
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 4).Range.Text = "��:" + allQnt.ToString();
                oDoc.Tables[1].Cell(beginRow + inScrpList.Count, 5).Range.Text = "��:" + allPrice.ToString();
            }






        }



        //public static Microsoft.Office.Interop.Word._Application oWord;
        //public static Microsoft.Office.Interop.Word._Document oDoc;


        ///// <summary>
        ///// �����汨��
        ///// </summary>
        ///// <param name="tempword"></param>
        ///// <param name="dataTable"></param>
        ///// <param name="title"></param>
        ///// <param name="sumQnt"></param>
        ///// <param name="sumPrice"></param>
        ///// <param name="sumInQnt"></param>
        ///// <param name="sumInPrice"></param>
        ///// <param name="sumOutQnt"></param>
        ///// <param name="sumOutPrice"></param>
        ///// <param name="progressBar1"></param>
        //public static void ToWordFormInOutDataTable(string tempword, DataTable dataTable, string title, string sumQnt, string sumPrice, string sumInQnt,
        //    string sumInPrice, string sumOutQnt, string sumOutPrice, ProgressBar progressBar1)
        //{
        //    Quit();
        //    object oMissing = System.Reflection.Missing.Value;
        //    oWord = new Microsoft.Office.Interop.Word.Application();
        //    //ȡ��word�ļ�ģ��
        //    object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\" + tempword;
        //    //����ģ������һ�����ĵ����൱�����Ϊ
        //    oDoc = oWord.Documents.Add(ref fileName, ref oMissing, ref oMissing, ref oMissing);
        //    //�������������е��ı�

        //    //����
        //    oDoc.Tables[1].Cell(1, 1).Range.Text = title;

        //    //���������
        //    oDoc.Tables[1].Cell(2, 2).Range.Text = sumInQnt;
        //    //����ܽ��
        //    oDoc.Tables[1].Cell(2, 6).Range.Text = sumInPrice;
        //    //����������
        //    oDoc.Tables[1].Cell(3, 2).Range.Text = sumOutQnt;
        //    //�����ܽ��
        //    oDoc.Tables[1].Cell(3, 6).Range.Text = sumOutPrice;
        //    //���������
        //    oDoc.Tables[1].Cell(4, 2).Range.Text = sumQnt;
        //    //����ܽ��
        //    oDoc.Tables[1].Cell(4, 6).Range.Text = sumPrice;

        //    //����
        //    oDoc.Tables[1].Cell(4, 9).Range.Text = DateTime.Now.ToShortDateString();

        //    FillWordTableFromList(dataTable, oDoc, progressBar1);
        //    oWord.Visible = true;

        //    oDoc = null;
        //    oWord = null;
        //}

        ///// <summary>
        ///// �����ͳ�Ʊ���
        ///// </summary>
        ///// <param name="tempword"></param>
        ///// <param name="dataTable"></param>
        ///// <param name="title"></param>
        ///// <param name="sumQnt"></param>
        ///// <param name="sumPrice"></param>
        ///// <param name="sumInQnt"></param>
        ///// <param name="sumInPrice"></param>
        ///// <param name="sumOutQnt"></param>
        ///// <param name="sumOutPrice"></param>
        ///// <param name="progressBar1"></param>
        //public static void ToWordFormInOutDataTable(string tempword, DataTable dataTable, string title, string sumInQnt,
        //    string sumInPrice, string sumOutQnt, string sumOutPrice, ProgressBar progressBar1)
        //{
        //    Quit();
        //    object oMissing = System.Reflection.Missing.Value;
        //    oWord = new Microsoft.Office.Interop.Word.Application();
        //    //ȡ��word�ļ�ģ��
        //    object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\" + tempword;
        //    //����ģ������һ�����ĵ����൱�����Ϊ
        //    oDoc = oWord.Documents.Add(ref fileName, ref oMissing, ref oMissing, ref oMissing);
        //    //�������������е��ı�

        //    //����
        //    oDoc.Tables[1].Cell(1, 1).Range.Text = title;

        //    //���������
        //    oDoc.Tables[1].Cell(2, 2).Range.Text = sumInQnt;
        //    //����ܽ��
        //    oDoc.Tables[1].Cell(2, 4).Range.Text = sumInPrice;
        //    //����������
        //    oDoc.Tables[1].Cell(3, 2).Range.Text = sumOutQnt;
        //    //�����ܽ��
        //    oDoc.Tables[1].Cell(3, 4).Range.Text = sumOutPrice;

        //    //����
        //    oDoc.Tables[1].Cell(3, 8).Range.Text = DateTime.Now.ToShortDateString();

        //    FillWordTableFromList(dataTable, oDoc, progressBar1);
        //    oWord.Visible = true;

        //    oDoc = null;
        //    oWord = null;
        //}


        ///// <summary>
        ///// ���ͳ�Ʊ���
        ///// </summary>
        ///// <param name="tempword"></param>
        ///// <param name="dataTable"></param>
        ///// <param name="title"></param>
        ///// <param name="sumInQnt"></param>
        ///// <param name="sumInPrice"></param>
        ///// <param name="btext"></param>
        ///// <param name="progressBar1"></param>
        //public static void ToWordFormInReportDataTable(string tempword, DataTable dataTable, string title, string sumInQnt,
        //    string sumInPrice, string btext,ProgressBar progressBar1)
        //{
        //    Quit();
        //    object oMissing = System.Reflection.Missing.Value;
        //    oWord = new Microsoft.Office.Interop.Word.Application();
        //    //ȡ��word�ļ�ģ��
        //    object fileName = System.Windows.Forms.Application.StartupPath + "\\word\\" + tempword;
        //    //����ģ������һ�����ĵ����൱�����Ϊ
        //    oDoc = oWord.Documents.Add(ref fileName, ref oMissing, ref oMissing, ref oMissing);
        //    //�������������е��ı�

        //    //����
        //    oDoc.Tables[1].Cell(1, 1).Range.Text = title;

        //    //���������
        //    oDoc.Tables[1].Cell(2, 2).Range.Text = sumInQnt;
        //    //����ܽ��
        //    oDoc.Tables[1].Cell(2, 4).Range.Text = sumInPrice;


        //    //����
        //    oDoc.Tables[1].Cell(2, 6).Range.Text = DateTime.Now.ToShortDateString();

        //    //����ܽ��
        //    oDoc.Tables[1].Cell(3, 1).Range.Text = "����:" + btext;

        //    FillWordTableFromList(dataTable, oDoc, progressBar1);
        //    oWord.Visible = true;

        //    oDoc = null;
        //    oWord = null;
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="list"></param>
        ///// <param name="oDoc"></param>
        //public static void FillWordTableFromList(List<List<string>> list, Microsoft.Office.Interop.Word._Document oDoc)
        //{
        //    object oMissing = System.Reflection.Missing.Value;
        //    for (int i = 0; i < list.Count; i++)
        //    {

        //        for (int j = 0; j < list[0].Count; j++)
        //        {

        //            oDoc.Tables[2].Cell(2 + i, j + 1).Range.Text = list[i][j].ToString();
        //        }
        //        oDoc.Tables[2].Rows.Add(ref oMissing);
        //        //oDoc.Tables[1].RangRows[i].Cells.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    }

        //    //oDoc.Tables[1].Rows[i].Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //}



        //public static void FillWordTableFromList(DataTable dataTable, Microsoft.Office.Interop.Word._Document oDoc, ProgressBar progressBar1)
        //{
        //    object oMissing = System.Reflection.Missing.Value;
        //    progressBar1.Value = 0;
        //    progressBar1.Minimum = 0;
        //    progressBar1.Maximum = dataTable.Rows.Count;
        //    progressBar1.Step = 1;
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {

        //        for (int j = 0; j < dataTable.Columns.Count; j++)
        //        {

        //            oDoc.Tables[2].Cell(2 + i, j + 1).Range.Text = dataTable.Rows[i][j].ToString();
        //        }
        //        oDoc.Tables[2].Rows.Add(ref oMissing);
        //        progressBar1.PerformStep();
        //        //oDoc.Tables[1].RangRows[i].Cells.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    }

        //    //oDoc.Tables[1].Rows[i].Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical].LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //    oDoc.Tables[2].Columns.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical].LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;

        //}







        ///**/
        ///// <summary>
        ///// �˳�
        ///// </summary>
        //public static void Quit()
        //{
        //    GCForQuit();
        //    GC.Collect();
        //    foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
        //    {
        //        if (p.ProcessName.ToUpper() == "WINWORD")
        //        {
        //            p.Kill();
        //        }
        //    }
        //}

        ///**/
        ///// <summary>
        ///// ����������ʱ��������������л����ڵ�ǰ������WORD�Ľ���
        ///// �������ϣ���������һ���������ڵ���GC�ſ������������������ǰ�Ľ���
        ///// </summary>
        //private static void GCForQuit()
        //{
        //    object missing = System.Reflection.Missing.Value;
        //    //oWord.Application.Quit(ref missing, ref missing, ref missing);
        //    if (oDoc != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oDoc);
        //        oDoc = null;
        //    }
        //    if (oWord != null)
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
        //        oWord = null;
        //    }
        //    GC.Collect();
        //}








    }
}
