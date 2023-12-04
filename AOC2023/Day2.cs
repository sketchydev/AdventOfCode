using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day2
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            int answer = 0;

            foreach(string line in lines)
            {
                // match first digit as game number
                var gameNo = Regex.Match(line, "(\\d)");

                var draws = line.Split(':')[1];

                var drawlist = draws.Split(";");

                var redMax = 0;
                var blueMax = 0;
                var greenMax = 0;


                foreach( var draw in drawlist) {

                    var split = draw.Trim().Split(',');
                    
                    foreach( var draw2 in split) {
                        var split2 = draw2.Trim().Split(" ");

                        switch (split2[1])
                        {
                            case "blue":
                                var blueCount = int.Parse(split2[0]);
                                if (blueCount > blueMax) blueMax = blueCount;
                                break;
                            case "red":
                                var redCount = int.Parse(split2[0]);
                                if (redCount > redMax) redMax = redCount;
                                break;
                            case "green":
                                var greenCount = int.Parse(split2[0]);
                                if (greenCount > greenMax) greenMax = greenCount;
                                break;
                            default:
                                break;
                        }
                    }
                }

                var power = redMax * blueMax * greenMax;

                answer += power;

            }

            Console.WriteLine("answer: " + answer);
        }
    }
}
