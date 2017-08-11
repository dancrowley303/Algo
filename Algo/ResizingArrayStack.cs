using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class ResizingArrayStack<T> : Stack<T>
    {
        private T[] a;
        private int n = 0;

        public class ResingArrayStackEnumerator<T2> : IEnumerator<T2>
        {
            ResizingArrayStack<T2> parent;
            public ResingArrayStackEnumerator(ResizingArrayStack<T2> parent)
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

        public ResizingArrayStack(int capacity)
        {
            a = new T[capacity];
        }

        public override void Push(T item)
        {
            if (n == a.Length) Resize(2 * a.Length);
            a[n++] = item;
        }

        public override T Pop()
        {
            T item = a[--n];
            a[n] = default(T); // to avoid loitering, as defined for the JVM. Not sure if this affects the .NET CLR.
            if (n > 0 && n == a.Length / 4) Resize(a.Length / 2);
            return item;
        }

        public override bool IsEmpty()
        {
            return n == 0;
        }

        public override int Size()
        {
            return n;
        }

        private void Resize(int max)
        {
            T[] temp = new T[max];
            for (int i = 0; i < n; i++)
            {
                temp[i] = a[i];
            }
            a = temp;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            // No implicit reference to parent class, unlike Java
            return new ResingArrayStackEnumerator<T>(this);
        }
    }

}
