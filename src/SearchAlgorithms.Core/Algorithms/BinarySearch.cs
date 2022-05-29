using System;
using System.Collections.Generic;
using System.Linq;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Algorytm wyszukiwania podłańcuchów metodą drzewa binarnego.
    /// </summary>
    /// <remarks>
    /// Ważna informacja: algorytm <see cref="BinarySearch"/> działa wyłącznie dla posortowanych łańcuchów znaków,
    /// oraz tylko w przypadku gdy szukanym podłańcuchem jest pojedynczy znak.
    /// </remarks>
    public class BinarySearch : ISearchAlgorithm
    {
        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return "Binary-Tree";
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        /// <remarks>
        /// Działa wyłącznie dla posortowanego <paramref name="longString"/> oraz dla <paramref name="lookingString"/>
        /// składającego się wyłącznie z jednego znaku.
        /// </remarks>
        public List<int> Search(in string lookingString, in string longString)
        {
            if (longString.Length == 0)
            {
                return new List<int>();
            }

            string needle = lookingString[0].ToString();
            string haystack = longString.SortCharacters();

            var continueExecution = true;
            var result = new List<int>();
            var tree = new BinaryTree();

            Array.ForEach(haystack.ToCharArray(), tree.Insert);
            var currentNode = tree.RootNode;

            int analysedIndex = 0;

            while (continueExecution)
            {
                if (currentNode.Data == needle[analysedIndex])
                {
                    analysedIndex++;
                }
                else
                {
                    analysedIndex = 0;
                }

                if (analysedIndex == needle.Length)
                {
                    result.Add(currentNode.ElemNumber );
                    analysedIndex = 0;
                }

                if (currentNode.Left != null && currentNode.Left.Data >= needle[analysedIndex])
                {
                    currentNode = currentNode.Left;
                }
                else if (currentNode.Right != null && currentNode.Right.Data <= needle[analysedIndex])
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    continueExecution = false;
                }
            }

            return result;
        }
    }
}