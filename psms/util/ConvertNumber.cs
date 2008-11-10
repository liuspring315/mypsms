using System;
using System.Collections.Generic;
using System.Text;

namespace psms.util
{
    public class ConvertNumber
    {
        //加到类的定义部分
        private static string[] cstr ={ "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        private static string[] wstr ={ "", "", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟" };
        //数字必须在12位整数以内的字符串
        //调用方式如：label1.text=convertint("数字字符串");

        public static string convertint(string str2)
        {
            string str = str2.Trim();
            int len = str.Length;
            int i;
            string tmpstr, rstr;
            rstr = "";
            for (i = 1; i <= len; i++)
            {
                tmpstr = str.Substring(len - i, 1);
                rstr = string.Concat(cstr[Int32.Parse(tmpstr)] + wstr[i], rstr);
            }
            rstr = rstr.Replace("拾零", "拾");
            rstr = rstr.Replace("零拾", "零");
            rstr = rstr.Replace("零佰", "零");
            rstr = rstr.Replace("零仟", "零");
            rstr = rstr.Replace("零萬", "萬");
            for (i = 1; i <= 6; i++)
                rstr = rstr.Replace("零零", "零");
            rstr = rstr.Replace("零萬", "零");
            rstr = rstr.Replace("零億", "億");
            rstr = rstr.Replace("零零", "零");

            string lrstr = rstr.Substring(rstr.Length - 1, 1);
            if (lrstr == "零")
                rstr = rstr.Substring(0, rstr.Length - 1);

            //rstr += "圆整";
            return rstr;
        } 
    }
}
