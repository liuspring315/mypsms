using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using cfg = System.Configuration;

namespace psms.util
{
	/// <summary>
	/// 功能说明：套用模板输出Microsoft.Office.Interop.Excel，并对数据进行分页
	/// 作    者：Lingyun_k
	/// 创建日期：2005-7-12
	/// </summary>
	public class ExcelHelper
	{
//        protected string templetFile = null;
//        protected string outputFile = null;
//        protected object missing = Missing.Value;

//        /// <summary>
//        /// 构造函数，需指定模板文件和输出文件完整路径
//        /// </summary>
//        /// <param name="templetFilePath">Microsoft.Office.Interop.Excel模板文件路径</param>
//        /// <param name="outputFilePath">输出Microsoft.Office.Interop.Excel文件路径</param>
//        public ExcelHelper(string templetFilePath,string outputFilePath)
//        {
//            if(templetFilePath == null)
//                throw new Exception("Microsoft.Office.Interop.Excel模板文件路径不能为空！");

//            if(outputFilePath == null)
//                throw new Exception("输出Microsoft.Office.Interop.Excel文件路径不能为空！");

//            if(!File.Exists(templetFilePath))
//                throw new Exception("指定路径的Microsoft.Office.Interop.Excel模板文件不存在！");

//            this.templetFile = templetFilePath;
//            this.outputFile = outputFilePath;

//        }




///// <summary>
///// 
///// </summary>
//        public void ExcelCollect(System.Data.DataTable dt, int rows, int top, int left, string sheetPrefixName)
//        {
//            DataTableToExcel(dt,rows,top,left,sheetPrefixName);
//            GC.Collect();
//        } 





//        /// <summary>
//        /// 将DataTable数据写入Microsoft.Office.Interop.Excel文件（套用模板并分页）
//        /// </summary>
//        /// <param name="dt">DataTable</param>
//        /// <param name="rows">每个WorkSheet写入多少行数据</param>
//        /// <param name="top">行索引</param>
//        /// <param name="left">列索引</param>
//        /// <param name="sheetPrefixName">WorkSheet前缀名，比如：前缀名为“Sheet”，那么WorkSheet名称依次为“Sheet-1，Sheet-2...”</param>
//        public void DataTableToExcel(System.Data.DataTable dt,int rows,int top,int left,string sheetPrefixName)
//        {
//            int rowCount = dt.Rows.Count;		//源DataTable行数
//            int colCount = dt.Columns.Count;	//源DataTable列数
//            int sheetCount = this.GetSheetCount(rowCount,rows);	//WorkSheet个数
//            DateTime beforeTime;	
//            DateTime afterTime;
			
//            if(sheetPrefixName == null || sheetPrefixName.Trim() == "")
//                sheetPrefixName = "Sheet";

//            //创建一个Application对象并使其可见
//            beforeTime = DateTime.Now;
//            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
//            app.Visible = true;
//            afterTime = DateTime.Now;

//            //打开模板文件，得到WorkBook对象
//            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(templetFile, missing, missing, missing, missing, missing,
//                                missing, missing, missing, missing, missing, missing, missing, missing, missing);

//            //得到WorkSheet对象
//            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

//            //复制sheetCount-1个WorkSheet对象
//            //for(int i=1;i<sheetCount;i++)
//            //{
//            //    ((Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i)).Copy(missing,workBook.Worksheets[i]);
//            //}

//            for (int i = 0; i < rowCount; i++)
//            {
//                for (int j = 0; j < colCount; j++)
//                {
//                    if (workSheet.Cells[top + i, left + j] != null)
//                    {
//                        workSheet.Cells[top + i, left + j] = dt.Rows[i][j].ToString();
//                    }
                    
//                }
//            }
            

//            #region 将源DataTable数据写入Microsoft.Office.Interop.Excel
//            //for(int i=1;i<=sheetCount;i++)
//            //{
//            //    int startRow = (i - 1) * rows;		//记录起始行索引
//            //    int endRow = i * rows;			//记录结束行索引

//            //    //若是最后一个WorkSheet，那么记录结束行索引为源DataTable行数
//            //    if(i == sheetCount)
//            //        endRow = rowCount;

//            //    //获取要写入数据的WorkSheet对象，并重命名
//            //    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i);
//            //    sheet.Name = sheetPrefixName + "-" + i.ToString();

//            //    //将dt中的数据写入WorkSheet
//            //    for(int j=0;j<endRow-startRow;j++)
//            //    {
//            //        for(int k=0;k<colCount;k++)
//            //        {
//            //            sheet.Cells[top + j,left + k] = dt.Rows[startRow + j][k].ToString();
//            //        }
//            //    }

//            //    //写文本框数据
//            //    Microsoft.Office.Interop.Excel.TextBox txtAuthor = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtAuthor");
//            //    Microsoft.Office.Interop.Excel.TextBox txtDate = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtDate");
//            //    Microsoft.Office.Interop.Excel.TextBox txtVersion = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtVersion");

//            //    txtAuthor.Text = "lingyun_k";
//            //    txtDate.Text = DateTime.Now.ToShortDateString();
//            //    txtVersion.Text = "1.0.0.0";
//            //}
//            #endregion

//            //输出Microsoft.Office.Interop.Excel文件并退出
//            try
//            {
//                //workBook.SaveAs(outputFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
//                //workBook.Close(null,null,null);
//                //app.Workbooks.Close();
//                //app.Application.Quit();
//                //app.Quit();

//                //System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
//                //System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
//                //System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

//                //workSheet=null;
//                //workBook=null;
//                //app=null;

//                //GC.Collect();
//            }
//            catch(Exception e)
//            {
//                throw e;
//            }
//            finally
//            {
//                Process[] myProcesses;
//                DateTime startTime;
//                myProcesses = Process.GetProcessesByName("Microsoft.Office.Interop.Excel");

//                //得不到Microsoft.Office.Interop.Excel进程ID，暂时只能判断进程启动时间
//                foreach(Process myProcess in myProcesses)
//                {
//                    startTime = myProcess.StartTime;

//                    if(startTime > beforeTime && startTime < afterTime)
//                    {
//                        myProcess.Kill();
//                    }
//                }
//            }
			
//        }

		
//        /// <summary>
//        /// 获取WorkSheet数量
//        /// </summary>
//        /// <param name="rowCount">记录总行数</param>
//        /// <param name="rows">每WorkSheet行数</param>
//        private int GetSheetCount(int rowCount,int rows)
//        {
//            int n = rowCount % rows;		//余数

//            if(n == 0)
//                return rowCount / rows;
//            else
//                return Convert.ToInt32(rowCount / rows) + 1;
//        }


//        /// <summary>
//        /// 将二维数组数据写入Microsoft.Office.Interop.Excel文件（套用模板并分页）
//        /// </summary>
//        /// <param name="arr">二维数组</param>
//        /// <param name="rows">每个WorkSheet写入多少行数据</param>
//        /// <param name="top">行索引</param>
//        /// <param name="left">列索引</param>
//        /// <param name="sheetPrefixName">WorkSheet前缀名，比如：前缀名为“Sheet”，那么WorkSheet名称依次为“Sheet-1，Sheet-2...”</param>
//        public void ArrayToExcel(string[,] arr,int rows,int top,int left,string sheetPrefixName)
        //{
        //    int rowCount = arr.GetLength(0);		//二维数组行数（一维长度）
        //    int colCount = arr.GetLength(1);	//二维数据列数（二维长度）
        //    int sheetCount = this.GetSheetCount(rowCount,rows);	//WorkSheet个数
        //    DateTime beforeTime;	
        //    DateTime afterTime;
			
