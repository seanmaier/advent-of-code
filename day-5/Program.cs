﻿using System.Net;

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

        int sum = Part1(pageOrder, pageNumbers);
        Console.WriteLine($"The sum is {sum}");
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

    public static int Part1(Dictionary<int, List<int>> pageOrder, List<List<int>> pageNumberList)
    {
        int sum = 0;
        
        foreach (var pageCol in pageNumberList)
        {
            var skip = false;
            
            for (int page = 0; page < pageCol.Count - 1; page++)
            {
                int currentKey = pageCol[page];
                
                if (!pageOrder.ContainsKey(currentKey) || !pageOrder[currentKey].Contains(pageCol[page + 1]))
                {
                    skip = true;
                    break;
                }
            }
            if (skip) continue;
            sum += pageCol[pageCol.Count / 2];
        }

        return sum;
    }
}