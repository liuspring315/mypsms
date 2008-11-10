using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace psms.util
{
    class StrUtil
    {
        public static string UP = "up";
        public static string ADD = "add";

        public static string ENTER = (char)13 + "\n";


        public static string inStrbyLength(string p_no,int length)
        {
            StringBuilder str = new StringBuilder("");
            for (int i = 0; i < length - p_no.Length; i++)
            {
                str.Append(" ");
            }
            return str.ToString();
        }

        public static int inStrbyLength(float p_no, int length)
        {
            int a = 0;
            for (int i = 0; i < length - p_no; i++)
            {
                a++;
            }
            return a;
        }


        /// <summary>
        /// 实现类似Excel自动填充单元格 字符串末尾数字累加
        /// </summary>
        /// <param name="s">上一个字符串</param>
        /// <returns>下一个字符串</returns>
        public static string Next(string s)
        {
            if (!isNumber(s.Substring(s.Length - 1, 1)))
                s = s + "0";
            MatchCollection coll = Regex.Matches(s, @"\d+");
            Match m = coll[coll.Count - 1];

            return s.Substring(0, m.Index) + NextNum(m.Value);
        }
        private static string NextNum(string s)
        {
            char[] cs = s.ToCharArray();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (!NextChar(ref   cs[i])) break;
            }

            string re = new string(cs);
            if (Int32.Parse(re) == 0)
                re = "1" + re;
            return re;
        }
        private static bool NextChar(ref   char c)
        {
            string p = "0123456789０１２３４５６７８９";
            int n = p.IndexOf(c);
            c = p[(n + 1) % 10 + 10 * (n / 10)];
            return (n == 9 || n == 19);
        }
        private static bool isNumber(string str)
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (r.IsMatch(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
