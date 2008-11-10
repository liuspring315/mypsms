using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace psms.util
{
    class MyMessageBox 
    {
        /// <summary>
        /// ���������ʾ������¼��־
        /// </summary>
        /// <param name="from">����Ĺ���</param>
        /// <param name="ex">�쳣����</param>
        public static void ShowErrorMessageBox(string from,Exception ex)
        {
            MessageBox.Show(from + "����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.WriteLog(from + "��������Ϣ��" + ex.ToString());
        }


        /// <summary>
        /// ������ɹ���ʾ��Ϣ
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowInfoMessageBox(string mess)
        {
            MessageBox.Show(mess, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }






    }
}
