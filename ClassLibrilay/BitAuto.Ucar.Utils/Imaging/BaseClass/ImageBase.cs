using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.Interface;

namespace KangHui.JianHui.Utils.Imaging.BaseClass
{
    /// <summary>
    /// 图片配置基类
    /// </summary>
    internal class ImageBase : ISmallerImage, ISmallImage, IMiddleImage, IBigImage
    {
        #region 微图相关配置

        /// <summary>
        /// 微图规格
        /// </summary>
        public virtual Size SmallerSize
        {
            get { return new Size(80, 60); }
        }

        /// <summary>
        /// 是否需要微图
        /// </summary>
        public virtual bool NeedSmallerImage
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要微图水印
        /// </summary>
        public virtual bool NeedSmallerWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要微图背景
        /// </summary>
        public virtual bool NeedSmallerBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// 微图后缀名
        /// </summary>
        public virtual string SmallerSuffix
        {
            get { return "_smaller"; }
        }

        /// <summary>
        /// 微图水印类型
        /// </summary>
        public virtual WaterMarkType SmallerWaterMarkType 
        {
            get { return WaterMarkType.Text; } 
        }

        /// <summary>
        /// 微图水印位置
        /// </summary>
        public virtual WaterMarkPosition SmallerWaterMarkPosition 
        {
            get { return WaterMarkPosition.BottomRight; } 
        }

        /// <summary>
        /// 微图水印内容
        /// </summary>
        public virtual string SmallerWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 微图水印图片
        /// </summary>
        public virtual Bitmap SmallerWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// 微图背景图片
        /// </summary>
        public virtual Bitmap SmallerBackGround 
        {
            get { return BackGround._80x60; }
        }

        /// <summary>
        /// 微图默认图片名称
        /// </summary>
        public virtual string SmallerDefaultImage 
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_80x60.jpg"; }
        }

        #endregion

        #region 小图相关配置

        /// <summary>
        /// 小图规格
        /// </summary>
        public virtual Size SmallSize
        {
            get { return new Size(100, 75); }
        }

        /// <summary>
        /// 是否需要小图
        /// </summary>
        public virtual bool NeedSmallImage
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要小图水印
        /// </summary>
        public virtual bool NeedSmallWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要小图背景
        /// </summary>
        public virtual bool NeedSmallBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// 小图后缀名
        /// </summary>
        public virtual string SmallSuffix
        {
            get { return "_small"; }
        }

        /// <summary>
        /// 小图水印类型
        /// </summary>
        public virtual WaterMarkType SmallWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// 小图水印位置
        /// </summary>
        public virtual WaterMarkPosition SmallWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// 小图水印内容
        /// </summary>
        public virtual string SmallWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 小图水印图片
        /// </summary>
        public virtual Bitmap SmallWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// 小图背景图片
        /// </summary>
        public virtual Bitmap SmallBackGround
        {
            get { return BackGround._100x75; }
        }

        /// <summary>
        /// 小图默认图片名称
        /// </summary>
        public virtual string SmallDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_100x75.jpg"; }
        }

        #endregion

        #region 中图相关配置

        /// <summary>
        /// 中图规格
        /// </summary>
        public virtual Size MiddleSize
        {
            get { return new Size(300, 225); }
        }

        /// <summary>
        /// 是否需要中图
        /// </summary>
        public virtual bool NeedMiddleImage
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要中图水印
        /// </summary>
        public virtual bool NeedMiddleWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要中图背景
        /// </summary>
        public virtual bool NeedMiddleBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// 中图后缀名
        /// </summary>
        public virtual string MiddleSuffix
        {
            get { return "_middle"; }
        }

        /// <summary>
        /// 中图水印类型
        /// </summary>
        public virtual WaterMarkType MiddleWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// 中图水印位置
        /// </summary>
        public virtual WaterMarkPosition MiddleWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// 中图水印内容
        /// </summary>
        public virtual string MiddleWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 中图水印图片
        /// </summary>
        public virtual Bitmap MiddleWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// 中图背景图片
        /// </summary>
        public virtual Bitmap MiddleBackGround
        {
            get { return BackGround._300x225; }
        }

        /// <summary>
        /// 中图默认图片名称
        /// </summary>
        public virtual string MiddleDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_300x225.jpg"; }
        }

        #endregion

        #region 大图相关配置

        /// <summary>
        /// 缩略图最大规格
        /// </summary>
        public virtual Size MaxSize
        {
            get { return new Size(1200, 900); }
        }

        /// <summary>
        /// 是否需要大图
        /// </summary>
        public virtual bool NeedBigImage
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要大图水印
        /// </summary>
        public virtual bool NeedBigWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// 是否需要大图背景
        /// </summary>
        public virtual bool NeedBigBackGround
        {
            get { return false; }
        }

        /// <summary>
        /// 大图后缀名
        /// </summary>
        public virtual string BigSuffix
        {
            get { return "_big"; }
        }

        /// <summary>
        /// 大图水印类型
        /// </summary>
        public virtual WaterMarkType BigWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// 大图水印位置
        /// </summary>
        public virtual WaterMarkPosition BigWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// 大图水印内容
        /// </summary>
        public virtual string BigWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 大图水印图片
        /// </summary>
        public virtual Bitmap BigWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// 大图背景图片
        /// </summary>
        public virtual Bitmap BigBackGround
        {
            get { return null; }
        }

        /// <summary>
        /// 大图默认图片名称
        /// </summary>
        public virtual string BigDefaultImage
        {
            get { return string.Empty; }
        }

        #endregion
    }
}
