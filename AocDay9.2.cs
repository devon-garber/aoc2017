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

            int garbageTotal = 0;
            char lastChar = '\0';
            bool inGarbage = false;
            foreach (char c in input.First())
            {
                if (lastChar == '!')
                {
                    lastChar = '\0';
                    continue;
                }

                if (c == '<' && !inGarbage)
                {
                    inGarbage = true;
                }             
                else if (c == '>')
                {
                    inGarbage = false;
                }
                else if (inGarbage && c != '!')
                {
                    garbageTotal++;
                }

                lastChar = c;
            }

            Console.WriteLine(garbageTotal);
        }
    }
}