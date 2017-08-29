using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class UnorderedArrayPriorityQueue<T> : Sort<T> where T : IComparable
    {
        private T[] a;
        private int n;

        public UnorderedArrayPriorityQueue(int capacity)
        {
            a = new T[capacity];
        }

        public void Insert(T item)
        {
            a[n++] = item;
        }

        public T DelMax()
        {
            Sort();
            return a[--n];
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public int Size()
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

        public override void Go(T[] a)
        {
            throw new NotImplementedException();
        }
    }
}
