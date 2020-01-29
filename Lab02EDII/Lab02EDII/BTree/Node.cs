using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02EDII.Models;

namespace Lab02EDII.BTree
{
    public class stringComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    public class Node<T>
    {                
        T[] data { get; set; }
        Node<T>[] children;
        Node<T> father;        

        public Node(int order){
            data = new T[order];
            children = new Node<T>[order];            
        }

        public Node(int order, Node<T> father) {
            data = new T[order];
            children = new Node<T>[order];
            this.father = father;

        }

        public void Sort()
        {

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
