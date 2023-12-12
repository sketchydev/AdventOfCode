using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day10
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 10");

            int answer = 0;

            var linesArr = lines.ToArray();

            var sRow = 0;
            var sCol = 0;


            var northValidMoves = "|F7";
            var eastValidMoves = "-7J";
            var southValidMoves = "|LJ";
            var westValidMoves = "-LF";

            for (var i =0;i<linesArr.Length;i++)
            {
                if (linesArr[i].Contains('S'))
                {
                    sRow = i;
                    sCol = linesArr[i].IndexOf('S');            
                }
            }

            var stepCounter = 0;
            char currentStep ='X';

            while (currentStep != 'S')
            {
                if (northValidMoves.Contains(linesArr[sRow - 1][sCol]))
                {

                }
                else if (eastValidMoves.Contains(linesArr[sRow][sCol+1]))
                { }
                else if (southValidMoves.Contains(linesArr[sRow+1][sCol]))
                { }
                else if (westValidMoves.Contains(linesArr[sRow][sCol-1]))
                { }
            }

            Console.WriteLine("answer: " + answer);
        }
        
    }
}
