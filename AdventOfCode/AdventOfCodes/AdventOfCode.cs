using System;

namespace AdventOfCode.AdventOfCodes;

public class AdventOfCode(IAdventOfCode adventOfCode)
{
    public void Run()
    {
        do
        {
            Console.WriteLine("-Day X: 'x'");
            Console.Write("\nCódigo:");
            var console = Console.ReadLine();
            try
            {

                switch (console)
                {
                    case "1":
                        adventOfCode.Day1();
                        break;
                    case "2":
                        adventOfCode.Day2();
                        break;
                    case "3":
                        adventOfCode.Day3();
                        break;
                    case "4":
                        adventOfCode.Day4();
                        break;
                    case "5":
                        adventOfCode.Day5();
                        break;
                    case "6":
                        adventOfCode.Day6();
                        break;
                    case "7":
                        adventOfCode.Day7();
                        break;
                    default:
                        Console.WriteLine("Não encontrado.\n");
                        break;
                }

            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Não implementado.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Aperte ESC para sair. Se quiser ver mais progamas qualquer tecla para continuar.\n");

        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
