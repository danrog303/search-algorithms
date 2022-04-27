using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithms.TestAlgorithm;

namespace SearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstAlgorithm fa = new FirstAlgorithm(10);
            List<int> searchResult = fa.search("do", "Napis do przeszukania");
            foreach(var e in searchResult)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
