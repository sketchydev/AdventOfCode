using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _AdventOfCode.AOC2023
{
    public static class Day3
    {
        public static void Run(List<string> inputLines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            var symbols = new List<Symbol>();
            var numbers = new List<Number>();

            var numberRegex = new Regex(@"(\d)+");
            var symbolRegex = new Regex(@"[^\.\d\n]");

            var lineNum = 0;
            foreach (var line in inputLines)
            {
                foreach (Match nm in numberRegex.Matches(line))
                    numbers.Add(new Number(
                        Value: int.Parse(nm.Value),
                        Pos: new Pos(lineNum, nm.Index, nm.Index + nm.Length - 1)));

                foreach (Match sm in symbolRegex.Matches(line))
                    symbols.Add(new Symbol(
                        Value: sm.Value,
                        Pos: new Pos(lineNum, sm.Index, sm.Index)));

                lineNum++;
            }

            var partSum = numbers
                .Where(n => symbols.Any(s => s.Pos.IsAdjacent(n)))
                .Sum(n => n.Value);

            var ratio = symbols
                .Where(s => s.Value is "*")
                .Sum(g =>
                {
                    var adjacentNumbers = numbers
                        .Where(n => g.Pos.IsAdjacent(n))
                        .ToList();
                    return adjacentNumbers.Count == 2
                        ? adjacentNumbers.Aggregate(1, (acc, n) => acc * n.Value)
                        : 0;
                });

            Console.WriteLine($"Part 1 answer: {partSum}");
            Console.WriteLine($"Part 2 answer: {ratio}");
        }

        record Pos(int Row, int ColStart, int ColEnd)
        {
            public bool IsAdjacent(Number number)
            {
                // same row, directly above or below
                if (Row < number.Pos.Row - 1 || Row > number.Pos.Row + 1)
                    return false;
                // within or directly adjacent to the number's column range
                return ColStart >= number.Pos.ColStart - 1 && ColStart <= number.Pos.ColEnd + 1;
            }
        };

        record Symbol(string Value, Pos Pos);

        record Number(int Value, Pos Pos);
    }
}
