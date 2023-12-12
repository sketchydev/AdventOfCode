using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day6
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 6");
            

            var lineArr = lines.ToArray();

            //var times = Regex.Matches(lines[0], @"\d+").Cast<Match>().Select(m=>int.Parse(m.Value)).ToArray();
            //var Distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();

            var races = new List<long[]>();
            //for (int i = 0; i < times.Length; i++) {
            //    races.Add([times[i], Distances[i]]);
            //}

            races.Add([54708275,239114212951253]);           

            long answer = 1;

            foreach (var race in races)
            {
                long winninginwWays = 0;                

                for (long i = 1; i < race[0] + 1; i++)
                {                    
                    var remainingTime = race[0] - i;                    

                    if (i * remainingTime > race[1]) winninginwWays++;
                }

                if (winninginwWays > 0) answer *= winninginwWays;
            }


            Console.WriteLine("answer: " + answer);
        }
    }
}
