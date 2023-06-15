using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// ΢ͼ���õĽӿ���
    /// </summary>
    internal interface ISmallerImage
    {
        /// <summary>
        /// ΢ͼ���
        /// </summary>
        Size SmallerSize { get; }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼ
        /// </summary>
        bool NeedSmallerImage { get; }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼˮӡ
        /// </summary>
        bool NeedSmallerWaterMark { get; }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼ����
        /// </summary>
        bool NeedSmallerBackGround { get; }

        /// <summary>
        /// ΢ͼ��׺��
        /// </summary>
        string SmallerSuffix { get; }

        /// <summary>
        /// ΢ͼˮӡ����
        /// </summary>
        WaterMarkType SmallerWaterMarkType { get; }

        /// <summary>
        /// ΢ͼˮӡλ��
        /// </summary>
        WaterMarkPosition SmallerWaterMarkPosition { get; }

        /// <summary>
        /// ΢ͼˮӡ����
        /// </summary>
        string SmallerWaterMarkContent { get; }

        /// <summary>
        /// ΢ͼˮӡͼƬ
        /// </summary>
        Bitmap SmallerWaterMarkImage { get; }

        /// <summary>
        /// ΢ͼ����ͼƬ
        /// </summary>
        Bitmap SmallerBackGround { get; }

        /// <summary>
        /// ΢ͼĬ��ͼƬ����
        /// </summary>
        string SmallerDefaultImage { get; }
    }
}
