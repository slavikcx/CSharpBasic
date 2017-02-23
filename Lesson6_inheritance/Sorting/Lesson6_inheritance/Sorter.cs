using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sorter
    {

        protected int[] array;

        public Sorter(int[] arrayforSorting)
        {
            array = arrayforSorting;
        }

        public void Print()
        {
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        protected void Swap(int index1, int index2)
        {
            int temp = 0;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public virtual void Sort()
        {

        }

    }
}
