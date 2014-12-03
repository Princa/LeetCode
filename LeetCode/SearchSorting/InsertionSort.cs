using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.SearchSorting
{
    //Insertion sort - take first element, compare all its previous elements, and if previous is greater than element
    //all element move forward 1 position, and move the smallest one to the far left
    public class InsertionSort
    {
        public static int[] DoInsertionSort(int[] array)
        {
            int i, k, j;
            for (i = 0; i < array.Length; i++)
            {
                k = array[i];
                j = i - 1;
                while (j > 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j+1] = k;
            }
            return array;
        }
    }
}
