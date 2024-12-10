namespace day_8;

class Program
{
    static void Main(string[] args)
    {
        var map = ProcessFile("input.txt");

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    static char[,] ProcessFile(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        var rows = input.Length;
        var cols = input[0].Length;
        var map = new char[rows, cols];
        
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                map[i, j] = input[i][j];
            }
        }

        return map;
    }
}