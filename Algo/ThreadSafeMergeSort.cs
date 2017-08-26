using System;

namespace Algo
{
    public class ThreadSafeMergeSort<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            var aux = new T[a.Length];
            Sort(a, aux, 0, a.Length - 1);
        }

        private static void Sort(T[] a, T[] aux, int lo, int hi)
        {
            // Sort a[lo..hi]
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        protected static void Merge(T[] a, T[] aux, int lo, int mid, int hi)
        {
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
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
