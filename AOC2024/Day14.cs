using System.Drawing;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2024
{
    public static class Day14
    {
        public static void Run(List<string> lines)
        {
            //Adjust for live run
            var spaceRows = 103;
            var spaceCols = 101;
            var iterations = 100;

            var space = new int[spaceRows, spaceCols];

            var robots = new List<Robot>();


            foreach (var line in lines)
            {
                var positions = Regex.Matches(line, @"-?\d+");
                var p = new Point(int.Parse(positions[0].Value), int.Parse(positions[1].Value));
                var v = new Point(int.Parse(positions[2].Value), int.Parse(positions[3].Value));
                robots.Add(new Robot { p = p, v = v });
            }

            Console.WriteLine($"Robots: {robots.Count}");

            //establish starting positions
            foreach (var robot in robots)
            {
                space[robot.p.Y, robot.p.X] += 1;
            }


            Console.WriteLine("Starting Space:");
            for (int i = 0; i < space.GetLength(0); i++)
            {
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    Console.Write(space[i, j]);
                }
                Console.WriteLine();
            }
            //All good up to here

            for (int i = 0; i < iterations; i++)
            {
                foreach (var robot in robots)
                {
                    Move(space, robot);
                }
            }

            //work out quadrents
            Console.WriteLine("Ending Space:");
            for (int i = 0; i < space.GetLength(0); i++)
            {
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    Console.Write(space[i, j]);
                }
                Console.WriteLine();
            }



            var quadrents = new int[4];
            quadrents[0] = 0;
            quadrents[1] = 0;
            quadrents[2] = 0;
            quadrents[3] = 0;

            for (int i = 0; i < spaceCols; i++)
            {
                for (int j = 0; j < spaceRows; j++)
                {
                    if (i < spaceCols / 2)
                    {
                        if (j < spaceRows / 2)
                        {
                            quadrents[0] += space[j, i];
                        }
                        else if (j > spaceRows / 2)
                        {
                            quadrents[2] += space[j, i];
                        }
                    }
                    else if (i > spaceCols / 2)
                    {
                        if (j < spaceRows / 2)
                        {
                            quadrents[1] += space[j, i];
                        }
                        else if (j > spaceRows / 2)
                        {
                            quadrents[3] += space[j, i];
                        }
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Quadrent " + i + ": " + quadrents[i]);
            }


            //establish number of robots in each quadrent
            var part1 = quadrents[0] * quadrents[1] * quadrents[2] * quadrents[3];  

            Console.WriteLine($"Part 1: {part1}");

        }

        private static void Move(int[,] space, Robot robot)
        {
            //remove robot from current space
            space[robot.p.Y, robot.p.X] -= 1;

            //establish new position
            var tmpNewPosition = new Point(robot.p.X + robot.v.X, robot.p.Y + robot.v.Y);

            //update robot position if within bounds of space
            if (tmpNewPosition.X >= 0 && tmpNewPosition.X < space.GetLength(1) && tmpNewPosition.Y >= 0 && tmpNewPosition.Y < space.GetLength(0))
            {
                robot.p = tmpNewPosition;                
            }
            else { 

                if (tmpNewPosition.X < 0) tmpNewPosition.X = space.GetLength(1) + tmpNewPosition.X;

                else if (tmpNewPosition.X > space.GetLength(1)-1) tmpNewPosition.X = tmpNewPosition.X - (space.GetLength(1));

                if (tmpNewPosition.Y < 0) tmpNewPosition.Y = space.GetLength(0) + tmpNewPosition.Y;                

                else if (tmpNewPosition.Y > space.GetLength(0)-1) tmpNewPosition.Y = tmpNewPosition.Y - (space.GetLength(0));

                robot.p = tmpNewPosition;
            }

            space[robot.p.Y, robot.p.X] += 1;
        }

    }

    public class Robot 
    {
        public Point p { get; set; }
        public Point v { get; set; }
    }
}
