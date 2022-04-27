using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SearchAlgorithms.BaseInterfaceClass;

namespace SearchAlgorithms.TestAlgorithm
{
    public class FirstAlgorithm : SearchAlgorithmInterface
    {
        public FirstAlgorithm(int r)
        {
            random = r;
        }

        private int random;

        public string name()
        {
            return "first";
        }
        public List<int> search(in string lookingString,in string longString)
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
