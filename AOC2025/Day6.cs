using System;

namespace _AdventOfCode.AOC2025
{
    public static class Day6
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = ["123 328  51 64 ", " 45 64  387 23 ", "  6 98  215 314", "*   +   *   +  "];

            long part1 = 0; long part2=0;

            //take the last line as the operators

            var operators = lines.Last().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();                        
            
            var numberlines = new List<int[]>();

            for (int i = 0; i < lines.Count - 1; i++)
            {                    
                numberlines.Add([.. lines[i].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x))]);
            }

            var numberColumns = new List<int[]>();  

            for (int i = 0; i < operators.Length; i++)
            {
                var localgroup = new int[numberlines.Count];
                for (int j = 0; j < numberlines.Count; j++)
                {
                    var x= numberlines[j][i];
                    localgroup[j] = x;
                }
                numberColumns.Add(localgroup);
            }

            //part 1

            for (int i = 0; i < operators.Length; i++)
            { 
                var op = operators[i];
                var numbers = numberColumns[i];
                var localresult = 0L;

                if (op == "*")
                {
                    localresult = 1;
                    foreach (var n in numbers)
                    {
                        localresult *= n;
                    }
                }
                else if (op == "+")
                {
                    localresult = 0;
                    foreach (var n in numbers)
                    {
                        localresult += n;
                    }
                }
                Console.WriteLine($"Operator {op} on numbers {string.Join(", ", numbers)} gives result {localresult}");
                part1 += localresult;
            }
            //Part1 answer
            Console.WriteLine($"Part 1: {part1}");

            //part2

            //replace all spaces with a full stop 
            for (int i = 0; i < lines.Count-1; i++)
            {
                lines[i] = lines[i].Replace(" ", ".");
            }

            //replace genuine spaces with commas
            for (int i = 0; i < lines[0].Length; i++)
            {
                var numfound = false;
                for (int j = 0; j < lines.Count-1; j++)
                {
                    if (lines[j][i] == '.') continue;
                    numfound = true;
                }
                if (!numfound)
                {
                    for (int j = 0; j < lines.Count - 1; j++)
                    {
                        lines[j] = lines[j].Remove(i, 1).Insert(i, ",");                        
                    }
                }

            }


            foreach (var numline in lines)
            {
                Console.WriteLine(numline);
            }

            var numberlinesStrings = new List<string[]>();

            for (int i = 0; i < lines.Count - 1; i++)
            {
                numberlinesStrings.AddRange([.. lines[i].Split(',')]);
            }

            var numberColumnStrings = new List<string[]>();

            for (int i = 0; i < operators.Length; i++)
            {
                var localgroup = new string[numberlinesStrings.Count];
                for (int j = 0; j < numberlinesStrings.Count; j++)
                {
                    var x = numberlinesStrings[j][i];
                    localgroup[j] = x;
                }
                numberColumnStrings.Add(localgroup);
            }




            for (int i = 0; i < operators.Length; i++)
            {
                var op = operators[i];
                var numberStrings = numberColumnStrings[i].ToArray();

                //pad the numbers with . at the end
                var maxLength = numberStrings.Max(x => x.Length);

                for (int j = 0; j < numberStrings.Length; j++)
                {
                    while (numberStrings[j].Length < maxLength)
                    {
                        numberStrings[j] +="." ;
                    }
                }
                var numbers = new List<int>();
                for (int k = maxLength - 1; k >= 0; k--) {
                    var numstring = "";
                    for (int l = 0; l < numberStrings.Length; l++)
                    {
                        if(numberStrings[l][k] != '.')
                        numstring += numberStrings[l][k];
                    }
                    numbers.Add(int.Parse(numstring));
                }

                Console.WriteLine("nums:");
                foreach (var num in numbers)
                {
                    Console.WriteLine(num);
                }

                    


                var localresult = 0L;

                if (op == "*")
                {
                    localresult = 1;
                    foreach (var n in numbers)
                    {
                        localresult *= n;
                    }
                }
                else if (op == "+")
                {
                    localresult = 0;
                    foreach (var n in numbers)
                    {
                        localresult += n;
                    }
                }
                Console.WriteLine($"Operator {op} on numbers {string.Join(", ", numbers)} gives result {localresult}");
                part2 += localresult;
            }



            //Part2 answer

            Console.WriteLine($"Part 2: {part2}");       //10153315705125     


        }

    }
}
