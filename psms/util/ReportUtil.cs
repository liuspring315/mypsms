using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

namespace psms.util
{
    /// <summary>
    /// ��������ؼ��Ĺ�����
    /// </summary>
    class ReportUtil
    {

        /// <summary>
        /// �����ͷ����
        /// </summary>
        //public static Font hfont = new Font("����", 12.0F, FontStyle.Bold|FontStyle.Regular);

        public static void setYearList(ComboBox comboBoxYear)
        {
            for (int i = 2008; i < 2020; i++)
            {
                comboBoxYear.Items.Add(i.ToString());
            }
            comboBoxYear.SelectedItem = comboBoxYear.Items[comboBoxYear.FindString(DateTime.Now.Year.ToString())];
        }

        public static void setMonthList(ComboBox comboBoxMonth)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (i < 10)
                {
                    comboBoxMonth.Items.Add("0" + i.ToString());
                }
                else
                {
                    comboBoxMonth.Items.Add(i.ToString());
                }
            }
            int nowMonth = DateTime.Now.Month;
            comboBoxMonth.SelectedItem = comboBoxMonth.Items[comboBoxMonth.FindString(nowMonth<10?"0"+nowMonth.ToString():nowMonth.ToString())];
        }


        /// <summary>
        /// Ϊ����ؼ��������
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        //public static void setDataForAxlgxgrid(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid)
        //{
        //    axlgxgrid.clear();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        IList<string> data = list[i];
        //        for (int j = 0; j < data.Count; j++)
        //        {
        //            axlgxgrid.SetData(i + 1, j + 1, data[j].Trim());
        //            axlgxgrid.SetFormatTxt(i + 1, j + 1, ">");
        //        }

        //    }
        //}


        /// <summary>
        /// Ϊ����ؼ��������
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        //public static void setDataForAxlgxgridAddCount(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid)
        //{
        //    axlgxgrid.clear();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        axlgxgrid.SetData(i + 1, 1, (i + 1).ToString());
        //        axlgxgrid.SetFormatTxt(i + 1, 1, "<");
        //        IList<string> data = list[i];
        //        for (int j = 0; j < data.Count; j++)
        //        {
        //            axlgxgrid.SetData(i + 1, j + 2, data[j].Trim());
        //            axlgxgrid.SetFormatTxt(i + 1, j + 2, "<");
        //        }

        //    }
        //}


        /// <summary>
        /// Ϊ����ؼ��������
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">���뷽ʽֵ��0�����У�1����2���ң�����2��0����</param>
        //public static void setDataForAxlgxgrid(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid, int alignment)
        //{
        //    setDataForAxlgxgrid(list, axlgxgrid);
        //    setLAlignmentForAxlgxgrid(axlgxgrid, alignment);
        //}



        /// <summary>
        /// Ϊ����ؼ��������
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">���뷽ʽֵ��0�����У�1����2���ң�����2��0����</param>
        //public static void setDataForAxlgxgridAddCount(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid, int alignment)
        //{

        //    setDataForAxlgxgridAddCount(list, axlgxgrid);
        //    setLAlignmentForAxlgxgrid(axlgxgrid, alignment);
        //}



        /// <summary>
        /// ���õ�Ԫ��ˮƽ���䷽ʽ
        /// </summary>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">���뷽ʽֵ��0�����У�1����2���ң�����2��0����</param>
        //public static void setLAlignmentForAxlgxgrid(AxLgxgridV10.Axlgxgrid axlgxgrid,int alignment)
        //{
        //    for (int i = 1; i <= axlgxgrid.rows; i++)
        //    {
        //        for (int j = 1; j <= axlgxgrid.lists; j++)
        //        {
        //            if (axlgxgrid.GetData(i, j) != null)
        //            {
        //                if (isNumber(axlgxgrid.GetData(i, j).Trim()))
        //                {
        //                    axlgxgrid.SetLAlignment(i, j, 2);
        //                }
        //                else
        //                {
        //                    axlgxgrid.SetLAlignment(i, j, 1);
        //                }
        //            }
                    
        //        }
        //    }
        //}


        /// <summary>
        /// ��ӡ����ؼ�������
        /// </summary>
        /// <param name="axlgxgrid"></param>
        /// <param name="title">����</param>
        /// <param name="Ltext">���ҳü�ı�</param>
        /// <param name="Btext">����ҳü�ı�</param>
        /// <param name="Rtext">�ұ�ҳü�ı�</param>
        //public static void setPrintInfoForAxlgxgrid(AxLgxgridV10.Axlgxgrid axlgxgrid,string title,string Ltext,string Btext,string Rtext)
        //{
        //    LgxgridV10.PrinterInfos pr;
        //    pr = axlgxgrid.PrinterInfoGet();

        //    pr.TopSy = 2;   //cm
        //    pr.LeftSx = 2;

        //    pr.TitleText = title;
        //    pr.TitleFont.Size = 25;
        //    pr.TitleFont.Name = "����";
        //    pr.TitleFont.Bold = true;

            

        //   // pr.ColorOrBlack = 1;

        //    pr.MainFont.Size = 10;
        //    pr.MainFont.Name = "����";
        //    pr.MainFont.Bold = false;

        //    pr.TableHeadFont.Size = 10;
        //    pr.TableHeadFont.Name = "����";
        //    pr.TableHeadFont.Bold = true;


        //    pr.Ltext = Ltext;
        //    pr.Btext = Btext;
        //    pr.Rtext = Rtext;

        //    pr.TableTop = pr.TableTop - 0.6;
        //    pr.ULtext = "";
        //    pr.UBtext = "�� &[ҳ��] ҳ  �� &[��ҳ��] ҳ";
        //    pr.URtest = "";
        //    pr.TellText = "";
        //    //(char)13+"\n"Ϊ����һ���س����з����൱��VB��vbCrLf
        //    pr.ListScale = 1.7;
        //    pr.RowH = 350;
        //    pr.LineWidth = 4;

        //    pr.ZoomScale = 1;
        //    //pr.SheetAspect = LgxgridV10.pshat.vbPRORPortrait;
        //    //pr.SheetAspect = LgxgridV10.pshat.vbPRORLandscape;
        //    axlgxgrid.SetPrintInfo("SheetAspect", 2);
        //    axlgxgrid.PrinterInfoSet(pr);
        //    axlgxgrid.SetPrintShow();
        //}


        ///// <summary>
        ///// �Ƴ������б��е�����
        ///// </summary>
        ///// <param name="axlgxgrid"></param>
        //public static void removeDataForAxlgxgrid(AxLgxgridV10.Axlgxgrid axlgxgrid)
        //{
        //    axlgxgrid.clear();
        //    while (axlgxgrid.lists != 0)
        //    {
        //        axlgxgrid.DelList();
        //    }
        //}


        ///// <summary>
        ///// ���������У���ָ�������ݵĺ�
        ///// </summary>
        ///// <param name="axlgxgrid">����ؼ�����</param>
        ///// <param name="col">�к� ��1��ʼ</param>
        ///// <param name="type">�������ͣ�1��decimal��2��int��Ĭ��decimal</param>
        ///// <returns>string ָ�������ݵĺ͵��ַ�������</returns>
        //public static string getDataFromAxlgxgrid(AxLgxgridV10.Axlgxgrid axlgxgrid,int col,int type)
        //{
        //    string _sum = "0";
        //    try
        //    {
        //        if (type == 2)
        //        {
        //            int isum = 0;

        //            for (int i = 1; i <= axlgxgrid.rows; i++)
        //            {
        //                if (axlgxgrid.GetData(i, col) != null && axlgxgrid.GetData(i, col).Trim() != "")
        //                    isum = isum + int.Parse(axlgxgrid.GetData(i, col).Trim());
        //            }
        //            _sum = isum.ToString();
        //        }
        //        else
        //        {
        //            decimal dsum = 0.00M;

        //            for (int i = 1; i <= axlgxgrid.rows; i++)
        //            {
        //                if (axlgxgrid.GetData(i, col) != null && axlgxgrid.GetData(i, col).Trim() != "")
        //                    dsum = dsum + decimal.Parse(axlgxgrid.GetData(i, col).Trim());
        //            }
        //            _sum = dsum.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriteLog(ex.ToString());
        //    }
        //    return _sum;
        //}


        /// <summary>
        /// ���������У���ָ�������ݵĺ�
        /// </summary>
        /// <param name="DataTable">DataTable</param>
        /// <param name="col">�к� ��0��ʼ</param>
        /// <param name="type">�������ͣ�1��decimal��2��int��Ĭ��decimal</param>
        /// <returns>string ָ�������ݵĺ͵��ַ�������</returns>
        public static string getDataFromDataTable(DataTable dataTable, int col, int type)
        {
            string _sum = "0";
            try
            {
                if (type == 2)
                {
                    int isum = 0;

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        isum = isum + int.Parse(dataTable.Rows[i][col].ToString().Trim());
                    }
                    _sum = isum.ToString();
                }
                else
                {
                    decimal dsum = 0.00M;

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        dsum = dsum + decimal.Parse(dataTable.Rows[i][col].ToString().Trim());
                    }
                    _sum = dsum.ToString();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
            }
            return _sum;
        }



        public static bool isNumber(string str)
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if(r.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql1"></param>
        /// <param name="sql2"></param>
        /// <returns></returns>
        public static string getScrpNoStr(string sql1,string sql2)
        {
            BLL.PreInfo bllPreInfo = new BLL.PreInfo();
            string scrpNo = "";
            DataTable dt1 = bllPreInfo.GetDataTableBySql(sql1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                scrpNo = scrpNo + bllPreInfo.GetDataTableBySql(sql1).Rows[0][0].ToString().Substring(5) + " �� ";
            }
            else
            {
                scrpNo = scrpNo + "0 �� ";
            }
            DataTable dt2 = bllPreInfo.GetDataTableBySql(sql2);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                scrpNo = scrpNo + bllPreInfo.GetDataTableBySql(sql2).Rows[0][0].ToString().Substring(5);
            }
            else
            {
                scrpNo = scrpNo + "0";
            }
            return scrpNo;
        }



    }
}
