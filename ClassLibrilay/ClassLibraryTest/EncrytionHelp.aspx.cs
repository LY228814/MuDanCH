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

public partial class EncrytionHelp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string y = KangHui.Common.EncryptionHelper.DesEncrypt("54645543");
        //Response.Write(y);
        KangHui.Common.SmsHelper.SendMessage("15236275663", "mytest");



    }
}
