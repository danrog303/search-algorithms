using System;
using System.Collections.Generic;


namespace SearchAlgorithms.Core.Algorithms
{
    public class KMPAlgoritm : ISearchAlgorithm
    {

        public string Name()
        {
            return "Knutha-Morrisa-Pratta";
        }

        public List<int> Search(in string lookingString, in string longString) {
            var result = new List<int>();

            int M = lookingString.Length;
            int N = longString.Length;

            int[] lps = new int[M];
            int j = 0;

            ComputeLPSArray(lookingString, M, lps);

            int i = 0;
            while (i < N)
            {
                if (lookingString[j] == longString[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    result.Add(i - j);
                    j = lps[j - 1];
                }

                else if (i < N && lookingString[j] != longString[i])
                {

                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }

            return result;
        }

        private static void ComputeLPSArray(string lookingString, int a, int[] lps)
        {
            int length = 0;
            int i = 1;
            lps[0] = 0;
            while (i < a)
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
                    }
                }

            }
        }
    }
}
