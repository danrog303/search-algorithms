using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Testing.Timers;
using SearchAlgorithms.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.UnitTests.Core.Testing.Timers
{
    [TestClass]
    public class TimeMeasure_Test
    {
        [TestMethod]
        public void Measure_Calculating5000PrimeNumbersExpectedToTakeMoreThan0Ms()
        {
            TimeMeasure timeMeasure = new TimeMeasure();
            Action calculatePrimes = () => PrimeNumberUtils.FindNthPrimeNumber(5000);
            double result = timeMeasure.Measure(calculatePrimes);
            Assert.IsTrue(result > 0);
        }
    }
}
