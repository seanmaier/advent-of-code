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
}