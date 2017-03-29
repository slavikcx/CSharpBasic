
namespace Sorters
{
    public class SorterUtils
    {
        // Method for converting 2d array to 1d array
        public static int[] ConvertArrayTo1D(int[,] array2d)
        {
            int[] array = new int[array2d.Length];

            int k = 0; // for counting simple array index

            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array[k] = array2d[i, j]; // just moving values one by one from 2d array to simple array
                    k++;
                }
            }
            return array;
        }

        public static int[,] ConvertArrayTo2D(int[] array, int numberOfRows, int numberOfColumns)
        {
            int k = 0; // for counting simple array index

            int[,] array2d = new int[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    array2d[i, j] = array[k]; //just moving values one by one from simple array to 2d array
                    k++;
                }
            }
            return array2d;
        }

        //method for inversion of array
        public static int[] ChangeDirection(int[] array)
        {
            int[] invertedArray = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                invertedArray[array.Length - 1 - i] = array[i]; // moving values starting from begining of one array to another starting from end of second array
            }

            return invertedArray;
        }
    }
}
