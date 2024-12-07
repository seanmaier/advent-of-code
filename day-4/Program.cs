namespace day_4;

class Program
{
    static void Main(string[] args)
    {
        string[] input = ProcessFile("input.txt");
        int amount = Part1(input);
        Console.WriteLine($"The total amount of found 'XMAS' is {amount}");
    }

    public static string[] ProcessFile(string filePath)
    {
        try
        {
            string[] formatted = File.ReadAllLines(filePath);
            return formatted;
        }
        catch(Exception e)
        {
            Console.WriteLine("File couldn't be read");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return null;
    }
    
    
    public static int Part1(string[] input)
    {
        var rowLength = input[1].Length;
        var colLength = input.Length;
        var totalAmount = 0;
        
        (int, int)[] direction = [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (-1, -1), (1, -1), (-1, 1)];  
        
        for (int col = 0; col < colLength; col++)
        {
            for (int row = 0; row < rowLength; row++)
            {
                foreach (var (dx, dy) in direction)
                {
                    if (IsValid(input, col, row, dx, dy)) totalAmount++;
                }
            }
        }

        return totalAmount;
    }

    public static bool IsValid(string[] grid,int col, int row, int dx, int dy)
    {
        var keyword = "XMAS";
        var keywordLength = keyword.Length;

        for (int i = 0; i < keywordLength; i++)
        {
            var r = row + i * dx;
            var c = col + i * dy;
            if (r < 0 || r >= grid[0].Length || c < 0 || c >= grid.Length || grid[c][r] != keyword[i])
            {
                return false;
            }
        }

        return true;
    }
}