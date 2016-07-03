using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.BinaryTree.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void CountTest()
        {
            var tree = new BinaryTree<int>();
            tree.Add(new BinaryTreeNode<int>(1));
            Assert.AreEqual(1, tree.Count);
            tree.Add(new BinaryTreeNode<int>(2));
            Assert.AreEqual(2, tree.Count);
            tree.Add(new BinaryTreeNode<int>(0));
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            var tree = new BinaryTree<int>();
            var node4 = new BinaryTreeNode<int>(4);
            var node2 = new BinaryTreeNode<int>(2);
            var node6 = new BinaryTreeNode<int>(6);
            var node1 = new BinaryTreeNode<int>(1);
            var node7 = new BinaryTreeNode<int>(7);
            var node3 = new BinaryTreeNode<int>(3);
            var node5 = new BinaryTreeNode<int>(5);

            tree.Add(node4);
            tree.Add(node2);
            tree.Add(node6);
            tree.Add(node1);
            tree.Add(node7);
            tree.Add(node3);
            tree.Add(node5);

            // Expected:
            //        4
            //    2       6
            //  1   3   5   7
            Assert.AreEqual(node4, tree.Top);

            Assert.AreEqual(node2, tree.Top.Left);
            Assert.AreEqual(node1, tree.Top.Left.Left);
            Assert.AreEqual(node3, tree.Top.Left.Right);

            Assert.AreEqual(node6, tree.Top.Right);
            Assert.AreEqual(node5, tree.Top.Right.Left);
            Assert.AreEqual(node7, tree.Top.Right.Right);

            Assert.AreNotEqual(node1, tree.Top);

        }

        [TestMethod]
        public void FindParentTest()
        {
            var tree = new BinaryTree<int>();
            var node0 = new BinaryTreeNode<int>(0);
            var node1 = new BinaryTreeNode<int>(1);
            var node2 = new BinaryTreeNode<int>(2);
            var node3 = new BinaryTreeNode<int>(3);
            var node4 = new BinaryTreeNode<int>(4);
            var node5 = new BinaryTreeNode<int>(5);
            var node6 = new BinaryTreeNode<int>(6);
            var node7 = new BinaryTreeNode<int>(7);
            var node8 = new BinaryTreeNode<int>(8);
            var node9 = new BinaryTreeNode<int>(9);
            var node10 = new BinaryTreeNode<int>(10);
            var node11 = new BinaryTreeNode<int>(11);
            var node12 = new BinaryTreeNode<int>(12);
            var node13 = new BinaryTreeNode<int>(13);
            var node14 = new BinaryTreeNode<int>(14);
            var node15 = new BinaryTreeNode<int>(15);
            var node16 = new BinaryTreeNode<int>(16);

            tree.Add(node8);
            tree.Add(node4);
            tree.Add(node12);
            tree.Add(node2);
            tree.Add(node6);
            tree.Add(node10);
            tree.Add(node14);
            tree.Add(node1);
            tree.Add(node3);
            tree.Add(node5);
            tree.Add(node7);
            tree.Add(node9);
            tree.Add(node11);
            tree.Add(node13);
            tree.Add(node15);
            tree.Add(node0);
            tree.Add(node16);

            // Structure:
            //                8
            //        4               12
            //    2       6      10        14
            //  1   3   5   7  9    11  13    15
            //0                                  16

            Assert.AreEqual(node15, tree.FindParent(tree.Top, 16));
            Assert.AreEqual(node1, tree.FindParent(tree.Top, 0));
            Assert.AreEqual(node2, tree.FindParent(tree.Top, 1));
            Assert.AreEqual(node2, tree.FindParent(tree.Top, 3));
            Assert.AreEqual(node8, tree.FindParent(tree.Top, 4));

        }
    }
}
