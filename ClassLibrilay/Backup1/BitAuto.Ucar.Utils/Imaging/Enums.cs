using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.JianHui.Utils.Imaging
{
    #region 图片类型
    /// <summary>
    /// 图片类型
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        /// 优卡车源图片
        /// </summary>
        UcarImage,

        /// <summary>
        /// 车商通车源图片
        /// </summary>
        TranstarUcarImage,

        /// <summary>
        /// 经销商图片
        /// </summary>
        VendorImage,

        /// <summary>
        /// 经销商Logo图片
        /// </summary>
        VendorLogoImage,

        /// <summary>
        /// 个人图片
        /// </summary>
        PersonalImage,

        /// <summary>
        /// 无需压缩的图片
        /// </summary>
        NoCompressionImage
    }
    #endregion

    #region 缩略图类型
    /// <summary>
    /// 缩略图类型
    /// </summary>
    public enum MicroImageType
    {
        /// <summary>
        /// 微图
        /// </summary>
        Smaller,

        /// <summary>
        /// 小图
        /// </summary>
        Small,

        /// <summary>
        /// 中图
        /// </summary>
        Middle,

        /// <summary>
        /// 大图
        /// </summary>
        Big,

        /// <summary>
        /// 原图
        /// </summary>
        Source
    }
    #endregion

    #region 水印类型
    /// <summary>
    /// 水印类型
    /// </summary>
    internal enum WaterMarkType
    {
        /// <summary>
        /// 图片
        /// </summary>
        Image,

        /// <summary>
        /// 文字
        /// </summary>
        Text
    }
    #endregion

    #region 图片水印的位置
    /// <summary>
    /// 图片水印的位置
    /// </summary>
    internal enum WaterMarkPosition
    {
        /// <summary>
        /// 左上方
        /// </summary>
        TopLeft,

        /// <summary>
        /// 右上方
        /// </summary>
        TopRight,

        /// <summary>
        /// 左下方
        /// </summary>
        BottomLeft,

        /// <summary>
        /// 右下方
        /// </summary>
        BottomRight
    }
    #endregion
}
