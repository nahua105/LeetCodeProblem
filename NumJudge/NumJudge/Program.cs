using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("“请输入数字【如果为科学计数法请输入大写E1】：”");
            string a = Console.ReadLine();
            if (IsNum(a))
            {
                //需要修改的纯数字判断
                Console.Write("是纯数字");
            }
            else
            {
                //含有多个符号的字符串
                if (Extext(a, "-") > 1 || Extext(a, ".") > 1 || Extext(a, "E") > 1 || a.IndexOf(".") == 0 || a.IndexOf("E") == 0)
                {
                    Console.Write("无效十进制数目");

                }
                else
                {
                    if (a.IndexOf("-") == 0 && a.IndexOf(".") != 1)
                    {
                        Console.Write("负数");
                    }
                    //正科学计数法
                    else if ((a.IndexOf("E") > 0 && a.IndexOf("+") == (a.IndexOf("E") + 1) && a.IndexOf(".") != (a.IndexOf("E") + 1) && a.IndexOf(".") != (a.IndexOf("E") - 1) && a.IndexOf(".") != (a.IndexOf("+") - 1) && a.IndexOf(".") != (a.IndexOf("+") + 1)) || (a.IndexOf("E") > 0 && a.IndexOf("-") == (a.IndexOf("E") + 1) && a.IndexOf(".") != (a.IndexOf("-") + 1) && a.IndexOf(".") != (a.IndexOf("-") - 1) && a.IndexOf(".") != (a.IndexOf("E") + 1) && a.IndexOf(".") != (a.IndexOf("E") - 1)))
                    {
                        Console.Write("科学计数法数字（正数）");
                    }
                    //负科学计数法
                    else if (Extext(a, "-") == 2 && a.IndexOf("E") > 0 && a.IndexOf("-", 1, 2) == (a.IndexOf("E") + 1))
                    {
                        Console.Write("科学计数法数字(负数)");
                    }
                    else if (a.IndexOf(".") > 0 && Extext(a, "-") == 0 && Extext(a, "E") == 0)
                    {
                        Console.Write("正小数");
                    }
                    else
                    {
                        Console.Write("非十进制数");

                    }
                }

            }
            Console.ReadLine();
        }
        /// <summary>
        /// 非数字字符检索
        /// </summary>
        /// <param name="str">需要检索的字符串</param>
        /// <param name="sign">需要被检索的字符</param>
        /// <returns>特定字符的个数</returns>
        public static int Extext(string str, string sign)
        {
            if (str.Contains(sign))
            {
                string strReplaced = str.Replace(sign, "");
                return (str.Length - strReplaced.Length) / sign.Length;
            }

            return 0;
        }

        /// <summary>
        /// 判断是否全为数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsNum(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9')
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 判定数字(不含有E/e)
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string Isvalueful(string Str)
        {
            //负号
            bool min_flag = false;
            bool scl_flag = false;
            ///小数点符号
            bool point_flag = false;
            bool first_zero_flag = false;
            int num_flag = 0;
            int zero_flag = 0;
            for (int i = 0; i < Str.Length; i++)
            {

                if (Str[i] == '-')
                {
                    //下一位
                    if (Str[i + 1] > '0' || Str[i + 1] < '9')
                    {
                        continue;
                    }
                    else {

                        return "-号后面不是数字的非数字";
                    }
                }
                ///第一位判断
                if (Str[0] == 0)
                {
                    
                    first_zero_flag = true;
                    if (Str[i + 1] == '.')
                    {
                        
                        continue;
                    }
                    else {
                        return "第一位为0且后一位不是小数点的非数字";
                    }
                }

                if (Str[Str.Length] == 0)
                {
                    return "末置位为0的小数";
                }
            }

            return "";
        }
    }
}
