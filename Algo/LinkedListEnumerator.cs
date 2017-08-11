using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        IEnumerableLinkedList<T> parent;

        private LinkedListNode<T> current;

        public LinkedListEnumerator(IEnumerableLinkedList<T> parent)
        {
            this.parent = parent;
            current = parent.First;
        }

        public T Current
        {
            get
            {
                T item = current.Item;
                current = current.Next;
                return item;
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current;  }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return current != null;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

}
