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
            string[] input = System.IO.File.ReadLines("input7.1.txt").ToArray();
            Dictionary<string, int> data = new Dictionary<string, int>();
            List<string> rightSide = new List<string>();
            foreach (string line in input)
            {
                string[] split = line.Split(' ');
                string betterFormat = split[1].Substring(1).Replace(')', ' ');
                data[split[0]] = Int32.Parse(betterFormat);
                if (split.Length > 2) // Leaf
                {
                    for (int i = 3; i < split.Length; ++i) // Ignore the "->" string AKA start at 3.
                    {
                        rightSide.Add(split[i].Replace(',', ' ').Trim());
                    }
                }
            }

            string answer = data.Keys.Where(x => !rightSide.Contains(x)).First();
            Console.WriteLine(answer);
        }
    }
}