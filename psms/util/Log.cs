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
        /// 写日志文件
        /// </summary>
        /// <param name="sMsg"></param>
        public static void WriteLog(string sMsg)
        {
            LogWriter(sMsg, "异常" + DateTime.Now.ToString("yyyyMM") + ".log");
        }




        /// <summary>
        /// 出入库操作新增修改写日志文件
        /// </summary>
        /// <param name="strfrom">来源</param>
        /// <param name="strbutton">时间按钮</param>
        /// <param name="sMsg">信息</param>
        /// <param name="res">结果</param>
        public static void WriteLog(string strfrom,string strbutton,string sMsg,string res)
        {
            DateTime dateTime = DateTime.Now;
            string strDate = "操作时间：" + dateTime;
            string from = "操作来源：" + strfrom;
            string button = "事件触发于：" + strbutton;
            string msg = "信息：" + sMsg;
            string result = "结果：" + res;

            StringBuilder log = new StringBuilder();
            log.Append(strDate).Append("\n");
            log.Append(from).Append("\n");
            log.Append(button).Append("\n");
            log.Append(msg).Append("\n");
            log.Append(result).Append("\n");

            LogWriter(log.ToString(), "日志" + DateTime.Now.ToString("yyyyMM") + ".log");

            
        }




        /// <summary>
        /// 写入文件
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