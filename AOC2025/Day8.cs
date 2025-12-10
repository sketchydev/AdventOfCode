using System.Numerics;

namespace _AdventOfCode.AOC2025
{
    public static class Day8
    {
        public static void Run(List<string> lines)
        {
            //Test input
            //lines = [
            //    "162,817,812",
            //    "57,618,57",
            //    "906,360,560",
            //    "592,479,940",
            //    "352,342,300",
            //    "466,668,158",
            //    "542,29,236",
            //    "431,825,988",
            //    "739,650,466",
            //    "52,470,668",
            //    "216,146,977",
            //    "819,987,18",
            //    "117,168,530",
            //    "805,96,715",
            //    "346,949,466",
            //    "970,615,88",
            //    "941,993,340",
            //    "862,61,35",
            //    "984,92,344",
            //    "425,690,689"];

            long part1 = 0; long part2 = 0;

            //convert to list of vector3

            var circuitBoxVectors = new List<Vector3>();

            foreach (var line in lines)
            {
                var parts = line.Split(',').Select(x => long.Parse(x)).ToArray();
                circuitBoxVectors.Add(new Vector3(parts[0], parts[1], parts[2]));
            }

            var distancePairs = new List<Tuple<Vector3,Vector3,float>>();

            for (int i = 0; i < circuitBoxVectors.Count-1; i++)
            {
                for (int j = i + 1; j < circuitBoxVectors.Count; j++)
                {
                    var dist = Vector3.DistanceSquared(circuitBoxVectors[i], circuitBoxVectors[j]);
                    distancePairs.Add(new Tuple<Vector3, Vector3, float>(circuitBoxVectors[i], circuitBoxVectors[j], dist));
                }
            }

            var circuits = new List<HashSet<Vector3>>();


            //part1
            //sort by closest pairs
            distancePairs.Sort((a, b) => a.Item3.CompareTo(b.Item3));

            //for (int i = 0; i < 1000; i++)
            for (int i = 0; i < 10; i++)
            {
                var pair = distancePairs[i];
                Console.WriteLine($"Distance squared between {pair.Item1} and {pair.Item2} is {pair.Item3}");

                //first pass, just add the closest pair
                if (circuits.Count == 0)
                {
                    circuits.Add([pair.Item1, pair.Item2]);
                    continue;
                }
                var circuitAdded = false;
                foreach (var circuit in circuits)
                {                    
                    if (circuit.Contains(pair.Item1))
                    {
                        circuit.Add(pair.Item2);
                        circuitAdded = true;
                        break;
                    }
                    if (circuit.Contains(pair.Item2))
                    {
                        circuit.Add(pair.Item1);
                        circuitAdded = true;
                        break;
                    }                                        
                }
                if (!circuitAdded) circuits.Add([pair.Item1, pair.Item2]);                
            }

            //consolidate circuits that share points

            var merged = false;
            do
            {
                merged = false;
                for (int i = 0; i < circuits.Count - 1; i++)
                {
                    for (int j = i + 1; j < circuits.Count; j++)
                    {
                        if (circuits[i].Overlaps(circuits[j]))
                        {
                            circuits[i].UnionWith(circuits[j]);
                            circuits.RemoveAt(j);
                            merged = true;
                            break;
                        }
                    }
                    if (merged) break;
                }
            } while (merged);

            circuits = circuits.OrderByDescending(x=>x.Count).ToList();
            part1 = circuits[0].Count * circuits[1].Count * circuits[2].Count;

            //Part1 answer
            Console.WriteLine($"Part 1: {part1}"); //122430            

            //part2
            circuits = [];            
            
            Console.WriteLine($"Distance Pairs count: {distancePairs.Count}");
            var found = false;
            for (int i = 0; i < distancePairs.Count; i++)
            {                
                var pair = distancePairs[i];
                //Console.WriteLine($"Distance squared between {pair.Item1} and {pair.Item2} is {pair.Item3}");

                //first pass, just add the first pair
                if (circuits.Count == 0)
                {
                    circuits.Add([pair.Item1, pair.Item2]);
                    continue;
                }
                var circuitAdded = false;
                foreach (var circuit in circuits)
                {
                    if (circuit.Contains(pair.Item1))
                    {
                        circuit.Add(pair.Item2);
                        circuitAdded = true;
                        break;
                    }
                    if (circuit.Contains(pair.Item2))
                    {
                        circuit.Add(pair.Item1);
                        circuitAdded = true;
                        break;
                    }
                }
                if (!circuitAdded) circuits.Add([pair.Item1, pair.Item2]);


                //consolidate circuits that share points

                merged = false;
                do
                {
                    merged = false;
                    for (int j = 0; j < circuits.Count - 1; j++)
                    {
                        for (int k = j + 1; k < circuits.Count; k++)
                        {
                            if (circuits[j].Overlaps(circuits[k]))
                            {
                                circuits[j].UnionWith(circuits[k]);
                                circuits.RemoveAt(k);
                                merged = true;
                                break;
                            }
                        }
                        if (merged) break;
                    }
                } while (merged);

                foreach (var circuit in circuits)
                {
                    if (circuit.Count == lines.Count)
                    {
                        part2 = (long)distancePairs[i].Item1.X * (long)distancePairs[i].Item2.X;
                        found = true;
                    }
                }
                if (found) break;
            }
            Console.WriteLine($"Part 2: {part2}"); //8135565324

        }

    }
}
