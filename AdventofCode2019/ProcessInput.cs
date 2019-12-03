using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2019
{
    class ProcessInput
    {
        internal List<int> GenerateListOfInputs(string textFile)
        {
            List<int> listOfInputs = new List<int>();
            if (File.Exists(textFile))
            {
                string[] numbers = File.ReadAllLines(textFile);
                foreach (string num in numbers)
                {
                    listOfInputs.Add(int.Parse(num));
                }
            }

            return listOfInputs;
        }

        internal int ProcessAnswer(List<int> inputList)
        {
            int answer = 0;

            foreach (int num in inputList)
            {
                int number = num;
                while (number > 0)
                {
                    number /= 3;
                    number -= 2;
                    if (number > 0)
                    {
                        answer += number;
                    }
                }
            }

            return answer;
        }
    }
}
