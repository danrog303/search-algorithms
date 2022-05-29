using System;
using System.Security.Cryptography;

namespace SearchAlgorithms.Core.Utils
{
    /// <summary>
    /// Klasa pomocnicza służąca do generowania kryptograficznie bezpiecznych losowych ciągów znaków.
    /// </summary>
    public static class RandomString
    {
        /// <summary>
        /// Funkcja pomocnicza zwracająca kryptograficznie bezpieczny ciąg znaków o wskazanej długości.
        /// </summary>
        /// <param name="stringLength">Żądana długość wynikowego łańcucha.</param>
        /// <returns>Zwraca kryptograficznie bezpieczny ciąg znaków o wskazanej długości.</returns>
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
