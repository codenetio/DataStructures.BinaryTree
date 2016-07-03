using System;
using System.Collections.Generic;
using System.Linq;

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
            var parentNode = FindParent(Top, value);

            if (parentNode == null)
            {
                Top = node.Right;
                // removing top node, move left side to far left of right side.
                var lastNode = node.Right.Left;
                while (lastNode.Left != null)
                {
                    lastNode = lastNode.Left;
                }
                lastNode.Left = node.Left;
                return;
            }

            var isLeft = parentNode.Left == node;

            if (node.Left == null && node.Right == null)
            {
                // node is terminal (leaf)
                if (isLeft)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }
            }
            else if (node.Left == null && node.Right != null)
            {
                // left is null, right is not
                if (isLeft)
                {
                    parentNode.Left = node.Right;
                }
                else
                {
                    parentNode.Right = node.Right;
                }
            }
            else if (node.Right == null && node.Left != null)
            {
                // right is null, left is not
                if (isLeft)
                {
                    parentNode.Left = node.Left;
                }
                else
                {
                    parentNode.Right = node.Left;
                }
            }
            else
            {
                // node has left and right branches.
                if (isLeft)
                {
                    var left = node.Left;
                    var right = node.Right;
                    parentNode.Left = node.Right;

                    if (right != null)
                    {
                        if (right.Left == null)
                        {
                            right.Left = left;
                        }
                        else
                        {
                            var lastNode = right.Left;
                            while (lastNode.Left != null)
                            {
                                lastNode = lastNode.Left;
                            }
                            lastNode.Left = left;
                        }
                    }
                }
                else
                {
                    var left = node.Left;
                    var right = node.Right;
                    parentNode.Right = node.Left;

                    if (left != null)
                    {
                        if (left.Right == null)
                        {
                            left.Right = right;
                        }
                        else
                        {
                            var lastNode = left.Right;
                            while (lastNode.Right != null)
                            {
                                lastNode = lastNode.Right;
                            }
                            lastNode.Right = right;
                        }
                    }
                }
            }

        }

        public IList<T> ToDepthFirstList()
        {
            var list = new List<T>();
            ToDepthFirstList(Top, list);
            return list;
        }

        public IList<T> ToBreadthFirstList()
        {
            var list = new List<T>();
            ToBreadthFirstList(Top, list);
            return list;
        }

        private void ToBreadthFirstList(BinaryTreeNode<T> currentNode, IList<T> list)
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(currentNode);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                list.Add(node.Value);
                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }

        private void ToDepthFirstList(BinaryTreeNode<T> currentNode, IList<T> list)
        {
            if (currentNode != null)
            {
                if (currentNode.Left != null)
                {
                    ToDepthFirstList(currentNode.Left, list);
                }

                list.Add(currentNode.Value);

                if (currentNode.Right != null)
                {
                    ToDepthFirstList(currentNode.Right, list);
                }
            }
        }
    }
}
