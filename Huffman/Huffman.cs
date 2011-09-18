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
using MergeSort;
using BinaryTree;

// standard implementation of Huffman coding of a set of input strings.
// the implementation uses the Node data structure to build a binary tree, 
// but not the BinaryTree implementation, because the data structure built is 
// actually a heap, not a Binary Search Tree.
// the implementation is original but inspired by the CLR book.

namespace Huffman
{
    public class HuffmanCode
    {
        public HuffmanCode() { }

        public Dictionary<string, int> Frequencies = new Dictionary<string, int>();
        public Dictionary<string, int> Codes = new Dictionary<string, int>();

        public void ComputeCodes()
        {
            CodeElement[] array = new CodeElement[Frequencies.Count];
            int i = 0;
            foreach (var freq in Frequencies.Keys)
            {
                array[i++] = new CodeElement() { Key = Frequencies[freq], Code = freq, Node = null };
            }

            for (int j = 0; j < i-1; j++)
            {
                // sort the array 
                array.MergeSort();

                var node = new Node(array[j].Key + array[j+1].Key);
                node.Left = array[j].Node == null ? new Node<CodeElement>(array[j].Key, array[j]) : array[j].Node;
                node.Right = array[j+1].Node == null ? new Node<CodeElement>(array[j+1].Key, array[j+1]) : array[j+1].Node;

                array[j] = null;
                array[j+1].Key = node.Val;
                array[j+1].Node = node;
            }

            AssignCodes(array[array.Count()-1].Node, 0);
        }

        void AssignCodes(Node node, int code)
        {
            if (node == null)
                return;
            Node<CodeElement> codeNode = node as Node<CodeElement>;
            if (codeNode != null)
                Codes[codeNode.Value.Code] = code;
            else
            {
                AssignCodes(node.Left, code << 1);
                AssignCodes(node.Right, (code << 1) + 1);
            }
        }
    }

    public class CodeElement : Element
    {
        public string Code { get; set; }
        public Node Node { get; set; }
    }
}
