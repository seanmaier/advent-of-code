namespace day_10;

class Program
{
    static void Main(string[] args)
    {
        var map = ProcessFile("input.txt");

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }

        Part1(map);
    }

    static char[,] ProcessFile(string filePath)
    {

        try
        {
            var lines = File.ReadLines(filePath).ToArray();
            var rows = lines.Length;
            var cols = lines[0].Length;
            var result = new char[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = lines[i][j];
                }
            }

            return result;

        }
        catch (Exception e)
        {
            Console.WriteLine("Couldn't process file");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
            return null;
        }

    }
    
    static int Part1(char[,] map)
    {
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var start = new List<(int x, int y)>();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (map[row, col] != '0') continue;
                start.Add((row, col));
            }


        }
        
        foreach (var coordinates in start)
        {
            Console.WriteLine(coordinates);
        }
        
        return -1;
    }
}