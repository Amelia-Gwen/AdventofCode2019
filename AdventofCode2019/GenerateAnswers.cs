using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2019
{
    class GenerateAnswers
    {
        internal int GenerateAnswerDayTwo(List<int> inputList)
        {
            int index = 0;

            while (true)
            {
                int tempVal = 0;
                if (inputList[index] == 99)
                {
                    break;
                }
                if (inputList[index] == 1)
                {
                    ++index;
                    tempVal = inputList[inputList[index]];
                    ++index;
                    tempVal += inputList[inputList[index]];
                    ++index;
                    inputList[inputList[index]] = tempVal;
                    ++index;
                }
                else
                {
                    ++index;
                    tempVal = inputList[inputList[index]];
                    ++index;
                    tempVal *= inputList[inputList[index]];
                    ++index;
                    inputList[inputList[index]] = tempVal;
                    ++index;
                }
            }

            return inputList[0];
        }
    }
}
