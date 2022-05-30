using System;
using System.Diagnostics;

namespace SearchAlgorithms.Core.Testing.Timers
{
    /// <summary>
    /// Klasa umożliwiająca zmierzenie czasu wykonania wskazanej funkcji.
    /// </summary>
    public class TimeMeasure
    {
        /// <summary>
        /// Wykonuje funkcję <paramref name="functionToMeasure"/> i zwraca czas wykonania w milisekundach.
        /// </summary>
        /// <param name="functionToMeasure">Funkcja, której czas wykonania ma być zbadany./param>
        /// <returns>Czas wykonania funkcji w milisekundach (obsługuje ułamki milisekund).</returns>
        public double Measure(Action functionToMeasure)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            functionToMeasure();
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}