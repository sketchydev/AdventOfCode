using System.Drawing;

namespace _AdventOfCode.AOC2024
{
    public static class Day18
    {
        public static void Run(List<string> lines)
        {
            var Q = new Queue<Point>();

            foreach (var line in lines)
            {
                var split = line.Split(',');
                Q.Enqueue(new Point(int.Parse(split[0]), int.Parse(split[1])));
            }

            var Xlim = 71;
            var Ylim = 71;

            var startPoint = new Point(0, 0);
            var goalPoint = new Point(Xlim - 1, Ylim - 1); // Adjusted to be within bounds
            var bytesToDrop = 1024;

            var map = new char[Xlim, Ylim];

            for (var i = 0; i < Xlim; i++)
            {
                for (var j = 0; j < Ylim; j++)
                {
                    map[i, j] = '.';
                }
            }

            for (var i = 0; i < bytesToDrop; i++)
            {
                var p = Q.Dequeue();
                map[p.X, p.Y] = '#';
            }


            List<Point> shortestPath;
            var nextByte = new Point(0,0);

            do
            {
                shortestPath = FindShortestPath(map, startPoint, goalPoint);

                // Output the shortest path length or path itself
                Console.WriteLine(shortestPath != null ? $"Shortest path length: {shortestPath.Count}" : "No path found");

                if (shortestPath == null)
                {
                    Console.WriteLine($"Failure at: [{nextByte.X},{nextByte.Y}]");
                    break;
                }
                else
                {
                    nextByte = Q.Dequeue();
                    map[nextByte.X, nextByte.Y] = '#';
                }

            } while (shortestPath != null);


        }

        private static List<Point> FindShortestPath(char[,] map, Point start, Point goal)
        {
            var directions = new Point[]
            {
                new(0, 1),  // Right
                new(1, 0),  // Down
                new(0, -1), // Left
                new(-1, 0)  // Up
            };

            var queue = new Queue<(Point point, List<Point> path)>();
            var visited = new HashSet<Point>();
            queue.Enqueue((start, new List<Point> { start }));
            visited.Add(start);

            while (queue.Count > 0)
            {
                var (current, path) = queue.Dequeue();

                if (current == goal)
                {
                    return path;
                }

                foreach (var direction in directions)
                {
                    var next = new Point(current.X + direction.X, current.Y + direction.Y);

                    if (next.X >= 0 && next.X < map.GetLength(0) && next.Y >= 0 && next.Y < map.GetLength(1) &&
                        map[next.X, next.Y] == '.' && !visited.Contains(next))
                    {
                        visited.Add(next);
                        var newPath = new List<Point>(path) { next };
                        queue.Enqueue((next, newPath));
                    }
                }
            }

            return null; // No path found
        }
    }
}
