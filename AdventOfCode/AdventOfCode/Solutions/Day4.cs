using AdventOfCode.Framework;

namespace AdventOfCode.Solutions;

/// <summary>
/// https://adventofcode.com/2022/day/4
/// </summary>
[Solution(4)]
[SolutionInput("Input4.txt")]
public class Solution4 : Solution
{
    private readonly Input input;
    
    public Solution4(Input input) : base(input)
    {
        this.input = input;
    }

    /// <inheritdoc />
    protected override string Problem1()
    {
        int numberOfPairsWhereOneRangeIsContainedInAnother = 0;

        foreach (string inputLine in this.input.Lines)
        {
            string[] pairAssignments = inputLine.Split(",");

            string[] elf1Range = pairAssignments[0].Split("-");
            string[] elf2Range = pairAssignments[1].Split("-");

            int startElf1 = int.Parse(elf1Range[0]);
            int startElf2 = int.Parse(elf2Range[0]);
            int endElf1 = int.Parse(elf1Range[1]);
            int endElf2 = int.Parse(elf2Range[1]);

            if (startElf1 >= startElf2 && endElf1 <= endElf2)
            {
                numberOfPairsWhereOneRangeIsContainedInAnother++;
            }
            else if (startElf1 <= startElf2 && endElf1 >= endElf2)
            {
                numberOfPairsWhereOneRangeIsContainedInAnother++;
            }
        }

        return numberOfPairsWhereOneRangeIsContainedInAnother.ToString();
    }
    
    /// <inheritdoc />
    protected override string Problem2()
    {
        int numberOfPairsWhereOneRangeIsContainedInAnother = 0;

        foreach (string inputLine in this.input.Lines)
        {
            string[] pairAssignments = inputLine.Split(",");

            string[] elf1Range = pairAssignments[0].Split("-");
            string[] elf2Range = pairAssignments[1].Split("-");

            int startElf1 = int.Parse(elf1Range[0]); 
            int startElf2 = int.Parse(elf2Range[0]);
            int endElf1 = int.Parse(elf1Range[1]); 
            int endElf2 = int.Parse(elf2Range[1]); 

            if (startElf1 <= startElf2 && endElf1 >= startElf2)
            {
                numberOfPairsWhereOneRangeIsContainedInAnother++;
            }
            else if (startElf2 <= startElf1 && endElf2 >= startElf1)
            {
                numberOfPairsWhereOneRangeIsContainedInAnother++;
            }
        }

        return numberOfPairsWhereOneRangeIsContainedInAnother.ToString();
    }
}
