namespace _AdventOfCode.AOC2023
{
    public static class Day1
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 1");

            int answer = 0;

            var numberstrings = new Dictionary<string, int> { { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 } };

            foreach (var value in lines)
            {

                //key = index, value = value; sorted list puts the keys in order
                var numberIndexes = new SortedList<int, int>();

                //indexes of numbers
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        numberIndexes.Add(i, int.Parse(value[i].ToString()));
                    }
                }

                //indexes of words (starting letter)
                for (int i = 3; i < 6; i++)
                {
                    for (int j = 0; j < value.Length - (i - 1); j++)
                    {
                        var window = value.Substring(j, i);
                        if (numberstrings.ContainsKey(window))
                        {
                            numberIndexes.Add(j, numberstrings[window]);
                        }
                    }
                }

                answer += int.Parse(numberIndexes.First().Value.ToString() + numberIndexes.Last().Value.ToString());

            }

            Console.WriteLine("answer: " + answer);
        }
    }
}
