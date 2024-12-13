namespace _AdventOfCode.AOC2024
{
    public static class Day9
    {
        public static void Run(List<string> lines)
        {
            var startingval = lines[0];

            var numbers = startingval.ToCharArray().Select(c => long.Parse(c.ToString())).ToArray();

            var isFile = true;
            var fileId = 0;
            long spaceCount = 0;

            long part1Answer = 0;

            var initialState = string.Empty;

            foreach (var number in numbers) ///we start with a file
            {
                var joined = string.Empty;
                if (isFile)
                {
                    for (int i = 0; i < number; i++)
                    {                        
                        joined += fileId.ToString();
                    }

                    fileId++;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {                        
                        joined += ".";
                    }
                    spaceCount += number;
                }                

                isFile = !isFile;
                initialState += joined;
            }

            //Console.WriteLine(initialState);
            
            //Part 1

            var part1List = new LinkedList<string>();
            foreach (var c in initialState)
            {
                part1List.AddLast(c.ToString());
            }

            var currentNode = part1List.Last;

            var swappedNodes = new List<string>{"."};

            while (currentNode != part1List.First)
            {
                if (currentNode.Value !=".")
                {
                    //find first "." and replace with current value
                    var swapnode = part1List.Find(".");
                    swapnode.Value = currentNode.Value;
                    currentNode.Value = ".";                    
                    swappedNodes.Add(swapnode.Value);
                }
                currentNode = currentNode.Previous;
                //foreach (var c in part1List)
                //{
                //    Console.Write(c);
                //}
                //Console.WriteLine();

                var checkNode = part1List.Find(".");

                while (checkNode.Next != null && checkNode.Next.Value == ".")
                {
                    checkNode = checkNode.Next;
                }

                if (checkNode.Next == null) break;                

            }
            foreach (var c in part1List)
            {
                Console.Write(c);
            }
            Console.WriteLine();

            var posCounter = 0;

            foreach (var c in part1List)
            {
                if (c != ".")
                {
                    part1Answer += (long.Parse(c) * posCounter);                    
                }
                posCounter++;
            }
            Console.WriteLine($"Part 1: {part1Answer}"); // wrong 89425419840
                                                         // right 6307275788409


        }

    }

}
