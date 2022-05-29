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
        /// Funkcja, której czas wykonania ma zostać zmierzony.
        /// </summary>
        private Action FunctionToMeasure;

        /// <summary>
        /// Tworzy nowy obiekt klasy <see cref="TimeMeasure"/>.
        /// </summary>
        /// <param name="functionToMeasure">Funkcja, której czas wykonania ma zostać zmierzony.</param>
        public TimeMeasure(Action functionToMeasure)
        {
            this.FunctionToMeasure = functionToMeasure;
        }

        /// <summary>
        /// Wykonuje funkcję <see cref="TimeMeasure.FunctionToMeasure"/> i zwraca czas wykonania w milisekundach.
        /// </summary>
        /// <returns>Czas wykonania funkcji w milisekundach (obsługuje ułamki milisekund).</returns>
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