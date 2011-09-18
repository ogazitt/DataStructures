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

// this implementation of heapsort comes out of the CLR book.
// it sorts an array in place by building a heap out of it, and then
// scanning the heap from bottom to top, swapping the largest element 
// at the beginning of the heap for the element at the bottom, resulting
// in an ordered array.  the algorithm runs in O(n*lg(n)).
// 
// the function is defined as an extension method to an integer array.  
// it can easily be adapted to a data structure that has an integer key 
// (see Element.cs and MergeSort.cs in the mergesort project for an example).

namespace HeapSort
{
    public static class HeapSortClass
    {
        
        public static void HeapSort(this int[] array)
        {
            BuildHeap(array);
            for (int i = array.Count() - 1; i > 1; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i - 1, 0);
            }
        }

        static void BuildHeap(int[] array)
        {
            for (int i = array.Count() / 2; i >= 0; i--)
                Heapify(array, array.Count(), i);
        }

        static void Heapify(int[] array, int length, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left < length && array[left] > array[largest])
                largest = left;

            if (right < length && array[right] > array[largest])
                largest = right;

            if (largest != index)
            {
                int temp = array[largest];
                array[largest] = array[index];
                array[index] = temp;
                Heapify(array, length, largest);
            }
        }
    }
}
