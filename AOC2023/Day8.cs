using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day8
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 8");

            long answer = 0;

            var instructionSet = lines[0];

            var nodes = new Dictionary<string, string[]>();

            var subsCount = new Dictionary<char, int>();

            for (var ch = 'A'; ch <= 'Z'; ch++)
            { 
                subsCount.Add(ch, 1);
            }


            for (int i = 2; i < lines.Count; i++)
            {
                var matches = Regex.Matches(lines[i], @"[\w]{3}").Cast<Match>().Select(m => m.Value).ToArray();
               
                nodes.Add(matches[0], [matches[1], matches[2]]);
                
            }            



            var nodeKeys = nodes.Keys.Where(k => k[2] == 'A').ToList();

            var multiples = new List<long>();
            
            

            foreach (var key in nodeKeys)
            {
                var count = 0;
                var currentNodeKey= key;
                var found = false;
                while (!found)
                {
                    for (int i = 0; i < instructionSet.Length; i++)
                    {                        
                        if (currentNodeKey[2] == 'Z')
                        {
                            found = true;
                            break;
                            
                        }

                        var ins = instructionSet[i];                        
                            if (ins == 'L') currentNodeKey = nodes[currentNodeKey][0];
                            if (ins == 'R') currentNodeKey = nodes[currentNodeKey][1];
                        
                        count++;
                    }
                }
                multiples.Add(count);
                Console.WriteLine(count);

            }

            answer = new LCM(multiples).getLCM();

            Console.WriteLine();
            Console.WriteLine("answer: " + answer);
        }
    }
}
