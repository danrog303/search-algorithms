using SearchAlgorithms.Core.Algorithms;
using System;
using System.Linq;
using System.Reflection;
using SearchAlgorithms.Core.Testing.Timers;
using SearchAlgorithms.Core.Testing.Validators;
using System.Collections.Generic;

namespace SearchAlgorithms.Core
{
    /// <summary>
    /// Klasa będąca punktem startowym interfejsu tekstowego.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Funkcja główna, wywoływana w momencie uruchomienia programu. Realizuje funkcję interfejsu tekstowego użytkownika.
        /// </summary>
        static void Main()
        {
            string haystack, needle;
            Console.WriteLine("Search-Algorithms CLI");
            Console.Write("\nPodaj tekst, w którym chcesz wykonywać wyszukiwanie:\n> ");
            haystack = Console.ReadLine();
            Console.Write("\nPodaj tekst, który chcesz wyszukać:\n>");
            needle = Console.ReadLine();
            Console.WriteLine();

            ISearchAlgorithm[] algorithms = new ISearchAlgorithm[] {
                new BinarySearch(), new BoyerMooreSearch(), new HashSearch(),
                new KMPSearch(), new RabinKarpSearch(), new SequenceSearch()
            };

            PrimeNumbersTimeMeasure tm = new PrimeNumbersTimeMeasure();

            foreach (ISearchAlgorithm algo in algorithms)
            {
                Console.WriteLine($"Algorytm: {algo.Name()}");

                try
                {
                    SearchAlgorithmValidator validator = new SearchAlgorithmValidator(algo);
                    List<int> results = null;
                    UnifiedUnitTimeMeasure.MeasurementResult time = tm.UnifiedUnitMeasure(() => {
                        results = algo.Search(needle, haystack);
                    });
                    Console.WriteLine($"Wynik działania: {string.Join(" ", results)}");
                    Console.WriteLine($"Wykonanie zajęło {time.ResultInReferrentialUnit} jednostek pomiaru ({time.OriginalResult} ms)");
                    Console.WriteLine($"Walidacja: {(validator.Validate(needle, haystack) ? "wynik prawidłowy\n" : "wynik nieprawidłowy\n")}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd! Nastąpił wyjątek typu {ex.GetType().Name}.");
                    Console.WriteLine("Wyszukiwanie tym algorytmem nie może zostać dokończone.\n");
                }
            }

            Console.ReadKey();
        }
    }
}
