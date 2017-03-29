
namespace Sorters
{
    public class InsertionSorter : Sorter
    {
        public InsertionSorter(int[,] arrayToSort) : base(arrayToSort)
        {

        }

        public override int[] Sort(bool isDescending)
        {
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
            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            return array;
        }

        public override string ToString()
        {
            return "Isertion sorter";
        }
    }
}
