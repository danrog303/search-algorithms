using System.Collections.Generic;
using System.Threading;

namespace SearchAlgorithms.Core.Algorithms
{
    public class TestSearch : ISearchAlgorithm
    {
        public TestSearch(int random)
        {
            this.random = random;
        }

        private int random;

        public string Name()
        {
            return "random-time testing algorithm";
        }
        public List<int> Search(in string lookingString,in string longString)
        {

            Thread.Sleep(random%100+1);
            List<int> result = new List<int>();
            for (int i = 0; i < longString.Length; i++)
            {
                if (i + lookingString.Length - 1 < longString.Length && lookingString[0] == longString[i] )
                {
                    bool isFound = true;
                    for (int j = 1; j < lookingString.Length; j++)
                    {
                        if (lookingString[j] != longString[i + j])
                        {
                            isFound = false;
                            break;
                        }
                    }
                    if (isFound)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

    }
}
