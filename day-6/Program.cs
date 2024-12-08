namespace day_6;

class Program
{
    static void Main(string[] args)
    {
        var input = ProcessFile("input.txt");
        for (int i = 0; i < input.GetLength(0); i++)
        {
            for (int j = 0; j < input.GetLength(1); j++)
            {
                Console.Write(input[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static char[,] ProcessFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var rows = lines.Length;
        var cols = lines[0].Length;
        var formatted = new char[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                formatted[i, j] = lines[i][j];
            }
        }

        return formatted;
    }
}