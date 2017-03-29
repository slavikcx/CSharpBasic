using System;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using Sorters.Common;


namespace Sorters
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfRows, amountOfColumns, sorterMenuIterator = 0;
            int[,] array2d;

            int sortingType, sortingDirection;
            char choice = ' ';

            bool parsingResult;
            bool isDescending = false;

            int allSortersMenuNumber = 0;

            object locker = new object();

            Random rnd = new Random();

            do
            {
                do
                {
                    Console.WriteLine("Please make your choise.");
                    Console.WriteLine("c - create new array");
                    Console.WriteLine("e - exit");

                    choice = (char)Console.Read();


                    Console.Clear();
                } while (choice != 'c' && choice != 'e');


                // if user enter e - breack the loop and exit from program
                if (choice == 'e')
                {
                    break;
                }


                // asking user how much raws should be in 2D array
                do
                {
                    Console.Write("Please enter amount of rows in 2D array - ");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out amountOfRows);

                    Console.Clear();

                } while (parsingResult != true || amountOfRows == 0);


                //asking user how much raws should be in 2D array
                do
                {
                    Console.Write("Please enter amount of columns in 2D array - ");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out amountOfColumns);

                    Console.Clear();
                } while (parsingResult != true || amountOfColumns == 0);


                // generating filled 2D array
                array2d = Generate2DArray(amountOfRows, amountOfColumns);

                Console.WriteLine("New {0}X{1} array created and filled with random values", amountOfRows, amountOfColumns);
                Console.WriteLine("");
                Printer.Print(array2d);
                Console.WriteLine("");


                ArrayList sortersList = new ArrayList(); //change to List ?

                ISorter bubleSort = new BubbleSorter(array2d);
                ISorter insertionSort = new InsertionSorter(array2d);
                ISorter quickSort = new QuickSorter(array2d);
                ISorter selectionSort = new SelectionSorter(array2d);

                sortersList.Add(bubleSort);
                sortersList.Add(insertionSort);
                sortersList.Add(quickSort);
                sortersList.Add(selectionSort);


                //defining sorting method
                do
                {
                    Console.WriteLine("Choose sorter type: ");

                    // Generating dynamic menu
                    foreach (ISorter s in sortersList) //change s
                    {
                        sorterMenuIterator++;
                        Console.WriteLine("{0} - {1}.", sorterMenuIterator, s);

                    }

                    // Adding Last menu item for use all sorters
                    
                    allSortersMenuNumber = sorterMenuIterator + 1;
                    Console.WriteLine("{0} - All sorters", allSortersMenuNumber);


                    parsingResult = Int32.TryParse(Console.ReadLine(), out sortingType);
                    
                    sorterMenuIterator = 0;

                    Console.Clear();
                } while (parsingResult != true || sortingType > allSortersMenuNumber); // allSortersMenuNumber - lust number in menu

                
                //definig array direction
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("Choose sorting direction: ");
                    Console.WriteLine("1 - Ascending");
                    Console.WriteLine("2 - Descending");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out sortingDirection);

                    if (sortingDirection == 2)
                    {
                        isDescending = true;
                    }else
                    {
                        isDescending = false;
                    }

                    Console.Clear();
                } while (parsingResult != true || sortingDirection > 2);
              

                switch (sortingType) //change with arraylist index
                {
                    case 1:
                        Console.WriteLine("Sorted array with {0}", sortersList[0]);
                        Console.WriteLine("");
                        Printer.Print(SorterUtils.ConvertArrayTo2D(bubleSort.Sort(isDescending), amountOfRows, amountOfColumns));
                        break;

                    case 2:
                        Console.WriteLine("Sorted array with {0}", sortersList[1]);
                        Console.WriteLine("");
                        Printer.Print(SorterUtils.ConvertArrayTo2D(insertionSort.Sort(isDescending), amountOfRows, amountOfColumns));
                        break;

                    case 3:
                        Console.WriteLine("Sorted array with {0}", sortersList[2]);
                        Console.WriteLine("");
                        Printer.Print(SorterUtils.ConvertArrayTo2D(quickSort.Sort(isDescending), amountOfRows, amountOfColumns));
                        break;

                    case 4:
                        Console.WriteLine("Sorted array with {0}", sortersList[3]);
                        Console.WriteLine("");
                        Printer.Print(SorterUtils.ConvertArrayTo2D(selectionSort.Sort(isDescending), amountOfRows, amountOfColumns));
                        break;

                }

                //sorting using all sorters
                if (sortingType == allSortersMenuNumber)
                {
                    foreach (ISorter s in sortersList) //change s
                    {
                        int[] value = null; // creating empty value for returning from thread

                        Stopwatch sortingStopwatch = new Stopwatch();

                        Thread sortThread = new Thread(
                        () =>  // creating anonymus method which will be run in thread
                        {
                            sortingStopwatch.Start();

                            value = s.Sort(isDescending); // sorting the array inside anonymus method

                            sortingStopwatch.Stop();

                           lock (locker)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Sorted with {0}", s);
                                Console.WriteLine("");
                                Printer.Print(SorterUtils.ConvertArrayTo2D(value, amountOfRows, amountOfColumns));
                                Console.WriteLine("Sorting time: {0}", sortingStopwatch.Elapsed);
                                Console.WriteLine("");
                                
                            }
                        });

                        sortThread.Start();
                    }
                    //
                    // here we need somehow know when all threads are finished
                }

            } while (choice != 'e');
        }

        public static int[,] Generate2DArray(int amountOfRaws, int amountOfColumns)
        {
            int[,] array2d = new int[amountOfRaws, amountOfColumns];

            Random rnd = new Random();
            
            //filling array with default values
            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = rnd.Next(99); ;
                }
            }
            
            return array2d;
        }




    }
}
