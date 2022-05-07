using System.Collections.Generic;

namespace SearchAlgorithms.Core.Algorithms
{
    public interface ISearchAlgorithm
    {
        List<int> Search(in string lookingString, in string longString);

        string Name();
    }
}
