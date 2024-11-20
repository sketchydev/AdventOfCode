using System.Text.RegularExpressions;

namespace _AdventOfCode.AOC2023
{
    public static class Day21
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 21");

            long answer = 0;

            var lineArr = lines.ToArray();

            var origin = new int[2];

            for (var i = 0; i < lineArr.Length; i++)
            {
                if (lineArr[i].Contains('S'))
                {                    
                    origin[0] = lineArr[i].IndexOf('S');
                    origin[1] = i;
                    break;
                }
            }

            var nodeQueue = new Queue<int[]>();
            nodeQueue.Enqueue(origin);

            for (var i = 0;i <= 6; i++) {

                var nextNodes = new List<int[]>();

                while (nodeQueue.Count > 0)
                {
                    var node = nodeQueue.Dequeue();
                    var added = false;

                    var val = lineArr[node[1]][node[0]];
                    if (i == 6 && val == '.') lineArr[node[1]] = lineArr[node[1]].Remove(node[0], 1).Insert(node[0], "O");
                    //left
                    if (node[0] > 0)
                    {
                        val = lineArr[node[1]][node[0] - 1];
                        if (val != '#') nextNodes.Add([node[1], node[0] - 1]);
                    }

                    //right
                    if (node[0] < lineArr[0].Length - 2)
                    {
                        val = lineArr[node[1]][node[0] + 1];
                        if (val != '#') nextNodes.Add([node[1], node[0] + 1]);
                    }

                    //up
                    if (node[1] > 0)
                    {
                        val = lineArr[node[1] - 1][node[0]];
                        if (val != '#') nextNodes.Add([node[1] - 1, node[0]]);
                    }

                    //down
                    if (node[1] < lineArr.Length - 2)
                    {
                        val = lineArr[node[1] + 1][node[0]];
                        if (val != '#') nextNodes.Add([node[1] + 1, node[0]]);
                    }
                }


                foreach (var node in nextNodes)
                {
                    nodeQueue.Enqueue(node);
                }            
            }



            

            foreach (var line in lineArr) {
                Console.WriteLine(line);
                foreach (var ch in line) {
                    if (ch == 'O') answer++;
                }
            }


            Console.WriteLine("answer: " + answer);
        }

        public static void ProcessNodes(Node<int[]> node, string[] lineArr, long limit, long count)
        {
            if (count != limit)
            {
                count++;
                var val = lineArr[node.Value[1]][node.Value[0]];
                if (val == '.') lineArr[node.Value[1]] = lineArr[node.Value[1]].Remove(node.Value[0], 1).Insert(node.Value[0], "O");      
                //left
                if (node.Value[0] > 0)
                {
                    val = lineArr[node.Value[1]][node.Value[0] - 1];
                    if (val != '#') node.Subnodes.Add(new Node<int[]>([node.Value[1], node.Value[0] - 1]));
                }

                //right
                if (node.Value[0] < lineArr[0].Length -2)
                {
                    val = lineArr[node.Value[1]][node.Value[0] + 1];
                    if (val != '#') node.Subnodes.Add(new Node<int[]>([node.Value[1], node.Value[0] + 1]));
                }

                //up
                if (node.Value[1] > 0)
                {
                    val = lineArr[node.Value[1]-1][node.Value[0]];
                    if (val != '#') node.Subnodes.Add(new Node<int[]>([node.Value[1]-1, node.Value[0]]));
                }

                //down
                if (node.Value[1] < lineArr.Length-2)
                {
                    val = lineArr[node.Value[1] + 1][node.Value[0]];
                    if (val != '#') node.Subnodes.Add(new Node<int[]>([node.Value[1] + 1, node.Value[0]]));
                }

                foreach (var nd in node.Subnodes)
                {
                    ProcessNodes(nd, lineArr, limit, count);
                }
            }

        }
    }
}
