using System.Runtime.InteropServices;
using System.Text;

namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        var processed = ProcessFile("input.txt");
        var rearrange = Rearrange(processed);
        var swapped = SwapPositions(rearrange);
        var sum = CheckSum(swapped);
        Console.WriteLine($"The sum is {sum}");
    }

    static int[] ProcessFile(string filePath)
    {
        try
        {
            var fileContent = File.ReadAllText(filePath);
            var numbers = fileContent
                .Where(char.IsDigit)
                .Select(c => int.Parse(c.ToString()))
                .ToArray();

            return numbers;
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldn't process file");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return [-1];
    }

    static List<string> Rearrange(int[] disk)
    {
        var after = new List<string>();
        var index = 0;
        var i = 0;

        foreach (var counter in disk)
        {
            if (i % 2 == 0) // Add numbers
            {
                var value = index.ToString();
                for (var j = 0; j < counter; j++)
                {
                    after.Add(value);
                }
                index++;
            }
            else
            {
                for (int j = 0; j < counter; j++)
                {
                    after.Add(".");
                }
            }

            i++;
        }

        return after;
    }

    static List<string> SwapPositions(List<string> array)
    {
        var totalDots = array.Count(c => c == ".");
        var right = array.Count - 1;
        
        for (var left = 0; left < right; left++)
        {
            if (array[left] != ".") continue;
            
            while (right > left && array[right] == ".")
            {
                right--;
            }

            if (right <= left) continue;
            array[left] = array[right];
            array[right] = ".";
            right--; 
        }

        Console.WriteLine(string.Join(" ", array));
        return array;
    }

    static int CheckSum(List<string> array)
    {
        var sum = 0;
        
        for (var i = 0; i < array.Count; i++)
        {
            if (array[i] == ".") break;

            sum += i * Convert.ToInt32(array[i]);
        }

        return sum;
    }

}
