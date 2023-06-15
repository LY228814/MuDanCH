using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// 中图配置的接口类
    /// </summary>
    internal interface IMiddleImage
    {
        /// <summary>
        /// 中图规格
        /// </summary>
        Size MiddleSize { get; }

        /// <summary>
        /// 是否需要中图
        /// </summary>
        bool NeedMiddleImage { get; }

        /// <summary>
        /// 是否需要中图水印
        /// </summary>
        bool NeedMiddleWaterMark { get; }

        /// <summary>
        /// 是否需要中图背景
        /// </summary>
        bool NeedMiddleBackGround { get; }

        /// <summary>
        /// 中图后缀名
        /// </summary>
        string MiddleSuffix { get; }

        /// <summary>
        /// 中图水印类型
        /// </summary>
        WaterMarkType MiddleWaterMarkType { get; }

        /// <summary>
        /// 中图水印位置
        /// </summary>
        WaterMarkPosition MiddleWaterMarkPosition { get; }

        /// <summary>
        /// 中图水印内容
        /// </summary>
        string MiddleWaterMarkContent { get; }

        /// <summary>
        /// 中图水印图片
        /// </summary>
        Bitmap MiddleWaterMarkImage { get; }

        /// <summary>
        /// 中图背景图片
        /// </summary>
        Bitmap MiddleBackGround { get; }

        /// <summary>
        /// 中图默认图片名称
        /// </summary>
        string MiddleDefaultImage { get; }
    }
}
