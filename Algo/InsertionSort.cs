using System;

namespace Algo
{
    public class InsertionSort<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j-1]); j--)
                {
                    Exchange(a, j, j - 1);
                }
            }
        }
    }
}
