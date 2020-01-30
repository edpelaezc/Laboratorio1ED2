using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02EDII.BTree
{
    public class keyComparer : IComparer
    {
        public delegate int compare(object aux, object aux2);
        compare compareElements;
        public void compareElementsDelegate(compare cmp)
        {
            compareElements = cmp;
        }
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(object x, object y)
        {
            return compareElements(x, y);
        }
    }

    public class BTree<T>
    {
        public keyComparer comparer = new keyComparer();
        Node<T> root;
        int order; 
        public BTree(int order) {
            root = null;
            this.order = order;
        }

        public void add(T element) {
            if (this.root == null) 
            { //Si la raiz es nula
                root = new Node<T>(order);

                for (int i = 0; i < order; i++)
                {
                    root.data[0] = element;
                }
            }
            else 
            {
                insert(this.root, element);
            }
        }

        private void insert(Node<T> root, T element) {
            if (root.isLeaf) // si es un nodo hoja 
            {
                if (!root.full) { // si el nodo hoja no está lleno 
                    int i = 0;
                    while (root.data[i] != null)
                    {
                        i++;
                    }
                    root.data[i] = element;
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
