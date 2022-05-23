using System;
using System.Collections.Generic;
using System.Linq;
namespace SearchAlgorithms.Core.Testing.Timers
{
    public class UnifiedUnitTimeMeasure : TimeMeasure
    {
        public class MeasurementResult
        {
            public double OriginalResult { get; private set; }
            public double ResultInReferrentialUnit { get; private set; }

            public MeasurementResult(double originalResult, double resultInReferrentialUnit)
            {
                this.OriginalResult = originalResult;
                this.ResultInReferrentialUnit = resultInReferrentialUnit;
            }
        }

        private double ReferrentialUnit;

        public UnifiedUnitTimeMeasure(Action functionToMeasure, double referentialUnit) : base(functionToMeasure)
        {
            this.ReferrentialUnit = referentialUnit;
        }

        public MeasurementResult UnifiedUnitMeasure()
        {
            double resultInMs = base.Measure();
            return new MeasurementResult(resultInMs, resultInMs / ReferrentialUnit);
        }
    }
}