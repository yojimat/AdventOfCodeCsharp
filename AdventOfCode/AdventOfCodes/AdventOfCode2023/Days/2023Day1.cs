using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCodes.AdventOfCode2023.Days;

public static partial class _2023Day1
{
    public static void ExecuteProgram()
    {
        Console.WriteLine("See the Challenge at https://adventofcode.com/2023/day/1");
        // I can make a loop iterating through the input and adding the numbers to a list
        // When found a number I can save this number in a tuple of two integers 
        // If I cannot find the second number, I repeat the second number
        // Then I sum the numbers in each tuple of the list

        const string url = "https://adventofcode.com/2023/day/1/input";
        byte[] buffer;

        using (var client = new HttpClient())
        {
            // REMEMBER TO ADD THE YOUR COOKIE from the request header found in the developer tools of your browser
            client.DefaultRequestHeaders.Add("Cookie", "");
            buffer = client.GetByteArrayAsync(url).Result;
        }

        var text = Encoding.UTF8.GetString(buffer);
        var textSeparatedInLines = text.Split('\n');
        var sum = 0;

        foreach (var line in textSeparatedInLines)
        {
            var textOfLine = line.Trim();

            // Second part of the puzzle function, with positive lookahead to find overlapping words like "twone"
            var transformedLine = TransformWordNumberInNumbersRegex(textOfLine);

            var digitsFound = transformedLine.Where(char.IsDigit);
            var wholeNumber = digitsFound.Aggregate("", (current, digit) => current + digit);
            var number = wholeNumber;

            switch (number.Length)
            {
                case 0:
                    continue;
                case 1:
                    number += number;
                    break;
            }

            if (number.Length > 2)
            {
                var firstDigit = number[0];
                var lastDigit = number[^1];
                number = string.Concat(firstDigit, lastDigit);
            }

            Console.WriteLine($"The number found is {number}");
            sum += int.Parse(number);
        }

        Console.WriteLine($"The sum of the items found is: {sum}");
    }

    private static string TransformWordNumberInNumbersRegex(string line)
    {
        var result = TransformWordNumberRegex().Replace(line, match =>
        {
            // I think changing in some way the regex pattern this can be done better.
            var number = match.Groups[1].Value switch
            {
                "one" => "1",
                "two" => "2",
                "three" => "3",
                "four" => "4",
                "five" => "5",
                "six" => "6",
                "seven" => "7",
                "eight" => "8",
                "nine" => "9",
                _ => throw new Exception("Unexpected value")
            };

            return number;
        });
        return result;
    }

    [GeneratedRegex("(?=(one|two|three|four|five|six|seven|eight|nine))", RegexOptions.IgnoreCase | RegexOptions.Singleline)]
    private static partial Regex TransformWordNumberRegex();
}
