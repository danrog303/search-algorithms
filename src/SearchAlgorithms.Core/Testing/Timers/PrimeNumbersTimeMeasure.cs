using SearchAlgorithms.Core.Utils;
using System;
using System.Collections.Generic;
namespace SearchAlgorithms.Core.Testing.Timers
{
    /// <summary>
    /// Klasa rozszerzająca klasę <see cref="UnifiedUnitTimeMeasure"/>, mierząca czas wykonania danej funkcji.
    /// Jako jednostkę referencyjną wykorzystywany jest czas wyznaczenia wskazanej ilości liczb pierwszych.
    /// </summary>
    public class PrimeNumbersTimeMeasure : UnifiedUnitTimeMeasure
    {
        /// <summary>
        /// Oblicza jednostkę referencyjną, zwracając czas wyznaczenia (<paramref name="numbersToCalculate"/>) liczb pierwszych.
        /// </summary>
        /// <param name="numbersToCalculate">Ilość liczb pierwszych do wyznaczenia</param>
        /// <returns>Czas szukania liczb pierwszych w milisekundach</returns>
        private static double MeasureReferentialUnit(long numbersToCalculate)
        {
            var timer = new TimeMeasure(() => PrimeNumberUtils.FindNthPrimeNumber(numbersToCalculate));
            return timer.Measure();
        }

        /// <summary>
        /// Konstruuje nowy obiekt klasy <see cref="PrimeNumbersTimeMeasure"/>.
        /// </summary>
        /// <param name="functionToMeasure">Funkcja, której czas wykonania ma zostać zmierzony.</param>
        /// <param name="primeNumbersToCalculate">Ilość liczb pierwszych, na podstawie których ma zostać wyznaczona jednostka referencyjna.</param>
        public PrimeNumbersTimeMeasure(Action functionToMeasure, long primeNumbersToCalculate = 4500) : base(functionToMeasure, MeasureReferentialUnit(primeNumbersToCalculate))
        {
        }
    }
}
