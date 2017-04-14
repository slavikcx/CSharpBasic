using System;

namespace Sorters
{
    public delegate void PrintingFinishedEventHandler(object obj, EventArgs e);

    public class Printer //arrayPrinter
    {
        private static object lockObject = new object();
        public event PrintingFinishedEventHandler PrintingFinished;

        //add printer method with sorter name and time


        public void Print(int[,] array2d)
        {
            lock (lockObject)
            {

                PrintArray(array2d);

            }

        }


        public void Print(int[,] array2d, object source , TimeSpan sortingTime)
        {
            lock (lockObject)
            {
                Console.WriteLine("Sorted array with {0} \n", source);
                Console.WriteLine("Sorting time: {0} \n", sortingTime); //displaying sorting time

                PrintArray(array2d);

            }

            OnPrintingFinished();
        }
    

        protected void PrintArray(int[,] array2d)
        {
            lock (lockObject)
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


        protected virtual void OnPrintingFinished()
        {
            if (PrintingFinished != null)
            {
                PrintingFinished(this, EventArgs.Empty);
            }
        }
    }
}
