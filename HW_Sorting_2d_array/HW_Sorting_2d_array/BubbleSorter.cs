using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    class BubbleSorter : Sorter
    {
        public BubbleSorter(int[,] arrayforSorting) : base(arrayforSorting)
        {

        }
        
        //Bubble sorting method
        public override int [,] Sort(int direction)
        {
            bool isSwapped;
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
            if (direction == 2)
            {
                array =  ChangeDirection(); // inverting array
            } 

            return ConvertArrayTo2D();
        }
        
    }
}
