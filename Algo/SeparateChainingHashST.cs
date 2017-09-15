using System;
using System.Collections.Generic;

namespace Algo
{
    public class SeparateChainingHashST<K, V> : SymbolTable<K, V> where K : IComparable
    {
        private int m;

        private SequentialSearchST<K, V>[] st;

        public SeparateChainingHashST() : this(997)
        {
        }

        public SeparateChainingHashST(int m)
        {
            this.m = m;
            st = new SequentialSearchST<K, V>[m];
            for (int i = 0; i < m; i++)
            {
                st[i] = new SequentialSearchST<K, V>();
            }
        }

        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }

        public override K Ceiling(K key)
        {
            throw new NotImplementedException();
        }

        public override void Delete(K key)
        {
            throw new NotImplementedException();
        }

        public override K Floor(K key)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            return st[Hash(key)].Get(key);
        }

        public override IEnumerable<K> Keys(K lo, K hi)
        {
            throw new NotImplementedException();
        }

        public override K Max()
        {
            throw new NotImplementedException();
        }

        public override K Min()
        {
            throw new NotImplementedException();
        }

        public override void Put(K key, V value)
        {
            st[Hash(key)].Put(key, value);
        }

        public override int Rank(K key)
        {
            throw new NotImplementedException();
        }

        public override K Select(int k)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }
    }
}