        //    if(sheetPrefixName == null || sheetPrefixName.Trim() == "")
        //        sheetPrefixName = "Sheet";

        //    //创建一个Application对象并使其可见
        //    beforeTime = DateTime.Now;
        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    app.Visible = true;
        //    afterTime = DateTime.Now;

        //    //打开模板文件，得到WorkBook对象
        //    Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(templetFile,missing,missing,missing,missing,missing,
        //        missing, missing, missing, missing, missing, missing, missing, missing, missing);

        //    //得到WorkSheet对象
        //    Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

        //    //复制sheetCount-1个WorkSheet对象
        //    for(int i=1;i<sheetCount;i++)
        //    {
        //        ((Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i)).Copy(missing,workBook.Worksheets[i]);
        //    }

        //    #region 将二维数组数据写入Microsoft.Office.Interop.Excel
        //    for(int i=1;i<=sheetCount;i++)
        //    {
        //        int startRow = (i - 1) * rows;		//记录起始行索引
        //        int endRow = i * rows;			//记录结束行索引

        //        //若是最后一个WorkSheet，那么记录结束行索引为源DataTable行数
        //        if(i == sheetCount)
        //            endRow = rowCount;

        //        //获取要写入数据的WorkSheet对象，并重命名
        //        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i);
        //        sheet.Name = sheetPrefixName + "-" + i.ToString();

        //        //将二维数组中的数据写入WorkSheet
        //        for(int j=0;j<endRow-startRow;j++)
        //        {
        //            for(int k=0;k<colCount;k++)
        //            {
        //                sheet.Cells[top + j,left + k] = arr[startRow + j,k];
        //            }
        //        }

        //        Microsoft.Office.Interop.Excel.TextBox txtAuthor = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtAuthor");
        //        Microsoft.Office.Interop.Excel.TextBox txtDate = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtDate");
        //        Microsoft.Office.Interop.Excel.TextBox txtVersion = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtVersion");

        //        txtAuthor.Text = "lingyun_k";
        //        txtDate.Text = DateTime.Now.ToShortDateString();
        //        txtVersion.Text = "1.0.0.0";
        //    }
        //    #endregion

        //    //输出Microsoft.Office.Interop.Excel文件并退出
        //    try
        //    {
        //        workBook.SaveAs(outputFile, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
        //        workBook.Close(null,null,null);
        //        app.Workbooks.Close();
        //        app.Application.Quit();
        //        app.Quit();

        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

        //        workSheet=null;
        //        workBook=null;
        //        app=null;

        //        GC.Collect();
        //    }
        //    catch(Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        Process[] myProcesses;
        //        DateTime startTime;
        //        myProcesses = Process.GetProcessesByName("Microsoft.Office.Interop.Excel");

        //        //得不到Microsoft.Office.Interop.Excel进程ID，暂时只能判断进程启动时间
        //        foreach(Process myProcess in myProcesses)
        //        {
        //            startTime = myProcess.StartTime;

        //            if(startTime > beforeTime && startTime < afterTime)
        //            {
        //                myProcess.Kill();
        //            }
        //        }
        //    }
			
        //}
	}
}
