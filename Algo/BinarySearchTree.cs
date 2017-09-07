using System;
using System.Collections.Generic;

namespace Algo
{
    public class BinarySearchTree<K, V> : SymbolTable<K, V> where K : IComparable
    {
        internal class Node
        {
            internal K Key;
            internal V Value;
            internal Node Left, Right;
            internal int N;

            internal Node(K key, V value, int n)
            {
                this.Key = key;
                this.Value = value;
                this.N = n;
            }

            public override string ToString()
            {
                return string.Format("{0}: {1} ({2})", Key, Value, N);
            }

        }

        private Node root;

        public override K Ceiling(K Key)
        {
            Node x = Ceiling(root, Key);
            if (x == null) throw new InvalidOperationException();
            return x.Key;
        }

        private Node Ceiling(Node x, K key)
        {
            if (x == null) return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp > 0) return Ceiling(x.Right, key);
            var t = Ceiling(x.Left, key);
            if (t != null) return t;
            else return x;
        }

        public override void Delete(K key)
        {
            throw new NotImplementedException();
        }

        public override K Floor(K key)
        {
            Node x = Floor(root, key);
            if (x == null) throw new InvalidOperationException();
            return x.Key;
        }

        private Node Floor(Node x, K key)
        {
            if (x == null) return null;
            var cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.Left, key);
            var t = Floor(x.Right, key);
            if (t != null) return t;
            else return x;
        }

        public override V Get(K key)
        {
            return Get(root, key);
        }

        private V Get(Node x, K key)
        {
            if (x == null) return default(V);
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Get(x.Left, key);
            else if (cmp > 0) return Get(x.Right, key);
            else return x.Value;
        }

        public override IEnumerable<K> Keys(K lo, K hi)
        {
            throw new NotImplementedException();
        }

        public override K Max()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            Node x = Max(root);
            return x.Key;
        }

        private Node Max(Node x)
        {
            if (x.Right == null) return x;
            return Max(x.Right);
        }

        public override K Min()
        {
            if (IsEmpty()) throw new InvalidOperationException();
            Node x = Min(root);
            return x.Key;
        }

        private Node Min(Node x)
        {
            if (x.Left == null) return x;
            return Min(x.Left);
        }

        public override void Put(K key, V value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node x, K key, V value)
        {
            if (x == null) return new Node(key, value, 1);
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0) x.Left = Put(x.Left, key, value);
            else if (cmp > 0) x.Right = Put(x.Right, key, value);
            else x.Value = value;
            x.N = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }

        public override int Rank(K Key)
        {
            throw new NotImplementedException();
        }

        public override K Select(int k)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            return Size(root);
        }

        private int Size(Node x)
        {
            if (x == null) return 0;
            else return x.N;
        }
    }
}
