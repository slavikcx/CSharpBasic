using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_classes
{
    class BubbleSorter
    {
        private int[] array;

        public BubbleSorter (int[] arrayforSorting)
        {
            array = arrayforSorting;
        }

        public void Sort()
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
