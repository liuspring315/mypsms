using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using cfg = System.Configuration;

namespace psms.util
{
	/// <summary>
	/// ����˵��������ģ�����Microsoft.Office.Interop.Excel���������ݽ��з�ҳ
	/// ��    �ߣ�Lingyun_k
	/// �������ڣ�2005-7-12
	/// </summary>
	public class ExcelHelper
	{
//        protected string templetFile = null;
//        protected string outputFile = null;
//        protected object missing = Missing.Value;

//        /// <summary>
//        /// ���캯������ָ��ģ���ļ�������ļ�����·��
//        /// </summary>
//        /// <param name="templetFilePath">Microsoft.Office.Interop.Excelģ���ļ�·��</param>
//        /// <param name="outputFilePath">���Microsoft.Office.Interop.Excel�ļ�·��</param>
//        public ExcelHelper(string templetFilePath,string outputFilePath)
//        {
//            if(templetFilePath == null)
//                throw new Exception("Microsoft.Office.Interop.Excelģ���ļ�·������Ϊ�գ�");

//            if(outputFilePath == null)
//                throw new Exception("���Microsoft.Office.Interop.Excel�ļ�·������Ϊ�գ�");

//            if(!File.Exists(templetFilePath))
//                throw new Exception("ָ��·����Microsoft.Office.Interop.Excelģ���ļ������ڣ�");

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
//        /// ��DataTable����д��Microsoft.Office.Interop.Excel�ļ�������ģ�岢��ҳ��
//        /// </summary>
//        /// <param name="dt">DataTable</param>
//        /// <param name="rows">ÿ��WorkSheetд�����������</param>
//        /// <param name="top">������</param>
//        /// <param name="left">������</param>
//        /// <param name="sheetPrefixName">WorkSheetǰ׺�������磺ǰ׺��Ϊ��Sheet������ôWorkSheet��������Ϊ��Sheet-1��Sheet-2...��</param>
//        public void DataTableToExcel(System.Data.DataTable dt,int rows,int top,int left,string sheetPrefixName)
//        {
//            int rowCount = dt.Rows.Count;		//ԴDataTable����
//            int colCount = dt.Columns.Count;	//ԴDataTable����
//            int sheetCount = this.GetSheetCount(rowCount,rows);	//WorkSheet����
//            DateTime beforeTime;	
//            DateTime afterTime;
			
//            if(sheetPrefixName == null || sheetPrefixName.Trim() == "")
//                sheetPrefixName = "Sheet";

//            //����һ��Application����ʹ��ɼ�
//            beforeTime = DateTime.Now;
//            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
//            app.Visible = true;
//            afterTime = DateTime.Now;

//            //��ģ���ļ����õ�WorkBook����
//            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(templetFile, missing, missing, missing, missing, missing,
//                                missing, missing, missing, missing, missing, missing, missing, missing, missing);

//            //�õ�WorkSheet����
//            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

//            //����sheetCount-1��WorkSheet����
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
            

//            #region ��ԴDataTable����д��Microsoft.Office.Interop.Excel
//            //for(int i=1;i<=sheetCount;i++)
//            //{
//            //    int startRow = (i - 1) * rows;		//��¼��ʼ������
//            //    int endRow = i * rows;			//��¼����������

//            //    //�������һ��WorkSheet����ô��¼����������ΪԴDataTable����
//            //    if(i == sheetCount)
//            //        endRow = rowCount;

//            //    //��ȡҪд�����ݵ�WorkSheet���󣬲�������
//            //    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i);
//            //    sheet.Name = sheetPrefixName + "-" + i.ToString();

//            //    //��dt�е�����д��WorkSheet
//            //    for(int j=0;j<endRow-startRow;j++)
//            //    {
//            //        for(int k=0;k<colCount;k++)
//            //        {
//            //            sheet.Cells[top + j,left + k] = dt.Rows[startRow + j][k].ToString();
//            //        }
//            //    }

//            //    //д�ı�������
//            //    Microsoft.Office.Interop.Excel.TextBox txtAuthor = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtAuthor");
//            //    Microsoft.Office.Interop.Excel.TextBox txtDate = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtDate");
//            //    Microsoft.Office.Interop.Excel.TextBox txtVersion = (Microsoft.Office.Interop.Excel.TextBox)sheet.TextBoxes("txtVersion");

//            //    txtAuthor.Text = "lingyun_k";
//            //    txtDate.Text = DateTime.Now.ToShortDateString();
//            //    txtVersion.Text = "1.0.0.0";
//            //}
//            #endregion

//            //���Microsoft.Office.Interop.Excel�ļ����˳�
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

//                //�ò���Microsoft.Office.Interop.Excel����ID����ʱֻ���жϽ�������ʱ��
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
//        /// ��ȡWorkSheet����
//        /// </summary>
//        /// <param name="rowCount">��¼������</param>
//        /// <param name="rows">ÿWorkSheet����</param>
//        private int GetSheetCount(int rowCount,int rows)
//        {
//            int n = rowCount % rows;		//����

//            if(n == 0)
//                return rowCount / rows;
//            else
//                return Convert.ToInt32(rowCount / rows) + 1;
//        }


//        /// <summary>
//        /// ����ά��������д��Microsoft.Office.Interop.Excel�ļ�������ģ�岢��ҳ��
//        /// </summary>
//        /// <param name="arr">��ά����</param>
//        /// <param name="rows">ÿ��WorkSheetд�����������</param>
//        /// <param name="top">������</param>
//        /// <param name="left">������</param>
//        /// <param name="sheetPrefixName">WorkSheetǰ׺�������磺ǰ׺��Ϊ��Sheet������ôWorkSheet��������Ϊ��Sheet-1��Sheet-2...��</param>
//        public void ArrayToExcel(string[,] arr,int rows,int top,int left,string sheetPrefixName)
        //{
        //    int rowCount = arr.GetLength(0);		//��ά����������һά���ȣ�
        //    int colCount = arr.GetLength(1);	//��ά������������ά���ȣ�
        //    int sheetCount = this.GetSheetCount(rowCount,rows);	//WorkSheet����
        //    DateTime beforeTime;	
        //    DateTime afterTime;
			
