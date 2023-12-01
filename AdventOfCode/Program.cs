using System;
using AdventOfCode.AdventOfCodes;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto dedicado a resolução dos exercícios encontrados no Advent of Code\n(https://adventofcode.com/)\nEscreva o código referente a determinado projeto pra acessar os programas.\n");

            do
            {
                Console.WriteLine("\nLista de Programas de 2015:\n");
                Console.WriteLine("-Day X: 'x'");
                Console.Write("\nCódigo:");
                var console = Console.ReadLine();

                switch (console)
                {
                    case "2":
                        AdventOfCode2015.Day2();
                        break;
                    case "3":
                        AdventOfCode2015.Day3();
                        break;
                    case "4":
                        AdventOfCode2015.Day4();
                        break;
                    case "5":
                        AdventOfCode2015.Day5();
                        break;
                    case "6":
                        AdventOfCode2015.Day6();
                        break;
                    case "7":
                        AdventOfCode2015.Day7();
                        break;
                    default:
                        Console.WriteLine("Não encontrado.\n");
                        break;
                }

                Console.WriteLine("Aperte ESC para sair.Se quiser ver mais progamas qualquer tecla para continuar.\n");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
