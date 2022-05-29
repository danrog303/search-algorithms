using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
	/// <summary>
	/// Algorytm wyszukiwania pod³añcuchów metod¹ hashowania.
	/// </summary>
	public class HashSearch : ISearchAlgorithm
	{
		/// <summary>
		/// TODO: FILL THIS ENTRY
		/// </summary>
		/// <param name="lookingString">TODO: FILL THIS ENTRY</param>
		/// <param name="longString">TODO: FILL THIS ENTRY</param>
		/// <returns>TODO: FILL THIS ENTRY</returns>
		static int Leng(string lookingString, string longString)
		{
			double size = 0;
			int size2, limit, n = lookingString.Length;
			limit = longString.Length - lookingString.Length;
			// Ile razy pierwszy znak szukanego slowa pojawia sie w przeszukiwanym ci¹gu?
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

		/// <summary>
		/// TODO: FILL THIS ENTRY
		/// </summary>
		/// <param name="lookingString">TODO: FILL THIS ENTRY</param>
		/// <param name="longString">TODO: FILL THIS ENTRY</param>
		/// <param name="limit">TODO: FILL THIS ENTRY</param>
		/// <param name="counter">TODO: FILL THIS ENTRY</param>
		/// <param name="size">TODO: FILL THIS ENTRY</param>
		/// <param name="n">TODO: FILL THIS ENTRY</param>
		/// <param name="array">TODO: FILL THIS ENTRY</param>
		/// <param name="arrays">TODO: FILL THIS ENTRY</param>
		static void Insert(string lookingString, string longString, int limit, int counter, int size, int n, int[] array, string[] arrays)
		{
			for (int i = 0; i <= limit; i++)
			{
				// Znalezienie kandydatów na szukane s³owo
				if (longString[i] == lookingString[0])
				{
					string tmps = "";
					int power = counter;
					int utfvalue = 0;
					// Algorytm haszuj¹cy
					for (int j = i; j < i + n; j++)
					{
						tmps += longString[j];
						utfvalue += ((int)longString[j]) ^ power;
						power--;
						if (power == 0)
							power = counter;
					}

					utfvalue = utfvalue % size;
					// Szukanie pustego miejsca w tablicy
					while (!String.IsNullOrEmpty(arrays[utfvalue]))
					{
						utfvalue++;
						if (utfvalue == size)
							utfvalue = 0;
					}

					// Umieszczenie kandydata w tablicy
					array[utfvalue] = i;
					arrays[utfvalue] = tmps;
				}
			}
		}

		/// <summary>
		/// TODO: FILL THIS ENTRY
		/// </summary>
		/// <param name="counter">TODO: FILL THIS ENTRY</param>
		/// <param name="size">TODO: FILL THIS ENTRY</param>
		/// <param name="lookingString">TODO: FILL THIS ENTRY</param>
		/// <param name="array">TODO: FILL THIS ENTRY</param>
		/// <param name="arrays">TODO: FILL THIS ENTRY</param>
		/// <returns>TODO: FILL THIS ENTRY</returns>
		static List<int> Find(int counter, int size, string lookingString, int[] array, string[] arrays)
		{
			int power = counter;
			int utfvalue = 0;
			// Algorytm haszuj¹cy
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
			// Utworzenie listy indeksow znalezionych slow 
			List<int> results = new List<int>();
			// Przeszukanie tablicy haszujacej i wpisanie indeksow znalezionych slow do listy
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

		/// <summary>
		/// Implementuje metodê <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
		/// </summary>
		public List<int> Search(in string lookingString, in string longString)
		{
			int size = Leng(lookingString, longString), n = lookingString.Length;
			int limit = longString.Length - lookingString.Length;
			// Utworzenie tablicy o rozmiarze wiekszym niz ilosc znalezionych kandytatow na szukane slowo
			int[] array = new int[size];
			string[] arrays = new string[size];
			int tmp = size;
			int counter = 0;
			// Ustalenie jak¹ wielokrotnoœci¹ setki jest wielkosc tablicy.
			// Jest to wymagane do równomiernego roz³o¿enia kandydatów na szukane slowo w tablicy.
			while (tmp > 0)
			{
				counter++;
				tmp /= 100;
			}

			Insert(lookingString, longString, limit, counter, size, n, array, arrays);
			return Find(counter, size, lookingString, array, arrays);
		}

		/// <summary>
		/// Implementuje metodê <see cref="ISearchAlgorithm.Name"/>.
		/// </summary>
		public string Name()
		{
			return "HashSearch";
		}
	}
}
