using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day14
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 14");

            long answer = 0;

            lines.Reverse();

            var rocksArr = lines.ToArray();
            
            var didMove = true;

            while (didMove)
            {
                didMove = false;
                for (int i = 0; i < rocksArr.Length - 1; i++)
                {
                    for (int j = 0; j < rocksArr[i].Length - 1; j++)
                    {
                        //if row below == . then swap
                        if (rocksArr[i][j + 1] == '.')
                        {
                            rocksArr[i].Remove(j);
                            rocksArr[i].Insert(j, ".");
                            rocksArr[i + 1].Remove(j);
                            rocksArr[i + 1].Insert(j, "O");
                            didMove = true;
                        }
                        //if row below == # then don't move and break
                        if (rocksArr[i][j + 1] == '#')
                        {
                            break;
                        }
                        //if row below == O then do nothing
                    }
                }
                //checking
                var tmp = new List<string>(rocksArr);

                tmp.Reverse();

                foreach (var ln in tmp)
                {
                    Console.WriteLine(ln);
                }

                //end checking
            }





            Console.WriteLine("answer: " + answer);
        }
    }
}
