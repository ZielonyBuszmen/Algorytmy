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
    /* Lista metod:
     *  - Show() - wyświetla jako pre-order z wcięciami
     *  - ShowPreOrder() - wyświetla jako pre-order z nawiasami (A(B(C)))
     *  - ShowPostOrder() - pokazuje post-order (ze spacjami)
     *  - ShowInOrder() - pokazuje in-order (ze spacjami)
     *  - ShowInOrderWithIndent - pokazuje in-order z wcięciami
     *  - Height() - Wysokość drzewa
     *  - Weight() - waga drzewa
     *
     *  - Insert() - wstawianie rekurencyjne
     *  - InsertIteratively() - wstawia iteracyjnie
     *  - Delete() - usuwa iteracyjnie podany węzeł
     *  - GetMaxElement() - zwraca najwiekszy element
     *  - GetMinElement() - zwraca najmniejszy element
     *  - Search() - szuka węzła o podanej wartości - rekurencyjnie
     *  - SearchIteratively() - szuka węzła iteracyjnie
     *
     *  - RightRotation() - (obrót) rotacja węzła w prawo - nie zmienia się IN-ORDER, zmiany można zaobserwować w pre-order
     *  - LeftRotation() - (obrót) rotacja węzła w lewo
     *  - InsertNewRoot() - wstawianie nowego węzła do korzenia przy wykorzystaniu obrotów
     *
     *  - FindSuccerssor() - szuka następnika, jeśli nie znajdzie zwraca podane value
     *  - FindPredecessor() - szuka poprzednika, jeśli nie znajdzie zwraca podane value
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

        // Wysokość drzewa
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

        // Wstawianie rekurencyjne
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

        // wstawianie iteracyjne
        public void InsertIteratively(T value)
        {
            if (this.root == null)
            {
                this.root = new Node(value);
            }
            else
            {
                Node temp = this.root;
                while (true)
                {
                    if (value.CompareTo(temp.value) < 0)
                    {
                        if (temp.left == null)
                        {
                            temp.left = new Node(value);
                            return;
                        }
                        else
                        {
                            temp = temp.left;
                        }
                    }
                    else
                    {
                        if (temp.right == null)
                        {
                            temp.right = new Node(value);
                            return;
                        }
                        else
                        {
                            temp = temp.right;
                        }
                    }
                }
            }
        }

        // Usuwa ITERACYJNIE podany węzeł z drzewa (metoda z wykładu, uuujowo napisana)
        public void Delete(T value)
        {
            if (this.root == null) return;
            Node temp = this.root;
            Node parent = null;

            while (temp != null)
            {
                if (temp.value.CompareTo(value) == 0)
                {
                    // tylko jedno dziecko, albo wcale
                    if (temp.left == null)
                    {
                        if (parent == null) // usuwamy korzeń
                        {
                            this.root = temp.right;
                        }
                        else
                        {
                            if (parent.left == temp) parent.left = temp.right;
                            else parent.right = temp.right;
                        }
                    }
                    else if (temp.right == null)
                    {
                        if (parent == null) // usuwamy korzeń
                        {
                            this.root = temp.left;
                        }
                        else
                        {
                            if (parent.left == temp) parent.left = temp.left;
                            else parent.right = temp.left;
                        }
                    }
                    else if (temp.left != null && temp.right != null)
                    {   //krok w lewo
                        Node qParent = temp;
                        Node q = temp.left;
                        while (q.right != null) // teraz do oporu w prawo
                        {
                            qParent = q;
                            q = q.right;
                        }
                        // Usuwamy q z jego miejsca, a na jego miejsce wstawiamy lewego potomka (moze byc null)
                        if (qParent.right == q) qParent.right = q.left;
                        else qParent.left = q.left;
                        // teraz q przenosimy na miejsce temp
                        if (parent == null) // usuwamy korzeń
                        {
                            this.root = q;
                        }
                        else
                        {
                            if (parent.left == temp) parent.left = q;
                            else parent.right = q;
                        }
                        // na koniec wstawiamy potomkow temp jako potomkow q
                        q.left = temp.left;
                        q.right = temp.right;
                    }
                    return;
                }
                parent = temp; // szukamy dalej
                if (temp.value.CompareTo(value) > 0) temp = temp.left;
                else temp = temp.right;
            }
            return; // nie zaleziono
        }

        // Zwraca największy element (zad 5A lab 11)
        public T GetMaxElement()
        {
            return this.GetMaxElement(this.root).value;
        }
        private Node GetMaxElement(Node node)
        {
            Node temp = node;
            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }

        // Zwraca najmniejszy element (zad 5B lab 11)
        public T GetMinElement()
        {
            return this.GetMinElement(this.root).value;
        }
        private Node GetMinElement(Node node)
        {
            Node temp = node;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }

        // Szuka węzła o podanej wartości - REKURENCYJNIE
        public bool Search(T value)
        {
            return this.Search(this.root, value) != null;
        }
        private Node Search(Node root, T value)
        {
            if (root == null) return null;
            if (root.value.CompareTo(value) == 0) return root;
            if (root.value.CompareTo(value) < 0)
            {
                return this.Search(root.right, value);
            }
            else
            {
                return this.Search(root.left, value);
            }
        }

        // Szuka węzła o podanej wartości - ITERACYJNIE (zad 5C lab 11)
        public bool SearchIteratively(T value)
        {
            if (root == null) return false;
            Node temp = this.root;
            while (true)
            {
                if (temp.value.CompareTo(value) == 0) return true;
                if (temp.value.CompareTo(value) < 0)
                {
                    if (temp.right == null) return false;
                    temp = temp.right;
                }
                else
                {
                    if (temp.left == null) return false;
                    temp = temp.left;
                }
            }
        }

        // pobiera wartość węzła, znajduje go w drzewie i wykonuje rotację w PRAWO
        public void RightRotation(T value)
        {
            Node parent = this.FindParent(value);
            Node node = Search(this.root, value);
            Node temp = node.left;
            node.left = temp.right;
            temp.right = node;
            node = temp;

            // sprawdzenie, do której "odnogi" parenta musimy przyłączyć węzeł
            if (parent != null)
            {
                bool isRightChild = parent.right.value.CompareTo(value) == 0;
                if (isRightChild)
                {
                    parent.right = node;
                }
                else
                {
                    parent.left = node;
                }
            }
        }

        // pobiera wartość węzła, znajduje go w drzewie i wykonuje rotację w LEWO
        public void LeftRotation(T value)
        {
            Node parent = this.FindParent(value);
            Node node = Search(this.root, value);
            Node temp = node.right;
            node.right = temp.left;
            temp.left = node;
            node = temp;

            if (parent != null)
            {
                bool isRightChild = parent.right.value.CompareTo(value) == 0;
                if (isRightChild)
                {
                    parent.right = node;
                }
                else
                {
                    parent.left = node;
                }
            }
        }

        // Wstawia nowy korzeń przy pomocy obrotów
        // nie działa - sposób z wykładu
        public void InserNewRoot(T value)
        {
            Node newNode = new Node(value);
            InsertNewRoot(this.root, newNode);
        }
        private void InsertNewRoot(Node węzeł, Node nowy)
        {
            if (węzeł == null)
            {
                węzeł = nowy;
                return;
            }

            if (węzeł.value.CompareTo(nowy.value) > 0)
            {
                InsertNewRoot(węzeł.left, nowy);
                RightRotation(węzeł.value);
            }
            else
            {
                InsertNewRoot(węzeł.right, nowy);
                RightRotation(węzeł.value);
            }
            return;
        }

        // szuka następnika w drzewie - jeśli nie znajdzie zwraca podane value
        public T FindSuccerssor(T value)
        {
            Node node = this.Search(this.root, value);
            if (node.right != null)
            {
                return this.GetMinElement(node.right).value;
            }
            Node parent = this.FindParent(value);
            while (parent != null && parent.left != null && parent.left.value.CompareTo(node.value) != 0)
            {
                node = parent;
                parent = this.FindParent(parent.value);
            }

            if (parent == null) return value;
            else return parent.value;
        }

        // Szuka poprzednika  w drzewie - jeśli nie znajdzie zwraca podane value
        public T FindPredecessor(T value)
        {
            Node node = this.Search(this.root, value);
            if (node.left != null)
            {
                return this.GetMaxElement(node.left).value;
            }
            Node parent = this.FindParent(value);
            while (parent != null && parent.right != node)
            {
                node = parent;
                parent = this.FindParent(parent.value);
            }

            if (parent == null) return value;
            else return parent.value;
        }

        // metoda pomocnicza do poprzednika i następnika - znajduje rodzica danego węzła
        private Node FindParent(T childrenValue)
        {
            return FindParent(this.root, childrenValue);
        }
        private Node FindParent(Node node, T childrenValue) // metoda reukurencyjna, pomocnicza do FindParent(T childrenValue)
        {
            if (node.value.CompareTo(childrenValue) == 0) return null; // zabezpieczenie przed "nieznalezieniem dziecka"
            if (node.left == null && node.right == null)
                return null;

            if ((node.left != null && node.left.value.CompareTo(childrenValue) == 0)
                || (node.right != null && node.right.value.CompareTo(childrenValue) == 0))
                return node;

            if (node.value.CompareTo(childrenValue) < 0)
            {
                return this.FindParent(node.right, childrenValue);
            }
            else
            {
                return this.FindParent(node.left, childrenValue);
            }
        }
    }

    class Program
    {
        public static DrzewoBST<T> CreateTreeFromArray<T>(T[] array) where T : IComparable<T>
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
            Console.WriteLine("In order:");
            drzewo0.ShowInOrder();
            Console.WriteLine();
            Console.WriteLine("Pre-order: ");
            drzewo0.ShowPreOrder();
            Console.WriteLine();
            drzewo0.LeftRotation(15);
            Console.WriteLine("In order bez zmian");
            drzewo0.ShowInOrder();
            Console.WriteLine();
            Console.WriteLine("Pre-order ze zmianami");
            drzewo0.ShowPreOrder();


            Console.WriteLine();

            int[] array1 = new int[] { 16, 10, 6, 21, 20, 18, 13, 14, 17, 4, 11 };
            DrzewoBST<int> drzewo1 = CreateTreeFromArray(array1);


            int[] array2 = new int[] { 10, 16, 12, 7, 9, 2, 21, 6, 17, 1, 15 };
            DrzewoBST<int> drzewo2 = CreateTreeFromArray(array2);

            Console.ReadKey();
        }
    }
}
