using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public class Day4
    {
        public CardTest[] OriginalCardsArr;
        public int Answer = 0;

        public void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 2");

            int answer = 0;

            var CardsList = new List<CardTest>();

            for (int i = 0; i < lines.Count; i++)
            {
                var split1 = lines[i].Split(':');


                var split2 = split1[1].Split('|');
                var myNumbers = Regex.Matches(split2[0], @"\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToList();
                var testNumbers = Regex.Matches(split2[1], @"\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToList();

                CardsList.Add(new()
                {
                    CardNumber = i + 1,
                    MyNumbers = myNumbers,
                    TestNumbers = testNumbers
                });
            }

            OriginalCardsArr = [.. CardsList];

            ProcessCards(CardsList);

            Console.WriteLine("answer: " + Answer);
        }

        public void ProcessCards(List<CardTest> cards)
        {
            if (cards.Count > 0)
            {
                var newList = new List<CardTest>();
                foreach (var card in cards)
                {
                    Answer++;
                    int matches = 0;

                    foreach (var num in card.MyNumbers)
                    {
                        if (card.TestNumbers.Contains(num)) matches++;
                    }

                    for (int i = 0; i < matches; i++)
                    {
                        var cardToAdd = card.CardNumber + i;
                        newList.Add(OriginalCardsArr[cardToAdd]);
                    }

                }

                ProcessCards(newList);
            }
        }



        public class CardTest
        { 
            public int CardNumber { get; set; }
            public List<int> MyNumbers { get; set; }
            public List<int> TestNumbers { get; set; }
        }

    }
}
