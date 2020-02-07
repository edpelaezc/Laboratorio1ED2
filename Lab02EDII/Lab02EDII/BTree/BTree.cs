using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02EDII.BTree
{
    public class BTree<T>
    {
        public Node<T> root;
        int order; 

        //public BTree()
        //{
        //    this.root = null;
        //    this.order = 5;
        //}

        public BTree(int order) {
            this.root = new Node<T>(order);
            this.order = order;
        }

        public void Add(T element) {
            Insert(this.root, element);
        }

        private void Insert(Node<T> root, T element) {

            //if (!(root.PositionInNode(element) != -1)) // el dato no está incluido en el nodo
            //{
                if (root.IsLeaf) // si es un nodo hoja 
                {
                    root.InsertData(element);
                }
                else
                {
                    Insert(root.Children[root.AproxChild(element)], element);
                }
            //}            
        }
        
        //public void sortData()
        //{
        //    Array.Sort(children, comparer);
        //}

    }
}
