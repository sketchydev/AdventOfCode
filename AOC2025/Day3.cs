namespace _AdventOfCode.AOC2025
{
    public static class Day3
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = ["987654321111111", "811111111111119", "234234234234278", "818181911112111"];


            var part1 = 0; long part2 = 0;


            
            //Part 1 - turn on exactly 2 batteries

            foreach (var line in lines)
            {
                int[] numbers = line
                    .Select(ch => int.Parse(ch.ToString())).ToArray();

                var combos = new List<int>();

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        var combo = int.Parse(string.Concat(numbers[i], numbers[j]));
                        combos.Add(combo);
                    }
                }

                Console.WriteLine($"Max Combo For line:{combos.Max()}");

                part1 += combos.Max();

            }

            //Part 2 - turn on exactly 12 batteries
            foreach (var line in lines)
            {
                //Find the largest digit that leaves at least 11 digits remaining
                var startindex = 0;
                var answerstring= "";
                var minremaining = 12;

                while (answerstring.Length < 12)
                {
                    for (int i = 9; i > 0; i--) { 
                        var index = line.IndexOf(i.ToString(), startindex);
                        if (index < 0) continue;
                        if (line.Length - index >= minremaining) { 
                            answerstring += line[index].ToString();
                            startindex = index + 1;
                            minremaining--;
                            break;
                        }
                    }
                }
                //Console.WriteLine($"Max Combo For line:{answerstring}");
                part2 += long.Parse(answerstring);
            }



            //Part1 answer
            Console.WriteLine($"Part 1: {part1}"); //16946 - correct


            //Part2 answer            
            Console.WriteLine($"Part 2: {part2}"); //168627047606506 - correct



        }

    }
}
