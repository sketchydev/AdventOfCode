using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day19
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 19");

            long answer = 0;

            var lineArr = lines.ToArray();

            var workflowsRaw = new List<string>();
            var partsRaw = new List<string>();

            var isRule = true;

            foreach (var line in lineArr)
            {
                if (line == "")
                {
                    isRule = false;
                    continue;
                }

                if (isRule) workflowsRaw.Add(line);
                else partsRaw.Add(line);
            }

            var parts = ParseParts(partsRaw);
            var workflows = ParseWorkflows(workflowsRaw);

            foreach (var part in parts) {
                answer += ApplyWorkflow(part, workflows);
            }


            Console.WriteLine("answer: " + answer);
        }

        public static long ApplyWorkflow(int[] part, Dictionary<string, string> workflows)
        {
            var currentWF = workflows["in"];
            var currentRules = currentWF.Split(',');
            var currentApp = currentRules[0];

            var counter = 0;

            while (currentApp != "A" && currentApp != "R")
            {

                //apply logic
                // x=0,m=1,a=2,s=3
                while (currentApp.Contains('>') || currentApp.Contains('<'))
                {
                    var left = 0;
                    var right = int.Parse(Regex.Match(currentApp, @"\d+").Value);

                    //determine left value
                    switch (currentApp[0])
                    {
                        case 'x':
                            left = part[0];
                            break;
                        case 'm':
                            left = part[1];
                            break;
                        case 'a':
                            left = part[2];
                            break;
                        case 's':
                            left = part[3];
                            break;
                    }


                    switch (currentApp[1])
                    {
                        case '>':

                            if (left > right)
                            {
                                currentApp = currentApp.Split(':')[1];
                            }
                            else
                            {
                                counter++;
                                currentApp = currentRules[counter];
                            }

                            break;
                        case '<':

                            if (left < right)
                            {
                                currentApp = currentApp.Split(':')[1];
                            }
                            else
                            {
                                counter++;
                                currentApp = currentRules[counter];
                            }

                            break;
                    }
                }

                //change workflow

                if (currentApp != "A" && currentApp != "R")
                { 
                    counter = 0;
                    currentWF = workflows[currentApp];
                    currentRules = currentWF.Split(',');
                    currentApp = currentRules[counter];
                }

            }





            if (currentApp == "R") return 0;

            return part[0] + part[1] + part[2] + part[3];

        }

        public static List<int[]> ParseParts(List<string> rawParts)
        { 
            var retVal = new List<int[]>();
            foreach (var rpt in rawParts)
            {
                var matches = Regex.Matches(rpt,@"\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();

                retVal.Add([matches[0], matches[1], matches[2], matches[3]]);                
            }
            return retVal;
        }

        public static Dictionary<string, string> ParseWorkflows(List<string> rawWorkflows)
        { 
            var retval = new Dictionary<string, string>();

            foreach (var rwf in rawWorkflows)
            { 
                var name = rwf.Split('{')[0];

                var workflow = rwf.Substring(rwf.IndexOf('{')+1, rwf.Length - rwf.IndexOf('{') - 2);

                retval.Add(name, workflow);
            }

            return retval;

        }

        public class Part
        { 
            public int x { get; set; }
            public int m { get; set; }
            public int a { get; set; }
            public int s { get; set; }
        }
    }
}
