using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucar.Common
{
    /// <summary>
    /// 用于在页面中输出脚本的类
    /// </summary>
    public class ScriptHelper
    {
        #region 显示消息提示对话框
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAlertScript(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        #endregion

        #region 控件点击消息确认提示框
        /// <summary>
        /// 控件点击消息确认提示框
        /// </summary>
        /// <param name="control">点击控件的对象</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirmScript(WebControl control, string msg)
        {
            control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
        #endregion

        #region 控件点击打开窗体
        /// <summary>
        /// 控件点击打开窗体
        /// </summary>
        /// <param name="control">点击控件的对象</param>
        /// <param name="url">打开页面的地址</param>
        public static void ShowOpenScript(WebControl control, string url)
        {
            control.Attributes.Add("onclick", "window.open('" + url + "');");
        }

        /// <summary>
        /// 控件点击打开窗体
        /// </summary>
        /// <param name="control">点击控件的对象</param>
        /// <param name="url">打开页面的地址</param>
        /// <param name="width">打开页面的宽度</param>
        /// <param name="height">打开页面的高度</param>
        public static void ShowOpenScript(WebControl control, string url, int width, int height)
        {
            control.Attributes.Add("onclick", "window.open('" + url + "', '', 'width=" + width + ",height=" + height + ",fullscreen=no, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no');");
        }

        /// <summary>
        /// 控件点击打开最大化窗体
        /// </summary>
        /// <param name="control">点击控件的对象</param>
        /// <param name="url">打开页面的地址</param>
        public static void ShowOpenMaxScript(WebControl control, string url)
        {
            control.Attributes.Add("onclick", "var mywin=window.open('" + url + "');mywin.moveTo(0,0);mywin.resizeTo(screen.availWidth,screen.availHeight);");
        }
        #endregion

        #region 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        public static void ShowCloseScript(Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>window.close();</script>");
        }
        /// <summary>
        /// 控件点击关闭窗体
        /// </summary>
        /// <param name="Control">点击控件的对象</param>
        public static void ShowCloseScript(WebControl control)
        {
            control.Attributes.Add("onclick", "window.close();");
        }
        #endregion

        #region 显示消息确认提示框，并关闭窗体
        /// <summary>
        /// 显示消息确认提示框，并关闭窗体
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAlertAndCloseScript(Page page, string msg)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.close();");
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }
        /// <summary>
        /// 控件点击消息确认提示框，并关闭窗体
        /// </summary>
        /// <param name="Control">点击控件的对象</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAlertAndCloseScript(WebControl Control, string msg)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.close();");
            Builder.Append("</script>");
            Control.Attributes.Add("onclick", Builder.ToString());
        }
        #endregion

        #region 显示消息确认提示框，并关闭窗体，刷新父窗体
        /// <summary>
        /// 显示消息确认提示框，并关闭窗体，刷新父窗体
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">父窗体地址</param>
        public static void ShowAlertAndCloseRefreshScript(Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.close();");
            if (url != "") Builder.AppendFormat("opener.location.href='{0}';", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }
        /// <summary>
        /// 控件点击消息确认提示框，并关闭窗体，刷新父窗体
        /// </summary>
        /// <param name="Control">点击控件的对象</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">父窗体地址</param>
        public static void ShowAlertAndCloseRefreshScript(WebControl Control, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.close();");
            if (url != "") Builder.AppendFormat("opener.location.href='{0}';", url);
            Builder.Append("</script>");
            Control.Attributes.Add("onclick", Builder.ToString());
        }
        #endregion

        #region 显示消息提示对话框，并进行页面跳转
        /// <summary>
        /// 显示消息提示对话框，并在当前页面进行跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标地址</param>
        public static void ShowAlertAndRedirectScript(Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("window.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        /// <summary>
        /// 显示消息提示对话框，并在最上层页面进行跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标地址</param>
        public static void ShowAlertAndTopRedirectScript(Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        #endregion

        #region 输出自定义脚本信息
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ShowCustomScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
        #endregion
    }
}
