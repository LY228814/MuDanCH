using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using KangHui.JianHui.Utils.Imaging.BaseClass;
using KangHui.JianHui.Utils.Imaging.ImplClass;
using KangHui.JianHui.Utils.Common;

namespace KangHui.JianHui.Utils.Imaging
{
    /// <summary>
    /// ��ͼƬ���д���Ĺ�����
    /// </summary>
    public class ImageHelper
    {
        #region �����ϴ�ͼƬ�ķ���
        /// <summary>
        /// �����ϴ�ͼƬ�ķ���
        /// </summary>
        /// <param name="imgLocalPath">ͼƬ����������·��</param>
        /// <param name="imgDbPath">ͼƬ�����ݿⴢ���·������ͼƬ����ʧ��ʱ�᷵�ش�����Ϣ��</param>
        /// <param name="imageType">ͼƬ����</param>
        /// <returns>������</returns>
        public static bool SaveImage(string imgLocalPath, ref string imgDbPath, ImageType imageType)
        {
            return SaveImage(imgLocalPath, ref imgDbPath, imageType, null);
        }
        /// <summary>
        /// �����ϴ�ͼƬ�ķ���
        /// </summary>
        /// <param name="imgLocalPath">ͼƬ����������·��</param>
        /// <param name="imgDbPath">ͼƬ�����ݿⴢ���·������ͼƬ����ʧ��ʱ�᷵�ش�����Ϣ��</param>
        /// <param name="imageType">ͼƬ����</param>
        /// <param name="postedFile">�ϴ�ͼƬ���ļ�����</param>
        /// <returns>������</returns>
        public static bool SaveImage(string imgLocalPath, ref string imgDbPath, ImageType imageType, HttpPostedFile postedFile)
        {
            return SaveImage(imgLocalPath, "", ref imgDbPath, imageType, postedFile);
        }
        /// <summary>
        /// �����ϴ�ͼƬ�ķ���
        /// </summary>
        /// <param name="imgLocalPath">ͼƬ����������·��</param>
        /// <param name="childFolder">ͼƬ��Ŀ¼</param>
        /// <param name="imgDbPath">ͼƬ�����ݿⴢ���·������ͼƬ����ʧ��ʱ�᷵�ش�����Ϣ��</param>
        /// <param name="imageType">ͼƬ����</param>
        /// <returns>������</returns>
        public static bool SaveImage(string imgLocalPath, string childFolder, ref string imgDbPath, ImageType imageType)
        {
            return SaveImage(imgLocalPath, childFolder, ref imgDbPath, imageType, null);
        }
        /// <summary>
        /// �����ϴ�ͼƬ�ķ���
        /// </summary>
        /// <param name="imgLocalPath">ͼƬ����������·��</param>
        /// <param name="childFolder">ͼƬ��Ŀ¼</param>
        /// <param name="imgDbPath">ͼƬ�����ݿⴢ���·������ͼƬ����ʧ��ʱ�᷵�ش�����Ϣ��</param>
        /// <param name="imageType">ͼƬ����</param>
        /// <param name="postedFile">�ϴ�ͼƬ���ļ�����</param>
        /// <returns>������</returns>
        public static bool SaveImage(string imgLocalPath, string childFolder, ref string imgDbPath, ImageType imageType, HttpPostedFile postedFile)
        {
            try
            {
                //��ʽ��ͼƬ����������·��
                imgLocalPath = imgLocalPath.Replace("/", @"\"); 
                if (!imgLocalPath.EndsWith(@"\")) 
                {
                    imgLocalPath += @"\";
                }

                //��ʽ��ͼƬ��Ŀ¼
                if (!string.IsNullOrEmpty(childFolder))
                {
                    childFolder = childFolder.Replace("/", @"\"); 
                    childFolder = childFolder.TrimStart(new char[] { '\\' });
                    if (!childFolder.EndsWith(@"\")) 
                    {
                        childFolder += @"\";
                    }
                }

                if (postedFile != null)
                {
                    FileHelper.SaveFile(imgLocalPath, childFolder, ref imgDbPath, postedFile);
                }
                else
                {
                    if (!FileHelper.IsExist(imgLocalPath + childFolder + imgDbPath))
                    {
                        imgDbPath = "ͼƬ" + imgLocalPath + childFolder + imgDbPath + "�����ڡ�";
                        return false;
                    }
                }

                CompressImageByType(imgLocalPath, childFolder, imgDbPath, imageType); //��ͼƬ����ѹ��ͼƬ;
                return true;
            }
            catch (Exception ex)
            {
                imgDbPath = ex.Message + "\n" + ex.StackTrace;
                return false;
            }
        }
        #endregion

        #region ����ͼƬ����ѹ��ͼƬ�ķ���
        /// <summary>
        /// ����ͼƬ����ѹ��ͼƬ�ķ���
        /// </summary>
        /// <param name="imgLocalPath">ͼƬ����������·��</param>
        /// <param name="childFolder">ͼƬ��Ŀ¼</param>
        /// <param name="imgDbPath">ͼƬ�����ݿⴢ���·������ͼƬ����ʧ��ʱ�᷵�ش�����Ϣ��</param>
        /// <param name="imageType">ͼƬ����</param>
        /// <returns>ѹ�����</returns>
        private static void CompressImageByType(string imgLocalPath, string childFolder, string imgDbPath, ImageType imageType)
        {
            ImageBase image = ImageFactory.GetInstance(imageType);
            string imgOriginalName = imgLocalPath + childFolder + imgDbPath; //ԭͼƬ����
            
            if (image.NeedBigImage)
            {
                string imgBigName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.BigSuffix + "."); //��ͼ����
                CompressImageBySize(imgOriginalName, imgBigName, image.MaxSize); //ѹ����ͼ

                if (image.NeedBigWaterMark)
                {
                    AddWaterMark(imgBigName, image.BigWaterMarkType, image.BigWaterMarkPosition, image.BigWaterMarkContent, image.BigWaterMarkImage); //��ͼ��ˮӡ
                }

                if (image.NeedBigBackGround)
                {
                    AddBackGround(imgBigName, image.BigBackGround); //��ͼ�ӱ���
                }
            }

            if (image.NeedMiddleImage)
            {
                string imgMiddleName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.MiddleSuffix + "."); //��ͼ����
                CompressImageBySize(imgOriginalName, imgMiddleName, image.MiddleSize); //ѹ����ͼ

                if (image.NeedMiddleWaterMark)
                {
                    AddWaterMark(imgMiddleName, image.MiddleWaterMarkType, image.MiddleWaterMarkPosition, image.MiddleWaterMarkContent, image.MiddleWaterMarkImage); //��ͼ��ˮӡ
                }

                if (image.NeedMiddleBackGround)
                {
                    AddBackGround(imgMiddleName, image.MiddleBackGround); //��ͼ�ӱ���
                }
            }

            if (image.NeedSmallImage)
            {
                string imgSmallName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.SmallSuffix + "."); //Сͼ����
                CompressImageBySize(imgOriginalName, imgSmallName, image.SmallSize); //ѹ��Сͼ

                if (image.NeedSmallWaterMark)
                {
                    AddWaterMark(imgSmallName, image.SmallWaterMarkType, image.SmallWaterMarkPosition, image.SmallWaterMarkContent, image.SmallWaterMarkImage); //Сͼ��ˮӡ
                }

                if (image.NeedSmallBackGround)
                {
                    AddBackGround(imgSmallName, image.SmallBackGround); //Сͼ�ӱ���
                }
            }

            if (image.NeedSmallerImage)
            {
                string imgSmallerName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.SmallerSuffix + "."); //΢ͼ����
                CompressImageBySize(imgOriginalName, imgSmallerName, image.SmallerSize); //ѹ��΢ͼ

                if (image.NeedSmallerWaterMark)
                {
                    AddWaterMark(imgSmallerName, image.SmallerWaterMarkType, image.SmallerWaterMarkPosition, image.SmallerWaterMarkContent, image.SmallerWaterMarkImage); //΢ͼ��ˮӡ
                }

                if (image.NeedSmallerBackGround)
                {
                    AddBackGround(imgSmallerName, image.SmallerBackGround); //΢ͼ�ӱ���
                }
            }
        }
        #endregion

        #region ���ݳߴ�ѹ��ͼƬ�ķ���
        /// <summary>
        /// ���ݳߴ�ѹ��ͼƬ�ķ���
        /// </summary>
        /// <param name="srcImageName">ѹ��ǰ��ͼƬ����</param>
        /// <param name="destImageName">ѹ�����ͼƬ����</param>
        /// <param name="size">ѹ���ĳߴ�</param>
        private static void CompressImageBySize(string srcImageName, string destImageName, Size size)
        {
            Image srcImage = Image.FromFile(srcImageName);
            if (srcImage.Width > size.Width | srcImage.Height > size.Height) //���ͼƬ�Ŀ�Ȼ�߶ȳ����涨�ĳߴ磬��Ҫ��ͼƬ����ѹ������֮��ѹ����ֱ�Ӹ���
            {
                if ((double)srcImage.Height / (double)srcImage.Width < (double)size.Height / (double)size.Width) //���ͼƬ�ĸ߿��С�ڹ涨�ĸ߿�ȣ���Ҫ����ȵȱ���ѹ������֮���߶ȵȱ���ѹ��
                {
                    int newWidth = srcImage.Width > size.Width ? size.Width : srcImage.Width;
                    int newHeight = srcImage.Height * newWidth / srcImage.Width;    
                    CompressImage(srcImage, destImageName, new Size(newWidth, newHeight));
                }
                else
                {
                    int newHeight = srcImage.Height > size.Height ? size.Height : srcImage.Height;
                    int newWidth = srcImage.Width * newHeight / srcImage.Height;
                    CompressImage(srcImage, destImageName, new Size(newWidth, newHeight));
                }
            }
            else
            {
                FileHelper.CopyFile(srcImageName, destImageName);
            }
            srcImage.Dispose();
        }
        #endregion

        #region ѹ��ͼƬ�ķ���
        /// <summary>
        /// ѹ��ͼƬ�ķ���
        /// </summary>
        /// <param name="srcImage">ͼƬ����</param>
        /// <param name="destImageName">Ŀ���ļ���</param>
        /// <param name="size">Ҫѹ�����ĳߴ�</param>
        private static void CompressImage(Image srcImage, string destImageName, Size size)
        {
            ImageFormat thisFormat = srcImage.RawFormat;
            Bitmap outBmp = new Bitmap(srcImage, size);
            Graphics g = Graphics.FromImage(outBmp);
            // ���û������������
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(srcImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // ���´���Ϊ����ͼƬʱ,����ѹ������
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 90; //�������������ͼƬѹ����������ֵԽ��ѹ������Խ��
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����.
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int i = 0; i < arrayICI.Length; i++)
            {
                if (arrayICI[i].FormatDescription.Equals("JPEG"))
                {
                    //����JPEG����
                    jpegICI = arrayICI[i];
                    break;
                }
            }

            FileHelper.DeleteFile(destImageName); //���Ҫ���ɵ�ͼƬ�����Ѵ��ڣ���Ҫ��ɾ��

            if (jpegICI != null)
            {
                outBmp.Save(destImageName, jpegICI, encoderParams);
            }
            else
            {
                outBmp.Save(destImageName, thisFormat);
            }
            
            outBmp.Dispose();
        }
        #endregion

        #region ���ˮӡ�ķ���
        /// <summary>
        /// ���ˮӡ�ķ���
        /// </summary>
        /// <param name="srcImageName">Ҫ��ˮӡ��ͼƬ����</param>
        /// <param name="type">ˮӡ����</param>
        /// <param name="position">ˮӡλ��</param>
        /// <param name="content">ˮӡ����</param>
        /// <param name="watermark">ˮӡͼƬ</param>
        private static void AddWaterMark(string srcImageName, WaterMarkType type, WaterMarkPosition position, string content, Bitmap watermark)
        {
            Image srcImage = Image.FromFile(srcImageName);
            Bitmap b = new Bitmap(srcImage.Width, srcImage.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            g.DrawImage(srcImage, 0, 0, srcImage.Width, srcImage.Height);

            switch (type)
            {
                //�����ͼƬ              
                case WaterMarkType.Image:
                    AddImageWatermark(g, watermark, position, srcImage.Width, srcImage.Height);
                    break;
                //���������                    
                case WaterMarkType.Text:
                    AddTextWatermark(g, content, position, srcImage.Width, srcImage.Height);
                    break;
            }

            int index = srcImageName.Replace("/", @"\").LastIndexOf(@"\");
            string tempImageName = srcImageName.Insert(index + 1, "wm");

            b.Save(tempImageName);
            b.Dispose();
            srcImage.Dispose();

            FileHelper.CopyFile(tempImageName, srcImageName);
            FileHelper.DeleteFile(tempImageName);
        }
        #endregion

        #region ��ˮӡ���ֵķ���
        /// <summary>
        /// ��ˮӡ���ֵķ���
        /// </summary>
        /// <param name="picture">Graphics ����</param>
        /// <param name="watermarkText">ˮӡ��������</param>
        /// <param name="watermarkPosition">ˮӡλ��</param>
        /// <param name="width">����ˮӡͼƬ�Ŀ�</param>
        /// <param name="height">����ˮӡͼƬ�ĸ�</param>
        private static void AddTextWatermark(Graphics picture, string watermarkText, WaterMarkPosition watermarkPosition, int width, int height)
        {
            int[] sizes = new int[] { 40, 36, 32, 28, 24, 20, 16, 12 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 8; i++)
            {
                crFont = new Font("arial", sizes[i], FontStyle.Bold);
                crSize = picture.MeasureString(watermarkText, crFont);

                if ((ushort)crSize.Width < (ushort)width / 2)
                    break;
            }

            float xpos = 0;
            float ypos = 0;

            switch (watermarkPosition)
            {
                case WaterMarkPosition.TopLeft:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WaterMarkPosition.TopRight:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = (float)height * (float).01;
                    break;
                case WaterMarkPosition.BottomRight:
                    xpos = ((float)width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
                case WaterMarkPosition.BottomLeft:
                    xpos = ((float)width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)height * (float).99) - crSize.Height;
                    break;
            }

            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            picture.DrawString(watermarkText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            picture.DrawString(watermarkText, crFont, semiTransBrush, xpos, ypos, StrFormat);

            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();
        }
        #endregion

        #region ��ˮӡͼƬ�ķ���
        /// <summary>
        /// ��ˮӡͼƬ�ķ���
        /// </summary>
        /// <param name="picture">Graphics ����</param>
        /// <param name="watermark">ˮӡͼƬ</param>
        /// <param name="watermarkPosition">ˮӡλ��</param>
        /// <param name="width">����ˮӡͼƬ�Ŀ�</param>
        /// <param name="height">����ˮӡͼƬ�ĸ�</param>
        private static void AddImageWatermark(Graphics picture, Bitmap watermark, WaterMarkPosition watermarkPosition, int width, int height)
        {
            if (watermark == null) //�жϱ���ͼ�Ƿ����
            {
                throw new Exception("ˮӡͼƬ�����ڡ�");
            }

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                            };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int waterMarkWidth = watermark.Width;
            int waterMarkHeight = watermark.Height;
            double bl = 1d;
            int rate = 1; //�������������ˮӡͼƬ�Ĵ�С��ֵԽСˮӡͼԽ��
            //����ˮӡͼƬ�ı���
            if ((width > watermark.Width * rate) && (height > watermark.Height * rate))
            {
                bl = 1;
            }
            else if ((width > watermark.Width * rate) && (height < watermark.Height * rate))
            {
                bl = Convert.ToDouble(height / rate) / Convert.ToDouble(watermark.Height);
            }
            else
            {
                if ((width < watermark.Width * rate) && (height > watermark.Height * rate))
                {
                    bl = Convert.ToDouble(width / rate) / Convert.ToDouble(watermark.Width);
                }
                else
                {
                    if ((width * watermark.Height) > (height * watermark.Width))
                    {
                        bl = Convert.ToDouble(height / rate) / Convert.ToDouble(watermark.Height);
                    }
                    else
                    {
                        bl = Convert.ToDouble(width / rate) / Convert.ToDouble(watermark.Width);
                    }

                }
            }

            waterMarkWidth = Convert.ToInt32(watermark.Width * bl);
            waterMarkHeight = Convert.ToInt32(watermark.Height * bl);

            switch (watermarkPosition)
            {
                case WaterMarkPosition.TopLeft:
                    xpos = 10;
                    ypos = 10;
                    break;
                case WaterMarkPosition.TopRight:
                    xpos = width - waterMarkWidth - 10;
                    ypos = 10;
                    break;
                case WaterMarkPosition.BottomRight:
                    xpos = width - waterMarkWidth - 10;
                    ypos = height - waterMarkHeight - 10;
                    break;
                case WaterMarkPosition.BottomLeft:
                    xpos = 10;
                    ypos = height - waterMarkHeight - 10;
                    break;
            }

            picture.DrawImage(watermark, new Rectangle(xpos, ypos, waterMarkWidth, waterMarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            watermark.Dispose();
            imageAttributes.Dispose();
        }
        #endregion

        #region �ӱ���ͼƬ�ķ���
        /// <summary>
        /// �ӱ���ͼƬ�ķ���
        /// </summary>
        /// <param name="srcImageName">Ҫ�ӱ�����ͼƬ����</param>
        /// <param name="bgImage">����ͼƬ</param>
        private static void AddBackGround(string srcImageName, Bitmap bgImage)
        {
            if (bgImage == null) //�жϱ���ͼ�Ƿ����
            {
                throw new Exception("����ͼƬ�����ڡ�");
            }

            int index = srcImageName.Replace("/", @"\").LastIndexOf(@"\");
            string tempImageName = srcImageName.Insert(index + 1, "bg");

            Image srcImage = Image.FromFile(srcImageName);

            if (srcImage.Width == bgImage.Width & srcImage.Height == bgImage.Height) //�������ͼ�Ĺ����ڱ���ͼ�Ĺ�񣬾Ͳ�����ӱ���ͼ��
            {
                return;
            }

            if (srcImage.Width > bgImage.Width | srcImage.Height > bgImage.Height) //�ж�����ͼ�Ĺ���Ƿ�С�ڵ��ڱ���ͼ�Ĺ��
            {
                FileHelper.DeleteFile(tempImageName);
                srcImage.Dispose();
                bgImage.Dispose();
                throw new Exception("����ͼ�Ĺ�񳬹��˱���ͼ�Ĺ��");
            }

            Bitmap b = new Bitmap(bgImage.Width, bgImage.Height, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            int diffWidth = bgImage.Width - srcImage.Width;
            int diffHeight = bgImage.Height - srcImage.Height;

            g.DrawImage(bgImage, new Rectangle(0, 0, bgImage.Width, bgImage.Height));
            g.DrawImage(srcImage, new Rectangle(diffWidth / 2, diffHeight / 2, srcImage.Width, srcImage.Height));

            b.Save(tempImageName);

            b.Dispose();
            g.Dispose();
            srcImage.Dispose();
            bgImage.Dispose();

            FileHelper.CopyFile(tempImageName, srcImageName);
            FileHelper.DeleteFile(tempImageName);
        }
        #endregion
    }
}
