using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day13
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 13");

            int answer = 0;
            

            var pattern = new List<string>();

            foreach (string line in lines)
            {
                
                if (!string.IsNullOrEmpty(line))
                {
                    pattern.Add(line);
                }
                else {
                    
                    var patArr = pattern.ToArray();

                    var isVert = false;
                    var isHorz = false;

                    //look for Horizontal mirror

                    for (var i = 0; i < patArr.Length - 1; i++)
                    {
                        if (patArr[i] != patArr[i + 1]) continue;

                        var mirrorLimit = Math.Min(patArr.Length-(i+1),i);

                        for (var j = 1;  j <= mirrorLimit; j++) {
                            if (patArr[i - j] == patArr[i + j]) continue;


                        }
                    }




                        if (!isHorz)
                    {
                        //look for Vertical
                        
                    }




                    pattern = new List<string>();
                }

            }

            Console.WriteLine("answer: " + answer);
        }
    }
}
