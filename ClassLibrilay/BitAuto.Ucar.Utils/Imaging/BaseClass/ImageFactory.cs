using System;
using System.Collections.Generic;
using System.Text;

using KangHui.JianHui.Utils.Imaging.ImplClass;

namespace KangHui.JianHui.Utils.Imaging.BaseClass
{
    /// <summary>
    /// 图片工厂类
    /// </summary>
    internal class ImageFactory
    {
        #region 实例化对象的方法
        /// <summary>
        /// 实例化对象的方法
        /// </summary>
        /// <param name="imageType">图片类型</param>
        /// <returns>实例化的对象</returns>
        public static ImageBase GetInstance(ImageType imageType)
        {
            switch (imageType)
            {
                case ImageType.PersonalImage:
                    return new PersonalImage();
                case ImageType.UcarImage:
                    return new UcarImage();
                case ImageType.TranstarUcarImage:
                    return new TranstarUcarImage();
                case ImageType.VendorImage:
                    return new VendorImage();
                case ImageType.VendorLogoImage:
                    return new VendorLogoImage();
                default:
                    return new NoCompressionImage();
            }
        }
        #endregion
    }
}
