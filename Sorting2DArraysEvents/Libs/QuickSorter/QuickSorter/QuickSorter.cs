using System;

namespace Sorters
{
    public class QuickSorter : Sorter, ISorter
    {
        public event SortingFinishedEventHandler SortingFinished; // event which will be rised after sorting will finish

        public override void Sort(bool isDescending, int[,] arrayforSorting)
        {

            // Getting i and j values from arrived 2D array for future back conversion from 1D to 2D array
            amountOfRaws = arrayforSorting.GetLength(0);
            amountOfColumns = arrayforSorting.GetLength(1);

            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d 

            sortingStopwatch.Start(); //starting stopwatch
            Quicksort(array);
            sortingStopwatch.Stop(); //stopping stopwatch

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            TimeSpan sortingTime = sortingStopwatch.Elapsed;

            OnSortingFinished(array, amountOfRaws, amountOfColumns, sortingTime); //rising event
            
        }

        private void Quicksort(int[] ar)
        {
            if (ar.Length > 1) Quicksort(ar, 0, ar.Length - 1);
        }

        private void Quicksort(int[] ar, int left, int right)
        {
            if (left == right) return;
            int i = left + 1;
            int j = right;
            int pivot = ar[left];

            // Loop invariant i <= j
            while (i < j)
            {
                if (ar[i] <= pivot) i++;
                else if (ar[j] > pivot) j--;
                else
                { // Swap ith and jth elements
                    Swap(i, j);
                }
            }
            // Now i == j

            if (ar[j] <= pivot /* it also means that i == right, because j was never moved */)
            {
                // Left most element is array's maximum
                int m = ar[left]; ar[left] = ar[right]; ar[right] = m;
                Quicksort(ar, left, right - 1);
            }
            else
            {
                Quicksort(ar, left, i - 1);
                Quicksort(ar, i, right);
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
            return "Quick sorter";
        }
    }
}
