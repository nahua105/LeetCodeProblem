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
            //是否纯为数字
            if (IsNum(a))
            {

                if (a.Length > 0 && a[0] != '0') { Console.Write("有效数字"); }
                if (a.Length > 0 && a[0] == '0') { Console.Write("无效数字（纯数字方法出）"); }
            }
            else
            {
                //含有多个符号的字符串
                if (Extext(a, "-") > 2 || Extext(a, ".") > 1 || Extext(a, "E") > 1 || a.IndexOf(".") == 0 || a.IndexOf("E") == 0|| OtherStr(a))
                { Console.Write("无效十进制数目"); }
                else
                {
                    //区分科学计数法和非科学计数法
                    if (Extext(a, "E") == 0)
                    {
                        ///含有小数点和负号的字符串判断
                        if (Extext(a, ".") == 1)
                        {
                            var result = SnumCheck(a);
                            if (result)
                            { Console.Write("有效数字(小数方法出)"); Console.ReadLine(); }
                            else
                            { Console.Write("无效数字(小数方法出)"); Console.ReadLine(); }

                        }
                        else if (Extext(a, "-") == 1)
                        {
                            var result = NumCheck(a);
                            if (result)
                            { Console.Write("有效数字(负数方法出)"); Console.ReadLine(); }
                            else
                            { Console.Write("无效数字(负数方法出)"); Console.ReadLine(); }
                        }
                    }
                    else if (Extext(a, "E") == 1)
                    {
                        var result = SclCheck(a);
                        if (result)
                        { Console.Write("有效数字(科学计数法出)"); Console.ReadLine(); }
                        else
                        { Console.Write("无效数字(科学计数法出)"); Console.ReadLine(); }

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
        /// 数字中的正确判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool NumCheck(string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] < '0' || str[i] > '9' || str[1] == '0')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 小数判断
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool SnumCheck(string Str)
        {
            //先将字符串由小数点分隔开
            string[] Sarray = Str.Split('.');
            var HeadInfo = Sarray[0];
            bool HeadFlag = false;
            bool EndFlag = false;
            //前半部分第一位为负号
            if (HeadInfo[0] == '-' && HeadInfo.Length > 1)
            {
                //负号后一位为0只能有两位[加上负号 ：0.]
                if (HeadInfo[1] == '0' && HeadInfo.Length == 2) { HeadFlag = true; }
                //第一位不为0,且为数字
                if (HeadInfo[1] > '0' && HeadInfo[1] < '9') { HeadFlag = true; }
            }
            //第一位为0且只能有一位
            if (HeadInfo[0] == '0' && HeadInfo.Length == 1)
            {
                HeadFlag = true;
            }
            else if ((HeadInfo[0] > '0' && HeadInfo[0] <= '9') && HeadInfo[0] != '-') { HeadFlag = true; }

            var EndInfo = Sarray[1];
            if (HeadInfo.Length < 1 || EndInfo.Length < 1)
            {
                return false;
            }

            if (EndInfo[EndInfo.Length - 1] != '0')
            {
                EndFlag = true;
            }
            if (HeadFlag && EndFlag)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 科学计数法判断
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool SclCheck(string Str)
        {
            string[] Sarray = Str.Split('E');
            var HeadSclInfo = Sarray[0];
            bool HeadFlag = false;

            //判断前半部分【E分割开的前部分】
            if (Extext(HeadSclInfo, ".") == 1)
            {
                ///科学记数法E前面的数要大于1小于10
                if (IsNum(HeadSclInfo) && float.Parse(HeadSclInfo) < 10 && float.Parse(HeadSclInfo) > 1)
                { HeadFlag = SnumCheck(HeadSclInfo); }
                else { HeadFlag = false; }
            }
            else if (HeadSclInfo[0] != '0' && HeadSclInfo.Length == 1)
            {
                HeadFlag = true;
            }
            var EndSclInfo = Sarray[1];
            bool EndFlag = false;
            if (EndSclInfo[0] == '-' || EndSclInfo[0] == '+')
            {
                ///此处后置位为-/+ 加数字 所以新建一个筛选方法
                EndFlag = NumCheck(EndSclInfo);
            }
            if (HeadFlag && EndFlag)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 判断字符串是否含有其他字符
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static bool OtherStr(string Str)
        {
            var flag = false;
            for (int i = 0; i < Str.Length; i++)
            {
                if ((Str[i] < '0' || Str[i] > '9') && Str[i] != '+')
                {
                    ///说明有其他字符
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

        /// <summary>
        /// 判定数字(不含有E/e)【弃用】
        /// </summary>
        /// <param name="Str">需要检索的字符串（做过一次筛选）</param>
        /// <param name="Sign">是否含有符号</param>
        /// <returns></returns>
        public static string Resultful(string Str, bool Sign)
        {

            //负号flag
            bool min_flag = false;
            if (Extext(Str, "-") == 1) { min_flag = true; }
            //小数点flag
            bool point_flag = false;
            if (Extext(Str, ".") == 1) { point_flag = true; }
            //其他字符flag
            bool other_flag = false;
            //第一位为0flag
            bool first_zero_flag = false;

            for (int i = 0; i < Str.Length; i++)
            {
                //判断其他字符


                if (Str[i] == '-')
                {
                    //负号不在第一位
                    if (Str.IndexOf('-') > 0)
                    {
                        return "负号不在第一位的非十进制数字";
                    }

                    if (point_flag && Str[i + 1] == '0' && Str.IndexOf('.') != 2)
                    {

                        return "非十进制数字(-000.1)";
                    }
                    //下一位str[i]是负号
                    if (Str[i + 1] > '0' || Str[i + 1] < '9')
                    {
                        continue;
                    }
                    else
                    {
                        return "-号后面不是数字的非数字";
                    }

                }
                ///整数判断：第一位判断(第一数为0)，sign为false[不含字符]
                if (Str[0] == '0')
                {

                    if (Str.Length > 1 && !Sign) { return "首位为0的非十进制数字"; }
                    if (Str.Length > 1 && point_flag && Str.IndexOf('.') != 1)
                    {
                        return "首位为0的小数点不在0后的非十进制数字";
                    }
                }

                ///第一位是0且后一位不是小数点
                if (Str[0] == '0' && Sign && Str[1] != '.')
                {
                    return "第一位为0且后一位不是小数点的非数字";
                }
                ///末置位判断(小数)[有小数点]
                if (Str[Str.Length - 1] == '0' && Sign && point_flag)
                {
                    return "末置位为0的非数字（非整数）";
                }
            }

            if (other_flag)
            {
                return "存在其他字符";
            }
            return "正常数字";
        }
    }
}

