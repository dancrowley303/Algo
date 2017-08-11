using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class CircularQueue<T>
    {
        private LinkedListNode<T> last;
        private int n = 0;

        public T Dequeue()
        {
            var item = last.Next.Item;
            last.Next = last.Next.Next;
            n--;
            if (IsEmpty())
            {
                last = null;
            }
            return item;
        }

        public void Enqueue(T item)
        {
            var insert = new LinkedListNode<T> { Item = item };
            if (last == null)
            {
                insert.Next = insert;
                last = insert;
            } else
            {
                var first = last.Next;
                insert.Next = first;
                last.Next = insert;
                last = insert;
            }
            n++;
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public int Size()
        {
            return n;
        }
    }
}
