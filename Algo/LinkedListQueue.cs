using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedListQueue<T> : Queue<T>, IEnumerableLinkedList<T>
    {
        private LinkedListNode<T> last;
        private int n = 0;

        public LinkedListNode<T> First { get; private set; }

        public override T Dequeue()
        {
            var item = First.Item;
            First = First.Next;
            n--;
            if (IsEmpty())
            {
                last = null;
            }
            return item;
        }

        public override void Enqueue(T item)
        {
            var oldLast = last;
            last = new LinkedListNode<T> { Item = item };
            if (IsEmpty())
            {
                First = last;
            }
            else
            {
                oldLast.Next = last;
            }
            n++;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        public override bool IsEmpty()
        {
            return n == 0;
        }

        public override int Size()
        {
            return n;
        }
    }
}
