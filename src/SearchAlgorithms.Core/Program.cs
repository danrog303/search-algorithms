using SearchAlgorithms.Core.Algorithms;
using System;
using System.Collections.Generic;
using SearchAlgorithms.Core.Utils;
using SearchAlgorithms.Core.Testing.Validators;
using System.Security.Cryptography;
using SearchAlgorithms.Core.Testing.Timers;

namespace SearchAlgorithms.Core
{
    public class Program
    {
        static void Main()
        {
            var measurementResult = new PrimeNumbersTimeMeasure(MainFunc, 4500).UnifiedUnitMeasure();
            Console.WriteLine($"Wykonanie zajęło {measurementResult.ResultInReferrentialUnit} jednostek pomiaru");
            Console.WriteLine($"(czyli {measurementResult.OriginalResult} milisekund)");
            Console.ReadKey();
        }

        static void MainFunc()
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
        }
    }
}
