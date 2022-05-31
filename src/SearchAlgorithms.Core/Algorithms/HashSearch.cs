using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
	/// <summary>
	/// Algorytm wyszukiwania podłańcuchów metodą hashowania.
	/// </summary>
	public class HashSearch : ISearchAlgorithm
	{
		/// <summary>
		/// Funkcja obliczająca długość przyszłej tablicy elementów
		/// </summary>
		/// <param name="lookingString">Szukany ciąg znaków</param>
		/// <param name="longString">Przeszukiwany ciąg znaków</param>
		/// <returns>Długość tablicy</returns>
		static int Leng(string lookingString, string longString)
		{
			double size = 0;
			int size2, limit, n = lookingString.Length;
			limit = longString.Length - lookingString.Length;
			// Ile razy pierwszy znak szukanego słowa pojawia sie w przeszukiwanym ciągu?
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
		/// Funkcja wprowadzająca dane do tablicy
		/// </summary>
		/// <param name="lookingString">Szukany ciąg znaków</param>
		/// <param name="longString">Przeszukiwany ciąg znaków</param>
		/// <param name="limit">Indeks ostatniego elementu przeszukiwanego ciągu, który może być początkiem szukanego słowa</param>
		/// <param name="counter">Stopień potęgi</param>
		/// <param name="size">Rozmiar tablic elementów</param>
		/// <param name="n">Długość szukanego ciągu</param>
		/// <param name="array">Tablica indeksów</param>
		/// <param name="arrays">Tablica słów</param>
		static void Insert(string lookingString, string longString, int limit, int counter, int size, int n, int[] array, string[] arrays)
		{
			for (int i = 0; i <= limit; i++)
			{
				// Znalezienie kandydatów na szukane słowo
				if (longString[i] == lookingString[0])
				{
					string tmps = "";
					int power = counter;
					int utfvalue = 0;
					// Algorytm haszujący
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
		/// Funkcja przeszukująca tablicę
		/// </summary>
		/// <param name="counter">Stopień potęgi</param>
		/// <param name="size">Rozmiar tablic elementów</param>
		/// <param name="lookingString">Szukany ciąg znakó</param>
		/// <param name="array">Tablica indeksów</param>
		/// <param name="arrays">Tablica słów</param>
		/// <returns>Lista zawierająca indeksy przeszukiwanego ciągu, od któryych zaczynają się poszukiwane słowa</returns>
		static List<int> Find(int counter, int size, string lookingString, int[] array, string[] arrays)
		{
			int power = counter;
			int utfvalue = 0;
			// Algorytm haszujący
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
			// Utworzenie listy indeksów znalezionych słów 
			List<int> results = new List<int>();
			// Przeszukanie tablicy haszującej i wpisanie indeksów znalezionych słów do listy
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
		/// Implementuje metodę <see cref="ISearchAlgorithm.Search(in string, in string)"/>.
		/// </summary>
		public List<int> Search(in string lookingString, in string longString)
		{
			int size = Leng(lookingString, longString), n = lookingString.Length;
			int limit = longString.Length - lookingString.Length;
			// Utworzenie tablicy o rozmiarze większym niz ilość znalezionych kandytatów na szukane słowo
			int[] array = new int[size];
			string[] arrays = new string[size];
			int tmp = size;
			int counter = 0;
			// Ustalenie jaką wielokrotnością setki jest wielkość tablicy.
			// Jest to wymagane do równomiernego rozłożenia kandydatów na szukane słowo w tablicy.
			while (tmp > 0)
			{
				counter++;
				tmp /= 100;
			}

			Insert(lookingString, longString, limit, counter, size, n, array, arrays);
			return Find(counter, size, lookingString, array, arrays);
		}

		/// <summary>
		/// Implementuje metodę <see cref="ISearchAlgorithm.Name"/>.
		/// </summary>
		public string Name()
		{
			return "HashSearch";
		}
	}
}
