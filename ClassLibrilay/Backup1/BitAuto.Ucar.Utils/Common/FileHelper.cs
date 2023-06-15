using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Net;

namespace KangHui.JianHui.Utils.Common
{
    /// <summary>
    /// ���ļ����д���Ĺ�����
    /// </summary>
    public class FileHelper
    {
        #region �ж��ļ��Ƿ���ڵķ���
        /// <summary>
        /// �ж��ļ��Ƿ���ڵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <returns>True:����,False:������</returns>
        public static bool IsExist(string srcFileName)
        {
            return File.Exists(srcFileName);
        }
        #endregion

        #region ����Ŀ¼�ķ���
        /// <summary>
        /// ����Ŀ¼�ķ���
        /// </summary>
        /// <param name="directory">Ҫ����Ŀ¼��·��</param>
        public static void CreateDirectory(string directory)
        {
            directory = directory.Replace("/", @"\");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        #endregion

        #region ȡ��չ���ķ���
        /// <summary>
        /// ȡ��չ���ķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <returns>��չ��</returns>
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

        #region �����ļ��ķ���
        /// <summary>
        /// �����ļ��ķ���
        /// </summary>
        /// <param name="srcFileName">Դ�ļ���</param>
        /// <param name="destFileName">Ŀ���ļ���</param>
        public static void CopyFile(string srcFileName, string destFileName)
        {
            DeleteFile(destFileName);
            File.Copy(srcFileName, destFileName);
        }
        #endregion

        #region ɾ���ļ��ķ���
        /// <summary>
        /// ɾ���ļ��ķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        public static void DeleteFile(string srcFileName)
        {
            if (IsExist(srcFileName))
            {
                File.Delete(srcFileName);
            }
        }
        #endregion

        #region ��ȡ�ļ����ݵķ���
        /// <summary>
        /// ��ȡ�ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <returns>�ļ�����</returns>
        public static string ReadFile(string srcFileName)
        {
            return ReadFile(srcFileName, Encoding.Default);
        }
        /// <summary>
        /// ��ȡ�ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="encoding">�ļ�����</param>
        /// <returns>�ļ�����</returns>
        public static string ReadFile(string srcFileName, Encoding encoding)
        {
            if (!IsExist(srcFileName))
            {
                throw new Exception("Ŀ���ļ�" + srcFileName + "�����ڡ�");
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

        #region ׷���ļ����ݵķ���
        /// <summary>
        /// ׷���ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="content">Ҫ׷�ӵ�����</param>
        public static void AppendFile(string srcFileName, string content)
        {
            AppendFile(srcFileName, content, Encoding.Default);
        }
        /// <summary>
        /// ׷���ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="content">Ҫ׷�ӵ�����</param>
        /// <param name="encoding">�ļ�����</param>
        public static void AppendFile(string srcFileName, string content, Encoding encoding)
        {
            UpdateOrAppendFile(srcFileName, content, encoding, FileMode.Append);
        }
        #endregion

        #region �����ļ����ݵķ���
        /// <summary>
        /// �����ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="content">Ҫ׷�ӵ�����</param>
        public static void UpdateFile(string srcFileName, string content)
        {
            UpdateFile(srcFileName, content, Encoding.Default);
        }
        /// <summary>
        /// �����ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="content">Ҫ���µ�����</param>
        /// <param name="encoding">�ļ�����</param>
        public static void UpdateFile(string srcFileName, string content, Encoding encoding)
        {
            UpdateOrAppendFile(srcFileName, content, encoding, FileMode.Create);
        }
        #endregion

        #region ���»�׷���ļ����ݵķ���
        /// <summary>
        /// ���»�׷���ļ����ݵķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="content">Ҫ׷�ӵ�����</param>
        /// <param name="encoding">�ļ�����</param>
        /// <param name="mode">���ļ��ķ�ʽ</param>
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

        #region �����ϴ��ļ��ķ���
        /// <summary>
        /// �����ϴ��ļ��ķ���
        /// </summary>
        /// <param name="fileLocalPath">�ļ�����������·��</param>
        /// <param name="fileDbPath">�ļ������ݿⴢ���·��</param>
        /// <param name="postedFile">�ϴ����ļ�����</param>
        public static void SaveFile(string fileLocalPath, ref string fileDbPath, HttpPostedFile postedFile)
        {
            SaveFile(fileLocalPath, "", ref fileDbPath, postedFile);
        }
        /// <summary>
        /// �����ϴ��ļ��ķ���
        /// </summary>
        /// <param name="fileLocalPath">�ļ�����������·��</param>
        /// <param name="childFolder">�ļ���Ŀ¼</param>
        /// <param name="fileDbPath">�ļ������ݿⴢ���·��</param>
        /// <param name="postedFile">�ϴ����ļ�����</param>
        public static void SaveFile(string fileLocalPath, string childFolder, ref string fileDbPath, HttpPostedFile postedFile)
        {
            if (postedFile == null)
            {
                throw new Exception("�ϴ����ļ�������ΪNull��");
            }

            //��ʽ���ļ�����������·��
            fileLocalPath = fileLocalPath.Replace("/", @"\"); 
            if (!fileLocalPath.EndsWith(@"\")) 
            {
                fileLocalPath += @"\";
            }

            //��ʽ���ļ���Ŀ¼
            if (!string.IsNullOrEmpty(childFolder))
            {
                childFolder = childFolder.Replace("/", @"\");
                childFolder = childFolder.TrimStart(new char[] { '\\' });
                if (!childFolder.EndsWith(@"\")) 
                {
                    childFolder += @"\";
                }
            }

            string fileDirectory = DateTime.Now.ToString("yyyyMMdd"); //�ļ�Ŀ¼
            string fileName = DateTime.Now.ToString("HHmmssfff"); //�ļ�����
            string suffixName = GetSuffix(postedFile.FileName); //�ļ���չ��
            fileDbPath = fileDirectory + "/" + fileName + suffixName; //�ļ������ݿⴢ���·��

            CreateDirectory(fileLocalPath + childFolder + fileDirectory); //����Ŀ¼
            postedFile.SaveAs(fileLocalPath + childFolder + fileDbPath); //�����ļ�
        }
        #endregion

        #region �����ļ��ķ���
        /// <summary>
        /// �����ļ��ķ���
        /// </summary>
        /// <param name="srcFileName">�����ļ���</param>
        /// <param name="showName">������ʾ���ļ���</param>
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

        #region ��ȡ�����ļ����ݵķ���
        /// <summary>
        /// ��ȡ�����ļ����ݵķ���
        /// </summary>
        /// <param name="url">�����ļ�·��</param>
        /// <returns>�����ļ�����</returns>
        public static string ReadWebFile(string url)
        {
            return ReadWebFile(url, Encoding.Default);
        }
        /// <summary>
        /// ��ȡ�����ļ����ݵķ���
        /// </summary>
        /// <param name="url">�����ļ�·��</param>
        /// <param name="encoding">�����ļ�����</param>
        /// <returns>�����ļ�����</returns>
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

        #region ��ȡָ��Ŀ¼�������ļ����ķ���
        /// <summary>
        /// ��ȡָ��Ŀ¼�������ļ����ķ���
        /// </summary>
        /// <param name="path">ָ����Ŀ¼</param>
        /// <param name="includeChildFolder">�Ƿ������Ŀ¼</param>
        /// <returns>��ȡ�����ļ���</returns>
        public static string[] GetFiles(string path, bool includeChildFolder)
        {
            return GetFiles(path, null, includeChildFolder);
        }
        /// <summary>
        /// ��ȡָ��Ŀ¼�������ļ����ķ���
        /// </summary>
        /// <param name="path">ָ����Ŀ¼</param>
        /// <param name="filters">�ļ�����������</param>
        /// <param name="includeChildFolder">�Ƿ������Ŀ¼</param>
        /// <returns>��ȡ�����ļ���</returns>
        public static string[] GetFiles(string path, string[] filters, bool includeChildFolder)
        {
            List<string> fileList = new List<string>();
            return GetFiles(path, filters, includeChildFolder, fileList);
        }
        /// <summary>
        /// ��ȡָ��Ŀ¼�������ļ����ķ���
        /// </summary>
        /// <param name="path">ָ����Ŀ¼</param>
        /// <param name="filters">�ļ�����������</param>
        /// <param name="includeChildFolder">�Ƿ������Ŀ¼</param>
        /// <param name="fileList">�ļ��б�</param>
        /// <returns>��ȡ�����ļ���</returns>
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
