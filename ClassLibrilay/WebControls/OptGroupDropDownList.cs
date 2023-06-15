using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace KangHui.WebControls
{
    public class OptGroupDropDownList : DropDownList
    {
        /// <summary>
        /// �������SmartDropDownList�ķ������ListItem��Valueֵ
        /// </summary>
        public virtual string OptionGroupValue
        {
            get
            {
                string s = (string)ViewState["OptionGroupValue"];

                return (s == null) ? "optgroup" : s;
            }
            set
            {
                ViewState["OptionGroupValue"] = value;
            }
        }


        public OptGroupDropDownList()
        { }

        /// <summary>
        /// ���ؼ������ݳ��ֵ�ָ���ı�д����
        /// </summary>
        /// <param name="writer">writer</param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
            // ����Option��OptionGroup
            OptionGroupRenderContents(writer);
        }

        /// <summary>
        /// ����Option��OptionGroup
        /// </summary>
        /// <param name="writer">writer</param>
        private void OptionGroupRenderContents(HtmlTextWriter writer)
        {
            // �Ƿ���Ҫ����OptionGroup��EndTag
            bool writerEndTag = false;

            foreach (ListItem li in this.Items)
            {
                // ���û��optgroup���������Option
                if (li.Value != this.OptionGroupValue)
                {
                    // ����Option
                    RenderListItem(li, writer);
                }
                // �����optgroup���������OptionGroup
                else
                {
                    if (writerEndTag)
                        // ����OptionGroup��EndTag
                        OptionGroupEndTag(writer);
                    else
                        writerEndTag = true;

                    // ����OptionGroup��BeginTag
                    OptionGroupBeginTag(li, writer);
                }
            }

            if (writerEndTag)
                // ����OptionGroup��EndTag
                OptionGroupEndTag(writer);
        }

        /// <summary>
        /// ����OptionGroup��BeginTag
        /// </summary>
        /// <param name="li">OptionGroup������</param>
        /// <param name="writer">writer</param>
        private void OptionGroupBeginTag(ListItem li, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("optgroup");

            // д��OptionGroup��label
            writer.WriteAttribute("label", li.Text);

            foreach (string key in li.Attributes.Keys)
            {
                // д��OptionGroup����������
                writer.WriteAttribute(key, li.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);
            writer.WriteLine();
        }

        /// <summary>
        /// ����OptionGroup��EndTag
        /// </summary>
        /// <param name="writer">writer</param>
        private void OptionGroupEndTag(HtmlTextWriter writer)
        {
            writer.WriteEndTag("optgroup");
            writer.WriteLine();
        }

        /// <summary>
        /// ����Option
        /// </summary>
        /// <param name="li">Option������</param>
        /// <param name="writer">writer</param>
        private void RenderListItem(ListItem li, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("option");

            // д��Option��Value
            writer.WriteAttribute("value", li.Value, true);

            if (li.Selected)
            {
                // �����Option��ѡ����д��selected
                writer.WriteAttribute("selected", "selected", false);
            }

            foreach (string key in li.Attributes.Keys)
            {
                // д��Option����������
                writer.WriteAttribute(key, li.Attributes[key]);
            }

            writer.Write(HtmlTextWriter.TagRightChar);

            // д��Option��Text
            HttpUtility.HtmlEncode(li.Text, writer);

            writer.WriteEndTag("option");
            writer.WriteLine();
        }
    }
}
