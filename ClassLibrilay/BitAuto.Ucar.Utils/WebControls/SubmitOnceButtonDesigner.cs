using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace BitAuto.Ucar.Utils.WebControls
{
    internal class SubmitOnceButtonDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();
                actionLists.Add(new MarqueePanelActionList(this.Component));
                return actionLists;
            }
        }
    }

    internal class SubmitOnceButtonActionList : DesignerActionList
    {
        private SubmitOnceButton m_SubmitOnceButton;

        public SubmitOnceButtonActionList(IComponent component)
            : base(component)
        {
            m_SubmitOnceButton = component as SubmitOnceButton;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();
            actionItems.Add(new DesignerActionHeaderItem("自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("WaitingText", "单击提交后，按钮上所显示的文本", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("ValidateScriptFunction", "执行客户端验证的脚本方法", "自定义属性"));
            return actionItems;
        }

        public string WaitingText
        {
            get
            {
                return m_SubmitOnceButton.WaitingText;
            }
            set
            {
                SetProperty("WaitingText", value);
            }
        }

        public string ValidateScriptFunction
        {
            get
            {
                return m_SubmitOnceButton.ValidateScriptFunction;
            }
            set
            {
                SetProperty("ValidateScriptFunction", value);
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(m_SubmitOnceButton)[propertyName];
            property.SetValue(m_SubmitOnceButton, value);
        }
    }
}
