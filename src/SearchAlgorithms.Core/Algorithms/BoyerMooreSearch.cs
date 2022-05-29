using System;
using System.Collections.Generic;
namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Algorytm wyszukiwania podłańcuchów metodą Boyera-Moore'a.
    /// </summary>
    /// <remarks>
    /// Ważna informacja: algorytm <see cref="BoyerMooreSearch"/> działa wyłącznie dla znaków z tablicy ASCII.
    /// </remarks>
    public class BoyerMooreSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Pole przechowujące maksymalny zakres znaków, który może wyszukać algorytm.
        /// W przypadku obecnej implementacji jest to 256, czyli cała tabela znaków ASCII
        /// </summary>
        private static int StringLength = 256;

        /// <summary>
        /// Metoda realizująca heurystykę złego znaku.
        /// </summary>
        /// <param name="str">TODO: FILL THIS ENTRY</param>
        /// <param name="size">TODO: FILL THIS ENTRY</param>
        /// <param name="badchar">TODO: FILL THIS ENTRY</param>
        private static void BadCharHeuristic(string str, int size, int[] badchar)
        {
            int i;

            // Zainicjuj wszystkie wystąpienia jako -1
            for (i = 0; i < StringLength; i++)
            {
                badchar[i] = -1;
            }

            // Wypełnij rzeczywistą wartość ostatniego wystąpienia  postaci
            for (i = 0; i < size; i++)
            {
                badchar[(int) str[i]] = i;
            }
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return "Boyer-Moore";
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        /// <remarks>
        /// Działa poprawnie wyłącznie wtedy, jeśli oba przekazane parametry składają się ze znaków z tabeli ASCII.
        /// </remarks>
        public List<int> Search(in string lookingString, in string longString)
        {
            var result = new List<int>();
            int m = lookingString.Length;
            int n = longString.Length;

            int[] badchar = new int[StringLength];

            // Wypełnij tablicę złych znaków, wywołując funkcję przetwarzania wstępnego
            // BadCharHeuristic() dla danego wzoru
            BadCharHeuristic(lookingString, m, badchar);

            int s = 0; // s to przesunięcie wzorca o szacunek do tekstu
            while (s <= (n - m))
            {
                int j = m - 1;

                // Zmniejszanie indeksu j wzoru, podczas gdy znaki wzoru i tekstu są
                // dopasowanie na tej zmianie s
                while (j >= 0 && lookingString[j] == longString[s + j])
                    j--;

                // Jeśli wzorzec jest obecny w bieżącym przesunięciu, wtedy indeks j zmieni się na -1
                if (j < 0)
                {
                    result.Add(s);

                    // Przesunięcie wzóru tak, aby następny znak w tekście był zgodny z ostatnim
                    // występowaniu tego we wzorcu. Warunek s+m < n jest konieczny dla
                    // przypadku, gdy wzór występuje na końcu tekstu
                    s += (s + m < n) ? m - badchar[longString[s + m]] : 1;

                }
                else
                {
                    // Przesuwa wzorzec tak, aby zły znak w tekście wyrównał się z ostatnim wystąpieniem we wzorcu. 
                    // Funkcja Max służy do upewnienia się, że otrzymamy pozytywną zmianę.
                    // Możemy uzyskać ujemne przesunięcie, jeśli ostatnie występowanie złego znaku we wzorcu
                    // jest po prawej stronie obecnej postaci.
                   s += Math.Max(1, j - badchar[longString[s + j]]);
                }
            }
            return result;
        }
    }
}