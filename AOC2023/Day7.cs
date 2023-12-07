using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day7
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            var cardScores = new Dictionary<char, int> {
                {'A', 14 },
                {'K', 13 },
                {'Q', 12 },
                {'J', 1 },
                {'T', 10 },
                {'9', 9 },
                {'8', 8 },
                {'7', 7 },
                {'6', 6 },
                {'5', 5 },
                {'4', 4 },
                {'3', 3 },
                {'2', 2 },
            };

            int answer = 0;

            var hands = new List<Hand>();

            foreach (string line in lines)
            {                
                var split = line.Split(' ');
                var hand = new Hand
                {
                    Cards = split[0],
                    Bid = int.Parse(split[1]),
                    
                };
                Console.WriteLine($"Hand:[{hand.Cards}]");

                var intArr = new int[hand.Cards.Length];
                for (int i = 0; i < hand.Cards.Length; i++) {
                    if (char.IsDigit(hand.Cards[i]))
                    {
                        intArr[i] = int.Parse(hand.Cards[i].ToString());
                    }
                    else {
                        intArr[i] = cardScores[hand.Cards[i]];
                    }
                }
                hand.CardsIntArr = intArr;

                if (!hand.Cards.Contains('J'))
                {
                    hand.HandScore = BaseScore(split[0]);
                }
                else
                {
                    //Try all combinations to get the best score

                    var bestscore = 0;

                    var startingCombinations = new List<string> {hand.Cards };

                    var combinations = GetCombinations(startingCombinations, cardScores);

                                        

                    foreach (var combo in combinations)
                    {
                        var score = BaseScore(combo);
                        if(score>bestscore) bestscore = score;
                    }



                    hand.HandScore = bestscore;
                }



                hands.Add(hand);
            }

            var handsArr = hands.ToArray();

            var sortedResult = handsArr
                .OrderBy(h => h.HandScore)
                .ThenBy(h => h.CardsIntArr[0])
                .ThenBy(h => h.CardsIntArr[1])
                .ThenBy(h => h.CardsIntArr[2])
                .ThenBy(h => h.CardsIntArr[3])
                .ThenBy(h => h.CardsIntArr[4])
                .ToArray();


            for (var k = 0; k < sortedResult.Length; k++)
            {
                Console.WriteLine($"[{sortedResult[k].HandScore}] | [{sortedResult[k].Cards}] | [{sortedResult[k].CardsIntArr}]");
                answer += (k + 1) * sortedResult[k].Bid;
            }
            // Part 1: 253910319
            // Part 2: 254083736

            Console.WriteLine("answer: " + answer);
        }

        public static List<string> GetCombinations(List<string> combos, Dictionary<char,int> scores)
        {
            var outputList = new List<string>();            

            foreach (var c in combos)
            {
                var firstJ = c.IndexOf('J');
                if (firstJ != -1)
                {
                    outputList.Add(c);
                    var newList = new List<string>();

                    foreach (var j in scores.Keys)
                    {
                        if (j != 'J') { 
                            var tmp = c.Remove(firstJ, 1).Insert(3, j.ToString());
                            newList.Add(tmp);
                        }
                    }

                    outputList.AddRange(GetCombinations(newList, scores));
                }
                else outputList.Add(c);
            }
            return outputList;

        }

        public static int BaseScore(string hand)
        {
            if (isFiveOfAKind(hand)) return 7;
            if (isFourOfAKind(hand)) return 6;
            if (isFullHouse(hand)) return 5;
            if (isThreeOfAKind(hand)) return 4;
            if (isTwoPair(hand)) return 3;
            if (isOnePair(hand)) return 2;
            else return 1;
        }

        public static bool isFiveOfAKind(string hand)
        {
            if (hand[0] != hand[1]) return false;
            if (hand[1] != hand[2]) return false;
            if (hand[2] != hand[3]) return false;
            if (hand[3] != hand[4]) return false;
            return true;
        }

        public static bool isFourOfAKind(string hand)
        {
            for(var i=0; i<2; i++)
            { 
                var matches = Regex.Matches(hand, $"[{hand[i]}]").Count();
                if (matches == 4) return true;
            }
            return false;
        }

        public static bool isFullHouse(string hand)
        {
            for (var i = 0; i < 3; i++)
            {                
                var matches = Regex.Matches(hand, $"[{hand[i]}]").Count();
                if (matches == 3) {
                    var others = Regex.Matches(hand, $"[^{hand[i]}]").Cast<Match>().Select(m=>m.Value).ToArray();
                    if (others[0] == others[1])
                        return true;
                };
            }
            return false;

        }

        public static bool isThreeOfAKind(string hand)
        {
            for (var i = 0; i < 3; i++)
            {
                var matches = Regex.Matches(hand, $"[{hand[i]}]").Count();
                if (matches == 3) return true;
            }
            return false;
        }

        public static bool isTwoPair(string hand)
        {
            foreach (var c in hand)
            {
                var matches = Regex.Matches(hand, $"[{c}]").Count();
                if (matches == 2)
                {
                    var others = Regex.Matches(hand, $"[^{c}]").Cast<Match>().Select(m => m.Value).ToArray();
                    foreach (var ch in others)
                    {
                        var othermatches = Regex.Matches(hand, $"[{ch}]").Count();
                        if (othermatches == 2) return true;
                    }
                };
            }
            return false;
        }

        public static bool isOnePair(string hand)
        {
            foreach (var c in hand)
            {
                var matches = Regex.Matches(hand, $"[{c}]").Count();
                if (matches == 2) return true;
            }
            return false;
        }        
    }

    public class Hand {
        public string Cards { get; set; }
        public int[] CardsIntArr { get; set; }
        public int Bid { get; set; }
        public int HandScore { get; set; }
    }
}
