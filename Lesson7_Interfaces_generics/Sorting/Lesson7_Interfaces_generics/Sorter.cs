using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    abstract class Sorter<T> : ISorter<T> where T : IComparable<T>
    {

        protected T[] array;

        public Sorter(T[] arrayforSorting)
        {
            array = arrayforSorting;
        }

        protected abstract void Swap(int index1, int index2);
        
        public void Print()
        {
            foreach (T i in array)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }

        public abstract void Sort();
    }
}
