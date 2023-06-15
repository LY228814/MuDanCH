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
using KangHui.Common;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class Mail : System.Web.UI.Page
{
    public void MailCeshi()
    {
        MailHelper.SendEmail("67293414@qq.com", "i love this game", "the body is love", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SmtpClient client = new SmtpClient("mail.qq.com");
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("920971988@qq.com", "wang111111");
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage message = new MailMessage("920971988@qq.com", "67293414@qq.com", "this is subject", "this is body");
        message.BodyEncoding = Encoding.Default;
        message.IsBodyHtml = true;


        client.Send(message);

        Response.Write("发送成功");
    }
    protected void btnceshi_Click(object sender, EventArgs e)
    {
        KangHui.Common.ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "ds", "Default4.aspx");
    }
}
