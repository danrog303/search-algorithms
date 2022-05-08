using SearchAlgorithms.Core.Algorithms;
using System;
using System.Collections.Generic;
using SearchAlgorithms.Core.Testing.Validators;

namespace SearchAlgorithms.Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            var currentlyCheckedAlgorithm = new KMPAlgoritm();

            Console.WriteLine("Zaraz powinno wyświetlić się True, jeśli algorytm działa poprawnie.");
            Console.WriteLine("Jeśli algorytm działa niepoprawnie, wyświetli się False.");
            var validationResult = new SearchAlgorithmValidator(currentlyCheckedAlgorithm).Validate();
            Console.WriteLine(validationResult);


            var searchResult = currentlyCheckedAlgorithm.Search("bb", "aabbaabb");
            var correctResult = new BuiltInSearch().Search("bb", "aabbaabb");

            Console.WriteLine("\nWyszukuję napis bb w napisie aabbaabb");
            Console.WriteLine("Poprawnie działający algorytm zwrócił takie dane: ");
            Console.WriteLine(string.Join(" ", correctResult));
            Console.WriteLine("Twój algorytm zwrócił takie dane: ");
            Console.WriteLine(string.Join(" ", searchResult));


            Console.ReadKey();
        }
    }
}
