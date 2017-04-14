using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using DBSources;

namespace Sorters
{
    public class Controller
    {

        private object locker = new object();
        private List<ISorter> sortersList = new List<ISorter>();

        private Menu menu = new Menu();

        private int threadCounter = 0;

        public void Start() // rename to init
        {
            int[,] array2d;

            Printer generatedArrayPrinter = new Printer();

           // creating instatnce of each sorter and add to list
            sortersList = new List<ISorter>
            {
                new BubbleSorter(),
                new InsertionSorter(),
                new QuickSorter(),
                new SelectionSorter()
            };

            //subscribing for event from each sorter / /cretae in list

            foreach (ISorter sorter in sortersList)
            {
                sorter.SortingFinished += OnSortingFinished;
            }

            menu.GenerateMenu(sortersList);

            if (menu.isArrayNeedToGenerate == true)
            {
                //Generating and printing generated array
                array2d = SorterUtils.Generate2DArray(menu.amountOfRows, menu.amountOfColumns);
                Console.WriteLine("New {0}X{1} array created and filled with random values \n", menu.amountOfRows, menu.amountOfColumns);
                generatedArrayPrinter.Print(array2d);

            } else
            {
                Console.WriteLine("Got array from DataBase");

                //Data Source = NICESRV - 3189\SQLEXPRESS; Initial Catalog = TestData; Integrated Security = True

                SQLDBSource dbSource = new SQLDBSource();
                array2d = dbSource.GetArray(@"NICESRV-3189\SQLEXPRESS", "TestData");
                //array2d = dbSource.GetArray(@"SLAVA-HP\SQLEXPRESS", "ArraysDB");

                generatedArrayPrinter.Print(array2d);
                //array2d = SorterUtils.Generate2DArray(menu.amountOfRows, menu.amountOfColumns);   //Getting array from DB
            }


            if (menu.typeOfSorter <= sortersList.Count)
            {
                // Starting thread and running selected sorter
                Thread sortThread = new Thread( // cretae method
                () =>  // creating anonymus method which will be run in thread
                {
                    sortersList[menu.typeOfSorter - 1].Sort(menu.isDescending, array2d);
                    
                });

                sortThread.Start();

            }
            else
            {
                foreach (Sorter sorter in sortersList) //change s
                {

                    Thread sortThread = new Thread(
                    () =>  // creating anonymus method which will be run in thread
                    {

                        sorter.Sort(menu.isDescending, array2d); // sorting the array inside anonymus method

                    });

                    sortThread.Start();
                }
            }
        }


        public void OnSortingFinished(object source, SorterEventArgs e)
        {
            threadCounter++;
            Printer sortedArrayPrinter = new Printer(); // create printer instance for printing sorted array

            if (menu.typeOfSorter < sortersList.Count + 1 || threadCounter == sortersList.Count)
            {
                sortedArrayPrinter.PrintingFinished += OnPrintingFinished; //subscrubing for printing finished event
                threadCounter = 0;
            }

            lock (locker)
            {
                sortedArrayPrinter.Print(SorterUtils.ConvertArrayTo2D(e.array, e.amountOfRaws, e.amountOfColumns), source, e.sortingTime);

            }

        }

        public void OnPrintingFinished(object source, EventArgs e)
        {
            Controller controller = new Controller();

            controller.Start();
        }

    }
}
