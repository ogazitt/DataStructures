using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryTree;
using QuickSort;
using MergeSort;
using Huffman;
using HeapSort;

namespace Driver
{
    class Program
    {
        static int[] arr = { 5, 3, 7, 9, 11, 1, 4, 13, 8, 10, 2, 7 };

        static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree test");
            BinaryTreeTest();
            Console.WriteLine("MergeSort test");
            MergeSortTest();
            Console.WriteLine("Huffman encoding test");
            HuffmanTest();
            Console.WriteLine("Huffman encoding test with CLR input");
            HuffmanTestCLR();
            Console.WriteLine("HeapSort test");
            HeapSortTest();

            Console.ReadLine();
        }

        static void BinaryTreeTest()
        {
            var tree = new BinaryTree.BinaryTree();
            foreach (int v in arr)
            {
                tree.Insert(new Node(v));
            }

            //tree.Print();
            Console.WriteLine("Inorder walk of binary search tree");
            tree.PrintSorted();

            Console.WriteLine("Print successor of each node");
            foreach (int v in arr)
            {
                Node node = tree.Find(v);
                node.Print();
                Node successor = tree.FindSuccessor(node);
                if (successor != null) successor.Print();
                Console.WriteLine();
            }

            Console.WriteLine("Delete each of the nodes and print resulting tree");
            foreach (int v in arr)
            {
                tree.Delete(v);
                tree.PrintSorted();
                Console.WriteLine();
            }
        }

        static void HeapSortTest()
        {
            arr.Print();
            arr.HeapSort();
            arr.Print();
        }

        static void HuffmanTest()
        {
            HuffmanCode hc = new HuffmanCode();
            hc.Frequencies["omri"] = 35;
            hc.Frequencies["had"] = 3;
            hc.Frequencies["a"] = 107;
            hc.Frequencies["little"] = 53;
            hc.Frequencies["lamb"] = 27;

            hc.ComputeCodes();

            foreach (var key in hc.Codes.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, hc.Codes[key]));
            }
        }

        static void HuffmanTestCLR()
        {
            HuffmanCode hc = new HuffmanCode();
            hc.Frequencies["f"] = 5;
            hc.Frequencies["e"] = 9;
            hc.Frequencies["c"] = 12;
            hc.Frequencies["b"] = 13;
            hc.Frequencies["d"] = 16;
            hc.Frequencies["a"] = 45;

            hc.ComputeCodes();

            foreach (var key in hc.Codes.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, hc.Codes[key]));
            }
        }

        static void MergeSortTest()
        {
            arr.Print();
            arr.MergeSort();
            arr.Print();
        }
    }
}
