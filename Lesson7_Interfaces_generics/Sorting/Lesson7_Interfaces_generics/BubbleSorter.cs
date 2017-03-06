using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    class BubbleSorter<T> : Sorter<T> where T: IComparable<T>
    {
        public BubbleSorter(T[] arrayforSorting) : base(arrayforSorting)
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
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(j, j + 1);
                        isSwapped = true;
                    }
                }
            } while (isSwapped);
        }

        protected override void Swap(int index1, int index2)
        {
            T temp;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

    }
}
