using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Utils;
using System;

namespace SearchAlgorithms.UnitTests.Core.Utils
{
    [TestClass]
    public class RandomString_Test
    {
        [TestMethod]
        public void GetRandomString_StringExpectedToHaveCorrectLength()
        {
            Assert.AreEqual(512, RandomString.GetRandomString(512).Length);
        }
    }
}
