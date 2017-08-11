using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public abstract class Queue<T> : IEnumerable<T>
    {
        public abstract void Enqueue(T item);
        public abstract T Dequeue();
        public abstract bool IsEmpty();
        public abstract int Size();

        public abstract IEnumerator<T> GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
