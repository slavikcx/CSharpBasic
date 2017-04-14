using System;

namespace Sorters
{
    public class BubbleSorter : Sorter, ISorter
    {
        public event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish

        public override void Sort(bool isDescending, int[,] arrayforSorting)
        {
            bool isSwapped;
          
            // Getting i and j values from arrived 2D array for future back conversion from 1D to 2D array
            amountOfRaws = arrayforSorting.GetLength(0);
            amountOfColumns = arrayforSorting.GetLength(1);

            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d 

            sortingStopwatch.Start(); //starting stopwatch

            //Sorting...
            do
            {
                isSwapped = false;
                
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0) //comparing values and if next value less than previous  - swapping values
                    {
                        Swap(j, j + 1);
                        isSwapped = true;
                    }
                }
            } while (isSwapped); // repit cycle until there was no swap

            sortingStopwatch.Stop(); //stopping stopwatch

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }
            
            sortingTime = sortingStopwatch.Elapsed;
            
            OnSortingFinished(array, amountOfRaws, amountOfColumns, sortingTime); //rising event
            
        }  

        public override void OnSortingFinished(int [] sortedArray, int rawsAmount, int columnAmount, TimeSpan timeOfSorting)
        {
            //var SortingFinish = SortingFinished;

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
            return "Bubble sorter";
        }
    }
}
