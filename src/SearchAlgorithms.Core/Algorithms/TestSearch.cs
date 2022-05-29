using System.Collections.Generic;
using System.Threading;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Testowy algorytm wyszukiwania, zwracający dane z pewnym opóźnieniem.
    /// </summary>
    public class TestSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Tworzy nowy obiekt reprezentujący algorytm.
        /// </summary>
        /// <param name="random">Czas w milisekundach, o który ma zostać opóźnione zwrócenie danych.</param>
        public TestSearch(int random)
        {
            this.random = random;
        }

        /// <summary>
        /// Przechowuje czas w milisekundach, o który ma zostać opóźnione zwrócenie danych 
        /// </summary>
        private readonly int random;

        public string Name()
        {
            return "random-time testing algorithm";
        }
        public List<int> Search(in string lookingString, in string longString)
        {

            Thread.Sleep(random%100+1);
            return new BuiltInSearch().Search(lookingString, longString);
        }

    }
}
