using System.Text.RegularExpressions;

namespace day_1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Advent of Code Day 1!");
        
        
        Console.WriteLine("Calculating the total Distance...");
        var (leftList, rightList) = ProcessFile("input.txt");
        int tDistance = CalculateTotalDistance(leftList, rightList);
        Console.WriteLine($"Total distance is: {tDistance}");
        
        
        Console.WriteLine("Calculating the similarity Score...");
        int sScore = CalculateSimilarityScore(leftList, rightList);
        Console.WriteLine($"Similarity Score is: {sScore}");
    }

    
    
    
    
    public static (List<int> leftList, List<int> rightList) ProcessFile(string filePath)
    {
        List<int> leftList = [];
        List<int> rightList = [];
        
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = Regex.Split(line, @"\s+");

                    leftList.Add(Convert.ToInt32(values[0]));
                    rightList.Add(Convert.ToInt32(values[1]));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        return (leftList, rightList);
    }
    
    
    public static int CalculateTotalDistance(List<int> leftList, List<int> rightList)
    {
        var tDistance = 0;
        var leftCopy = new List<int>(leftList);
        var rightCopy = new List<int>(rightList);
        
        leftCopy.Sort();
        rightCopy.Sort();
        
        while(leftCopy.Count > 0 && rightCopy.Count > 0)
        {
            tDistance += Math.Abs(leftCopy.Min() - rightCopy.Min());
            rightCopy.RemoveAt(IndexOfMin(rightCopy));
            leftCopy.RemoveAt((IndexOfMin(leftCopy)));
        }

        return tDistance;
    }

    
    
    
    // Use Dictionary
    // Use this if statement -> if (groupedRightList.TryGetValue(leftValue, out int count))
    public static int CalculateSimilarityScore(List<int> leftList, List<int> rightList)
    {
        int sScore = 0;
        
        int length = leftList.Count;

        var g = rightList.GroupBy(i => i);

        for(var i = 0; i < length;i++)
        {
            var leftValue = leftList[i];
    
            if (!rightList.Contains(leftValue))
            {
                leftList[i] = 0;
                continue;
            }
    
            foreach (var grp in g) 
            {
                if (grp.Key == leftValue)
                {
                    leftList[i] *= grp.Count();
                    break;
                }
            }

            sScore += leftList[i];
        }

        return sScore;
    }

    
    
    
    
    public static int IndexOfMin(IList<int> self)
    {
        if (self == null) {
            throw new ArgumentNullException("self");
        }

        if (self.Count == 0) {
            throw new ArgumentException("List is empty.", "self");
        }

        int min = self[0];
        int minIndex = 0;

        for (int i = 1; i < self.Count; ++i) {
            if (self[i] < min) {
                min = self[i];
                minIndex = i;
            }
        }

        return minIndex;
    }
}