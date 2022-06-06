using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAlgorithms.Core.Utils;

namespace SearchAlgorithms.UnitTests.Core.Utils
{
    [TestClass]
    public class BinaryTree_Test
    {
        [TestMethod]
        public void Insert_CheckIfInsertionWorksCorrectly_Case1()
        {
            var tree = new BinaryTree();
            tree.Insert('c');
            tree.Insert('a');

            Assert.AreEqual('c', tree.RootNode.Data);
            Assert.AreEqual('a', tree.RootNode.Left.Data);
        }

        [TestMethod]
        public void Insert_CheckIfInsertionWorksCorrectly_Case2()
        {
            var tree = new BinaryTree();
            tree.Insert('d');
            tree.Insert('f');

            Assert.AreEqual('d', tree.RootNode.Data);
            Assert.AreEqual('f', tree.RootNode.Right.Data);
        }
    }
}
