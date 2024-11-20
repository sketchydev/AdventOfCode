using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day25
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 25");

            long answer = 0;

            var components = new Dictionary<string, string[]>();

            foreach(string line in lines)
            {
                var key = line.Split(':')[0];
                var vals = line.Split(':')[1].Split(' ').Select(s => s.Trim()).ToList();
                vals.Remove(string.Empty);
                
                components.Add(key, vals.ToArray());
            }

            Console.WriteLine("answer: " + answer);
        }
    }
}
