namespace _AdventOfCode.AOC2024
{
    public class Day2
    {
        public static void Run(List<string> lines)
        {
            //Part 1    
            var countSafe = 0;

            var unsafeParts = new List<string>();

            foreach (string line in lines)
            {
                var parts = line.Split(' ').Select(int.Parse).ToArray();

                var isSafe = SafetyCheck(parts);

                if (isSafe) countSafe++;
                else unsafeParts.Add(line);

            }

            
            Console.WriteLine($"Part 1: {countSafe}");

            //Part 2
            foreach (var line in unsafeParts)
            {
                var parts = line.Split(' ').Select(int.Parse).ToArray();

                var lclCountSafe = 0;
                for (int i = 0; i < parts.Length; i++)
                {
                    var newParts = CoreFunctions.RemoveAt(parts, i);
                    if (SafetyCheck(newParts))
                    {
                        lclCountSafe++;
                        break;
                    }
                }
                if(lclCountSafe == 1) countSafe++;
            }

            Console.WriteLine($"Part 2: {countSafe}");
        }

        public static bool SafetyCheck(int[] parts)
        {
            var isDescending = false;
            var isAscending = false;
            var notSafe = false;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i] > parts[i + 1])
                {
                    isDescending = true;
                }
                else if (parts[i] < parts[i + 1])
                {
                    isAscending = true;
                }
                if (isAscending && isDescending)
                {
                    notSafe = true;
                    break;
                }
                var diff = Math.Abs(parts[i] - parts[i + 1]);
                if (diff < 1 || diff > 3)
                {
                    notSafe = true;
                    break;
                }
            }
            return !notSafe;
        }
    }
}

