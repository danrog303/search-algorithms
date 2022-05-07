using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;
using System;

namespace SearchAlgorithms.UnitTests.Core.Algorithms
{
    [TestClass]
    public class TestSearch_Test
    {
        [TestMethod]
        public void Search_ShouldReturn5Occurences()
        {
            var algo = new TestSearch(10);
            var results = algo.Search("ab", "fafafa-ab-ab-ab-ab-ab-12398321");
            Assert.AreEqual(5, results.Count);
        }

        [TestMethod]
        public void Search_ShouldReturn0Occurences_Case1()
        {
            var algo = new TestSearch(10);
            var results = algo.Search("ba", "fafafa-ab-ab-ab-ab-ab-12398321");
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void Search_ShouldReturn0Occurences_Case2()
        {
            var algo = new TestSearch(10);
            var results = algo.Search("ba", "");
            Assert.AreEqual(0, results.Count);
        }
    }
}
