namespace day_7;

class Program
{
    static void Main(string[] args)
    {
        var dict = ProcessFile("input.txt");

        /*foreach (var line in dict)
        {
            Console.WriteLine($"Key: {line.Key}, Values: {string.Join(", ", line.Value)}");
        }*/

        var part1 = Part1(dict);
        Console.WriteLine($"The calibrated amount in Part 1 is {part1}");

        var part2 = Part2(dict);
        Console.WriteLine($"The calibrated amount in Part 2 is {part2}");
    }

    public static Dictionary<long, List<int>> ProcessFile(string filePath)
    {
        try
        {
            var input = File.ReadAllLines(filePath);
            var calibrationValues = new Dictionary<long, List<int>>();

            foreach (var line in input)
            {
                var parts = line.Split(":");
                var key = long.Parse(parts[0].Trim());
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

    public static long Part2(Dictionary<long, List<int>> dict)
    {
        var op = new[] { "+", "*", "||" };
        var calibrationResult = 0L;

        foreach (var line in dict)
        {
            var matchFound = CheckCombinations(line.Value, op, 1, line.Value[0].ToString(), line.Key);

            if (matchFound) calibrationResult += line.Key;
        }

        return calibrationResult;
    }
    
    public static long Part1(Dictionary<long, List<int>> dict)
    {
        var op = new[] { '+', '*' };
        var calibrationResult = 0L;

        foreach (var line in dict)
        {
            var matchFound = CheckCombinations(line.Value, op, 1, line.Value[0], line.Key);

            if (matchFound) calibrationResult += line.Key;
        }

        return calibrationResult;
    }

    public static bool CheckCombinations(List<int> numbers, char[] operators, int index, long currentResult, long target)
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

    public static bool CheckCombinations(List<int> numbers, string[] operators, int index, string currentResult, long target)
    {
        if (index == numbers.Count)
        {
            return long.TryParse(currentResult, out var result) && result == target;
        }

        foreach (var op in operators)
        {
            var newResult = currentResult;

            switch (op)
            {
                case "+":
                    newResult = (long.Parse(newResult) + numbers[index]).ToString();
                    break;
                case "*":
                    newResult = (long.Parse(newResult) * numbers[index]).ToString();
                    break;
                case "||":
                    newResult += numbers[index].ToString();
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