using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
    public class HashSearch : ISearchAlgorithm
    {
        public List<int> Search(in string lookingString, in string longString)
        {
            double dl = 0;
            int dl2, limit, n = lookingString.Length;    
            limit = longString.Length - lookingString.Length;
            //ile razy pierwszy znak szukanego slowa pojawia sie w przeszukiwanym ciagu
            for (int i = 0; i <= limit; i++) 
            {
                if (longString[i] == lookingString[0]) dl++;
            }
            dl = 1.1 * dl; 
            dl2 = (int)dl;
            dl2 += 5;
            /*utworzenie tablicy o rozmiarze wiekszym niz ilosc znalezionych 
                kandytatow na szukane slowo*/
            int[] tab = new int[dl2];
            string[] tabs = new string[dl2];
            int tmp = dl2;
            int licznik = 0;
            /*ustelenie jaka wielokrotnoscia setki jest wielkosc tablicy
                jest to wymagane do rownomiernego rozlozenia kandydatow
                na szukane slowo w tablicy*/
            while (tmp > 0)
            {
                licznik++;
                tmp /= 100;
            }
            for (int i = 0; i <= limit; i++)
            {
                //znalezienie kandydatow na szukane slowo
                if (longString[i] == lookingString[0])
                {
                    string tmps = "";
                    int potega = licznik;
                    int wartoscASCII = 0;
                    //algorytm haszujacy
                    for (int j = i; j < i + n; j++)
                    {
                        tmps += longString[j];
                        wartoscASCII += ((int)longString[j]) ^ potega;
                        potega--;
                        if (potega == 0) potega = licznik;
                    }
                    wartoscASCII = wartoscASCII % dl2;
                    //szukanie pustego miejsca w tablicy
                    while (!String.IsNullOrEmpty(tabs[wartoscASCII]))
                    {
                        wartoscASCII++;
                        if (wartoscASCII == dl2) wartoscASCII = 0;
                    }
                    //umieszczenie kandydata w tablicy
                    tab[wartoscASCII] = i;
                    tabs[wartoscASCII] = tmps;
                }

            }
            int potega1 = licznik;
            int wartoscASCII1 = 0;
            //algorytm haszujacy
            for (int i = 0; i < lookingString.Length; i++)
            {
                wartoscASCII1 += ((int)lookingString[i]) ^ potega1;
                potega1--;
                if (potega1 == 0) potega1 = licznik;
            }
            wartoscASCII1 = wartoscASCII1 % dl2;
            int tmp1 = wartoscASCII1;
            wartoscASCII1--;
            //utworzenie listy indeksow znalezionych slow 
            List<int> wyniki = new List<int>();
            //przeszukanie tablicy haszujacej i wpisanie indeksow znalezionych slow do listy
            while (tmp1 != wartoscASCII1 && !String.IsNullOrEmpty(tabs[tmp1]))
            {
                if (tabs[tmp1] == lookingString)
                {
                    wyniki.Add(tab[tmp1]);
                }
                tmp1++;
                if (tmp1 == dl2) tmp1 = 0;
            }
            return wyniki;
        }

        public string Name()
        {
            return "Haszowanie";
        }
    }
}
