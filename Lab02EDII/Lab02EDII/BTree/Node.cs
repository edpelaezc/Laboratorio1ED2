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
        public void compareElementsDelegate(compare cmp)
        {
            compareElements = cmp;
        }
        //comparación en base al delegate enviado
        public int Compare(object x, object y)
        {
            return compareElements(x, y);
        }
    }
    public class Node<T>
    {
        private keyComparer keyComparer = new keyComparer();
        public T[] Data { get; set; }
        public Node<T>[] Children { get; set; }
        public Node<T> Father { get; set; }
        public int order; 

        public Node(int order)
        {
            Data = new T[order - 1];
            Children = new Node<T>[order];
            this.order = order; 
        }

        public Node(int order, Node<T> nodeFather)
        {
            Data = new T[order];
            Children = new Node<T>[order];
            Father = nodeFather;
        }

        internal bool IsLeaf => Children[0] == null;

        internal bool Full => Data[Data.Length - 1] != null;

        internal int AproxChild(T data)
        {
            int position = 0;
            for (int i = 0; i < Data.Length; i++)
            {                
                if ((keyComparer.Compare(Data[i], data) < 0) || Data[i] == null)
                {
                    position = i;
                    i = Data.Length;
                }
                if (i == Data.Length - 1)
                {
                    position = i + 1;
                    i = Data.Length;
                }
            }
            return position;
        }

        internal void InsertData(T data)
        {
            if (!Full)
            {
                for (int i = 0; i < Data.Length; i++)
                {
                    if (Data[i] == null) {
                        Data[i] = data;
                        i = Data.Length;
                    }                    
                }
                Array.Sort(Data, keyComparer); //ordenar un arreglo con comparación especificada
            }
            else
            {
                SplitNode(data);
            }
        }

        internal void DeleteData(T data)
        {

        }
        
        private void SplitNode(T data)
        {
            T[] temp = new T[order];
            T[] aux1 = new T[order - 1];
            T[] aux2 = new T[order - 1];
            for (int i = 0; i < Data.Length; i++) {
                temp[i] = Data[i];
            }
            temp[order - 1] = data;
            Array.Sort(temp, keyComparer);

            Father.InsertData(temp[order / 2]); // insertar el dato en medio del nodo en el padre. 
            
            for (int i = 0; i < (order / 2); i++)
            {
                aux1[i] = temp[i];
                aux2[i] = temp[(order / 2) + i + 1];
            }

            Data = aux1;
            Node<T>[] auxChildren = Father.Children;
            
            int cont = 0;
            for (int i = 0; i < order; i++)
            {                
                if (Father.Children[i].Data == aux1)
                {
                    if (Father.Children[i + 1] != null) { 
                        Father.Children[i + 1].Data = aux2; 
                    }
                    else { 
                        Father.Children[i + 1] = new Node<T>(order);
                        Father.Children[i + 1].Data = aux2;
                    }
                    cont++;
                }
                else
                {
                    Father.Children[cont] = auxChildren[i];
                }
                cont++;
            }

        }

        private void AddChildren() { 
        
        }

        public int PositionInNode(T data)
        {
            int position = -1;
            for (int i = 0; i < Data.Length; i++)
            {
                if (keyComparer.Compare(data, Data[i]) == 0)
                {
                    position = i;
                    i = Data.Length;
                }
            }
            return position;
        }
    }
}
