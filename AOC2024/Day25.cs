namespace _AdventOfCode.AOC2024
{
    public static class Day25
    {
        public static void Run(List<string> lines)
        {
            var keys = new List<int[]>();
            var locks = new List<int[]>();
            var schematics = new List<List<string>>();

            var isKey = false;
            
            var schematic = new List<string>();

            //Take batches of 7 lines

            var count = 0;

            foreach (var line in lines)
            {
                count++;
                
                if (count == 8)
                {
                    schematics.Add(schematic);
                    schematic = new List<string>();
                    count = 0;
                    continue;
                }
                schematic.Add(line);
            }

            foreach (var item in schematics)
            {
                if (item[0]=="#####")
                {
                    isKey = false;
                }
                else
                {
                    isKey = true;
                }

                var keylock = new int[5];

                for (int i = 1; i < 6; i++)
                {
                 var row = item[i];
                    for (int j = 0; j < 5; j++)
                    {
                        if (row[j] == '#')
                        {
                            keylock[j] += 1;
                        }
                    }
                }

                if (isKey)
                {
                    keys.Add(keylock);
                }
                else
                {
                    locks.Add(keylock);
                }

            }

            Console.WriteLine("Keys:");
            
            foreach (var key in keys)
            {
                Console.Write($"{key[0]},{key[1]},{key[2]},{key[3]},{key[4]}");
                Console.WriteLine();
            }
            
            Console.WriteLine("Locks");
            foreach (var l in locks)
            {
                Console.Write($"{l[0]},{l[1]},{l[2]},{l[3]},{l[4]}");
                Console.WriteLine();
            }

            var part1Answer = 0;
            foreach (var l in locks)
            {
                
                foreach (var k in keys)
                {
                    Console.Write($"Trying: Lock[{string.Join(",", l)}], Key[{string.Join(",", k)}]");
                    var match = true;

                    for (int i = 0; i < 5; i++)
                    {
                        if (k[i] + l[i] > 5)
                        {
                            Console.Write($": NO MATCH");
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        Console.Write($": MATCH");
                        part1Answer++;
                    }
                    Console.WriteLine();
                }
                
            }

            Console.WriteLine($"Part 1: {part1Answer}");    



        }
    }
}
