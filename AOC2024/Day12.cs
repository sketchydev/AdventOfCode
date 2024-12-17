using System.Drawing;

namespace _AdventOfCode.AOC2024
{
    public static class Day12
    {
        public static void Run(List<string> lines)
        {
            var part1Answer = 0;
            var padding = 1;
            //add padding to the input
            var paddedLines = CoreFunctions.AddPadding(lines, padding, '.');

            //Count of flowers = area; 1 per flower
            //permiter = every edge of a flower that is not touching another flower of the same type

            var allFlowers = new List<Flower>();

            for (int i = padding; i < paddedLines.Length - padding; i++)
            {
                for (int j = padding; j < paddedLines[i].Length - padding; j++)
                {
                    var perimeter = 0;
                    var current = paddedLines[i][j];

                    if (paddedLines[i + 1][j] != current) perimeter++;
                    if (paddedLines[i - 1][j] != current) perimeter++;
                    if (paddedLines[i][j + 1] != current) perimeter++;
                    if (paddedLines[i][j - 1] != current) perimeter++;

                    var flower = new Flower
                    {
                        Location = new Point(j, i),
                        Type = paddedLines[i][j],
                        Area = 1,
                        Perimeter = perimeter
                    };
                    allFlowers.Add(flower);
                }
            }

            var visited = new HashSet<Point>();
            var flowerGroups = new List<List<Flower>>();

            foreach (var flower in allFlowers)
            {
                if (!visited.Contains(flower.Location))
                {
                    var group = new List<Flower>();
                    FloodFill(flower, allFlowers, visited, group);
                    flowerGroups.Add(group);
                }
            }

            // Output the flower groups for verification
            foreach (var group in flowerGroups)
            {
                var totalArea = group.Sum(g => g.Area);
                var totalPerimeter = group.Sum(g => g.Perimeter);
                var price = totalArea * totalPerimeter;

                Console.WriteLine($"A region of {group[0].Type} plants with price {totalArea} * {totalPerimeter} = {price}");
                part1Answer += price;
            }

            Console.WriteLine($"Part 1: {part1Answer}");





        }

        public static void FloodFill(Flower start, List<Flower> allFlowers, HashSet<Point> visited, List<Flower> group)
        {
            var stack = new Stack<Flower>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (visited.Contains(current.Location)) continue;

                visited.Add(current.Location);
                group.Add(current);

                var neighbors = GetNeighbors(current, allFlowers);
                foreach (var neighbor in neighbors)
                {
                    if (!visited.Contains(neighbor.Location) && neighbor.Type == current.Type)
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }

        public static List<Flower> GetNeighbors(Flower flower, List<Flower> allFlowers)
        {
            var neighbors = new List<Flower>();
            var directions = new List<Point>
            {
                new(0, 1), // Down
                new(0, -1), // Up
                new(1, 0), // Right
                new(-1, 0) // Left
            };

            foreach (var direction in directions)
            {
                var neighborLocation = new Point(flower.Location.X + direction.X, flower.Location.Y + direction.Y);
                var neighbor = allFlowers.FirstOrDefault(f => f.Location == neighborLocation);
                if (neighbor != null)
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
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
