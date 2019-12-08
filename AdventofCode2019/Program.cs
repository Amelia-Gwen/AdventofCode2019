using System;
using System.Collections.Generic;

namespace AdventofCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile =
                 @"C:\Developer\Projects\AdventOfCode\AdventofCode2019\AdventofCode2019\Day6Input.txt";
            ProcessInput processor = new ProcessInput();
            OrbitalMapCalculator calculator = new OrbitalMapCalculator();
            List<Tuple<string, string>> orbitalPairs = processor.GenerateOrbitalPairs(inputFile);
            calculator.ReadTokens(orbitalPairs);
            int answer = calculator.CountOrbits();

            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
