using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aoc
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadLines("input8.1.txt").ToArray();
            Dictionary<string, int> program = new Dictionary<string, int>();
            foreach (string line in input)
            {
                // Collect the data, probably would be cleaner with regex
                string[] split = line.Split(' ');
                string regToChange = split[0];
                string regCommand = split[1];
                int regChangeValue = Int32.Parse(split[2]);
                string condition = split[3];
                string conditionReg = split[4];
                string condition2 = split[5];
                int conditionValue = Int32.Parse(split[6]);

                if (!program.ContainsKey(regToChange))
                {
                    program.Add(regToChange, 0);
                }
                if (!program.ContainsKey(conditionReg))
                {
                    program.Add(conditionReg, 0);
                }

                switch (condition)
                {
                    case "if":
                        if (IfConditionPasses(program, conditionReg, condition2, conditionValue))
                        {
                            RunRegisterChange(program, regToChange, regCommand, regChangeValue);
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine(program.Values.Max());
        }

        private static void RunRegisterChange(
            Dictionary<string, int> program, 
            string regToChange, 
            string regCommand, 
            int regChangeValue)
        {
            switch (regCommand)
            {
                case "inc":
                    program[regToChange] += regChangeValue;
                    break;
                case "dec":
                    program[regToChange] -= regChangeValue;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static bool IfConditionPasses(
            Dictionary<string, int> program, 
            string conditionReg, 
            string condition2, 
            int conditionValue)
        {
            switch (condition2)
            {
                case "<":
                    if (program[conditionReg] < conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "<=":
                    if (program[conditionReg] <= conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "!=":
                    if (program[conditionReg] != conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "==":
                    if (program[conditionReg] == conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ">=":
                    if (program[conditionReg] >= conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case ">":
                    if (program[conditionReg] > conditionValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
