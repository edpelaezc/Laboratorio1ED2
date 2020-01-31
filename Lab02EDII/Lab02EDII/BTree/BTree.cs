using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02EDII.BTree
{
    public class BTree<T>
    {
        public keyComparer comparer = new keyComparer();
        Node<T> root;
        int order; 

        public BTree()
        {
            this.root = null;
            this.order = 5;
        }

        public BTree(int order) {
            this.root = null;
            this.order = order;
        }

        public void Add(T element) {
            if (this.root == null) 
            { //Si la raiz es nula
                this.root = new Node<T>(this.order);
                root.Data[0] = element;
                root.Children = null;
            }
            else 
            {
                Insert(this.root, element);
            }
        }

        private void Insert(Node<T> root, T element) {
            if (root.IsLeaf) // si es un nodo hoja 
            {
                if (!root.Full) { // si el nodo hoja no está lleno 
                    int i = 0;
                    while (root.Data[i] != null)
                    {
                        i++;
                    }
                    root.Data[i] = element;
                }
            }
            else
            {

            }
        }
        
        //public void sortData()
        //{
        //    Array.Sort(children, comparer);
        //}

    }
}
