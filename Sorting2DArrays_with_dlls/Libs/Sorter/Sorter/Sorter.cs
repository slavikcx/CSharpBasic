using Sorters.Common;

namespace Sorters
{
    public abstract class Sorter : ISorter
    {
        protected int[] array;

        public Sorter(int[,] arrayforSorting)
        {
            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d in constuctor
        }

        //Method for swapping values in array
        protected void Swap(int index1, int index2)
        {
            int temp;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public abstract int[] Sort(bool isDescending);
        
    }
}
