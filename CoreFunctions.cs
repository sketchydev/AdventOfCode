public static class CoreFunctions {
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
}


