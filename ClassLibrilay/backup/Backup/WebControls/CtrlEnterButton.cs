using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucar.WebControls
{
    [Description("按Ctrl和Enter键可以触发点击事件的按钮控件")]
    [ToolboxData("<{0}:CtrlEnterButton runat=\"server\"></{0}:CtrlEnterButton>")]
    public class CtrlEnterButton : Button
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ID + "_StartupScript", "<script>document.body.onkeypress = " + this.ID + "_CheckKeyCode;</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), this.ID + "_ClientScriptBlock", "<script>function " + this.ID + "_CheckKeyCode() { if(window.event.keyCode == 10) { document.getElementById(\"" + this.ClientID + "\").click(); } }</script>");
        }
    }
}
