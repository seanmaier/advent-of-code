using System.Runtime.InteropServices;
using System.Text;

namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        var processed = ProcessFile("input.txt");
        var rearrange = Rearrange(processed);
        //var swapped = SwapPositions(rearrange);
        //var sum = CheckSum(swapped);
        //Console.WriteLine($"The sum is {sum}");

        Console.WriteLine(string.Join(" ", rearrange));
        var compact = SwapCompact(rearrange);
        var sum2 = CheckSum(compact);
        Console.WriteLine($"The sum is {sum2}");
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
        var right = array.Count - 1;
        
        for (var left = 0; left < right; left++)
        {
            if (array[left] != ".") continue;
            
            while (right > left && array[right] == ".")
            {
                right--;
            }

            if (right <= left) continue;
            Swap(left, right, array);
            right--; 
        }

        return array;
    }
    
    static List<string> SwapCompact(List<string> array)
    {
        var left = 0;
        var dotCounts = new Dictionary<int, int>();


        for (var right = array.Count - 1; "0" != array[right]; right--)
        {
            
            // Adjusting left and right
            if (array[right] == ".") continue;
            
            while (right > left && array[left] != ".")
            {
                left++;
            }
            
            
            // Check for amount of numbers
            if (right <= 0) break;
            var countNumb = 1;
            var rightCopy = right;

            
            while (array[rightCopy] == array[rightCopy - 1])
            {
                countNumb++;
                rightCopy--;
            };

            
            dotCounts.Clear();
            // Check for amount of space
            for (var i = left; i < right; i++)
            {
                if (array[i] != ".") continue;
                var key = i;
                var count = 0;
                while (i < array.Count && array[i] == ".")
                {
                    count++;
                    i++;
                }
                dotCounts.Add(key, count);
            }
            
            var isSpace = dotCounts.Any(count => countNumb <= count.Value);
            if (!isSpace)
            {
                right -= (countNumb - 1);
                continue;
            }

            
            // Replace the values
            var index = dotCounts.First(dots => dots.Value >= countNumb).Key;
            for (var i = 0; i < countNumb; i++)
            {
                Swap(index, right, array);
                index++;
                right--; 
            }
            
            // Used to make outer loop work, after inner loop
            right += 1;
        }
        

        return array;
    }

    static long CheckSum(List<string> array)
    {
        var sum = (long) 0;
        
        for (var i = 0; i < array.Count; i++)
        {
            if (array[i] == ".") continue;

            sum += i * Convert.ToInt64(array[i]);
        }

        return sum;
    }

    static void Swap(int left, int right, List<string> array)
    {
        array[left] = array[right];
        array[right] = ".";
    }

}
