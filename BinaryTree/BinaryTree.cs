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

// standard implementation of Binary Tree operations
// supports duplicate keys
// Delete implementation out of CLR book
// Pretty-printing and Depth undone
namespace BinaryTree
{
    public class BinaryTree
    {
        Node root = null;

        public BinaryTree()
        {
        }

        /// <summary>
        /// Delete a node by key.  This will only delete one occurence of a 
        /// node with that key.
        /// </summary>
        /// <param name="val">Key of node to delete</param>
        public void Delete(int val)
        {
            Node curr = Find(val);
            Node parent = FindParent(root, val);
            Node node = null, nodeParent = null, nodeChild = null;
            if (curr.Left == null || curr.Right == null)
                node = curr;
            else
                node = FindSuccessor(curr);

            nodeParent = FindParent(root, node.Val);

            if (node.Left != null)
                nodeChild = node.Left;
            else
                nodeChild = node.Right;

            if (nodeParent == null) // root
            {
                root = nodeChild;
            }
            else
            {
                if (node == nodeParent.Left)
                    nodeParent.Left = nodeChild;
                else
                    nodeParent.Right = nodeChild;
            }
            if (node != curr)
                curr.Val = node.Val;
        }

        /// <summary>
        /// Delete a node from the binary tree
        /// </summary>
        /// <param name="node">Node reference</param>
        public void Delete(Node node)
        {
            Delete(node.Val);
        }

        /// <summary>
        /// Find a node given a key
        /// </summary>
        /// <param name="val">Key of node to find</param>
        /// <returns>First node found with that key</returns>
        public Node Find(int val)
        {
            return Find(root, val);
        }

        /// <summary>
        /// Find the node with the next biggest key
        /// </summary>
        /// <param name="curr">Input node</param>
        /// <returns>Successor node</returns>
        public Node FindSuccessor(Node curr)
        {
            if (curr.Right != null)
            {
                curr = curr.Right;
                while (curr.Left != null)
                    curr = curr.Left;
                return curr;
            }
            else
            {
                Node Parent = FindParent(root, curr.Val);
                Node LastParent = curr;
                while (Parent != null && Parent.Right == LastParent)
                {
                    LastParent = Parent;
                    Parent = FindParent(root, Parent.Val);
                }
                return Parent;
            }
        }

        /// <summary>
        /// Insert a node into the binary tree
        /// </summary>
        /// <param name="node">Node to insert</param>
        public void Insert(Node node)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            InsertHelper(root, node);
        }

        /// <summary>
        /// Pretty-print the binary tree
        /// </summary>
        public void Print()
        {
            // not implemented
        }

        /// <summary>
        /// Do a pre-order walk of the tree and print the key of each node
        /// </summary>
        public void PrintSorted()
        {
            Print(root);
        }

        #region Helpers

        int Depth()
        {
            // not implemented
            return 0;
        }

        Node Find(Node curr, int val)
        {
            if (curr == null)
                return null;
            if (curr.Val == val)
                return curr;
            if (val < curr.Val)
                return Find(curr.Left, val);
            return Find(curr.Right, val);
        }

        Node FindParent(Node curr, int val)
        {
            if (curr == null)
                return null;
            if (curr.Left != null && curr.Left.Val == val)
                return curr;
            if (curr.Right != null && curr.Right.Val == val)
                return curr;
            if (val < curr.Val)
                return FindParent(curr.Left, val);
            return FindParent(curr.Right, val);
        }

        void InsertHelper(Node curr, Node node)
        {
            if (node.Val < curr.Val)
            {
                if (curr.Left == null)
                    curr.Left = node;
                else
                    InsertHelper(curr.Left, node);
            }
            else
            {
                if (curr.Right == null)
                    curr.Right = node;
                else
                    InsertHelper(curr.Right, node);
            }
        }

        void Print(Node node)
        {
            if (node == null)
                return;
            Print(node.Left);
            Console.WriteLine(node.Val);
            Print(node.Right);
        }

        #endregion
    }
}
