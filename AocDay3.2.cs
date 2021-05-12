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
            Console.WriteLine(FindFirstLargerValue(Answer));
        }

        private static int FindFirstLargerValue(int target)
        {
            Dictionary<Point, int> data = new Dictionary<Point, int>();
            int sideLen = 1;
            int x = 0;
            int y = 0;
            Point p;
            while (true)
            {
                for (int i = 0; i < sideLen; ++i)
                {
                    int valueForPoint = GetSurroundingValues(data, x, y);
                    if (valueForPoint > target)
                    {
                        return valueForPoint;
                    }
                    data[new Point(x, y)] = valueForPoint;
                    ++x;
                }

                for (int i = 0; i < sideLen; ++i)
                {
                    int valueForPoint = GetSurroundingValues(data, x, y);
                    if (valueForPoint > target)
                    {
                        return valueForPoint;
                    }
                    data[new Point(x, y)] = valueForPoint;
                    --y;
                }
                ++sideLen;

                for (int i = 0; i < sideLen; ++i)
                {
                    int valueForPoint = GetSurroundingValues(data, x, y);
                    if (valueForPoint > target)
                    {
                        return valueForPoint;
                    }
                    data[new Point(x, y)] = valueForPoint;
                    --x;
                }

                for (int i = 0; i < sideLen; ++i)
                {
                    int valueForPoint = GetSurroundingValues(data, x, y);
                    if (valueForPoint > target)
                    {
                        return valueForPoint;
                    }
                    data[new Point(x, y)] = valueForPoint;
                    ++y;
                }
                ++sideLen;
            }
        }

        private static int GetSurroundingValues(Dictionary<Point, int> data, int x, int y)
        {
            if (x == 0 && y == 0)
            {
                return 1;
            }

            int totalSurrounding = 0;
            if (data.ContainsKey(new Point(x - 1, y - 1))) // Up left
            {
                totalSurrounding += data[new Point(x - 1, y - 1)];
            }
            if (data.ContainsKey(new Point(x, y - 1))) // Up
            {
                totalSurrounding += data[new Point(x, y - 1)];
            }
            if (data.ContainsKey(new Point(x + 1, y - 1))) // Up right
            {
                totalSurrounding += data[new Point(x + 1, y - 1)];
            }
            if (data.ContainsKey(new Point(x - 1, y))) // Left
            {
                totalSurrounding += data[new Point(x - 1, y)];
            }
            if (data.ContainsKey(new Point(x + 1, y))) // Right
            {
                totalSurrounding += data[new Point(x + 1, y)];
            }
            if (data.ContainsKey(new Point(x - 1, y + 1))) // Down Left
            {
                totalSurrounding += data[new Point(x - 1, y + 1)];
            }
            if (data.ContainsKey(new Point(x, y + 1))) // Down
            {
                totalSurrounding += data[new Point(x, y + 1)];
            }
            if (data.ContainsKey(new Point(x + 1, y + 1))) // Down Right
            {
                totalSurrounding += data[new Point(x + 1, y + 1)];
            }
            return totalSurrounding;
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

            public override bool Equals(Object obj)
            {
                //Check for null and compare run-time types.
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                else
                {
                    Point p = (Point)obj;
                    return (this.X == p.X) && (this.Y == p.Y);
                }
            }

            public override int GetHashCode()
            {
                return (this.X << 2) ^ this.Y;
            }
        }
    }
}
