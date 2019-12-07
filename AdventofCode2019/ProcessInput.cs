using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace AdventofCode2019
{
    class ProcessInput
    {
        // Day 1 Input process.
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
        
        internal List<int> GenerateListDayTwo(string textFile)
        {
            List<int> listOfInputs = new List<int>();
            if (File.Exists(textFile))
            {
                string text = File.ReadAllText(textFile);
                string[] values = text.Split(',');
                foreach (string num in values)
                {
                    listOfInputs.Add(Int32.Parse(num));
                }
            }

            return listOfInputs;
        }

        // Tokenizer for Day 3
        internal List<string> GenerateTokens(string untokenizedString)
        {
            string[] values = untokenizedString.Split(',');
            List<string> tokens = new List<string>();
            foreach (string token in values)
            {
                tokens.Add(token);
            }
            return tokens;
        }
        // Process Tokens into Points Day 3
        internal List<Point> GenerateListOfPoints(List<string> tokens)
        {
            int x = 0;
            int y = 0;
            List<Point> points = new List<Point>();

            foreach(string token in tokens)
            {
                int distance = Int32.Parse(token.Substring(1));
                if(token[0] == 'U')
                {
                    for (int i = 0; i < distance; ++i)
                    {
                        ++x;
                        points.Add(new Point(x, y));
                    }
                }
                else if (token[0] == 'R')
                {
                    for (int i = 0; i < distance; ++i)
                    {
                        ++y;
                        points.Add(new Point(x, y));
                    }
                }
                else if (token[0] == 'D')
                {
                    for (int i = 0; i < distance; ++i)
                    {
                        --x;
                        points.Add(new Point(x, y));
                    }
                }
                else if (token[0] == 'L')
                {
                    for (int i = 0; i < distance; ++i)
                    {
                        --y;
                        points.Add(new Point(x, y));
                    }
                }
            }

            return points;
        }


        // This method should move to the generate answer class and be named for the day it solves.
        // It also solves part two only.
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
