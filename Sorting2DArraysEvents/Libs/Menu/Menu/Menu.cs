using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sorters
{
    
    public class Menu
    {
        private char choice;
        private int amountOfRowsInArray, amountOfColumnsInArray, sorterMenuIterator = 0;
        private bool parsingResult;
        private int allSortersMenuNumber = 0;
        private int sortingType, sortingDirection;
        bool isDescendingTrue = false;

        bool isArrayToGenerate = false;


        public char userChoice
        {
            get { return choice; }
            set { }
        }

        public int amountOfRows
        {
            get { return amountOfRowsInArray; }
            set { }
        }

        public int amountOfColumns
        {
            get { return amountOfColumnsInArray; }
            set { }
        }

        public bool isDescending
        {
            get { return isDescendingTrue; }
            set { }
        }

        public int typeOfSorter
        {
            get { return sortingType; }
            set { }
        }

        public bool isArrayNeedToGenerate
        {
            get { return isArrayToGenerate; }
            set { }
        }

        public void GenerateMenu(List<ISorter> listOfSorters) // rename to console menu
        {
            //Main menu
            do
            {
                Console.WriteLine("Please make your choise.");
                Console.WriteLine("d - get array from database");
                Console.WriteLine("c - create new array");
                Console.WriteLine("e - exit");

                choice = (char)Console.Read();

                // if user enter e - exit from program
                if (userChoice == 'e')
                {
                    Environment.Exit(0);
                }

                Console.Clear();
            } while (choice != 'c' && choice != 'd');

            if (choice == 'd')
            {
                isArrayToGenerate = false;
                //need to get array from DB
            }
            else if (choice == 'c')
            {
                //creating new array
                isArrayToGenerate = true;
                // asking user how many rows should be in 2D array
                do
                {
                    Console.Write("Please enter amount of rows in 2D array - ");

                    parsingResult = Int32.TryParse(Console.ReadLine(), out amountOfRowsInArray);

                    Console.Clear();

                } while (parsingResult != true || amountOfRowsInArray == 0);

                //asking user how many columns should be in 2D array
                do
                {
                    Console.Write("Please enter amount of columns in 2D array - ");

                    parsingResult = int.TryParse(Console.ReadLine(), out amountOfColumnsInArray);

                    Console.Clear();
                } while (parsingResult != true || amountOfColumnsInArray == 0);

            }

            //asking which sorting type to use for sorting
            do
            { 
                Console.WriteLine("Choose sorter type: ");

                // Generating dynamic menu
                foreach (ISorter sorter in listOfSorters)
                {
                    sorterMenuIterator++;
                    Console.WriteLine("{0} - {1}.", sorterMenuIterator, sorter);
                }

                // Adding Last menu item for use all sorters
                allSortersMenuNumber = sorterMenuIterator + 1;
                Console.WriteLine("{0} - All sorters", allSortersMenuNumber);
                
                parsingResult = Int32.TryParse(Console.ReadLine(), out sortingType);

                sorterMenuIterator = 0;

                Console.Clear();
            } while (parsingResult != true || sortingType > allSortersMenuNumber); // allSortersMenuNumber - lust number in menu
            
            //asking array direction
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Choose sorting direction: ");
                Console.WriteLine("1 - Ascending");
                Console.WriteLine("2 - Descending");

                parsingResult = Int32.TryParse(Console.ReadLine(), out sortingDirection);

                if (sortingDirection == 2)
                {
                    isDescendingTrue = true;
                }
                else
                {
                    isDescendingTrue = false;
                }

                Console.Clear();
            } while (parsingResult != true || sortingDirection > 2);


        }
       
    }
}
