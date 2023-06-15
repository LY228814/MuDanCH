using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace KangHui.Common
{
    /// <summary>
    /// 发短信相关方法的类
    /// </summary>
    public class SmsHelper
    {
        #region 优卡短信平台发送用户名
        private static string UcarSmsUserName
        {
            get { return EncryptionHelper.DesDecrypt("s4aK7WndD4yjqXYIbEOrTw=="); }
        }
        #endregion

        #region 优卡短信平台发送密码
        private static string UcarSmsPassword
        {
            get { return EncryptionHelper.DesDecrypt("s4aK7WndD4yjqXYIbEOrTw=="); }
        }
        #endregion

        #region 发送60个字符以内短信的方法
        /// <summary>
        /// 发送60个字符以内短信的方法      
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="message">发送内容</param>
        /// <returns>发送结果</returns>
        public static int SendMessage(string phoneList, string content)
        {
            return SendMessage(phoneList, content, "");
        }
        /// <summary>
        /// 发送60个字符以内短信的方法      
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="message">发送内容</param>
        /// <param name="userName">优卡短信平台发送用户名</param>
        /// <param name="password">优卡短信平台发送密码</param>
        /// <returns>发送结果</returns>
        public static int SendMessage(string phoneList, string content, string userName, string password)
        {
            return SendMessage(phoneList, content, "", userName, password);
        }
        /// <summary>
        /// 发送60个字符以内短信的方法      
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="message">发送内容</param>
        /// <param name="tailNumber">发送尾号</param>
        /// <returns>发送结果</returns>
        public static int SendMessage(string phoneList, string content, string tailNumber)
        {
            return SendMessage(phoneList, content, tailNumber, UcarSmsUserName, UcarSmsPassword);
        }
        /// <summary>
        /// 发送60个字符以内短信的方法      
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="message">发送内容</param>
        /// <param name="tailNumber">发送尾号</param>
        /// <param name="userName">优卡短信平台发送用户名</param>
        /// <param name="password">优卡短信平台发送密码</param>
        /// <returns>发送结果</returns>
        public static int SendMessage(string phoneList, string content, string tailNumber, string userName, string password)
        {
            Bitauto.SmsService.WebService service = new Bitauto.SmsService.WebService();
            return service.NewSendMsgNow(userName, password, phoneList, content);
        }
        #endregion

        #region 发送超过60个字符的短信的方法
        /// <summary>
        /// 发送超过60个字符的短信
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessage(string phoneList, string content)
        {
            return SendLongMessage(phoneList, content, "");
        }
        /// <summary>
        /// 发送超过60个字符的短信的方法
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <param name="userName">优卡短信平台发送用户名</param>
        /// <param name="password">优卡短信平台发送密码</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessage(string phoneList, string content, string userName, string password)
        {
            return SendLongMessage(phoneList, content, "", userName, password);
        }
        /// <summary>
        /// 发送带尾号的超过60个字符的短信的方法
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <param name="tailNumber">发送尾号</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessage(string phoneList, string content, string tailNumber)
        {
            return SendLongMessage(phoneList, content, tailNumber, UcarSmsUserName, UcarSmsPassword);
        }
        /// <summary>
        /// 发送带尾号的超过60个字符的短信的方法
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <param name="tailNumber">发送尾号</param>
        /// <param name="userName">优卡短信平台发送用户名</param>
        /// <param name="password">优卡短信平台发送密码</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessage(string phoneList, string content, string tailNumber, string userName, string password)
        {
            if (content.Length > 60)
            {
                int result1 = SendMessage(phoneList, content.Substring(0, 60), tailNumber, userName, password);
                int result2 = SendLongMessage(phoneList, content.Substring(60), tailNumber, userName, password);
                if (result1 * result2 == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return SendMessage(phoneList, content, tailNumber, userName, password);
            }
        }


        /// <summary>
        /// 发送超过60个字符的短信，让分隔字符串的内容放在一条短信中
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <param name="split">分隔字符串</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessageWithSplit(string phoneList, string content, string split)
        {
            return SendLongMessageWithSplit(phoneList, content, split, UcarSmsUserName, UcarSmsPassword);
        }
        /// <summary>
        /// 发送超过60个字符的短信，让分隔字符串的内容放在一条短信中
        /// </summary>
        /// <param name="phoneList">用逗号分割的电话号码列表</param>
        /// <param name="content">发送内容</param>
        /// <param name="split">分隔字符串</param>
        /// <param name="userName">优卡短信平台发送用户名</param>
        /// <param name="password">优卡短信平台发送密码</param>
        /// <returns>发送结果</returns>
        public static int SendLongMessageWithSplit(string phoneList, string content, string split, string userName, string password)
        {
            if (content.Length > 60)
            {
                string content1, content2;
                int splitIndex = content.IndexOf(split);
                if (splitIndex != -1)
                {
                    if (splitIndex >= 60)
                    {
                        content1 = content.Substring(0, 60);
                        content2 = content.Substring(60);
                    }
                    else
                    {
                        content1 = content.Substring(0, splitIndex);
                        content2 = content.Substring(splitIndex);
                    }
                    int result1 = SendMessage(phoneList, content1, userName, password);
                    int result2 = SendLongMessage(phoneList, content2, userName, password);
                    if (result1 * result2 == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return SendLongMessage(phoneList, content, userName, password);
                }
            }
            else
            {
                return SendMessage(phoneList, content, userName, password);
            }
        }
        #endregion

        #region 接收短信返回数据集的方法
        /// <summary>
        /// 接收短信返回数据集的方法
        /// </summary>
        /// <returns>数据集</returns>
        public static DataSet ReceiveMessage()
        {
            return ReceiveMessage(UcarSmsUserName, UcarSmsPassword);
        }
        /// <summary>
        /// 接收短信返回数据集的方法
        /// </summary>
        /// <param name="userName">优卡短信平台接收用户名</param>
        /// <param name="password">优卡短信平台接收密码</param>
        /// <returns>数据集</returns>
        public static DataSet ReceiveMessage(string userName, string password)
        {
            Bitauto.SmsService.WebService service = new Bitauto.SmsService.WebService();
            return service.UcarReceive(userName, password);
        }
        #endregion
    }
}
