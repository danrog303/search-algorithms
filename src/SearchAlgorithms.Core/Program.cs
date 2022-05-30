﻿using SearchAlgorithms.Core.Algorithms;
using System;
using System.Collections.Generic;
using SearchAlgorithms.Core.Utils;
using SearchAlgorithms.Core.Testing.Validators;
using System.Security.Cryptography;
using SearchAlgorithms.Core.Testing.Timers;

namespace SearchAlgorithms.Core
{
    /// <summary>
    /// Klasa będąca punktem startowym interfejsu tekstowego.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Funkcja główna, wywoływana w momencie uruchomienia programu. Wywołuje funkcję MainFunc,
        /// mierząc jej czas wykonania.
        /// </summary>
        static void Main()
        {
            var measurementResult = new PrimeNumbersTimeMeasure(4500).UnifiedUnitMeasure(MainFunc);
            Console.WriteLine($"Wykonanie zajęło {measurementResult.ResultInReferrentialUnit} jednostek pomiaru");
            Console.WriteLine($"(czyli {measurementResult.OriginalResult} milisekund)");
            Console.ReadKey();
        }

        /// <summary>
        /// Funkcja zawierające właściwe działanie interfejsu tekstowego.
        /// </summary>
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
