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
            
            if (File.Exists(inputFile))
            {

            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
