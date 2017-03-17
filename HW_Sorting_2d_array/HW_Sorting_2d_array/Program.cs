using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayRows, arrayColumns = 0;
            int[,] array2d;

            int sortingType, sortingDirection, k = 0;
            string choice = "";

            Random rnd = new Random();

            do
            {
                do
                {
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("c - create new array");
                    Console.WriteLine("e - exit");

                    choice = Console.ReadLine();
                    if (choice != "c" && choice != "e")
                    {
                        Console.WriteLine("Please enter valid value");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                // if user enter e - breack the loop and exit from program
                if (choice == "e")
                {
                    break;
                }

                Console.Write("Please enter amount of rows in 2D array - ");
                arrayRows = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Please enter amount of columns in 2D array - ");
                arrayColumns = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                array2d = new int[arrayRows, arrayColumns];

                //filling array with default values
                for (int i = 0; i < array2d.GetLength(0); i++)
                {
                    for (int j = 0; j < array2d.GetLength(1); j++)
                    {
                        array2d[i, j] = rnd.Next(99);
                        k++;
                    }
                    k++;
                }

                Console.WriteLine("New {0}X{1} array created and filled with random values", arrayRows, arrayColumns);
                Printer.Print(array2d);
                Console.WriteLine("");

                //defining sorting method
                do
                {
                    Console.WriteLine("Choose type of sorting: ");
                    Console.WriteLine("1 - Bubble sorting");
                    Console.WriteLine("2 - Insertion sorting");
                    Console.WriteLine("3 - Quick sorting");
                    Console.WriteLine("4 - Selection sorting");
                    sortingType = Convert.ToInt32(Console.ReadLine());
                    if (sortingType != 1 && sortingType != 2 && sortingType != 3 && sortingType != 4)
                    {
                        Console.WriteLine("Please enter valid value");
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                //definig array direction
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Choose sorting direction: ");
                    Console.WriteLine("1 - Ascending");
                    Console.WriteLine("2 - Descending");
                    sortingDirection = Convert.ToInt32(Console.ReadLine());

                    if (sortingDirection != 1 && sortingDirection != 2)
                    {
                        Console.WriteLine("Please enter valid value");
                    }
                    else
                    {
                        break;
                    }

                } while (true);


                switch (sortingType)
                {
                    case 1:
                        ISorter bubleSort = new BubbleSorter(array2d);
                        Printer.Print(bubleSort.Sort(sortingDirection));
                        break;

                    case 2:
                        ISorter insertionSort = new InsertionSorter(array2d);
                        Printer.Print(insertionSort.Sort(sortingDirection));
                        break;

                    case 3:
                        ISorter quickSort = new QuickSorter(array2d);
                        Printer.Print(quickSort.Sort(sortingDirection));
                        break;

                    case 4:
                        ISorter selectionSort = new SelectionSorter(array2d);
                        Printer.Print(selectionSort.Sort(sortingDirection));
                        break;
                }
                
            } while (choice != "e");
            
        }
    }
}
