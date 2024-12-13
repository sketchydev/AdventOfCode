using System.Drawing;

namespace _AdventOfCode.AOC2024
{
    public static class Day12
    {
        public static void Run(List<string> lines)
        {
            //add padding to the input
            var paddedLines = CoreFunctions.AddPadding(lines, 1, '.');

            //Count of flowers = area; 1 per flower
            //permiter = every edge of a flower that is not touching another flower of the same type

            var allFlowers = new List<Flower>();

            for (int i = 0; i < paddedLines.Length; i++)
            {
                for (int j = 0; j < paddedLines[i].Length; j++)
                {
                    var flower = new Flower {
                        Location = new Point(j, i),
                        Type = paddedLines[i][j],
                        Area = 1,
                        Perimeter = 0
                    };
                }
            }


        }
    }

    public class Flower
    {
        public Point Location { get; set; }
        public char Type { get; set; }
        public int Perimeter { get; set; }
        public int Area { get; set; }
    }
}
