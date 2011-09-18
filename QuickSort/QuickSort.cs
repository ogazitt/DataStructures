// Copyright 2011 Omri Gazitt
//
// Licensed under the Apache License, Version 2.0 (the "License"): you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// this implementation of quicksort comes out of the CLR book.
// it is a classic divide-and-conquer implementation and operates in place.
// 
// the function is defined as an extension method to an integer array.  
// it can easily be adapted to a data structure that has an integer key 
// (see Element.cs and MergeSort.cs in the mergesort project for an example).
//
// note that this implementation works on an array with no duplicates but has 
// not yet been fully tested/debugged on arrays with duplicates.  there appears 
// to be a bug in the boundary conditions and/or the Partition function implementation.

namespace QuickSort
{
    public static class QuickSortClass
    {
        public static void Print(this int[] array)
        {
            for (int i = 0; i < array.Count(); i++)
                Console.Write(array[i] + " ");
            Console.Write("\n");
        }

        public static void QuickSort(this int[] array)
        {
            Sort(array, 0, array.Count()-1);
        }

        static int Partition(int[] array, int p, int r)
        {
            int val = array[p];
            int i = p;
            int j = r;

            while (true)
            {
                while (array[j] > val)
                    j--;
                while (array[i] < val)
                    i++;
                if (i < j)
                {
                    int temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;
                }
                else
                    return j;
            }
        }

        static void Sort(int[] array, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(array, p, r);
                Sort(array, p, q);
                Sort(array, q + 1, r); 
            }
        }
    }
}
