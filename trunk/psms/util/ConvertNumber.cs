using System;
using System.Collections.Generic;
using System.Text;

namespace psms.util
{
    public class ConvertNumber
    {
        //�ӵ���Ķ��岿��
        private static string[] cstr ={ "��", "Ҽ", "��", "��", "��", "��", "½", "��", "��", "��" };
        private static string[] wstr ={ "", "", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ" };
        //���ֱ�����12λ�������ڵ��ַ���
        //���÷�ʽ�磺label1.text=convertint("�����ַ���");

        public static string convertint(string str2)
        {
            string str = str2.Trim();
            int len = str.Length;
            int i;
            string tmpstr, rstr;
            rstr = "";
            if (str.IndexOf("-") < 0)
            {
                for (i = 1; i <= len; i++)
                {
                    tmpstr = str.Substring(len - i, 1);
                    rstr = string.Concat(cstr[Int32.Parse(tmpstr)] + wstr[i], rstr);
                }
            }
            else
            {
                for (i = 1; i < len; i++)
                {
                    tmpstr = str.Substring(len - i, 1);
                    rstr = string.Concat(cstr[Int32.Parse(tmpstr)] + wstr[i], rstr);
                }
                rstr = "(��)" + rstr;
            }
            rstr = rstr.Replace("ʰ��", "ʰ");
            rstr = rstr.Replace("��ʰ", "��");
            rstr = rstr.Replace("���", "��");
            rstr = rstr.Replace("��Ǫ", "��");
            rstr = rstr.Replace("����", "��");
            for (i = 1; i <= 6; i++)
                rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("����", "��");
            rstr = rstr.Replace("����", "��");

            string lrstr = rstr.Substring(rstr.Length - 1, 1);
            if (lrstr == "��")
                rstr = rstr.Substring(0, rstr.Length - 1);

            //rstr += "Բ��";
            return rstr;
        } 
    }
}
