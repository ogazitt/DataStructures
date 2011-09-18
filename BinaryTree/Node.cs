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

namespace BinaryTree
{
    public class Node
    {
        public int Val { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node()
        {
        }

        public Node(int val)
        {
            Val = val;
        }

        public void Print()
        {
            Console.WriteLine(Val);
        }
    }

    public class Node<T> : Node
    {
        public Node(int key, T value) : base(key)
        {
            Value = value;
        }

        public T Value { get; set; }
    }
}
