using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class FindIntersection
    {
        public static List<int> FindIntersectionTwoSortedArray(int[] A, int[] B)
        {
            int n1 = A.Count();
            int n2 = B.Count();
            List<int> intersection = new List<int>();
            int i=0,j =0;
            while (i< n1 && j < n2) {
                if (A[i] > B[j]) {
                    j++;
                } else if (A[i] < B[j])  {
                    i++;
                } else {
                    intersection.Add(A[i]);
                    i++;
                    j++;
                }
            }
            return intersection;
        }
    }
}
