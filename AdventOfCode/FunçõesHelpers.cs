using System;

namespace AdventOfCode
{
    static class FunçõesHelpers
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
    }
}
