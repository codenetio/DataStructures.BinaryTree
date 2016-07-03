using System;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        private int _count = 0;

        public BinaryTreeNode<T> Top { get; set; }
        public int Count => _count;

        public void Add(BinaryTreeNode<T> node)
        {
            if (Top == null)
            {
                Top = node;
            }
            else
            {
                var current = Top;
                while (current != null)
                {
                    if (current <= node)
                    {
                        if (current.Right == null)
                        {
                            current.Right = node;
                            _count++;
                            return;
                        }
                        current = current.Right;
                    }
                    else
                    {
                        if (current.Left == null)
                        {
                            current.Left = node;
                            _count++;
                            return;
                        }
                        current = current.Left;
                    }
                }
            }
            _count++;
        }

        public BinaryTreeNode<T> Find(BinaryTreeNode<T> current, T value)
        {
            if (current == null)
            {
                return null;
            }

            if (current.Value.Equals(value))
            {
                return current;
            }

            if (current.Value.CompareTo(value) > 0)
            {
                return Find(current.Left, value);
            }

            return Find(current.Right, value);
        }

        public BinaryTreeNode<T> FindParent(BinaryTreeNode<T> current, T value)
        {
            // node doesn't exist in the tree.
            if (current == null)
            {
                return null;
            }

            // if the left or right of the current node == the value we're looking for
            // then the current node is the parent node.
            if ((current.Left != null && current.Left.Value.Equals(value)) ||
                (current.Right != null && current.Right.Value.Equals(value)))
            {
                return current;
            }

            // if the current node's value is greater than the target value, try to go left.
            if (current.Value.CompareTo(value) > 0)
            {
                if (current.Left == null)
                {
                    return null;
                }

                // Travel down the left leg from the current node
                // since the target value is less than the current value.
                return FindParent(current.Left, value);
            }

            // now we assume that the value is > or = to the current value, so we go right.
            if (current.Right == null)
            {
                return null;
            }

            // Travel down the right leg from the current node
            // since the target value is less than the current value.
            return FindParent(current.Right, value);
        } 

        public void Remove(T value)
        {
            // find the node.
            var node = Find(Top, value);

        } 
    }
}
