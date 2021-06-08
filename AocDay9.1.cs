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
            string[] input = System.IO.File.ReadLines("input9.1.txt").ToArray();
            if (input.Length != 1)
            {
                throw new InvalidProgramException();
            }

            int totalScore = 0;
            int groupDepth = 0;
            char lastChar = '\0';
            bool inGarbage = false;
            foreach (char c in input.First())
            {
                if (lastChar == '!')
                {
                    lastChar = '\0';
                    continue;
                }

                if (!inGarbage && c == '{')
                {
                    groupDepth++;
                }
                else if (!inGarbage && c == '}')
                {
                    totalScore += groupDepth;
                    groupDepth--;
                }
                else if (c == '<')
                {
                    inGarbage = true;
                }
                else if (c == '>')
                {
                    inGarbage = false;
                }
                else
                {
                    // Do nothing
                }

                lastChar = c;
            }

            Console.WriteLine(totalScore);
        }
    }
}