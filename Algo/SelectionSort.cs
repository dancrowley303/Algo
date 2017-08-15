using System;

namespace Algo
{
    public class SelectionSort<T> : Sort<T> where T:IComparable
    {
        public override void Go(T[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                int min = i;
                for (var j = i+1; j < a.Length; j++)
                {
                    if (Less(a[j], a[min])) min = j;
                }
                Exchange(a, i, min);
            }
        }
    }
}
