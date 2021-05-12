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
        private static readonly int Answer = 312051;
        static void Main(string[] args)
        {
            Dictionary<int, Point> data = GetData();
            Point p = data[Answer];
            Console.WriteLine(Math.Abs(p.X) + Math.Abs(p.Y));
        }

        private static Dictionary<int, Point> GetData()
        {
            int num = 1;
            int sideLen = 1;
            int x = 0;
            int y = 0;
            Dictionary<int, Point> data = new Dictionary<int, Point>();
            Point p = new Point(x, y);
            while (true)
            {
                for (int i = 0; i < sideLen; ++i)
                {
                    p = new Point(x, y);
                    data[num] = p;
                    ++num;
                    ++x;
                }

                for (int i = 0; i < sideLen; ++i)
                {
                    p = new Point(x, y);
                    data[num] = p;
                    ++num;
                    --y;
                }
                ++sideLen;

                for (int i = 0; i < sideLen; ++i)
                {
                    p = new Point(x, y);
                    data[num] = p;
                    ++num;
                    --x;
                }

                for (int i = 0; i < sideLen; ++i)
                {
                    p = new Point(x, y);
                    data[num] = p;
                    ++num;
                    ++y;
                }
                ++sideLen;

                if (num > Answer)
                {
                    return data;
                }
            }
        }

        private class Point
        { 
            public int X { get; private set; }
            public int Y { get; private set; }

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
    }
}
