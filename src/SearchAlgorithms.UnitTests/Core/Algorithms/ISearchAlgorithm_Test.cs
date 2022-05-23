using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Utils;
using System;
using System.Linq;

namespace SearchAlgorithms.UnitTests.Core.Algorithms
{
    [TestClass]
    public class ISearchAlgorithm_Test
    {
        [TestMethod]
        public void Search_ShouldWorkForNonAsciiCharacters()
        {
            var algo = new BuiltInSearch(); // Couldn't find ISearchAlgorithm in Algorithms directory
            // Replace BuiltInSearch() with ISearchAlgorithm() later on
            var results = algo.Search("żółć", "zażółć gęślą jaźń żółć");
            CollectionAssert.AreEquivalent(new int[] { 2, 18 }, results);
        }

        [TestMethod]
        public void Search_ShouldWorkForVeryLongStrings()
        {
            var algo = new BuiltInSearch();
            var haystack = RandomString.GetRandomString(5000000);
            var needle = "a";
            var correctResults = new BuiltInSearch().Search(needle, haystack);
            var actualResults = algo.Search(needle, haystack);
            CollectionAssert.AreEquivalent(correctResults, actualResults);
        }

        [TestMethod]
        public void Search_ShouldNotBeGreedy()
        {
            var algo = new BuiltInSearch();
            var results = algo.Search("oo", "_xxxooooxxx!");
            CollectionAssert.AreEquivalent(new int[] { 4, 5, 6 }, results);
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case1()
        {
            var algo = new BuiltInSearch();
            CollectionAssert.AreEquivalent(new int[0], algo.Search("ab", ""));
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case2()
        {
            var algo = new BuiltInSearch();
            CollectionAssert.AreEquivalent(new int[0], algo.Search("ab", "xxxxxxxxxxxxxxxxxxxx"));
        }

        [TestMethod]
        public void Search_ShouldWorkForDigits()
        {
            var algo = new BinarySearch();
            CollectionAssert.AreEquivalent(new int[] { 6 }, algo.Search("6", "0123456789"));
        }
    }
}