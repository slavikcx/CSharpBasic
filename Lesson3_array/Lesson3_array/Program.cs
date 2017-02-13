using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayLenght = 0;
            int arrayMaxLenght = 1000000;
            
            Console.WriteLine("Please enter array lenght");

            while (arrayLenght <= 0 || arrayLenght>arrayMaxLenght) //checking if array lenght is not 0 and not grater than MaxLenght
            {
                arrayLenght = Convert.ToInt32(Console.ReadLine());

                if (arrayLenght <= 0)
                {
                    Console.WriteLine("Please enter value greater than 0");
                } else if(arrayLenght > arrayMaxLenght)
                {
                    Console.WriteLine("Please enter value less than {0}", arrayMaxLenght);
                }
            }
            
            int[] intArray = new int[arrayLenght]; // createing array

            Console.WriteLine("Please enter array values");

            for (int i = 0; i<arrayLenght; i++) //filling array
            {
                intArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("");
            Console.WriteLine("Max value of array is {0}", MaxValue(intArray));
            Console.WriteLine("Min value of array is {0}", MinValue(intArray));

            Console.ReadKey();

        }

        static int MaxValue(int [] array)
        {
            int maxVal = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (maxVal < array[i])
                {
                    maxVal = array[i];
                }
            }

            return maxVal;
        }

        static int MinValue(int[] array)
        {
            int minVal = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (minVal > array[i])
                {
                    minVal = array[i];
                }
            }

            return minVal;
        }
    }
}
