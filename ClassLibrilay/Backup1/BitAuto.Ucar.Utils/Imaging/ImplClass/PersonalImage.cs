using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.BaseClass;

namespace KangHui.JianHui.Utils.Imaging.ImplClass
{
    /// <summary>
    /// 个人图片配置实现类
    /// </summary>
    internal class PersonalImage : ImageBase
    {
        public override Size SmallerSize
        {
            get { return new Size(56, 56); }
        }

        public override Bitmap SmallerBackGround
        {
            get { return BackGround._56x56; }
        }

        public override string SmallerDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_56x56.jpg"; }
        }

        public override Size SmallSize
        {
            get { return new Size(85, 85); }
        }

        public override Bitmap SmallBackGround
        {
            get { return BackGround._85x85; }
        }

        public override string SmallDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_85x85.jpg"; }
        }

        public override Size MiddleSize
        {
            get { return new Size(180, 180); }
        }

        public override Bitmap MiddleBackGround
        {
            get { return BackGround._180x180; }
        }

        public override string MiddleDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_180x180.jpg"; }
        }
    }
}
