using System;
using System.Diagnostics;
using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.Core.Testing.Timers
{
    public class TimeMeasure
    {
        private Action FunctionToMeasure;

        public TimeMeasure(Action functionToMeasure)
        {
            this.FunctionToMeasure = functionToMeasure;
        }

        public double Measure()
        {
            Stopwatch stopwatchUnifyTimeUnit = new Stopwatch();
            stopwatchUnifyTimeUnit.Start();
            PrimeNumberUtils.FindNthPrimeNumber(4500); // Time unifier execution time
            stopwatchUnifyTimeUnit.Stop();
            double unifyExecutionTime = stopwatchUnifyTimeUnit.Elapsed.TotalMilliseconds;
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FunctionToMeasure(); // Search algorithm execution time
            stopwatch.Stop();
            double algorithmExecutionTime = stopwatch.Elapsed.TotalMilliseconds;
            
            return algorithmExecutionTime / unifyExecutionTime; // Unifying execution time
        }
    }
}