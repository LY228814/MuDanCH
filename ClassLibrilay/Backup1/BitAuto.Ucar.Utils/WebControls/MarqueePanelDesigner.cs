using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace KangHui.JianHui.Utils.WebControls
{
    internal class MarqueePanelDesigner : ControlDesigner
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

    internal class MarqueePanelActionList : DesignerActionList
    {
        private MarqueePanel m_MarqueePanel;

        public MarqueePanelActionList(IComponent component)
            : base(component)
        {
            m_MarqueePanel = component as MarqueePanel;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();
            actionItems.Add(new DesignerActionHeaderItem("自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("InnerHtml", "滚动内容的HTML代码", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("Width", "控件的宽度", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("Height", "控件的高度", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("Speed", "移动的速度", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("MarqueeDirection", "内容移动的方向", "自定义属性"));
            return actionItems;
        }

        public string InnerHtml
        {
            get
            {
                return m_MarqueePanel.InnerHtml;
            }
            set
            {
                SetProperty("InnerHtml", value);
            }
        }

        public Unit Width
        {
            get
            {
                return m_MarqueePanel.Width;
            }
            set
            {
                SetProperty("Width", value);
            }
        }

        public Unit Height
        {
            get
            {
                return m_MarqueePanel.Height;
            }
            set
            {
                SetProperty("Height", value);
            }
        }

        public int Speed
        {
            get
            {
                return m_MarqueePanel.Speed;
            }
            set
            {
                SetProperty("Speed", value);
            }
        }

        public MarqueeDirection MarqueeDirection
        {
            get
            {
                return m_MarqueePanel.MarqueeDirection;
            }
            set
            {
                SetProperty("MarqueeDirection", value);
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(m_MarqueePanel)[propertyName];
            property.SetValue(m_MarqueePanel, value);
        }
    }
}
