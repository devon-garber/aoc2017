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
        private static readonly int[] InputData = new int[] { 5, 1, 10, 0, 1, 7, 13, 14, 3, 12, 8, 10, 7, 12, 0, 6 };
        static void Main(string[] args)
        {
            List<List<int>> allSoFar = new List<List<int>>();
            int cycleCount = 1;
            List<int> newIter = RunLoopIteration(InputData.ToList());
            allSoFar.Add(newIter);
            while (true)
            {
                cycleCount++;
                newIter = RunLoopIteration(newIter);
                if (ListContained(allSoFar, newIter))
                {
                    Console.WriteLine(cycleCount);
                    return;
                }
                allSoFar.Add(newIter);
            }
        }

        private static List<int> RunLoopIteration(List<int> start)
        {
            int indexToChange = start.IndexOf(start.Max());
            int valueOfIndex = start[indexToChange];
            List<int> changedList = new List<int>(start);
            changedList.RemoveAt(indexToChange);
            changedList.Insert(indexToChange, 0);
            for (int i = 0; i < valueOfIndex; ++i)
            {
                indexToChange++;
                if (indexToChange == start.Count)
                {
                    indexToChange = 0;
                }
                changedList[indexToChange]++;
            }

            return changedList;
        }

        private static bool ListContained(List<List<int>> all, List<int> newList)
        {
            foreach (List<int> list in all)
            {
                if (list.SequenceEqual(newList))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
