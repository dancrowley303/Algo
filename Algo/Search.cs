using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class Search
    {
        public static bool IsInCircularShift(string s, string t)
        {
            for (var i = 0; i < s.Length; i++)
            {
                if (t.IndexOf(s[i]) == -1) return false;
            }
            for (var i = 0; i < t.Length; i++)
            {
                if (s.IndexOf(t[i]) == -1) return false;
            }
            return true;
        }

        public static string ReverseString(string s)
        {
            int n = s.Length;
            if (n <= 1) return s;

            var a = s.Substring(0, n / 2);
            var b = s.Substring(n / 2, n - n / 2);
            return ReverseString(b) + ReverseString(a);
        }

        public static int IndexOf(int[] a, int key, out int searchCount)
        {
            searchCount = 0;
            var lo = 0;
            var hi = a.Length - 1;
            while (lo <= hi)
            {
                searchCount++;
                var mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }

    }
}
