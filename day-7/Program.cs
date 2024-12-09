namespace day_7;

class Program
{
    static void Main(string[] args)
    {
        var dict = ProcessFile("input.txt");

        foreach (var line in dict)
        {
            Console.WriteLine($"Key: {line.Key}, Values: {string.Join(", ", line.Value)}");
        }
    }

    public static Dictionary<int, List<int>> ProcessFile(string filePath)
    {
        try
        {
            var input = File.ReadAllLines(filePath);
            var  calibrationValues = new Dictionary<int, List<int>>();
            
            foreach (var line in input)
            {
                var parts = line.Split(":");
                var key = int.Parse(parts[0].Trim());
                var list = parts[1].Trim().Split(" ").Select(int.Parse).ToList();
                calibrationValues.Add(key, list);
            }

            return calibrationValues;
        }
        catch (Exception e)
        {
            Console.WriteLine("File could not be read.");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return null;
    }
}