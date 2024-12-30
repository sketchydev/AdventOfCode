namespace _AdventOfCode.AOC2024
{
    public static class Day19
    {
        public static void Run(List<string> lines)
        {
            var availableDesigns = lines[0].Split(',').Select(x => x.Trim()).ToList();

            var part1Answer = 0;
            var part2Answer = 0;

            for (int i = 2; i < lines.Count; i++)
            {
                Console.WriteLine($"Processing [{lines[i]}]");
                var target = lines[i];

                var potentialparts = availableDesigns.Where(x => target.Contains(x)).ToList(); //let's filter out the designs that are not in the target

                if (potentialparts.Count == 0)
                {
                    Console.WriteLine("No solution found");
                    continue;
                }

                //let's get longest token in potential parts
                var maxPartLength = potentialparts.OrderByDescending(x => x.Length).FirstOrDefault().Length;

                //look for the first character of the target in the potential parts - if there is a match, we can use that part, if not we increase the token size
                var tokenSize = 1;

                //get starters
                var potentialSolutions = potentialparts.Where(p => target.StartsWith(p)).ToList();

                while (potentialSolutions.Any())
                {
                    var tmpSolutions = new List<string>();
                    foreach (var part in potentialparts)
                    {
                        foreach (var sol in potentialSolutions)
                        {
                            tmpSolutions.Add(sol + part);
                        }
                    }

                    potentialSolutions.Clear();
                    potentialSolutions.AddRange(tmpSolutions.Where(x => target.StartsWith(x)).ToList().Distinct());

                    foreach (var sol in potentialSolutions)
                    {
                        if (sol == target)
                        {
                            Console.WriteLine($"Solution found for [{target}]");
                            part1Answer++;
                            part2Answer += potentialSolutions.Count(); // clearly not the way to do this...
                            potentialSolutions.Clear();
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Part 1: {part1Answer}");
            Console.WriteLine($"Part 1: {part2Answer}"); // 9186 = too low, 128378 = too low
        }
    }
}
