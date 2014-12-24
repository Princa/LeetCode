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

            //BinarySearchTree<int> bst = new BinarySearchTree<int>();
            //bst.Add(50);
            //bst.Add(20);
            //bst.Add(10);
            //bst.Add(40);
            //bst.Add(89);
            //bst.Add(51);
            //bst.Add(100);

            //bst.PreorderTraversal(bst.Root);
            //bst.InOrderTraversal(bst.Root);            
            //bst.PostorderTraversal(bst.Root);

            //int[] array = { 12, 11, 13, 8, 5, 7, 1 };
            int[] array = { 2, 6, 3, 12, 56, 8 };
            //int[] result = LeetCode.SearchSorting.HeapSort.DoHeapSort(array, array.Length);
            //int[] result = LeetCode.SearchSorting.SortKArray.SortK(array, array.Length, 3);
            //int[] result = LeetCode.SearchSorting.QuickSort.DoQuickSort(array, 0, array.Length - 1);
            //int[] result = LeetCode.SearchSorting.InsertionSort.DoInsertionSort(array);
            int[] result = LeetCode.SearchSorting.ShellSort.DoShellSort(array);
            //PrintArray(result);

            LinkedList.SinglyLinkedList newsll = new LinkedList.SinglyLinkedList();
            newsll.Add(1);
            newsll.Add(2);
            newsll.Add(3);
            newsll.Add(4);
            newsll.Add(5);
            newsll.Add(6);
            newsll.Add(7);
            newsll.Add(8);

            //newsll.ListAll();
            //newsll.delete(4);
            //newsll.delete(1);
            
            //newsll.IterativeReverse();
            //newsll.RecursiveReverse(newsll.root);
            //newsll.root.Next.Next.Next = newsll.root;
            //var isCycled = newsll.IsCycled();
            //Console.Write(isCycled.ToString());  
            //var mid1 = newsll.GetMiddleMethod1();
            //var mid2 = newsll.GetMiddleMethod2();
            //Console.Write(mid1 + "," + mid2);

            //newsll.ReverseAlternateNodeAppendAtLast();
            //newsll.PairwiseSwapIterative();
            newsll.PairwiseSwapRecursive(newsll.root);
            newsll.ListAll();
            //newsll.PrintReverseRecursive(newsll.root);
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
