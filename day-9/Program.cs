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
        try
        {
            var input = File.ReadAllText(filePath);
            return input.ToCharArray();

        }
        catch (Exception e)
        {
            Console.WriteLine("Couldn't process file");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return null;
    }
}
