using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinearProbingHashST<K, V> : SymbolTable<K, V> where K : IComparable
    {
        private int n;
        private int m;
        private K[] keys;
        private V[] values;

        public LinearProbingHashST() : this(16)
        {
        }

        public LinearProbingHashST(int m)
        {
            this.m = m;
            keys = new K[m];
            values = new V[m];
        }

        private int Hash(K key)
        {
            return (key.GetHashCode() & 0x7fffffff) % m;
        }

        private void Resize(int cap)
        {
            var t = new LinearProbingHashST<K, V>(cap);
            for (int i = 0; i < m; i++)
            {
                if (!keys[i].Equals(default(K))) t.Put(keys[i], values[i]);
            }
            keys = t.keys;
            values = t.values;
            m = t.m;
        }

        public override K Ceiling(K key)
        {
            throw new NotImplementedException();
        }

        public override void Delete(K key)
        {
            if (!Contains(key)) return;
            var i = Hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % m;
            keys[i] = default(K);
            values[i] = default(V);
            i = (i + 1) % m;
            while (!keys[i].Equals(default(K)))
            {
                K keyToRedo = keys[i];
                V valueToRedo = values[i];
                n--;
                Put(keyToRedo, valueToRedo);
                i = (i + 1) % m;
            }
            n--;
            if (n > 0 && n <= m / 8) Resize(m / 2);
        }

        public override K Floor(K key)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            for (int i = Hash(key); !keys[i].Equals(default(K)); i = (i+1)%m)
            {
                if (keys[i].Equals(key)) return values[i];
            }
            return default(V);
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
            if (n >= m / 2) Resize(2 * m);
            int i;
            for (i = Hash(key); !keys[i].Equals(default(K)); i = (i+1) % m)
            {
                if (keys[i].Equals(key))
                {
                    values[i] = value;
                    return;
                }
            }
            keys[i] = key;
            values[i] = value;
            n++;
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
