using System.Drawing;

namespace _AdventOfCode.AOC2025
{
    public static class Day9
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = [
            //    "7,1",
            //    "11,1",
            //    "11,7",
            //    "9,7",
            //    "9,5",
            //    "2,5",
            //    "2,3",
            //    "7,3"];

            long part1 = 0; long part2 = 0;

            //part1
            var redPoints = lines.ToList().Select(x=> new Point(int.Parse(x.Split(',')[0]), int.Parse(x.Split(',')[1]))).ToArray();

            //can only create rectangles from points that do not share x or y coordinates

            var rectangleAreas = new List<Tuple<Point,Point,long>>();
            

            for (int i = 0; i < redPoints.Length; i++)
            {
                for (int j = i + 1; j < redPoints.Length; j++)
                {
                        long xDist = Math.Abs(redPoints[i].X - redPoints[j].X)+1;
                        long yDist = Math.Abs(redPoints[i].Y - redPoints[j].Y)+1;

                    rectangleAreas.Add(new (redPoints[i], redPoints[j],Math.Abs(xDist * yDist)));
                   //     Console.WriteLine($"Rectangle formed by points {points[i]} and {points[j]} has area {xDist * yDist}");                    
                }
            }

            part1 = rectangleAreas.Select(x=>x.Item3).Max();

            //Part1 answer
            Console.WriteLine($"Part 1: {part1}");  //4765757080                                                    

            //part2
            //rectangle areas are all still valid, but we need to find the largest which is wholly enclosed by the red/green loop

            //map out all points within red green loop
            var allPointsInLoop = new HashSet<Point>();

            Point current;
            Point next;

            for (int i = 0; i < redPoints.Length-1; i++)
            {
                current = redPoints[i];
                next = redPoints[(i + 1)];
                allPointsInLoop.Add(current);
                while (current != next)
                {
                    if (current.X < next.X) current.X++;
                    else if (current.X > next.X) current.X--;
                    else if (current.Y < next.Y) current.Y++;
                    else if (current.Y > next.Y) current.Y--;
                    allPointsInLoop.Add(new Point(current.X, current.Y));
                }                
            }
            //join last to first
            current = redPoints[redPoints.Length-1];
            next = redPoints[0];            
            while (current != next)
            {
                if (current.X < next.X) current.X++;
                else if (current.X > next.X) current.X--;
                else if (current.Y < next.Y) current.Y++;
                else if (current.Y > next.Y) current.Y--;
                allPointsInLoop.Add(new Point(current.X, current.Y));
            }

            var allPointsInLoopArray = allPointsInLoop.ToArray();
            Console.WriteLine($"Total points in loop: {allPointsInLoopArray.Length}");

            //sort rectangles to make this a bit easier
            var sortedRectangles = rectangleAreas.OrderByDescending(x => x.Item3).ToList();

            Console.WriteLine($"Total rectangles to check: {sortedRectangles.Count}");

            foreach (var rectangle in sortedRectangles)
            {
                Console.WriteLine($"Checking rectangle formed by points {rectangle.Item1} and {rectangle.Item2}");
                bool allPointsInside = true;
                var perimeterPoints = CoreFunctions.GetPerimeterPoints(rectangle.Item1, rectangle.Item2);
                Console.WriteLine($"Perimeter points count: {perimeterPoints.Count()}");
                var count = 1;
                foreach (var point in perimeterPoints)
                {
                    
                    Console.Write("\r" + $"{count}".PadRight(Console.WindowWidth - 1));
                    if (!CoreFunctions.IsPointInPolygon(allPointsInLoopArray, point) && !allPointsInLoop.Contains(point))
                    {
                        allPointsInside = false;
                        break;
                    }
                    count++;
                }
                if (allPointsInside)
                {
                    part2 = rectangle.Item3;
                    break;
                }
            }


            //Part2 answer

            Console.WriteLine($"Part 2: {part2}");
            // 4624346420 - too high


        }

    }
}
