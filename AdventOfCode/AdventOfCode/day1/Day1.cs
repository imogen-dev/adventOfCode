namespace AdventOfCode.day1;

public class Day1
{
    public string SolveQuestionOne()
    {
        string[] lines = File.ReadAllLines("day1/day1input.txt");

        int currentMaximumCalories = 0;

        int currentElfCalorieSum = 0;
        
        foreach (string line in lines)
        {
            string lineSterilised = line.Trim();
            
            if (string.IsNullOrEmpty(lineSterilised))
            {
                if (currentElfCalorieSum > currentMaximumCalories)
                {
                    currentMaximumCalories = currentElfCalorieSum;
                }

                currentElfCalorieSum = 0;
            }
            else
            {
                currentElfCalorieSum += int.Parse(lineSterilised);
            }
        }

        return $"Maximum Elf Calories Carried: {currentMaximumCalories}";
    }
    
    public string SolveQuestionTwo()
    {
        string[] lines = File.ReadAllLines("day1/day1input.txt");

        Dictionary<int, ElfInformation> elves = new();

        int currentElfIndex = 0;
        
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            
            string lineSterilised = line.Trim();

            if (string.IsNullOrEmpty(lineSterilised))
            {
                currentElfIndex++;
                continue;
            };
            
            if (elves.ContainsKey(currentElfIndex))
            {
                elves[currentElfIndex].CaloriesCarried += int.Parse(lineSterilised);
            }
            else
            {
                elves.Add(currentElfIndex, new ElfInformation(elfId: i, caloriesCarried: int.Parse(lineSterilised)));
            }
        }

        List<ElfInformation> sortedByCalories = elves
            .Select(x => x.Value)
            .OrderByDescending(x => x.CaloriesCarried)
            .ToList();

        int sumOfTop3Elves = sortedByCalories[0].CaloriesCarried
                             + sortedByCalories[1].CaloriesCarried
                             + sortedByCalories[2].CaloriesCarried;
        
        return $"Top 3 Elf Calories Carried: {sumOfTop3Elves}";
    }
}

public class ElfInformation
{
    public ElfInformation()
    {
    }

    public ElfInformation(int elfId, int caloriesCarried)
    {
        ElfId = elfId;
        CaloriesCarried = caloriesCarried;
    }

    public int ElfId { get; set; }
    
    public int CaloriesCarried { get; set; }
}