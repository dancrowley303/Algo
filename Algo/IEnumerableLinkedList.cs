using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public interface IEnumerableLinkedList<T>
    {
        LinkedListNode<T> First { get; }
    }
}
