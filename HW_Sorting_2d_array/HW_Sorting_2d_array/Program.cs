using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfRaws, amountOfColumns, amountOfSorters, sorterMenuIterator = 0;
            int[,] array2d;
            
            int sortingType, sortingDirection, k = 0;
            char choice = ' ';

            bool parsingResult;
            bool isDescending = false;

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
                } while (choice !='c' && choice!='e');


                // if user enter e - breack the loop and exit from program
                if (choice == 'e')
                {
                    break;
                }


                // asking user how much raws should be in 2D array
                do
                {
                    Console.Write("Please enter amount of rows in 2D array - ");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out amountOfRaws);

                    Console.Clear();

                } while (parsingResult != true || amountOfRaws == 0);


                //asking user how much raws should be in 2D array
                do
                {
                    Console.Write("Please enter amount of columns in 2D array - ");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out amountOfColumns);

                    Console.Clear();
                } while (parsingResult != true || amountOfColumns == 0);


                // generating filled 2D array
                array2d = Generate2DArray(amountOfRaws, amountOfColumns); 

                Console.WriteLine("New {0}X{1} array created and filled with random values", amountOfRaws, amountOfColumns);
                Printer.Print(array2d);
                Console.WriteLine("");


                ArrayList sortersList = new ArrayList();
                
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
                    foreach (ISorter s in sortersList)
                    {
                        sorterMenuIterator++;
                        Console.WriteLine("{0} - {1}.", sorterMenuIterator, s);
                        
                    }

                    parsingResult = Int32.TryParse(Console.ReadLine(), out sortingType);
                    amountOfSorters = sorterMenuIterator;
                    sorterMenuIterator = 0;
                    Console.Clear();
                } while (parsingResult != true || sortingType > amountOfSorters);



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
                    }

                    Console.Clear();
                } while (parsingResult != true || sortingDirection > 2);





                switch (sortingType)
                {
                    case 1:
                        Console.WriteLine("Sorted array:");
                        Printer.Print(SorterUtils.ConvertArrayTo2D(bubleSort.Sort(isDescending), amountOfRaws, amountOfColumns));
                        break;

                    case 2:
                        
                        Printer.Print(SorterUtils.ConvertArrayTo2D(insertionSort.Sort(isDescending), amountOfRaws, amountOfColumns));
                        break;

                    case 3:
                        Printer.Print(SorterUtils.ConvertArrayTo2D(quickSort.Sort(isDescending), amountOfRaws, amountOfColumns));
                        break;

                    case 4:
                        Printer.Print(SorterUtils.ConvertArrayTo2D(selectionSort.Sort(isDescending), amountOfRaws, amountOfColumns));
                        break;
                }
                
            } while (choice != 'e');
            
        }

        public static int[,] Generate2DArray(int amountOfRaws, int amountOfColumns)
        {
            int [,] array2d = new int[amountOfRaws, amountOfColumns];
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
