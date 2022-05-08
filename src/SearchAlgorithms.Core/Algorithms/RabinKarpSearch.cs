using System;
using System.Collections.Generic;



namespace SearchAlgorithms.Core.Algorithms
{

    public class RabinKarpSearch : ISearchAlgorithm
    {
        private readonly static int d = 256;

        /* pat -> pattern
            txt -> text
            q -> Liczba pierwsza
        */
        public List<int> Search(in string pat, in string txt)
        {
            const int q = 101;
            var result = new List<int>();

            int M = pat.Length;
            int N = txt.Length;
            int i, j;
            int p = 0; // wartosc hashu patternu 
            int t = 0; // wartosc hashu txt
            int h = 1;

            // h bedzie mialo wartosc pow(d,M-1)%q
            for (i = 0; i < M - 1; i++)
                h = (h * d) % q;
            // Oblicza wartosc hasha patternu i pierwszego ucinka

            for (i = 0; i < M; i++)
            {
                p = (d * p + pat[i]) % q;
                t = (d * t + txt[i]) % q;
            }

            // Przesuwa pattern po calym stringu
            for (i = 0; i <= N - M; i++)
            {

                // Sprawdza hash aktualnego urywka
                // sprawdza litery tylko jezeli hash sie zgadza
                if (p == t)
                {
                    // Sprawdzanie liter
                    for (j = 0; j < M; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }

                    // jeżeli  p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]
                    if (j == M)
                        result.Add(i);
                }
                // Oblicza wartosc hash kolejnego odcinku i usuwa pierwsza i koncowa cyfre
                if (i < N - M)
                {
                    t = (d * (t - txt[i] * h) + txt[i + M]) % q;

                    // Jak dostaniemy ujemna wartosc konwertujemy ja
                    if (t < 0)
                        t = (t + q);
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