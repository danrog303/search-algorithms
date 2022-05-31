using System;
using System.Collections.Generic;


namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Algorytm wyszukiwania podłańcuchów metodą Knutha-Morrisa-Pratta
    /// </summary>
    public class KMPSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return "Knuth-Morris-Pratt";
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        public List<int> Search(in string lookingString, in string longString)
        {
            var result = new List<int>();

            int[] lps = new int[lookingString.Length];
            int j = 0;

            ComputeLPSArray(lookingString, lps);

            int i = 0;
            while (i < longString.Length)
            {
                if (lookingString[j] == longString[i])
                {
                    j++;
                    i++;
                }
                if (j == lookingString.Length)
                {
                    result.Add(i - j);
                    j = lps[j - 1];
                }

                else if (i < longString.Length && lookingString[j] != longString[i])
                {

                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return result;
        }

        /// <summary>
        /// Funkcja ComputeLPSArray wypelnia tablicę najdłuższego prefixo-suffixu dla podanego wzorca, biorąc pod uwagę
        /// obliczone już elementy.
        /// </summary>
        /// <param name="lookingString">Szukany wzorzec</param>
        /// <param name="lps">Przechowuje najdłuższe wartości prefixo-suffixu</param>
        private static void ComputeLPSArray(string lookingString, int[] lps)
        {
            int length = 0;
            int i = 1;
            lps[0] = 0;
            while (i < lookingString.Length)
            {
                if (lookingString[i] == lookingString[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                        length = lps[length - 1];
                    else
                    {
                        lps[i] = length;
                        i++;
                    }
                }

            }
        }
    }
}
