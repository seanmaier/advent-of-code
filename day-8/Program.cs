using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace day_8;

class Program
{
    static void Main(string[] args)
    {
        var map = ProcessFile("input.txt");

        var amount = Part1(map);
        Console.WriteLine($"The amount of antinodes is {amount}");
    }

    static char[,] ProcessFile(string filePath)
    {
        try
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
        catch (Exception e)
        {
            Console.WriteLine("Couldn't process file.");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return null;
    }

    static int Part1(char[,] map)
    {
        var rows = map.GetLength(0);
        var cols = map.GetLength(1);

        Dictionary<(int row, int column), char> allLocs = new Dictionary<(int, int), char>();
        
        for (var currRow = 0; currRow < rows; currRow++)
        {
            for (var currCol = 0; currCol < cols; currCol++)
            {
                var c = map[currRow, currCol];
                if(c == '.') continue;
                allLocs.Add((currRow, currCol), c);
            }
        }
        
        var antinodes = new HashSet<(int, int)>();

        foreach (List<(int row, int column)> locs in allLocs.Select(freq => allLocs.Keys.ToList()))
        {
            for (int i = 0; i < locs.Count; i++)
            {
                for (int j = i + 1; j < locs.Count; j++)
                {
                    if (allLocs[locs[i]] != allLocs[locs[j]]) continue;
                    var a = locs[i];
                    var b = locs[j];

                    foreach (var antinode in GetAntiNodesPart2(a, b, map)) // Change to Part1 or Part2!!!
                    {
                        antinodes.Add(antinode);
                        map[antinode.Item1, antinode.Item2] = '#';
                    } 
                }
            }

            foreach (var loc in locs)
            {
                antinodes.Add(loc);
            }
        }

        for (var i = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
        
        return antinodes.Count;
    }

    static List<(int, int)> GetAntiNodesPart1((int x,int y) a, (int x, int y) b, char[,] map)
    {
        var rowLength = map.GetLength(0);
        var colLength = map.GetLength(1);
        int ax = a.x, ay = a.y;
        int bx = b.x, by = b.y;

        int cx = ax - (bx - ax), cy = ay - (by - ay);
        int dx = bx + (bx - ax), dy = by + (by - ay);

        var antinodes = new List<(int, int)>();
        
        if(InBounds(cx, cy, rowLength, colLength))
        {
            antinodes.Add((cx, cy));
        }

        if (InBounds(dx, dy, rowLength, colLength))
        {
            antinodes.Add((dx, dy));
        }

        return antinodes;
    }

    static bool InBounds(int x, int y, int bx, int by)
    {
        return (x >= 0 && x < bx && y >= 0 && y < by );
    }

    static int Part2(char[,] map)
    {
        return -1;
    }
    
    static List<(int, int)> GetAntiNodesPart2((int x,int y) a, (int x, int y) b, char[,] map)
    {
        var rowLength = map.GetLength(0);
        var colLength = map.GetLength(1);
        int ax = a.x, ay = a.y;
        int bx = b.x, by = b.y;

        int xDistance = bx - ax, yDistance = by - ay;
        int cx = ax - xDistance, cy = ay - yDistance;
        int dx = bx + xDistance, dy = by + yDistance;
        

        var antinodes = new List<(int, int)>();
        
        while(InBounds(cx, cy, rowLength, colLength))
        {
            antinodes.Add((cx, cy));
            cx -= xDistance;
            cy -= yDistance;
        }

        while (InBounds(dx, dy, rowLength, colLength))
        {
            antinodes.Add((dx, dy));
            dx += xDistance;
            dy += yDistance;
        }

        return antinodes;
    }
}