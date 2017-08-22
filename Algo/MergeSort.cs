using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class MergeSort<T> : Sort<T> where T : IComparable
    {
        protected static T[] aux;

        public override void Go(T[] a)
        {
            aux = new T[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(T[] a, int lo, int hi)
        {
            // Sort a[lo..hi]
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);
            Sort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }

        protected static void Merge(T[] a, int lo, int mid, int hi)
        {
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }
            
            for(int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else
                    a[k] = aux[i++];
            }
        }
    }
}
