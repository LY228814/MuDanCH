using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;

namespace Ucar.Common
{
    /// <summary>
    /// 用于进行字符串处理的类
    /// </summary>
    public class StringHelper
    {
        #region 获取字符串的实际字节长度的方法
        /// <summary>
        /// 获取字符串的实际字节长度的方法
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>实际长度</returns>
        public static int GetRealLength(string source)
        {
            return Encoding.Default.GetByteCount(source);
        }
        #endregion

        #region 按字节数截取字符串的方法
        /// <summary>
        /// 按字节数截取字符串的方法
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="n">要截取的字节数</param>
        /// <param name="needEndDot">是否需要结尾的省略号</param>
        /// <returns>截取后的字符串</returns>
        public static string SubString(string source, int n, bool needEndDot)
        {
            string temp = string.Empty;
            if (GetRealLength(source) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return source;
            }
            else
            {
                int t = 0;
                char[] q = source.ToCharArray();
                for (int i = 0; i < q.Length && t < n; i++)
                {
                    if ((int)q[i] > 127)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t++;
                    }
                }
                if (needEndDot)
                    temp += "...";
                return temp;
            }
        }
        #endregion

        #region 去除价格小数点后末尾0的方法
        /// <summary>
        /// 去除价格小数点后末尾0的方法
        /// </summary>
        /// <param name="price">去0之前的价格字符串</param>
        /// <returns>去0之后的价格字符串</returns>
        public static string TrimEndZeroForPrice(string price)
        {
            while (price.EndsWith("0") && price.IndexOf(".") > 0)
            {
                price = price.TrimEnd('0');
            }
            if (price.EndsWith("."))
                price = price.Substring(0, price.Length - 1);
            return price;
        }
        #endregion

        #region 截取规定小数点后位数的方法
        /// <summary>
        /// 截取规定小数点后位数的方法
        /// </summary>
        /// <param name="objDecimal">截取前的小数对象</param>
        /// <param name="length">要截取的小数位长度</param>
        /// <returns>截取后的小数字符串</returns>
        public static string SubSpecialLengthDecimal(object objDecimal, int length)
        {
            decimal strDecimal = ConvertHelper.GetDecimal(objDecimal);
            return strDecimal.ToString("f" + length);
        }
        #endregion

        #region 过滤字符串中注入SQL脚本的方法
        /// <summary>
        /// 过滤字符串中注入SQL脚本的方法
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string SqlFilter(string input)
        {
            //单引号替换成两个单引号
            input = input.Replace("'", "''");

            //半角封号替换为全角封号，防止多语句执行
            input = input.Replace(";", "；");

            //半角括号替换为全角括号
            input = input.Replace("(", "（");
            input = input.Replace(")", "）");

            //去除执行SQL语句的命令关键字
            Regex regexSelect = new Regex("select", RegexOptions.IgnoreCase);
            input = regexSelect.Replace(input, "");
            Regex regexInsert = new Regex("insert", RegexOptions.IgnoreCase);
            input = regexInsert.Replace(input, "");
            Regex regexUpdate = new Regex("update", RegexOptions.IgnoreCase);
            input = regexUpdate.Replace(input, "");
            Regex regexDelete = new Regex("delete", RegexOptions.IgnoreCase);
            input = regexDelete.Replace(input, "");
            Regex regexDrop = new Regex("drop", RegexOptions.IgnoreCase);
            input = regexDrop.Replace(input, "");
            Regex regexTruncate = new Regex("truncate", RegexOptions.IgnoreCase);
            input = regexTruncate.Replace(input, "");

            //去除执行存储过程的命令关键字
            Regex regexExec = new Regex("exec", RegexOptions.IgnoreCase);
            input = regexExec.Replace(input, "");
            Regex regexExecute = new Regex("execute", RegexOptions.IgnoreCase);
            input = regexExecute.Replace(input, "");

            //去除系统存储过程或扩展存储过程关键字
            Regex regexXp = new Regex("xp_", RegexOptions.IgnoreCase);
            input = regexXp.Replace(input, "x p_");
            Regex regexSp = new Regex("sp_", RegexOptions.IgnoreCase);
            input = regexSp.Replace(input, "s p_");

            //防止16进制注入
            Regex regexox = new Regex("0x", RegexOptions.IgnoreCase);
            input = regexox.Replace(input, "0 x");

            return input;
        }
        #endregion

        #region 移除Html标签的方法
        /// <summary>
        /// 移除Html标签的方法
        /// </summary>
        /// <param name="str">移除Html标签之前的字符串</param>
        /// <returns>移除Html标签之后的字符串</returns>
        public static string RemoveHtmlTag(string source)
        {
            source = source.Replace("&nbsp;", "");
            source = source.Replace("\r\n", "");
            return Regex.Replace(source, "<[^>]*>", "");
        }

        #endregion

