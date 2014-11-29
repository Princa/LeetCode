using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.SearchSorting
{
    public class SortKArray
    {
        //Given an array of n elements, where each element is at most k away from its target position, devise an algorithm that sorts in O(n log k) time. 
        //For example, let us consider k is 2, an element at index 7 in the sorted array, can be at indexes 5, 6, 7, 8, 9 in the given array.

        //Use minHeap to sort for K+1 elements, remove root to assign to original array[0], add next none k+1 element from array to subtree array, then minHeap
        //if no more element to add to subtree, then keep removing root and add to original array and minHeap the rest of subtree array.

        public static int[] SortK(int[] array, int size, int k)
        {
            int[] subArray = new int[k + 1];
            for (int i = 0; i <= k && i < size; i++)
                subArray[i] = array[i];
            //MinHeapify the subArray
            for (int i = (subArray.Length - 1) / 2; i > 0; i--)
            {
                MinHeap(subArray, subArray.Length, i);
            }
            //Got K+1 subtree minheapified
            //remove root and bind to array, and add rest element from Array to subtree by 1
            for (int i = k + 1, ti = 0; ti < size; i++, ti++)
            {
                if (i < size)
                    array[ti] = ExcludeMin(subArray, subArray.Length, array[i]);
                else
                    array[ti] = ExcludeMin(subArray, i - size);
            }
            return array;
        }
        public static void MinHeap(int[] A, int size, int index)
        {
            var smallest = index;
            var left = index * 2 + 1;
            var right = index * 2 + 2;

            if (left < size && A[left] < A[smallest]) smallest = left;
            if (right < size && A[right] < A[smallest]) smallest = right;
            if (index != smallest)
            {
                Swap(A, index, smallest);
                MinHeap(A, size, smallest);
            }
        }

        public static int ExcludeMin(int[] A, int size, int nextElement)
        {
            var root = A[0];
            A[0] = nextElement;
            //MinHeap new A if nextElement > root
            if (nextElement > root)
                MinHeap(A, size, 0);
            return root;
        }

        public static int ExcludeMin(int[] A, int index)
        {
            var root = A[0];
            if (A.Length > 1)
            {
                A[0] = A[A.Length - index - 1];
                MinHeap(A, A.Length - index - 1, 0);
            }
            return root;
        }

        public static void Swap(int[] A, int bottom, int top)
        {
            var temp = A[bottom];
            A[bottom] = A[top];
            A[top] = temp;
        }
    }
}
