using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class HeapSort<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            int n = a.Length - 1;
            for (int k = n / 2; k >= 1; k--)
            {
                Sink(a, k, n);
            }
            while (n > 1)
            {
                Exchange(a, 1, n--);
                Sink(a, 1, n);
            }
        }

        private void Swim(T[] a, int k, int n)
        {
            while (k > 1 && Less(a[k / 2], a[k]))
            {
                Exchange(a, k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(T[] a, int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(a[j], a[j + 1])) j++;
                if (!Less(a[k], a[j])) break;
                Exchange(a, k, j);
                k = j;
            }
        }

    }
}
