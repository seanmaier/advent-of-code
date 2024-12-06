namespace day_2;

class Program
{
    static void Main(string[] args)
    {
        List<int[]> input = ProcessFile("input.txt");
        int amount = Part1(input);
        Console.WriteLine($"Of the scanned reports {amount} are safe.");

        int skippedAmount = Part2(input);
        Console.WriteLine($"\nOf the correctly scanned reports {skippedAmount} are safe");
    }
    

    static List<int[]> ProcessFile(string filepath)
    {

        try
        {
            var reports = File.ReadAllLines(filepath)
                .Select(x => x.Split(" ")
                .Select(int.Parse)
                .ToArray())
                .ToList();

            return reports;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured while reading the file:");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return null;
    }

    static int Part1(List<int[]> input)
    {
        var validReports = input
            .Count(IsValidReport);

        return validReports;
    }

    static bool IsValidReport(int[] levels)
    {
        var isDecreasing = IsDecreasing(levels);
        var isIncreasing = IsIncreasing(levels);

        if (!isDecreasing && !isIncreasing) return false;

        for (int i = 0; i < levels.Length - 1; i++)
        {
            var diff = Math.Abs(levels[i + 1] - levels[i]);

            if (diff is < 1 or > 3) return false;
        }

        return true;
    }

    public static bool IsIncreasing(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1]) return false;
        }

        return true;
    }

    public static bool IsDecreasing(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1]) return false;
        }

        return true;
    }

    static int Part2(List<int[]> input)
    {
        var validReports = 0;

        foreach (var ints in input)
        {
            if (IsValidReport(ints))
            {
                validReports++;
                continue;
            }

            if (ints.Select((t, i) => ints.Where((_, index) => index != i).ToArray())
                .Any(IsValidReport))
            {
                validReports++;
            }
        }

        return validReports;
    }

}

/*
public static int CheckSafeAmount(int[][] jaggedArray)
{
    int safeAmount = 0;

    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] row = jaggedArray[i];

        if (!IsDecreasing(row) && !IsIncreasing(row))
        {
            continue;
        }

        bool isSafe = true;
        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            int currentValue = jaggedArray[i][j];
            int nextValue = jaggedArray[i][j + 1];

            var difference = Math.Abs(currentValue - nextValue);
            if (difference < 1 || difference > 3)
            {
                isSafe = false;
                break;
            }
        }

        if (isSafe)
        {
            safeAmount++;
        }
    }

    return safeAmount;
}


public static int CheckSafeAmount(int[][] jaggedArray, bool skip)
{
    int safeAmount = 0;

    for (int i = 0; i < jaggedArray.Length; i++)
    {
        int[] row = jaggedArray[i];

        (bool isDecreasing, row) = IsDecreasing(row, skip);
        (bool isIncreasing, row) = IsIncreasing(row, skip);

        if (!isDecreasing && !isIncreasing)
        {
            continue;
        }

        bool isSafe = true;
        for (int j = 0; j < jaggedArray[i].Length - 1; j++)
        {
            int currentValue = jaggedArray[i][j];
            int nextValue = jaggedArray[i][j + 1];

            var difference = Math.Abs(currentValue - nextValue);
            if (difference < 1 || difference > 3)
            {
                isSafe = false;
                break;
            }
        }

        if (isSafe)
        {
            safeAmount++;
        }
    }

    return safeAmount;
}


public static (bool, int[]) IsDecreasing(int[] array, bool skip)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] < array[i + 1])
        {
            if (!skip) return (false, array);
            array = RemoveAtIndex(array, i + 1);
            skip = false;
        }
    }

    return (true, array);
}


public static (bool, int[]) IsIncreasing(int[] array, bool skip)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] > array[i + 1])
        {
            if (!skip) return (false, array);
            array = RemoveAtIndex(array, i + 1);
            skip = false;
        };
    }

    return (true, array);
}

public static int[] RemoveAtIndex(int[] array, int index)
{
    int[] result = new int[array.Length - 1];

    for (int i = 0, j = 0; i < array.Length; i++)
    {
        if (i == index) continue;

        result[j++] = array[i];
    }

    return result;
}
}*/