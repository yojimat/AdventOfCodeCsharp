using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.AdventOfCodes.AdventOfCode2023.Days;

public static class _2023Day1
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
            client.DefaultRequestHeaders.Add("Cookie",
                "_ga=GA1.2.1838003819.1701448933; _gid=GA1.2.1637003096.1701448933; session=53616c7465645f5f43eeddb9f69dba63ecbb6006b084652f0f4ea11d462507bfefd39283fbc24889c6fc8974e3e571c9750a03980459492317690ee9f369a56a; _ga_MHSNPJKWC7=GS1.2.1701464582.2.0.1701464582.0.0.0");
            buffer = client.GetByteArrayAsync(url).Result;
        }

        var text = Encoding.UTF8.GetString(buffer);
        var textSeparatedInLines = text.Split('\n');
        var numbers = new List<int>();

        foreach (var line in textSeparatedInLines)
        {
            var textOfLine = line.Trim();
            var digitsFound = textOfLine.Where(char.IsDigit);
            var number = digitsFound.Aggregate("", (current, digit) => current + digit);
            ////if (number.Length == 0)
            //{
                string pattern = @"^one|two|three|four|five|six|seven|eight|nine$";
                foreach (Match match in Regex.Matches(line, pattern))
                {
                    var valueFound = match.Value;
                }
                //bool isNumber = int.TryParse(word, out number);
                number = digitsFound.Aggregate("", (current, digit) => current + digit);
            //}

            if (number.Length == 0) continue;

            if (number.Length == 1)
            {
                number += number;
            }

            if (number.Length > 2)
            {
                var firstDigit = number[0];
                var lastDigit = number[^1];
                number = string.Concat(firstDigit, lastDigit);
            }

            Console.WriteLine($"The number found is {number}");
            numbers.Add(int.Parse(number));
        }

        var sum = numbers.Aggregate(0, (current, number) => current + number);
        Console.WriteLine($"The sum of the items found is: {sum}");
    }

}
