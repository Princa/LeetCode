using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class MergeSort
    {
        public static void DoMerge(int[] A, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;
            
            int[] temp1 = new int[n1];
            int[] temp2 = new int[n2];

            for (i = 0; i < n1; i++)
            {
                temp1[i] = A[l+i];
            }

            for (i = 0 ; i < n2; i++)
            {
                temp2[i] = A[m+1 + i];
            }

            i = 0; j = 0; k = l;
            while (i < n1 && j < n2)
            {
                if (temp1[i] <= temp2[j])
                {
                    A[k] = temp1[i];
                    i++;
                }
                else
                {
                    A[k] = temp2[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                A[k] = temp1[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                A[k] = temp2[j];
                k++;
                j++;  
            }
        }

        public static void DoMergeSort(int[] A, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                DoMergeSort(A, l, m);
                DoMergeSort(A, m + 1, r);
                DoMerge(A, l, m, r);
            }
        }
    }
}
