using SearchAlgorithms.Core.Algorithms;
using System.Linq;

namespace SearchAlgorithms.Core.Testing.Validators
{
    /// <summary>
    /// Klasa umożliwiająca weryfikację, czy wskazany algorytm wyszukiwania działa poprawnie.
    /// </summary>
    public class SearchAlgorithmValidator
    {
        /// <summary>
        /// Algorytm, na którym wykonujemy test.
        /// </summary>
        private ISearchAlgorithm AlgoToValidate;

        /// <summary>
        /// Algorytm, o którym wiadomo, że działa poprawnie.
        /// </summary>
        private ISearchAlgorithm ProperlyWorkingAlgorithm;

        /// <summary>
        /// Tworzy nowy obiekt klasy <see cref="SearchAlgorithmValidator"/>.
        /// </summary>
        /// <param name="algoToValidate">Algorytm do sprawdzenia.</param>
        public SearchAlgorithmValidator(ISearchAlgorithm algoToValidate)
        {
            this.AlgoToValidate = algoToValidate;
            this.ProperlyWorkingAlgorithm = new BuiltInSearch();
        }

        /// <summary>
        /// Weryfikuje działanie testowanego algorytmu, wyszukując wszystkie wystąpienia podłańcucha
        /// <paramref name="needle"/> w łańcuchu <paramref name="haystack"/>, porównując wyniki z algorytmem
        /// referencyjnym.
        /// </summary>
        /// <param name="needle">Podłańcuch, którego wystąpień szukamy.</param>
        /// <param name="haystack">Łańcuch, w którym szukamy wystąpień podłańcucha <paramref name="needle"/>.</param>
        /// <returns></returns>
        public bool Validate(string needle="ab", string haystack="abacabajabadabab")
        {
            var algoResult = AlgoToValidate.Search(needle, haystack);
            var referentialResult = ProperlyWorkingAlgorithm.Search(needle, haystack);
            return algoResult.OrderBy(x=> x).SequenceEqual(referentialResult.OrderBy(x=>x));
        }
    }
}
