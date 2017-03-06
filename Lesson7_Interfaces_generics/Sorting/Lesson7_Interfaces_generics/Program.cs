using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating 5 buildings with random amount of floors");

            String [] buildingNames = new String[5] {"Building 1", "Building 2", "Building 3", "Building 4", "Building 5"};

            Buildings[] buildingGroup = new Buildings[5];
            

            Random rnd = new Random();
            for (int i=0; i<5; i++)
            {
                Buildings building = new Buildings(buildingNames[i], rnd.Next(50));

                buildingGroup[i] = building;
            }

            
            ISorter<Buildings> bubleSort = new BubbleSorter<Buildings>(buildingGroup);
            ISorter<Buildings> insertionSort = new InsertionSorter<Buildings>(buildingGroup);

            bubleSort.Print();


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
                        bubleSort.Sort();
                        Console.WriteLine("Bubble sorted array:");
                        bubleSort.Print();
                        break;

                    case 'i':
                        insertionSort.Sort();
                        Console.WriteLine("Insertion sorted array:");
                        insertionSort.Print();
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
