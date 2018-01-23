using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace webapi.Common
{
    public static class EncryptHelper
    {
        #region MD5加密
        public static string MD5Encrypt(string content)
        {
            if (content == null) return null;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var enStr = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(content))).Replace("-", "");
            md5.Dispose();
            return enStr;
        }
        #endregion

        #region DES加密 解密 
        public static string DESEncrypt(string content, string key)
        {

            var rgbkey = UTF8Encoding.UTF8.GetBytes((key + "00000000").Substring(0, 8));///des加密的key必须为8位，不然会报错，以后再研究des算法的细节
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(rgbkey, rgbkey), CryptoStreamMode.Write))
            {
                encStream.Write(UTF8Encoding.UTF8.GetBytes(content), 0, UTF8Encoding.UTF8.GetBytes(content).Length);
                encStream.FlushFinalBlock();
                var enByte = ms.ToArray();
                var enBase64Str = Convert.ToBase64String(enByte);
                return enBase64Str;
            }
        }

        public static string DESDecrypt(string content, string key)
        {
            var rgbkey = UTF8Encoding.UTF8.GetBytes((key + "00000000").Substring(0, 8));///des加密的key必须为8位，不然会报错，以后再研究des算法的细节
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream encStream = new CryptoStream(ms, des.CreateDecryptor(rgbkey, rgbkey), CryptoStreamMode.Write))
            {
                var deByte = Convert.FromBase64String(content);
                encStream.Write(deByte, 0, deByte.Length);
                encStream.FlushFinalBlock();
                var deStr = UTF8Encoding.UTF8.GetString(ms.ToArray());
                return deStr;
            }
        }
        #endregion
    }
}