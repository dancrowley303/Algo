using System;
using System.Collections.Generic;

namespace Algo
{
    public class RedBlackBST<K, V> : SymbolTable<K, V> where K : IComparable
    {
        internal enum NodeColor
        {
            Black,
            Red
        }

        internal class Node
        {
            internal K Key;
            internal V Value;
            internal Node Left, Right;
            internal int N;
            internal NodeColor Color;

            internal Node(K key, V value, int n, NodeColor color)
            {
                this.Key = key;
                this.Value = value;
                this.N = n;
                this.Color = color;
            }

            public override string ToString()
            {
                return string.Format("Node-{0}-{1}", Key, Color);
            }
        }

        private Node root;

        private bool IsRed(Node x)
        {
            return NodeColor.Red == (x?.Color ?? NodeColor.Black);
        }

        private Node RotateLeft(Node h)
        {
            var x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = NodeColor.Red;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private Node RotateRight(Node h)
        {
            var x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = NodeColor.Red;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private void FlipColors(Node h)
        {
            h.Color = NodeColor.Red;
            h.Left.Color = NodeColor.Black;
            h.Right.Color = NodeColor.Black;
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
            throw new NotImplementedException();
        }

        public override K Min()
        {
            throw new NotImplementedException();
        }

        public override void Put(K key, V value)
        {
            root = Put(root, key, value);
            root.Color = NodeColor.Black;
        }

        private Node Put(Node h, K key, V value)
        {
            if (h == null) return new Node(key, value, 1, NodeColor.Red);

            var cmp = key.CompareTo(h.Key);
            if (cmp < 0) h.Left = Put(h.Left, key, value);
            else if (cmp > 0) h.Right = Put(h.Right, key, value);
            else h.Value = value;

            if (IsRed(h.Right) && !IsRed(h.Left)) h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left)) h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right)) FlipColors(h);

            h.N = Size(h.Left) + Size(h.Right) + 1;
            return h;
        }

        public override int Rank(K key)
        {
            return Rank(key, root);
        }

        private int Rank(K key, Node x)
        {
            //return number of keys less than key in the subtree rooted at x.
            if (x == null) return 0;
            var cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Rank(key, x.Left);
            else if (cmp > 0) return 1 + Size(x.Left) + Rank(key, x.Right);
            else return Size(x.Left);
        }

        public override K Select(int k)
        {
            if (k < 0 || k >= Size()) throw new InvalidOperationException();
            var x = Select(root, k);
            return x.Key;
        }

        private Node Select(Node x, int k)
        {
            //return node containing the key of rank k
            if (x == null) return null;
            var t = Size(x.Left);
            if (t > k) return Select(x.Left, k);
            else if (t < k) return Select(x.Right, k - t - 1);
            else return x;
        }

        public override int Size()
        {
            return Size(root);
        }

        private int Size(Node x)
        {
            return x?.N ?? 0;
        }


    }
}
