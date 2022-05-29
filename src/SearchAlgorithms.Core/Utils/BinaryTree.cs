using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms.Core.Utils
{
    /// <summary>
    /// Klasa reprezentująca pojedynczy węzeł drzewa binarnego.
    /// </summary>
    public class BinaryTreeNode
    {
        /// <summary>
        /// Dane zapisane w bieżącym węźle (pojedynczy znak).
        /// </summary>
        public char Data { get; set; }

        /// <summary>
        /// Lewy syn bieżącego elementu.
        /// </summary>
        public BinaryTreeNode Left { get; set; }

        /// <summary>
        /// Prawy syn bieżącego elementu.
        /// </summary>
        public BinaryTreeNode Right { get; set; }

        /// <summary>
        /// Indeks bieżącego elementu (zapamiętuje na którym indeksie dany znak pojawił się w oryginalnym łańcuchu).
        /// </summary>
        public int ElemNumber { get; set; }

        /// <summary>
        /// Konstruktor bezargumentowy umożliwiający utworzenie pustego węzła.
        /// </summary>
        public BinaryTreeNode()
        {}

        /// <summary>
        /// Konstruktor umożliwiający stworzenie obiektu reprezentującego pojedynczy węzeł drzewa binarnego.
        /// </summary>
        /// <param name="data">Znak do zapisania w węźle</param>
        /// <param name="elemNumber">Pozycja, na której znak pojawił się w oryginalnym łańcuchu</param>
        public BinaryTreeNode(char data, int elemNumber)
        {
            this.Data = data;
            this.ElemNumber = elemNumber;
        }
    }

    /// <summary>
    /// Klasa pomocnicza algorytmu odpowiedzialnego za wyszukiwanie przy pomocy drzewa binarnego. 
    /// Zawiera logikę działania drzewa binarnego. Drzewo binarne jest zrealizowane w sposób rekurencyjny.
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Przechowuje referencję do obiektu będącego "korzeniem" (czyli pierwszym elementem zapisanym w drzewie).
        /// </summary>
        public BinaryTreeNode RootNode;

        /// <summary>
        /// Konstruktor bezargumentowy inicjujący puste drzewo binarne.
        /// </summary>
        public BinaryTree()
        {
            RootNode = null;
        }

        /// <summary>
        /// Przechowuje indeks, który zostanie przekazany jako wartość pola <see cref="BinaryTreeNode.ElemNumber"/>.
        /// </summary>
        private int CurrentIndex = 0;

        /// <summary>
        /// Wstawia znak do drzewa binarnego.
        /// </summary>
        /// <param name="data">Znak, który ma być wstawiony</param>
        public void Insert(char data)
        {
            // Jeśli drzewo jest puste, utwórz nowy element i ustaw go jako korzeń 
            if (RootNode == null)
            {
                RootNode = new BinaryTreeNode(data, this.CurrentIndex++);
                return;
            }
            // W przeciwnym wypadku, przejdź w dół drzewa 
            InsertRec(RootNode, new BinaryTreeNode(data, this.CurrentIndex++));
        }

        /// <summary>
        /// Metoda pomocnicza, ułatwiająca rekurencyjne wstawianie danych do drzewa.
        /// </summary>
        /// <param name="root">Element, który tymczasowo na potrzeby wyszukiwania traktujemy jako korzeń drzewa</param>
        /// <param name="newNode">Element, który ma być wstawiony do drzewa</param>
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
    }
}