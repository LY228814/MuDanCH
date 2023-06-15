using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using KangHui.Common;

public partial class EmailAndLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetLogNote(Exception ex)
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
        return sb.ToString();
    }
    public void fnSendMail(string StrTo, string StrBody, string strSubjec)
    {

        System.Net.Mail.MailMessage onemail = new System.Net.Mail.MailMessage();

        string myEmail = "wangjianhui1006@gmail.com"; //发送邮件的邮箱地址

        string myPwd = "wang030405"; //发送邮件的邮箱密码

        onemail.BodyEncoding = System.Text.Encoding.UTF8;

        onemail.IsBodyHtml = true;

        onemail.From = new System.Net.Mail.MailAddress(myEmail);

        onemail.To.Add(new System.Net.Mail.MailAddress(StrTo));

        onemail.Subject = strSubjec;

        onemail.Body = StrBody;

        System.Net.Mail.SmtpClient clint = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);//发送邮件的服务器

        clint.Credentials = new System.Net.NetworkCredential(myEmail, myPwd);

        clint.EnableSsl = true;

        clint.Timeout = 15000;

        try { clint.Send(onemail); }
        catch (Exception ex) {  }

    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {

        try
        {
            string x = "abc";
            int y = Convert.ToInt32(x);
        }
        catch (Exception ex)
        {
            string message = GetLogNote(ex);
            fnSendMail("67293414@qq.com", message, "error Log");
        }
    }
}
