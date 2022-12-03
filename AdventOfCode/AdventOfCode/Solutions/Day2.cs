using AdventOfCode.Framework;

namespace AdventOfCode.Solutions;

/// <summary>
/// https://adventofcode.com/2022/day/2
/// </summary>
[Solution(2)]
[SolutionInput("Input2.txt")]
public class Solution2 : Solution
{
    private readonly Dictionary<char, GamePlay> playToScore = new()
    {
        { 'A', GamePlay.Rock }, 
        { 'B', GamePlay.Paper }, 
        { 'C', GamePlay.Scissors }, 
        { 'X', GamePlay.Rock }, 
        { 'Y', GamePlay.Paper }, 
        { 'Z', GamePlay.Scissors }, 
    };

    private readonly List<GamePlay> gamePlaysOrderedByResults = new()
    {
        GamePlay.Rock, 
        GamePlay.Paper, 
        GamePlay.Scissors, 
    };
    
    private Input input;
    
    public Solution2(Input input) : base(input)
    {
        this.input = input;
    }
    
    /// <inheritdoc />
    protected override string Problem1()
    {
        int totalScore = 0;

        foreach (string line in this.input.Lines)
        {
            string[] plays = line.Split(" ");

            GamePlay opponentPlay = playToScore[plays[0][0]];
            GamePlay myPlay = playToScore[plays[1][0]];

            int score = (int)myPlay + CalculateResultScore(opponentPlay, myPlay);

            totalScore += score;
        }
        
        return totalScore.ToString();
    }
    
    /// <inheritdoc />
    protected override string Problem2()
    {
        int totalScore = 0;

        foreach (string line in this.input.Lines)
        {
            string[] plays = line.Split(" ");
            
            GamePlay opponentPlay = playToScore[plays[0][0]];

            GamePlay? myPlay = plays[1][0] switch
            {
                'X' => gamePlaysOrderedByResults[((int)opponentPlay + 1) % 3], // lose
                'Y' => gamePlaysOrderedByResults[((int)opponentPlay + 2) % 3], // draw
                'Z' => gamePlaysOrderedByResults[(int)opponentPlay % 3],       // win
                _ => null
            };

            int score = (int)myPlay + CalculateResultScore(opponentPlay, (GamePlay)myPlay);

            totalScore += score;
        }
        
        return totalScore.ToString();
    }
    
    private int CalculateResultScore(GamePlay opponentPlay, GamePlay myPlay)
    {
        if (opponentPlay == myPlay)
        {
            return 3;
        }

        GamePlay winningPlay = gamePlaysOrderedByResults[(int)opponentPlay % 3];

        return myPlay == winningPlay ? 6 : 0;
    }
}

public enum GamePlay
{
    Rock = 1,
    Paper = 2,
    Scissors = 3,
}