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
            string[] input = System.IO.File.ReadLines("input1.1.txt").ToArray();
            if (input.Length != 1)
            {
                throw new InvalidProgramException();
            }

            int runningTotal = 0;
            foreach (string line in input)
            {
                int skipThisMany = line.Length / 2;
                for (int i = 0; i < line.Length; ++i)
                {
                    int comparisonIndex = (i + skipThisMany) % line.Length;
                    if (line[i] == line[comparisonIndex])
                    {
                        runningTotal += Int32.Parse(line.Substring(i, 1));
                    }
                }
            }
            Console.WriteLine(runningTotal);
        }
    }
}
