using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2024
{
    public class Day3
    {
        public static void Run(List<string> lines)
        {
            var sumOfMultiplications = 0;

            // Part 1
            string mulPattern = @"mul\((\d+),(\d+)\)";
            Regex regex = new(mulPattern);

            foreach (var line in lines)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    Console.WriteLine($"Matched: {match.Value}");

                    // Extract the two integers from the match
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);

                    // Calculate the product and add to the sum
                    int product = num1 * num2;
                    sumOfMultiplications += product;
                }
            }

            Console.WriteLine("Part 1: " + sumOfMultiplications);

            //Part 2
            sumOfMultiplications = 0;
            string pattern = @"don't\(\)(.*?)(do\(\)|$)";
            Regex substringRegex = new(pattern, RegexOptions.Singleline);

            var modifiedLines = new List<string>();

            foreach (var line in lines)
            {
                string modifiedLine = substringRegex.Replace(line, string.Empty);
                modifiedLines.Add(modifiedLine);
            }

            foreach (var line in modifiedLines)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    Console.WriteLine($"Matched: {match.Value}");

                    // Extract the two integers from the match
                    int num1 = int.Parse(match.Groups[1].Value);
                    int num2 = int.Parse(match.Groups[2].Value);

                    // Calculate the product and add to the sum
                    int product = num1 * num2;
                    sumOfMultiplications += product;
                }
            }



            Console.WriteLine("Part 2: " + sumOfMultiplications);
        }
    }
}