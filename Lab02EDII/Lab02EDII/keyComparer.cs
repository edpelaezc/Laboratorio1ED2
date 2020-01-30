using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02EDII
{
    public class keyComparer<T> : IComparer<T>
    {
        public delegate int compare(T aux, T aux2);
        compare compareElements;
        public void compareElementsDelegate(compare cmp)
        {
            compareElements = cmp;
        }
        public int Compare(T x, T y)
        {
            return compareElements(x, y);
        }
    }
}
