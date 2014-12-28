using System;

namespace LeetCode
{
	//Given a linked list, remove the nth node from the end of list and return its head.
	//Given linked list: 1->2->3->4->5, and n = 2.
	//After removing the second node from the end, the linked list becomes 1->2->3->5.
	//	Note:
	//	Given n will always be valid.
	//	Try to do this in one pass.

	public class RemoveNthFromEndList
	{
		public ListNode removeNthFromEnd (ListNode head, int n)
		{
			ListNode ahead = head;
			ListNode behind = head;
			ListNode dummy = new ListNode (0);
			dummy.next = head;

			while (ahead != null && n > 0) {
				ahead = ahead.next;
				n--;
			}
			if (n > 0)
				return head.next;

			ListNode temp = dummy;
			while (ahead != null) {
				ahead = ahead.next;
				behind = behind.next;
				temp = temp.next;
			}
			temp.next = behind.next.next;
			return dummy.next;
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

