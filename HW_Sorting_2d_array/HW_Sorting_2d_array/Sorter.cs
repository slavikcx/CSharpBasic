using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    abstract class Sorter : ISorter
    {

        protected int[,] array2d;
        protected int[] array;

        public Sorter(int[,] arrayforSorting)
        {
            //array2d = arrayforSorting;
            array = ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d in constuctor
            array2d = arrayforSorting;
        }
        
            //Method for swapping values in array
        protected void Swap(int index1, int index2)
        {
            int temp;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        // Method for converting 2d array to 1d array
        private int[] ConvertArrayTo1D(int [,] array2d)
        {
            array = new int[array2d.Length];

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

        protected int [,] ConvertArrayTo2D()
        {
            int k = 0; // for counting simple array index

            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = array[k]; //just moving values one by one from simple array to 2d array
                    k++;
                }
            }
            return array2d;
        }

        //method for inversion of array
        protected int[] ChangeDirection()
        {
            int[] invertedArray = new int[array.Length];

            for(int i = 0; i < array.Length; i++)
            {
                invertedArray[array.Length - 1 - i] = array[i]; // moving values starting from begining of one array to another starting from end of second array
            }

            return invertedArray;
        }

        public abstract int[,] Sort(int direction);


    }
}
