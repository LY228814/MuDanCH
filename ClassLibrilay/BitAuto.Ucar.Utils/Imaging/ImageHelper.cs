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
    /// 对图片进行处理的功能类
    /// </summary>
    public class ImageHelper
    {
        #region 保存上传图片的方法
        /// <summary>
        /// 保存上传图片的方法
        /// </summary>
        /// <param name="imgLocalPath">图片服务器物理路径</param>
        /// <param name="imgDbPath">图片在数据库储存的路径（当图片保存失败时会返回错误信息）</param>
        /// <param name="imageType">图片类型</param>
        /// <returns>保存结果</returns>
        public static bool SaveImage(string imgLocalPath, ref string imgDbPath, ImageType imageType)
        {
            return SaveImage(imgLocalPath, ref imgDbPath, imageType, null);
        }
        /// <summary>
        /// 保存上传图片的方法
        /// </summary>
        /// <param name="imgLocalPath">图片服务器物理路径</param>
        /// <param name="imgDbPath">图片在数据库储存的路径（当图片保存失败时会返回错误信息）</param>
        /// <param name="imageType">图片类型</param>
        /// <param name="postedFile">上传图片的文件对象</param>
        /// <returns>保存结果</returns>
        public static bool SaveImage(string imgLocalPath, ref string imgDbPath, ImageType imageType, HttpPostedFile postedFile)
        {
            return SaveImage(imgLocalPath, "", ref imgDbPath, imageType, postedFile);
        }
        /// <summary>
        /// 保存上传图片的方法
        /// </summary>
        /// <param name="imgLocalPath">图片服务器物理路径</param>
        /// <param name="childFolder">图片子目录</param>
        /// <param name="imgDbPath">图片在数据库储存的路径（当图片保存失败时会返回错误信息）</param>
        /// <param name="imageType">图片类型</param>
        /// <returns>保存结果</returns>
        public static bool SaveImage(string imgLocalPath, string childFolder, ref string imgDbPath, ImageType imageType)
        {
            return SaveImage(imgLocalPath, childFolder, ref imgDbPath, imageType, null);
        }
        /// <summary>
        /// 保存上传图片的方法
        /// </summary>
        /// <param name="imgLocalPath">图片服务器物理路径</param>
        /// <param name="childFolder">图片子目录</param>
        /// <param name="imgDbPath">图片在数据库储存的路径（当图片保存失败时会返回错误信息）</param>
        /// <param name="imageType">图片类型</param>
        /// <param name="postedFile">上传图片的文件对象</param>
        /// <returns>保存结果</returns>
        public static bool SaveImage(string imgLocalPath, string childFolder, ref string imgDbPath, ImageType imageType, HttpPostedFile postedFile)
        {
            try
            {
                //格式化图片服务器物理路径
                imgLocalPath = imgLocalPath.Replace("/", @"\"); 
                if (!imgLocalPath.EndsWith(@"\")) 
                {
                    imgLocalPath += @"\";
                }

                //格式化图片子目录
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
                        imgDbPath = "图片" + imgLocalPath + childFolder + imgDbPath + "不存在。";
                        return false;
                    }
                }

                CompressImageByType(imgLocalPath, childFolder, imgDbPath, imageType); //按图片类型压缩图片;
                return true;
            }
            catch (Exception ex)
            {
                imgDbPath = ex.Message + "\n" + ex.StackTrace;
                return false;
            }
        }
        #endregion

        #region 根据图片类型压缩图片的方法
        /// <summary>
        /// 根据图片类型压缩图片的方法
        /// </summary>
        /// <param name="imgLocalPath">图片服务器物理路径</param>
        /// <param name="childFolder">图片子目录</param>
        /// <param name="imgDbPath">图片在数据库储存的路径（当图片保存失败时会返回错误信息）</param>
        /// <param name="imageType">图片类型</param>
        /// <returns>压缩结果</returns>
        private static void CompressImageByType(string imgLocalPath, string childFolder, string imgDbPath, ImageType imageType)
        {
            ImageBase image = ImageFactory.GetInstance(imageType);
            string imgOriginalName = imgLocalPath + childFolder + imgDbPath; //原图片名称
            
            if (image.NeedBigImage)
            {
                string imgBigName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.BigSuffix + "."); //大图名称
                CompressImageBySize(imgOriginalName, imgBigName, image.MaxSize); //压缩大图

                if (image.NeedBigWaterMark)
                {
                    AddWaterMark(imgBigName, image.BigWaterMarkType, image.BigWaterMarkPosition, image.BigWaterMarkContent, image.BigWaterMarkImage); //大图加水印
                }

                if (image.NeedBigBackGround)
                {
                    AddBackGround(imgBigName, image.BigBackGround); //大图加背景
                }
            }

            if (image.NeedMiddleImage)
            {
                string imgMiddleName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.MiddleSuffix + "."); //中图名称
                CompressImageBySize(imgOriginalName, imgMiddleName, image.MiddleSize); //压缩中图

                if (image.NeedMiddleWaterMark)
                {
                    AddWaterMark(imgMiddleName, image.MiddleWaterMarkType, image.MiddleWaterMarkPosition, image.MiddleWaterMarkContent, image.MiddleWaterMarkImage); //中图加水印
                }

                if (image.NeedMiddleBackGround)
                {
                    AddBackGround(imgMiddleName, image.MiddleBackGround); //中图加背景
                }
            }

            if (image.NeedSmallImage)
            {
                string imgSmallName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.SmallSuffix + "."); //小图名称
                CompressImageBySize(imgOriginalName, imgSmallName, image.SmallSize); //压缩小图

                if (image.NeedSmallWaterMark)
                {
                    AddWaterMark(imgSmallName, image.SmallWaterMarkType, image.SmallWaterMarkPosition, image.SmallWaterMarkContent, image.SmallWaterMarkImage); //小图加水印
                }

                if (image.NeedSmallBackGround)
                {
                    AddBackGround(imgSmallName, image.SmallBackGround); //小图加背景
                }
            }

            if (image.NeedSmallerImage)
            {
                string imgSmallerName = imgLocalPath + childFolder + imgDbPath.Replace(".", image.SmallerSuffix + "."); //微图名称
                CompressImageBySize(imgOriginalName, imgSmallerName, image.SmallerSize); //压缩微图

                if (image.NeedSmallerWaterMark)
                {
                    AddWaterMark(imgSmallerName, image.SmallerWaterMarkType, image.SmallerWaterMarkPosition, image.SmallerWaterMarkContent, image.SmallerWaterMarkImage); //微图加水印
                }

                if (image.NeedSmallerBackGround)
                {
                    AddBackGround(imgSmallerName, image.SmallerBackGround); //微图加背景
                }
            }
        }
        #endregion

        #region 根据尺寸压缩图片的方法
        /// <summary>
        /// 根据尺寸压缩图片的方法
        /// </summary>
        /// <param name="srcImageName">压缩前的图片名称</param>
        /// <param name="destImageName">压缩后的图片名称</param>
        /// <param name="size">压缩的尺寸</param>
        private static void CompressImageBySize(string srcImageName, string destImageName, Size size)
        {
            Image srcImage = Image.FromFile(srcImageName);
            if (srcImage.Width > size.Width | srcImage.Height > size.Height) //如果图片的宽度或高度超过规定的尺寸，需要对图片进行压缩，反之不压缩，直接复制
            {
                if ((double)srcImage.Height / (double)srcImage.Width < (double)size.Height / (double)size.Width) //如果图片的高宽比小于规定的高宽比，需要按宽度等比例压缩，反之按高度等比例压缩
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

        #region 压缩图片的方法
        /// <summary>
        /// 压缩图片的方法
        /// </summary>
        /// <param name="srcImage">图片对象</param>
        /// <param name="destImageName">目标文件名</param>
        /// <param name="size">要压缩到的尺寸</param>
        private static void CompressImage(Image srcImage, string destImageName, Size size)
        {
            ImageFormat thisFormat = srcImage.RawFormat;
            Bitmap outBmp = new Bitmap(srcImage, size);
            Graphics g = Graphics.FromImage(outBmp);
            // 设置画布的描绘质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(srcImage, new Rectangle(0, 0, size.Width, size.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时,设置压缩质量
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 90; //这个参数控制了图片压缩的质量，值越大压缩质量越高
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            //获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象.
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int i = 0; i < arrayICI.Length; i++)
            {
                if (arrayICI[i].FormatDescription.Equals("JPEG"))
                {
                    //设置JPEG编码
                    jpegICI = arrayICI[i];
                    break;
                }
            }

            FileHelper.DeleteFile(destImageName); //如果要生成的图片名称已存在，需要先删除

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

        #region 添加水印的方法
        /// <summary>
        /// 添加水印的方法
        /// </summary>
        /// <param name="srcImageName">要加水印的图片名称</param>
        /// <param name="type">水印类型</param>
        /// <param name="position">水印位置</param>
        /// <param name="content">水印内容</param>
        /// <param name="watermark">水印图片</param>
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
                //如果是图片              
                case WaterMarkType.Image:
                    AddImageWatermark(g, watermark, position, srcImage.Width, srcImage.Height);
                    break;
                //如果是文字                    
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

        #region 加水印文字的方法
        /// <summary>
        /// 加水印文字的方法
        /// </summary>
        /// <param name="picture">Graphics 对象</param>
        /// <param name="watermarkText">水印文字内容</param>
        /// <param name="watermarkPosition">水印位置</param>
        /// <param name="width">被加水印图片的宽</param>
        /// <param name="height">被加水印图片的高</param>
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

        #region 加水印图片的方法
        /// <summary>
        /// 加水印图片的方法
        /// </summary>
        /// <param name="picture">Graphics 对象</param>
        /// <param name="watermark">水印图片</param>
        /// <param name="watermarkPosition">水印位置</param>
        /// <param name="width">被加水印图片的宽</param>
        /// <param name="height">被加水印图片的高</param>
        private static void AddImageWatermark(Graphics picture, Bitmap watermark, WaterMarkPosition watermarkPosition, int width, int height)
        {
            if (watermark == null) //判断背景图是否存在
            {
                throw new Exception("水印图片不存在。");
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
            int rate = 1; //这个参数控制了水印图片的大小，值越小水印图越大
            //计算水印图片的比率
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

        #region 加背景图片的方法
        /// <summary>
        /// 加背景图片的方法
        /// </summary>
        /// <param name="srcImageName">要加背景的图片名称</param>
        /// <param name="bgImage">背景图片</param>
        private static void AddBackGround(string srcImageName, Bitmap bgImage)
        {
            if (bgImage == null) //判断背景图是否存在
            {
                throw new Exception("背景图片不存在。");
            }

            int index = srcImageName.Replace("/", @"\").LastIndexOf(@"\");
            string tempImageName = srcImageName.Insert(index + 1, "bg");

            Image srcImage = Image.FromFile(srcImageName);

            if (srcImage.Width == bgImage.Width & srcImage.Height == bgImage.Height) //如果缩略图的规格等于背景图的规格，就不用添加背景图了
            {
                return;
            }

            if (srcImage.Width > bgImage.Width | srcImage.Height > bgImage.Height) //判断缩略图的规格是否小于等于背景图的规格
            {
                FileHelper.DeleteFile(tempImageName);
                srcImage.Dispose();
                bgImage.Dispose();
                throw new Exception("缩略图的规格超过了背景图的规格。");
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
