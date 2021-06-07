using System;
using System.Security.Cryptography;

namespace TDesWeakKeySoluation
{
    internal static class SecurityHelper
    {
        /// <summary>
        /// 3Des with weak key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] TDes(byte[] data, byte[] key)
        {
            if (key.Length > 16)
                key = key.SubArray(0, 16);
            var iv = new byte[8];
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.Zeros;
            var cTransform = tdes.CreateWeakEncryptor(key, iv);
            var result = cTransform.TransformFinalBlock(data, 0, data.Length);
            tdes.Clear();
            return result;
        }

        /// <summary>
        /// Extension method for getting sub array from array by index and length
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            if (data == null)
                return null;

            if (data.Length < length)
                return null;

            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Converting byte array to hex string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static string ByteArrayToHexString(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}
