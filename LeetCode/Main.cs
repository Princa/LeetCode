using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 2, 4, 5, 5, 6, 6, 6, 6, 7, 8, 9 };
            //int n = arr.Count();
            //int x = 6;
            //int RecursiveSearchResult = BinarySearch.RecursiveSearch(arr, 0, n - 1, x);
            //if (RecursiveSearchResult == -1)
            //{
            //    Console.WriteLine("no such value.");
            //}
            //else
            //{
            //    Console.WriteLine("value is at index " + RecursiveSearchResult.ToString());
            //}

            //int iterativeSearchResult = BinarySearch.IterativeSearch(arr, 0, n - 1, x);
            //if (iterativeSearchResult == -1)
            //{
            //    Console.WriteLine("no such value.");
            //}
            //else
            //{
            //    Console.WriteLine("value is at index " + iterativeSearchResult.ToString());
            //}

            //int NumberOfOccurance = CountNumberOfOccurenceSortedArray.count(arr, x, arr.Count());
            //if (NumberOfOccurance == -1) Console.WriteLine("No such value.");
            //else Console.WriteLine("the number has " + NumberOfOccurance.ToString());

            ////Find Kth smallest
            //int[] A = {1,2,4,5,6,8,10,23,25,88};
            //int[] B = {8,20,29,30,50};
            //int k = 5;
            //int result = FindKthSmallest.FindKthSmallestFunc(A, 0, A.Count() - 1, B, 0, B.Count() - 1, k);
            //Console.WriteLine(k.ToString() + "th smallest is " + result.ToString());

            //int[] TestArr = { 12, 5, 333, 23, 2, 8, 98, 64, 3, 67, 21 };
            //MergeSort.DoMergeSort(TestArr, 0, TestArr.Length - 1);
            //PrintArray(TestArr);           

            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Add(50);
            bst.Add(20);
            bst.Add(10);
            bst.Add(40);
            bst.Add(89);
            bst.Add(51);
            bst.Add(100);

            bst.PreorderTraversal(bst.Root);
            bst.InOrderTraversal(bst.Root);            
            bst.PostorderTraversal(bst.Root);


            Console.ReadLine();
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }
    }
}
