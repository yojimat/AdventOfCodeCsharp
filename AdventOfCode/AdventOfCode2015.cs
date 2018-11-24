using System;
using System.IO;
using System.Linq;

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
            string[] medidas = File.ReadAllLines(@".\inputs2015\inputsParaDay2.txt");

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

        static public void Day3()
        {
            Console.WriteLine("\nPrograma Day 3:\n");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);

            int x = 0, y = 0, presentesUnicos = 0;
            string coordenadas = File.ReadAllText(@".\inputs2015\inputsParaDay3.txt");
            string[] paresUnicos = FunçõesHelpers.ListaCoordenadas(coordenadas, x, y).Distinct().ToArray();

            presentesUnicos += paresUnicos.Length;

            foreach (string par in paresUnicos)
            {
                Console.WriteLine("Unicos:{0}", par);
            }

            Console.WriteLine("Presentes Unicos sem Robô-Santa: {0}.\n", presentesUnicos);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);

            int turno = 0, yNoel = 0, xNoel = 0, yRobo = 0, xRobo = 0, n = 1, r = 1;
            string[] paresNoel = new string[coordenadas.Length / 2 + 1];
            string[] paresRobo = new string[coordenadas.Length / 2 + 1];

            presentesUnicos = 0;
            paresNoel[0] = "0,0"; paresRobo[0] = "0,0";

            foreach (char ponto in coordenadas)
            {
                if (turno == 1)
                {
                    switch (ponto)
                    {
                        case '<':
                            xRobo += -1;
                            break;
                        case '^':
                            yRobo += 1;
                            break;
                        case '>':
                            xRobo += 1;
                            break;
                        case 'v':
                            yRobo += -1;
                            break;
                        default:
                            break;
                    }

                    paresRobo[r] = xRobo.ToString() + "," + yRobo.ToString();
                    Console.WriteLine("Caminho Robô: {0}", paresRobo[r]);

                    r++;
                    turno = 0;
                }
                else if (turno == 0)
                {
                    switch (ponto)
                    {
                        case '<':
                            xNoel += -1;
                            break;
                        case '^':
                            yNoel += 1;
                            break;
                        case '>':
                            xNoel += 1;
                            break;
                        case 'v':
                            yNoel += -1;
                            break;
                        default:
                            break;
                    }

                    paresNoel[n] = xNoel.ToString() + "," + yNoel.ToString();
                    Console.WriteLine("Caminho Noel: {0}", paresNoel[n]);

                    n++;
                    turno = 1;
                }

            }

            string[] paresRoboNoel = paresNoel.Concat(paresRobo).ToArray();
            string[] paresUnicosFinal = paresRoboNoel.Distinct().ToArray();
            presentesUnicos += paresUnicosFinal.Length;

            foreach (string par in paresUnicosFinal)
            {
                Console.WriteLine("Unicos:{0}", par);
            }

            Console.WriteLine("Presentes Unicos com Robô-Santa: {0}.\n", presentesUnicos);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
        }

        static public void Day4()
        {

            Console.WriteLine("\nPrograma Day 4:\n");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
            Console.WriteLine("Itenerando secretKey para 5 zeros...\n");

            string cincozeros, secretKeyModificado, secretKey = "bgvyzdsv";
            long valorAtual = 1;

            do
            {

                secretKeyModificado = FunçõesHelpers.InsertNumeroSecretKey(secretKey, valorAtual);
                cincozeros = FunçõesHelpers.HexaHashMD5(secretKeyModificado).Substring(0, 5);
                valorAtual++;

            } while (cincozeros != "00000");

            Console.WriteLine("A secretKey é: {0}\n", secretKey);
            Console.WriteLine("A secretKey modificada para 5 zeros inicias no hash é: {0}\n", secretKeyModificado);
            Console.WriteLine("Itenerando secretKey para 6 zeros...\n");
            valorAtual = 1;

            do
            {

                secretKeyModificado = FunçõesHelpers.InsertNumeroSecretKey(secretKey, valorAtual);
                cincozeros = FunçõesHelpers.HexaHashMD5(secretKeyModificado).Substring(0, 6);
                valorAtual++;
            } while (cincozeros != "000000");

            Console.WriteLine("A secretKey modificada para 6 zeros inicias no hash é: {0}\n", secretKeyModificado);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
        }
    }
}
