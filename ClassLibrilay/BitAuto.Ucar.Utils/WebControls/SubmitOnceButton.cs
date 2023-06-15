using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BitAuto.Ucar.Utils.WebControls
{
    /// <summary>
    /// 表示一个防止重复提交的按钮。当用户单击按钮以后，该按钮变灰，不能再次单击，直到重新加载页面或者跳转。
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SubmitOnceButton runat=\"server\"></{0}:SubmitOnceButton>")]
    [Designer(typeof(SubmitOnceButtonDesigner))]
    public class SubmitOnceButton : Button
    {
        /// <summary>
        /// 默认的构造函数。
        /// </summary>
        public SubmitOnceButton()
        {
            this.ViewState["afterSubmitText"] = "请稍候...";
            base.Text = "SubmitOnceButton";
            this.ViewState["validateScriptFunction"] = "";
        }

        /// <summary>
        /// 获取或设置单击按钮后，按钮上所显示的文本。
        /// </summary>
        [Bindable(true),
        Category("自定义属性"),
        DefaultValue("请稍候..."),
        Description("指示单击提交后，按钮上所显示的文本。")]
        public string WaitingText
        {
            get
            {
                string afterSubmitText = (string)this.ViewState["afterSubmitText"];
                if (afterSubmitText != null)
                {
                    return afterSubmitText;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                this.ViewState["afterSubmitText"] = value;
            }
        }

        /// <summary>
        /// 获取或设置执行客户端验证的脚本方法。
        /// </summary>
        [Bindable(true),
        Category("自定义属性"),
        DefaultValue(""),
        Description("指示执行客户端验证的脚本方法。")]
        public string ValidateScriptFunction
        {
            get
            {
                return (string)this.ViewState["validateScriptFunction"];
            }
            set
            {
                string formatValue = value.TrimEnd(new char[] { ';' });
                this.ViewState["validateScriptFunction"] = formatValue;
                if (!string.IsNullOrEmpty(formatValue) & !formatValue.EndsWith("()"))
                {
                    this.ViewState["validateScriptFunction"] += "()";
                }
            }
        }

        /// <summary>
        /// AddAttributesToRender
        /// </summary>
        /// <param name="writer">HtmlTextWriter</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            StringBuilder ClientSideEventReference = new StringBuilder();

            if (((this.Page != null) && this.CausesValidation) && (this.Page.Validators.Count > 0))
            {
                ClientSideEventReference.Append("if (typeof(Page_ClientValidate) == 'function'){if (Page_ClientValidate() == false){return false;}}");
            }

            string text = this.Text;
            ClientSideEventReference.AppendFormat("this.value='{0}';", (string)this.ViewState["afterSubmitText"]);
            ClientSideEventReference.Append("this.disabled=true;");
            if (!string.IsNullOrEmpty(ValidateScriptFunction))
            {
                ClientSideEventReference.Append("var flag=" + ValidateScriptFunction + ";if(!flag){this.disabled=false;this.value='" + text + "';return false;}");
            }
            ClientSideEventReference.Append(this.Page.ClientScript.GetPostBackEventReference(this, string.Empty));

            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, ClientSideEventReference.ToString(), true);
            base.AddAttributesToRender(writer);
        }
    }
}
