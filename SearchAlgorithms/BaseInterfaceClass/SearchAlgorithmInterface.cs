using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.BaseInterfaceClass
{
    public interface SearchAlgorithmInterface
    {
        List<int> search(in string lookingString, in string longString);

        string name();
    }
}
