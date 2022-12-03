// See https://aka.ms/new-console-template for more information

using AdventOfCode.day1;
using AdventOfCode.day2;

Console.WriteLine("Hello, Advent Of Code!");

Day1 day1 = new();

Console.WriteLine($"Day 1 solution one: {day1.SolveQuestionOne()}");
Console.WriteLine($"Day 1 solution two: {day1.SolveQuestionTwo()}");


Day2 day2 = new();
Console.WriteLine($"Day 2 solution one: {day2.SolveQuestionOne()}");
Console.WriteLine($"Day 2 solution two: {day2.SolveQuestionTwo()}");
