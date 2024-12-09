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

            long answer1 = 0;
            long answer2 = 0;

            //part 1

            foreach (var problem in problems)
            {
                var results = new List<int>();

                long[] restItems = problem.Value[1..];

                if (IteratePart1(problem.Value[0], restItems, problem.Key))
                {
                    answer1 += problem.Key;
                }

                if (IteratePart2(problem.Value[0], restItems, problem.Key))
                {
                    answer2 += problem.Key;
                }

            }

            Console.WriteLine("Part 1: " + answer1);
            Console.WriteLine("Part 2: " + answer2);


        }

        public static bool IteratePart1(long left, long[] right, long target)
        {
            var calculation_one = left + right[0];
            var calculation_two = left * right[0];

            if (right.Length > 1) //keep going
            {
                var restItems = right[1..];

                var result_one = IteratePart1(calculation_one, restItems, target);
                var result_two = IteratePart1(calculation_two, restItems, target);
                
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

        public static bool IteratePart2(long left, long[] right, long target)
        {
            var calculation_one = left + right[0];
            var calculation_two = left * right[0];
            var calculation_three = long.Parse(left.ToString() + right[0].ToString());
            

            if (right.Length > 1) //keep going
            {
                var restItems = right[1..];

                var result_one = IteratePart2(calculation_one, restItems, target);
                var result_two = IteratePart2(calculation_two, restItems, target);
                var result_three = IteratePart2(calculation_three, restItems, target);

                if (result_one || result_two || result_three)
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
                if (calculation_one == target || calculation_two == target || calculation_three == target)
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
