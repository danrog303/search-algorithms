using SearchAlgorithms.Core.Algorithms;
using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestSearch fa = new TestSearch(10);
            List<int> searchResult = fa.Search("do", "Napis do przeszukania");
            foreach(var e in searchResult)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
