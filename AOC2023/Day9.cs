using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day9
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            long answer = 0;
            var difs = new List<long>();

            var theirDifs = new List<long>();

            foreach (string line in lines)
            {
                var mine = Mine(line);
                difs.Add(mine);
            }

            ////
            var weights = new Dictionary<int, int[]>();
            weights.Add(6, [-1, 6, -15, 20, -15, 6]);
            weights.Add(21, [1, -21, 210, -1330, 5985, -20349, 54264, -116280, 203490, -293930, 352716, -352716, 293930, -203490, 116280, -54264, 20349, -5985, 1330, -210, 21]);            
            long sumRight = 0;
            long sumLeft = 0;
            foreach (string line in lines)
            {
                long extrapolatedValueRight = 0;
                long extrapolatedValueLeft = 0;
                string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long[] nums = Array.ConvertAll(numbers, long.Parse);
                for (var i = 0; i < nums.Length; i++)
                {
                    extrapolatedValueRight += nums[i] * weights[nums.Length][i];
                    extrapolatedValueLeft += nums[i] * weights[nums.Length][nums.Length - 1 - i];
                }

                theirDifs.Add(extrapolatedValueRight);

                sumRight += extrapolatedValueRight;
                sumLeft += extrapolatedValueLeft;
            }
            ////

            var myDifsArr = difs.ToArray();
            var theirDifsArr = theirDifs.ToArray();

            for (int i = 0; i < myDifsArr.Length; i++)
            {
                
                if (theirDifsArr[i] != myDifsArr[i])
                {
                    Console.WriteLine($"Line:{i+1} -Mine/Theirs[{myDifsArr[i]}]:[{theirDifsArr[i]}]");
                }
            }           








            ///
            /// DONE  but with 3rd party solution
            ///





            foreach (var dif in difs)
            {
                answer += dif;
            }
          

            Console.WriteLine("My answer: " + answer);
            Console.WriteLine($"Their answers: {sumRight}, {sumLeft}");
        }

        public static long Mine(string line)
        {
            // match first digit as game number                
            var seq = line.Split(' ').Select(n => long.Parse(n)).ToList();


            var expandedList = new List<List<long>> { { seq } };

            var testList = expandedList.First();

            var isDone = false;
            while (!isDone)
            {
                var listArr = testList.ToArray();
                var newSeq = new List<long>();
                for (var i = 0; i < listArr.Length - 1; i++)
                {
                    newSeq.Add(Math.Abs(listArr[i + 1] - listArr[i]));
                    //newSeq.Add(listArr[i + 1] - listArr[i]);
                }



                if (!newSeq.Any()) newSeq = [0];

                expandedList.Add(newSeq);
                testList = expandedList.Last();
                if (newSeq.Distinct().Count() == 1) isDone = true;

            }

            expandedList.Reverse();

            long nextVal = 0;
            foreach (var sublist in expandedList)
            {

                if (sublist.Last() < 0)
                    nextVal = sublist.Last() - nextVal;
                else
                    nextVal = sublist.Last() + nextVal;
            }


            //wrong - 1865490357
            //wrong - 1850388125
            //wrong - 1850388125
            //wrong - 1844456611
            //wrong - 1883037613
            //wrong - 1857321411
            return nextVal;

        }
        
    }
}
