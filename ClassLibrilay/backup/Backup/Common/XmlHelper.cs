using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Xml;

namespace Ucar.Common
{
    /// <summary>
    /// 对XML文件进行处理的类
    /// </summary>
    public class XmlHelper
    {
        #region 获得Xml文档对象的方法
        /// <summary>
        /// 获得Xml文档对象的方法
        /// </summary>
        /// <param name="fullFileName">XML完整文件名</param>
        /// <returns>Xml文档对象</returns>
        public static XmlDocument GetXmlDocument(string fullFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fullFileName);
                return doc;
            }
            catch
            {
                throw new Exception("XML文件" + fullFileName + "不存在或拒绝访问。");
            }
        }
        #endregion

        #region 根据标记名称获得数据集合的方法
        /// <summary>
        /// 根据标记名称获得数据集合的方法
        /// </summary>
        /// <param name="fileName">XML完整文件名</param>
        /// <param name="tagName">标记名称</param>
        /// <returns>数据集合</returns>
        public static ArrayList GetArrayListByTagName(string fileName, string tagName)
        {
            XmlDocument doc = GetXmlDocument(fileName);
            XmlNodeList nodeList = doc.DocumentElement.GetElementsByTagName(tagName);
            ArrayList al = new ArrayList();
            for (int i = 0; i < nodeList.Count; i++)
            {
                al.Add(nodeList[i].InnerText);
            }
            return al;
        }
        #endregion
    }
}
