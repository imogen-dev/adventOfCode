namespace AdventOfCode.day2;

public class Day2
{
    private static Dictionary<char, GamePlay> playToScore = new()
    {
        { 'A', GamePlay.Rock }, 
        { 'B', GamePlay.Paper }, 
        { 'C', GamePlay.Scissors }, 
        { 'X', GamePlay.Rock }, 
        { 'Y', GamePlay.Paper }, 
        { 'Z', GamePlay.Scissors }, 
    };

    private List<GamePlay> gamePlaysOrderedByResults = new()
    {
        GamePlay.Rock, 
        GamePlay.Paper, 
        GamePlay.Scissors, 
    };
    
    private int CalculateResultScore(GamePlay opponentPlay, GamePlay myPlay)
    {
        if (opponentPlay == myPlay)
        {
            return 3;
        }

        GamePlay winningPlay = gamePlaysOrderedByResults[(int)opponentPlay % 3];

        return myPlay == winningPlay ? 6 : 0;
    }
    
    public string SolveQuestionOne()
    {
        string[] lines = File.ReadAllLines("day2/day2input.txt");

        int totalScore = 0;

        foreach (string line in lines)
        {
            string[] plays = line.Split(" ");

            GamePlay opponentPlay = playToScore[plays[0][0]];
            GamePlay myPlay = playToScore[plays[1][0]];

            int score = (int)myPlay + CalculateResultScore(opponentPlay, myPlay);

            totalScore += score;
        }
        
        return $"Total Score: {totalScore}";
    }
    
    public string SolveQuestionTwo()
    {
        string[] lines = File.ReadAllLines("day2/day2input.txt");

        int totalScore = 0;

        foreach (string line in lines)
        {
            string[] plays = line.Split(" ");
            
            GamePlay opponentPlay = playToScore[plays[0][0]];
            GamePlay? myPlay = null;
            
            switch (plays[1][0])
            {
                case 'X': // lose
                    myPlay = gamePlaysOrderedByResults[((int)opponentPlay + 1) % 3];
                    break;
                case 'Y':
                    myPlay = gamePlaysOrderedByResults[((int)opponentPlay + 2) % 3];
                    break;
                case 'Z':
                    myPlay = gamePlaysOrderedByResults[(int)opponentPlay % 3];
                    break;
            }
            
            int score = (int)myPlay + CalculateResultScore(opponentPlay, (GamePlay)myPlay);

            totalScore += score;
        }
        
        return $"Total Score: {totalScore}";
    }
}

public enum GamePlay
{
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}