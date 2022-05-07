using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Algorithms;
using SearchAlgorithms.Core.Testing.Validators;
using System;
using System.Collections.Generic;

namespace SearchAlgorithms.UnitTests.Core.Testing.Validators
{
    [TestClass]
    public class SearchAlgorithmValidator_Test
    {
        private class ImproperlyWorkingSearch : ISearchAlgorithm
        {
            public string Name()
            {
                return "improperly working search";
            }

            public List<int> Search(in string lookingString, in string longString)
            {
                return new List<int>() { -1000 };
            }
        }

        [TestMethod]
        public void Validate_ValidationOfBuiltInSearchAlgorithmShouldPass()
        {
            var bus = new BuiltInSearch();
            var validator = new SearchAlgorithmValidator(bus);
            var result = validator.Validate();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_ValidationOfImproperlyWorkingSearchAlgorithmShouldFail()
        {
            var search = new ImproperlyWorkingSearch();
            var validator = new SearchAlgorithmValidator(search);
            var result = validator.Validate();
            Assert.IsFalse(result);
        }

    }
}
