using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace day_3;

class Program
{
    static void Main(string[] args)
    {
        List<(int, int)> processed1 = ProcessFilePart1("input.txt");
        int sum1 = CalculateSum(processed1);
        Console.WriteLine($"The sum is {sum1}");

        List<(int, int)> processed2 = ProcessFilePart2("input.txt");
        int sum2 = CalculateSum(processed2);
        Console.WriteLine($"The sum is {sum2}");
    }

    static List<(int, int)> ProcessFilePart1(string filepath)
    {
        string pattern = @"mul\((-?\d+),(-?\d+)\)";
        List<(int, int)> intPairs = new List<(int, int)>();
        
        string[] file = File.ReadAllLines(filepath);

        foreach (var line in file)
        {
            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                string fullMatch = match.Value;
                int firstInt = int.Parse(match.Groups[1].Value);
                int secondInt = int.Parse(match.Groups[2].Value);
                intPairs.Add((firstInt, secondInt));
            }
        }

        return intPairs;
    }

    static int CalculateSum(List<(int, int)> intPairs)
    {
        int sum = 0;
        
        foreach (var pair in intPairs)
        {
            sum += pair.Item1 * pair.Item2;
        }

        return sum;
    }
    
    static List<(int, int)> ProcessFilePart2(string filepath)
    {
        string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
        List<(int, int)> intPairs = new List<(int, int)>();
        bool isActive = true;
        
        string[] file = File.ReadAllLines(filepath);

        foreach (var line in file)
        {
            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                if (match.Value.StartsWith("mul("))
                {
                    if (isActive)
                    {
                        int firstInt = int.Parse(match.Groups[1].Value);
                        int secondInt = int.Parse(match.Groups[2].Value);
                        intPairs.Add((firstInt, secondInt));
                    }
                }
                else if (match.Value == "don't()")
                {
                    isActive = false;
                }
                else
                {
                    isActive = true;
                }
            }
        }
        return intPairs;
    }
}