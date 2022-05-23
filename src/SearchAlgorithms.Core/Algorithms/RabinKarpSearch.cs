using System;
using System.Collections.Generic;



namespace SearchAlgorithms.Core.Algorithms
{

    public class RabinKarpSearch : ISearchAlgorithm
    {
        private readonly static int d = 256;

        /* pat -> pattern
            txt -> text
            primeNumber -> Liczba pierwsza
        */
        public List<int> Search(in string pat, in string txt)
        {
            const int primeNumber = 101;
            var result = new List<int>();

            int patternLength = pat.Length;
            int textLength = txt.Length;
            int i, j;
            int hashPatternValue = 0; // wartosc hashu patternu 
            int hashTxtValue = 0; // wartosc hashu txt
            int h = 1;

            // h bedzie mialo wartosc pow(d,patternLength-1)%primeNumber
            for (i = 0; i < patternLength - 1; i++)
                h = (h * d) % primeNumber;
            // Oblicza wartosc hasha patternu i pierwszego ucinka

            for (i = 0; i < patternLength; i++)
            {
                hashPatternValue = (d * hashPatternValue + pat[i]) % primeNumber;
                hashTxtValue = (d * hashTxtValue + txt[i]) % primeNumber;
            }

            // Przesuwa pattern po calym stringu
            for (i = 0; i <= textLength - patternLength; i++)
            {

                // Sprawdza hash aktualnego urywka
                // sprawdza litery tylko jezeli hash sie zgadza
                if (hashPatternValue == hashTxtValue)
                {
                    // Sprawdzanie liter
                    for (j = 0; j < patternLength; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }

                    // jeżeli  hashPatternValue == hashTxtValue and pat[0...patternLength-1] = txt[i, i+1, ...i+patternLength-1]
                    if (j == patternLength)
                        result.Add(i);
                }
                // Oblicza wartosc hash kolejnego odcinku i usuwa pierwsza i koncowa cyfre
                if (i < textLength - patternLength)
                {
                    hashTxtValue = (d * (hashTxtValue - txt[i] * h) + txt[i + patternLength]) % primeNumber;

                    // Jak dostaniemy ujemna wartosc konwertujemy ja
                    if (hashTxtValue < 0)
                        hashTxtValue = (hashTxtValue + primeNumber);
                }
            }

            return result;
        }

        public string Name()
        {
            return "Rabin Karp";
        }
    }
}
