namespace _AdventOfCode.AOC2024
{
    public static class Day1
    {

        public static void Run(List<string> lines)
        {
            
            var colA = new List<int>();
            var colB = new List<int>();

            foreach (var line in lines)
            {
                var split = line.Split(" ");
                colA.Add(int.Parse(split[0]));
                colB.Add(int.Parse(split[3]));
            }

            
            var arrA = colA.ToArray();
            Array.Sort(arrA);
            var arrB = colB.ToArray();
            Array.Sort(arrB);

            int sumDistances = 0;

            for (int i = 0; i < arrA.Length; i++)
            {
                sumDistances += Math.Abs(arrB[i] - arrA[i]);
            }


            //Part1
            Console.WriteLine($"Part 1: {sumDistances}");

            var similarityScore = 0;

            foreach (var number in colA)
            {
                var count = colB.Count(x => x == number);
                var score = count * number;

                similarityScore += score;
            }

            //Part2
            Console.WriteLine($"Part 2: {similarityScore}");


        }
    }
}
