using System.Drawing;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day17
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 17");

            int answer = 0;


            var linesArr = lines.ToArray();

            // work out shortest path as a tester
            var minPathSum = linesArr[0].Select(x=>(int)x).ToList().Sum();
            for (int i = 1; i < linesArr.Length;i++)
            { 
                minPathSum+= int.Parse(linesArr[i][linesArr[i].Length-1].ToString());
            }

            Console.WriteLine($"initial min path:[{minPathSum}]");

            // 0 = X, 1 =Y
            var cursor = new int[] { 0, 0 };

            minPathSum = Move(cursor, linesArr[0].Length, linesArr.Length, 0);
             



            Console.WriteLine("answer: " + minPathSum);
        }

        public static int Move(int[] cursor, int xLim, int yLim, int slMoves)
        {
            return 0;



        }
    }
}
