using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KangHui.WebControls
{
    [Description("集成验证功能的字符串类型文本框控件")]
    [ValidationProperty("Text")]
    [ToolboxData("<{0}:StringTextBox runat=\"server\" Text=\"\"></{0}:StringTextBox>")]
    public class StringTextBox : WebControl, INamingContainer
    {
        private TextBox txtTextBoxValue;
        private RequiredFieldValidator valrTextBoxValue;
        private CustomValidator vallTextBoxValue;
        private RegularExpressionValidator valeTextBoxValue;

        private const string m_TelephoneNumberRegularExpression = "^(0\\d{2,3})?-?(\\d{7,8})(-\\d{3,6})?$";
        private const string m_MobilePhoneNumberRegularExpression = "^13[0-9]{9}$|^0{0,1}15[0-9]{1}[0-9]{8}$";
        private const string m_TelephoneOrMobilePhoneNumberRegularExpression = "^(0\\d{2,3})?-?(\\d{7,8})(-\\d{3,6})?$|^13[0-9]{9}$|^0{0,1}15[0-9]{1}[0-9]{8}$";
        private const string m_IDCardRegularExpression = "^[0-9]{17}[x,X,y,Y0-9]{1}$|^[0-9]{15}$";
        private const string m_PostCodeRegularExpression = "^\\d{6}$";
        private const string m_EmailRegularExpression = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";
        private const string m_ChineseRegularExpression = "^[\\u4e00-\\u9fa5]+$";

        public StringTextBox()
        {

        }

        #region 文本框相关属性

        [Category("文本框相关属性")]
        [DefaultValue("")]
        [Description("文本框的样式")]
        public override string CssClass
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.CssClass;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.CssClass = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(ValidatorDisplay.None)]
        [Description("验证程序的显示方式")]
        public ValidatorDisplay Display
        {
            get
            {
                this.EnsureChildControls();
                return valrTextBoxValue.Display;
            }
            set
            {
                this.EnsureChildControls();
                valrTextBoxValue.Display = value;
                vallTextBoxValue.Display = value;
                valeTextBoxValue.Display = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(typeof(Unit), "")]
        [Description("文本框的高度")]
        public override Unit Height
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.Height;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.Height = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(false)]
        [Description("文本框是否只读")]
        public bool ReadOnly
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.ReadOnly;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.ReadOnly = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(true)]
        [Description("控件无效时，验证程序是否在控件上设置焦点")]
        public bool SetFocusOnError
        {
            get
            {
                this.EnsureChildControls();
                return valrTextBoxValue.SetFocusOnError;
            }
            set
            {
                this.EnsureChildControls();
                valrTextBoxValue.SetFocusOnError = value;
                vallTextBoxValue.SetFocusOnError = value;
                valeTextBoxValue.SetFocusOnError = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue("")]
        [Description("文本框的文本")]
        public string Text
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.Text;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.Text = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue("")]
        [Description("验证程序所属的组")]
        public string ValidationGroup
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.ValidationGroup;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.ValidationGroup = value;
                valrTextBoxValue.ValidationGroup = value;
                vallTextBoxValue.ValidationGroup = value;
                valeTextBoxValue.ValidationGroup = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(TextBoxMode.SingleLine)]
        [Description("文本框的行为模式")]
        public TextBoxMode TextMode
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.TextMode;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.TextMode = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(typeof(Unit), "")]
        [Description("文本框的宽度")]
        public override Unit Width
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.Width;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.Width = value;
            }
        }

        #endregion

        #region 非空验证相关属性

        [Category("非空验证相关属性")]
        [DefaultValue(false)]
        [Description("是否启用非空验证")]
        public bool EnabledRequiredValidation
        {
            get
            {
                this.EnsureChildControls();
                return valrTextBoxValue.Enabled;
            }
            set
            {
                this.EnsureChildControls();
                valrTextBoxValue.Enabled = value;
            }
        }

        [Category("非空验证相关属性")]
        [DefaultValue("请输入一段文字！")]
        [Description("非空验证的错误信息")]
        public string RequiredErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return valrTextBoxValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                valrTextBoxValue.ErrorMessage = value;
            }
        }

        #endregion

        #region 长度验证相关属性

        [Category("长度验证相关属性")]
        [DefaultValue(eDataType.Varchar)]
        [Description("字段的数据类型")]
        public eDataType DataType
        {
            get
            {
                this.EnsureChildControls();
                switch (vallTextBoxValue.ClientValidationFunction.Replace(this.ID, ""))
                {
                    case "_ClientFunction":
                        return eDataType.Varchar;
                    case "_NClientFunction":
                        return eDataType.Nvarchar;
                    default:
                        return eDataType.Varchar;
                }
            }
            set
            {
                this.EnsureChildControls();
                switch (value)
                {
                    case eDataType.Varchar:
                        vallTextBoxValue.ClientValidationFunction = this.ID + "_ClientFunction";
                        break;
                    case eDataType.Nvarchar:
                        vallTextBoxValue.ClientValidationFunction = this.ID + "_NClientFunction";
                        break;
                }
            }
        }

        [Category("长度验证相关属性")]
        [DefaultValue("输入的文字超长！")]
        [Description("长度验证的错误信息")]
        public string LengthErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return vallTextBoxValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                vallTextBoxValue.ErrorMessage = value;
            }
        }

        [Category("长度验证相关属性")]
        [DefaultValue(0)]
        [Description("文本框可输入的最大字符数")]
        public int MaxLength
        {
            get
            {
                this.EnsureChildControls();
                return txtTextBoxValue.MaxLength;
            }
            set
            {
                this.EnsureChildControls();
                txtTextBoxValue.MaxLength = value;
                vallTextBoxValue.Enabled = (value > 0);
            }
        }

        #endregion

        #region 正则表达式验证相关属性

        [Category("正则表达式验证相关属性")]
        [DefaultValue(false)]
        [Description("是否启用正则表达式验证")]
        public bool EnabledRegularExpressionValidation
        {
            get
            {
                this.EnsureChildControls();
                return valeTextBoxValue.Enabled;
            }
            set
            {
                this.EnsureChildControls();
                valeTextBoxValue.Enabled = value;
            }
        }

        [Category("正则表达式验证相关属性")]
        [DefaultValue("输入的文字格式不正确！")]
        [Description("正则表达式验证的错误信息")]
        public string RegularExpressionErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return valeTextBoxValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                valeTextBoxValue.ErrorMessage = value;
            }
        }

        [Category("正则表达式验证相关属性")]
        [DefaultValue("")]
        [Description("用于确定有效性的正则表达式")]
        public string ValidationExpression
        {
            get
            {
                this.EnsureChildControls();
                return valeTextBoxValue.ValidationExpression;
            }
            set
            {
                this.EnsureChildControls();
                valeTextBoxValue.ValidationExpression = value;
            }
        }

        [Category("正则表达式验证相关属性")]
        [DefaultValue(eRegularExpressionType.Custom)]
        [Description("正则表达式验证类型")]
        public eRegularExpressionType RegularExpressionType
        {
            get
            {
                this.EnsureChildControls();
                switch (valeTextBoxValue.ValidationExpression)
                {
                    case m_EmailRegularExpression:
                        return eRegularExpressionType.Email;
                    case m_IDCardRegularExpression:
                        return eRegularExpressionType.IDCard;
                    case m_MobilePhoneNumberRegularExpression:
                        return eRegularExpressionType.MobilePhoneNumber;
                    case m_PostCodeRegularExpression:
                        return eRegularExpressionType.PostCode;
                    case m_TelephoneNumberRegularExpression:
                        return eRegularExpressionType.TelephoneNumber;
                    case m_TelephoneOrMobilePhoneNumberRegularExpression:
                        return eRegularExpressionType.TelephoneOrMobilePhoneNumber;
                    case m_ChineseRegularExpression:
                        return eRegularExpressionType.ChineseOnly;
                    default:
                        return eRegularExpressionType.Custom;
                }
            }
            set
            {
                this.EnsureChildControls();
                switch (value)
                {
                    case eRegularExpressionType.Email:
                        valeTextBoxValue.ValidationExpression = m_EmailRegularExpression;
                        break;
                    case eRegularExpressionType.IDCard:
                        valeTextBoxValue.ValidationExpression = m_IDCardRegularExpression;
                        break;
                    case eRegularExpressionType.MobilePhoneNumber:
                        valeTextBoxValue.ValidationExpression = m_MobilePhoneNumberRegularExpression;
                        break;
                    case eRegularExpressionType.PostCode:
                        valeTextBoxValue.ValidationExpression = m_PostCodeRegularExpression;
                        break;
                    case eRegularExpressionType.TelephoneNumber:
                        valeTextBoxValue.ValidationExpression = m_TelephoneNumberRegularExpression;
                        break;
                    case eRegularExpressionType.TelephoneOrMobilePhoneNumber:
                        valeTextBoxValue.ValidationExpression = m_TelephoneOrMobilePhoneNumberRegularExpression;
                        break;
                    case eRegularExpressionType.ChineseOnly:
                        valeTextBoxValue.ValidationExpression = m_ChineseRegularExpression;
                        break;
                    default:
                        valeTextBoxValue.ValidationExpression = "";
                        break;
                }
            }
        }

        #endregion
        
        protected override void CreateChildControls()
        {
            txtTextBoxValue = new TextBox();
            txtTextBoxValue.ID = this.ID + "_txtTextBoxValue";
            this.Controls.Add(txtTextBoxValue);

            valrTextBoxValue = new RequiredFieldValidator();
            valrTextBoxValue.ID = this.ID + "_valrTextBoxValue";
            valrTextBoxValue.ControlToValidate = txtTextBoxValue.ID;
            valrTextBoxValue.ErrorMessage = "请输入一段文字！";
            valrTextBoxValue.Display = ValidatorDisplay.None;
            valrTextBoxValue.SetFocusOnError = true;
            valrTextBoxValue.Enabled = false;
            this.Controls.Add(valrTextBoxValue);

            vallTextBoxValue = new CustomValidator();
            vallTextBoxValue.ID = this.ID + "_vallTextBoxValue";
            vallTextBoxValue.ControlToValidate = txtTextBoxValue.ID;
            vallTextBoxValue.ErrorMessage = "输入的文字超长！";
            vallTextBoxValue.Display = ValidatorDisplay.None;
            vallTextBoxValue.ClientValidationFunction = this.ID + "_ClientFunction";
            vallTextBoxValue.SetFocusOnError = true;
            vallTextBoxValue.Enabled = false;
            this.Controls.Add(vallTextBoxValue);

            valeTextBoxValue = new RegularExpressionValidator();
            valeTextBoxValue.ID = this.ID + "_valeTextBoxValue";
            valeTextBoxValue.ControlToValidate = txtTextBoxValue.ID;
            valeTextBoxValue.ErrorMessage = "输入的文字格式不正确！";
            valeTextBoxValue.Display = ValidatorDisplay.None;
            valeTextBoxValue.SetFocusOnError = true;
            valeTextBoxValue.Enabled = false;
            this.Controls.Add(valeTextBoxValue);

            base.CreateChildControls();
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            txtTextBoxValue.RenderControl(output);
            valrTextBoxValue.RenderControl(output);
            vallTextBoxValue.RenderControl(output);
            valeTextBoxValue.RenderControl(output);

            string strJs = @"
<script language='javascript'>
function " + this.ID + @"_GetByteLength()
{
    var iLen = 0;
    var str = document.getElementById('" + txtTextBoxValue.ClientID + @"').value;
    for(i = 0; i < str.length; i ++)
    {
	    if(str.charCodeAt(i) >= 8481 && str.charCodeAt(i) <= 63486)
	    {
		    iLen += 2;
	    }
	    else
	    {
		    iLen += 1;
	    }
    }
    return iLen;
}
function " + this.ID + @"_ClientFunction(source, arguments)
{
    if (" + this.ID + @"_GetByteLength() > " + MaxLength + @")
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}
function " + this.ID + @"_NClientFunction(source, arguments)
{
    if (document.getElementById('" + txtTextBoxValue.ClientID + @"').value.length > " + MaxLength + @")
        arguments.IsValid = false;
    else
        arguments.IsValid = true;
}
</script>
";

            output.Write(strJs);
        }
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum eDataType
    {
        Varchar,
        Nvarchar
    }

    /// <summary>
    /// 正则表达式类型
    /// </summary>
    public enum eRegularExpressionType
    {
        Custom,
        TelephoneNumber,
        MobilePhoneNumber,
        TelephoneOrMobilePhoneNumber,
        IDCard,
        PostCode,
        Email,
        ChineseOnly
    }
}
