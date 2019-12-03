using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile =
                 @"C:\Developer\Projects\AdventOfCode\AdventofCode2019\AdventofCode2019\Day2Input.txt";
            ProcessInput processor = new ProcessInput();
            GenerateAnswers generator = new GenerateAnswers();

            List<int> values = processor.GenerateListDayTwo(inputFile);
            int answer = generator.GenerateAnswerDayTwo(values);

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
