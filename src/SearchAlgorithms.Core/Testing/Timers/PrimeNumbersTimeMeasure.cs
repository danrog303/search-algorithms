using SearchAlgorithms.Core.Utils;
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
            var timer = new TimeMeasure();
            return timer.Measure(() => PrimeNumberUtils.FindNthPrimeNumber(numbersToCalculate));
        }

        /// <summary>
        /// Konstruuje nowy obiekt klasy <see cref="PrimeNumbersTimeMeasure"/>.
        /// </summary>
        /// <param name="primeNumbersToCalculate">Ilość liczb pierwszych, na podstawie których ma zostać wyznaczona jednostka referencyjna.</param>
        public PrimeNumbersTimeMeasure(long primeNumbersToCalculate = 4500) : base(MeasureReferentialUnit(primeNumbersToCalculate))
        {
        }
    }
}
