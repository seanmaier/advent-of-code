using System.Runtime.InteropServices;

namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        var processed = ProcessFile("input.txt");
        Console.WriteLine(string.Join(" | ", processed));
    }

    static char[] ProcessFile(string filePath)
    {
        string input = File.ReadAllText(filePath);
        return input.ToCharArray();
    }
}
