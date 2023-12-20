using System.Drawing;

namespace _AdventOfCode.AOC2023
{
    public static class Day16
    {
        public static void Run(List<string> lines)
        {
            Console.WriteLine("AOC 2023 Day 16");

            int answer = 0;



            var linesArr = lines.ToArray();

            var XLim = linesArr[0].Length - 1;
            var YLim = linesArr.Length - 1;

            var beams = new Queue<Beam>();

            beams.Enqueue(
                new()
                {
                    Direction = "E",
                    Location = new Point(0, 0),
                    StartPoint = new Point(0, 0),
                });            

            var energisedPoints = new List<Point>();            
            
            while (beams.Count > 0)
            {

                //remove beams:
                //ResolveAction

                var newBeams = new List<Beam>();

                var currentBeam = beams.Dequeue();
                

                while (currentBeam.Location.X <= XLim && currentBeam.Location.X >= 0 && currentBeam.Location.Y <= YLim && currentBeam.Location.Y >= 0)
                {

                    //try to energise
                    if (!energisedPoints.Contains(currentBeam.Location))
                    {
                        energisedPoints.Add(currentBeam.Location);
                    }

                    //establish next move

                    var locVal = linesArr[currentBeam.Location.Y][currentBeam.Location.X];                    

                    //split                    
                    if (locVal == '|' && (currentBeam.Direction == "E" || currentBeam.Direction == "W"))
                    {
                        if (currentBeam.Location != currentBeam.StartPoint)
                        {
                            currentBeam.Direction = "N";
                            newBeams.Add(new() {Direction = "S", StartPoint = currentBeam.Location, Location = currentBeam.Location });
                        }

                    }

                    if (locVal == '-' && (currentBeam.Direction == "N" || currentBeam.Direction == "S"))
                    {
                        if (currentBeam.Location != currentBeam.StartPoint)
                        {
                            currentBeam.Direction = "E";
                            newBeams.Add(new() { Direction = "W", StartPoint = currentBeam.Location, Location = currentBeam.Location });
                        }
                    }

                    //redirect
                    if (locVal == '/')
                    {
                        switch (currentBeam.Direction)
                        {
                            case "E":
                                currentBeam.Direction = "N";
                                break;
                            case "S":
                                currentBeam.Direction = "W";
                                break;
                            case "W":
                                currentBeam.Direction = "S";
                                break;
                            case "N":
                                currentBeam.Direction = "E";
                                break;
                            default:
                                break;
                        }
                    }

                    if (locVal == '\\')
                    {
                        switch (currentBeam.Direction)
                        {
                            case "E":
                                currentBeam.Direction = "S";
                                break;
                            case "S":
                                currentBeam.Direction = "E";
                                break;
                            case "W":
                                currentBeam.Direction = "N";
                                break;
                            case "N":
                                currentBeam.Direction = "W";
                                break;
                            default:
                                break;
                        }
                    }

                    //move
                    switch (currentBeam.Direction)
                    {
                        case "E":
                            currentBeam.Location = new Point(currentBeam.Location.X + 1, currentBeam.Location.Y);
                            break;
                        case "S":
                            currentBeam.Location = new Point(currentBeam.Location.X, currentBeam.Location.Y + 1);
                            break;
                        case "W":
                            currentBeam.Location = new Point(currentBeam.Location.X - 1, currentBeam.Location.Y);
                            break;
                        case "N":
                            currentBeam.Location = new Point(currentBeam.Location.X, currentBeam.Location.Y - 1);
                            break;
                        default:
                            break;
                    }
                    
                }
            

            //loop handling            

            foreach(var b in newBeams) beams.Enqueue(b);

        }

            answer = energisedPoints.Count();


            Console.WriteLine("answer: " + answer);
        }
    }

    public class Beam {
        public string Direction { get; set; }
        public Point Location { get; set; }

        public Point StartPoint { get; set; }
    }

}
