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
            string[] input = System.IO.File.ReadLines("input2.1.txt").ToArray();

            int checksumTotal = 0;
            foreach (string line in input)
            {
                string[] split = line.Split('\t');
                IEnumerable<int> lineConverted = split.Select(x => Int32.Parse(x));
                checksumTotal += lineConverted.Max() - lineConverted.Min();
            }

            Console.WriteLine(checksumTotal);
        }
    }
}
