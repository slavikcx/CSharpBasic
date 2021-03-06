﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Sorting_2d_array
{
    abstract class Sorter : ISorter
    {

       // protected int[,] array2d;// I J
        protected int[] array;

        public Sorter(int[,] arrayforSorting)
        {
            //array2d = arrayforSorting;
            array = SorterUtils.ConvertArrayTo1D(arrayforSorting); //converting 2d array to 1d in constuctor
            //array2d = arrayforSorting;
        }
        
            //Method for swapping values in array
        protected void Swap(int index1, int index2)
        {
            int temp;

            temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public abstract int[] Sort(bool isDescending);


    }
}
