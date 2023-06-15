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
    internal class ClientCalendarDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();
                actionLists.Add(new ClientCalendarActionList(this.Component));
                return actionLists;
            }
        }
    }

    internal class ClientCalendarActionList : DesignerActionList
    {
        private ClientCalendar m_Calendar;

        public ClientCalendarActionList(IComponent component)
            : base(component)
        {
            m_Calendar = component as ClientCalendar;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();
            actionItems.Add(new DesignerActionHeaderItem("自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("IsWrite", "是否可以写入日期", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("DefaultYear", "默认选择年份", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("DefaultMonth", "默认选择月份", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("BeforeDefaultYearCount", "默认选择年份之前的年数", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("AfterDefaultYearCount", "默认选择年份之后的年数", "自定义属性"));
            return actionItems;
        }

        public bool IsWrite
        {
            get
            {
                return m_Calendar.IsWrite;
            }
            set
            {
                SetProperty("IsWrite", value);
            }
        }

        public int DefaultYear
        {
            get
            {
                return m_Calendar.DefaultYear;
            }
            set
            {
                SetProperty("DefaultYear", value);
            }
        }

        public int DefaultMonth
        {
            get
            {
                return m_Calendar.DefaultMonth;
            }
            set
            {
                SetProperty("DefaultMonth", value);
            }
        }

        public int BeforeDefaultYearCount
        {
            get
            {
                return m_Calendar.BeforeDefaultYearCount;
            }
            set
            {
                SetProperty("BeforeDefaultYearCount", value);
            }
        }

        public int AfterDefaultYearCount
        {
            get
            {
                return m_Calendar.AfterDefaultYearCount;
            }
            set
            {
                SetProperty("AfterDefaultYearCount", value);
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(m_Calendar)[propertyName];
            property.SetValue(m_Calendar, value);
        }
    }
}
