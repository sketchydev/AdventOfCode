using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static partial class Day18
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 18");

            int answer = 0;

            var cursor = new int[] { 0, 0 };

            var xMax = 0;
            var yMax = 0;

            var xMin = 0;
            var yMin = 0;

            var outline = new List<int[]>();

            foreach(string line in lines)
            {
                var input = line.Split(' ');

                var moveDistance = int.Parse(input[1]);

                switch (input[0])
                {
                    case "R":

                        for (int i = 1; i <= moveDistance; i++)
                        {
                            outline.Add([cursor[0] + i, cursor[1]]);
                        }

                        cursor[0] += moveDistance;
                        if (cursor[0] > xMax) xMax = cursor[0];
                        break;
                    case "D":

                        for (int i = 1; i <= moveDistance; i++)
                        {
                            outline.Add([cursor[0], cursor[1]+i]);
                        }

                        cursor[1] += moveDistance;
                        if (cursor[1] > yMax) yMax = cursor[1];
                        break;
                    case "L":

                        for (int i = 1; i <= moveDistance; i++)
                        {
                            outline.Add([cursor[0] - i, cursor[1]]);
                        }

                        cursor[0] -= moveDistance;
                        if (cursor[0] < xMin) xMin = cursor[0];
                        break;
                    case "U":
                        for (int i = 1; i <= moveDistance; i++)
                        {
                            outline.Add([cursor[0], cursor[1] - i]);
                        }
                        cursor[1] -= moveDistance;
                        if (cursor[1] < yMin) yMin = cursor[1];
                        break;
                }

            }


            // reset origin
            var xOffset = Math.Abs(0 - xMin);
            var yOffset = Math.Abs(0 - yMin);

            foreach (var line in outline)
            {
                line[0] += xOffset;
                line[1] += yOffset;
            }

            xMax += xOffset;
            yMax += yOffset;

            var grid = new List<string>();

            for(int i = 0;i <= yMax;i++)
            {
                grid.Add(new string('.', xMax + 1));
            }

            var gridArr = grid.ToArray();            
            
            foreach (var cooord in outline)
            {
                gridArr[cooord[1]] =  gridArr[cooord[1]].Remove(cooord[0],1).Insert(cooord[0], "#");
            }

            var sum = 0;
            //Visualise
            for(var j=0;j<gridArr.Length;j++)
            {                
                var isInside = false;

                for (int i = 0; i < gridArr[j].Length; i++)
                {
                    if (gridArr[j][i] == '.')
                    {
                        if (!isInside) continue;
                        gridArr[j] = gridArr[j].Remove(i, 1).Insert(i, "#");
                        continue;
                    };

                    if (gridArr[j][i] == '#')
                    { 
                        if(i+1 < gridArr[j].Length && gridArr[j][i+1] !='#') isInside = !isInside;                                            
                    }
                }
                sum += Regex.Matches(gridArr[j], "#").Count;
                Console.WriteLine(gridArr[j]);
            }

            answer = sum;

            




            Console.WriteLine("answer: " + answer);
        }


    }
}
