using System;
using System.Linq;

namespace SearchAlgorithms.Core.Utils
{
    /// <summary>
    /// Klasa pomocnicza, która zawiera metodę rozszerzającą <see cref="SortCharacters"/>. 
    /// Metoda rozszerza typ string i pozwala na sortowanie łańcuchów znaków.
    /// </summary>
    public static class StringSort
    {
        /// <summary>
        /// Metoda rozszerzająca typ string, umożliwiająca sortowanie łańcuchów znaków. 
        /// Funkcja zwraca nowy obiekt, oryginalny łańcuch znaków nie jest modyfikowany.
        /// Przykładowo wywołując: <code>"badc".SortCharacters()</code> otrzymamy wynik <code>"abcd"</code>
        /// </summary>
        /// <param name="str">Źródłowy łańcuch do posortowania</param>
        /// <returns>Zwraca nowy, posortowany łańcuch znaków.</returns>
        public static string SortCharacters(this string str)
        {
            char[] characters = str.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
