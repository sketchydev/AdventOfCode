namespace _AdventOfCode.AOC2025
{
    public static class Day1
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = ["L68","L30","R48","L5","R60","L55","L1","L99","R14","L82"];

            int current = 1000050;
            int exactZeros = 0;            
            int zeroClicks = 0;

            var sum = 0;
           

            foreach (var line in lines)
            {
                int previous = current;
                var turn = line[0];
                var distance = int.Parse(line[1..]);

                sum += distance;

                if (turn == 'L')
                {
                    current -= distance;
                    
                }
                else if (turn == 'R')
                {
                    current += distance;
                }
                if (current % 100 == 0) exactZeros++;

                var currentHundreds = current / 100;
                var previousHundreds = previous / 100;
                var diff = Math.Abs(currentHundreds - previousHundreds);

                zeroClicks += diff;
                //if (diff > 0 && previous % 100 == 0) diff -= 1;

                Console.WriteLine($"Turn: {turn} Previous: {previous} Distance: {distance} Current: {current} Diff:{diff} - ExactZeros: {exactZeros} ZeroClicks: {zeroClicks}");

            }

            //brute force
            current = 50;            
            int bruteForceClicks = 0;

            foreach (var line in lines)
            {                
                var turn = line[0];
                var distance = int.Parse(line[1..]);

                sum += distance;

                if (turn == 'L')
                {                    

                    for (var i = 0; i < distance; i++)
                    {
                        current -= 1;
                        if(current% 100 == 0)                         {
                            bruteForceClicks++;
                        }
                    }


                }
                else if (turn == 'R')
                {
                    for (var i = 0; i < distance; i++)
                    {
                        current += 1;
                        if (current % 100 == 0)
                        {
                            bruteForceClicks++;
                        }
                    }
                }               
            }



            Console.WriteLine($"Sum:{sum}");

            //Part1 answer
            Console.WriteLine($"(1071) Part 1: {exactZeros}");


            //Part2 answer
            
            Console.WriteLine($"Part 2: {zeroClicks}");
            Console.WriteLine($"(6700) Part 2: {bruteForceClicks}");


        }

    }
}
