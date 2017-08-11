using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class DoubleNode<T>
    {
        public DoubleNode<T> Previous;
        public DoubleNode<T> Next;
        public T Item;

        public static DoubleNode<T> First(DoubleNode<T> node)
        {
            var current = node;
            while (current != null && current.Previous != null)
            {
                current = current.Previous;
            }
            return current;
        }

        public static DoubleNode<T> Last(DoubleNode<T> node)
        {
            var current = node;
            while (current != null && current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        public static void InsertAtBeginning(DoubleNode<T> node, DoubleNode<T> insert)
        {
            var current = First(node);
            insert.Next = current;
            if (current != null)
            {
                current.Previous = insert;
            }
        }

        public static void InsertAtEnd(DoubleNode<T> node, DoubleNode<T> insert)
        {
            var current = Last(node);
            insert.Previous = current;
            if (insert.Previous != null) insert.Previous.Next = insert;
        }

        public static void RemoveFromBeginning(DoubleNode<T> node)
        {
            var current = First(node);
            current.Next.Previous = null;
            current.Next = null;
        }

        public static void RemoveFromEnd(DoubleNode<T> node)
        {
            var current = Last(node);
            current.Previous.Next = null;
            current.Previous = null;
        }

        public static void InsertBefore(DoubleNode<T> node, DoubleNode<T> insert)
        {
            insert.Next = node;
            if (node != null && node.Previous != null)
            {
                node.Previous.Next = insert;
            }
            if (node != null)
            {
                node.Previous = insert;
            }
        }

        public static void InsertAfter(DoubleNode<T> node, DoubleNode<T> insert)
        {
            insert.Previous = node;
            insert.Next = node.Next;
            if (node != null && node.Next != null)
            {
                node.Next.Previous = insert;
            }                
            if (node != null)
            {
                node.Next = insert;
            }
        }

        public static void RemoveNode(DoubleNode<T> node, DoubleNode<T> remove)
        {
            var current = First(node);
            while (current.Next != null)
            {
                if (current == remove)
                {
                    var previous = current.Previous;
                    var next = current.Next;
                    previous.Next = next;
                    next.Previous = previous;
                }
                current = current.Next;
            }
        }
    }
}
