using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using KangHui.JianHui.Utils.Common;
using KangHui.JianHui.Utils.Imaging;
using KangHui.JianHui.Utils.Imaging.BaseClass;

[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_100x75.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_180x180.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_250x187.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_300x225.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_56x56.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_80x60.jpg", "image/jpg")]
[assembly: WebResource("KangHui.JianHui.Utils.Imaging.WebResource.Default_85x85.jpg", "image/jpg")]

namespace KangHui.JianHui.Utils.WebControls
{
    /// <summary>
    /// 自定义的图片显示控件
    /// </summary>
    [Description("自定义的图片显示控件")]
    [Designer(typeof(SuperImageDesigner))]
    [ToolboxData("<{0}:SuperImage runat=\"server\"></{0}:SuperImage>")]
    public class SuperImage : Image
    {
        #region 图片服务器的网络路径
        /// <summary>
        /// 图片服务器的网络路径（默认读取配置文件appSettings节点下key为ImageServerPath的配置）
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("图片服务器的网络路径")]
        [Localizable(true)]
        public string ImageServerPath
        {
            get
            {
                String s = (String)ViewState["ImageServerPath"];
                if (string.IsNullOrEmpty(s))
                {
                    s = ConfigurationManager.AppSettings["ImageServerPath"];
                }
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ImageServerPath"] = value;
            }
        }
        #endregion

        #region 图片子目录
        /// <summary>
        /// 图片子目录
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("图片子目录")]
        [Localizable(true)]
        public string ChildFolder
        {
            get
            {
                String s = (String)ViewState["ChildFolder"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ChildFolder"] = value;
            }
        }
        #endregion

        #region 图片在数据库储存的路径
        /// <summary>
        /// 图片在数据库储存的路径
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("图片在数据库储存的路径")]
        [Localizable(true)]
        public string ImageDbPath
        {
            get
            {
                String s = (String)ViewState["ImageDbPath"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ImageDbPath"] = value;
            }
        }
        #endregion

        #region 默认图片的网络路径
        /// <summary>
        /// 默认图片的网络路径
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("默认图片的网络路径")]
        [Localizable(true)]
        public string DefaultImagePath
        {
            get
            {
                String s = (String)ViewState["DefaultImagePath"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["DefaultImagePath"] = value;
            }
        }
        #endregion

        #region 图片类型
        /// <summary>
        /// 图片类型
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("图片类型")]
        [Localizable(true)]
        public ImageType ImageType
        {
            get
            {
                return (ViewState["ImageType"] == null) ? ImageType.NoCompressionImage : (ImageType)ViewState["ImageType"];
            }
            set
            {
                ViewState["ImageType"] = value;
            }
        }
        #endregion

        #region 缩略图片类型
        /// <summary>
        /// 缩略图片类型
        /// </summary>
        [Bindable(true)]
        [Category("自定义属性")]
        [Description("缩略图片类型")]
        [Localizable(true)]
        public MicroImageType MicroImageType
        {
            get
            {
                return (ViewState["MicroImageType"] == null) ? MicroImageType.Source : (MicroImageType)ViewState["MicroImageType"];
            }
            set
            {
                ViewState["MicroImageType"] = value;
            }
        }
        #endregion

        #region 将控件呈现给指定的HTML编写器
        /// <summary>
        /// 将控件呈现给指定的HTML编写器
        /// </summary>
        /// <param name="writer">控件输出流</param>
        protected override void Render(HtmlTextWriter writer)
        {
            //格式化图片服务器网络路径
            if (!string.IsNullOrEmpty(this.ImageServerPath))
            {
                this.ImageServerPath = this.ImageServerPath.Replace(@"\", "/");
                if (!this.ImageServerPath.EndsWith("/"))
                {
                    this.ImageServerPath += "/";
                }
            }

            //格式化图片子目录
            if (!string.IsNullOrEmpty(this.ChildFolder))
            {
                this.ChildFolder = this.ChildFolder.Replace(@"\", "/");
                this.ChildFolder = this.ChildFolder.TrimStart(new char[] { '/' });
                if (!this.ChildFolder.EndsWith("/"))
                {
                    this.ChildFolder += "/";
                }
            }

            ImageBase image = ImageFactory.GetInstance(this.ImageType);

            //加缩略图后缀名
            if (!string.IsNullOrEmpty(this.ImageDbPath))
            {
                int index = this.ImageDbPath.LastIndexOf(".");
                if (index < 0)
                {
                    index = this.ImageDbPath.Length;
                }
                string prefixPath = this.ImageDbPath.Substring(0, index);
                string suffixPath = FileHelper.GetSuffix(this.ImageDbPath);
                string suffix = string.Empty;
                switch (this.MicroImageType)
                {
                    case MicroImageType.Smaller:
                        suffix = image.SmallerSuffix;
                        break;
                    case MicroImageType.Small:
                        suffix = image.SmallSuffix;
                        break;
                    case MicroImageType.Middle:
                        suffix = image.MiddleSuffix;
                        break;
                    case MicroImageType.Big:
                        suffix = image.BigSuffix;
                        break;
                }
                this.ImageDbPath = prefixPath + suffix + suffixPath;
            }

            //确定图片显示的路径
            if (string.IsNullOrEmpty(this.ImageUrl))
            {
                if (this.ImageDbPath.StartsWith("http://"))
                {
                    this.ImageUrl = this.ImageDbPath;
                }
                else
                {
                    this.ImageUrl = this.ImageServerPath + this.ChildFolder + this.ImageDbPath;
                }
            }

            //确定图片默认路径
            if (string.IsNullOrEmpty(this.DefaultImagePath))
            {
                string defaultUrl = string.Empty;
                switch (this.MicroImageType)
                {
                    case MicroImageType.Smaller:
                        defaultUrl = image.SmallerDefaultImage;
                        break;
                    case MicroImageType.Small:
                        defaultUrl = image.SmallDefaultImage;
                        break;
                    case MicroImageType.Middle:
                        defaultUrl = image.MiddleDefaultImage;
                        break;
                    case MicroImageType.Big:
                        defaultUrl = image.BigDefaultImage;
                        break;
                }
                if (!string.IsNullOrEmpty(defaultUrl))
                {
                    DefaultImagePath = Page.ClientScript.GetWebResourceUrl(GetType(), defaultUrl);
                }
            }

            //加入onerror事件
            if (!string.IsNullOrEmpty(this.DefaultImagePath))
            {
                this.Attributes.Add("onerror", "this.onerror='';this.src='" + DefaultImagePath + "';");
            }

            base.Render(writer);
        }
        #endregion
    }
}
