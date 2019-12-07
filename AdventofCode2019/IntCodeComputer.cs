using System;
using System.IO;
using System.Collections.Generic;

namespace AdventofCode2019
{
    class IntCodeComputer
    {
        private int index = 0;
        private List<int> program = new List<int>();

        internal void InitializeProgram(string sourceFile)
        {
            if (File.Exists(sourceFile))
            {
                string text = File.ReadAllText(sourceFile);
                string[] values = text.Split(',');
                foreach (string num in values)
                {
                    program.Add(Int32.Parse(num));
                }
            }
        }

        internal void ReadProgram()
        {
            index = 0;
            while (true)
            {
                int tempVal = 0;
                string opcode = program[index].ToString();
                ++index;
                int opcodeIndex = opcode.Length - 1;
                if (opcode[opcodeIndex] == '9') { break; }
                else if (opcode[opcodeIndex] == '1')
                {
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal = program[program[index]];
                        ++index;
                    }
                    else
                    {
                        tempVal = program[index];
                        ++index;
                    }
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal += program[program[index]];
                        ++index;
                    }
                    else
                    {
                        tempVal += program[index];
                        ++index;
                    }

                    program[program[index]] = tempVal;
                    ++index;
                }
                else if (opcode[opcodeIndex] == '2')
                {
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal = program[program[index]];
                        ++index;
                    }
                    else
                    {
                        tempVal = program[index];
                        ++index;
                    }
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal *= program[program[index]];
                        ++index;
                    }
                    else
                    {
                        tempVal *= program[index];
                        ++index;
                    }

                    program[program[index]] = tempVal;
                    ++index;
                }
                else if (opcode[opcodeIndex] == '3')
                {
                    program[program[index]] = int.Parse(Console.ReadLine());
                    ++index;
                }
                else if (opcode[opcodeIndex] == '4')
                {
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        Console.WriteLine("Debug Code is: " + program[program[index]]);
                        ++index;
                    }
                    else
                    {
                        Console.WriteLine("Debug Code is: " + program[index]);
                        ++index;
                    }
                }
            }
        }
    }
}
