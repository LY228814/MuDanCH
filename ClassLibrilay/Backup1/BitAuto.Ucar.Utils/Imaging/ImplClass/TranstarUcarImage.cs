using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.BaseClass;

namespace KangHui.JianHui.Utils.Imaging.ImplClass
{
    /// <summary>
    /// 车商通车源图片配置实现类
    /// </summary>
    internal class TranstarUcarImage : ImageBase
    {
        public override Size MiddleSize
        {
            get { return new Size(250, 187); }
        }

        public override Bitmap MiddleBackGround
        {
            get { return BackGround._250x187; }
        }

        public override string MiddleDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_250x187.jpg"; }
        }
    }
}
