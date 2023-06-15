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
using Ucar.Common;
using Ucar.BaseClass;

public partial class Default2 : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(StringHelper.GetSmallCurrentDateString());
        //MarqueePanel1.InnerHtml = @"<img src='image/2007420113430859_small.jpg'>&nbsp;<img src='image/2007420114232437_small.jpg'>&nbsp;<img src='image/200742011472162_small.jpg'>&nbsp;<img src='image/2007420115233765_small.jpg'>&nbsp;<img src='image/2007420115324453_small.jpg'>&nbsp;<img src='image/2007420115447687_small.jpg'>&nbsp;<img src='image/2007420115559406_small.jpg'>&nbsp;<img src='image/200742011833109_small.jpg'>&nbsp;";
    }
    protected void CtrlEnterButton1_Click(object sender, EventArgs e)
    {
        ScriptHelper.ShowAlertScript(this, StringTextBox1.Text);
    }
}
