namespace _AdventOfCode.AOC2024
{
    public static class Day5
    {
        public static void Run(List<string> lines)
        {
            var answer = 0;
            var rules = new List<string>();
            var dataset = new List<string>();
            var writeRules = true;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] == "")
                {
                    writeRules = false;
                    continue;
                }
                if (writeRules)
                {
                    rules.Add(lines[i]);
                }
                else
                {
                    dataset.Add(lines[i]);
                }
            }

            //Part1

            var consolidatedRules = new Dictionary<int, List<int>>();

            foreach (var rule in rules)
            {
                var splitrules = rule.Split("|");

                var page = int.Parse(splitrules[0]);
                var beforePage = int.Parse(splitrules[1]);

                if (consolidatedRules.ContainsKey(page))
                {
                    var newRules = consolidatedRules[page];
                    newRules.Add(beforePage);
                    consolidatedRules[page] = newRules;
                }
                else
                {
                    consolidatedRules.Add(int.Parse(splitrules[0]), [beforePage]);
                }
            }

            foreach (var rule in consolidatedRules)
            {
                Console.WriteLine($"{rule.Key} -> {string.Join(",", rule.Value)}");
            }

            var incorrectPages = new List<int[]>();

            foreach (var pagelist in dataset)
            {
                var pages = pagelist.Split(",").Select(int.Parse).ToArray();

                var isValid = true;

                foreach (var page in pages)
                {   
                    //if no rules, skip
                    if (!consolidatedRules.ContainsKey(page))
                    {
                        continue;
                    }

                    var indexOfPageInDataSet = Array.IndexOf(pages, page);

                    var order = consolidatedRules[page];

                    foreach (var orderpage in order)
                    {
                        var orderpageInDatasetIndex = Array.IndexOf(pages, orderpage);

                        if (orderpageInDatasetIndex > -1 && orderpageInDatasetIndex < indexOfPageInDataSet)
                        {                            
                            isValid = false;
                            break;
                        }
                    }
                    if (!isValid) break;
                }

                if (isValid)
                {
                    int midpointIndex = pages.Length / 2;
                    answer += pages[midpointIndex];
                }
                else { 
                    incorrectPages.Add(pages);
                }
            }

            Console.WriteLine($"Part 1: {answer}");

            //Part 2
            answer = 0;                        

            foreach (var pagelist in incorrectPages)
            {
                bool isValid;
                do {
                    isValid = true;
                    Console.WriteLine($"Checking {string.Join(",", pagelist)}");
                    foreach (var page in pagelist)
                    {
                        //if no rules, skip
                        if (!consolidatedRules.ContainsKey(page))
                        {
                            continue;
                        }

                        var indexOfPageInDataSet = Array.IndexOf(pagelist, page);

                        var order = consolidatedRules[page];

                        foreach (var orderpage in order)
                        {
                            var orderpageInDatasetIndex = Array.IndexOf(pagelist, orderpage);

                            if (orderpageInDatasetIndex > -1 && orderpageInDatasetIndex < indexOfPageInDataSet)
                            {
                                isValid = false;
                                //swap the pages

                                var tmpA = pagelist[indexOfPageInDataSet];
                                var tmpB = pagelist[orderpageInDatasetIndex];

                                pagelist[indexOfPageInDataSet] = tmpB;
                                pagelist[orderpageInDatasetIndex] = tmpA;

                                break;
                            }
                        }
                        if (!isValid) break;
                    }
                } while (!isValid);
                int midpointIndex = pagelist.Length / 2;
                    answer += pagelist[midpointIndex];
            }
            Console.WriteLine($"Part 2: {answer}");
        }
    }
}
