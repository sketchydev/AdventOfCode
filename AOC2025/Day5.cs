namespace _AdventOfCode.AOC2025
{
    public static class Day5
    {
        public static void Run(List<string> lines)
        {
            var part1 = 0; long part2 = 0;  


            //Test input
            //lines = ["3-5", "10-14","16-20","12-18","","1","5","8","11","17","32"];

            //min-max pairs
            var ranges = new List<Tuple<long,long>>();
            var ingredients = new List<long>();

            //part 1
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                if (line.Contains('-'))
                {
                    var split = line.Split('-');
                    var min = long.Parse(split[0]);
                    var max = long.Parse(split[1]);
                    ranges.Add(new Tuple<long, long>(min, max));
                }
                else
                {
                    ingredients.Add(long.Parse(line));
                }
            }

            foreach (var ingredient in ingredients)
            {
                foreach (var range in ranges)
                {
                    if (ingredient >= range.Item1 && ingredient <= range.Item2)
                    {
                        Console.WriteLine($" Ingredient {ingredient} is in range {range.Item1}-{range.Item2}");
                        part1++;
                        break;
                    }
                }
            }

            //part 2

            //sort ranges
            ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            //merge overlapping ranges
            var mergedRanges = new List<Tuple<long, long>>();
            foreach (var range in ranges)
            {
                Console.WriteLine($" Range: {range.Item1}-{range.Item2}");
                if (mergedRanges.Count == 0)
                {
                    Console.WriteLine($"Adding: {range.Item1}-{range.Item2}");
                    mergedRanges.Add(range);
                    continue;
                }
                else
                {
                    if (mergedRanges.Last().Item2 > range.Item1 || mergedRanges.Last().Item2 + 1 == range.Item1)
                    {
                        var tmp = mergedRanges.Last();
                        mergedRanges.Remove(mergedRanges.Last());
                        mergedRanges.Add(new Tuple<long, long>(tmp.Item1, range.Item2));
                        Console.WriteLine($" Merging: {tmp.Item1}-{tmp.Item2} with {range.Item1}-{range.Item2} to {tmp.Item1}-{range.Item2}");
                    }
                    else
                    {
                        Console.WriteLine($"Adding: {range.Item1}-{range.Item2}");
                        mergedRanges.Add(range);
                    }   
                }
            }

            foreach (var range in mergedRanges)
            {                 
                part2 += range.Item2 - range.Item1 + 1;
                Console.WriteLine($" Merged Range: {range.Item1}-{range.Item2} - sum of diff: {part2}");
            }
            






            //Part1 answer
            Console.WriteLine($" Part 1: {part1}"); // 735 


            //Part2 answer                       
            Console.WriteLine($" Part 2: {part2}");
            //316105981563145 - low


        }


    }
}
