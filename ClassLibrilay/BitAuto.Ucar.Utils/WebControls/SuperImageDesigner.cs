using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using KangHui.JianHui.Utils.Imaging;
using KangHui.JianHui.Utils.Imaging.WebControls;

namespace KangHui.JianHui.Utils.WebControls
{
    internal class SuperImageDesigner : ControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();
                actionLists.Add(new SuperImageActionList(this.Component));
                return actionLists;
            }
        }
    }

    internal class SuperImageActionList : DesignerActionList
    {
        private SuperImage m_Image;

        public SuperImageActionList(IComponent component)
            : base(component)
        {
            m_Image = component as SuperImage;
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();
            actionItems.Add(new DesignerActionHeaderItem("自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("ImageType", "图片类型", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("MicroImageType", "缩略图片类型", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("ChildFolder", "图片子目录", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("DefaultImagePath", "默认图片路径", "自定义属性"));
            actionItems.Add(new DesignerActionPropertyItem("ImageDbPath", "图片在数据库储存的路径", "自定义属性"));
            return actionItems;
        }

        public ImageType ImageType
        {
            get
            {
                return m_Image.ImageType;
            }
            set
            {
                SetProperty("ImageType", value);
            }
        }

        public MicroImageType MicroImageType
        {
            get
            {
                return m_Image.MicroImageType;
            }
            set
            {
                SetProperty("MicroImageType", value);
            }
        }

        public string ChildFolder
        {
            get
            {
                return m_Image.ChildFolder;
            }
            set
            {
                SetProperty("ChildFolder", value);
            }
        }

        public string DefaultImagePath
        {
            get
            {
                return m_Image.DefaultImagePath;
            }
            set
            {
                SetProperty("DefaultImagePath", value);
            }
        }

        public string ImageDbPath
        {
            get
            {
                return m_Image.ImageDbPath;
            }
            set
            {
                SetProperty("ImageDbPath", value);
            }
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(m_Image)[propertyName];
            property.SetValue(m_Image, value);
        }
    }
}
