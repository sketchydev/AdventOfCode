namespace _AdventOfCode.AOC2024
{
    public static class Day7
    {
        public static void Run(List<string> lines)
        {
            var problems = new Dictionary<long, long[]>();
            foreach (var line in lines)
            {
                var split1 = line.Split(':');

                var split2 = split1[1].Trim().Split(' ').Select(long.Parse).ToArray();

                problems.Add(long.Parse(split1[0]),split2);

            }

            long answer = 0; 

            //part 1

            foreach (var problem in problems)
            {
                var results = new List<int>();

                long[] restItems = problem.Value[1..];

                if (Iterate(problem.Value[0], restItems, problem.Key))
                {
                    answer += problem.Key;
                }

            }

            Console.WriteLine("Part 1: " + answer);


        }

        public static bool Iterate(long left, long[] right, long target)
        {
            var calculation_one = left + right[0];
            var calculation_two = left * right[0];

            if (right.Length > 1) //keep going
            {
                var restItems = right[1..];

                var result_one = Iterate(calculation_one, restItems, target);
                var result_two = Iterate(calculation_two, restItems, target);
                
                if (result_one || result_two)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else 
            {
                if (calculation_one == target || calculation_two == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
}
