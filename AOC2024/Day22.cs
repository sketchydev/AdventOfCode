using System.Net.Sockets;

namespace _AdventOfCode.AOC2024
{
    public static class Day22
    {
        public static void Run(List<string> lines)
        {
            var iterations = 10;

            long answer = 0;

            var prices = new List<List<int>>();

            foreach (var line in lines)
            {
                var iterationPrices = new List<int>();

                var secret = long.Parse(line);
                var iterationPrice = (int)secret % 10;
                iterationPrices.Add(iterationPrice);

                for (int i = 0; i < iterations; i++)
                {
                    long step1 = secret * 64;  //secret * 64

                    long step2 = secret ^ step1; //mix - bitwise XOR the result of step1 with initial secret
                    long step3 = step2 % 16777216;  //prune - step 2 modulo 16777216
                    double step4 = Math.Floor(step3 / 32d); // divide by 32 and round down                
                    long step5 = step3 ^ (long)step4; // mix bitwise XOR the result of step 3 with the result of step 4
                    long step6 = step5 % 16777216; //prune - step 5 modulo 16777216
                    long step7 = step6 * 2048; //secret * 2048
                    long step8 = step6 ^ step7; //mix - bitwise XOR the result of step 7 with the result of step 6
                    long step9 = step8 % 16777216; //prune - step 8 modulo 16777216

                    secret = step9;

                    iterationPrice = (int)secret % 10;
                    iterationPrices.Add(iterationPrice);
                }
                prices.Add(iterationPrices);
                answer += secret;
                Console.WriteLine($"{line} : {secret}");
            }

            Console.WriteLine($"Part 1: [{answer}]");

            var changeSequences = new List<List<int>>();

            foreach (var priceSequence in prices)
            {
                var changeSequence = new List<int>();
                for (int i = 0; i < priceSequence.Count - 1; i++)
                {
                    var change = priceSequence[i + 1] - priceSequence[i];
                    changeSequence.Add(change);
                }
                changeSequences.Add(changeSequence);
            }

            //first index we are interested in is 4
            //

        }
    }
}
