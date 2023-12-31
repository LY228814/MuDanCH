﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Web;

namespace Ucar.Common
{
    /// <summary>
    /// 对日志进行处理的类
    /// </summary>
    public class LogHelper
    {
        #region 记录错误日志的方法
        /// <summary>
        /// 记录错误日志的方法
        /// </summary>
        /// <param name="ex">异常的实例</param>
        public static void ErrorLog(Exception ex)
        {
            ErrorLog(ex, HttpContext.Current.Server.MapPath("~/ErrorLog/"));
        }

        /// <summary>
        /// 记录错误日志的方法
        /// </summary>
        /// <param name="ex">异常的实例</param>
        /// <param name="_logLocalPath">日志文件物理路径</param>
        public static void ErrorLog(Exception ex, string logLocalPath)
        {
            HttpRequest request = HttpContext.Current.Request;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("========================================================================");
            sb.AppendLine("异常发生时间           : " + DateTime.Now);
            sb.AppendLine("客户端IP地址           : " + request.UserHostAddress);
            sb.AppendLine("客户端浏览器版本       : " + request.Browser.Type);
            sb.AppendLine("客户端上次请求的地址   : " + ConvertHelper.GetString(request.UrlReferrer));
            sb.AppendLine("客户端本次请求的地址   : " + ConvertHelper.GetString(request.Url));
            sb.AppendLine("当前异常的消息         : " + ex.Message);
            sb.AppendLine("引发当前异常的类名     : " + ex.TargetSite.DeclaringType.FullName);
            sb.AppendLine("引发当前异常的方法名   : " + ex.TargetSite.Name);
            sb.AppendLine("堆栈信息               : " + ex.StackTrace);
            sb.AppendLine("========================================================================");
            sb.AppendLine();

            //CustomLog(sb.ToString(), logLocalPath);

            if (ConfigHelper.GetAppSettingBoolean("SendErrorEmail", false))
            {
                string strto = ConfigHelper.GetAppSetting("ErrorEmailReceiver", false);
                string strSubject = "网站错误日志";
                string strBody = sb.ToString();
                MailHelper.SendEmail(strto, strSubject, strBody, false);
            }
        }
        #endregion

        #region 记录自定义日志信息的方法
        /// <summary>
        /// 记录自定义日志信息的方法
        /// </summary>
        /// <param name="content">日志信息</param>
        public static void CustomLog(string content)
        {
            CustomLog(content, HttpContext.Current.Server.MapPath("~/CustomLog/"));
        }

        /// <summary>
        /// 记录自定义日志信息的方法
        /// </summary>
        /// <param name="content">日志信息</param>
        /// <param name="logLocalPath">日志文件物理路径</param>
        public static void CustomLog(string content, string logLocalPath)
        {
            string FilePath = logLocalPath + DateTime.Now.ToShortDateString() + ".txt";
            FileHelper.AppendFile(content, FilePath);
        }
        #endregion
    }
}
