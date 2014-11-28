using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.SearchSorting
{
    public class HeapSort
    {
        public static int[] DoHeapSort(int[] array, int arraySize)
        {
            for (int i = arraySize / 2 - 1; i >= 0; i--)
            {
                MaxHeap(array, arraySize, i);
            }
            for (int i = arraySize - 1; i > 0; i--)
            {
                Swap(array, 0, i);
                MaxHeap(array, i - 1, 0);
            }
            return array;
        }

        public static void MaxHeap(int[] array, int arraySize, int index)
        {
            var largest = index;
            var left = largest * 2 + 1;
            var right = largest * 2 + 2;

            //Need to have equal for last heap tree
            if (left <= arraySize && array[left] > array[largest]) largest = left;
            if (right <= arraySize && array[right] > array[largest]) largest = right;
            if (largest != index)
            {
                Swap(array, largest, index);
                MaxHeap(array, arraySize, largest);
            }
        }

        public static void Swap(int[] array, int bottom, int topIndex)
        {
            var temp = array[bottom];
            array[bottom] = array[topIndex];
            array[topIndex] = temp;
        }
    }
}
