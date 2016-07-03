
using System;
using System.Net.NetworkInformation;

namespace DataStructures.BinaryTree
{
    public class BinaryTreeNode<T>: IComparable<T> where T: IComparable
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; } 
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public static bool operator <(BinaryTreeNode<T> x, BinaryTreeNode<T> y)
        {
            return x.Value.CompareTo(y.Value) < 0;
        }

        public static bool operator >(BinaryTreeNode<T> x, BinaryTreeNode<T> y)
        {
            return x.Value.CompareTo(y.Value) > 0;
        }

        public static bool operator <=(BinaryTreeNode<T> x, BinaryTreeNode<T> y)
        {
            return x < y || x.Value.Equals(y.Value);
        }

        public static bool operator >=(BinaryTreeNode<T> x, BinaryTreeNode<T> y)
        {
            return x > y || x.Value.Equals(y.Value);
        }

    }
}
