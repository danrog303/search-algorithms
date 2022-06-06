using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
    /// <summary>
    /// Algorytm wyszukiwania podłańcuchów metodą Rabina-Karpa.
    /// </summary>
    public class RabinKarpSearch : ISearchAlgorithm
    {
        /// <summary>
        /// Zmienna d odpowiada liczbie znaków w alfabecie wejściowym, możliwych do zapisania na jednym bajcie. (1 bajt = 8 bitów -> 2^8 = 256)
        /// </summary>
        private readonly static int d = 256;

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
        /// </summary>
        public List<int> Search(in string pat, in string txt)
        {
            if (txt.Length == 0)
            {
                return new List<int>();
            }

            const int primeNumber = 101;
            var result = new List<int>();

            int patternLength = pat.Length;
            int textLength = txt.Length;
            int i, j;
            int hashPatternValue = 0; 
            int hashTxtValue = 0; 
            int h = 1; // Zmienna h przechowywać będzie wartość równą "pow(d, patternLength-1)%primeNumber". Powiązane jest to ściśle z rehashowaniem, czyli wykonywaniem ponownego hashowania po uprzednim usunięciu najbardziej znaczącej cyfry dla wartości skrótu i dodaniu najmniej znaczącej. Dokładny opis działania rehashowania znajduje się w dokumentacji.

            for (i = 0; i < patternLength - 1; i++)
            {
                h = (h * d) % primeNumber;
            }

            for (i = 0; i < patternLength; i++)
            {
                hashPatternValue = (d * hashPatternValue + pat[i]) % primeNumber;
                hashTxtValue = (d * hashTxtValue + txt[i]) % primeNumber;
            }

            // Przesuwa pattern po całym stringu
            for (i = 0; i <= textLength - patternLength; i++)
            {
                // Sprawdza hash aktualnego urywka
                // Sprawdza litery tylko jeżeli hash się zgadza
                if (hashPatternValue == hashTxtValue)
                {
                    // Sprawdzanie liter
                    for (j = 0; j < patternLength; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }

                    // Jeżeli hashPatternValue == hashTxtValue ORAZ pat[0...patternLength-1] = txt[i, i+1, ...i+patternLength-1]
                    if (j == patternLength)
                        result.Add(i);
                }

                // Oblicza wartosc hashu kolejnego odcinka i usuwa pierwsząą i końcową cyfrę
                if (i < textLength - patternLength)
                {
                    hashTxtValue = (d * (hashTxtValue - txt[i] * h) + txt[i + patternLength]) % primeNumber;

                    // Jeśli otrzymamy ujemną wartość, konwertujemy ją
                    if (hashTxtValue < 0)
                        hashTxtValue = (hashTxtValue + primeNumber);
                }
            }

            return result;
        }

        /// <summary>
        /// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
        /// </summary>
        public string Name()
        {
            return "Rabin Karp";
        }
    }
}
