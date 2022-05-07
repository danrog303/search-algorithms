using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.UnitTests.Core.Utils
{
    [TestClass]
    public class PrimeNumberUtils_Test
    {
        [TestMethod]
        public void IsPrime_ShouldReturnTrueFor13()
        {
            bool result = PrimeNumberUtils.IsPrime(13);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPrime_ShouldReturnFalseFor12()
        {
            bool result = PrimeNumberUtils.IsPrime(12);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindNthPrimeNumber_ShouldReturn19For8()
        {
            long result = PrimeNumberUtils.FindNthPrimeNumber(8);
            Assert.AreEqual(result, 19);
        }
    }
}
