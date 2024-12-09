namespace day_7;

class Program
{
    static void Main(string[] args)
    {
        var dict = ProcessFile("input.txt");

        var amount = Part1(dict);
        Console.WriteLine($"The sum of the correct calibrations is: {amount}");
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

    public static int Part1(Dictionary<int, List<int>> dict)
    {
        var op = new[] { '+', '*' };
        var calibrationResult = 0;
            
        foreach (var line in dict)
        {
                var matchFound = CheckCombinations(line.Value, op, 1, line.Value[0], line.Key);

                if (matchFound) calibrationResult += line.Key;
        }

        return calibrationResult;
    }

    public static bool CheckCombinations(List<int> numbers, char[] operators, int index, int currentResult, int target)
    {
        if (index == numbers.Count)
        {
            return currentResult == target;
        }

        foreach (var op in operators)
        {
            var newResult = currentResult;
            
            switch (op)
            {
                case '+':
                    newResult += numbers[index];
                    break;
                case '*':
                    newResult *= numbers[index];
                    break;
            }

            if (CheckCombinations(numbers, operators, index + 1, newResult, target))
            {
                return true;
            }
        }

        return false;
    }
}