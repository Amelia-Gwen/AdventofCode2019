using System;

namespace AdventofCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile =
                 @"C:\Developer\Projects\AdventOfCode\AdventofCode2019\AdventofCode2019\Day5Input.txt";
            IntCodeComputer computer = new IntCodeComputer();
            computer.InitializeProgram(inputFile);
            computer.ReadProgram();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
