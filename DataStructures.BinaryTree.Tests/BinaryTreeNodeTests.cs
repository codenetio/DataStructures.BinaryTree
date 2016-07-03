using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.BinaryTree.Tests
{
    [TestClass]
    public class BinaryTreeNodeTests
    {
        [TestMethod]
        public void OperatorTests()
        {
            var smallNode = new BinaryTreeNode<int>(1);
            var largeNode = new BinaryTreeNode<int>(2);
            var anotherSmallNode = new BinaryTreeNode<int>(1);
            var anotherLargeNode = new BinaryTreeNode<int>(2);

            Assert.IsTrue(smallNode < largeNode);
            Assert.IsTrue(largeNode > smallNode);
            Assert.IsTrue(smallNode <= largeNode);
            Assert.IsTrue(smallNode <= anotherSmallNode);
            Assert.IsTrue(largeNode >= smallNode);
            Assert.IsTrue(largeNode >= anotherLargeNode);
        }
    }
}
