using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day3
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            int answer = 0;            

            for (int i = 0; i < lines.Count; i++)
            {

                string preLine, postLine;

                if (i == 0)
                {
                    preLine = new string('.', lines[i].Length);
                }
                else
                { 
                    preLine = lines[i-1];
                }
                
                var testline = lines[i];
                
                if (i == lines.Count - 1 )
                {
                    postLine = new string('.', lines[i].Length);
                }
                else
                {
                    postLine = lines[i +1 ];
                }

                var matches = Regex.Matches(testline, @"\d+").Select(m => new KeyValuePair<int, int>(m.Index, int.Parse(m.Value))).ToArray();

                foreach (var match in matches)
                {

                    var startIndex = match.Key == 0 ? 0 : match.Key - 1;
                    //var endIndex = match.Key + match.Value.ToString().Length + 1 == testline.Length ? 1 : 2;
                    var endIndex = 2;
                    if (startIndex == 0) endIndex = 1;
                    if (match.Key + match.Value.ToString().Length == testline.Length) endIndex = 1;

                    var a = testline.Length;
                    var b = match.Key + match.Value.ToString().Length;

                    var prelineTest = preLine.Substring(startIndex, match.Value.ToString().Length + endIndex);
                    var testlineTest = testline.Substring(startIndex, match.Value.ToString().Length + endIndex);
                    var postlineTest = postLine.Substring(startIndex, match.Value.ToString().Length + endIndex);

                    var isIncluded = false;

                    if(Regex.Match(prelineTest, @"[^a-zA-Z\d.:]").Success) isIncluded = true;
                    if (Regex.Match(testlineTest, @"[^a-zA-Z\d.:]").Success) isIncluded = true;
                    if (Regex.Match(postlineTest, @"[^a-zA-Z\d.:]").Success) isIncluded = true;

                    if (isIncluded) answer += match.Value;
                    if (!isIncluded)
                    {
                        var ln = i;
                        var blah = "blah";
                    }
                }
            }

            Console.WriteLine("answer: " + answer);
        }
    }
}
