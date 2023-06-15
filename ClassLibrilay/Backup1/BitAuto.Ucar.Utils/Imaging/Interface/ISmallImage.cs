using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// Сͼ���õĽӿ���
    /// </summary>
    internal interface ISmallImage
    {
        /// <summary>
        /// Сͼ���
        /// </summary>
        Size SmallSize { get; }

        /// <summary>
        /// �Ƿ���ҪСͼ
        /// </summary>
        bool NeedSmallImage { get; }

        /// <summary>
        /// �Ƿ���ҪСͼˮӡ
        /// </summary>
        bool NeedSmallWaterMark { get; }

        /// <summary>
        /// �Ƿ���ҪСͼ����
        /// </summary>
        bool NeedSmallBackGround { get; }

        /// <summary>
        /// Сͼ��׺��
        /// </summary>
        string SmallSuffix { get; }

        /// <summary>
        /// Сͼˮӡ����
        /// </summary>
        WaterMarkType SmallWaterMarkType { get; }

        /// <summary>
        /// Сͼˮӡλ��
        /// </summary>
        WaterMarkPosition SmallWaterMarkPosition { get; }

        /// <summary>
        /// Сͼˮӡ����
        /// </summary>
        string SmallWaterMarkContent { get; }

        /// <summary>
        /// СͼˮӡͼƬ
        /// </summary>
        Bitmap SmallWaterMarkImage { get; }

        /// <summary>
        /// Сͼ����ͼƬ
        /// </summary>
        Bitmap SmallBackGround { get; }

        /// <summary>
        /// СͼĬ��ͼƬ����
        /// </summary>
        string SmallDefaultImage { get; }
    }
}
