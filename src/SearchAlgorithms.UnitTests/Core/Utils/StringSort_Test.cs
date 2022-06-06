using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.UnitTests.Core.Utils
{
    [TestClass]
    public class StringSort_Test
    {
        [TestMethod]
        public void SortCharacters_CheckIfSortingIsDoneCorrectly()
        {
            Assert.AreEqual("bdac".SortCharacters(), "abcd");
        }

        [TestMethod]
        public void SortCharacters_CheckIfSortingWorksForEmptyStrings()
        {
            Assert.AreEqual("".SortCharacters(), "");
        }
    }
}
