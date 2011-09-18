using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// this implementation of mergesort is inspired by the CLR book.
// the implementation of Merge is original and therefore may not be optimal.
// it is a classic divide-and-conquer implementation but the Merge() routine
// allocates a work array that is the same size as the original array.
// however, the original array is the one that ends up being sorted as opposed
// to a copy.  this implementation runs in O(n*lg(n)).
// 
// the function is defined as an extension method to an integer array, and also 
// as an extension method to an Element array (see Element.cs).  Any data structure 
// that extends Element can be sorted by calling .MergeSort on an array of that 
// subclass (see the that usage in the Huffman project for an example).

namespace MergeSort
{
    public static class MergeSortClass
    {
        public static void MergeSort(this int[] array)
        {
            MergeSort(array, 0, array.Count());
        }

        public static void MergeSort(this Element[] array)
        {
            int i = 0;
            while (array[i] == null) 
                i++;
            MergeSort(array, i, array.Count());
        }

        static void MergeSort(int[] array, int p, int r)
        {
            if (p < r - 1)
            {
                int q = (p + r) / 2;
                MergeSort(array, p, q);
                MergeSort(array, q, r);
                Merge(array, p, q, r);
            }
        }

        static void MergeSort(Element[] array, int p, int r)
        {
            if (p < r - 1)
            {
                int q = (p + r) / 2;
                MergeSort(array, p, q);
                MergeSort(array, q, r);
                Merge(array, p, q, r);
            }
        }

        static void Merge(int[] array, int p, int q, int r)
        {
            if (p + 1 >= r)
                return;
            int i = p;
            int j = q;
            int[] newarray = new int[r - p];
            int index = 0;
            while (i < q && j < r)
            {
                int left = array[i];
                int right = array[j];
                if (left <= right)
                {
                    newarray[index++] = left;
                    i++;
                }
                else
                {
                    newarray[index++] = right;
                    j++;
                }
            }
            if (i >= q)
                while (j < r)
                    newarray[index++] = array[j++];
            else
                while (i < q)
                    newarray[index++] = array[i++];

            index = 0;
            for (i = p; i < r; i++)
                array[i] = newarray[index++];
        }

        static void Merge(Element[] array, int p, int q, int r)
        {
            if (p + 1 >= r)
                return;
            int i = p;
            int j = q;
            var newarray = new Element[r - p];
            int index = 0;
            while (i < q && j < r)
            {
                int left = array[i].Key;
                int right = array[j].Key;
                if (left <= right)
                {
                    newarray[index++] = array[i];
                    i++;
                }
                else
                {
                    newarray[index++] = array[j];
                    j++;
                }
            }
            if (i >= q)
                while (j < r)
                    newarray[index++] = array[j++];
            else
                while (i < q)
                    newarray[index++] = array[i++];

            index = 0;
            for (i = p; i < r; i++)
                array[i] = newarray[index++];
        }
    }
}
