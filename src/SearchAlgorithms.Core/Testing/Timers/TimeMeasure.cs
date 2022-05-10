using System;
using System.Diagnostics;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FunctionToMeasure();
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}