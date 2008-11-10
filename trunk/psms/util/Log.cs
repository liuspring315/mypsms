using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace psms.util
{
    class Log
    {
        /// <summary>
        /// д��־�ļ�
        /// </summary>
        /// <param name="sMsg"></param>
        public static void WriteLog(string sMsg)
        {
            LogWriter(sMsg, "�쳣" + DateTime.Now.ToString("yyyyMM") + ".log");
        }




        /// <summary>
        /// �������������޸�д��־�ļ�
        /// </summary>
        /// <param name="strfrom">��Դ</param>
        /// <param name="strbutton">ʱ�䰴ť</param>
        /// <param name="sMsg">��Ϣ</param>
        /// <param name="res">���</param>
        public static void WriteLog(string strfrom,string strbutton,string sMsg,string res)
        {
            DateTime dateTime = DateTime.Now;
            string strDate = "����ʱ�䣺" + dateTime;
            string from = "������Դ��" + strfrom;
            string button = "�¼������ڣ�" + strbutton;
            string msg = "��Ϣ��" + sMsg;
            string result = "�����" + res;

            StringBuilder log = new StringBuilder();
            log.Append(strDate).Append("\n");
            log.Append(from).Append("\n");
            log.Append(button).Append("\n");
            log.Append(msg).Append("\n");
            log.Append(result).Append("\n");

            LogWriter(log.ToString(), "��־" + DateTime.Now.ToString("yyyyMM") + ".log");

            
        }




        /// <summary>
        /// д���ļ�
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="filename"></param>
        private static void LogWriter(string sMsg,string filename)
        {
            if (sMsg != "")
            {
                try
                {
                    FileInfo fi = new FileInfo(Application.StartupPath + "\\log\\" + filename);
                    if (!fi.Exists)
                    {
                        using (StreamWriter sw = fi.CreateText())
                        {
                            sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = fi.AppendText())
                        {
                            sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }




    }
}