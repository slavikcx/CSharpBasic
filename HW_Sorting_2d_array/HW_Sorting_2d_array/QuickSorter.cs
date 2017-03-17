using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    class QuickSorter : Sorter
    {
        public QuickSorter(int[,] arrayforSorting) : base(arrayforSorting)
        {

        }

        public override int[,] Sort(int direction)
        {

            Quicksort(array);

            // checking if we need to invert array
            if (direction == 2)
            {
                array = ChangeDirection(); // inverting array
            }

            return ConvertArrayTo2D();
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
                    int m = ar[i]; ar[i] = ar[j]; ar[j] = m;
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
    }
}
