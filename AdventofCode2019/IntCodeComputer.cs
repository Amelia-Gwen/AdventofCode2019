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
                else if (opcode[opcodeIndex] == '5')
                {
                    bool isNonZero;
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        isNonZero = program[program[index]] != 0;
                        ++index;
                    }
                    else
                    {
                        isNonZero = program[index] != 0;
                        ++index;
                    }
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        int tempIndex = index++;
                        if (isNonZero) { index = program[program[tempIndex]]; }
                    }
                    else
                    {
                        int tempIndex = index++;
                        if (isNonZero) { index = program[tempIndex]; }
                    }
                }
                else if (opcode[opcodeIndex] == '6')
                {
                    bool isZero;
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        isZero = program[program[index]] == 0;
                        ++index;
                    }
                    else
                    {
                        isZero = program[index] == 0;
                        ++index;
                    }
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        int tempIndex = index++;
                        if (isZero) { index = program[program[tempIndex]]; }
                    }
                    else
                    {
                        int tempIndex = index++;
                        if (isZero) { index = program[tempIndex]; }
                    }
                    

                }
                else if (opcode[opcodeIndex] == '7')
                {
                    bool less;
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal = program[program[index]];
                    }
                    else
                    {
                        tempVal = program[index];
                    }
                    ++index;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        less = tempVal < program[program[index]];
                    }
                    else
                    {
                        less = tempVal < program[index];
                    }
                    ++index;
                    program[program[index]] = less ? 1 : 0;
                    ++index;
                }
                else if (opcode[opcodeIndex] == '8')
                {
                    bool equal;
                    --opcodeIndex;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        tempVal = program[program[index]];
                    }
                    else
                    {
                        tempVal = program[index];
                    }
                    ++index;
                    --opcodeIndex;
                    if (opcodeIndex < 0 || opcode[opcodeIndex] == '0')
                    {
                        equal = tempVal == program[program[index]];
                    }
                    else
                    {
                        equal = tempVal == program[index];
                    }
                    ++index;
                    program[program[index]] = equal ? 1 : 0;
                    ++index;
                }
            }
        }
    }
}
