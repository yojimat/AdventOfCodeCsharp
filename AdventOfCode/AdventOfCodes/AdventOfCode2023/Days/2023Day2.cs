using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCodes.AdventOfCode2023.Days;

public static partial class _2023Day2
{
    private static readonly Dictionary<string, int> Cubes = new()
    {
        {"red", 12},
        {"green" , 13},
        {"blue" , 14}
    };

    private static int _sumOfValidGames;

    public static void ExecuteProgram()
    {
        Console.WriteLine("See the Challenge at https://adventofcode.com/2023/day/2");
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Day2Input.txt");
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            Solution(line);
        }
        Console.WriteLine($"The sum of the valid games is {_sumOfValidGames}");
    }

    private static void Solution(string line)
    {
        var splitAtTwoDots = line.Split(':');
        var gameIndex = splitAtTwoDots[0].Trim().Split(" ").Last();
        var setOfCubes = splitAtTwoDots[1].Trim().Split(';');
        var validGame = true;

        foreach (var set in setOfCubes)
        {
            var matches = FindNumberAndColors().Matches(set);

            foreach (var match in matches.Cast<Match>())
            {
                var color = match.Groups[2].Value;
                var number = int.Parse(match.Groups[1].Value);
                if (Cubes[color] >= number) continue;
                Console.WriteLine($"Game {gameIndex} is impossible");
                validGame = false;
            }

        }

        if (validGame) _sumOfValidGames += int.Parse(gameIndex);
    }

    [GeneratedRegex(@"(\d+)\s(\w+)")]
    private static partial Regex FindNumberAndColors();
}
