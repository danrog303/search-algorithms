using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.Core.Utils
{
    public class BinaryTreeNode
    {
        public char Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode()
        {

        }
        public BinaryTreeNode(char data)
        {
            this.Data = data;

        }
    }
    public class BinaryTree
    {
        private BinaryTreeNode _root;
        public BinaryTree()
        {
            _root = null;
        }
        public void Insert(char data)
        {
            // 1. Jeśli drzewo puste, return a new, single node 
            if (_root == null)
            {
                _root = new BinaryTreeNode(data);
                return;
            }
            // 2. W przeciwnym wypadku, przejdz w dol drzewa 
            InsertRec(_root, new BinaryTreeNode(data));
        }
        private void InsertRec(BinaryTreeNode root, BinaryTreeNode newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(BinaryTreeNode root)
        {
            if (root == null) return;

            DisplayTree(root.Left);
            System.Console.Write(root.Data + " ");
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            DisplayTree(_root);
        }

    }
}