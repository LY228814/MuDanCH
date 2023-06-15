using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Net;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// 对文件进行处理的功能类
    /// </summary>
    public class FileHelper
    {
        #region 判断文件是否存在的方法
        /// <summary>
        /// 判断文件是否存在的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <returns>True:存在,False:不存在</returns>
        public static bool IsExist(string srcFileName)
        {
            return File.Exists(srcFileName);
        }
        #endregion

        #region 创建目录的方法
        /// <summary>
        /// 创建目录的方法
        /// </summary>
        /// <param name="directory">要创建目录的路径</param>
        public static void CreateDirectory(string directory)
        {
            directory = directory.Replace("/", @"\");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        #endregion

        #region 取扩展名的方法
        /// <summary>
        /// 取扩展名的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <returns>扩展名</returns>
        public static string GetSuffix(string srcFileName)
        {
            int pos = srcFileName.LastIndexOf(".");
            if (pos != -1)
            {
                return srcFileName.ToLower().Substring(pos);
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region 复制文件的方法
        /// <summary>
        /// 复制文件的方法
        /// </summary>
        /// <param name="srcFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        public static void CopyFile(string srcFileName, string destFileName)
        {
            DeleteFile(destFileName);
            File.Copy(srcFileName, destFileName);
        }
        #endregion

        #region 删除文件的方法
        /// <summary>
        /// 删除文件的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        public static void DeleteFile(string srcFileName)
        {
            if (IsExist(srcFileName))
            {
                File.Delete(srcFileName);
            }
        }
        #endregion

        #region 读取文件内容的方法
        /// <summary>
        /// 读取文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <returns>文件内容</returns>
        public static string ReadFile(string srcFileName)
        {
            return ReadFile(srcFileName, Encoding.Default);
        }
        /// <summary>
        /// 读取文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="encoding">文件编码</param>
        /// <returns>文件内容</returns>
        public static string ReadFile(string srcFileName, Encoding encoding)
        {
            if (!IsExist(srcFileName))
            {
                throw new Exception("目标文件" + srcFileName + "不存在。");
            }
            StringBuilder sBuilder = new StringBuilder("");
            using (StreamReader sr = new StreamReader(srcFileName, encoding))
            {
                if (sr != null)
                {
                    sBuilder.Append(sr.ReadToEnd());
                }
            }
            return sBuilder.ToString();
        }
        #endregion

        #region 追加文件内容的方法
        /// <summary>
        /// 追加文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="content">要追加的内容</param>
        public static void AppendFile(string srcFileName, string content)
        {
            AppendFile(srcFileName, content, Encoding.Default);
        }
        /// <summary>
        /// 追加文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="content">要追加的内容</param>
        /// <param name="encoding">文件编码</param>
        public static void AppendFile(string srcFileName, string content, Encoding encoding)
        {
            UpdateOrAppendFile(srcFileName, content, encoding, FileMode.Append);
        }
        #endregion

        #region 更新文件内容的方法
        /// <summary>
        /// 更新文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="content">要追加的内容</param>
        public static void UpdateFile(string srcFileName, string content)
        {
            UpdateFile(srcFileName, content, Encoding.Default);
        }
        /// <summary>
        /// 更新文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="content">要更新的内容</param>
        /// <param name="encoding">文件编码</param>
        public static void UpdateFile(string srcFileName, string content, Encoding encoding)
        {
            UpdateOrAppendFile(srcFileName, content, encoding, FileMode.Create);
        }
        #endregion

        #region 更新或追加文件内容的方法
        /// <summary>
        /// 更新或追加文件内容的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="content">要追加的内容</param>
        /// <param name="encoding">文件编码</param>
        /// <param name="mode">打开文件的方式</param>
        private static void UpdateOrAppendFile(string srcFileName, string content, Encoding encoding, FileMode mode)
        {
            int pos = srcFileName.LastIndexOf(@"\");
            if (pos != -1)
            {
                string directory = srcFileName.Substring(0, pos);
                CreateDirectory(directory);

                using (FileStream fs = new FileStream(srcFileName, mode))
                {
                    byte[] bContent = encoding.GetBytes(content);
                    fs.Write(bContent, 0, bContent.Length);
                }
            }
        }
        #endregion

        #region 保存上传文件的方法
        /// <summary>
        /// 保存上传文件的方法
        /// </summary>
        /// <param name="fileLocalPath">文件服务器物理路经</param>
        /// <param name="fileDbPath">文件在数据库储存的路径</param>
        /// <param name="postedFile">上传的文件对象</param>
        public static void SaveFile(string fileLocalPath, ref string fileDbPath, HttpPostedFile postedFile)
        {
            SaveFile(fileLocalPath, "", ref fileDbPath, postedFile);
        }
        /// <summary>
        /// 保存上传文件的方法
        /// </summary>
        /// <param name="fileLocalPath">文件服务器物理路经</param>
        /// <param name="childFolder">文件子目录</param>
        /// <param name="fileDbPath">文件在数据库储存的路径</param>
        /// <param name="postedFile">上传的文件对象</param>
        public static void SaveFile(string fileLocalPath, string childFolder, ref string fileDbPath, HttpPostedFile postedFile)
        {
            if (postedFile == null)
            {
                throw new Exception("上传的文件对象不能为Null。");
            }

            //格式化文件服务器物理路径
            fileLocalPath = fileLocalPath.Replace("/", @"\"); 
            if (!fileLocalPath.EndsWith(@"\")) 
            {
                fileLocalPath += @"\";
            }

            //格式化文件子目录
            if (!string.IsNullOrEmpty(childFolder))
            {
                childFolder = childFolder.Replace("/", @"\");
                childFolder = childFolder.TrimStart(new char[] { '\\' });
                if (!childFolder.EndsWith(@"\")) 
                {
                    childFolder += @"\";
                }
            }

            string fileDirectory = DateTime.Now.ToString("yyyyMMdd"); //文件目录
            string fileName = DateTime.Now.ToString("HHmmssfff"); //文件名称
            string suffixName = GetSuffix(postedFile.FileName); //文件扩展名
            fileDbPath = fileDirectory + "/" + fileName + suffixName; //文件在数据库储存的路径

            CreateDirectory(fileLocalPath + childFolder + fileDirectory); //创建目录
            postedFile.SaveAs(fileLocalPath + childFolder + fileDbPath); //保存文件
        }
        #endregion

        #region 下载文件的方法
        /// <summary>
        /// 下载文件的方法
        /// </summary>
        /// <param name="srcFileName">完整文件名</param>
        /// <param name="showName">下载显示的文件名</param>
        public static void DownloadFile(string srcFileName, string showName)
        {
            FileInfo file = new FileInfo(srcFileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(showName, Encoding.UTF8));
            HttpContext.Current.Response.AppendHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 读取网络文件内容的方法
        /// <summary>
        /// 读取网络文件内容的方法
        /// </summary>
        /// <param name="url">网络文件路径</param>
        /// <returns>网络文件内容</returns>
        public static string ReadWebFile(string url)
        {
            return ReadWebFile(url, Encoding.Default);
        }
        /// <summary>
        /// 读取网络文件内容的方法
        /// </summary>
        /// <param name="url">网络文件路径</param>
        /// <param name="encoding">网络文件编码</param>
        /// <returns>网络文件内容</returns>
        public static string ReadWebFile(string url, Encoding encoding)
        {
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream readStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(readStream, encoding);
            return sr.ReadToEnd();
        }
        #endregion

        #region 获取指定目录下所有文件名的方法
        /// <summary>
        /// 获取指定目录下所有文件名的方法
        /// </summary>
        /// <param name="path">指定的目录</param>
        /// <param name="includeChildFolder">是否包含子目录</param>
        /// <returns>获取到的文件名</returns>
        public static string[] GetFiles(string path, bool includeChildFolder)
        {
            return GetFiles(path, null, includeChildFolder);
        }
        /// <summary>
        /// 获取指定目录下所有文件名的方法
        /// </summary>
        /// <param name="path">指定的目录</param>
        /// <param name="filters">文件名过滤条件</param>
        /// <param name="includeChildFolder">是否包含子目录</param>
        /// <returns>获取到的文件名</returns>
        public static string[] GetFiles(string path, string[] filters, bool includeChildFolder)
        {
            List<string> fileList = new List<string>();
            return GetFiles(path, filters, includeChildFolder, fileList);
        }
        /// <summary>
        /// 获取指定目录下所有文件名的方法
        /// </summary>
        /// <param name="path">指定的目录</param>
        /// <param name="filters">文件名过滤条件</param>
        /// <param name="includeChildFolder">是否包含子目录</param>
        /// <param name="fileList">文件列表</param>
        /// <returns>获取到的文件名</returns>
        private static string[] GetFiles(string path, string[] filters, bool includeChildFolder, List<string> fileList)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    if (filters != null)
                    {
                        foreach (string filter in filters)
                        {
                            if (file.ToLower().IndexOf(filter.ToLower()) >= 0)
                            {
                                fileList.Add(file);
                            }
                        }
                    }
                    else
                    {
                        fileList.Add(file);
                    }
                }
            }

            if (includeChildFolder)
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    GetFiles(directory, filters, includeChildFolder, fileList);
                }
            }

            return fileList.ToArray();
        }
        #endregion
    }
}
