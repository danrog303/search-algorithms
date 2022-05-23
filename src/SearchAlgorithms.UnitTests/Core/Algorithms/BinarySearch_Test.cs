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
        public void Search_GroupedNonAsciiCharacters()
        {
            var algo = new BinarySearch();
            var results = algo.Search("ę", "ąąą ćęę ł"); // Returns incorrect resul for grouped characters
            CollectionAssert.AreEquivalent(new int[2] { 5, 6 }, results);
        }

        [TestMethod]
        public void
            Search_ShouldWorkForVeryLongStrings() // *BinarySearch is only capable of searching strings in alphabetical order
        {
            var algo = new BinarySearch();
            var haystack = "abcdefghijklmnopqrstuvwxyz";
            var needle = "o";
            var correctResults = new BuiltInSearch().Search(needle, haystack);
            var actualResults = algo.Search(needle, haystack);
            CollectionAssert.AreEquivalent(correctResults, actualResults);
        }

        /*[TestMethod]
        public void Search_ShouldNotBeGreedy()
        {
            var algo = new BinarySearch();
            var results = algo.Search("a", "aa"); // Only works for single characters
            CollectionAssert.AreEquivalent(new int[] { 1 }, results);
        }*/

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