using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace psms.util
{
    public class DataGirdViewUtil
    {
        public static int ONE = -1;
        public static int PRV = -2;
        public static int NEXT = -3;
        public static int LAST = -4;


        /// <summary>
        /// 得到导航
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="i"></param>
        public static void selectedDataGridViewRow(DataGridView dg, int i)
        {
            if (dg.RowCount == 0)
                return;

            int selectIndex = 0;
            int rowCount = dg.Rows.Count;
            if (dg.SelectedRows.Count == 0)
            {
                dg.Rows[selectIndex].Selected = true;
            }
            else
            {
                selectIndex = dg.SelectedRows[0].Index;
                if (i == NEXT)
                {
                    if (selectIndex + 1 < rowCount)
                    {
                        dg.Rows[selectIndex + 1].Selected = true;
                        dg.CurrentCell = dg.Rows[selectIndex + 1].Cells[0];
                    }
                }
                else if (i == PRV)
                {
                    if (selectIndex - 1 > -1)
                    {
                        dg.Rows[selectIndex - 1].Selected = true;
                        dg.CurrentCell = dg.Rows[selectIndex - 1].Cells[0];
                    }
                }
                else if (i == LAST)
                {
                    dg.Rows[rowCount - 1].Selected = true;
                    dg.CurrentCell = dg.Rows[rowCount - 1].Cells[0];
                }
                else if (i == ONE)
                {
                    dg.Rows[0].Selected = true;
                    dg.CurrentCell = dg.Rows[0].Cells[0];
                }
                else
                {
                    if (i > 0 && i < rowCount)
                    {
                        dg.Rows[i].Selected = true;
                        dg.CurrentCell = dg.Rows[i].Cells[0];
                    }
                }
            }
        }



        /// <summary>
        /// 选中指定列columnname的值为value的行，如果有多个，选中遍历得到的第一个
        /// </summary>
        /// <param name="dg">DataGridView对象</param>
        /// <param name="columnname">DataGridView中的列名</param>
        /// <param name="value">指定列的值</param>
        /// <returns></returns>
        public static void selectedRowByValue(DataGridView dg, string columnname,string value)
        {
            //int selectIndex = dg.SelectedRows[0].Index;
            int rowCount = dg.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (dg.Rows[i].Cells[columnname].Value.ToString().Trim() == value)
                {
                    dg.Rows[i].Selected = true;
                    dg.CurrentCell = dg.Rows[i].Cells[0];
                    break;
                }
            }
        }

        /// <summary>
        /// 得到选中行指定列的值
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="columnname"></param>
        /// <returns></returns>
        public static string getSelectedRowsCellValue(DataGridView dg, string columnname)
        {
            //int selectIndex = dg.SelectedRows[0].Index;
            if (dg.CurrentRow.Index >= dg.RowCount)
                return "";
            return dg.Rows[dg.CurrentRow.Index].Cells[columnname].Value.ToString();
        }

        /// <summary>
        /// 查找id所在的行
        /// </summary>
        /// <param name="dg"></param>
        /// <param name="id"></param>
        /// <param name="columnname"></param>
        public static void getRowById(DataGridView dg, int id, string columnname)
        {
            if (dg.RowCount == 0)
                return;

            int count = dg.Rows.Count;
            if (id == 0)
            {
                dg.Rows[0].Selected = true;
                dg.CurrentCell = dg.Rows[0].Cells[0];
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (Int32.Parse(dg.Rows[i].Cells[columnname].Value.ToString()) == id)
                    {
                        dg.Rows[i].Selected = true;
                        dg.CurrentCell = dg.Rows[i].Cells[0];
                        break;
                    }
                }
            }
        }



        public static DataTable ListToTable(IList<IList<string>> list)
        {
            DataTable dt = new DataTable();
            int count = list[0].Count;
            //int index = 1;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    dt.Columns.Add("col" + i, "abc".GetType());
                }
                //dt.Columns.Add("id");//编号
                dt.BeginLoadData();
                for (int i = 0; i < list.Count; i++)
                {
                    object[] objectRow = new object[count];
                    for (int j = 0; j < count; j++)
                    {

                        objectRow[j] = list[i][j];
                    }
                    //objectRow[count] = index;//编号
                    dt.LoadDataRow(objectRow, true);
                    //index++;
                }
                dt.EndLoadData();
            }
            return dt;

        }


    }
}
