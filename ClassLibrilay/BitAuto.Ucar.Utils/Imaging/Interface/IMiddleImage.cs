using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// ��ͼ���õĽӿ���
    /// </summary>
    internal interface IMiddleImage
    {
        /// <summary>
        /// ��ͼ���
        /// </summary>
        Size MiddleSize { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ
        /// </summary>
        bool NeedMiddleImage { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼˮӡ
        /// </summary>
        bool NeedMiddleWaterMark { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ����
        /// </summary>
        bool NeedMiddleBackGround { get; }

        /// <summary>
        /// ��ͼ��׺��
        /// </summary>
        string MiddleSuffix { get; }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        WaterMarkType MiddleWaterMarkType { get; }

        /// <summary>
        /// ��ͼˮӡλ��
        /// </summary>
        WaterMarkPosition MiddleWaterMarkPosition { get; }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        string MiddleWaterMarkContent { get; }

        /// <summary>
        /// ��ͼˮӡͼƬ
        /// </summary>
        Bitmap MiddleWaterMarkImage { get; }

        /// <summary>
        /// ��ͼ����ͼƬ
        /// </summary>
        Bitmap MiddleBackGround { get; }

        /// <summary>
        /// ��ͼĬ��ͼƬ����
        /// </summary>
        string MiddleDefaultImage { get; }
    }
}
