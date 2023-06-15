using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using KangHui.JianHui.Utils.Imaging.Interface;

namespace KangHui.JianHui.Utils.Imaging.BaseClass
{
    /// <summary>
    /// ͼƬ���û���
    /// </summary>
    internal class ImageBase : ISmallerImage, ISmallImage, IMiddleImage, IBigImage
    {
        #region ΢ͼ�������

        /// <summary>
        /// ΢ͼ���
        /// </summary>
        public virtual Size SmallerSize
        {
            get { return new Size(80, 60); }
        }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼ
        /// </summary>
        public virtual bool NeedSmallerImage
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼˮӡ
        /// </summary>
        public virtual bool NeedSmallerWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ΢ͼ����
        /// </summary>
        public virtual bool NeedSmallerBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// ΢ͼ��׺��
        /// </summary>
        public virtual string SmallerSuffix
        {
            get { return "_smaller"; }
        }

        /// <summary>
        /// ΢ͼˮӡ����
        /// </summary>
        public virtual WaterMarkType SmallerWaterMarkType 
        {
            get { return WaterMarkType.Text; } 
        }

        /// <summary>
        /// ΢ͼˮӡλ��
        /// </summary>
        public virtual WaterMarkPosition SmallerWaterMarkPosition 
        {
            get { return WaterMarkPosition.BottomRight; } 
        }

        /// <summary>
        /// ΢ͼˮӡ����
        /// </summary>
        public virtual string SmallerWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// ΢ͼˮӡͼƬ
        /// </summary>
        public virtual Bitmap SmallerWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// ΢ͼ����ͼƬ
        /// </summary>
        public virtual Bitmap SmallerBackGround 
        {
            get { return BackGround._80x60; }
        }

        /// <summary>
        /// ΢ͼĬ��ͼƬ����
        /// </summary>
        public virtual string SmallerDefaultImage 
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_80x60.jpg"; }
        }

        #endregion

        #region Сͼ�������

        /// <summary>
        /// Сͼ���
        /// </summary>
        public virtual Size SmallSize
        {
            get { return new Size(100, 75); }
        }

        /// <summary>
        /// �Ƿ���ҪСͼ
        /// </summary>
        public virtual bool NeedSmallImage
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���ҪСͼˮӡ
        /// </summary>
        public virtual bool NeedSmallWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���ҪСͼ����
        /// </summary>
        public virtual bool NeedSmallBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// Сͼ��׺��
        /// </summary>
        public virtual string SmallSuffix
        {
            get { return "_small"; }
        }

        /// <summary>
        /// Сͼˮӡ����
        /// </summary>
        public virtual WaterMarkType SmallWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// Сͼˮӡλ��
        /// </summary>
        public virtual WaterMarkPosition SmallWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// Сͼˮӡ����
        /// </summary>
        public virtual string SmallWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// СͼˮӡͼƬ
        /// </summary>
        public virtual Bitmap SmallWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// Сͼ����ͼƬ
        /// </summary>
        public virtual Bitmap SmallBackGround
        {
            get { return BackGround._100x75; }
        }

        /// <summary>
        /// СͼĬ��ͼƬ����
        /// </summary>
        public virtual string SmallDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_100x75.jpg"; }
        }

        #endregion

        #region ��ͼ�������

        /// <summary>
        /// ��ͼ���
        /// </summary>
        public virtual Size MiddleSize
        {
            get { return new Size(300, 225); }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ
        /// </summary>
        public virtual bool NeedMiddleImage
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼˮӡ
        /// </summary>
        public virtual bool NeedMiddleWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ����
        /// </summary>
        public virtual bool NeedMiddleBackGround
        {
            get { return true; }
        }

        /// <summary>
        /// ��ͼ��׺��
        /// </summary>
        public virtual string MiddleSuffix
        {
            get { return "_middle"; }
        }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        public virtual WaterMarkType MiddleWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// ��ͼˮӡλ��
        /// </summary>
        public virtual WaterMarkPosition MiddleWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        public virtual string MiddleWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// ��ͼˮӡͼƬ
        /// </summary>
        public virtual Bitmap MiddleWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// ��ͼ����ͼƬ
        /// </summary>
        public virtual Bitmap MiddleBackGround
        {
            get { return BackGround._300x225; }
        }

        /// <summary>
        /// ��ͼĬ��ͼƬ����
        /// </summary>
        public virtual string MiddleDefaultImage
        {
            get { return "BitAuto.Ucar.Utils.Imaging.WebResource.Default_300x225.jpg"; }
        }

        #endregion

        #region ��ͼ�������

        /// <summary>
        /// ����ͼ�����
        /// </summary>
        public virtual Size MaxSize
        {
            get { return new Size(1200, 900); }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ
        /// </summary>
        public virtual bool NeedBigImage
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼˮӡ
        /// </summary>
        public virtual bool NeedBigWaterMark
        {
            get { return true; }
        }

        /// <summary>
        /// �Ƿ���Ҫ��ͼ����
        /// </summary>
        public virtual bool NeedBigBackGround
        {
            get { return false; }
        }

        /// <summary>
        /// ��ͼ��׺��
        /// </summary>
        public virtual string BigSuffix
        {
            get { return "_big"; }
        }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        public virtual WaterMarkType BigWaterMarkType
        {
            get { return WaterMarkType.Text; }
        }

        /// <summary>
        /// ��ͼˮӡλ��
        /// </summary>
        public virtual WaterMarkPosition BigWaterMarkPosition
        {
            get { return WaterMarkPosition.BottomRight; }
        }

        /// <summary>
        /// ��ͼˮӡ����
        /// </summary>
        public virtual string BigWaterMarkContent
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// ��ͼˮӡͼƬ
        /// </summary>
        public virtual Bitmap BigWaterMarkImage
        {
            get { return null; }
        }

        /// <summary>
        /// ��ͼ����ͼƬ
        /// </summary>
        public virtual Bitmap BigBackGround
        {
            get { return null; }
        }

        /// <summary>
        /// ��ͼĬ��ͼƬ����
        /// </summary>
        public virtual string BigDefaultImage
        {
            get { return string.Empty; }
        }

        #endregion
    }
}
