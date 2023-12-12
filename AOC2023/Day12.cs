using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day12
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 12");

            long answer = 0;

            /* . - operational
             * # - damaged
             * ? - unknown
             */


            foreach (string line in lines)
            {

                var split = line.Split(' ');

                var springs = split[0];
                var patterns = split[1];


                //for (var i = 1; i <= 5; i++)
                //{
                //    springs = springs + $"?{split[0]}";
                //    patterns = patterns + $",{split[1]}";
                //}

                var pattern = patterns.Split(',').Select(x => int.Parse(x)).ToArray();

                var goal = "";

                foreach (var val in pattern)
                {
                    goal = $"{goal}{new string('#', val)}.";
                }

                goal = goal.TrimEnd('.');


                var possiblePatterns = new List<string> { springs };

                possiblePatterns = EnumeratePatterns(possiblePatterns, pattern);


                long matchCount = 0;

                foreach (var possiblePattern in possiblePatterns)
                {
                    if(IsPatternMatch(possiblePattern, pattern)) matchCount++;
                }
                


                Console.WriteLine(matchCount);
                answer += matchCount;
            }
                                
            Console.WriteLine("answer: " + answer);
        }

        private static List<string> EnumeratePatterns(List<string> possiblePatterns, int[] pattern)
        {
            var newList = new List<string>();

            foreach (var possiblePattern in possiblePatterns)
            {
                if (possiblePattern.Contains('?'))
                {
                    var replacementIndex = possiblePattern.IndexOf('?');

                    var option1 = possiblePattern.Remove(replacementIndex, 1).Insert(replacementIndex, "#");
                    var option2 = possiblePattern.Remove(replacementIndex, 1).Insert(replacementIndex, ".");

                    if (IsPossibleMatch(option1, pattern)) newList.Add(option1);
                    if (IsPossibleMatch(option2, pattern)) newList.Add(option2);                    

                }
            }

            if (newList.Any(x => x.Contains('?'))) newList = EnumeratePatterns(newList, pattern);
            return newList;
        }

        private static bool IsPossibleMatch(string springs, int[] pattern)
        {
                     
            
            return true;
        }


        private static bool IsPatternMatch(string springs, int[] pattern)
        {                        
            var brokenCount = 0;
            var brokenList = new List<int>();
            for (int i = 0; i < springs.Length; i++)
            {

                if (springs[i] == '.') {
                    if(brokenCount >0)
                    { 
                        brokenList.Add(brokenCount);
                        brokenCount = 0; 
                    }
                    
                    continue;
                };
                if (springs[i] == '#')
                { 
                    brokenCount++;
                }

            }

            if (brokenCount > 0)
            {
                brokenList.Add(brokenCount);
                brokenCount = 0;
            }

            if (brokenList.Count != pattern.Length) return false;

            var brokenArr = brokenList.ToArray();

            for (int i = 0; i < pattern.Length;i++)
            {
                if (brokenArr[i] != pattern[i]) return false;
            }

            return true;        
        }

    }
}
