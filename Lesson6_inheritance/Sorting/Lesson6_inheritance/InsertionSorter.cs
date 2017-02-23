using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertionSorter: Sorter
    {
        public InsertionSorter(int[] arrayToSort): base(arrayToSort)
        {

        }

        public override void Sort()
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j + 1] < array[j])
                {
                    Swap(j, j + 1);

                    for (int i = j; i > 0; i--)
                    {
                        if (array[i] < array[i - 1])
                        {
                            Swap(i, i - 1);
                        }
                    }
                }
            }
        }

    }
}
