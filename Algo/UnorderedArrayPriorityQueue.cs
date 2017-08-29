using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class UnorderedArrayPriorityQueue<T> : PriorityQueue<T> where T : IComparable
    {
        private T[] a;
        private int n;

        public UnorderedArrayPriorityQueue(int capacity)
        {
            a = new T[capacity];
        }

        protected static void Exchange(T[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;

        }

        public override void Insert(T item)
        {
            a[n++] = item;
        }

        public override T DelMax()
        {
            Sort();
            return a[--n];
        }

        public override bool IsEmpty()
        {
            return n == 0;
        }

        public override int Size()
        {
            return n;
        }

        private void Sort()
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                {
                    Exchange(a, j, j - 1);
                }
            }
        }
    }
}
