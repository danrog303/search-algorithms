using SearchAlgorithms.Core.Algorithms;
using System.Linq;

namespace SearchAlgorithms.Core.Testing.Validators
{
    public class SearchAlgorithmValidator
    {
        private ISearchAlgorithm AlgoToValidate;
        private ISearchAlgorithm ProperlyWorkingAlgorithm;

        public SearchAlgorithmValidator(ISearchAlgorithm algoToValidate)
        {
            this.AlgoToValidate = algoToValidate;
            this.ProperlyWorkingAlgorithm = new BuiltInSearch();
        }

        public bool Validate(string needle="ab", string haystack="abacabajabadabab")
        {
            var algoResult = AlgoToValidate.Search(needle, haystack);
            var referentialResult = ProperlyWorkingAlgorithm.Search(needle, haystack);
            return algoResult.OrderBy(x=> x).SequenceEqual(referentialResult.OrderBy(x=>x));
        }
    }
}
