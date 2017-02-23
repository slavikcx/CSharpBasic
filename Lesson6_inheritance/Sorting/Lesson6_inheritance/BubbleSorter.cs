using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class BubbleSorter : Sorter
    {
        public BubbleSorter(int[] arrayforSorting): base(arrayforSorting)
        {
          
        }

        public override void Sort()
        {
            bool isSwapped;
            do
            {
                isSwapped = false;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(j, j + 1);
                        isSwapped = true;
                    }
                }
            } while (isSwapped);
        }


    }
}
