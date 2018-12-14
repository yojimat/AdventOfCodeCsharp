using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    static class FunctionHelpers
    {
        static public int AreaPapelPlus(int l, int w, int h)
        {
            int area = 0, arealadomenor = 0;

            area = (2 * l * w) + (2 * w * h) + (2 * h * l);
            arealadomenor = Math.Min(l * w, Math.Min(w * h, h * l));
            area += arealadomenor;
            Console.WriteLine("Area: {0}", area);

            return area;
        }

        static public int QntRibbon(int l, int w, int h)
        {
            int areaRibbon = 0, volumeRibbon = 0;

            areaRibbon = Math.Min(l + l + w + w, Math.Min(h + h + w + w, h + h + l + l));
            volumeRibbon = l * w * h;
            areaRibbon += volumeRibbon;
            Console.WriteLine("Comprimento do Laço: {0}", areaRibbon);

            return areaRibbon;
        }

        static public string[] ListaCoordenadas(string coordenadas, int x, int y)
        {
            int i = 1;
            string[] pares = new string[coordenadas.Length + 1];
            pares[0] = "0,0";

            foreach (char ponto in coordenadas)
            {
                switch (ponto)
                {
                    case '<':
                        x += -1;
                        break;
                    case '^':
                        y += 1;
                        break;
                    case '>':
                        x += 1;
                        break;
                    case 'v':
                        y += -1;
                        break;
                    default:
                        break;
                }

                pares[i] = x.ToString() + "," + y.ToString();
                Console.WriteLine(pares[i]);

                i++;
            }

            return pares;
        }

        static public string InsertNumeroSecretKey(string secretKey, long valorAtual)
        {
            int count = 0;
            string valorAtualString;

            StringBuilder novoHash = new StringBuilder();
            foreach (char letra in secretKey)
            {
                novoHash.Append(letra);
                if (++count == 8)
                {
                    valorAtualString = valorAtual.ToString();
                    novoHash.Insert(8, valorAtualString, 1);
                }
            }

            return novoHash.ToString();
        }

        static public string HexaHashMD5(string secretKeyModificado)
        {
            // Use input string to calculate MD5 hash
            byte[] inputBytes = Encoding.ASCII.GetBytes(secretKeyModificado);
            byte[] hashBytes = MD5.Create().ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        static public bool verificarvogais(string linha)
        {
            char[] caracteres = linha.ToCharArray();
            int qntvogais = 0;

            foreach (char letra in caracteres)
            {
                switch (letra)
                {
                    case 'a':
                        qntvogais++;
                        break;
                    case 'e':
                        qntvogais++;
                        break;
                    case 'i':
                        qntvogais++;
                        break;
                    case 'o':
                        qntvogais++;
                        break;
                    case 'u':
                        qntvogais++;
                        break;
                    default:
                        break;
                }
            }

            if (qntvogais >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool verificarRepeticao(string linha)
        {
            char[] caracteres = linha.ToCharArray();
            bool repetiu = false;

            for (int i = 0; i < caracteres.Length - 1; i++)
            {
                if (caracteres[i] == caracteres[i + 1])
                {
                    repetiu = true;
                }
            }

            return repetiu;
        }

        static public bool verificarDuplaRepeticao(string linha)
        {
            char[] caracteres = linha.ToCharArray();
            List<string> pares = new List<string>();
            bool parDeRepeticao = false;
            string par;

            for (int i = 0; i < caracteres.Length - 1; i++)
            {
                if (i == 0)
                {
                    par = linha.Substring(i, 2);
                    pares.Add(par);
                } else
                {
                    if (caracteres[i] != caracteres[i-1])
                    {
                        par = linha.Substring(i, 2);
                        pares.Add(par);
                    }
                }
                // Outra solução
                //par = linha.Substring(i, 2);
                //if (linha.IndexOf(par, i + 2) != -1)
                //{
                //    return true;
                //}
            }
            if (pares.Distinct().Count() < pares.Count())
            {
                parDeRepeticao = true;
            }

            return parDeRepeticao;
        }

        static public bool verificarRepeticaoNasBeiras(string linha)
        {
            char[] caracteres = linha.ToCharArray();
            bool repetiu = false;

            for (int i = 0; i < caracteres.Length - 2; i++)
            {
                if (caracteres[i] == caracteres[i + 2])
                {
                    repetiu = true;
                }
            }

            return repetiu;
        }
    }
}
