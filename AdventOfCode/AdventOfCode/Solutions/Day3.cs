using AdventOfCode.Framework;

namespace AdventOfCode.Solutions;

/// <summary>
/// https://adventofcode.com/2022/day/3
/// </summary>
[Solution(3)]
[SolutionInput("Input3.txt")]
public class Solution3 : Solution
{
    private Input input;
    
    public Solution3(Input input) : base(input)
    {
        this.input = input;
    }

    private int[] characterBuffer = new int[53];
    
    /// <inheritdoc />
    protected override string Problem1()
    {
        int sumOfDuplicateItems = 0;

        bool ValueIsDuplicateOrIncrement(int valueToCheck, int owningCompartment)
        {
            if (characterBuffer[valueToCheck] == 0)
            {
                characterBuffer[valueToCheck] = owningCompartment;
            }
            else if (characterBuffer[valueToCheck] != owningCompartment)
            {
                sumOfDuplicateItems += valueToCheck;
                Array.Clear(characterBuffer);
                return true;
            }

            return false;
        }

        foreach (string inputLine in this.input.Lines)
        {
            int lengthOfCompartments = inputLine.Length / 2;
            string compartmentOne = inputLine[..lengthOfCompartments];
            string compartmentTwo = inputLine[lengthOfCompartments..];

            for (int i = 0; i < lengthOfCompartments; i++)
            {
                int charCompartment1 = CharToNumber(compartmentOne[i]);
                int charCompartment2 = CharToNumber(compartmentTwo[i]);

                if (ValueIsDuplicateOrIncrement(charCompartment1, 1)) break;
                if (ValueIsDuplicateOrIncrement(charCompartment2, 2)) break;
            }
        }

        return sumOfDuplicateItems.ToString();
    }
    
    /// <inheritdoc />
    protected override string Problem2()
    {
        int sumOfDuplicateItems = 0;

        bool CharacterOccurs3TimesOrIncrement(int characterValue, int owningGroupPrimeNumber)
        {
            if (characterBuffer[characterValue] == 0)
            {
                characterBuffer[characterValue] += owningGroupPrimeNumber;
            }
            
            if (characterBuffer[characterValue] % owningGroupPrimeNumber != 0)
            {
                characterBuffer[characterValue] *= owningGroupPrimeNumber;
            }
            
            if (characterBuffer[characterValue] == 2 * 3 * 5)
            {
                sumOfDuplicateItems += characterValue;
                Array.Clear(characterBuffer);
                return true;
            }

            return false;
        }

        foreach (string[] group in this.input.Lines.Chunk(3))
        {
            for (int i = 0; i < Math.Max(Math.Max(group[0].Length, group[1].Length), group[2].Length); i++)
            {
                if (group[0].Length > i)
                {
                    int charValueElf = CharToNumber(group[0][i]);
                    if (CharacterOccurs3TimesOrIncrement(charValueElf, 2)) break;
                }
                
                if (group[1].Length > i)
                {
                    int charValueElf = CharToNumber(group[1][i]);
                    if (CharacterOccurs3TimesOrIncrement(charValueElf, 3)) break;
                }
                
                if (group[2].Length > i)
                {
                    int charValueElf = CharToNumber(group[2][i]);
                    if (CharacterOccurs3TimesOrIncrement(charValueElf, 5)) break;
                }
            }
        }

        return sumOfDuplicateItems.ToString();
    }

    private static int CharToNumber(char character)
    {
        char uppercaseChar = char.ToUpperInvariant(character);

        int value = uppercaseChar - 'A' + 1;

        if (character == uppercaseChar)
        {
            value += 26;
        }

        return value;
    }
}
