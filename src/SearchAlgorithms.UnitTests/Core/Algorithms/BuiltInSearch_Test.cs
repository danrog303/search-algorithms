using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;

namespace SearchAlgorithms.UnitTests.Core.Algorithms
{
    [TestClass]
    public class BuiltInSearch_Test
    {
        [TestMethod]
        public void Search_ShouldReturn6OccurencesOfSubstring()
        {
            BuiltInSearch algo = new BuiltInSearch();
            var result = algo.Search("ab", "dd100-ab-ab-ab-ab-ab-ab-ffffff");
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void Search_ShouldReturn0OccurencesOfSubstring_Case1()
        {
            BuiltInSearch algo = new BuiltInSearch();
            Assert.AreEqual(0, algo.Search("ab", "cacaca").Count);
        }

        [TestMethod]
        public void Search_ShouldReturn0OccurencesOfSubstring_Case2()
        {
            BuiltInSearch algo = new BuiltInSearch();
            Assert.AreEqual(0, algo.Search("cac", "").Count);
        }

        [TestMethod]
        public void Search_ShouldReturn0OccurencesOfSubstring_Case3()
        {
            BuiltInSearch algo = new BuiltInSearch();
            Assert.AreEqual(0, algo.Search("12", "21").Count);
        }

        [TestMethod]
        public void Search_ShouldWorkForDigits()
        {
            var algo = new BinarySearch();
            CollectionAssert.AreEquivalent(new int[] { 6 }, algo.Search("6", "0123456789"));
        }
    }
}