        #region 获取8位当前日期字符串的方法
        /// <summary>
        /// 获取8位当前日期字符串的方法
        /// </summary>
        /// <returns>8位当前日期字符串</returns>
        public static string GetCurrentDateString()
        {
            DateTime now = DateTime.Now;
            return string.Concat(now.Year, GetSpecialNumericString(now.Month, 2), GetSpecialNumericString(now.Day, 2));
        }
        #endregion

        #region 获取6位当前日期字符串的方法
        /// <summary>
        /// 获取6位当前日期字符串的方法
        /// </summary>
        /// <returns>6位当前日期字符串</returns>
        public static string GetSmallCurrentDateString()
        {
            string currentDateString = GetCurrentDateString();
            return currentDateString.Substring(2);
        }
        #endregion

        #region 获取指定长度数字字符串的方法，不足位数用0填充
        /// <summary>
        /// 获取指定长度数字字符串的方法，不足位数用0填充
        /// </summary>
        /// <param name="number">数字</param>
        /// <param name="length">指定的长度</param>
        /// <returns>指定长度数字字符串</returns>
        public static string GetSpecialNumericString(int number, int length)
        {
            return number.ToString("d" + length);
        }
        #endregion

        #region 移除数字字符串开始0的方法
        /// <summary>
        /// 移除数字字符串开始0的方法
        /// </summary>
        /// <param name="source">移除前的字符串</param>
        /// <returns>移除后的字符串</returns>
        public static string TrimStartZero(string source)
        {
            while (source.StartsWith("0"))
            {
                source = source.Substring(1);
            }
            return source;
        }
        #endregion

        #region 转换字符串编码的方法
        /// <summary>
        /// 转换字符串编码的方法
        /// </summary>
        /// <param name="dstEncoding">转换后的编码格式</param>
        /// <param name="s">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertEncoding(Encoding dstEncoding, string s)
        {
            return ConvertEncoding(Encoding.Default, dstEncoding, s);
        }
        /// <summary>
        /// 转换字符串编码的方法
        /// </summary>
        /// <param name="srcEncoding">转换前的编码格式</param>
        /// <param name="dstEncoding">转换后的编码格式</param>
        /// <param name="s">要进行转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ConvertEncoding(Encoding srcEncoding, Encoding dstEncoding, string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            bytes = Encoding.Convert(srcEncoding, dstEncoding, bytes);
            return Encoding.Default.GetString(bytes);
        }
        #endregion

        #region 将全角字符串转成半角字符串的方法
        /// <summary>
        /// 将全角字符串转成半角字符串的方法
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>半角字符串</returns>
        public static string ConvertDbcToSbcString(string source)
        {
            StringBuilder sb = new StringBuilder();
            char[] c = source.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                sb.Append(ConvertDbcToSbcChar(c[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region 将字符串数组转成逗号分割字符串的方法
        /// <summary>
        /// 将字符串数组转成逗号分割字符串的方法
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns>逗号分割字符串</returns>
        public static string ConvertStringArrayToStrings(string[] strArray)
        {
            if (strArray == null)
            { 
                return "";
            }

            string result = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                result += strArray[i] + ",";
            }
            return result.TrimEnd(new char[] { ',' });
        }
        #endregion

        #region 对字符串进行Url编码的方法
        /// <summary>
        /// 对字符串进行Url编码的方法
        /// </summary>
        /// <param name="s">要进行Url编码的字符串</param>
        /// <returns>Url编码后的字符串</returns>
        public static string UrlEncode(string s)
        {
            return UrlEncode(s, Encoding.Default);
        }
        /// <summary>
        /// 对字符串进行Url编码的方法
        /// </summary>
        /// <param name="s">要进行Url编码的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>Url编码后的字符串</returns>
        public static string UrlEncode(string s, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = encoding.GetBytes(s);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 将全角字符转成半角字符的方法
        /// </summary>
        /// <param name="c">转换前的字符</param>
        /// <returns>半角字符</returns>
        private static char ConvertDbcToSbcChar(char c)
        {
            //得到c的编码
            byte[] bytes = Encoding.Unicode.GetBytes(c.ToString());

            int H = Convert.ToInt32(bytes[1]);
            int L = Convert.ToInt32(bytes[0]);

            //得到unicode编码
            int value = H * 256 + L;

            //是全角
            if (value >= 65281 && value <= 65374)
            {
                int halfvalue = value - 65248;//65248是全半角间的差值。
                byte halfL = Convert.ToByte(halfvalue);

                bytes[0] = halfL;
                bytes[1] = 0;
            }
            else if (value == 12288)
            {
                int halfvalue = 32;
                byte halfL = Convert.ToByte(halfvalue);

                bytes[0] = halfL;
                bytes[1] = 0;
            }
            else
            {
                return c;
            }

            //将bytes转换成字符
            string ret = Encoding.Unicode.GetString(bytes);

            return Convert.ToChar(ret);
        }
        #endregion
    }
}
