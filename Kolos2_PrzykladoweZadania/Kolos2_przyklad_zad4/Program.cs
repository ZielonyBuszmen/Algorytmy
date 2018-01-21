using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos_przyklad_zad4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] po1 = { 6, 3, 1, 2, 4, 5, 7 }; // dobre dane
            Tree.RevertPreOrder(po1).Print();
            Console.WriteLine();

            int[] po2 = { 6, 3, 1, 2, 4, 7, 5 }; // złe dane
            Tree.RevertPreOrder(po2).Print();

            Console.ReadKey();
        }
    }

    class Tree
    {
        Node root;

        class Node
        {
            public Node left;
            public Node right;
            public int value;

            public Node(int value)
            {
                this.value = value;
            }

            public void Print(int level)
            {
                if (left != null)
                    left.Print(level + 1);
                for (int i = 0; i < level; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(value);
                if (right != null)
                    right.Print(level + 1);
            }
        }

        public static Tree RevertPreOrder(int[] po)
        {
            if (po.Length < 1)
                return new Tree();

            Tree tree = new Tree();
            Stack<Node> s = new Stack<Node>();
            int min = int.MinValue;
            bool left;
            Node popped = new Node(0);
            Node tmp;

            tree.root = new Node(po[0]);
            s.Push(tree.root);
            for (int i = 1; i < po.Length; i++)
            {
                left = false;
                tmp = new Node(po[i]);
                if (tmp.value < min)
                    return new Tree();
                if (tmp.value < s.Peek().value)
                {
                    s.Peek().left = tmp;
                    left = true;
                }
                while (s.Count != 0 && s.Peek().value < tmp.value)
                {
                    min = s.Peek().value;
                    popped = s.Pop();
                }
                if (!left)
                {
                    popped.right = tmp;
                }
                s.Push(tmp);
            }

            return tree;
        }

        public void Print()
        {
            if (root == null)
                Console.WriteLine("empty tree :/");
            else
                root.Print(0);
        }
    }
}

