using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.Core.Utils
{
    public static class PrimeNumberUtils
    {
        public static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2 || number == 3 || number == 5) return true;
            if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            long i = 6;
            while (i <= boundary)
            {
                if (number % (i + 1) == 0 || number % (i + 5) == 0)
                    return false;

                i += 6;
            }

            return true;
        }

        public static long FindNthPrimeNumber(long n)
        {
            long currentlyAnalysedNumber = 1;
            long primeCounter = 0;
            while(primeCounter < n)
            {
                if(IsPrime(currentlyAnalysedNumber))
                {
                    primeCounter++;
                }
                currentlyAnalysedNumber++;
            }
            return currentlyAnalysedNumber - 1;
        }
    }
}
