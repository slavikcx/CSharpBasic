
namespace Sorters
{
    public class QuickSorter : Sorter
    {
        public QuickSorter(int[,] arrayforSorting) : base(arrayforSorting)
        {

        }

        public override int[] Sort(bool isDescending)
        {
            Quicksort(array);

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            return array;
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

        public override string ToString()
        {
            return "Quick sorter";
        }
    }
}
