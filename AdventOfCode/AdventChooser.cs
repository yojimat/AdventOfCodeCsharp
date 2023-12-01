using System;
using AdventOfCode.AdventOfCodes;
using AdventOfCode.AdventOfCodes.AdventOfCode2023;

namespace AdventOfCode;

public static class AdventChooser
{
    public static void Start()
    {
        Console.WriteLine(
            "Projeto dedicado a resolução dos exercícios encontrados no Advent of Code\n(https://adventofcode.com/)\nEscreva o código referente a determinado projeto pra acessar os programas.\n");
        Console.WriteLine("Escolha um ano:");
        Console.WriteLine("2015, 2023");
        var adventOfCode = new AdventOfCodes.AdventOfCode(ChooseYear());
        adventOfCode.Run();
    }

    private static IAdventOfCode ChooseYear()
    {
        var consoleInput = Console.ReadLine();
        IAdventOfCode adventOfCode = null;

        while (adventOfCode is null)
        {
            adventOfCode = consoleInput switch
            {
                "2015" => new AdventOfCode2015(),
                "2023" => new AdventOfCode2023(),
                _ => null
            };

            if(adventOfCode == null) Console.WriteLine("Não encontrado.\n");
        }

        return adventOfCode; // Ano não chega a ser nulo, mas o compilador não sabe disso.
    }
}

