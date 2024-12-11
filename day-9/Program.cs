using System.Runtime.InteropServices;
using System.Text;

namespace day_9;

class Program
{
    static void Main(string[] args)
    {
        var processed = ProcessFile("input.txt");
        var rearrange = Rearrange(processed);
        SwapPositions(rearrange);
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

    static char[] Rearrange(int[] disk)
    {
        var after = new StringBuilder();
        var index = 0;
        var i = 0;

        foreach (var counter in disk)
        {
            if (i % 2 == 0)
            {
                after.Append(new string((char)(index + '0'), counter)); // Add '0', '1', '2', ... 
                index++;
            }
            else
            {
                after.Append(new string('.', counter)); // Add '.' for the entire counter
            }

            i++;
        }

        return after.ToString().ToCharArray();
    }

    static char[] SwapPositions(char[] array)
    {
        var totalDots = array.Count(c => c == '.');
        var right = array.Length - 1;               
        
        for (var left = 0; left < right; left++)
        {
            if (array[left] != '.') continue;
            
            while (right > left && array[right] == '.')
            {
                right--;
            }

            if (right <= left) continue;
            array[left] = array[right];
            array[right] = '.';
            right--; 
        }

        Console.WriteLine(string.Join(" ", array));
        return array;
    }

}
