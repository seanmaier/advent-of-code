using System.Data;

namespace day_6;

class Program
{
    static void Main(string[] args)
    {
        var input = ProcessFile("input.txt");
        Part2(input);
        //Console.WriteLine($"The total amount of movements were {totalMoves}");
        
        
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

    public static int Part1(char[,] map)
    {
        var dy = new[] {-1, 0, 1, 0}; // Up, right, down, left
        var dx = new[] { 0, 1, 0, -1 };
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var direction = 0; // Upwards
        
        var (y, x) = FindGuard(map, rows, cols);
        map[y, x] = 'X';

        while (y < rows && y >= 0 && x < cols && x >= 0)
        {
            var ny = y + dy[direction];
            var nx = x + dx[direction];

            if (ny < 0 || ny >= rows || nx < 0 || nx >= cols)
            {
                break;
            }

            if (map[ny, nx] != '#')
            {
                y = ny;
                x = nx;
                map[y, x] = 'X';
            }
            else
            {
                direction = (direction + 1) % 4;
            }
        }

        return CountPositions(map, rows, cols);

    }

    public static (int y, int x) FindGuard(char[,] map, int rows, int cols)
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (map[i, j] == '^') return (i, j);
            }
        }

        throw new Exception("Guard could not be found");
    }
    
    public static int CountPositions(char[,] map, int rows, int cols)
    {
        var totalAmount = 0;
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (map[i, j] == 'X') totalAmount++;
            }
        }

        return totalAmount;
    }

    public static void Part2(char[,] map)
    {
        var direction = 0;
        var dy = new[] {-1, 0, 1, 0}; // Up, right, down, left
        var dx = new[] { 0, 1, 0, -1 };
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);
        var amountBlocker = 0;
     
        var (y, x) = FindGuard(map, rows, cols);
        map[y, x] = '|';
        
        while (y < rows && y >= 0 && x < cols && x >= 0)
        {
            var ny = y + dy[direction];
            var nx = x + dx[direction];

            if (ny < 0 || ny >= rows || nx < 0 || nx >= cols)
            {
                break;
            }

            if (map[ny, nx] != '#')
            {
                y = ny;
                x = nx;
                if (map[y, x] == '|' || map[y, x] == '-')
                {
                    map[y, x] = '+';
                    amountBlocker++;
                }
                else if (direction % 2 == 0)
                {
                    map[y, x] = '|';
                }
                else
                {
                    map[y, x] = '-';
                }
            }
            else
            {
                map[y, x] = '+';
                direction = (direction + 1) % 4;
            }
        }
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"The amount of blockers are {amountBlocker}");
    }
}