        //    if(sheetPrefixName == null || sheetPrefixName.Trim() == "")
        //        sheetPrefixName = "Sheet";

        //    //����һ��Application����ʹ��ɼ�
        //    beforeTime = DateTime.Now;
        //    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    app.Visible = true;
        //    afterTime = DateTime.Now;

        //    //��ģ���ļ����õ�WorkBook����
        //    Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(templetFile,missing,missing,missing,missing,missing,
        //        missing, missing, missing, missing, missing, missing, missing, missing, missing);

        //    //�õ�WorkSheet����
        //    Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets.get_Item(1);

        //    //����sheetCount-1��WorkSheet����
        //    for(int i=1;i<sheetCount;i++)
        //    {
        //        ((Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i)).Copy(missing,workBook.Worksheets[i]);
        //    }

        //    #region ����ά��������д��Microsoft.Office.Interop.Excel
        //    for(int i=1;i<=sheetCount;i++)
        //    {
        //        int startRow = (i - 1) * rows;		//��¼��ʼ������
        //        int endRow = i * rows;			//��¼����������

        //        //�������һ��WorkSheet����ô��¼����������ΪԴDataTable����
        //        if(i == sheetCount)
        //            endRow = rowCount;

        //        //��ȡҪд�����ݵ�WorkSheet���󣬲�������
        //        Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(i);
        //        sheet.Name = sheetPrefixName + "-" + i.ToString();

        //        //����ά�����е�����д��WorkSheet
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

        //    //���Microsoft.Office.Interop.Excel�ļ����˳�
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

        //        //�ò���Microsoft.Office.Interop.Excel����ID����ʱֻ���жϽ�������ʱ��
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
