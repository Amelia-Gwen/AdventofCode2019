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
            GenerateAnswers generator = new GenerateAnswers();
            int answer = generator.GenerateAnswerDayFour();
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
