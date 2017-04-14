using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sorters
{
    public delegate void SortingFinishedEventHandler(object source, SorterEventArgs args); //defining deligate for Sorting finish event handling
    

    public class SorterEventArgs : EventArgs // creating custom event arguments for sending sorted array and array details with event
    {
        public int[] array { set; get; } //field for containing sorted array
        public int amountOfRaws { set; get; }
        public int amountOfColumns { set; get; }
        public TimeSpan sortingTime { set; get; }
    }


    public interface ISorter
    {
        void Sort(bool isDescending, int[,] arrayforSorting);

        void OnSortingFinished(int[] sortedArray, int rawsAmount, int columnAmount, TimeSpan sortingTime);

        event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish

    }


    public abstract class Sorter
    {
        protected int[] array;
        protected int amountOfRaws;
        protected int amountOfColumns;
        protected TimeSpan sortingTime;

        protected Stopwatch sortingStopwatch = new Stopwatch();

        //public event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish
        
        //Method for swapping values in array
        protected void Swap(int index1, int index2)
        {
            int temp;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public abstract void Sort(bool isDescending, int[,] arrayforSorting);

        public abstract void OnSortingFinished(int[] sortedArray, int rawsAmount, int columnAmount, TimeSpan sortingTime);

    }


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
