using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2024
{
    public static class Day13
    {                                      

        public static long minimumMove = 10000000;
        public static long maximumTarget = 0;
        public static void Run(List<string> lines)
        {


            Console.WriteLine($"Part 1: {DoStuff(lines, 0, 100)}");

            Console.WriteLine($"Resetting minimum move to {minimumMove} and maximum target to {maximumTarget}");
            //Resetting minimum move to 17 and maximum target to 18641
            var maxPresses = (long)(Math.Round((10000000000000.0 + maximumTarget) / minimumMove, 0));

            Console.WriteLine($"Max Presses:{maxPresses}");

            Console.WriteLine($"Part 2: {DoStuff(lines, 10000000000000,maxPresses)}");

        }

        public static long DoStuff(List<string> lines, long offset, long maxPresses)
        {
            long answer = 0;

            for (int i = 0; i < lines.Count; i = i + 4)
            {                
                long[] target = [0, 0];
                var buttonA = GetXY(lines[i],0);
                var buttonB = GetXY(lines[i + 1],0);
                var targets = GetXY(lines[i + 2], offset);

                //check if we need to reset the minimum move and/or maximum target

                if (buttonA[0] < minimumMove) minimumMove = buttonA[0];
                if (buttonA[1] < minimumMove) minimumMove = buttonA[1];
                if (buttonB[0] < minimumMove) minimumMove = buttonB[0];
                if (buttonA[1] < minimumMove) minimumMove = buttonB[1];

                if (targets[0] > maximumTarget) maximumTarget = targets[0];
                if (targets[1] > maximumTarget) maximumTarget = targets[1];
                // end this bit

                target[0] = targets[0];
                target[1] = targets[1];
                var tokenCosts = new List<long>();

                // do stuff

                var xAMultiples = GetMultiples(buttonA[0], maxPresses, targets[0]);
                var xBMultiples = GetMultiples(buttonB[0], maxPresses, targets[0]);

                ///now let's find the A combinations which are at target

                var xCombos = new List<long[]>();

                for (long j = 0; j < xAMultiples.Length; j++)
                {
                    for (long k = 0; k < xBMultiples.Length; k++)
                    {
                        if (xAMultiples[j] + xBMultiples[k] == targets[0]) xCombos.Add([j, k]);
                    }
                }

                //for each of these combos let's find the Valid Ys

                var validOverallCombos = new List<long[]>();

                foreach (var combo in xCombos)
                {
                    if (buttonA[1] * combo[0] + buttonB[1] * combo[1] == target[1]) validOverallCombos.Add(combo);
                }

                //now lets find out the cost of each combo

                foreach (var combo in validOverallCombos)
                {
                    tokenCosts.Add(combo[0] * 3 + combo[1]);
                }

                //if found
                if (tokenCosts.Count > 0)
                {
                    if (i==0)
                    {
                        Console.WriteLine($"**Win on claw {1}**");
                    }
                    else
                    {
                        Console.WriteLine($"**Win on claw {i/4+1}**");
                    }

                    answer += tokenCosts.Min();
                }



                //reset                             
                tokenCosts = [];
            }
            return answer;
        }   


        public static long[] GetMultiples(long initial, long count, long target)
        {
            var multiples = new List<long> { 0 };

            for (long i = 1; i <= count; i++)
            {
                var result = initial * i;
                if (result >= target) break;
                multiples.Add(result);

            }


            return multiples.ToArray();
        }

        public static long[] GetXY(string line, long offset)
        {
            var regex = new Regex(@"\d+");

            var matches = regex.Matches(line);

            var x = long.Parse(matches[0].Value) + offset;
            var y = long.Parse(matches[1].Value) + offset;
            return [x, y];
        }

    }
}
