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

}