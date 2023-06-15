using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// 读取配置文件信息的功能类
    /// </summary>
    public class ConfigHelper
    {
        #region 读取配置信息的方法
        /// <summary>
        /// 读取配置信息的方法，返回字符串
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <returns>字符串型的配置信息值</returns>
        public static string GetAppSettingValue(string key)
        {
            return GetAppSettingValue(key, true);
        }
        /// <summary>
        /// 读取配置信息的方法，返回字符串
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <param name="throwException">配置文件里没有该配置时是否抛出异常</param>
        /// <returns>字符串型的配置信息值</returns>
        public static string GetAppSettingValue(string key, bool throwException)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                if (throwException)
                {
                    throw new Exception("没有在配置文件里找到名为'" + key + "'的配置信息。");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 读取配置信息的方法，返回字符串数组
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <returns>字符串数组型的配置信息值</returns>
        public static string[] GetAppSettingStringArrayValue(string key)
        {
            return GetAppSettingStringArrayValue(key, true);
        }
        /// <summary>
        /// 读取配置信息的方法，返回字符串数组
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <param name="throwException">配置文件里没有该配置时是否抛出异常</param>
        /// <returns>字符串数组型的配置信息值</returns>
        public static string[] GetAppSettingStringArrayValue(string key, bool throwException)
        {
            try
            {
                string appSettingValue = GetAppSettingValue(key);
                return ConvertHelper.ToStringArray(appSettingValue, ',');
            }
            catch
            {
                if (throwException)
                {
                    throw new Exception("没有在配置文件里找到名为'" + key + "'的配置信息。");
                }
                else
                {
                    return new string[] { };
                }
            }
        }

        /// <summary>
        /// 读取配置信息的方法，返回整数
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <returns>整数型的配置信息值</returns>
        public static int GetAppSettingInt32Value(string key)
        {
            return GetAppSettingInt32Value(key, true);
        }
        /// <summary>
        /// 读取配置信息的方法，返回整数
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <param name="throwException">配置文件里没有该配置时是否抛出异常</param>
        /// <returns>整数型的配置信息值</returns>
        public static int GetAppSettingInt32Value(string key, bool throwException)
        {
            try
            {
                string appSettingValue = GetAppSettingValue(key);
                return ConvertHelper.ToInt32(appSettingValue);
            }
            catch
            {
                if (throwException)
                {
                    throw new Exception("没有在配置文件里找到名为'" + key + "'的配置信息。");
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 读取配置信息的方法，返回整数数组
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <returns>整数数组型的配置信息值</returns>
        public static int[] GetAppSettingInt32ArrayValue(string key)
        {
            return GetAppSettingInt32ArrayValue(key, true);
        }
        /// <summary>
        /// 读取配置信息的方法，返回整数数组
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <param name="throwException">配置文件里没有该配置时是否抛出异常</param>
        /// <returns>整数数组型的配置信息值</returns>
        public static int[] GetAppSettingInt32ArrayValue(string key, bool throwException)
        {
            try
            {
                string appSettingValue = GetAppSettingValue(key);
                return ConvertHelper.ToInt32Array(appSettingValue, ',');
            }
            catch
            {
                if (throwException)
                {
                    throw new Exception("没有在配置文件里找到名为'" + key + "'的配置信息。");
                }
                else
                {
                    return new int[] { };
                }
            }
        }

        /// <summary>
        /// 读取配置信息的方法，返回布尔型变量
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <returns>布尔型的配置信息值</returns>
        public static bool GetAppSettingBooleanValue(string key)
        {
            return GetAppSettingBooleanValue(key, true);
        }
        /// <summary>
        /// 读取配置信息的方法，返回布尔型变量
        /// </summary>
        /// <param name="key">配置信息键</param>
        /// <param name="throwException">配置文件里没有该配置时是否抛出异常</param>
        /// <returns>布尔型的配置信息值</returns>
        public static bool GetAppSettingBooleanValue(string key, bool throwException)
        {
            try
            {
                return GetAppSettingValue(key).ToLower().Equals("true");
            }
            catch
            {
                if (throwException)
                {
                    throw new Exception("没有在配置文件里找到名为'" + key + "'的配置信息。");
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region 读取连接字符串信息的方法
        /// <summary>
        /// 读取连接字符串信息的方法
        /// </summary>
        /// <param name="key">连接字符串信息键</param>
        /// <returns>连接字符串信息值</returns>
        public static string GetConnectionString(string key)
        {
            try { return ConfigurationManager.ConnectionStrings[key].ConnectionString; }
            catch { throw new Exception("没有在配置文件里找到名为'" + key + "'的连接字符串信息。"); }
        }
        #endregion
    }
}
