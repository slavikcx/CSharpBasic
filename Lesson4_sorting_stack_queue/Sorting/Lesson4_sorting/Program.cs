using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10;
            
            int[] array = new int[arraySize]; // creating array
            Random rnd = new Random();

            Console.Write("Initial array - ");
            for (int i = 0; i<arraySize; i++) // filling aray with random values
            {
                array[i] = rnd.Next(100);
            }

            Print(array);

            char pressed = '0';

            Console.WriteLine("How do you want to sort this array?");
            Console.WriteLine("b - Bubble sorting");
            Console.WriteLine("i - Insertion sorting");

            while (pressed != 'b' && pressed != 'i') //checking for correct char
            {

                pressed =  Convert.ToChar(Console.ReadLine());
                switch (pressed)
                {
                    case 'b':
                        BubleSort(array);
                        Console.Write("Bubble sorted array - ");
                        Print(array);
                        break;

                    case 'i':
                        InsertionSort(array);
                        Console.Write("Insertion sorted array - ");
                        Print(array);
                        break;

                    default:
                        Console.WriteLine("Please press <b> or <i>");
                        break;
                }
            }

            Console.ReadKey();
        }

        //Swap method
        static int[] Swap (int[] array, int index1, int index2)
        {
            int temp = 0;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            
            return array;
        }
           
        //Array printing method
        static void Print (int[] array)
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        // Bubble sorting
        static void BubleSort(int[] array)
        {
            bool isSwapped;
            do
            {
               isSwapped = false;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                        isSwapped = true;
                    }
                }
            } while (isSwapped);
        }

        //insertion sorting
        static void InsertionSort (int[] array)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j + 1] < array[j])
                {
                    Swap(array, j, j + 1);

                    for (int i = j; i > 0; i--)
                    {
                        if (array[i] < array[i - 1])
                        {
                            Swap(array, i, i - 1);
                        }
                    }
                }
            }
        }
    }
}
