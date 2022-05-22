using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
	public class HashSearch : ISearchAlgorithm
	{
		static int Leng(string lookingString, string longString)
		{
			double size = 0;
			int size2, limit, n = lookingString.Length;
			limit = longString.Length - lookingString.Length;
			//ile razy pierwszy znak szukanego slowa pojawia sie w przeszukiwanym ciagu
			for (int i = 0; i <= limit; i++)
			{
				if (longString[i] == lookingString[0])
					size++;
			}

			size = 1.1 * size;
			size2 = (int)size;
			size2 += 5;
			return size2;
		}

		static void Insert(string lookingString, string longString, int limit, int counter, int size, int n, int[] array, string[] arrays)
		{
			for (int i = 0; i <= limit; i++)
			{
				//znalezienie kandydatow na szukane slowo
				if (longString[i] == lookingString[0])
				{
					string tmps = "";
					int power = counter;
					int utfvalue = 0;
					//algorytm haszujacy
					for (int j = i; j < i + n; j++)
					{
						tmps += longString[j];
						utfvalue += ((int)longString[j]) ^ power;
						power--;
						if (power == 0)
							power = counter;
					}

					utfvalue = utfvalue % size;
					//szukanie pustego miejsca w tablicy
					while (!String.IsNullOrEmpty(arrays[utfvalue]))
					{
						utfvalue++;
						if (utfvalue == size)
							utfvalue = 0;
					}

					//umieszczenie kandydata w tablicy
					array[utfvalue] = i;
					arrays[utfvalue] = tmps;
				}
			}
		}

		static List<int> Find(int counter, int size, string lookingString, int[] array, string[] arrays)
		{
			int power = counter;
			int utfvalue = 0;
			//algorytm haszujacy
			for (int i = 0; i < lookingString.Length; i++)
			{
				utfvalue += ((int)lookingString[i]) ^ power;
				power--;
				if (power == 0)
					power = counter;
			}

			utfvalue = utfvalue % size;
			int tmp1 = utfvalue;
			utfvalue--;
			//utworzenie listy indeksow znalezionych slow 
			List<int> results = new List<int>();
			//przeszukanie tablicy haszujacej i wpisanie indeksow znalezionych slow do listy
			while (tmp1 != utfvalue && !String.IsNullOrEmpty(arrays[tmp1]))
			{
				if (arrays[tmp1] == lookingString)
				{
					results.Add(array[tmp1]);
				}

				tmp1++;
				if (tmp1 == size)
					tmp1 = 0;
			}

			return results;
		}

		public List<int> Search(in string lookingString, in string longString)
		{
			int size = Leng(lookingString, longString), n = lookingString.Length;
			int limit = longString.Length - lookingString.Length;
			/*utworzenie tablicy o rozmiarze wiekszym niz ilosc znalezionych 
                kandytatow na szukane slowo*/
			int[] array = new int[size];
			string[] arrays = new string[size];
			int tmp = size;
			int counter = 0;
			/*ustalenie jaka wielokrotnoscia setki jest wielkosc tablicy
                jest to wymagane do rownomiernego rozlozenia kandydatow
                na szukane slowo w tablicy*/
			while (tmp > 0)
			{
				counter++;
				tmp /= 100;
			}

			insert(lookingString, longString, limit, counter, size, n, array, arrays);
			return find(counter, size, lookingString, array, arrays);
		}

		public string Name()
		{
			return "HashSearch";
		}
	}
}
