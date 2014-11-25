using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class MedianTwoSortedArray
    {
        public static int FindMedianTwoSortedArray(int[] A, int m, int[] B, int n)
        {

            int i = m / 2;
            int j = n / 2;
            if (A[i] <= B[j])
            {
                int k = 0;
                if (m / 2 == 0)
                {
                    k = Math.Min(i - 1, n - j - 1);
                }
                else
                {
                    k = Math.Min(i, n - j - 1);
                }
                return FindMedianTwoSortedArray(A, k, B, n);
            }
            else
            {
                //if (n/2 == 0) { int k = 0; }
                //else {int k =0;}
                //return FindMedianTwoSortedArray(A, 


            }

            return -1;
        }

    }
}
