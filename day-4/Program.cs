namespace day_4;

class Program
{
    static void Main(string[] args)
    {
        string[] input = ProcessFile("input.txt");
        Console.WriteLine(String.Join("\n", input));
    }

    public static string[] ProcessFile(string filePath)
    {
        string[] formatted = File.ReadAllLines(filePath);

        return formatted;
    }
}