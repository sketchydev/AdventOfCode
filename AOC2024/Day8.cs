using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace _AdventOfCode.AOC2024
{
    public static class Day8
    {
        public static void Run(List<string> lines)
        {
            var antennaLocations = new Dictionary<char, Point[]>();

            //set up our vectors
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '.') continue; //ignore "spaces"

                    if (antennaLocations.ContainsKey(lines[i][j]))
                    {
                        antennaLocations[lines[i][j]] = antennaLocations[lines[i][j]].Append(new Point(j, i)).ToArray();
                    }
                    else
                    {
                        antennaLocations.Add(lines[i][j], [new Point(j, i)]);
                    }
                }
            }

            foreach (var location in antennaLocations)
            {
                var points = string.Join(", ", location.Value.Select(p => $"({p.X},{p.Y})"));
                Console.WriteLine($"Char: {location.Key}: {points}");
            }

            //Char: 0: (8, 1), (5, 2), (7, 3), (4, 4)
            //Char: A: (6, 5), (8, 8), (9, 9)

            // for each antena, calculate the distance between each point as a point

            var antiNodeLocations = new List<Point>();

            foreach (var location in antennaLocations)
            {
                var locationPairs = CoreFunctions.GeneratePairs(location.Value);

                foreach (var pair in locationPairs)
                {
                    antiNodeLocations.AddRange(GenerateAntinodes(pair.ToArray()));
                }
            }

            foreach (var location in antiNodeLocations)
            {
                Console.WriteLine($"({location.X},{location.Y})");
            }

            //remove duplicates

            antiNodeLocations = antiNodeLocations.Distinct().ToList();

            var answer = 0;
            //ignore antinodes outside the grid
            foreach (var antinode in antiNodeLocations)
            {
                if (antinode.X >= 0 && antinode.Y >= 0 && antinode.X < lines[0].Length && antinode.Y < lines.Count) answer++;                
            }

            Console.WriteLine($"Part 1: {answer}");

            ///Part 2

            antiNodeLocations = [];

            foreach (var location in antennaLocations)
            {
                var locationPairs = CoreFunctions.GeneratePairs(location.Value);

                foreach (var pair in locationPairs)
                {
                    antiNodeLocations.AddRange(GenerateAntinodesV2(pair.ToArray(), lines[0].Length, lines.Count));
                }
            }

            foreach (var location in antiNodeLocations)
            {
                Console.WriteLine($"({location.X},{location.Y})");
            }

            //remove duplicates

            antiNodeLocations = antiNodeLocations.Distinct().ToList();

            answer = 0;
            //ignore antinodes outside the grid
            foreach (var antinode in antiNodeLocations)
            {
                if (antinode.X >= 0 && antinode.Y >= 0 && antinode.X < lines[0].Length && antinode.Y < lines.Count) answer++;
            }

            Console.WriteLine($"Part 2: {answer}");



        }

        public static List<Point> GenerateAntinodes(Point[] nodeList)
        {
            
            var distanceX = nodeList[0].X - nodeList[1].X;
            var distanceY = nodeList[0].Y - nodeList[1].Y;
            var distance = new Point(distanceX, distanceY);

            var firstPointAntinode = new Point(nodeList[0].X + distance.X, nodeList[0].Y + distance.Y);
            var secondPointAntinode = new Point(nodeList[1].X - distance.X, nodeList[1].Y - distance.Y);
            

            return [firstPointAntinode, secondPointAntinode];
        }

        public static List<Point> GenerateAntinodesV2(Point[] nodeList, int xLim, int yLim)
        {
            int xmin = -xLim, xmax = xLim, ymin = -yLim, ymax = yLim;

            int x1 = nodeList[0].X, y1 = nodeList[0].Y, x2 = nodeList[1].X, y2 = nodeList[1].Y;


            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x2 > x1 ? 1 : -1;
            int sy = y2 > y1 ? 1 : -1;
            int err = dx - dy;

            var points = new List<Point>();

            while (true)
            {
                points.Add(new Point(x1, y1));

                if ((x1 >= xmax && sx > 0) || (x1 <= xmin && sx < 0) ||
                    (y1 >= ymax && sy > 0) || (y1 <= ymin && sy < 0))
                {
                    break;
                }

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }

            return points.Distinct().ToList();
        }
    }
}
