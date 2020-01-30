using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02EDII.Models;

namespace Lab02EDII.BTree
{
    public class Node<T>
    {        
        public T[] data { get; set; }
        public Node<T>[] children;
        public Node<T> father;

        public Node(int order)
        {
            data = new T[order];
            children = new Node<T>[order];            
        }

        public Node(int order, Node<T> nodeFather)
        {
            data = new T[order];
            children = new Node<T>[order];
            father = nodeFather;
        }

        internal bool isLeaf
        {
            get
            {
                return children[0] == null;
            }
        }

        internal bool full
        {
            get
            {
                return children[children.Length - 1] != null;
            }
        }
    }
}
