using System;
using LeetCode.LinkedList;

namespace LeetCode
{
	public class MergeSortSinglyLinkedList
	{
		public MergeSortSinglyLinkedList ()
		{
		}

		public static SinglyLinkedListNode MergeSort (SinglyLinkedListNode node)
		{
			if (node == null || node.Next == null)
				return node;
				
			//do frontbacksplit until a single node
			//then do merge sort for each half
			//last do SortMerge of two singlylinkedlist
			var mid = GetMiddleNode (node);
			var backList = mid.Next;
			mid.Next = null;
			return SortMergeRecursive (MergeSort (node), MergeSort (backList));
		}

		private static SinglyLinkedListNode GetMiddleNode (SinglyLinkedListNode source)
		{
			SinglyLinkedListNode fast = source;
			SinglyLinkedListNode slow = source;
			if (source == null) {
				return source;
			}				
			while (fast.Next != null && fast.Next.Next != null) {
				fast = fast.Next.Next;
				slow = slow.Next;
			}
			return slow;				
		}

		private static SinglyLinkedListNode SortMergeRecursive (SinglyLinkedListNode s1, SinglyLinkedListNode s2)
		{
			SinglyLinkedListNode result = new SinglyLinkedListNode ();
			if (s1 == null && s2 != null) {
				result.Data = s2.Data;
				result.Next = SortMergeRecursive (s1, s2.Next);
			}
			if (s1 != null && s2 == null) {
				result.Data = s1.Data;
				result.Next = SortMergeRecursive (s1.Next, s2);
			}
			if (s1 != null && s2 != null) {
				if ((int)(s1.Data) <= (int)(s2.Data)) {
					result.Data = s1.Data;
					result.Next = SortMergeRecursive (s1.Next, s2);
				} else {
					result.Data = s2.Data;
					result.Next = SortMergeRecursive (s1, s2.Next);
				}
			}				
			return result;
		}
	}
}

