using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Algorytm wyszukiwania podłańcuchów metodą wyszukiwania sekwencyjnego.
    /// </summary>
    public class SequenceSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return  "Sequence";
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        public List<int> Search(in string lookingString, in string longString)
        {
            var result = new List<int>();
            int len = longString.Length - lookingString.Length, count = 0;
            for(int i = 0; i <= len; i++)
            {
                if(longString[i] == lookingString[0])
                {
                    for (int j = i, x = 0; j <= i + lookingString.Length - 1; j++, x++)
                    {
                        if (longString[j] == lookingString[x])
                        {
                            count++;
                        }
                        else break;
                    }
                }
                if(count == lookingString.Length)
                {
                    result.Add(i);
                }
                count = 0;
            }
            return result;
        }
    }
}
