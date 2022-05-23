using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Utils;
using System;
using System.Linq;

namespace SearchAlgorithms.UnitTests.Core.Algorithms
{
    [TestClass]
    public class RabinKarpSearch_Test
    {
        [TestMethod]
        public void Search_ShouldWorkForNonAsciiCharacters()
        {
            var algo = new RabinKarpSearch();
            var results = algo.Search("żółć", "zażółć gęślą jaźń żółć");
            CollectionAssert.AreEquivalent(new int[] { 2, 18 }, results);
        }

        [TestMethod]
        public void Search_ShouldWorkForVeryLongStrings()
        {
            var algo = new RabinKarpSearch();
            var haystack = RandomString.GetRandomString(5000000);
            var needle = "a";
            var correctResults = new BuiltInSearch().Search(needle, haystack);
            var actualResults = algo.Search(needle, haystack);
            CollectionAssert.AreEquivalent(correctResults, actualResults);
        }

        [TestMethod]
        public void Search_ShouldNotBeGreedy()
        {
            var algo = new RabinKarpSearch();
            var results = algo.Search("oo", "_xxxooooxxx!");
            CollectionAssert.AreEquivalent(new int[] { 4, 5, 6 }, results);
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case1()
        {
            var algo = new RabinKarpSearch();
            CollectionAssert.AreEquivalent(new int[0], algo.Search("a", ""));
        }

        [TestMethod]
        public void Search_ShouldBehaveCorrectlyWhenNoSubstringOccurenceFound_Case2()
        {
            var algo = new RabinKarpSearch();
            CollectionAssert.AreEquivalent(new int[0], algo.Search("ab", "xxxxxxxxxxxxxxxxxxxx"));
        }

    }
}