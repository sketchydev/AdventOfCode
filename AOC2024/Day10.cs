using System.Drawing;

namespace _AdventOfCode.AOC2024
{
    public static class Day10
    {
        public static void Run(List<string> lines)
        {

            var Part1Answer = 0;
            var Part2Answer = 0;

            var locationValues = new Dictionary<int, List<Point>>
            {
                {0,new() },
                {1,new() },
                {2,new() },
                {3,new() },
                {4,new() },
                {5,new() },
                {6,new() },
                {7,new() },
                {8,new() },
                {9,new() }
            };

            var linesArr = lines.ToArray();

            for (int i = 0; i < linesArr.Length; i++)
            {
                for (int j = 0; j < linesArr[0].Length; j++)
                {
                    if (linesArr[j][i] == '0') locationValues[0].Add(new Point(j, i));
                    if (linesArr[j][i] == '1') locationValues[1].Add(new Point(j, i));
                    if (linesArr[j][i] == '2') locationValues[2].Add(new Point(j, i));
                    if (linesArr[j][i] == '3') locationValues[3].Add(new Point(j, i));
                    if (linesArr[j][i] == '4') locationValues[4].Add(new Point(j, i));
                    if (linesArr[j][i] == '5') locationValues[5].Add(new Point(j, i));
                    if (linesArr[j][i] == '6') locationValues[6].Add(new Point(j, i));
                    if (linesArr[j][i] == '7') locationValues[7].Add(new Point(j, i));
                    if (linesArr[j][i] == '8') locationValues[8].Add(new Point(j, i));
                    if (linesArr[j][i] == '9') locationValues[9].Add(new Point(j, i));
                }
            }

            foreach (var zero in locationValues[0])
            {
                var pairs = new List<Point>();


                foreach (var one in locationValues[1])
                {
                    if (CoreFunctions.PointAdjacentCheck(zero, one))
                    {
                        foreach (var two in locationValues[2])
                        {
                            if (CoreFunctions.PointAdjacentCheck(one, two))
                            {
                                foreach (var three in locationValues[3])
                                {
                                    if (CoreFunctions.PointAdjacentCheck(two, three))
                                    {
                                        foreach (var four in locationValues[4])
                                        {
                                            if (CoreFunctions.PointAdjacentCheck(three, four))
                                            {
                                                foreach (var five in locationValues[5])
                                                {
                                                    if (CoreFunctions.PointAdjacentCheck(four, five))
                                                    {
                                                        foreach (var six in locationValues[6])
                                                        {
                                                            if (CoreFunctions.PointAdjacentCheck(five, six))
                                                            {
                                                                foreach (var seven in locationValues[7])
                                                                {
                                                                    if (CoreFunctions.PointAdjacentCheck(six, seven))
                                                                    {
                                                                        foreach (var eight in locationValues[8])
                                                                        {
                                                                            if (CoreFunctions.PointAdjacentCheck(seven, eight))
                                                                            {
                                                                                foreach (var nine in locationValues[9])
                                                                                {
                                                                                    if (CoreFunctions.PointAdjacentCheck(eight, nine))
                                                                                    {
                                                                                        Part2Answer++;
                                                                                        pairs.Add(nine);
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Part1Answer += pairs.Distinct().Count();

            }

            //Part1
            Console.WriteLine($"Part 1: {Part1Answer}");
            //Part2
            Console.WriteLine($"Part 2: {Part2Answer}");


        }        
    }
}
