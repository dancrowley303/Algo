using System;

namespace Algo
{
    public class ShellSortWithArray<T> : Sort<T> where T : IComparable
    {
        public override void Go(T[] a)
        {
            int[] increments = new int[] { 1, 4, 13, 40, 121, 364, 1093, 3280, 9841, 29524, 88573, 265720, 797161, 2391484, 7174453 };
            int incrementIndex = 0;

            //sort a[] into increasing order
            int n = a.Length;
            int h = increments[incrementIndex];
            while (h < n / 3) h = increments[++incrementIndex];
            while (incrementIndex >= 0)
            {
                h = increments[incrementIndex];
                //h-sort the array
                for (int i = h; i < n; i++)
                {
                    //insert a[i] among a[i-h], a[1-2*h], a[i-3*h]...
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exchange(a, j, j - h);
                    }
                }
                incrementIndex--;
            }
        }
    }
}
