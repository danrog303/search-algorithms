using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchAlgorithms.Core.Algorithms
{
    public class BuiltInSearch : ISearchAlgorithm
    {
        public string Name()
        {
            return "C# built-in search";
        }

        public List<int> Search(in string lookingString, in string longString)
        {
            return Regex.Matches(longString, lookingString).Cast<Match>().Select(m => m.Index).ToList();
        }
    }
}
