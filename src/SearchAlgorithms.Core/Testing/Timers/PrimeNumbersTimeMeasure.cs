using SearchAlgorithms.Core.Utils;
using System;
using System.Collections.Generic;
namespace SearchAlgorithms.Core.Testing.Timers
{
    public class PrimeNumbersTimeMeasure : UnifiedUnitTimeMeasure
    {
        private static double MeasureReferentialUnit(long numbersToCalculate)
        {
            var timer = new TimeMeasure(() => PrimeNumberUtils.FindNthPrimeNumber(numbersToCalculate));
            return timer.Measure();
        }

        public PrimeNumbersTimeMeasure(Action functionToMeasure, long primeNumbersToCalculate = 4500) : base(functionToMeasure, MeasureReferentialUnit(primeNumbersToCalculate))
        {
        }
    }
}
