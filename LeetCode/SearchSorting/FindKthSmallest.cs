using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class FindKthSmallest
    {
        public static int FindKthSmallestFunc(int[] A, int startA, int endA, int[] B, int startB, int endB, int K)
        {
            if (K == 0) return Math.Min(A[startA], B[startB]);
            if (startA == endA) return B[K];
            if (startB == endB) return A[K];

            int i = (startA + endA) / 2;
            int j = (startB + endB) / 2;

            int mid = K / 2;
            int sub1 = Math.Min(mid, endA - startA);
            int sub2 = Math.Min(mid, endB - startB);

            if (A[startA + sub1] < B[startB + sub2]) return FindKthSmallestFunc(A, startA + sub1, endA, B, startB, endB, K - mid);
            else return FindKthSmallestFunc(A, startA, endA, B, startB + mid, endB, K - mid);

            //if ((i + j) < K)
            //{
            //    if (A[i] > B[j]) FindKthSmallestFunc(A, 0, A.Count(), B, j + 1, B.Count(), K - j - 1);
            //    else FindKthSmallestFunc(A, i + 1, A.Count(), B, 0, B.Count(), K - i - 1);
            //}
            //else
            //{
            //    if (A[i] > B[j]) FindKthSmallestFunc(A, 0, i, B, 0, B.Count(), K);
            //    else FindKthSmallestFunc(A, 0, A.Count(), B, 0, j, K);
            //}
        }
    }
}
