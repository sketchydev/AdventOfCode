namespace _AdventOfCode.AOC2024
{
    public static class Day9
    {
        public static void Run(List<string> lines)
        {

            var startingval = lines[0];

            var numbers = startingval.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();

            var isFile = true;
            var fileId = 0;
            var spaceCount = 0;
            long answer = 0;

            var blockValues = new List<string>();

            foreach (var number in numbers) ///we start with a file
            {
                if (isFile)
                {
                    for (int i = 0; i < number; i++)
                    {
                        blockValues.Add(fileId.ToString());

                    }

                    fileId++;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        blockValues.Add(".");
                    }
                    spaceCount += number;
                }

                isFile = !isFile;
            }

            var blockValuesArray = blockValues.ToArray();

            var swapCounter = 0;

            var countdown = blockValuesArray.Length - 1;
            for (int i = 0; i < blockValuesArray.Length; i++)
            {
                if (blockValuesArray[i] == ".")
                {
                    while (blockValuesArray[countdown] == ".")
                    {
                        countdown--;
                    }
                    blockValuesArray[i] = blockValuesArray[countdown];
                    blockValuesArray[countdown] = ".";
                    swapCounter++;
                }

                if (i == blockValuesArray.Length - 1 - spaceCount)
                {
                    break;
                }
            }

            for (int i = 0; i < blockValuesArray.Length; i++)
            {
                if (blockValuesArray[i] != ".") answer += long.Parse(blockValuesArray[i]) * i;
                Console.Write(blockValuesArray[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Part 1: {answer}"); //6307275788409 CORRECT!!


            // Part 2


        }
    }
}
