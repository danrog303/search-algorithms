using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Klasa zawierająca wzorcowy algorytm wyszukiwania podłańcuchów. Zakładamy, że algorytm <see cref="BuiltInSearch"/>
    /// zwraca zawsze poprawne dane i nigdy się nie myli.
    /// </summary>
    public class BuiltInSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return "Built-In-Search";
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        public List<int> Search(in string lookingString, in string longString)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < longString.Length; i++)
            {
                if (i + lookingString.Length - 1 < longString.Length && lookingString[0] == longString[i])
                {
                    bool isFound = true;
                    for (int j = 1; j < lookingString.Length; j++)
                    {
                        if (lookingString[j] != longString[i + j])
                        {
                            isFound = false;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }
    }
}
