namespace _AdventOfCode.AOC2025
{
    public static class Day7
    {
        public static void Run(List<string> lines)
        {
            //Test input
            lines = [".......S.......",
                     "...............",
                     ".......^.......",
                     "...............",
                     "......^.^......",
                     "...............",
                     ".....^.^.^.....",
                     "...............",
                     "....^.^...^....",
                     "...............",
                     "...^.^...^.^...",
                     "...............",
                     "..^...^.....^..",
                     "...............",
                     ".^.^.^.^.^...^.",
                     "..............."];

            var part1 = 0; var part2=1;

            string[] part2Lines = lines.ToArray();

            var beamPositions = new List<int>()
            {
                //find the first beam
                lines[0].IndexOf('S')
            };

            //part1

            for (int i = 1; i < lines.Count; i++)
            {
                var splits = 0;
                if (!lines[i].Contains('^'))
                {
                    //no splitter on this line so just add the beams
                    foreach (var beam in beamPositions)
                    {
                        lines[i] = lines[i].Remove(beam, 1).Insert(beam, "|");
                    }
                    continue;
                }

                var splitterPositions = new List<int>();
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '^') splitterPositions.Add(j);
                }

                var tmpNewBeamPositions = new List<int>();
                tmpNewBeamPositions.AddRange(beamPositions);
                foreach (var beam in beamPositions)
                {                    
                    if (splitterPositions.Contains(beam))
                    {
                        //split the beam
                        lines[i] = lines[i].Remove(beam+1, 1).Insert(beam+1, "|").Remove(beam - 1, 1).Insert(beam - 1, "|");
                        tmpNewBeamPositions.Remove(beam);
                        tmpNewBeamPositions.Add(beam - 1);
                        tmpNewBeamPositions.Add(beam + 1);
                        splits++;
                    }
                    else
                    {
                        //just continue the beam
                        lines[i] = lines[i].Remove(beam, 1).Insert(beam, "|");
                    }
                }
                beamPositions = tmpNewBeamPositions.Distinct().ToList();


                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                part1 += splits;
                part2 *= splits;
                Console.WriteLine($"Splits:[{splits}]");    
            }

            //Part1 answer
            Console.WriteLine($"Part 1: {part1}"); //1590

            //part2lines

            //pre-order B-Tree traversal to find the number of unique paths

            //starting position
            var rootNode = new Tuple<int, int>(0, lines[0].IndexOf('S'));

            //remove ... rows to simplify the tree

            var part2linesTrimmed = new List<string>();

            for (int i = 0; i < part2Lines.Length; i++)
            {
                if (part2Lines[i].Contains('^'))
                {
                    part2linesTrimmed.Add(part2Lines[i]);
                }
            }

            var part2linesArray = part2linesTrimmed.ToArray();

            //don't forget, there's always 2 paths on the final row
            var splitterNodes = new List<Tuple<int,int>>();
            for (int i = 0; i < part2linesArray.Length; i++)
            {
                for (int j = 0; j < part2linesArray[i].Length; j++)
                {
                    if (part2linesArray[i][j] == '^')
                    {
                        splitterNodes.Add(new Tuple<int, int>(i+1, j));
                    }
                }
            }



            var tree = new BinaryTree();





            //Part2 answer

            Console.WriteLine($"Part 2: {part2}");            


        }

    }

    public class Node
    {
        public Tuple<int, int> Data;
        public Node? Left;
        public Node? Right;

        public Node(Tuple<int, int> data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public Node? Root;

        // 1. Pre-Order: Root -> Left -> Right
        // Useful for: Copying a tree
        public void PreOrder(Node? node)
        {
            if (node == null) return;

            Console.Write(node.Data + " "); // Process Root
            PreOrder(node.Left);            // Go Left
            PreOrder(node.Right);           // Go Right
        }

        // 2. In-Order: Left -> Root -> Right
        // Useful for: Getting sorted data (if it's a BST)
        public void InOrder(Node? node)
        {
            if (node == null) return;

            InOrder(node.Left);             // Go Left
            Console.Write(node.Data + " "); // Process Root
            InOrder(node.Right);            // Go Right
        }

        // 3. Post-Order: Left -> Right -> Root
        // Useful for: Deleting a tree (delete children before parent)
        public void PostOrder(Node? node)
        {
            if (node == null) return;

            PostOrder(node.Left);           // Go Left
            PostOrder(node.Right);          // Go Right
            Console.Write(node.Data + " "); // Process Root
        }
    }
}
