using System;
using System.IO;

namespace AdventOfCode
{
    class AdventOfCode2015
    {
        static public void Day2()
        {
            Console.WriteLine("\nPrograma Day 2:\n");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);

            int largura=0, comprimento=0, altura=0, areaPresente=0,areaTodosPresentes=0, areaRibbon=0, areasRibbons=0;

            string[] medidas = File.ReadAllLines(@".\inputsParaDay2.txt");

            foreach (string medida in medidas)
            {
                Console.WriteLine("Medida: {0}", medida);

                string[] lwh = medida.Split(new char[] { 'x' });
                largura = int.Parse(lwh[0]);
                comprimento = int.Parse(lwh[1]);
                altura = int.Parse(lwh[2]);
                areaPresente = FunçõesHelpers.AreaPapelPlus(largura, comprimento, altura);
                areaTodosPresentes += areaPresente;

                //Parte 2
                areaRibbon = FunçõesHelpers.QntRibbon(largura, comprimento, altura);
                areasRibbons += areaRibbon;
            }

            Console.WriteLine("A quantidade de papel usada é : {0}\n", areaTodosPresentes);
            Console.WriteLine("A quantidade de laço usada é : {0}\n", areasRibbons);

            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
        }
    }
}
