using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace KangHui.JianHui.Utils.Imaging.Interface
{
    /// <summary>
    /// ��ͼ���õĽӿ���
    /// </summary>
    interface IBigImage
    {
        /// <summary>
        /// ����ͼ�����
        /// </summary>
        Size MaxSize { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ
        /// </summary>
        bool NeedBigImage { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼˮӡ
        /// </summary>
        bool NeedBigWaterMark { get; }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ����
        /// </summary>
        bool NeedBigBackGround { get; }

        /// <summary>
        /// ��ͼ��׺��
        /// </summary>
        string BigSuffix { get; }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        WaterMarkType BigWaterMarkType { get; }

        /// <summary>
        /// ��ͼˮӡλ��
        /// </summary>
        WaterMarkPosition BigWaterMarkPosition { get; }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        string BigWaterMarkContent { get; }

        /// <summary>
        /// ��ͼˮӡͼƬ
        /// </summary>
        Bitmap BigWaterMarkImage { get; }

        /// <summary>
        /// ��ͼ����ͼƬ
        /// </summary>
        Bitmap BigBackGround { get; }

        /// <summary>
        /// ��ͼĬ��ͼƬ����
        /// </summary>
        string BigDefaultImage { get; }
    }
}
