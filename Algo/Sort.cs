using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public static class Sort
    {
        public static int[][] RotateMatrix(int[][] matrix)
        {
            var n = matrix.Length;
            if (n == 0) throw new Exception("empty matrix");
            if (matrix[0].Length != n) throw new Exception("unbalanced matrix");
            var output = new int[n][];
            for (var i = 0; i < n; i++)
            {
                output[i] = new int[n];
            }
            for (var row = 0; row < n; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    output[col][n - row - 1] = matrix[row][col];
                }
            }
            return output;
        }

        public static void LomutoQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int p = LomutoPartition(arr, low, high);
                LomutoQuickSort(arr, low, p - 1);
                LomutoQuickSort(arr, p + 1, high);
            }
        }

        public static int LomutoPartition(int[] arr, int low, int high)
        {
            var pivot = arr[high];
            var i = low - 1;
            for (var j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i += 1;
                    Swap(arr, i, j);
                }
            }
            if (arr[high] < arr[i + 1])
            {
                Swap(arr, i + 1, high);
            }
            return ++i;
        }

        private static int DanPartition(int[] arr, int low, int high)
        {
            var pivot = arr[high];
            var i = low - 1;
            for (var j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            i++;
            if (arr[high] < arr[i])
            {
                Swap(arr, i, high);
            }
            return i;
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            int index = Partition(arr, left, right);
            if (left < index - 1)
            {
                QuickSort(arr, left, index - 1);
            }
            if (index < right)
            {
                QuickSort(arr, index, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];
            while (left <= right)
            {
                while (arr[left] < pivot) left++;
                while (arr[right] > pivot) right--;
                if (left <= right)
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }

        private static void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        public static void DanQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                var pivot = DanPartition(arr, low, high);
                DanQuickSort(arr, low, pivot - 1);
                DanQuickSort(arr, pivot + 1, high);
            }
        }

        public static int[] SortThreeNumbers(int a, int b, int c)
        {
            if (a > b) { var t = a; a = b; b = t; }
            if (a > c) { var t = a; a = c; c = t; }
            if (b > c) { var t = b; b = c; c = t; }

            return new int[] { a, b, c };
        }

        private static int bCount = 0;

        public static double Binomial(int n, int k, double p)
        {
            Console.WriteLine(++bCount);
            if ((n == 0) && (k == 0)) return 1.0;
            if ((n < 0) || (k < 0)) return 0.0;
            return (1 - p) * Binomial(n - 1, k, p) + p * Binomial(n - 1, k - 1, p);
        }
    }
}
