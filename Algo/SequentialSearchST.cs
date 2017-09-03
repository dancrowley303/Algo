using System;
using System.Collections.Generic;

namespace Algo
{
    public class SequentialSearchST<K, V> : SymbolTable<K, V> where K : IComparable
    {
        private Node first;
        private int n;

        private class Node
        {
            internal K key;
            internal V value;
            internal Node next;
            internal Node(K key, V value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public override V Get(K key)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                    return x.value;
            }
            //this is a little hacky since value types will not return null as expected
            return default(V);
        }

        public override void Put(K key, V value)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    x.value = value;
                    return;
                }
            }
            first = new Node(key, value, first);
            n++;
        }

        public override int Size()
        {
            return n;
        }

        public override K Ceiling(K Key)
        {
            throw new NotImplementedException();
        }

        public override void Delete(K key)
        {
            Node previous = null;
            for (Node x = first; x != null; x = x.next)
            {
                if (key.Equals(x.key))
                {
                    if (previous != null)
                        previous.next = x.next;
                    else
                        first = first.next;
                    n--;
                    return;
                }
                previous = x;
            }
        }

        public override K Floor(K Key)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<K> Keys(K lo, K hi)
        {
            for (Node x = first; x != null; x = x.next)
            {
                if (lo.Equals(x.key))
                {
                    while (!hi.Equals(x.key))
                    {
                        yield return x.key;
                        x = x.next;
                    }
                    yield return x.key;
                    yield break;
                }
            }
            yield break;
        }

        public override K Max()
        {
            var x = first;
            while (x.next != null) x = x.next;
            return x.key;
        }

        public override K Min()
        {
            return first.key;
        }

        public override int Rank(K Key)
        {
            throw new NotImplementedException();
        }

        public override K Select(int k)
        {
            throw new NotImplementedException();
        }
    }
}

