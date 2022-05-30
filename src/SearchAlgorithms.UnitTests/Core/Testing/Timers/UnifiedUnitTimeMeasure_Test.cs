using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Testing.Timers;
using SearchAlgorithms.Core.Utils;
using System;

namespace SearchAlgorithms.UnitTests.Core.Testing.Timers
{
    [TestClass]
    public class UnifiedUnitTimeMeasure_Test
    {
        [TestMethod]
        public void Measure_Calculating5000PrimeNumbersExpectedToTakeMoreThan0Ms()
        {
            UnifiedUnitTimeMeasure timeMeasure = new UnifiedUnitTimeMeasure(5.0);
            Action calculatePrimes = () => PrimeNumberUtils.FindNthPrimeNumber(5000);
            double result = timeMeasure.Measure(calculatePrimes);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UnifiedUnitMeasure_UnifiedResultExpectedToBeLesserThanMillisecondsResult()
        {
            UnifiedUnitTimeMeasure timeMeasure = new UnifiedUnitTimeMeasure(5.0);
            Action calculatePrimes = () => PrimeNumberUtils.FindNthPrimeNumber(5000);
            var result = timeMeasure.UnifiedUnitMeasure(calculatePrimes);
            Assert.IsTrue(result.ResultInReferrentialUnit < result.OriginalResult);
        }

        [TestMethod]
        public void UnifiedUnitMeasure_UnifiedResultExpectedToBeGreaterThanMillisecondsResult()
        {
            UnifiedUnitTimeMeasure timeMeasure = new UnifiedUnitTimeMeasure(0.25);
            Action calculatePrimes = () => PrimeNumberUtils.FindNthPrimeNumber(5000);
            var result = timeMeasure.UnifiedUnitMeasure(calculatePrimes);
            Assert.IsTrue(result.ResultInReferrentialUnit > result.OriginalResult);
        }

        [TestMethod]
        public void UnifiedUnitMeasure_UnifiedResultExpectedToBeEqualMillisecondsResult()
        {
            UnifiedUnitTimeMeasure timeMeasure = new UnifiedUnitTimeMeasure(1.0);
            Action calculatePrimes = () => PrimeNumberUtils.FindNthPrimeNumber(5000);
            var result = timeMeasure.UnifiedUnitMeasure(calculatePrimes);
            Assert.IsTrue(result.ResultInReferrentialUnit == result.OriginalResult);

        }
    }
}
