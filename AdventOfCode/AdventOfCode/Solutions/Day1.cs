using AdventOfCode.Framework;

namespace AdventOfCode.Solutions;


/// <summary>
/// https://adventofcode.com/2022/day/1
/// </summary>
[Solution(1)]
[SolutionInput("Input1.txt")]
public class Solution1 : Solution
{
    private readonly IOrderedEnumerable<int> elfCaloriesOrdered;
    
    public Solution1(Input input) : base(input)
    {
        Dictionary<int, int> elvesToCaloriesCarried = new();
        
        int currentElfIndex = 0;

        for (int i = 0; i < input.Lines.Length; i++)
        {
            string line = input.Lines[i];
            
            string lineSterilised = line.Trim();

            if (string.IsNullOrEmpty(lineSterilised))
            {
                currentElfIndex++;
                continue;
            };
            
            if (elvesToCaloriesCarried.ContainsKey(currentElfIndex))
            {
                elvesToCaloriesCarried[currentElfIndex] += int.Parse(lineSterilised);
            }
            else
            {
                elvesToCaloriesCarried.Add(currentElfIndex, int.Parse(lineSterilised));
            }
        }

        elfCaloriesOrdered = elvesToCaloriesCarried
            .Select(x => x.Value)
            .OrderByDescending(x => x);
    }

    /// <inheritdoc />
    protected override string Problem1()
    {
        return elfCaloriesOrdered.Take(1).Sum().ToString();
    }

    /// <inheritdoc />
    protected override string Problem2()
    {
        return elfCaloriesOrdered.Take(3).Sum().ToString();
    }
}
