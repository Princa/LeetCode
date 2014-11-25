using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class CountNumberOfOccurenceSortedArray
    {
        public static int count(int[] arr, int x, int n)
        {
            int i;
            int j;
            i = First(arr, 0, n - 1, x, n);
            if (i == -1) return i;
            j = Last(arr, i, n - 1, x, n);
            return j - i + 1;
        }

        public static int First(int[] arr, int l, int r, int x, int n)
        {
            if (r >= l)
            {
                int mid = (l + r) / 2;
                if ((mid == 0 || x > arr[mid - 1]) && (x == arr[mid])) return mid;
                if (x > arr[mid]) return First(arr, mid + 1, r, x, n);
                else return First(arr, l, mid - 1, x, n);
            }
            return -1;
        }

        public static int Last(int[] arr, int l, int r, int x, int n)
        {
            if (r >= l)
            {
                int mid = (l + r) / 2;
                if ((mid == n - 1 || x < arr[mid + 1]) && (x == arr[mid])) return mid;
                if (x < arr[mid]) return Last(arr, l, (mid - 1), x, n);
                else return Last(arr, (mid + 1), r, x, n);
            }
            return -1;
        }
    }
}
