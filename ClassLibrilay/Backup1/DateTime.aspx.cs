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
using System.IO;
public partial class DateTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            TimeSpan ts = KangHui.Common.DateTimeHelper.DateDiff2(Convert.ToDateTime("2011/5/15 13:00:00"), Convert.ToDateTime("2012/5/16 14:00:00"));
            Response.Write("总共" + ts.Days + "天；总共" + ts.Hours + "小时");

            string x = KangHui.Common.FileHelper.GetFileName("F:\\AllProject090219\\ClassLibraryTest\\DateTime.aspx");
            Response.Write(x);


            string z = "F:\\AllProject090219\\ClassLibraryTest\\DateTime.aspx";
            Response.Write(Path.GetExtension(z)+"<br />");
            Response.Write(Path.GetFileName(z));
            Directory.CreateDirectory("D:\\myaaaaaa");
            File.Create("D:\\myaaaaaa\\a.txt");
        }
    }
}
