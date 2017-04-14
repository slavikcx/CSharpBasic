using System;

namespace Sorters
{
    public class SelectionSorter : Sorter, ISorter
    {
        public event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish
        
        public override void Sort(bool isDescending, int[,] arrayforSorting)
        {
            // Getting i and j values from arrived 2D array for future back conversion from 1D to 2D array
            amountOfRaws = arrayforSorting.GetLength(0);
            amountOfColumns = arrayforSorting.GetLength(1);

            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d 

            sortingStopwatch.Start(); //starting stopwatch
            selectSort(array); // Sorting
            sortingStopwatch.Stop(); //stopping stopwatch

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            TimeSpan sortingTime = sortingStopwatch.Elapsed;

            OnSortingFinished(array, amountOfRaws, amountOfColumns, sortingTime); //rising event

        }

        private void selectSort(int[] arr)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }
        
        public override void OnSortingFinished(int[] sortedArray, int rawsAmount, int columnAmount, TimeSpan timeOfSorting)
        {
            if (SortingFinished != null) // checking if there are subscribers on event
            {
                SortingFinished(this, new SorterEventArgs() //Sending arguments with event
                {
                    array = sortedArray,
                    amountOfRaws = rawsAmount,
                    amountOfColumns = columnAmount,
                    sortingTime = timeOfSorting
                });
            }
        }
        
        public override string ToString()
        {
            return "Selection sorter";
        }
    }
}
