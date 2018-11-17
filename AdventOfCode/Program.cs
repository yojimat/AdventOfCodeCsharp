using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string console = "";

            Console.WriteLine("Projeto dedicado a resolução dos exercícios encontrados no Advent of Code\n(https://adventofcode.com/)\nEscreva o código referente a determinado projeto pra acessar os programas.\n");


            do
            {
                Console.WriteLine("\nLista de Programas:\n");
                Console.WriteLine("-Day2: '2'");
                Console.WriteLine("-Day3: '3'");
                Console.Write("\nCódigo:");
                console = Console.ReadLine();

                switch (console)
                {
                    case "2":
                        AdventOfCode2015.Day2();
                        break;
                    case "3":
                        AdventOfCode2015.Day3();
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
