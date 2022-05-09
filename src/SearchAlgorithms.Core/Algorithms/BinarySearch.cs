using System;
using System.Collections.Generic;
using System.Linq;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.Core.Algorithms
{
    // Note: this algorithm (partially) works only for strings with characters in alphabetical order
    public class BinaryTreeSearch : ISearchAlgorithm
    {
        public string Name()
        {
            return "binary tree search";
        }

        public List<int> Search(in string lookingString, in string longString)
        {
            string needle = string.Concat(lookingString.OrderBy(c => c));

            var continueExecution = true;
            var result = new List<int>();
            var tree = new BinaryTree();

            Array.ForEach(longString.ToCharArray(), tree.Insert);
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
                    result.Add(currentNode.ElemNumber);
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