using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace psms.util
{
    class MyMessageBox 
    {
        /// <summary>
        /// 程序出错提示，并记录日志
        /// </summary>
        /// <param name="from">出错的功能</param>
        /// <param name="ex">异常对象</param>
        public static void ShowErrorMessageBox(string from,Exception ex)
        {
            MessageBox.Show(from + "出错", "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.WriteLog(from + "，错误信息：" + ex.ToString());
        }


        /// <summary>
        /// 程序处理成功提示信息
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowInfoMessageBox(string mess)
        {
            MessageBox.Show(mess, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }






    }
}
