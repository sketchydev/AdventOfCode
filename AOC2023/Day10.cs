using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day10
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 10");

            string answer = "";

            var linesArr = lines.ToArray();

            var linesArrCopy = lines.Select(x => x.ToCharArray()).ToArray();

            var sRow = 0;
            var sCol = 0;

            var validMoves = new Dictionary<char, string>
            {
                { '|', "NS" },
                { '-', "EW" },
                { 'L', "NE" },
                { 'J', "NW" },
                { '7', "SW" },
                { 'F', "SE" }                
            };

            for (var i = 0; i < linesArr.Length; i++)
            {
                if (linesArr[i].Contains('S'))
                {
                    sRow = i;
                    sCol = linesArr[i].IndexOf('S');
                }
            }


            
            char currentStep ='S';

            var startValidMoves = "";

            if (sRow>0 && "|7F".Contains(linesArr[sRow - 1][sCol])) 
                startValidMoves = startValidMoves + "N";
            if (sCol< linesArr[0].Length -1 && "-7J".Contains(linesArr[sRow][sCol+1])) 
                startValidMoves = startValidMoves + "E";
            if (sRow < linesArr.Length -1 && "|JL".Contains(linesArr[sRow + 1][sCol])) 
                startValidMoves = startValidMoves + "S";
            if (sCol > 0 && "-FL".Contains(linesArr[sRow][sCol-1])) 
                startValidMoves = startValidMoves + "W";




            validMoves.Add('S',startValidMoves);

            linesArrCopy[sCol][sRow] = '$';



            var stepCounter = 0;
            char previousLoc = 'X';

            var canMoveNorth = false;
            var canMoveSouth = false;
            var canMoveWest = false;
            var canMoveEast = false;

            var isTopLimit = false;
            var isBottomLimit = false;
            var isLeftLimit = false; 
            var isRightLimit = false;

            do
            {                
                isTopLimit = sRow == 0;
                isBottomLimit = sRow == linesArr.Length - 1;
                isLeftLimit = sCol == 0;
                isRightLimit = sCol == linesArr[0].Length - 1;

                canMoveNorth = !isTopLimit && previousLoc != 'N' && validMoves[currentStep].Contains('N');
                canMoveEast = !isRightLimit && previousLoc != 'E' && validMoves[currentStep].Contains('E');
                canMoveSouth = !isBottomLimit && previousLoc != 'S' && validMoves[currentStep].Contains('S');
                canMoveWest = !isLeftLimit && previousLoc != 'W' && validMoves[currentStep].Contains('W');


                //Move North
                if (canMoveNorth)
                {
                    sRow--;
                    previousLoc = 'S';
                }
                //Move East
                else if (canMoveEast)
                {
                    sCol++;
                    previousLoc = 'W';

                }
                //Move South
                else if (canMoveSouth)
                {
                    sRow++;
                    previousLoc = 'N';
                }
                //Move West
                else if (canMoveWest)
                {
                    sCol--;
                    previousLoc = 'E';
                }

                currentStep = linesArr[sRow][sCol];
                linesArrCopy[sCol][sRow] = '$';
                stepCounter++;
            } while (currentStep != 'S');

            


            answer = Math.Ceiling(new decimal(stepCounter / 2)).ToString();

            // Part 2

            foreach (var ca in linesArrCopy)
            {
                for (var i = 0; i < ca.Length; i++)
                {
                    if (ca[i] != '$') ca[i] = '.';
                }
                Console.WriteLine(ca);
            }






            Console.WriteLine("answer: " + answer);
        }        
        
    }
}
