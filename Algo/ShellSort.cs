using System;

namespace Algo
{
    public class ShellSort<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            //sort a[] into increasing order
            int n = a.Length;
            int h = 1;
            while (h < n / 3) h = 3 * h + 1; //1, 4, 13, 40, 121, 364, 1093, ...
            while (h >= 1)
            {
                //h-sort the array
                for (int i = h; i < n; i++)
                {
                    //insert a[i] among a[i-h], a[1-2*h], a[i-3*h]...
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j-=h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                h = h / 3;
            }
        }
    }
}
