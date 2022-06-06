using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Utils;
using System;
using System.Linq;

namespace SearchAlgorithms.UnitTests.Core.Algorithms
{
    [TestClass]
    public class BinarySearch_Test
    {
        [TestMethod]
        public void Search_ShouldWorkForNonAsciiCharacters()
        {
            var algo = new BinarySearch();
            var results = algo.Search("ć", "ąąą ćę ł"); // Works only for single characters
            CollectionAssert.AreEquivalent(new int[] { 5 }, results);
        }

        [TestMethod]
        public void Search_ShouldWorkForStringsWithModerateLength()
        {
            var algo = new BinarySearch();
            var correctlyWorkingAlgo = new BuiltInSearch();
            var haystack = RandomString.GetRandomString(10000).SortCharacters();
            var needle = haystack[0].ToString();
            var results = algo.Search(needle, haystack); 
            var correctResults = correctlyWorkingAlgo.Search(needle, haystack);
            CollectionAssert.AreEquivalent(correctResults, results);
        }

        [TestMethod]
        public void Search_ShouldntWorkForStringsWithLengthOverTenThousand()
        {
            var algo = new BinarySearch();
            var haystack = RandomString.GetRandomString(500000).SortCharacters();
            var needle = haystack[0].ToString();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => algo.Search(needle, haystack));
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case1()
        {
            var algo = new BinarySearch();
            CollectionAssert.AreEquivalent(new int[] { }, algo.Search("a", ""));
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case2()
        {
            var algo = new BinarySearch();
            CollectionAssert.AreEquivalent(new int[0], algo.Search("a", "xxxxxxxxxxxxxxxxxxxx"));
        }

        [TestMethod]
        public void Search_ShouldWorkForDigits()
        {
            var algo = new BinarySearch();
            CollectionAssert.AreEquivalent(new int[] { 6 }, algo.Search("6", "0123456789"));
        }
    }
}