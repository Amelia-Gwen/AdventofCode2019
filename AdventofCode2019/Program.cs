using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace AdventofCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile =
                 @"C:\Developer\Projects\AdventOfCode\AdventofCode2019\AdventofCode2019\Day3Input.txt";
            ProcessInput processor = new ProcessInput();
            GenerateAnswers generator = new GenerateAnswers();
            long answer = 0;

            if (File.Exists(inputFile))
            {
                string[] wires = File.ReadAllLines(inputFile);
                List<string> one = processor.GenerateTokens(wires[0]);
                List<string> two = processor.GenerateTokens(wires[1]);
                List<Point> wireOne = processor.GenerateListOfPoints(one);
                List<Point> wireTwo = processor.GenerateListOfPoints(two);
                answer = generator.GenerateAnswerDayThreePartTwo(wireOne, wireTwo);
            }

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
