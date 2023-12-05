using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day5
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            int answer = 0;

            var linesArr = lines.ToArray();

            var seeds = Regex.Matches(linesArr[0], @"\d+").Cast<Match>().Select(m=> long.Parse(m.Value)).ToList();

            var sectionHeadNames = new[] { 
                "seed-to-soil map:", 
                "soil-to-fertilizer map:", 
                "fertilizer-to-water map:", 
                "water-to-light map:", 
                "light-to-temperature map:", 
                "temperature-to-humidity map:", 
                "humidity-to-location map:" };
            
            var SectionHeadIndexes = new Dictionary<string, int>();

            foreach (var name in sectionHeadNames)
            { 
                SectionHeadIndexes.Add(name, Array.IndexOf(linesArr,name));
            }

            var map1 = GenerateMap(SectionHeadIndexes["seed-to-soil map:"], linesArr);
            var map2 = GenerateMap(SectionHeadIndexes["soil-to-fertilizer map:"], linesArr);
            var map3 = GenerateMap(SectionHeadIndexes["fertilizer-to-water map:"], linesArr);
            var map4 = GenerateMap(SectionHeadIndexes["water-to-light map:"], linesArr);
            var map5 = GenerateMap(SectionHeadIndexes["light-to-temperature map:"], linesArr);
            var map6 = GenerateMap(SectionHeadIndexes["temperature-to-humidity map:"], linesArr);
            var map7 = GenerateMap(SectionHeadIndexes["humidity-to-location map:"], linesArr);


            Console.WriteLine("answer: " + answer);
        }



        public static List<Map> GenerateMap(int lineStart, string[] lines)
        {
            var lineCounter = lineStart + 1;
            var line = lines[lineCounter];

            var maps = new List<Map>();

            while (line != string.Empty)
            {
                var vals = Regex.Matches(line, @"\d+").Cast<Match>().Select(m => long.Parse(m.Value)).ToArray();

                var map = new Map
                {
                    DestinationStart = vals[0],
                    DestinationEnd = vals[0] + vals[2],
                    SourceStart = vals[1],                    
                    SourceEnd = vals[1] + vals[2]
                };
                maps.Add(map);
                lineCounter++;
                line = lines[lineCounter];
            }
            return maps;
        }
    }
    public class Map
    {
        public long SourceStart { get; set; }
        public long SourceEnd { get; set; }
        public long DestinationStart { get; set; }
        public long DestinationEnd { get; set; }
    }
}
