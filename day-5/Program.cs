using System.Net;

namespace day_5;

class Program
{
    static void Main(string[] args)
    {
        var (pageOrder, pageNumbers) = ProcessFile("input.txt");
        foreach (var kvp in pageOrder)
        {
            Console.WriteLine($"Key: {kvp.Key}, Values: {string.Join(", ", kvp.Value)}");
        }
        Console.WriteLine();
        foreach (var page in pageNumbers)
        {
            Console.WriteLine($"Page: {string.Join(", ", page)}");
        }
    }

    public static (Dictionary<int, List<int>>, List<List<int>>) ProcessFile(string filePath)
    {
        string[] input = File.ReadAllLines(filePath);

        var firstSection = input.TakeWhile(line => !string.IsNullOrWhiteSpace(line)).ToArray();
        var secondSection = input.Skip(firstSection.Length + 1).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        Dictionary<int, List<int>> numberDict = new Dictionary<int, List<int>>();

        foreach (var item in firstSection)
        {
            var parts = item.Split("|").Select(int.Parse).ToArray();
            int key = parts[0];
            int value = parts[1];

            if (!numberDict.ContainsKey(key))
            {
                numberDict[key] = new List<int>();
            }
            
            numberDict[key].Add(value);
        }
        
        var sortedDict = numberDict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        List<List<int>> listOfValues = new List<List<int>>();

        foreach (var line in secondSection)
        {
            var values = line.Split(",").Select(int.Parse).ToList();
            listOfValues.Add(values);
        }
        
        return (sortedDict, listOfValues);
    }
}