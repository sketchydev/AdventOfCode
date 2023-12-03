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
                var split1 = line.Split(':');
                var split2 = split1[0].split(' ');
                var gameNo = split2[1];

                var draws = split1[1].split(";");




            }

            

            Console.WriteLine("answer: " + answer);
        }
    }
}
