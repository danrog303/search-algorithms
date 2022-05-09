using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    public class Node
    {
        public char Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {

        }
        public Node(char data)
        {
            this.Data = data;

        }
    }
    public class BinaryTree
    {
        private Node _root;
        public BinaryTree()
        {
            _root = null;
        }
        public void Insert(char data)
        {
            // 1. Jeśli drzewo puste, return a new, single node 
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            // 2. W przeciwnym wypadku, przejdz w dol drzewa 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
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
        private void DisplayTree(Node root)
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



    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Node root = new Node();

            tree.Insert('A');
            tree.Insert('D');
            tree.Insert('I');
          

            tree.DisplayTree();
        }
    }
}
