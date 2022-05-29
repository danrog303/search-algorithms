using System;
using System.Collections.Generic;
using System.Linq;
namespace SearchAlgorithms.Core.Testing.Timers
{
    /// <summary>
    /// Klasa pomocnicza umożliwiająca pomiar czasu wykonania jakiejś funkcji. 
    /// Wynik może być wyrażony w dwóch jednostkach: milisekundach i we wskazanych jednostkach referencyjnych.
    /// </summary>
    public class UnifiedUnitTimeMeasure : TimeMeasure
    {
        /// <summary>
        /// Klasa reprezentująca wynik pomiaru klasy <see cref="UnifiedUnitTimeMeasure"/>.
        /// </summary>
        public class MeasurementResult
        {
            /// <summary>
            /// "Oryginalny" wynik pomiaru (czyli wyrażony w milisekundach).
            /// </summary>
            public double OriginalResult { get; private set; }

            /// <summary>
            /// Wynik pomiaru wyrażony w jednostkach referencyjnych.
            /// </summary>
            public double ResultInReferrentialUnit { get; private set; }

            /// <summary>
            /// Tworzy nowy obiekt klasy <see cref="UnifiedUnitTimeMeasure"/>.
            /// </summary>
            /// <param name="originalResult">Pomiar wyrażony w milisekundach</param>
            /// <param name="resultInReferrentialUnit">Ten sam pomiar wyrażony w jednostkach referencyjnych</param>
            public MeasurementResult(double originalResult, double resultInReferrentialUnit)
            {
                this.OriginalResult = originalResult;
                this.ResultInReferrentialUnit = resultInReferrentialUnit;
            }
        }

        /// <summary>
        /// Przelicznik jednostek referencyjnych (1 jednostka referencyjna = <see cref="ReferrentialUnit"/> milisekund).
        /// </summary>
        private double ReferrentialUnit;

        /// <summary>
        /// Tworzy nowy obiekt klasy <see cref="UnifiedUnitTimeMeasure"/>.
        /// </summary>
        /// <param name="functionToMeasure">Funkcja, której czas wykonania ma zostać zmierzony.</param>
        /// <param name="referentialUnit">Przelicznik jednostek referencyjnych</param>
        public UnifiedUnitTimeMeasure(Action functionToMeasure, double referentialUnit) : base(functionToMeasure)
        {
            this.ReferrentialUnit = referentialUnit;
        }

        /// <summary>
        /// Wykonuje funkcję <see cref="TimeMeasure.FunctionToMeasure"/> i zwraca czas wykonania w postaci obiektu <see cref="MeasurementResult"/>.
        /// </summary>
        /// <returns>Wynik wykonania pomiaru czasu testowanej funkcji, reprezentowany przez obiekt klasy <see cref="MeasurementResult"/>.</returns>
        public MeasurementResult UnifiedUnitMeasure()
        {
            double resultInMs = base.Measure();
            return new MeasurementResult(resultInMs, resultInMs / ReferrentialUnit);
        }
    }
}