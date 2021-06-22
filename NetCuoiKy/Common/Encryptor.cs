using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NetCuoiKy.Common
{
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5CryptoServiceProvider MD5Code = new MD5CryptoServiceProvider();
            byte[] byteDizisi = Encoding.UTF8.GetBytes(text);
            byteDizisi = MD5Code.ComputeHash(byteDizisi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in byteDizisi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}