using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KopiecBinarnyJakoDrzewo
{
    class Node
    {
        public int value;
        public Node left = null;
        public Node right = null;

        public Node(int value)
        {
            this.value = value;
        }

        // dodaje lewe dziecko
        public void AddLeft(Node leftChild)
        {
            this.left = leftChild;
        }

        // dodaje prawe dziecko
        public void AddRight(Node rightChild)
        {
            this.right = rightChild;
        }

        // PRE-ORDER
        public void ShowPreOrder()
        {
            Console.Write("({0}", this.value);
            if (this.left != null)
            {
                this.left.ShowPreOrder();
            }
            if (this.right != null)
            {
                this.right.ShowPreOrder();
            }
            Console.Write(")");
        }

        // zwraca wysokość
        public int GetHeight()
        {
            int height = 0;
            if (this.left != null)
            {
                height = Math.Max(height, this.left.GetHeight() + 1);
            }
            if (this.right != null)
            {
                height = Math.Max(height, this.right.GetHeight() + 1);
            }
            return height;
        }
    }

    // klasa kopca jako drzewo binarne
    class HeapInBinaryTree
    {
        public Node root = null;

        // tworzy kopiec z tablicy
        public static HeapInBinaryTree CreateHeap(int[] heap)
        {
            HeapInBinaryTree heapTree = new HeapInBinaryTree();
            Node node = new Node(heap[0]);
            heapTree.root = node; // przypisanie roota

            BuildHelper(heap, 0, node);
            return heapTree;
        }

        // funkcja pomocnicza w budowaniu kopca - wywoływana jest rekyranyjcnie
        private static void BuildHelper(int[] heap, int root, Node node)
        {
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // dopóki są dzieci
            if (left < heap.Length)
            {
                node.left = new Node(heap[left]);
                BuildHelper(heap, left, node.left);
            }
            if (right < heap.Length)
            {
                node.right = new Node(heap[right]);
                BuildHelper(heap, right, node.right);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kopiec binany jako drzewo binarne");
            int[] heap1 = { 23, 17, 14, 7, 13, 10, 1, 5, 6, 12 };

            HeapInBinaryTree heapTree = HeapInBinaryTree.CreateHeap(heap1);
            heapTree.root.ShowPreOrder();

            Console.ReadKey();
        }
    }
}
