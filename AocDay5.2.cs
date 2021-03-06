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
            string[] input = System.IO.File.ReadLines("input5.1.txt").ToArray();
            List<int> instructions = input.Select(x => Int32.Parse(x)).ToList();

            int instructionCounter = 0;
            int totalSteps = 0;
            while (true)
            {
                if (instructionCounter >= instructions.Count || instructionCounter < 0)
                {
                    break;
                }

                int lastIns = instructionCounter;
                int jumpOffset = instructions[instructionCounter];
                instructionCounter += instructions[instructionCounter];
                if (jumpOffset >= 3)
                {
                    instructions[lastIns]--;
                }
                else
                {
                    instructions[lastIns]++;
                }
                totalSteps++;
            }

            Console.WriteLine(totalSteps);
        }
    }
}
