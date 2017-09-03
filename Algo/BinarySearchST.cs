using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class BinarySearchST<K, V> : SymbolTable<K, V> where K : IComparable
    {
        private K[] keys;
        private V[] values;
        private int n;

        public BinarySearchST(int capacity)
        {
            keys = new K[capacity];
            values = new V[capacity];
        }

        public override int Size()
        {
            return n;
        }

        public override V Get(K key)
        {
            if (IsEmpty()) return default(V);
            int i = Rank(key);
            if (i < n && keys[i].CompareTo(key) == 0) return values[i];
            else return default(V);
        }

        public override int Rank(K key)
        {
            int lo = 0, hi = n - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }
            return lo;
        }

        public override void Put(K key, V value)
        {
            int i = Rank(key);
            if (i < n && keys[i].CompareTo(key) == 0)
            {
                values[i] = value;
                return;
            }
            for (int j = n; j > i; j--)
            {
                keys[j] = keys[j - 1];
                values[j] = values[j - 1];
            }
            keys[i] = key;
            values[i] = value;
            n++;
        }

        public override IEnumerable<K> Keys(K lo, K hi)
        {
            for (var i = Rank(lo); i <= Rank(hi); i++)
            {
                yield return keys[i];
            }
            yield break;
        }

        public override K Max()
        {
            return keys[n-1];
        }

        public override K Min()
        {
            return keys[0];
        }

        public override K Ceiling(K Key)
        {
            throw new NotImplementedException();
        }

        public override void Delete(K key)
        {
            throw new NotImplementedException();
        }

        public override K Floor(K Key)
        {
            throw new NotImplementedException();
        }

        public override K Select(int k)
        {
            return keys[k];
        }
    }
}
