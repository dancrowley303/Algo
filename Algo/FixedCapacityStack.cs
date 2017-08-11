using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class FixedCapacityStack<T> : Stack<T>
    {
        private T[] a;
        private int n;

        public class FixedCapacityStackEnumerator<T2> : IEnumerator<T2>
        {
            FixedCapacityStack<T2> parent;
            public FixedCapacityStackEnumerator(FixedCapacityStack<T2> parent)
            {
                this.parent = parent;
            }

            public T2 Current {
                get { return parent.a[--parent.n]; }
            }

            Object IEnumerator.Current
            {
                get { return parent.a[--parent.n]; }
            }
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return parent.n > 0;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public FixedCapacityStack(int capacity)
        {
            a = new T[capacity];
        }

        public override void Push(T item)
        {
            a[n++] = item;
        }

        public override T Pop()
        {
            return a[--n];
        }

        public override bool IsEmpty()
        {
            return n == 0;
        }

        public override int Size()
        {
            return n;
        }

        public bool IsFull()
        {
            return a.Length == n;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            // No implicit reference to parent class, unlike Java
            return new FixedCapacityStackEnumerator<T>(this);
        }
    }

}
