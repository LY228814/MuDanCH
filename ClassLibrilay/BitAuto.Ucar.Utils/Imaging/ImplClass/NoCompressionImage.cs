using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.BaseClass;

namespace KangHui.JianHui.Utils.Imaging.ImplClass
{
    /// <summary>
    /// ����ѹ����ͼƬ������ʵ����
    /// </summary>
    internal class NoCompressionImage : ImageBase
    {
        public override bool NeedSmallerImage
        {
            get { return false; }
        }

        public override bool NeedSmallImage
        {
            get { return false; }
        }

        public override bool NeedMiddleImage
        {
            get { return false; }
        }

        public override bool NeedBigImage
        {
            get { return false; }
        }
    }
}
