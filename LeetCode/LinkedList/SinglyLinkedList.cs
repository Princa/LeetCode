using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.LinkedList
{
	public class SinglyLinkedList
	{

		#region Properties

		public SinglyLinkedListNode root;
		public SinglyLinkedListNode last;
		public int count;

		public SinglyLinkedListNode Head { get { return this.root; } }

		public SinglyLinkedListNode Last {
			get {
				SinglyLinkedListNode current = root;
				if (current == null)
					return null;
				while (current.Next != null)
					current = current.Next;
				return current;
			}
		}

		#endregion

		#region Constructor

		public SinglyLinkedList ()
		{
			this.root = null;
			this.last = null;
			this.count = 0;
		}

		#endregion

		#region Methods

		public void Add (object data)
		{
			SinglyLinkedListNode newNode = new SinglyLinkedListNode (data);
			if (this.root == null)
				this.root = newNode;
			else
				Last.Next = newNode;
			count++;
		}

		public void ListAll ()
		{
			SinglyLinkedListNode tempNode = this.Head;
			while (tempNode != null) {
				Console.Write (tempNode.Data + ",");
				tempNode = tempNode.Next;
			}
		}

		public void AddAfter (object data, SinglyLinkedListNode node)
		{
			SinglyLinkedListNode newNode = new SinglyLinkedListNode (data);
			if (node.Next == null)
				node.Next = newNode;
			else {
				var temp = node.Next;
				node.Next = newNode;
				newNode.Next = temp;
			}
			count++;
		}

		public void Delete (SinglyLinkedListNode node)
		{
			if (root == node) {
				root = node.Next;
				node.Next = null;
			} else {
				SinglyLinkedListNode current = root;
				while (current != null) {
					if (current.Next == node) {
						current.Next = node.Next;
						node.Next = null;
						break;
					}
					current = current.Next;
				}
			}
			count--;
		}

		public void Delete (object data)
		{
			SinglyLinkedListNode temp = root;
			//if it's root then copy root next to root.
			if (temp != null && temp.Data.ToString () == data.ToString ()) {
				root = root.Next;
			} else {
				SinglyLinkedListNode prev = null;
				while (temp != null) {
					if (temp.Data.ToString () == data.ToString ()) {
						prev.Next = temp.Next;
						break;
					}
					prev = temp;
					temp = temp.Next;
				}
			}
			count--;
		}

		public void IterativeReverse ()
		{
			SinglyLinkedListNode prev = null;
			SinglyLinkedListNode current = root;
			SinglyLinkedListNode next = null;

			while (current != null) {
				next = current.Next;
				current.Next = prev;
				prev = current;
				current = next;
			}
			root = prev;
		}

		public void RecursiveReverse (SinglyLinkedListNode node)
		{
			if (node != null && node.Next != null) {
				var next = node.Next;
				var afternext = node.Next.Next;
				var currentHead = this.root;

				this.root = next;
				this.root.Next = currentHead;
				node.Next = afternext;

				RecursiveReverse (node);
			}
		}

		public Boolean IsCycled ()
		{
			Boolean result = false;
			SinglyLinkedListNode fast = root;
			SinglyLinkedListNode slow = root;

			while (fast != null && slow != null) {
				fast = fast.Next;
				slow = slow.Next;
				if (fast == slow) {
					result = true;
					break;
				}

			}

			return result;
		}

		public object GetMiddleMethod1 ()
		{
			//Method 1 - two pointers, one slow one fast, when fast reach end, slow is middle
			SinglyLinkedListNode slow = root;
			SinglyLinkedListNode fast = root;
			while (fast != null && fast.Next != null) {
				slow = slow.Next;
				fast = fast.Next.Next;
			}
			if (slow != null)
				return slow.Data;
			else
				return null;
		}

		public object GetMiddleMethod2 ()
		{
			//Method 2 - mid = head, when it's odd number, count ++ until end, mid is middle
			SinglyLinkedListNode mid = root;
			SinglyLinkedListNode head = root;
			int count = 0;
			while (head != null) {
				if ((count % 2) != 0) { //% reminder, / divide
					mid = mid.Next;
				}
				count++;
				head = head.Next;
			}
			if (mid != null)
				return mid.Data;
			else
				return null;
		}

		//public Boolean IsPalindrome()
		//{
		//    //Method 1 - insert first half to stack, then from the 2nd half compare with stack. all match = true
		//    // require O(n) and extra space.
		//    //Method 2 - take 2nd half and reverse, match with 1st half. all match = true.
		//    // require O(n) and constant space O(1)
		//    //Method 3 - recursive loop  -- NEED MORE THINKING


		//    Boolean result = false;

		//    return result;
		//}

		public Boolean IsIntersected (SinglyLinkedList A, SinglyLinkedList B)
		{
			//if intersected then at least the last node from each LinkedList should be the same
			return (A.last == B.last);
		}

		public object FindIntersectedNode (SinglyLinkedList A, SinglyLinkedList B)
		{
			//Count difference of two lists, traverce larger one until d
			//return true if compare return match
			var d = A.count - B.count;
			var count = 0;
			var headA = A.Head;
			var headB = B.Head;
			if (d > 0) {
				while (count < Math.Abs (d)) {
					headA = headA.Next;
					count++;
				}
			} else {
				while (count < Math.Abs (d)) {
					headB = headB.Next;
					count++;
				}
			}

			while (headA != null || headB != null) {
				if (headA.Data == headB.Data) {
					return headA.Data;
				}
				headA = headA.Next;
				headB = headB.Next;
			}
			return null;
		}

		public object FindIntersectedNodeWOCompare (SinglyLinkedList A, SinglyLinkedList B)
		{
			//No comparison needed
			//x is lengh of unintersected A nodes
			//y is lengh of unintersected B nodes
			//z is lengh of intersected nodes
			//x+z = A, y+z=B
			//Reverse A, traverse B, x+y = newB
			//x = (A+newB-B)/2, y = (B+newB-A)/2, z=(A+B-newB)/2
			var c1 = A.count;
			var c2 = B.count;
			//Reverse A
			A.IterativeReverse ();
			var c3 = 0;
			var headB = B.Head;
			while (headB.Next != null) {
				headB = headB.Next;
				c3++;
			}
			var x = (c1 + c3 - c2) / 2;
			var y = (c2 + c3 - c1) / 2;
			var z = (c1 + c2 - c3) / 2;
			var count = 0;
			A.IterativeReverse ();
			var result = A.Head;
			while (count <= x) {
				count++;
				result = result.Next;
			}
			return result.Data;
		}

		public void ReverseAlternateNodeAppendAtLast ()
		{
			//Reverse alternate node and append at last Space O(1) Time O(n)
			//use odd and even, put even to the front to have reverse sequence
			SinglyLinkedListNode odd = this.root;
			var even = odd.Next;
			odd.Next = odd.Next.Next;
			odd = odd.Next;
			even.Next = null;

			//loop if more nodes
			while (odd != null && odd.Next != null) {
				var temp = odd.Next.Next;
				odd.Next.Next = even; //make next even to be head of even list
				even = odd.Next; //create even list
				odd.Next = temp; //link next odd to odd list
				if (temp != null) //if next odd node is not null, move pointer to next odd
                    odd = temp;
			}
			odd.Next = even;
		}

		public void PrintReverseRecursive (SinglyLinkedListNode head)
		{
			//recursively print the linked list
			if (head == null)
				return;
			PrintReverseRecursive (head.Next);
			Console.Write (head.Data + ",");
		}

		public void PairwiseSwapIterative ()
		{
			if (this.root == null || this.root.Next == null)
				return; //check if the linkedlist has more than 2 nodes to swap;

			SinglyLinkedListNode prev = this.root; //1
			var current = this.root.Next; //2
			this.root = current; //2

			while (true) {
				var next = current.Next; //3
				current.Next = prev; //2->1

				if (next == null || next.Next == null) {
					prev.Next = next;
					break;
				}

				prev.Next = next.Next; //1->4
				//set prev and current
				prev = next; //3
				current = prev.Next; //4              
			}
		}

		public SinglyLinkedListNode PairwiseSwapRecursive (SinglyLinkedListNode head)
		{
			//Returns the new head of LinkedList, needs to pass head to printall

			//pass sublist head and return new head to keep swaping the pair
			if (head == null || head.Next == null)
				return head;

			SinglyLinkedListNode rest = head.Next.Next;

			SinglyLinkedListNode newHead = head.Next;
			//reverse link
			head.Next.Next = head;
			head.Next = PairwiseSwapRecursive (rest);
			return newHead;
		}

		public SinglyLinkedListNode SortedIntersectionTwoLinkedList (SinglyLinkedListNode s1, SinglyLinkedListNode s2)
		{
			//Return a new singlylinkedlist with only intersected nodes in order
			//if any of the link is null then return null - base case
			if (s1 == null && s2 == null)
				return null;
			//if all are none null list, compare with two list and recursive call
			if ((int)(s1.Data) < (int)(s2.Data))
				return SortedIntersectionTwoLinkedList (s1.Next, s2);
			if ((int)(s1.Data) > (int)(s2.Data))
				return SortedIntersectionTwoLinkedList (s1, s2.Next);
			var temp = new SinglyLinkedListNode (s1.Data, SortedIntersectionTwoLinkedList (s1.Next, s2.Next));

			return temp;
		}

		public void DeleteAltIterative ()
		{
			if (this.Head == null)
				return;
			SinglyLinkedListNode prev = Head;
			SinglyLinkedListNode current = Head.Next;

			while (current != null && prev != null) {
				prev.Next = current.Next;

				prev = current.Next;
				if (current.Next != null)
					current = current.Next.Next;
			}
		}

		public void DeleteAltRecursive (SinglyLinkedListNode node)
		{
			if (node == null)
				return;
			SinglyLinkedListNode current = node.Next;

			if (current != null) {
				node.Next = current.Next;
			}

			DeleteAltRecursive (node.Next);
		}

		public SinglyLinkedListNode SortedMergeRecursive (SinglyLinkedListNode s1, SinglyLinkedListNode s2)
		{
			SinglyLinkedListNode result = new SinglyLinkedListNode ();

			if (s1 == null && s2 != null) {
				result.Data = s2.Data;
				result.Next = SortedMergeRecursive (s1, s2.Next);
			}
			if (s2 == null && s1 != null) {
				result.Data = s1.Data;
				result.Next = SortedMergeRecursive (s1.Next, s2);
			}

			if (s1 != null && s2 != null) {
				if ((int)(s1.Data) <= (int)(s2.Data)) {
					result.Data = s1.Data;
					result.Next = SortedMergeRecursive (s1.Next, s2);
				} else {
					result.Data = s2.Data;
					result.Next = SortedMergeRecursive (s1, s2.Next);
				}
			}

			return result;

		}

		#endregion

		//LinkedListNode class
		public class SinglyLinkedListNode
		{
			private object data;
			private SinglyLinkedListNode next;

			public SinglyLinkedListNode ()
			{
				this.data = null;
				this.next = null;
			}

			public SinglyLinkedListNode (object data)
			{
				this.Data = data;
				this.Next = null;
			}

			public SinglyLinkedListNode (object data, SinglyLinkedListNode next)
			{
				this.Data = data;
				this.Next = next;
			}

			public SinglyLinkedListNode Next {
				get { return next; }
				set { this.next = value; }
			}

			public object Data {
				get { return this.data; }
				set { this.data = value; }
			}
		}

	}
}
