using System.Diagnostics;

namespace _AdventOfCode.AOC2024
{
    public static class Day11
    {
        public static void Run(List<string> lines)
        {
            long answer = 0;

            var input = lines[0].Split(' ').Select(long.Parse).ToArray();
            var stones = CoreFunctions.ConvertArrayToLinkedList(input);

            var timer = new Stopwatch();    

            timer.Start();
            //answer = NodeCount(stones, 25);
            timer.Stop();
            
            Console.WriteLine($"Method 1[{answer}] Time: {timer.ElapsedMilliseconds/1000} s");

            answer = 0;
            timer.Restart();
            foreach (var Node in stones)
            {
                var newStones = new LinkedList<long>();
                newStones.AddLast(Node);

                answer+= NodeCount(newStones, 25);

            }
            timer.Stop();
            Console.WriteLine($"Method 2[{answer}] Time: {timer.ElapsedMilliseconds / 1000}s ");

            //Part1
            Console.WriteLine($"Part 1: {stones.Count}");

            
            

            //Part2
            Console.WriteLine($"Part 2: {answer}");


        }

        public static long NodeCount(LinkedList<long> stones, int limit)
        {
            for (int blinks = 0; blinks < limit; blinks++)
            {
                var newStones = new List<long>();
                var node = stones.First;
                for (int j = 0; j < stones.LongCount(); j++)
                {
                    if (node.Value == 0) newStones.Add(1);
                    else if (node.Value.ToString().Length % 2 == 0)
                    {
                        var halves = CoreFunctions.SplitStringInHalf(node.Value.ToString());

                        for (int i = 0; i < halves.Length; i++)
                        {
                            var trimmed = halves[i].TrimStart('0');
                            if (trimmed.Length == 0) halves[i] = "0";
                            else halves[i] = trimmed;
                        }

                        newStones.Add(long.Parse(halves[0]));
                        newStones.Add(long.Parse(halves[1]));
                    }
                    else newStones.Add(node.Value * 2024);
                    node = node.Next;
                }

                stones = CoreFunctions.ConvertArrayToLinkedList(newStones.ToArray());

                Console.WriteLine($"Blink {blinks + 1}: {stones.Count}");
                //Console.ReadLine();
            }

            return stones.Count;
        }
    }
}
