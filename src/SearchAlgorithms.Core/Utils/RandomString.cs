using System;
using System.Security.Cryptography;

namespace SearchAlgorithms.Core.Utils
{
    public static class RandomString
    {
        public static string GetRandomString(int stringLength)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bitCount = (stringLength * 6);
                var byteCount = ((bitCount + 7) / 8);
                var bytes = new byte[byteCount];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
