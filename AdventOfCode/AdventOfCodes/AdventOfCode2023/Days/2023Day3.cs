using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCodes.AdventOfCode2023.Days;

public static partial class _2023Day3
{
    private static int _sumOfPartNumbers;
    private static string[] _lines;

    public static void ExecuteProgram()
    {
        Console.WriteLine("See the Challenge at https://adventofcode.com/2023/day/3");
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2023Day3Input.txt");
        _lines = File.ReadAllLines(filePath);
        for (var index = 0; index < _lines.Length; index++)
        {
            var line = _lines[index];
            Solution(line, index);
        }

        Console.WriteLine($"The sum of part numbers {_sumOfPartNumbers}");// 76536 91830 332815 591377
    }

    private static void Solution(string line, int lineIndex)
    {
        var matches = FindNumberAdjacentToSymbols().Matches(line);
        foreach (var match in matches.Cast<Match>())
        {
            var partNumberUnprocessed = match.Groups[1].Value;
            var matchIndex = match.Groups[1].Index + 1; // The index of the number start at the index + 1.
            var matchLength = match.Groups[1].Length - 2; // This -2 is the two chars captured by the regex.
            // Get length of the number as offset starting from the index + 1.
            // For each index verify if the index "below", "above" and "diagonal" are symbols.
            // To get the index "below" I can use the same index from the line bellow, and the same for the index "above".
            // To get diagonal I can use the index + 1 or index - 1 from the line bellow or above.
            // Optionally I can break the process if the symbol was found.
            // Take care with the first one and the last one because they don't have "above" and "bellow" respectively.
            //if (partNumberUnprocessed == ".125.") Console.WriteLine("Found");
            if (!TryProcessPartNumberSides(partNumberUnprocessed, out var partNumber) &&
                !TryProcessPartNumberUpDownDimensions(lineIndex, matchIndex, matchLength) &&
                !TryProcessPartNumberDiagonals(lineIndex, matchIndex, matchLength))
                continue;

            _sumOfPartNumbers += partNumber;
        }

        matches = FindInitialNumbers().Matches(line);

        foreach (var match in matches.Cast<Match>())
        {
            var partNumberUnprocessed = "." + match.Value;
            var matchIndex = match.Index;
            var matchLength = match.Length - 1; // This -1 is the two chars captured by the regex.
            if (!TryProcessPartNumberSides(partNumberUnprocessed, out var partNumber) &&
                !TryProcessPartNumberUpDownDimensions(lineIndex, matchIndex, matchLength) &&
                !TryProcessPartNumberDiagonals(lineIndex, matchIndex, matchLength))
                continue;

            _sumOfPartNumbers += partNumber;
        }

        matches = FindFinalNumbers().Matches(line);

        foreach (var match in matches.Cast<Match>())
        {
            var partNumberUnprocessed = match.Value + ".";
            var matchIndex = match.Index + 1; // The index of the number start at the index + 1.
            var matchLength = match.Length - 1; // This -1 is the two chars captured by the regex.
            if (!TryProcessPartNumberSides(partNumberUnprocessed, out var partNumber) &&
                !TryProcessPartNumberUpDownDimensions(lineIndex, matchIndex, matchLength) &&
                !TryProcessPartNumberDiagonals(lineIndex, matchIndex, matchLength))
                continue;

            _sumOfPartNumbers += partNumber;
        }
    }

    private static bool TryProcessPartNumberDiagonals(int lineIndex, int matchIndex, int matchLength)
    {
        var lineAbove = lineIndex - 1 < 0 ? "" : _lines[lineIndex - 1];
        var lineBellow = lineIndex + 1 >= _lines.Length ? "" : _lines[lineIndex + 1];
        var remainingNumbers = 0;
        var isPartNumber = false;

        while (!isPartNumber && remainingNumbers < matchLength)
        {
            if (IsPartNumberByDiagonalAfter(matchIndex, lineAbove, remainingNumbers))
                isPartNumber = true;

            if (IsPartNumberByDiagonalBefore(matchIndex, lineAbove, remainingNumbers))
                isPartNumber = true;

            if (IsPartNumberByDiagonalAfter(matchIndex, lineBellow, remainingNumbers))
                isPartNumber = true;

            if (IsPartNumberByDiagonalBefore(matchIndex, lineBellow, remainingNumbers))
                isPartNumber = true;

            remainingNumbers++;
        }

        return isPartNumber;

    }

    private static bool IsPartNumberByDiagonalAfter(int matchIndex, string line, int remainingNumbers)
    {
        var isNotStringEmpty = !string.IsNullOrEmpty(line);
        if (!isNotStringEmpty) return false;

        var isInsideRangeIndex = matchIndex + remainingNumbers + 1 < line.Length;
        if (!isInsideRangeIndex) return false;

        var isNotDigit = !char.IsDigit(line[matchIndex + remainingNumbers + 1]);
        var isNotDot = line[matchIndex + remainingNumbers + 1] != '.';

        return isNotDigit && isNotDot;
    }

    private static bool IsPartNumberByDiagonalBefore(int matchIndex, string line, int remainingNumbers)
    {
        var isNotStringEmpty = !string.IsNullOrEmpty(line);
        if (!isNotStringEmpty) return false;

        var isInsideRangeIndex = matchIndex + remainingNumbers - 1 > 0;
        if (!isInsideRangeIndex) return false;

        var isNotDigit = !char.IsDigit(line[matchIndex + remainingNumbers - 1]);
        var isNotDot = line[matchIndex + remainingNumbers - 1] != '.';

        return isNotDigit && isNotDot;
    }

    private static bool TryProcessPartNumberUpDownDimensions(int lineIndex, int matchIndex, int matchLength)
    {
        var lineAbove = lineIndex - 1 < 0 ? "" : _lines[lineIndex - 1];
        var lineBellow = lineIndex + 1 >= _lines.Length ? "" : _lines[lineIndex + 1];
        var remainingNumbers = 0;
        var isPartNumber = false;

        while (!isPartNumber && remainingNumbers < matchLength)
        {
            if (!string.IsNullOrEmpty(lineAbove) &&
                !char.IsDigit(lineAbove[matchIndex + remainingNumbers]) &&
                lineAbove[matchIndex + remainingNumbers] != '.') isPartNumber = true;

            if (!string.IsNullOrEmpty(lineBellow) &&
                !char.IsDigit(lineBellow[matchIndex + remainingNumbers]) &&
                lineBellow[matchIndex + remainingNumbers] != '.')
                isPartNumber = true;

            remainingNumbers++;
        }

        return isPartNumber;
    }

    private static bool TryProcessPartNumberSides(string partNumberUnprocessed, out int partNumber)
    {
        var firstChar = partNumberUnprocessed[0];
        var lastChar = partNumberUnprocessed[^1];
        partNumber = int.Parse(partNumberUnprocessed[1..^1]);

        return firstChar != '.' || lastChar != '.';
    }

    [GeneratedRegex(@"(?=(\D\d+\D))")]
    private static partial Regex FindNumberAdjacentToSymbols();

    [GeneratedRegex(@"^\d+\D")]
    private static partial Regex FindInitialNumbers();

    [GeneratedRegex(@"\D\d+$")]
    private static partial Regex FindFinalNumbers();
}
