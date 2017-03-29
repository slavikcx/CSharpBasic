using System;

namespace Sorters
{
    public static class Printer
    {
        public static void Print(int[,] array2d)
        {
            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    if (array2d[i, j] < 10)
                    {
                        Console.Write("0{0} ", array2d[i, j]);
                    }
                    else
                    {
                        Console.Write("{0} ", array2d[i, j]);
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
