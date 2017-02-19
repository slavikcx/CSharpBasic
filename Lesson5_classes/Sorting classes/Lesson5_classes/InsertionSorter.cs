using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_classes
{
    class InsertionSorter
    {
        private int[] array;

        public InsertionSorter(int[] arrayForSorting)
        {
            array = arrayForSorting;
        }

        public void Sort()
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

        public void Print()
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        private void Swap(int index1, int index2)
        {
            int temp = 0;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

    }
}
