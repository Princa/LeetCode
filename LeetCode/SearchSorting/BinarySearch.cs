using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class BinarySearch
    {
        public static int RecursiveSearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int i;
                int mid = (r + l) / 2;
                if (x == arr[mid]) return mid;
                if (x > arr[mid]) return RecursiveSearch(arr, mid + 1, r, x);
                else return RecursiveSearch(arr, l, mid - 1, x);
            }
            return -1;
        }

        public static int IterativeSearch(int[] arr, int l, int r, int n)
        {
            if (r >= l)
            {
                while (l <= r)
                {
                    int mid = (r + l) / 2;
                    if (arr[mid] == n) return mid;
                    if (n > arr[mid]) l = mid + 1;
                    else r = mid - 1;
                }
            }
            return -1;
        }
    }
}
