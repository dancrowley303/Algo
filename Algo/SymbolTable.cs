using System;
using System.Collections.Generic;

namespace Algo
{
    public abstract class SymbolTable<K, V> where K : IComparable
    {
        public abstract V Get(K key);
        public abstract void Put(K key, V value);
        public V this[K key] { get { return Get(key); } set { Put(key, value); } }
        public abstract void Delete(K key);
        public bool Contains(K key)
        {
            return Get(key) != null;
        }
        public bool IsEmpty()
        {
            return Size() == 0;
        }
        public abstract int Size();
        public abstract K Min();
        public abstract K Max();
        public abstract K Floor(K key);
        public abstract K Ceiling(K key);
        public abstract int Rank(K key);
        public abstract K Select(int k);
        public void DeleteMin()
        {
            Delete(Min());
        }
        public void DeleteMax()
        {
            Delete(Max());
        }
        public int Size(K lo, K hi)
        {
            if (hi.CompareTo(lo) < 0)
                return 0;
            else if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }
        public abstract IEnumerable<K> Keys(K lo, K hi);
        public virtual IEnumerable<K> Keys()
        {
            return Keys(Min(), Max());
        }        
    }
}
