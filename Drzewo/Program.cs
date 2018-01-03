using System;
using System.Collections;

namespace Drzewo
{
    class Node
    {
        public string value;
        public ArrayList children = new ArrayList();

        public Node(string value)
        {
            this.value = value;
            this.children = new ArrayList();
        }

        // inicjuje węzeł danymi
        public void InitNode(string value)
        {
            this.value = value;
            this.children = new ArrayList();
        }

        // dodaje dziecko 
        public void AddChild(Node child)
        {
            this.children.Add(child);
        }

        // PRE-ORDER - 
        public void ShowPreOrder()
        {
            // najpierw rodzic
            Console.Write("({0}", this.value);
            if (this.children.Count > 0)
            {
                for (int i = 0; i < this.children.Count; i++)
                {
                    Node child = (Node)this.children[i];
                    child.ShowPreOrder();
                }
            }
            Console.Write(")");
        }

        // POST-ORDER
        public void ShowPostOreder()
        {
            // najpierw potomkowie
            if (this.children.Count > 0)
            {
                for (int i = 0; i < this.children.Count; i++)
                {
                    Node child = (Node)this.children[i];
                    child.ShowPostOreder();
                }
            }
            Console.Write(" {0}", this.value);
        }

        // Zwraca wysokość
        public int GetHeight()
        {
            int height = 0;
            for (int i = 0; i < this.children.Count; i++)
            {
                Node child = (Node)this.children[i];
                height = Math.Max(height, child.GetHeight() + 1);
            }
            return height;
        }
    }

    class Drzewo
    {
        public Node root;
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo\n");

            Drzewo drzewo = new Drzewo();
            drzewo.root = new Node("F");

            Node wB = new Node("B");
            Node wA = new Node("A");
            Node wC = new Node("C");
            Node wD = new Node("D");
            Node wE = new Node("E");
            Node wG = new Node("G");
            Node wH = new Node("H");
            Node wI = new Node("I");

            wD.AddChild(wC);
            wD.AddChild(wE);
            wB.AddChild(wA);
            wB.AddChild(wD);
            wI.AddChild(wH);
            wG.AddChild(wI);

            drzewo.root.AddChild(wB);
            drzewo.root.AddChild(wG);

            Console.WriteLine("Pre-order:");
            drzewo.root.ShowPreOrder();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Post-order:");
            drzewo.root.ShowPostOreder();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Wysokosc = {0}", drzewo.root.GetHeight());

            Console.ReadKey();
        }
    }
}
