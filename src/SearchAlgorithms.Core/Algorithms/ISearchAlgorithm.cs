using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Interfejs reprezentujący pojedynczy algorytm wyszukiwania podłańcuchów dostępny w programie.
    /// </summary>
    public interface ISearchAlgorithm
    {
        /// <summary>
        /// Metoda wyszukująca wszystkie wystąpienia <paramref name="lookingString"/> wewnątrz <paramref name="longString"/>.
        /// </summary>
        /// <param name="lookingString">Napis, którego wystąpień ma poszukać metoda.</param>
        /// <param name="longString">Napis, w którym szukamy wystąpień podłańcucha <paramref name="lookingString"/>.</param>
        /// <returns>Zwraca listę pozycji, na których napis szukany pojawił się w napisie długim. Pozycje są numerowane od zera.</returns>
        List<int> Search(in string lookingString, in string longString);

        /// <summary>
        /// Metoda zwracająca skróconą nazwę algorytmu.
        /// </summary>
        /// <returns>Zwraca skróconą nazwę algorytmu.</returns>
        string Name();
    }
}
