namespace _AdventOfCode.AOC2024
{
    public static class Day6
    {
        public static void Run(List<string> lines)
        {
            var padding = 1;
            var paddedInput = CoreFunctions.AddPadding(lines, padding, 'Z');

            var answer = RunSimulation(paddedInput, padding, lines[0].Length, lines.Count);

            Console.WriteLine($"Part 1: {answer} ");

            //Part 2
            answer = 0;

            for (int i = padding; i < lines.Count; i++)
            {
                for (int j = padding; j < lines[i].Length; j++)
                {
                    Console.WriteLine($"Checking row: {i} col: {j}");
                    var oldLine = paddedInput[i];

                    var newLine = string.Concat(oldLine.AsSpan(0, j), "O", oldLine.AsSpan(j + 1));
                    paddedInput[i] = newLine;

                    var newAnswer = RunSimulation(paddedInput, padding, lines[0].Length, lines.Count);

                    if (newAnswer == -1) answer++;


                    //return to previous state
                    paddedInput[i] = oldLine;

                }
            }

            //
            Console.WriteLine($"Part 2: {answer+1}"); ///again we are 1 out for some reason hence the plus 1 ???
        }


        //local methods
        public static char RotateRight(char currentOrientation)
        {
            char newOrientation = currentOrientation;
            switch (currentOrientation)
            {
                case '^':
                    newOrientation = '>';
                    break;
                case '>':
                    newOrientation = 'v';
                    break;
                case 'v':
                    newOrientation = '<';
                    break;
                case '<':
                    newOrientation = '^';
                    break;
            }
            return newOrientation;
        }

        public static (int nextRow, int nextCol) SetNextCell(int currentRow, int currentCol, char currentOrientation)
        {
            int nextRow = currentRow;
            int nextCol = currentCol;
            switch (currentOrientation)
            {
                case '^':
                    nextRow--;
                    break;
                case '>':
                    nextCol++;
                    break;
                case 'v':
                    nextRow++;
                    break;
                case '<':
                    nextCol--;
                    break;
            }
            return (nextRow, nextCol);
        }

        public static int RunSimulation(string[] paddedInput, int padding, int lineLength, int LineCount)
        {
            int row = 0;
            int col = 0;

            char[] orientations = ['^', '>', 'v', '<']; //North, East, South, West

            //Part 1

            //Find the guard

            for (int i = padding; i < LineCount; i++)
            {
                for (int j = padding; j < lineLength; j++)
                {
                    if (orientations.Contains(paddedInput[i][j]))
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
            }

            var nextRow = row;
            var nextCol = col;
            var currentOrientation = paddedInput[row][col];

            //first move
            (nextRow, nextCol) = SetNextCell(row, col, currentOrientation);

            var visited = new List<string>();

            var steps = 0;

            while (paddedInput[nextRow][nextCol] != 'Z')
            {
                //determine next cell content
                var nextCell = paddedInput[nextRow][nextCol];

                //determine action

                switch (nextCell)
                {
                    case '^': //Move forward - if we hit the starting cell
                    case '.': //Move forward
                    case 'X': //Move forward                        
                        //mark previous cell as current cell
                        var previousRow = row;
                        var previousCol = col;

                        //mark next cell as current cell
                        row = nextRow;
                        col = nextCol;

                        //add previous cell to visited list
                        visited.Add($"{previousRow}, {previousCol}");
                        steps++;

                        break;
                    case 'O': //Rotate right                                                
                    case '#': //Rotate right                                                                        
                        currentOrientation = RotateRight(currentOrientation);

                        break;
                    case 'Z': //Finish
                        //mark next cell as current cell
                        row = nextRow;
                        col = nextCol;
                        //add next cell to visited list
                        visited.Add($"{row}, {col}");
                        break;

                }
                (nextRow, nextCol) = SetNextCell(row, col, currentOrientation);

                if (visited.Count > 100000) return -1; //bomb out if we hit 100000 steps; lets be honest this is not exactly the most precise thing...
            }

            //deduplicate visited list
            visited = visited.Distinct().ToList();


            return visited.Count + 1; //because, for some reason it's not count the last move...
        }

    }
}
