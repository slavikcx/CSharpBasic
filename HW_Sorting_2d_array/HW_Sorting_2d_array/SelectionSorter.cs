﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    class SelectionSorter : Sorter
    {
        public SelectionSorter(int[,] arrayforSorting) : base(arrayforSorting)
        {

        }

        public override int[] Sort(bool isDescending)
        {

            selectSort(array);
            // checking if we need to invert array
            // checking if we need to invert array
            if (isDescending)
            {
                array = SorterUtils.ChangeDirection(array); // inverting array
            }

            return array;

        }

        private void selectSort(int[] arr)
        {
            //pos_min is short for position of min
            int pos_min, temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i;//set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[pos_min])
                    {
                        //pos_min will keep track of the index that min is in, this is needed when a swap happens
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }

        public override string ToString()
        {
            return "Selection sorter";
        }
    }
}
