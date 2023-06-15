using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// 对数据类型进行转换的功能类
    /// </summary>
    public class ConvertHelper
    {
        #region 将对象变量转成字符串变量的方法
        /// <summary>
        /// 将对象变量转成字符串变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>字符串变量</returns>
        public static string ToString(object obj)
        {
            return (obj == null) ? string.Empty : obj.ToString();
        }
        #endregion

        #region 将对象变量转成32位整数型变量的方法
        /// <summary>
        /// 将对象变量转成32位整数型变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>32位整数型变量</returns>
        public static int ToInt32(object obj)
        {
            int result;
            int.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 将对象变量转成64位整数型变量的方法
        /// <summary>
        /// 将对象变量转成64位整数型变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>64位整数型变量</returns>
        public static long ToInt64(object obj)
        {
            long result;
            long.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 将对象变量转成双精度浮点型变量的方法
        /// <summary>
        /// 将对象变量转成双精度浮点型变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>双精度浮点型变量</returns>
        public static double ToDouble(object obj)
        {
            double result;
            double.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 将对象变量转成十进制数字变量的方法
        /// <summary>
        /// 将对象变量转成十进制数字变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>十进制数字变量</returns>
        public static decimal ToDecimal(object obj)
        {
            decimal result;
            decimal.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 将对象变量转成布尔型变量的方法
        /// <summary>
        /// 将对象变量转成布尔型变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>布尔型变量</returns>
        public static bool ToBoolean(object obj)
        {
            bool result;
            bool.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 将对象变量转成日期型变量的方法
        /// <summary>
        /// 将对象变量转成日期型变量的方法
        /// </summary>
        /// <param name="obj">对象变量</param>
        /// <returns>日期型变量</returns>
        public static DateTime ToDateTime(object obj)
        {
            DateTime result;
            DateTime.TryParse(ToString(obj), out result);
            return result;
        }
        #endregion

        #region 根据分隔符将字符串变量转成字符串数组的方法
        /// <summary>
        /// 根据分隔符将字符串变量转成字符串数组的方法
        /// </summary>
        /// <param name="s">字符串变量</param>
        /// <param name="seperator">分隔符</param>
        /// <returns>字符串数组</returns>
        public static string[] ToStringArray(string s, char seperator)
        {
            return s.Split(new char[] { seperator });
        }
        #endregion

        #region 根据分隔符将字符串变量转成32位整数型数组的方法
        /// <summary>
        /// 根据分隔符将字符串变量转成32位整数型数组的方法
        /// </summary>
        /// <param name="s">字符串变量</param>
        /// <param name="seperator">分隔符</param>
        /// <returns>32位整数型数组</returns>
        public static int[] ToInt32Array(string s, char seperator)
        {
            string[] sArray = ToStringArray(s, seperator);
            int[] iArray = new int[sArray.Length];
            for (int i = 0; i < sArray.Length; i++)
            {
                iArray[i] = ToInt32(sArray[i]);
            }
            return iArray;
        }
        #endregion
    }
}
