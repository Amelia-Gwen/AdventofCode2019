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
            int noun = 0;
            int verb = 0;
            int counter = 0;

            while (true)
            {
                List<int> answerList = new List<int>(inputList);
                answerList[1] = noun;
                answerList[2] = verb;
                int index = 0;

                while (true)
                {
                    int tempVal = 0;
                    if (answerList[index] == 99) { break; }
                    if (answerList[index] == 1)
                    {
                        ++index;
                        tempVal = answerList[answerList[index]];
                        ++index;
                        tempVal += answerList[answerList[index]];
                        ++index;
                        answerList[answerList[index]] = tempVal;
                        ++index;
                    }
                    else
                    {
                        ++index;
                        tempVal = answerList[answerList[index]];
                        ++index;
                        tempVal *= answerList[answerList[index]];
                        ++index;
                        answerList[answerList[index]] = tempVal;
                        ++index;
                    }
                }

                Console.WriteLine(counter);
                counter++;

                if (answerList[0] == 19690720) { break; }
                if (noun < 100)
                {
                    ++noun;
                }
                else
                {
                    noun = 0;
                    ++verb;
                }
            }

            return noun * 100 + verb;
        }
    }
}
