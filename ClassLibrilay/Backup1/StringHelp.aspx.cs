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

public partial class StringHelp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            string x = "我爱 中国 ab cd 12345";
            int a = x.Length;
            int b= System.Text.Encoding.Default.GetBytes(x).Length;
            decimal z = 123.14567M;
            string n = KangHui.Common.StringHelper.SubSpecialLengthDecimal(z, -1);

            string c = x.Substring(8);
            Response.Write(a.ToString()+";"+b.ToString()+";"+c+";"+n);
        }
    }
}
