using System;

namespace Algo
{
    public abstract class PriorityQueue<T> where T : IComparable
    {
        public abstract void Insert(T item);
        public abstract T DelMax();
        public abstract int Size();
        public abstract bool IsEmpty();

        protected static bool Less(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }

    }
}
