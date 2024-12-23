namespace _AdventOfCode.AOC2024
{
    public static class Day23
    {
        public static void Run(List<string> lines)
        {
            var part1Answer = 0;
            var fullList = new List<string>();
            var graph = new Dictionary<string, HashSet<string>>();

            // Build the graph
            foreach (var line in lines)
            {
                var parts = line.Split('-');
                var node1 = parts[0];
                var node2 = parts[1];

                if (!graph.ContainsKey(node1))
                {
                    graph[node1] = [];
                }
                if (!graph.ContainsKey(node2))
                {
                    graph[node2] = [];
                }

                graph[node1].Add(node2);
                graph[node2].Add(node1);
            }

            // Find triplets
            var triplets = new List<(string, string, string)>();

            foreach (var node1 in graph.Keys)
            {
                foreach (var node2 in graph[node1])
                {
                    foreach (var node3 in graph[node2])
                    {
                        if (node3 != node1 && graph[node3].Contains(node1))
                        {
                            var triplet = new List<string> { node1, node2, node3 };
                            triplet.Sort();
                            var tripletTuple = (triplet[0], triplet[1], triplet[2]);

                            if (!triplets.Contains(tripletTuple))
                            {
                                triplets.Add(tripletTuple);
                            }
                        }
                    }
                }
            }

            // Output triplets
            foreach (var triplet in triplets)
            {
                Console.WriteLine($"{triplet.Item1},{triplet.Item2},{triplet.Item3}");
                if(triplet.Item1.StartsWith('t')|| triplet.Item2.StartsWith('t') || triplet.Item3.StartsWith('t')) part1Answer++;
            }

            Console.WriteLine($"Part 1: {part1Answer}");



        }
    }
}