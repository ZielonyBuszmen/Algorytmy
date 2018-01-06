using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrzewoBST
{
    /**
     * DrzewoBST
     */
    /*
     * 
     * 
     */

    class DrzewoBST<T> where T : IComparable<T>
    {
        class Node
        {
            public T value;
            public Node left;
            public Node right;

            public Node(T value)
            {
                this.value = value;
            }
        }

        Node root;

        public DrzewoBST()
        {
            this.root = null;
        }

        // pre-order z wcięciami
        public void Show()
        {
            Show(this.root, 0);
        }
        void Show(Node node, int level)
        {
            string indent = ""; // wcięcie
            int p = level;
            while (p-- > 0) indent += " ";
            if (node == null) Console.WriteLine(indent + "*");
            else
            {
                Console.WriteLine(indent + node.value);
                if (node.left != null || node.right != null)
                {
                    Show(node.left, level + 1);
                    Show(node.right, level + 1);
                }
            }
        }

        // pre-order
        public void ShowPreOrder()
        {
            this.ShowPreOrder(this.root);
        }
        private void ShowPreOrder(Node node)
        {
            if (node == null) return;
            Console.Write("({0}", node.value);
            ShowPreOrder(node.left);
            ShowPreOrder(node.right);
            Console.Write(")");
        }

        // post-order
        public void ShowPostOrder()
        {
            this.ShowPostOrder(this.root);
        }
        private void ShowPostOrder(Node node)
        {
            if (node == null) return;
            ShowPostOrder(node.left);
            ShowPostOrder(node.right);
            Console.WriteLine("{0} ", node.value);
        }

        // in-order
        public void ShowInOrder()
        {
            this.ShowInOrder(this.root);
        }
        private void ShowInOrder(Node node)
        {
            if (node == null) return;
            ShowInOrder(node.left);
            Console.Write(node.value + " ");
            ShowInOrder(node.right);
        }

        // in-order z wcięciami
        public void ShowInOrderWithIndent()
        {
            ShowInOrderWithIndent(this.root, 0);
        }
        private void ShowInOrderWithIndent(Node node, int level)
        {
            string indent = ""; // wciecie
            int p = level; // poziom
            while (p-- > 0) indent += " ";
            if (node == null)
            {
                Console.WriteLine(indent + "*");
            }
            else
            {
                if (node.left != null || node.right != null)
                {
                    ShowInOrderWithIndent(node.left, level + 1);
                }
                Console.WriteLine(indent + node.value);
                if (node.left != null || node.right != null)
                {
                    ShowInOrderWithIndent(node.right, level + 1);
                }
            }
        }

        // wysokość drzewa
        public int Height()
        {
            return Height(this.root);
        }
        private int Height(Node node)
        {
            int height = 0;
            if (node == null) return 0;
            if (node.left != null)
            {
                height = Math.Max(height, Height(node.left) + 1);
            }
            if (node.right != null)
            {
                height = Math.Max(height, Height(node.right) + 1);
            }
            return height;
        }

        // Waga
        public int Weight()
        {
            return this.Weight(this.root);
        }
        private int Weight(Node node)
        {
            if (node == null) return 0;
            int weight = 1;
            if (node.left != null)
            {
                weight += Weight(node.left);
            }
            if (node.right != null)
            {
                weight += Weight(node.right);
            }
            return weight;
        }


        // Wstawianie reukrencyjne
        public void Insert(T value)
        {
            Node node = new Node(value);
            if (this.root == null)
            {
                this.root = node;
            }
            else
            {
                Insert(this.root, node);
            }
        }
        private void Insert(Node root, Node node)
        {
            if (root.value.CompareTo(node.value) > 0)
            {
                if (root.left == null)
                {
                    root.left = node;
                }
                else
                {
                    Insert(root.left, node);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = node;
                }
                else
                {
                    Insert(root.right, node);
                }
            }
        }



        // Należy napisać metody Poprzednik i Następnik dla drzewa BST 
        //   (w sensie takim jak przy przechodzeniu drzewa w porządku in-order) (Pr dom 11)

    }


    class Program
    {
        static DrzewoBST<T> CreateTreeFromArray<T>(T[] array) where T : IComparable<T>
        {
            DrzewoBST<T> tree = new DrzewoBST<T>();
            foreach (T item in array)
            {
                tree.Insert(item);
            }
            return tree;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo BST");

            int[] array0 = new int[] { 11, 15, 6, 8, 5, 1, 7, 13, 17, 14 };
            DrzewoBST<int> drzewo0 = CreateTreeFromArray(array0);

            int[] array1 = new int[] { 16, 10, 6, 21, 20, 18, 13, 14, 17, 4, 11 };
            DrzewoBST<int> drzewo1 = CreateTreeFromArray(array1);


            int[] array2 = new int[] { 10, 16, 12, 7, 9, 2, 21, 6, 17, 1, 15 };
            DrzewoBST<int> drzewo2 = CreateTreeFromArray(array2);



            Console.WriteLine("Wypisanie pre order z wcięciem");
            drzewo2.ShowPreOrder();
            Console.WriteLine();

            Console.WriteLine("Wypisanie in order z wcięciem");
            drzewo0.ShowInOrderWithIndent();
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
