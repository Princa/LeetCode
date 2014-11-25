using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace LeetCode
{
    public class BinarySearchTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinarySearchTree() { root = null; }

        public virtual void Clear() { root = null; }

        public BinaryTreeNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        //Add a node to the BST at leaf level -> search key if not then insert key
        public virtual void Add(T data)
        {
            //create a new node
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(data);
            int result;
            BinaryTreeNode<T> current = root, parent = null;

            //search until we hit the null for current, then it's the last level
            while (current != null)
            {
                result = Comparer.DefaultInvariant.Compare(current.value, data);
                if (result == 0) return; //trying to insert a duplicate node;
                if (result < 0)
                {
                    //data > current -> go to right
                    parent = current;
                    current = current.Right;
                }
                if (result > 0)
                {
                    //data < current -> go left
                    parent = current;
                    current = current.Left;
                }
            } //end while

            //check if parent is null, then the new data is root
            if (parent == null)
            {
                root = newNode;
            }
            else
            {
                result = Comparer.DefaultInvariant.Compare(parent.value, data);
                if (result > 0)
                    parent.Left = newNode;
                else
                    parent.Right = newNode;
            }
        }

        private BinaryTreeNode<T> NewNode(T item)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(item);
            newNode.Left = null;
            newNode.Right = null;
            return newNode;
        }

        private BinaryTreeNode<T> FindNode(T data)
        {
            BinaryTreeNode<T> current = root, parent = null;
            int result = Comparer.DefaultInvariant.Compare(current.value, data);
            while (result != 0)
            {
                if (result < 0)
                {
                    //on right side
                    parent = current;
                    current = current.Right;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }

                if (current == null)
                    return null;
                else
                    result = Comparer.DefaultInvariant.Compare(current.value, data);
            }
            return current;
        }

        private BinaryTreeNode<T> FindMinValueNode(BinaryTreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public bool Delete(T data)
        {
            if (root == null) return false;

            //Find node 
            BinaryTreeNode<T> current = root, parent = null;
            int result = Comparer.DefaultInvariant.Compare(current.value, data);
            while (result != 0)
            {
                if (result < 0)
                {
                    //on right side
                    parent = current;
                    current = current.Right;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }

                if (current == null)
                    return false; //no such node
                else
                    result = Comparer.DefaultInvariant.Compare(current.value, data);
            }

            //Case 1 if current has no right child, then left would be the parent
            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = Comparer.DefaultInvariant.Compare(parent.value, current.value);
                    //compare current delete node with parent
                    if (result > 0) parent.Left = current.Left;
                    else if (result < 0) parent.Right = current.Left;
                }
            }
            //Case 2 if current right child has no left child, then current right child replace current
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                    root = current.Right;
                else
                {
                    result = Comparer.DefaultInvariant.Compare(parent.value, current.value);
                    if (result > 0) parent.Right = current.Right;
                    else if (result < 0) parent.Left = current.Right;
                }
            }
            //Case 3 if current right child has left child, replace current with current right childs' left most decendent
            else
            {
                BinaryTreeNode<T> leftMost = current.Right.Left, lmParent = current.Right;
                while (leftMost.Left != null)
                {
                    lmParent = leftMost;
                    leftMost = leftMost.Left;
                }

                lmParent.Left = leftMost.Left;
                lmParent.Right = leftMost.Right;

                if (parent == null) parent.Left = leftMost;
                else
                {
                    result = Comparer.DefaultInvariant.Compare(parent.value, current.value);
                    if (result > 0) parent.Left = leftMost;
                    else if (result < 0) parent.Right = leftMost;
                }
            }
            return true;
        }

        #region DisplayOrder

        public void InOrderTraversal(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                InOrderTraversal(current.Left);
                Console.WriteLine(current.value);
                InOrderTraversal(current.Right);
            }
        }

        public void PreorderTraversal(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                Console.WriteLine(current.value);
                PreorderTraversal(current.Left);
                PreorderTraversal(current.Right);
            }
        }

        public void PostorderTraversal(BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                PostorderTraversal(current.Left);
                PostorderTraversal(current.Right);
                Console.WriteLine(current.value);
            }
        }
        #endregion
    }



    #region BaseProperty

    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode() : base() { }
        public BinaryTreeNode(T data) : base(data, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.value = data; //base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
            this.Neighbors = children; //base.Neighbors = Children;
        }

        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[0] = value;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
                base.Neighbors[1] = value;
            }
        }
    }

    public class Node<T>
    {
        //private member-variables
        private T data;
        private NodeList<T> neighbors = null;

        public T value
        {
            get { return data; }
            set { data = value; }
        }

        protected NodeList<T> Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            foreach (Node<T> node in Items)
                if (node.value.Equals(value))
                    return node;

            return null;
        }
    }

    #endregion
}
