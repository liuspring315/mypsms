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
    /// 操作报表控件的公共类
    /// </summary>
    class ReportUtil
    {

        /// <summary>
        /// 报表表头字体
        /// </summary>
        //public static Font hfont = new Font("黑体", 12.0F, FontStyle.Bold|FontStyle.Regular);

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
        /// 为报表控件填充数据
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
        /// 为报表控件填充数据
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
        /// 为报表控件填充数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">对齐方式值（0：居中；1靠左；2靠右；大于2按0处理）</param>
        //public static void setDataForAxlgxgrid(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid, int alignment)
        //{
        //    setDataForAxlgxgrid(list, axlgxgrid);
        //    setLAlignmentForAxlgxgrid(axlgxgrid, alignment);
        //}



        /// <summary>
        /// 为报表控件填充数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">对齐方式值（0：居中；1靠左；2靠右；大于2按0处理</param>
        //public static void setDataForAxlgxgridAddCount(IList<IList<string>> list, AxLgxgridV10.Axlgxgrid axlgxgrid, int alignment)
        //{

        //    setDataForAxlgxgridAddCount(list, axlgxgrid);
        //    setLAlignmentForAxlgxgrid(axlgxgrid, alignment);
        //}



        /// <summary>
        /// 设置单元格水平对其方式
        /// </summary>
        /// <param name="axlgxgrid"></param>
        /// <param name="alignment">对齐方式值（0：居中；1靠左；2靠右；大于2按0处理）</param>
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
        /// 打印报表控件中数据
        /// </summary>
        /// <param name="axlgxgrid"></param>
        /// <param name="title">标题</param>
        /// <param name="Ltext">左边页眉文本</param>
        /// <param name="Btext">居中页眉文本</param>
        /// <param name="Rtext">右边页眉文本</param>
        //public static void setPrintInfoForAxlgxgrid(AxLgxgridV10.Axlgxgrid axlgxgrid,string title,string Ltext,string Btext,string Rtext)
        //{
        //    LgxgridV10.PrinterInfos pr;
        //    pr = axlgxgrid.PrinterInfoGet();

        //    pr.TopSy = 2;   //cm
        //    pr.LeftSx = 2;

        //    pr.TitleText = title;
        //    pr.TitleFont.Size = 25;
        //    pr.TitleFont.Name = "隶书";
        //    pr.TitleFont.Bold = true;

            

        //   // pr.ColorOrBlack = 1;

        //    pr.MainFont.Size = 10;
        //    pr.MainFont.Name = "黑体";
        //    pr.MainFont.Bold = false;

        //    pr.TableHeadFont.Size = 10;
        //    pr.TableHeadFont.Name = "黑体";
        //    pr.TableHeadFont.Bold = true;


        //    pr.Ltext = Ltext;
        //    pr.Btext = Btext;
        //    pr.Rtext = Rtext;

        //    pr.TableTop = pr.TableTop - 0.6;
        //    pr.ULtext = "";
        //    pr.UBtext = "第 &[页码] 页  共 &[总页数] 页";
        //    pr.URtest = "";
        //    pr.TellText = "";
        //    //(char)13+"\n"为插入一个回车换行符，相当于VB的vbCrLf
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
        ///// 移除报表列表中的数据
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
        ///// 遍历所有行，求指定列数据的和
        ///// </summary>
        ///// <param name="axlgxgrid">报表控件对象</param>
        ///// <param name="col">列号 从1开始</param>
        ///// <param name="type">数据类型，1，decimal，2，int，默认decimal</param>
        ///// <returns>string 指定列数据的和的字符串类型</returns>
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
        /// 遍历所有行，求指定列数据的和
        /// </summary>
        /// <param name="DataTable">DataTable</param>
        /// <param name="col">列号 从0开始</param>
        /// <param name="type">数据类型，1，decimal，2，int，默认decimal</param>
        /// <returns>string 指定列数据的和的字符串类型</returns>
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
                scrpNo = scrpNo + bllPreInfo.GetDataTableBySql(sql1).Rows[0][0].ToString().Substring(5) + " 至 ";
            }
            else
            {
                scrpNo = scrpNo + "0 至 ";
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
