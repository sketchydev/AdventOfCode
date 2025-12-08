using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2025
{
    public static class Day5
    {
        public static void Run(List<string> lines)
        {
            var part1 = 0; long part2 = 0;


            //Test input
            //lines = ["3-5", "10-14","16-20","12-18","","1","5","8","11","17","32"];
            //lines = ["1-10", "4-8", "3-5","","1"];

            //min-max pairs
            var ranges = new List<Tuple<long,long>>();
            var ingredients = new List<long>();

            
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                if (line.Contains('-'))
                {
                    var split = line.Split('-');
                    var min = long.Parse(split[0]);
                    var max = long.Parse(split[1]);
                    ranges.Add(new Tuple<long, long>(min, max));
                }
                else
                {
                    ingredients.Add(long.Parse(line));
                }
            }

            //part 1
            //foreach (var ingredient in ingredients)
            //{
            //    foreach (var range in ranges)
            //    {
            //        if (ingredient >= range.Item1 && ingredient <= range.Item2)
            //        {
            //            Console.WriteLine($" Ingredient {ingredient} is in range {range.Item1}-{range.Item2}");
            //            part1++;
            //            break;
            //        }
            //    }
            //}

            //part 2

            //sort ranges                                                
            Tuple<long,long>[] rangeArray = [.. ranges.OrderBy(r => r.Item1)]; ;

            var merged = false;
            do
            {
                merged = false;
                var newValues = new List<Tuple<long, long>>();
                for (int i = 0; i < rangeArray.Length-1; i++)
                {
                    //next item is wholly after this one
                    if (rangeArray[i].Item2 < rangeArray[i + 1].Item1) 
                    { 
                        newValues.Add(rangeArray[i]);                        
                        continue; 
                    }

                    //next item is wholly contained within this one
                    if (rangeArray[i].Item1 <= rangeArray[i + 1].Item1 && rangeArray[i].Item2 >= rangeArray[i + 1].Item2)
                    {
                        Console.WriteLine($" skipping contained range: {rangeArray[i + 1].Item1}-{rangeArray[i + 1].Item2} within {rangeArray[i].Item1}-{rangeArray[i].Item2}");
                        merged = true;
                        continue;
                    }

                    //next item overlaps this one
                    if (rangeArray[i].Item2 >= rangeArray[i + 1].Item1)
                    {
                        Console.WriteLine($" Merging overlapping ranges: {rangeArray[i].Item1}-{rangeArray[i].Item2} and {rangeArray[i + 1].Item1}-{rangeArray[i + 1].Item2}");
                        merged = true;
                        var newRange = new Tuple<long, long>(rangeArray[i].Item1, rangeArray[i + 1].Item2);
                        newValues.Add(newRange);
                        continue;
                    }
                }
                if(merged) rangeArray = [.. newValues];

            } while (merged ==true);

            

            foreach (var range in rangeArray)
            {                 
                part2 += range.Item2 - range.Item1 + 1;
                Console.WriteLine($" Merged Range: {range.Item1}-{range.Item2} - sum of diff: {part2}");
            }
            






            //Part1 answer
            Console.WriteLine($" Part 1: {part1}"); // 735 


            //Part2 answer                       
            Console.WriteLine($" Part 2: {part2}");
            //206557553282766 - low
            //316105981563145 - low
            //329880555143914 - low
            //344306344403172 - correct
            //344306344403181 - high
            //344306344403185 - high
            //344306344403186 - high
            //344306344403188 - high
            //432822044824879 - high            



        }


    }
}
