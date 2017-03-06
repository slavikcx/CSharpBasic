using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    class InsertionSorter<T> : Sorter<T> where T : IComparable<T>
    {
        public InsertionSorter(T[] arrayToSort) : base(arrayToSort)
        {

        }

        public override void Sort()
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
