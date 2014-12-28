using System;

namespace LeetCode
{
	//	Swap Nodes in Pairs Total Accepted: 31227 Total Submissions: 96262 My Submissions Question Solution 
	//Given a linked list, swap every two adjacent nodes and return its head.
	//For example,Given 1->2->3->4, you should return the list as 2->1->4->3.
	//Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
	public class SwapPairs
	{
		public SwapPairs ()
		{
		}

		public ListNode swapPairs (ListNode head) {
			if (head == null || head.next == null)
				return head;
				
			ListNode newHead = head.next;
			ListNode rest = head.next.next;

			head.next.next = head;

			head.next = swapPairs (rest);

			return newHead;

		}
			
	}

	public class ListNode
	{
		int val;
		ListNode next;

		ListNode (int x)
		{
			val = x;
			next = null;
		}
	}
}

