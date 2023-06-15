using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.BaseClass;

namespace KangHui.JianHui.Utils.Imaging
{
    /// <summary>
    /// 优卡车源图片配置实现类
    /// </summary>
    internal class UcarImage : ImageBase
    {
        public override Size MiddleSize
        {
            get { return new Size(250, 187); }
        }

        public override bool NeedMiddleWaterMark
        {
            get { return true; }
        }

        public override WaterMarkType MiddleWaterMarkType
        {
            get { return WaterMarkType.Image; }
        }

        public override Bitmap MiddleWaterMarkImage
        {
            get { return WaterMark.ucar_middle; }
        }

        public override Bitmap MiddleBackGround
        {
            get { return BackGround._250x187; }
        }

        public override string MiddleDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_250x187.jpg"; }
        }

        public override bool NeedBigWaterMark
        {
            get { return true; }
        }

        public override WaterMarkType BigWaterMarkType
        {
            get { return WaterMarkType.Image; }
        }

        public override Bitmap BigWaterMarkImage
        {
            get { return WaterMark.ucar_big; }
        }        
    }
}
