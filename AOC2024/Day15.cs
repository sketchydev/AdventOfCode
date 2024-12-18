using System.Drawing;

namespace _AdventOfCode.AOC2024
{
    public static class Day15
    {
        public static void Run(List<string> lines)
        {
            var moves = string.Empty;
            var maps = new List<string>();

            var isMap = true;


            foreach (var line in lines)
            {
                if (line == "")
                {
                    isMap = false;
                    continue;
                }

                if (isMap) maps.Add(line);
                else string.Concat(moves, line);
            }

            //find the robot

            var robot = new Point(0,0);

            foreach (var line in maps)
            {
                if (line.Contains('@'))
                {
                    robot = new Point(line.IndexOf('@'), maps.IndexOf(line));
                    break;
                }
            }

            Console.WriteLine($"Robot Pos:({robot.X},{robot.Y})");





        }
    }
}
