using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// 小图配置的接口类
    /// </summary>
    internal interface ISmallImage
    {
        /// <summary>
        /// 小图规格
        /// </summary>
        Size SmallSize { get; }

        /// <summary>
        /// 是否需要小图
        /// </summary>
        bool NeedSmallImage { get; }

        /// <summary>
        /// 是否需要小图水印
        /// </summary>
        bool NeedSmallWaterMark { get; }

        /// <summary>
        /// 是否需要小图背景
        /// </summary>
        bool NeedSmallBackGround { get; }

        /// <summary>
        /// 小图后缀名
        /// </summary>
        string SmallSuffix { get; }

        /// <summary>
        /// 小图水印类型
        /// </summary>
        WaterMarkType SmallWaterMarkType { get; }

        /// <summary>
        /// 小图水印位置
        /// </summary>
        WaterMarkPosition SmallWaterMarkPosition { get; }

        /// <summary>
        /// 小图水印内容
        /// </summary>
        string SmallWaterMarkContent { get; }

        /// <summary>
        /// 小图水印图片
        /// </summary>
        Bitmap SmallWaterMarkImage { get; }

        /// <summary>
        /// 小图背景图片
        /// </summary>
        Bitmap SmallBackGround { get; }

        /// <summary>
        /// 小图默认图片名称
        /// </summary>
        string SmallDefaultImage { get; }
    }
}
