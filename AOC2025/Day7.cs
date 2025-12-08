namespace _AdventOfCode.AOC2025
{
    public static class Day7
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = [".......S.......", 
            //         "...............", 
            //         ".......^.......", 
            //         "...............", 
            //         "......^.^......",
            //         "...............",
            //         ".....^.^.^.....",
            //         "...............",
            //         "....^.^...^....",
            //         "...............",
            //         "...^.^...^.^...",
            //         "...............",
            //         "..^...^.....^..",
            //         "...............",
            //         ".^.^.^.^.^...^.",
            //         "..............."];
            
            var part1 = 0; var part2=0;

            var beamPositions = new List<int>()
            {
                //find the first beam
                lines[0].IndexOf('S')
            };

            //part1

            for (int i = 1; i < lines.Count; i++)
            {
                var splits = 0;
                if (!lines[i].Contains('^'))
                {
                    //no splitter on this line so just add the beams
                    foreach (var beam in beamPositions)
                    {
                        lines[i] = lines[i].Remove(beam, 1).Insert(beam, "|");
                    }
                    continue;
                }

                var splitterPositions = new List<int>();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '^') splitterPositions.Add(j);
                }

                var tmpNewBeamPositions = new List<int>();
                tmpNewBeamPositions.AddRange(beamPositions);
                foreach (var beam in beamPositions)
                {                    
                    if (splitterPositions.Contains(beam))
                    {
                        //split the beam
                        lines[i] = lines[i].Remove(beam+1, 1).Insert(beam+1, "|").Remove(beam - 1, 1).Insert(beam - 1, "|");
                        tmpNewBeamPositions.Remove(beam);
                        tmpNewBeamPositions.Add(beam - 1);
                        tmpNewBeamPositions.Add(beam + 1);
                        splits++;
                    }
                    else
                    {
                        //just continue the beam
                        lines[i] = lines[i].Remove(beam, 1).Insert(beam, "|");
                    }
                }
                beamPositions = tmpNewBeamPositions.Distinct().ToList();


                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                part1 += splits;
                Console.WriteLine($"Splits:[{splits}]");    
            }




            //Part1 answer
            Console.WriteLine($"Part 1: {part1}"); //1590


            //Part2 answer
            
            Console.WriteLine($"Part 2: {part2}");            


        }

    }
}
