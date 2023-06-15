using System;
using System.Collections.Generic;
using System.Text;

namespace KangHui.JianHui.Utils.Imaging
{
    #region ͼƬ����
    /// <summary>
    /// ͼƬ����
    /// </summary>
    public enum ImageType
    {
        /// <summary>
        /// �ſ���ԴͼƬ
        /// </summary>
        UcarImage,

        /// <summary>
        /// ����ͨ��ԴͼƬ
        /// </summary>
        TranstarUcarImage,

        /// <summary>
        /// ������ͼƬ
        /// </summary>
        VendorImage,

        /// <summary>
        /// ������LogoͼƬ
        /// </summary>
        VendorLogoImage,

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        PersonalImage,

        /// <summary>
        /// ����ѹ����ͼƬ
        /// </summary>
        NoCompressionImage
    }
    #endregion

    #region ����ͼ����
    /// <summary>
    /// ����ͼ����
    /// </summary>
    public enum MicroImageType
    {
        /// <summary>
        /// ΢ͼ
        /// </summary>
        Smaller,

        /// <summary>
        /// Сͼ
        /// </summary>
        Small,

        /// <summary>
        /// ��ͼ
        /// </summary>
        Middle,

        /// <summary>
        /// ��ͼ
        /// </summary>
        Big,

        /// <summary>
        /// ԭͼ
        /// </summary>
        Source
    }
    #endregion

    #region ˮӡ����
    /// <summary>
    /// ˮӡ����
    /// </summary>
    internal enum WaterMarkType
    {
        /// <summary>
        /// ͼƬ
        /// </summary>
        Image,

        /// <summary>
        /// ����
        /// </summary>
        Text
    }
    #endregion

    #region ͼƬˮӡ��λ��
    /// <summary>
    /// ͼƬˮӡ��λ��
    /// </summary>
    internal enum WaterMarkPosition
    {
        /// <summary>
        /// ���Ϸ�
        /// </summary>
        TopLeft,

        /// <summary>
        /// ���Ϸ�
        /// </summary>
        TopRight,

        /// <summary>
        /// ���·�
        /// </summary>
        BottomLeft,

        /// <summary>
        /// ���·�
        /// </summary>
        BottomRight
    }
    #endregion
}
