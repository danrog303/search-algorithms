using SearchAlgorithms.Core.Algorithms;
using System;
using System.Collections.Generic;
using SearchAlgorithms.Core.Utils;
using SearchAlgorithms.Core.Testing.Validators;
using System.Security.Cryptography;

namespace SearchAlgorithms.Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            var currentlyCheckedAlgorithm = new KMPSearch();
            var correctlyWorkingAlgorithm = new BuiltInSearch();

            string haystack = "oooo";
            string needle = "oo";

            Console.WriteLine(haystack);
            Console.WriteLine(needle);

            Console.WriteLine(currentlyCheckedAlgorithm.Name());
            Array.ForEach(currentlyCheckedAlgorithm.Search(needle, haystack).ToArray(), Console.WriteLine);
            Console.WriteLine(correctlyWorkingAlgorithm.Name());
            Array.ForEach(correctlyWorkingAlgorithm.Search(needle, haystack).ToArray(), Console.WriteLine);


            Console.ReadKey();
        }

        static string GetRandomString(int string_length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (string_length * 6);
                var byte_count = ((bit_count + 7) / 8);
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
