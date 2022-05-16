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

        private readonly int random;

        public string Name()
        {
            return "random-time testing algorithm";
        }
        public List<int> Search(in string lookingString, in string longString)
        {

            Thread.Sleep(random%100+1);
            return new BuiltInSearch().Search(lookingString, longString);
        }

    }
}
