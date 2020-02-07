using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02EDII.Models;

namespace Lab02EDII.BTree
{
    public class keyComparer<T> : IComparer<T>
    {
        public delegate int compare(T aux, T aux2);
        compare compareElements;
        public void compareElementsDelegate(compare cmp)
        {
            compareElements = cmp;
        }
        //comparación en base al delegate enviado
        public int Compare(T x, T y)
        {
            return compareElements(x, y);
        }
    }
    public class Node<T>
    {
        public keyComparer<T> keyComparer = new keyComparer<T>();
        public List<T> Data { get; set; }
        public List<Node<T>> Children { get; set; }
        public Node<T> Father { get; set; }
        public int order; 

        public Node(int order)
        {
            Data = new List<T>();
            Children = new List<Node<T>>();
            this.order = order; 
        }

        public Node(int order, Node<T> nodeFather)
        {
            Data = new List<T>();
            Children = new List<Node<T>>();
            Father = nodeFather;
        }

        internal bool IsLeaf => Children.Count == 0;

        internal bool Full => Data.Count == (order - 1);

        internal int AproxChild(T data)
        {
            int position = 0;
            for (int i = 0; i < Data.Count; i++)
            {                
                if ((keyComparer.Compare(Data[i], data) < 0) || Data[i] == null)
                {
                    position = i;
                    i = Data.Count;
                }
                if (i == Data.Count - 1)
                {
                    position = i + 1;
                    i = Data.Count;
                }
            }
            return position;
        }

        internal void InsertData(T data)
        {
            if (!Full)
            {
                Data.Add(data);
                Data.Sort(keyComparer); //ordenar datos con comparación de objetos especificada                
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
            List<T> temp = new List<T>();
            List<T> aux1 = new List<T>();
            List<T> aux2 = new List<T>();

            temp = Data;
            temp.Add(data);
            temp.Sort(keyComparer);

            for (int i = 0; i < (order / 2); i++)
            {
                aux1.Add(temp[i]);
                aux2.Add(temp[(order / 2) + i + 1]);
            }

            if (Father == null)
            {               
                Node<T> auxNode = new Node<T>(order);
                List<Node<T>> auxChildren = Children;
                auxNode.InsertData(temp[order / 2]); // insertar el dato en medio del nodo en el padre. 
                Data = auxNode.Data;                
                Children = new List<Node<T>>();
                Children.Add(new Node<T>(order));
                Children.Add(new Node<T>(order));                
                Children[0].Data = aux1;
                Children[1].Data = aux2;
                //Children[0].Father(this);
                for (int i = 0; i < ((order/2) + 1); i++)
                {
                    Children[0].Children.Add(auxChildren[i]);
                    Children[1].Children.Add(auxChildren[(order / 2) + i + 1]);
                }
            }
            else
            {
                Father.InsertData(temp[order / 2]); // insertar el dato en medio del nodo en el padre. 



                Data = aux1;
                List<Node<T>> auxChildren = Father.Children;

                int cont = 0;
                for (int i = 0; i < order; i++)
                {
                    if (Father.Children[i].Data == aux1)
                    {
                        if (Father.Children[i + 1] != null)
                        {
                            Father.Children[i + 1].Data = aux2;
                        }
                        else
                        {
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
        }

        private void AddChildren() { 
        
        }

        public int PositionInNode(T data)
        {
            int position = -1;
            for (int i = 0; i < Data.Count; i++)
            {
                if (keyComparer.Compare(data, Data[i]) == 0)
                {
                    position = i;
                    i = Data.Count;
                }
            }
            return position;
        }
    }
}
