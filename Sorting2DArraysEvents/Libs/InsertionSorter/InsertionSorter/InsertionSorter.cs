using System;

namespace Sorters
{
    public class InsertionSorter : Sorter, ISorter
    {
        public event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish
                
        public override void Sort(bool isDescending, int[,] arrayforSorting)
        {
            // Getting i and j values from arrived 2D array for future back conversion from 1D to 2D array
            amountOfRaws = arrayforSorting.GetLength(0);
            amountOfColumns = arrayforSorting.GetLength(1);

            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d 

            sortingStopwatch.Start(); //starting Stopwatch

            //Sorting...
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j + 1].CompareTo(array[j]) < 0)
                {
                    Swap(j, j + 1);

                    for (int i = j; i > 0; i--)
                    {
                        if (array[i].CompareTo(array[i - 1]) < 0)
                        {
                            Swap(i, i - 1);
                        }
                    }
                }
            }

            sortingStopwatch.Stop(); //Stoppping stopwatch

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }
            
            TimeSpan sortingTime = sortingStopwatch.Elapsed;
            
            OnSortingFinished(array, amountOfRaws, amountOfColumns, sortingTime); //rising event

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
            return "Isertion sorter";
        }
    }
}
