using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;
using System.IO;

namespace Ucar.Common
{
    /// <summary>
    /// 用于进行字符串加密的类
    /// </summary>
    public class EncryptionHelper
    {
        #region DES加密密钥
        /// <summary>
        /// DES加密密钥
        /// </summary>
        private const string m_EncryptKey = "auto@#$&";
        #endregion

        #region DES方式加密字符串的方法
        /// <summary>
        /// DES方式加密字符串的方法
        /// </summary>
        /// <param name="source">要进行加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string DesEncrypt(string source)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = Encoding.Default.GetBytes(m_EncryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.Default.GetBytes(source);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("DES方式加密字符串失败。错误信息：" + ex.Message);
            }
        }
        #endregion

        #region DES方式解密字符串的方法
        /// <summary>
        /// DES方式解密字符串的方法
        /// </summary>
        /// <param name="source">要进行解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(string source)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[source.Length];
            try
            {
                byKey = Encoding.Default.GetBytes(m_EncryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(source);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("DES方式解密字符串失败。错误信息：" + ex.Message);
            }
        }
        #endregion

        #region MD5方式加密字符串的方法
        /// <summary>
        /// MD5方式加密字符串的方法
        /// </summary>
        /// <param name="source">要进行加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypt(string source)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(source));
                string returnResult = "";
                for (int i = 0; i < result.Length; i++)
                {
                    returnResult += result[i].ToString("x");
                }
                return returnResult;
            }
            catch (Exception ex)
            {
                throw new Exception("MD5方式加密字符串失败。错误信息：" + ex.Message);
            }
        }
        #endregion

        #region SHA1方式加密字符串的方法
        /// <summary>
        /// SHA1方式加密字符串的方法
        /// </summary>
        /// <param name="source">要进行加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA1Encrypt(string source)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] result = sha1.ComputeHash(Encoding.Default.GetBytes(source));
                string returnResult = "";
                for (int i = 0; i < result.Length; i++)
                {
                    returnResult += result[i].ToString("x");
                }
                return returnResult;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1方式加密字符串失败。错误信息：" + ex.Message);
            }
        }
        #endregion
    }
}
