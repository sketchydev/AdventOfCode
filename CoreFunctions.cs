using System.Drawing;
using System.Xml.Linq;


public static class CoreFunctions
{
    public static List<string> Reader()
    {

        var lines = new List<string>();

        string? line;
        do
        {
            line = Console.ReadLine();

            if (line.ToLower() != "end")
            {
                lines.Add(line);
            }

        } while (line.ToLower() != "end");

        return lines;
    }

    public static List<string> ReadFile(string filename)
    {

        var lines = new List<string>();

        string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        string file = dir + filename;

        var sr = new StreamReader(file);

        var line = sr.ReadLine();
        while (line != null)
        {
            lines.Add(line);

            line = sr.ReadLine();
        }
        //close the file
        sr.Close();
        return lines;

    }

    public static bool PointAdjacentCheck(Point a, Point b)
    {
        if (a.X == b.X && a.Y == b.Y + 1) return true;
        if (a.X == b.X && a.Y == b.Y - 1) return true;
        if (a.X == b.X + 1 && a.Y == b.Y) return true;
        if (a.X == b.X - 1 && a.Y == b.Y) return true;
        return false;
    }

    public static int[] RemoveAt(int[] source, int index)
    {
        return source.Where((val, idx) => idx != index).ToArray();
    }


    public static double GetDistance(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }

    public static int[] RandomizeIntArray(int[] array)
    {
        Random rng = new();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = array[k];
            array[k] = array[n];
            array[n] = value;
        }

        return array;
    }

    public static string[] AddPadding(List<string> input, int padding, char paddingChar)
    {
        var linelength = input[0].Length;
        var dotLine = new string(paddingChar, linelength);
        var paddedLines = new List<string>();
        for (var i = 0; i < padding; i++) paddedLines.Add(dotLine);
        paddedLines.AddRange(input);
        for (var i = 0; i < padding; i++) paddedLines.Add(dotLine);
        var linesArr = paddedLines.ToArray();
        for (int i = 0; i < paddedLines.Count; i++) linesArr[i] = new string(paddingChar, padding) + paddedLines[i] + new string(paddingChar, padding);
        return linesArr;
    }


    public static LinkedList<T> ConvertArrayToLinkedList<T>(T[] array)
    {
        LinkedList<T> linkedList = new();

        foreach (T item in array)
        {
            linkedList.AddLast(item);
        }

        return linkedList;
    }

    public static int CountOccurrences<T>(LinkedList<T> list, T target)
    {
        LinkedListNode<T> current = list.First;
        int count = 0;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, target))
            {
                count++;
            }
            current = current.Next;
        }

        return count;
    }

    public static string[] SplitStringInHalf(string inputString)
    {
        int halfLength = inputString.Length / 2;
        string firstHalf = inputString.Substring(0, halfLength);
        string secondHalf = inputString.Substring(halfLength);

        return [firstHalf, secondHalf];
    }

    public static List<IEnumerable<T>> GeneratePairs<T>(IEnumerable<T> input)
    {
        var pairs = new List<IEnumerable<T>>();
        var list = input.ToList();

        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                var pair = new List<T> { list[i], list[j] }.ToArray();
                pairs.Add(pair);
            }
        }

        return pairs;
    }


        public static IEnumerable<string> SplitByLength(string str, int maxLength)
        {
            for (int index = 0; index < str.Length; index += maxLength)
            {
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
            }
        }

    public static IEnumerable<long> RangeLong(long start, long count)
    {
        for (long i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }

    public static bool ArePointsAdjacent(Point a, Point b)
    {
        int dx = Math.Abs(a.X - b.X);
        int dy = Math.Abs(a.Y - b.Y);
        return dx <= 1 && dy <= 1 && (dx | dy) != 0;
    }

    public static bool IsPointInPolygon(Point[] polygon, Point testPoint)
    {
        bool result = false;
        int j = polygon.Length - 1; // The last vertex

        for (int i = 0; i < polygon.Length; i++)
        {
            // 1. Check if the point's Y is between the edge's Y coordinates
            // 2. Check if the point is to the Left of the line segment
            if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y ||
                polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
            {
                if (polygon[i].X + (testPoint.Y - polygon[i].Y) /
                   (double)(polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                {
                    // Toggle the state
                    result = !result;
                }
            }

            // Save current point as 'previous' for next iteration
            j = i;
        }

        return result;
    }

    public static IEnumerable<Point> GetPointsInRectangle(Point p1, Point p2)
    {
        // 1. Determine the boundaries
        int minX = Math.Min(p1.X, p2.X);
        int maxX = Math.Max(p1.X, p2.X);
        int minY = Math.Min(p1.Y, p2.Y);
        int maxY = Math.Max(p1.Y, p2.Y);

        // 2. Iterate through every coordinate
        // Using <= insures we include the points ON the lines
        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                yield return new Point(x, y);
            }
        }
    }

    public static IEnumerable<Point> GetRectangleCorners(Point corner1, Point corner2)
    {
        var corner3 = new Point(corner1.X, corner2.Y);
        var corner4 = new Point(corner2.X, corner1.Y);
        return new List<Point> { corner1, corner2, corner3, corner4 };
    }

    public static IEnumerable<Point> GetPerimeterPoints(Point p1, Point p2)
    {
        // 1. Normalize coordinates to find strict bounds
        // This ensures the logic works regardless of which corners were passed
        // (e.g., Top-Left+Bottom-Right OR Top-Right+Bottom-Left)
        int xMin = Math.Min(p1.X, p2.X);
        int xMax = Math.Max(p1.X, p2.X);
        int yMin = Math.Min(p1.Y, p2.Y);
        int yMax = Math.Max(p1.Y, p2.Y);

        // 2. Iterate the Horizontal rows (Top and Bottom)
        for (int x = xMin; x <= xMax; x++)
        {
            // Top Edge
            yield return new Point(x, yMin);

            // Bottom Edge
            // We check (yMin != yMax) to ensure we don't double-count 
            // if the rectangle is actually a horizontal line (height 0).
            if (yMin != yMax)
            {
                yield return new Point(x, yMax);
            }
        }

        // 3. Iterate the Vertical columns (Left and Right)
        // Note: We iterate from (yMin + 1) to (yMax - 1) to avoid 
        // returning the corner points again, as they were handled in step 2.
        for (int y = yMin + 1; y < yMax; y++)
        {
            // Left Edge
            yield return new Point(xMin, y);

            // Right Edge
            // We check (xMin != xMax) to ensure we don't double-count 
            // if the rectangle is a vertical line (width 0).
            if (xMin != xMax)
            {
                yield return new Point(xMax, y);
            }
        }
    }


}
public class LCM {

