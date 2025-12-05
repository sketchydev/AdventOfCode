namespace _AdventOfCode.AOC2025
{
    public static class Day2
    {
        public static void Run(List<string> lines)
        {
            long part1 = 0;
            long part2 = 0;
            //test input
            //lines[0] = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

            var ranges = lines[0].Split(',');

            ////part 1
            //foreach (var range in ranges)
            //{
            //    var start = long.Parse(range.Split('-')[0]);
            //    var end = long.Parse(range.Split('-')[1]);                

            //    var current = start;

            //    while (current <= end)
            //    {
            //        //Console.WriteLine($"id: {id}");
            //        if (current.ToString().Length % 2 != 0) {
            //            current++;
            //            continue;
            //        } ;
                     

            //        var split = CoreFunctions.SplitStringInHalf(current.ToString());
            //        if (split[0] == split[1])
            //        {
            //            Console.WriteLine($"Invalid ID found: {current}");
            //            part1 += current;
            //        }
            //        current++;
            //    }
            //}

            //Console.WriteLine($"Part 1: {part1}");            
            //19574776074 - correct


            //suspected part 2 :
            foreach (var range in ranges)
            {
                Console.WriteLine($"Range:{range}");
                var start = long.Parse(range.Split('-')[0]);
                var end = long.Parse(range.Split('-')[1]);

                var current = start;

                while (current <= end)
                {
                    var midpoint = current.ToString().Length / 2;
                    for (int i = 1; i <= midpoint; i++)
                    {
                        var checkSubstring = current.ToString().Substring(0, i);
                        var checkWholeString = string.Concat(Enumerable.Repeat(checkSubstring, current.ToString().Length/checkSubstring.Length));
                        if (checkWholeString == current.ToString())
                        {
                            part2 += current;                            
                            Console.WriteLine($"Invalid ID found: {current} (substring:{checkSubstring})");
                            break;
                        }
                    }
                    current++;
                }

            }

            
            Console.WriteLine($"Part 2: {part2}");
            //25912654282 correct

        }
    }
}
