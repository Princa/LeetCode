using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.SearchSorting
{
    public class QuickSort
    {
        //Divide and conqure algorithm.
        //pick a number (last one e.x) as pivot then compare all elements with this pivot number
        //If smaller or equal update to left side of Pivot
        //If greater then update to right side of Pivot
        //Take pivot position and do both side recursively until last one, each round will return a pivot number be it's place
        //O(nlogn) as normal, O(n2) worsed case

        public static int[] DoQuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                var p = Partition(array, start, end);
                DoQuickSort(array, start, p - 1);
                DoQuickSort(array, p + 1, end);
            }
            return array;
        }

        public static int Partition(int[] array, int start, int end)
        {
            //take last as pivot as always
            var x = array[end];
            var i = start - 1;
            //need to exclude the last element as it's X
            for (int j = start; j <= end - 1; j++)
            {
                if (array[j] < x)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, end);
            return (i + 1);
        }

        public static void Swap(int[] A, int bottom, int top)
        {
            var temp = A[bottom];
            A[bottom] = A[top];
            A[top] = temp;
        }
    }
}