        private List<long> set_of_numbers = [];
        private List<long> arg_copy = []; // arrays are passed by reference; make a copy.
        private List<long> all_factors = []; // factors common to our set_of_numbers

        private long index; // index longo array common_factors
        private bool state_check; // variable to keep state
        private long calc_result;

        public LCM(List<long> group)
        {
            //iterate through and retrieve members
            foreach (long number in group)
            {
                set_of_numbers.Add(number);
                arg_copy.Add(number);
            }

            set_of_numbers.Sort();
            set_of_numbers.Reverse();

            state_check = false;
            calc_result = 1;
        }

        /**
         * Our function checks 'set_of_numbers'; If it finds a factor common to all
         * for it, it records this factor; then divides 'set_of_numbers' by the
         * common factor found and makes this the new 'set_of_numbers'. It continues
         * recursively until all common factors are found.
         *
         */
        private long findLCMFactors()
        {
            for (int i = 0; i < set_of_numbers.Count; i++)
            {
                arg_copy[i] = set_of_numbers[i];
            }
            // STEP 1:
            arg_copy.Sort();
            arg_copy.Reverse();

            while (index <= arg_copy[0])
            {
                state_check = false;
                for (int j = 0; j < set_of_numbers.Count; j++)
                {
                    if (set_of_numbers[j] != 1 && (set_of_numbers[j] % index) == 0)
                    {
                        // STEP 3:
                        set_of_numbers[j] /= index;
                        if (state_check == false)
                        {
                            all_factors.Add(index);
                        }
                        state_check = true;
                    }
                }
                // STEP 4:
                if (state_check == true)
                {
                    return findLCMFactors();
                }
                index++;
            }

            return 0;
        }

        /**
         * Just calls out and collects the prepared factors.
         * @return - long value;
         */
        public long getLCM()
        {
            // STEP 2:
            index = 2;
            findLCMFactors();

            //iterate through and retrieve members
            foreach (long factor in all_factors)
            {
                calc_result *= factor;
            }

            return calc_result;
        }
    }

public class SimpleMatrixItem
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string Value { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is SimpleMatrixItem other)
        {
            return Row == other.Row && Column == other.Column && Value == other.Value;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column, Value);
    }
}

public class Grid
{
    public GridRow[] Rows { get; set; }
}

public class GridRow
{
    public int Index { get; set; }
    public GridCell[] Cells { get; set; }
}

public class GridCell
{
    public int Index { get; set; }
    public string Value { get; set; }
}







