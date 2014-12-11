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
        public SinglyLinkedListNode Last
        {
            get
            {
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
        public SinglyLinkedList()
        {
            this.root = null;
            this.last = null;
            this.count = 0;
        }
        #endregion

        #region Methods
        public void Add(object data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            if (this.root == null)
                this.root = newNode;
            else
                Last.Next = newNode;
            count++;
        }

        public void ListAll()
        {
            SinglyLinkedListNode tempNode = this.Head;
            while (tempNode != null)
            {
                Console.Write(tempNode.Data + ",");
                tempNode = tempNode.Next;
            }
        }

        public void AddAfter(object data, SinglyLinkedListNode node)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            if (node.Next == null)
                node.Next = newNode;
            else
            {
                var temp = node.Next;
                node.Next = newNode;
                newNode.Next = temp;
            }
            count++;
        }

        public void Delete(SinglyLinkedListNode node)
        {
            if (root == node)
            {
                root = node.Next;
                node.Next = null;
            }
            else
            {
                SinglyLinkedListNode current = root;
                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        node.Next = null;
                        break;
                    }
                    current = current.Next;
                }
            }
            count--;
        }

        public void Delete(object data)
        {
            SinglyLinkedListNode temp = root;
            //if it's root then copy root next to root.
            if (temp != null && temp.Data.ToString() == data.ToString())
            {
                root = root.Next;
            }
            else
            {
                SinglyLinkedListNode prev = null;
                while (temp != null)
                {
                    if (temp.Data.ToString() == data.ToString())
                    {
                        prev.Next = temp.Next;
                        break;
                    }
                    prev = temp;
                    temp = temp.Next;
                }
            }
            count--;
        }

        public void IterativeReverse()
        {
            SinglyLinkedListNode prev = null;
            SinglyLinkedListNode current = root;
            SinglyLinkedListNode next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            root = prev;
        }

        public void RecursiveReverse(SinglyLinkedListNode node)
        {
            if (node != null && node.Next != null)
            {
                var next = node.Next;
                var afternext = node.Next.Next;
                var currentHead = this.root;

                this.root = next;
                this.root.Next = currentHead;
                node.Next = afternext;

                RecursiveReverse(node);
            }
        }

        public Boolean IsCycled()
        {
            Boolean result = false;
            SinglyLinkedListNode fast = root;
            SinglyLinkedListNode slow = root;

            while (fast != null && slow != null)
            {
                fast = fast.Next;
                slow = slow.Next;
                if (fast == slow)
                {
                    result = true;
                    break;
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

            public SinglyLinkedListNode(object data)
            {
                this.Data = data;
                this.Next = null;
            }

            public SinglyLinkedListNode(object data, SinglyLinkedListNode next)
            {
                this.Data = data;
                this.Next = next;
            }

            public SinglyLinkedListNode Next
            {
                get { return next; }
                set { this.next = value; }
            }
            public object Data
            {
                get { return this.data; }
                set { this.data = value; }
            }
        }

    }
}
