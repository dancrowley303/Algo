using System;

namespace Algo
{
    public class Quick3WaySort<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            Shuffle(a);
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, i = lo + 1, gt = hi;
            T v = a[lo];
            while (i <= gt)
            {
                var cmp = a[i].CompareTo(v);
                if (cmp < 0) Exchange(a, lt++, i++);
                else if (cmp > 0) Exchange(a, i, gt--);
                else i++;
            } // now a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]
            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }
    }
}
