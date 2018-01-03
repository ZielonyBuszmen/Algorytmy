using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrzewoPotomkowAdama
{
    /*
     * Zadanie 5 Lab 9
     * (zadanie profesora Mariana Ruska)
     *  Naszym zadaniem jest stworzenie i narysowanie drzewa potomków Adama, dane są w postaci par ojciec syn.  (patrz Main())
     */

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

        // dodaje dziecko szukając ojca za pomocą stringa
        public void AddChild(string parentValue, string childValue)
        {
            if (this.value == parentValue)
            {
                Node node = new Node(childValue);
                this.AddChild(node);
                return;
            }
            if (this.children.Count > 0)
            {
                for (int i = 0; i < this.children.Count; i++)
                {
                    Node child = (Node)this.children[i];
                    child.AddChild(parentValue, childValue);
                }
            }
        }

        // PRE-ORDER
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
            Console.WriteLine("Potomkowie Adama \n");
            string[,] parySynOjciec =
            {
                {"Kain"        , "Adam"},
                {"Abel"        , "Adam"},
                {"Set"        , "Adam"},
                {"Henoch"      , "Kain"},
                {"Irad"        , "Henoch"},
                {"Mechujael"  , "Irad"},
                {"Metuszael"  , "Mechujael"},
                {"Lamek"      , "Metuszael"},
                {"Jabal"      , "Lamek"},
                {"Jubal"      , "Lamek"},
                {"Tubal-Kain"  , "Lamek"},
                {"Enosz"      , "Set" },
                {"Kenan"      , "Enosz"},
                {"Mahalaleel"  , "Kenan"},
                {"Jered"      , "Mahalaleel"},
                {"Henoch "    , "Jered"},// spacja odróżnia go od pierwszego
                {"Metuszelach" , "Henoch "},
                {"Lamek "      , "Metuszelach"}, // spacja odróżnia go od pierwszego Lameka
                {"Noe"        , "Lamek "},
                {"Sem"        , "Noe"},
                {"Cham"        , "Noe"},
                {"Jafet"      , "Noe"}
            };

            Drzewo drzewo = new Drzewo();
            drzewo.root = new Node("Adam");

            for (int i = 0; i < parySynOjciec.GetLength(0); i++)
            {
                string child = parySynOjciec[i, 0];
                string parent = parySynOjciec[i, 1];
                drzewo.root.AddChild(parent, child);
            }

            drzewo.root.ShowPreOrder();

            Console.WriteLine("\n");
            Console.WriteLine("Wysokość: {0}", drzewo.root.GetHeight());

            Console.ReadKey();
        }
    }
}
