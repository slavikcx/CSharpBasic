
namespace Sorters
{
    public class BubbleSorter : Sorter
    {
        public BubbleSorter(int[,] arrayforSorting) : base(arrayforSorting)
        {

        }

        //Bubble sorting method
        public override int[] Sort(bool isdescending)
        {
            bool isSwapped;
            bool isDescending = (bool)isdescending;

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
            } while (isSwapped); // repit cycle untill there was no swap

            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            return array;
        }

        public override string ToString()
        {
            return "Bubble sorter";
        }
    }
}
