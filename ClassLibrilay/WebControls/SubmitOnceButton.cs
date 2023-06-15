using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KangHui.WebControls
{
    [Description("只能在页面中提交一次的按钮")]
    [ToolboxData("<{0}:SubmitOnceButton runat=\"server\" Text=\"Button\"></{0}:SubmitOnceButton>")]
    public class SubmitOnceButton : Button
    {
        private string waitingText = "请稍候...";

        [Category("自定义属性")]
        [DefaultValue("请稍候...")]
        [Description("按钮等待时显示的文本")]
        public string WaitingText
        {
            get
            {
                return waitingText;
            }
            set
            {
                waitingText = value;
            }
        }

		protected override void Render(HtmlTextWriter writer)
		{
            this.Attributes.Add("onclick", "WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('" + this.ClientID + "', '', true, '', '', false, false));var flag=WebForm_OnSubmit();if(flag){ this.disabled = true; this.value = '" + waitingText + "';" + this.Page.ClientScript.GetPostBackEventReference(this, "") + ";}else{return false;}");
			base.Render(writer);	
		}
    }
}
