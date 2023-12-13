using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day11
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            var part1 = Part1(lines);
            var part2 = Part2(lines);


            Console.WriteLine($"Part 1: [{part1}]");
            Console.WriteLine($"Part 2: [{part2}]");

        }

        public static long GetDistance(Point start, Point end)
        {
            long dist = 0;
            
            var xDist = Math.Abs(start.X - end.X);
            var yDist = Math.Abs(start.Y - end.Y);

            dist += xDist;
            dist += yDist;
            
            return dist;
        }        

        public static long Part2(List<string> lines)
        {
            long distSum = 0;

            int expandBy = 999999; //2 == 1x2

            var emptyRows = new List<int>();
            var emptyCols = new List<int>();

            var linesArr = lines.ToArray();

            for (int i = 0; i < linesArr.Length; i++)
            {
                if (lines[i].All(c => c == '.'))
                {
                    emptyRows.Add(i);
                }
            }

            for (var i = 0; i < linesArr[0].Length; i++)
            {
                var isMatch = true;

                for (var j = 0; j < linesArr.Length; j++)
                {
                    if (linesArr[j][i] == '#')
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch) { emptyCols.Add(i); }

            }

            var coords = new Dictionary<int, Point>();
            var count = 0;

            for (var i = 0; i < linesArr.Length; i++)
            {
                for (var j = 0; j < linesArr[0].Length; j++)
                {
                    if (linesArr[i][j] == '#')
                    {
                        count++;


                        var colsExtra = emptyCols.Where(c => c < j).Count() * expandBy;
                        var rowsExtra = emptyRows.Where(c => c < i).Count() * expandBy;

                        var realX = j + colsExtra;
                        var realY = i + rowsExtra;

                        coords.Add(count, new Point(realX, realY));
                    }
                }
                Console.WriteLine(linesArr[i]);
            }

            for (var i = 1; i < coords.Count; i++)
            {
                var start = coords[i];

                for (var j = i + 1; j <= coords.Count; j++)
                {
                    long dist = GetDistance(start, coords[j]);
                    Console.WriteLine($"[{i}->{j}] : [{dist}]");
                    distSum += dist;
                }

            }

            return distSum;
        }

        public static long Part1(List<string> lines)
        {            

            var linesList = new List<string>();
            

            foreach (string line in lines)
            {

                if (line.All(c => c == '.'))
                {                    
                  linesList.Add(line);                 
                }
                linesList.Add(line);

            }

            var linesArr = linesList.ToArray();

            var indexesToAdd = new List<int>();

            for (var i = 0; i < linesArr[0].Length; i++)
            {
                var isMatch = true;

                for (var j = 0; j < linesArr.Length; j++)
                {
                    if (linesArr[j][i] == '#')
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch) { indexesToAdd.Add(i); }

            }

            indexesToAdd.Reverse();
            foreach (var index in indexesToAdd)
            {
                for (var i = 0; i < linesArr.Length; i++)
                {
                    var str = linesArr[i];
                    str = str.Insert(index, ".");
                    
                    linesArr[i] = str;
                    Console.Write($"\r[{i}]");

                }
                Console.Write($"\r[{index}]");
            }


            //finish expansion

            var coords = new Dictionary<int, Point>();
            var count = 0;

            for (var i = 0; i < linesArr.Length; i++)
            {
                for (var j = 0; j < linesArr[0].Length; j++)
                {
                    if (linesArr[i][j] == '#')
                    {
                        count++;
                        coords.Add(count, new Point(i, j));
                    }
                }
                Console.WriteLine(linesArr[i]);
            }


            long distSum = 0;
            for (var i = 1; i < coords.Count; i++)
            {
                var start = coords[i];

                for (var j = i + 1; j <= coords.Count; j++)
                {
                    long dist = GetDistance(start, coords[j]);
                    Console.WriteLine($"[{i}->{j}] : [{dist}]");
                    distSum += dist;
                }

            }

            return distSum;

        }
    }    
}


