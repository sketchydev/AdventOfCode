using System.Drawing;


namespace _AdventOfCode.AOC2025
{
    public static class Day4
    {
        public static void Run(List<string> lines)
        {
            var part1 = 0;

            //Test input
            //var linesArr = new string[10];
            //linesArr[0] = "..@@.@@@@.";
            //linesArr[1] = "@@@.@.@.@@";
            //linesArr[2] = "@@@@@.@.@@";
            //linesArr[3] = "@.@@@@..@.";
            //linesArr[4] = "@@.@@@@.@@";
            //linesArr[5] = ".@@@@@@@.@";
            //linesArr[6] = ".@.@.@.@@@";
            //linesArr[7] = "@.@@@.@@@@";
            //linesArr[8] = ".@@@@@@@@.";
            //linesArr[9] = "@.@.@@@.@.";

            //lines = linesArr.ToList();

            var rollLocs = new List<Point>();

            //map roll locations
            for (var i=0;i<lines.Count;i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '@') rollLocs.Add(new Point(i, j));
                }
            }

            foreach (var rollLoc in rollLocs)
            {
                var adjacentRolls = rollLocs.Select(p => CoreFunctions.ArePointsAdjacent(rollLoc, p));
                var adjacentRollCount = adjacentRolls.Count(b => b == true);
                if (adjacentRollCount < 4) part1++;                
            }

            //Part1 answer
            Console.WriteLine($"Part 1: {part1}"); //1602

            //part2
            var part2 = 0;

            //Test input
            //linesArr = new string[10];
            //linesArr[0] = "..@@.@@@@.";
            //linesArr[1] = "@@@.@.@.@@";
            //linesArr[2] = "@@@@@.@.@@";
            //linesArr[3] = "@.@@@@..@.";
            //linesArr[4] = "@@.@@@@.@@";
            //linesArr[5] = ".@@@@@@@.@";
            //linesArr[6] = ".@.@.@.@@@";
            //linesArr[7] = "@.@@@.@@@@";
            //linesArr[8] = ".@@@@@@@@.";
            //linesArr[9] = "@.@.@@@.@.";

            //lines = linesArr.ToList();
            var matches = 0;
            do {
                
                rollLocs = new List<Point>();

                //map roll locations
                for (var i = 0; i < lines.Count; i++)
                {
                    for (var j = 0; j < lines[i].Length; j++)
                    {
                        if (lines[i][j] == '@')
                        {
                            rollLocs.Add(new Point(i, j));
                        
                        }
                    }
                }


                matches = 0;
                foreach (var rollLoc in rollLocs)
                {
                    var adjacentRolls = rollLocs.Select(p => CoreFunctions.ArePointsAdjacent(rollLoc, p));
                    var adjacentRollCount = adjacentRolls.Count(b => b == true);
                    if (adjacentRollCount < 4) { 
                        matches++;
                        var sb = new System.Text.StringBuilder(lines[rollLoc.X]);
                        sb[rollLoc.Y] = 'x';
                        lines[rollLoc.X] = sb.ToString();
                    }
                }
                part2 += matches;
                //test output
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }                        
            while (matches > 0) ;




            //Part2 answer            
            Console.WriteLine($"Part 2: {part2}");     //9518       


        }

        

    }
}
