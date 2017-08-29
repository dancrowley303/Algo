using System;

namespace Algo
{
    public class HeapPriorityQueue<T> : PriorityQueue<T> where T : IComparable
    {
        private T[] pq;
        private int n = 0;

        public HeapPriorityQueue(int maxN)
        {
            pq = new T[maxN+1];
        }

        public override bool IsEmpty()
        {
            return n == 0;
        }

        public override int Size()
        {
            return n;
        }

        public override void Insert(T v)
        {
            pq[++n] = v;
            Swim(n);
        }

        public override T DelMax()
        {
            T max = pq[1];
            Exchange(1, n--);
            Sink(1);
            return max;
        }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void Exchange(int i, int j)
        {
            var temp = pq[i];
            pq[i] = pq[j];
            pq[j] = temp;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2*k <= n)
            {
                int j = 2 * k;
                if (j < n && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }
    }
}
