using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10;

            int[] array = new int[arraySize]; // creating array
            Random rnd = new Random();

            Console.Write("Initial array - ");
            for (int i = 0; i < arraySize; i++) // filling aray with random values
            {
                array[i] = rnd.Next(100);
            }

            BubbleSorter bubbleSortingArray = new BubbleSorter(array);
            InsertionSorter insertSortingArray = new InsertionSorter(array);

            bubbleSortingArray.Print();

            char pressed = '0';

            Console.WriteLine("How do you want to sort this array?");
            Console.WriteLine("b - Bubble sorting");
            Console.WriteLine("i - Insertion sorting");

            while (pressed != 'b' && pressed != 'i') //checking for correct char
            {

                pressed = Convert.ToChar(Console.ReadLine());
                switch (pressed)
                {
                    case 'b':
                        bubbleSortingArray.Sort();
                        Console.Write("Bubble sorted array - ");
                        bubbleSortingArray.Print();
                        break;

                    case 'i':
                        insertSortingArray.Sort();
                        Console.Write("Insertion sorted array - ");
                        insertSortingArray.Print();
                        break;

                    default:
                        Console.WriteLine("Please press <b> or <i>");
                        break;
                }
            }

            Console.ReadKey();
        }

    }
    
}
