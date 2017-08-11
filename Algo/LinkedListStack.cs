using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class LinkedListStack<T> : Stack<T>, IEnumerableLinkedList<T>
    {
        private int n = 0;

        public LinkedListNode<T> First { get; private set; }


        public override IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        public override bool IsEmpty()
        {
            return n == 0; // could also do first == null
        }

        public override T Pop()
        {
            var item = First.Item;
            First = First.Next;
            n--;
            return item;
        }

        public T Peek()
        {
            return First.Item;
        }

        public override void Push(T item)
        {
            var oldFirst = First;
            First = new LinkedListNode<T> { Item = item, Next = oldFirst };
            n++;
        }

        public override int Size()
        {
            return n;
        }
    }
}
