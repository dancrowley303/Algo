using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public abstract class Stack<T> : IEnumerable<T>
    {
        public abstract void Push(T item);
        public abstract T Pop();
        public abstract bool IsEmpty();
        public abstract int Size();

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
