using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// 大图配置的接口类
    /// </summary>
    interface IBigImage
    {
        /// <summary>
        /// 缩略图最大规格
        /// </summary>
        Size MaxSize { get; }

        /// <summary>
        /// 是否需要大图
        /// </summary>
        bool NeedBigImage { get; }

        /// <summary>
        /// 是否需要大图水印
        /// </summary>
        bool NeedBigWaterMark { get; }

        /// <summary>
        /// 是否需要大图背景
        /// </summary>
        bool NeedBigBackGround { get; }

        /// <summary>
        /// 大图后缀名
        /// </summary>
        string BigSuffix { get; }

        /// <summary>
        /// 大图水印类型
        /// </summary>
        WaterMarkType BigWaterMarkType { get; }

        /// <summary>
        /// 大图水印位置
        /// </summary>
        WaterMarkPosition BigWaterMarkPosition { get; }

        /// <summary>
        /// 大图水印内容
        /// </summary>
        string BigWaterMarkContent { get; }

        /// <summary>
        /// 大图水印图片
        /// </summary>
        Bitmap BigWaterMarkImage { get; }

        /// <summary>
        /// 大图背景图片
        /// </summary>
        Bitmap BigBackGround { get; }

        /// <summary>
        /// 大图默认图片名称
        /// </summary>
        string BigDefaultImage { get; }
    }
}
