using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml;

namespace _AdventOfCode.AOC2023
{
    public static class Day24
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 24");

            long answer = 0;

            var hailStones = new List<Hailstone>();

            var xLower = 200000000000000;
            var xUpper = 400000000000000;
            
            var yLower = 200000000000000;
            var yUpper = 400000000000000;

            var intersectCount = 0;

            foreach (string line in lines)
            {
                var nums = Regex.Matches(line, @"-?\d+").Cast<Match>().Select(x=> long.Parse(x.Value)).ToArray();

                var hs = new Hailstone { Position = new(nums[0], nums[1]), Direction = new(nums[3], nums[4])};                                

                hailStones.Add(hs);

            }

            var hailstonesArr = hailStones.ToArray();

            for(int i = 0; i < hailstonesArr.Length; i++)
            {
                var a = hailstonesArr[i];

                for (int j = i + 1; j < hailstonesArr.Length - 2; j++)
                {

                    var b = hailstonesArr[j];

                    
                    if(!Intersects(a,b)) continue;

                    var intersect = GetPointOfIntersection(a,b);

                    if (intersect.X > xLower && intersect.X < xUpper && intersect.Y > yLower && intersect.Y < yUpper) intersectCount++;                    

                }

            }

            Console.WriteLine("answer: " + answer);
        }

        public static bool Intersects(Hailstone hs1, Hailstone hs2)
        {
            float u = (hs1.Position.Y * hs2.Direction.X + hs2.Direction.Y * hs2.Position.X - hs2.Position.Y * hs2.Direction.X - hs2.Direction.Y * hs1.Position.X) / (hs1.Direction.X * hs2.Direction.Y - hs1.Direction.Y * hs2.Direction.X);
            float v = (hs1.Position.X + hs1.Direction.X * u - hs2.Position.X) / hs2.Direction.X;

            return u > 0 && v > 0;

        }

        public static Vector2 GetPointOfIntersection(Hailstone hs1, Hailstone hs2)
        {
            var p1End = hs1.Position + hs1.Direction; // another point in line p1->n1
            var p2End = hs2.Position + hs2.Direction; // another point in line p2->n2

            double m1 = (p1End.Y - hs1.Position.Y) / (p1End.X - hs1.Position.X); // slope of line p1->n1
            double m2 = (p2End.Y - hs2.Position.Y) / (p2End.X - hs2.Position.X); // slope of line p2->n2

            double b1 = hs1.Position.Y - m1 * hs1.Position.X; // y-intercept of line p1->n1
            double b2 = hs2.Position.Y - m2 * hs2.Position.X; // y-intercept of line p2->n2

            double px = (b2 - b1) / (m1 - m2); // collision x
            double py = m1 * px + b1; // collision y



            return new Vector2((float)px, (float)py); // return statement
        }

    }
    public class Hailstone
    {
        public Vector2 Position { get; set; }        
        public Vector2 Direction { get; set; }      

    }
}
