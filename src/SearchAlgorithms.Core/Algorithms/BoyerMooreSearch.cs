using System;
using System.Collections.Generic;



namespace SearchAlgorithms.Core.Algorithms

{



    public class BoyerMooreSearch : ISearchAlgorithm

    {

        private static int StringLength = 256;


        //heurystyka złego znaku
        private static void BadCharHeuristic(string str, int size, int[] badchar)
        {
            int i;

            // Zainicjuj wszystkie wystąpienia jako -1
            for (i = 0; i < StringLength; i++)
                badchar[i] = -1;

            // Wypełnij rzeczywistą wartość ostatniego wystąpienia  postaci
            for (i = 0; i < size; i++)
                badchar[(int)str[i]] = i;
        }

        /* Funkcja wyszukiwania wzorców, która używa Bad Heurystyka znaków */

        public string Name()

        {

            return "Boyer Moore";

        }



        public List<int> Search(in string lookingString, in string longString)

        {
            var result = new List<int>();
            int m = lookingString.Length;
            int n = longString.Length;

            int[] badchar = new int[StringLength];

            /* Wypełnij tablicę złych znaków, wywołując
                funkcja przetwarzania wstępnego badCharHeuristic()
                dla danego wzoru */
            BadCharHeuristic(lookingString, m, badchar);

            int s = 0; // s to przesunięcie wzorca o szacunek do tekstu
            while (s <= (n - m))
            {
                int j = m - 1;


                /*  zmniejszanie indeksu j wzoru, podczas gdy
                 znaki wzoru i tekstu są
               dopasowanie na tej zmianie s */
                while (j >= 0 && lookingString[j] == longString[s + j])
                    j--;

                /* Jeśli wzorzec jest obecny w bieżącym
                    przesunięciu, wtedy indeks j zmieni się na -1  */
                if (j < 0)
                {
                    result.Add(s);

                    /* Przesunięcie wzóru tak, aby następny
                        znak w tekście był zgodny z ostatnim
                        występowaniu tego we wzorcu.
                        Warunek s+m < n jest konieczny dla
                        przypadku, gdy wzór występuje na końcu
                        tekstu */
                    s += (s + m < n) ? m - badchar[longString[s + m]] : 1;

                }

                else
                    /* Przesuwa wzorzec tak, aby zły znak
                        w tekście wyrównał się z ostatnim wystąpieniem
                         we wzorcu. Funkcja max służy do
                        upewnij się, że otrzymamy pozytywną zmianę.
                        Możemy uzyskać ujemne przesunięcie, jeśli ostatnie
                        występowanie złego charakteru we wzorcu
                        jest po prawej stronie obecnej postać. */
                    s += Math.Max(1, j - badchar[longString[s + j]]);
            }


            return result;
        }

    }

}
