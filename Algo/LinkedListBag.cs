using System.Collections.Generic;

namespace Algo
{
    public class LinkedListBag<T> : Bag<T>, IEnumerableLinkedList<T>
    {
        private int n = 0;

        public LinkedListNode<T> First { get; private set; }

        public override void Add(T item)
        {
            var oldFirst = First;
            First = new LinkedListNode<T> { Item = item, Next = oldFirst };
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
