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
using System.Xml;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            maqStudents.Speed = 30;
            maqStudents.MarqueeDirection = KangHui.WebControls.eMarqueeDerection.Right;
            maqStudents.Width = 100;
            maqStudents.Height = 200;
            maqStudents.InnerHtml = "汉字关东吧。<img src='./aaa/bb.png' />滚动吧。滚拱坝。。。";





            XmlDocument doc = XmlHelper.GetXmlDocument("E:\\KangHuiClassLibrilay\\ClassLibraryTest\\aaa\\Provinces.xml");
            gvxml.DataSource= XmlHelper.GetDataSetByXmlDocument(doc);
            //gvxml.DataBind();
            string strurl = "E:\\Src\\WebSite\\reports\\CarBussByMonth.aspx";
            Response.Write(FileHelper.GetSuffix(strurl)+"<br />");
            Response.Write(FileHelper.GetFileName(strurl));
            string bx = string.Concat("who ", "is ", "that ", "?");
            Response.Write(bx);
            string str = "UNIQUEIDENTIFIER 128 个位 用于远程过程调用的唯一识别数字";
            Response.Write(str.Substring(10, 29)+"<BR />");
            Response.Write(StringHelper.SubString(str,39,true) + "<BR />");
            Response.Write(StringHelper.GetRealLength("我的中国"));
            Response.Write(ConvertHelper.GetDateTime("dfdsfsdfsfd").ToString());
            Response.Write(ConvertHelper.GetDateTime("1988 8 8").ToString());
            //DateTime x = System.DateTime.Now;
            //string x = "afsd";
            //Response.Write(Convert.ToDateTime(x));
            //Response.Write(KangHui.Common.ConvertHelper.GetDateTimeString(x,"yyyy-MM-dd"));
            object a = "9990.54535945";
            string[] arr = { "1","2","3","4","5"};
            Response.Write(StringHelper.ConvertStringArrayToStrings(arr));
            string bb = "img1.ucar.cn\\ucar\\UploadPic\\SecondHandCar\\20100921\\170236495.jpg";
            Response.Write(FileHelper.GetFileName(bb));
            //Response.Write(KangHui.Common.StringHelper.SubSpecialLengthDecimal(a, 5));
        }
    }
    protected void aa_Click(object sender, EventArgs e)
    {
        FileHelper.UpdateFile("玩玩玩", "E:\\KangHuiClassLibrilay\\ClassLibraryTest\\aaa\\y.txt");
        FileHelper.AppendFile("我也是在测试呢，你在做啥呢？","E:\\KangHuiClassLibrilay\\ClassLibraryTest\\aaa\\x.txt");
       FileHelper.CreateDirectory("E:\\KangHuiClassLibrilay\\ClassLibraryTest\\aaa\\");
        Response.Write(Server.HtmlEncode(txtceshi.Text.Trim()));
        Response.Write(StringHelper.RemoveHtmlTag(txtceshi.Text.Trim()));
        // KangHui.Common.ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "IsPostBack", "Mail.aspx");
       //KangHui.Common.ScriptHelper.ShowOpenScript(this.aa, "Mail.aspx");
        
            string name = "E:\\KangHuiClassLibrilay\\ClassLibraryTest\\aaa\\aa.png";
            FileHelper.ReNameFile(name,"bb");
        //int b=a.IndexOf('.');
        //Response.Write(b.ToString());
        //ScriptHelper.ShowCustomScript(this.Page, "aa();");
    }
    //public static void ShowAlertAndCloseRefreshScript(Page page, string msg, string url)
    //{
    //    StringBuilder Builder = new StringBuilder();
    //    Builder.Append("<script language='javascript' defer>");
    //    Builder.AppendFormat("alert('{0}');", msg);
    //    Builder.AppendFormat("window.close();");
    //    if (url != "") Builder.AppendFormat("opener.location.href='{0}';", url);
    //    Builder.Append("</script>");
    //    page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
    //}
}
