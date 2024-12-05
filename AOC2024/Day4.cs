namespace _AdventOfCode.AOC2024
{
    public class Day4
    {
        public static void Run(List<string> lines)
        {            
            var xmasCount = 0;
            var padding = 4;
            var linelength = lines[0].Length;
            var dotLine = new string('.', linelength);
            var paddedLines = new List<string>();
            for ( var i = 0; i < padding; i++) paddedLines.Add(dotLine);
            paddedLines.AddRange(lines);
            for (var i = 0; i < padding; i++) paddedLines.Add(dotLine);            
            var linesArr = paddedLines.ToArray();           
            for (int i = 0; i < paddedLines.Count; i++) linesArr[i] = new string('.', padding) + paddedLines[i] + new string('.', padding);            
            foreach (var line in linesArr) Console.WriteLine(line);
            for (int i = padding; i < linesArr.Length-padding; i++)
            {
                for (var j = padding; j < linesArr[i].Length-padding; j++)
                {
                    if (linesArr[i][j] == 'X')
                    {
                        if (linesArr[i][j + 1] == 'M' && linesArr[i][j + 2] == 'A' && linesArr[i][j + 3] == 'S') xmasCount++; //forward
                        if (linesArr[i][j - 1] == 'M' && linesArr[i][j - 2] == 'A' && linesArr[i][j - 3] == 'S') xmasCount++; //backward
                        if (linesArr[i - 1][j] == 'M' && linesArr[i - 2][j] == 'A' && linesArr[i - 3][j] == 'S') xmasCount++; //upward
                        if (linesArr[i + 1][j] == 'M' && linesArr[i + 2][j] == 'A' && linesArr[i + 3][j] == 'S') xmasCount++; ; //downward
                        if (linesArr[i - 1][j + 1] == 'M' && linesArr[i - 2][j + 2] == 'A' && linesArr[i - 3][j + 3] == 'S') xmasCount++;  //upward-forward
                        if (linesArr[i - 1][j - 1] == 'M' && linesArr[i - 2][j - 2] == 'A' && linesArr[i - 3][j - 3] == 'S') xmasCount++; //upward-backaward
                        if (linesArr[i + 1][j + 1] == 'M' && linesArr[i + 2][j + 2] == 'A' && linesArr[i + 3][j + 3] == 'S') xmasCount++; //downward-forward
                        if (linesArr[i + 1][j - 1] == 'M' && linesArr[i + 2][j - 2] == 'A' && linesArr[i + 3][j - 3] == 'S') xmasCount++; //downward-backward                      
                    }
                }
            }
            Console.WriteLine($"Part 1: {xmasCount}");
            //Part 2
            xmasCount = 0;
            for (int i = padding; i < linesArr.Length - padding; i++)
            {
                for (var j = padding; j < linesArr[i].Length - padding; j++)
                {
                    if (linesArr[i][j] == 'A')
                    {
                        var masCount = 0;
                        if (linesArr[i - 1][j + 1] == 'M' && linesArr[i + 1][j - 1] == 'S') masCount++ ;  //upward-forward
                        if (linesArr[i - 1][j - 1] == 'M' && linesArr[i + 1][j + 1] == 'S') masCount++ ;  //upward-backaward
                        if (linesArr[i + 1][j + 1] == 'M' && linesArr[i - 1][j - 1] == 'S') masCount++ ; //downward-forward
                        if (linesArr[i + 1][j - 1] == 'M' && linesArr[i - 1][j + 1] == 'S') masCount++ ; //downward-backward                      
                        if(masCount ==2) xmasCount++;
                    }
                }
            }
            Console.WriteLine($"Part 2: {xmasCount}");
        }
    }
}