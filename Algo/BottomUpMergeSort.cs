using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BottomUpMergeSort<T> : MergeSort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            Sort(a);
        }

        private static void Sort(T[] a)
        {
            int n = a.Length;
            aux = new T[n];

            for (int len = 1; len < n; len *= 2)
            {
                for(int lo = 0; lo < n-len; lo += len+len)
                {
                    Merge(a, lo, lo + len - 1, Math.Min(lo + len + len - 1, n - 1));
                }
            }
        }
    }
}
