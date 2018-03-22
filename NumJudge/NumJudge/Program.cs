using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("“请输入数字【如果为科学计数法请输入大写E】：”");
            string a = Console.ReadLine();
            if (IsNum(a))
            {
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
    }
}
