using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
                areaPresente = FunctionHelpers.AreaPapelPlus(largura, comprimento, altura);
                areaTodosPresentes += areaPresente;

                //Parte 2
                areaRibbon = FunctionHelpers.QntRibbon(largura, comprimento, altura);
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
            string[] paresUnicos = FunctionHelpers.ListaCoordenadas(coordenadas, x, y).Distinct().ToArray();

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

                secretKeyModificado = FunctionHelpers.InsertNumeroSecretKey(secretKey, valorAtual);
                cincozeros = FunctionHelpers.HexaHashMD5(secretKeyModificado).Substring(0, 5);
                valorAtual++;

            } while (cincozeros != "00000");

            Console.WriteLine("A secretKey é: {0}\n", secretKey);
            Console.WriteLine("A secretKey modificada para 5 zeros inicias no hash é: {0}\n", secretKeyModificado);
            Console.WriteLine("Itenerando secretKey para 6 zeros...\n");
            valorAtual = 1;

            do
            {

                secretKeyModificado = FunctionHelpers.InsertNumeroSecretKey(secretKey, valorAtual);
                cincozeros = FunctionHelpers.HexaHashMD5(secretKeyModificado).Substring(0, 6);
                valorAtual++;
            } while (cincozeros != "000000");

            Console.WriteLine("A secretKey modificada para 6 zeros inicias no hash é: {0}\n", secretKeyModificado);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
        }

        static public void Day5()
        {
            Console.WriteLine("\nPrograma Day 5:\n");
            Console.WriteLine("Começando:");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);

            string[] input = File.ReadAllLines("./inputs2015/inputsParaDay5.txt");
            int nicestrings = 0;

            foreach (string line in input)
            {
                if (line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy"))
                {
                    Console.WriteLine("Bad string");
                }
                else if (FunctionHelpers.verificarvogais(line))
                {
                    Console.WriteLine("Good, Tem mais de 3 vogais.");
                    if (FunctionHelpers.verificarRepeticao(line))
                    {
                        Console.WriteLine("Nice string!");
                        nicestrings++;
                    }
                    else
                    {
                        Console.WriteLine("Not so good string T-T");
                    }
                }
                else
                {
                    Console.WriteLine("Bad string");
                }
            }

            Console.WriteLine("O input tem {0} nice strings\n", nicestrings);
            Console.WriteLine("Segunda Parte: Mudanças das regras de nice string.");
            Console.ReadKey();

            nicestrings = 0;

            foreach (string line in input)
            {
                if (FunctionHelpers.verificarDuplaRepeticao(line) && FunctionHelpers.verificarRepeticaoNasBeiras(line))
                {
                    Console.WriteLine("Good.");
                    nicestrings++;
                }
                else
                {
                    Console.WriteLine("Bad string");
                }
            }

            Console.WriteLine("O input novo tem {0} nice strings\n", nicestrings);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey(true);
        }

        static public void Day6()
        {
            Console.WriteLine("\nPrograma Day 6:\n");
            Console.WriteLine("Começando:");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey();

            string[] comandos = File.ReadAllLines("./inputs2015/inputsParaDay6.txt");
            int luzesAcesas = 0;
            int[,] grid = new int[1000, 1000];

            foreach (string cmd in comandos)
            {
                if (cmd.Contains("turn on"))
                {
                    //string resultString = string.Join(",", Regex.Matches(linha, @"\d+").OfType<Match>().Select(m => m.Value));
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {

                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                grid[linhas, colunas] = 1;
                            }
                        }
                    }
                }
                else if (cmd.Contains("turn off"))
                {
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {
                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                grid[linhas, colunas] = 0;
                            }
                        }
                    }
                }
                else if (cmd.Contains("toggle"))
                {
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {

                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                if (grid[linhas, colunas] == 0)
                                {
                                    grid[linhas, colunas] = 1;
                                }
                                else if (grid[linhas, colunas] == 1)
                                {
                                    grid[linhas, colunas] = 0;
                                }
                            }
                        }
                    }
                }
            }

            foreach (int luz in grid)
            {
                if (luz == 1)
                {
                    luzesAcesas++;
                    Console.WriteLine("Acendeu");
                }
            }

            Console.WriteLine("A quantidade de luzes que ficaram acesas depois dos comandos foi:{0}", luzesAcesas);
            Console.WriteLine("Segunda Parte do Desafio: Brilho das luzes.");
            Console.ReadKey();

            int[,] gridBrilho = new int[1000, 1000];
            int brilhoTotal = 0;

            foreach (string cmd in comandos)
            {
                if (cmd.Contains("turn on"))
                {
                    //string resultString = string.Join(",", Regex.Matches(linha, @"\d+").OfType<Match>().Select(m => m.Value));
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {
                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                gridBrilho[linhas, colunas] += 1;
                            }
                        }
                    }
                }
                else if (cmd.Contains("turn off"))
                {
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {
                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                if (gridBrilho[linhas, colunas] > 0)
                                {
                                    gridBrilho[linhas, colunas] -= 1;
                                }
                            }
                        }
                    }
                }
                else if (cmd.Contains("toggle"))
                {
                    int l1 = 0, l2 = 0, c1 = 0, c2 = 0, i = 0;

                    foreach (var numeros in Regex.Matches(cmd, @"\d+").OfType<Match>())
                    {

                        switch (i)
                        {
                            case 0:
                                l1 = int.Parse(numeros.Value);
                                break;
                            case 1:
                                c1 = int.Parse(numeros.Value);
                                break;
                            case 2:
                                l2 = int.Parse(numeros.Value);
                                break;
                            case 3:
                                c2 = int.Parse(numeros.Value);
                                break;
                            default:
                                break;
                        }
                        i++;
                    }

                    for (int linhas = 0; linhas <= 999; linhas++)
                    {
                        for (int colunas = 0; colunas <= 999; colunas++)
                        {
                            if (linhas >= l1 && linhas <= l2 && colunas >= c1 && colunas <= c2)
                            {
                                gridBrilho[linhas, colunas] += 2;
                            }
                        }
                    }
                }
                Console.WriteLine("Brilho Alterado.");
            }

            foreach (int brilho in gridBrilho)
            {
                brilhoTotal += brilho;
            }

            Console.WriteLine("O brilho total ficou em: {0}\n", brilhoTotal);
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey();
        }

        static public void Day7()
        {
            Console.WriteLine("\nPrograma Day 7:\n");
            Console.WriteLine("Começando: ");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey();

            string[] cmd = File.ReadAllLines("./inputs2015/inputsParaDay7.txt");

            IDictionary<string, Func<ushort>> listaChaves = new Dictionary<string, Func<ushort>>();
            IDictionary<string, ushort> valores = new Dictionary<string, ushort>();

            foreach (string comando in cmd)
            {

                string[] partes = comando.Split(' ');
                string output = partes[partes.Length - 1];

                switch (partes.Length)
                {
                    case 3:
                        ushort val;
                        if (ushort.TryParse(partes[0], out val))
                        {
                            listaChaves.Add(output, () => val);
                            valores.Add(output, val);
                        }
                        else
                        {
                            listaChaves.Add(output, () => {
                                if (valores.ContainsKey(output))
                                    return valores[output];
                                else
                                {
                                    ushort res = listaChaves[partes[0]].Invoke();
                                    valores.Add(output, res);
                                    return res;
                                }
                            });
                        }
                        break;
                    case 4:
                        listaChaves.Add(output, () => (ushort)(~listaChaves[partes[1]].Invoke()));
                        break;
                    case 5:
                        switch (partes[1])
                        {
                            case "AND":
                                listaChaves.Add(output, () =>
                                {
                                    if (valores.ContainsKey(output))
                                        return valores[output];
                                    else
                                    {
                                        ushort res = (ushort)((ushort.TryParse(partes[0], out val) ? val : listaChaves[partes[0]].Invoke()) & listaChaves[partes[2]].Invoke());
                                        valores.Add(output, res);
                                        return res;
                                    }
                                });
                                break;
                            case "OR":
                                listaChaves.Add(output, () =>
                                {
                                    if (valores.ContainsKey(output))
                                        return valores[output];
                                    else
                                    {
                                        ushort res = (ushort)((ushort.TryParse(partes[0], out val) ? val : listaChaves[partes[0]].Invoke()) | listaChaves[partes[2]].Invoke());
                                        valores.Add(output, res);
                                        return res;
                                    }
                                });
                                break;
                            case "LSHIFT":
                                listaChaves.Add(output, () =>
                                {
                                    if (valores.ContainsKey(output))
                                        return valores[output];
                                    else
                                    {
                                        ushort res = (ushort)(listaChaves[partes[0]].Invoke() << int.Parse(partes[2]));
                                        valores.Add(output, res);
                                        return res;
                                    }
                                });
                                break;
                            case "RSHIFT":
                                listaChaves.Add(output, () =>
                                {
                                    if (valores.ContainsKey(output))
                                        return valores[output];
                                    else
                                    {
                                        ushort res = (ushort)(listaChaves[partes[0]].Invoke() >> int.Parse(partes[2]));
                                        valores.Add(output, res);
                                        return res;
                                    }
                                });
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine("Parte 1");
            Console.WriteLine("Sinal/Output do fio A é:");
            Console.WriteLine(listaChaves["a"].Invoke());

            ushort outputA = listaChaves["a"].Invoke();
            listaChaves["b"] = () => outputA;
            valores.Clear();
            valores["b"] = outputA;

            Console.WriteLine("Parte 2");
            Console.WriteLine("Sinal/Output do fio A, depois de tudo resetado, e B com o valor anterior de A é:");
            Console.WriteLine(listaChaves["a"].Invoke());
            Console.WriteLine("Depois de vários dias tentando fazer, sem resolução, dedico esse resposta no git para o usuario JeffJankowski(https://www.reddit.com/user/JeffJankowski) do reddit, obrigado pela esclarecimento!!\n");
            Console.Write("Aperte qualquer tecla para continuar.\n");
            Console.ReadKey();
        }
    }
}
