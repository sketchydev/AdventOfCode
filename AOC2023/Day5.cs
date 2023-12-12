using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day5
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            long answer = 0;

            var linesArr = lines.ToArray();

            var maps = new Dictionary<int,List<Map>>();

            var seeds = Regex.Matches(linesArr[0], @"\d+").Cast<Match>().Select(m=> long.Parse(m.Value)).ToList();


            var newSeedList = new List<long>();

            for (int i = 0; i < seeds.Count; i += 2)
            {
                for (long j = seeds[i]; j <= seeds[i + 1]; j++)
                { 
                    newSeedList.Add(j);
                }
            }




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

            for (int i = 1; i <= sectionHeadNames.Length; i++)
            { 
                maps.Add(i, GenerateMap(SectionHeadIndexes[sectionHeadNames[i-1]], linesArr));
            }


            var locCount = 0;

            var match = false;

            while (!match) {
            
            

            
            
            
            
            
            
            
            locCount++;
            }










            ////////////////////////////////////////

            var locations = new List<long>();

            var counter = newSeedList.Count;

            foreach (var seed in newSeedList)
            {
                var nextInputVal = seed;

                for(var i = 1; i<= maps.Keys.Count;i++)
                {
                    foreach (var map in maps[i])
                    {
                        if (nextInputVal >= map.SourceStart && nextInputVal <= map.SourceEnd)
                        { 
                            var offset = nextInputVal - map.SourceStart;
                            nextInputVal = map.DestinationStart + offset;
                            break;
                        }
                    }

                }
                locations.Add(nextInputVal);
                counter--;
                Console.Write($"\r count:[{counter}]");
            }

            answer = locations.OrderBy(x => x).ToArray()[0];

            Console.WriteLine("answer: " + answer);

            //Part 2 - wrong: 589824481
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
                if (lineCounter >= lines.Length)
                { line = ""; }
                else { line = lines[lineCounter]; }
                    
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
