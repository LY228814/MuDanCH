using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KangHui.WebControls
{
    [Description("集成验证功能的数字类型文本框控件")]
    [ValidationProperty("Text")]
    [ToolboxData("<{0}:NumericTextBox runat=\"server\" Text=\"\"></{0}:NumericTextBox>")]
    public class NumericTextBox : WebControl, INamingContainer
    {
        private TextBox txtNumberValue;
        private RequiredFieldValidator valrNumberValue;
        private RangeValidator valgNumberValue;
        private RegularExpressionValidator valeNumberValue;

        private readonly string maxValue = int.MaxValue.ToString();
        private readonly string minValue = "0";

        private int integerLength = 8;
        private int decimalLength = 2;
        
        private string integerExpression = "^\\d{0,<!--integerLength-->}$";
        private string decimalExpression = "^\\d{0,<!--integerLength-->}([.]{1}\\d{1,<!--decimalLength-->})?$";

        public NumericTextBox()
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
                return txtNumberValue.CssClass;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.CssClass = value;
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
                return valrNumberValue.Display;
            }
            set
            {
                this.EnsureChildControls();
                valrNumberValue.Display = value;
                valgNumberValue.Display = value;
                valeNumberValue.Display = value;
            }
        }

        [Category("文本框相关属性")]
        [DefaultValue(0)]
        [Description("文本框可输入的最大字符数")]
        public int MaxLength
        {
            get
            {
                this.EnsureChildControls();
                return txtNumberValue.MaxLength;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.MaxLength = value;
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
                return txtNumberValue.ReadOnly;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.ReadOnly = value;
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
                return valrNumberValue.SetFocusOnError;
            }
            set 
            {
                this.EnsureChildControls();
                valrNumberValue.SetFocusOnError = value;
                valgNumberValue.SetFocusOnError = value;
                valeNumberValue.SetFocusOnError = value;
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
                return txtNumberValue.Text;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.Text = value;
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
                return txtNumberValue.ValidationGroup;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.ValidationGroup = value;
                valrNumberValue.ValidationGroup = value;
                valgNumberValue.ValidationGroup = value;
                valeNumberValue.ValidationGroup = value;
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
                return txtNumberValue.Width;
            }
            set
            {
                this.EnsureChildControls();
                txtNumberValue.Width = value;
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
                return valrNumberValue.Enabled;
            }
            set
            {
                this.EnsureChildControls();
                valrNumberValue.Enabled = value;
            }
        }

        [Category("非空验证相关属性")]
        [DefaultValue("请输入一段数字！")]
        [Description("非空验证的错误信息")]
        public string RequiredErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return valrNumberValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                valrNumberValue.ErrorMessage = value;
            }
        }

        #endregion

        #region 类型验证相关属性

        [Category("类型验证相关属性")]
        [DefaultValue(2)]
        [Description("小数部分的数字长度")]
        public int DecimalLength
        {
            get
            {
                return decimalLength;
            }
            set
            {
                decimalLength = value;
                if (value <= 0) decimalLength = 1;
                switch (NumberType)
                {
                    case eNumberType.Integer:
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", IntegerLength.ToString());
                        break;
                    case eNumberType.Decimal:
                        valeNumberValue.ValidationExpression = decimalExpression.Replace("<!--integerLength-->", IntegerLength.ToString()).Replace("<!--decimalLength-->", value.ToString());
                        break;
                    default:
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", IntegerLength.ToString());
                        break;
                }
            }
        }
        
        [Category("类型验证相关属性")]
        [DefaultValue(8)]
        [Description("整数部分的数字长度")]
        public int IntegerLength
        {
            get 
            {
                return integerLength;
            }
            set 
            {
                integerLength = value;
                if (value <= 0) integerLength = 1;
                switch (NumberType)
                {
                    case eNumberType.Integer:
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", value.ToString());
                        break;
                    case eNumberType.Decimal:
                        valeNumberValue.ValidationExpression = decimalExpression.Replace("<!--integerLength-->", value.ToString()).Replace("<!--decimalLength-->", DecimalLength.ToString());
                        break;
                    default:
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", value.ToString());
                        break;
                }
            }
        }
        
        [Category("类型验证相关属性")]
        [DefaultValue(eNumberType.Integer)]
        [Description("要进行验证的数据类型")]
        public eNumberType NumberType
        {
            get
            {
                this.EnsureChildControls();
                switch (valgNumberValue.Type)
                {
                    case ValidationDataType.Integer:
                        return eNumberType.Integer;
                    case ValidationDataType.Double:
                        return eNumberType.Decimal;
                    default:
                        return eNumberType.Integer;
                }
            }
            set
            {
                this.EnsureChildControls();
                switch (value)
                {
                    case eNumberType.Integer:
                        valgNumberValue.Type = ValidationDataType.Integer;
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", IntegerLength.ToString());
                        txtNumberValue.Attributes["onkeypress"] = "return event.keyCode>=48&&event.keyCode<=57;";
                        break;
                    case eNumberType.Decimal:
                        valgNumberValue.Type = ValidationDataType.Double;
                        valeNumberValue.ValidationExpression = decimalExpression.Replace("<!--integerLength-->", IntegerLength.ToString()).Replace("<!--decimalLength-->", DecimalLength.ToString());
                        txtNumberValue.Attributes["onkeypress"] = "return event.keyCode>=48&&event.keyCode<=57||(event.keyCode==46);";
                        break;
                    default:
                        valgNumberValue.Type = ValidationDataType.Integer;
                        valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", IntegerLength.ToString());
                        txtNumberValue.Attributes["onkeypress"] = "return event.keyCode>=48&&event.keyCode<=57;";
                        break;
                }
            }
        }

        [Category("类型验证相关属性")]
        [DefaultValue("输入的数字类型不正确！")]
        [Description("类型验证的错误信息")]
        public string TypeErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return valeNumberValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                valeNumberValue.ErrorMessage = value;
            }
        }

        #endregion

        #region 范围验证相关属性

        [Category("范围验证相关属性")]
        [DefaultValue(false)]
        [Description("是否启用范围验证")]
        public bool EnabledRangeValidation
        {
            get
            {
                this.EnsureChildControls();
                return valgNumberValue.Enabled;
            }
            set
            {
                this.EnsureChildControls();
                valgNumberValue.Enabled = value;
            }
        }
        
        [Category("范围验证相关属性")]
        [DefaultValue("输入的数字超出范围！")]
        [Description("范围验证的错误信息")]
        public string RangeErrorMessage
        {
            get
            {
                this.EnsureChildControls();
                return valgNumberValue.ErrorMessage;
            }
            set
            {
                this.EnsureChildControls();
                valgNumberValue.ErrorMessage = value;
            }
        }

        [Category("范围验证相关属性")]
        [DefaultValue(int.MaxValue)]
        [Description("所验证控件的最大值")]
        public string MaximumValue
        {
            get
            {
                this.EnsureChildControls();
                return valgNumberValue.MaximumValue;
            }
            set
            {
                this.EnsureChildControls();
                valgNumberValue.MaximumValue = value;
            }
        }

        [Category("范围验证相关属性")]
        [DefaultValue(0)]
        [Description("所验证控件的最小值")]
        public string MinimumValue
        {
            get
            {
                this.EnsureChildControls();
                return valgNumberValue.MinimumValue;
            }
            set
            {
                this.EnsureChildControls();
                valgNumberValue.MinimumValue = value;
            }
        }

        #endregion   

        protected override void CreateChildControls()
        {
            txtNumberValue = new TextBox();
            txtNumberValue.ID = this.ID + "_txtNumberValue";
            txtNumberValue.Attributes["onkeypress"] = "return event.keyCode>=48&&event.keyCode<=57;";
            this.Controls.Add(txtNumberValue);

            valrNumberValue = new RequiredFieldValidator();
            valrNumberValue.ID = this.ID + "_valrNumberValue";
            valrNumberValue.ControlToValidate = txtNumberValue.ID;
            valrNumberValue.Display = ValidatorDisplay.None;
            valrNumberValue.ErrorMessage = "请输入一段数字！";
            valrNumberValue.SetFocusOnError = true;
            valrNumberValue.Enabled = false;
            this.Controls.Add(valrNumberValue);

            valgNumberValue = new RangeValidator();
            valgNumberValue.ID = this.ID + "_valgNumberValue";
            valgNumberValue.ControlToValidate = txtNumberValue.ID;
            valgNumberValue.Display = ValidatorDisplay.None;
            valgNumberValue.ErrorMessage = "输入的数字超出范围！";
            valgNumberValue.Type = ValidationDataType.Integer;
            valgNumberValue.MaximumValue = maxValue;
            valgNumberValue.MinimumValue = minValue;
            valgNumberValue.SetFocusOnError = true;
            valgNumberValue.Enabled = false;
            this.Controls.Add(valgNumberValue);

            valeNumberValue = new RegularExpressionValidator();
            valeNumberValue.ID = this.ID + "_valeNumberValue";
            valeNumberValue.ControlToValidate = txtNumberValue.ID;
            valeNumberValue.Display = ValidatorDisplay.None;
            valeNumberValue.ErrorMessage = "输入的数字类型不正确！";
            valeNumberValue.ValidationExpression = integerExpression.Replace("<!--integerLength-->", IntegerLength.ToString());
            valeNumberValue.SetFocusOnError = true;
            this.Controls.Add(valeNumberValue);
            
            base.CreateChildControls();
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            txtNumberValue.RenderControl(output);
            valrNumberValue.RenderControl(output);
            valgNumberValue.RenderControl(output);
            valeNumberValue.RenderControl(output);
        }
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    public enum eNumberType
    {
        Integer,
        Decimal
    }
}
