using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.SearchSorting
{
    public class ShellSort
    {
        //ShellSort is a variant of insertion sort, instead of moving 1 step per round
        //Try to have max gap first, and devide the array into n/2 elements per group, then do insertion sort of each vertical group
        //Then minimize gap by /2, then do vertical group insertion sort until gap = 1;
        public static int[] DoShellSort(int[] A)
        {
            for (int gap = A.Length / 2; gap > 0; gap = gap / 2)
            {
                int i;
                for (i = gap; i < A.Length; i++)
                {
                    var temp = A[i];
                    int j;
                    for (j = i; j >= gap && A[j - gap] > temp; j = j - gap)
                    {
                        A[j] = A[j - gap];
                    }
                    A[j] = temp;
                }
            }
            return A;
        }
    }
}
