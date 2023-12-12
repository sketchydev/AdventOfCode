using System.Drawing;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day11
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            int answer = 0;

            var linesList = new List<string>();

            var expansionFactor = 10;

            foreach (string line in lines)
            {

                if (line.All(c => c == '.')) linesList.Add(line);
                for (int i = 1; i <= expansionFactor; i++)
                {
                    linesList.Add(line);
                }

            }

            var linesArr = linesList.ToArray();

            var indexesToAdd = new List<int>();

            for (var i = 0; i < linesArr[0].Length; i++)
            {
                var isMatch = true;

                for (var j = 0; j < linesArr.Length; j++) {
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
                    for (int j = 1; j <= expansionFactor; j++)
                    {
                        str = str.Insert(index, ".");
                    }
                    linesArr[i] = str;
                }                
            }

            //finish expansion

            var coords = new Dictionary<int, Point>();
            var count = 0;

            for (var i = 0; i< linesArr.Length; i++)
            {
                for (var j = 0;j < linesArr[0].Length; j++) {
                    if (linesArr[i][j] == '#')
                    {
                        count++;
                        coords.Add(count, new Point(i,j));
                    }
                }
                Console.WriteLine(linesArr[i]);
            }   
            

            int distSum = 0;
            for (var i = 1; i < coords.Count; i++)
            {
                var start = coords[i];

                for (var j = i+1;  j <= coords.Count; j++) {
                    var dist = GetDistance2(start, coords[j]);
                    Console.WriteLine($"[{i}->{j}] : [{dist}]");  
                    distSum+= dist;
                }

            }
                   
            Console.WriteLine($"sum: [{distSum}]");


            Console.WriteLine("answer: " + answer);
        }

        public static int GetDistance2(Point start, Point end)
        {
            int dist = 0;
            
            var xDist = Math.Abs(start.X - end.X);
            var yDist = Math.Abs(start.Y - end.Y);

            dist += xDist;
            dist += yDist;
            
            return dist;
        }
    }    
}
