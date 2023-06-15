using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// 微图配置的接口类
    /// </summary>
    internal interface ISmallerImage
    {
        /// <summary>
        /// 微图规格
        /// </summary>
        Size SmallerSize { get; }

        /// <summary>
        /// 是否需要微图
        /// </summary>
        bool NeedSmallerImage { get; }

        /// <summary>
        /// 是否需要微图水印
        /// </summary>
        bool NeedSmallerWaterMark { get; }

        /// <summary>
        /// 是否需要微图背景
        /// </summary>
        bool NeedSmallerBackGround { get; }

        /// <summary>
        /// 微图后缀名
        /// </summary>
        string SmallerSuffix { get; }

        /// <summary>
        /// 微图水印类型
        /// </summary>
        WaterMarkType SmallerWaterMarkType { get; }

        /// <summary>
        /// 微图水印位置
        /// </summary>
        WaterMarkPosition SmallerWaterMarkPosition { get; }

        /// <summary>
        /// 微图水印内容
        /// </summary>
        string SmallerWaterMarkContent { get; }

        /// <summary>
        /// 微图水印图片
        /// </summary>
        Bitmap SmallerWaterMarkImage { get; }

        /// <summary>
        /// 微图背景图片
        /// </summary>
        Bitmap SmallerBackGround { get; }

        /// <summary>
        /// 微图默认图片名称
        /// </summary>
        string SmallerDefaultImage { get; }
    }
}
