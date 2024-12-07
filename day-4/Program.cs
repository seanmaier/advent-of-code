namespace day_4;

class Program
{
    static void Main(string[] args)
    {
        string[] input = ProcessFile("input.txt");
        int amount = Part2(input);
        Console.WriteLine($"The total amount of found 'MAS' is {amount}");
    }

    public static string[] ProcessFile(string filePath)
    {
        try
        {
            string[] formatted = File.ReadAllLines(filePath);
            int length = formatted[0].Length;

            foreach (var line in formatted)
            {
                if (line.Length != length)
                {
                    throw new InvalidOperationException("Not all strings in the array have the same length.");
                }
            }

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
                foreach (var (dy, dx) in direction)
                {
                    if (IsValidPart1(input, col, row, dy, dx)) totalAmount++;
                }
            }
        }

        return totalAmount;
    }

    public static bool IsValidPart1(string[] grid,int col, int row, int dx, int dy)
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
    
    public static int Part2(string[] input)
    {
        var rowLength = input[1].Length;
        var colLength = input.Length;
        var totalAmount = 0;
        

        
        for (int row = 1; row < colLength - 1; row++)
        {
            for (int col = 1; col < rowLength; col++)
            { 
                if (IsValidPart2(input, row, col)) totalAmount++;
            }
        }

        return totalAmount;
    }

    public static bool IsValidPart2(string[] grid, int row, int col)
    {
        (int, int)[] direction = [(-1, -1), (1, -1), (-1, 1), (1, 1)];
        string[] keyword = ["MSMS", "MMSS", "SSMM", "SMSM"];
        int letterLength = keyword[0].Length;
        
        
        if (grid[row][col] != 'A') return false;

        for (int scheme = 0; scheme < keyword.Length; scheme++)
        {
            var counter = 0;
            
            foreach (var (dy,dx ) in direction) 
            { 
                var r = row + dx; 
                var c = col + dy;

                if (r < 0 || r >= grid[0].Length || c < 0 || c >= grid.Length || grid[r][c] != keyword[scheme][counter])
                {
                    continue;
                }

                counter++;
            }

            if (counter == keyword[0].Length) return true;
        }
        return false;
    }
}