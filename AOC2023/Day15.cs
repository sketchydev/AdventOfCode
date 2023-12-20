using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day15
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 15");

            long answer = 0;

            var vals = lines.First().Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
           
            
            foreach ( var val in vals )
            {
                var valChars = val.ToArray();

                long currentVal = 0;    
                foreach ( var ch in valChars) {

                    if (ch < 33 || ch > 255)
                    {
                        var x = "argh";
                    }

                    currentVal += ch;
                    currentVal *= 17;
                    currentVal %= 256;

                }
                Console.WriteLine(currentVal);

                answer += currentVal;
            }

            static int HASH(string input) => input.Aggregate(0, (x, y) => (((x + y) * 17) % 256));

            var answer2 = vals.Sum(HASH);

            Console.WriteLine("answer: " + answer);
            Console.WriteLine("answer2: " + answer2);
        }
    }
}
