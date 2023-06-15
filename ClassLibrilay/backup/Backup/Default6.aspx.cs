using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using log4net;

public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Ucar.Common.StringHelper.InvalidStringFilter("aaaSeLeCTsss"));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ILog log = LogManager.GetLogger("test");
        //log.Info(DateTime.Now.ToString() + "执行了log4net的Info方法", new Exception("抛出了自定义的异常"));
        
    }
}
