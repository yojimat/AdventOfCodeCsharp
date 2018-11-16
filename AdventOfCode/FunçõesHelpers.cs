using System;

namespace AdventOfCode
{
    static class FunçõesHelpers
    {
        static public int AreaPapelPlus(int l, int w, int h)
        {
            int area=0, arealadomenor=0;

            area = (2 * l * w) + (2 * w * h) + (2 * h * l);
            arealadomenor = Math.Min(l * w, Math.Min(w * h, h * l));
            area += arealadomenor;
            Console.WriteLine("Area: {0}", area);

            return area;
        }

        static public int QntRibbon (int l, int w, int h)
        {
            int areaRibbon=0, volumeRibbon=0;

            areaRibbon = Math.Min(l + l + w + w, Math.Min(h + h + w + w, h + h + l + l));
            volumeRibbon = l * w * h;
            areaRibbon += volumeRibbon;
            Console.WriteLine("Comprimento do Laço: {0}", areaRibbon);

            return areaRibbon;
        }
    }
}
