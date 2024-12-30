namespace _AdventOfCode.AOC2024
{
    public static class Day24
    {
        public static void Run(List<string> lines)
        {
            SortedDictionary<string, bool> wires = new SortedDictionary<string, bool>();

            var isStartingState = true;

            var operationQueue = new Queue<string>();   

            foreach (var line in lines)
            {
                if (line == "")
                {
                    isStartingState = false;
                    continue;
                }

                if (isStartingState)
                {
                    var parts = line.Split(" ");
                    wires.Add(parts[0].Replace(':', ' ').Trim(), Convert.ToBoolean(int.Parse(parts[1].Trim())));
                }
                else
                {
                    operationQueue.Enqueue(line);
                }                
            }


            while(operationQueue.Count > 0)
            {
                var line = operationQueue.Dequeue();

                var parts = line.Split(" ");

                var operand1 = parts[0];
                var operand2 = parts[2];
                var operation = parts[1];
                var target = parts[4];

                //if one of the operands is missing, re-queue the operation
                if (!wires.ContainsKey(operand1) || !wires.ContainsKey(operand2))
                {
                    operationQueue.Enqueue(line);
                }
                else
                {
                    if (!wires.ContainsKey(target)) wires.Add(target, false);

                    if (operation == "AND")
                    {
                        wires[target] = wires[operand1] && wires[operand2];
                    }
                    else if (operation == "OR")
                    {
                        wires[target] = wires[operand1] || wires[operand2];
                    }
                    else if (operation == "XOR")
                    {
                        wires[target] = wires[operand1] ^ wires[operand2];
                    }
                }
            }


            var answerString = string.Empty;

            foreach (var kvp in wires)
            {
                Console.WriteLine($"{kvp.Key}: {Convert.ToInt32(kvp.Value)}");

                if (kvp.Key.StartsWith('z')) answerString += $"{Convert.ToInt32(kvp.Value)}";
            }
            var ansArr = answerString.ToCharArray();
            Array.Reverse(ansArr);
            answerString = new string(ansArr);
            Console.WriteLine($"Raw AnswerString: {answerString}");
            Console.WriteLine($"Part1: {Convert.ToInt64(answerString, 2)}");

        }

    }
}

