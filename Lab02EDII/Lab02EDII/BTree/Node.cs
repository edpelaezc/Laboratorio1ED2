using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02EDII.Models;

namespace Lab02EDII.BTree
{
    public class keyComparer : IComparer
    {
        public delegate int compare(object aux, object aux2);
        compare compareElements;
        public void compareElementsDelegate(compare cmp) {
            compareElements = cmp;
        }
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(object x, object y) {
            return compareElements(x, y);
        }
    }

    public class Node<T>
    {
        public keyComparer comparer = new keyComparer();
        T[] data { get; set; }
        Node<T>[] children;
        Node<T> father;

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

        public void sortData()
        {
            Array.Sort(children, comparer);
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
