using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_przyklad_zad2
{

    // zadanie 2

    // Opracuj strukturę danych Zbiór opartą na liście dowiązaniowej. Napisz metodą Suma (mnogościowa) 
    // tworzącą listę z elementów dwóch list. Napisz także metodę Iloczyn (mnogościowy) tworzący listę z elementów wspólnych 
    // (o takiej samej wartości klucza) z dwóch list. Dodaj metodę Różnica (mnogościowa).
    // Rozważ dwa przypadki listy nieuporządkowane i uporządkowane. Jaka jest złożoność opracowanych algorytmów (metod)?
    class ZbiórNaLiscie
    {
        protected Node head = null;

        public ZbiórNaLiscie()
        {
        }

        public ZbiórNaLiscie(params int[] values)
        {
            foreach (int value in values)
            {
                this.Dodaj(value);
            }
        }

        public static ZbiórNaLiscie Suma(ZbiórNaLiscie zbior1, ZbiórNaLiscie zbior2)
        {
            ZbiórNaLiscie wynik = new ZbiórNaLiscie();
            for (Node temp = zbior1.head; temp != null; temp = temp.next)
            {
                wynik.Dodaj(temp.value);
            }

            for (Node temp = zbior2.head; temp != null; temp = temp.next)
            {
                if (!wynik.CzyZawiera(temp.value))
                {
                    wynik.Dodaj(temp.value);
                }
            }
            return wynik;
        }

        public static ZbiórNaLiscie Iloczyn(ZbiórNaLiscie zbior1, ZbiórNaLiscie zbior2)
        {
            ZbiórNaLiscie wynik = new ZbiórNaLiscie();
            for (Node temp = zbior1.head; temp != null; temp = temp.next)
            {
                if (zbior2.CzyZawiera(temp.value))
                {
                    wynik.Dodaj(temp.value);
                }
            }
            return wynik;
        }

        public static ZbiórNaLiscie Różnica(ZbiórNaLiscie zbior1, ZbiórNaLiscie zbior2)
        {
            ZbiórNaLiscie wynik = new ZbiórNaLiscie();
            for (Node temp = zbior1.head; temp != null; temp = temp.next)
            {
                if (!zbior2.CzyZawiera(temp.value))
                {
                    wynik.Dodaj(temp.value);
                }
            }
            return wynik;
        }

        public void Dodaj(int value)
        {
            Node node = new Node();
            node.value = value;
            node.next = this.head;
            this.head = node;
        }

        public bool CzyZawiera(int wartosc)
        {
            for (Node temp = this.head; temp != null; temp = temp.next)
            {
                if (temp.value == wartosc) return true;
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (Node temp = this.head; temp != null; temp = temp.next)
            {
                result += temp.value + ", ";
            }
            return result;
        }

    }

    class ZbiórNaLiścieUporządkowanej : ZbiórNaLiscie
    {

        public ZbiórNaLiścieUporządkowanej()
        {
        }

        public ZbiórNaLiścieUporządkowanej(params int[] values)
        {
            foreach (int value in values)
            {
                this.Dodaj(value);
            }
        }

        public bool Dodaj(int value)
        {
            Node newNode = new Node();
            newNode.value = value;

            // gdy lista jest pusta
            if (head == null)
            {
                head = newNode;
                return true;
            }
            // gdy jest jeden element
            if (head.next == null)
            {
                if (head.value <= newNode.value) // dodajemy na prawo
                {
                    head.next = newNode;
                }
                else // dodajemy na lewo
                {
                    newNode.next = head;
                    head = newNode;
                }
                return true;
            }


            // w innym wypadku, gdy elementow jest wiecej:
            // 1) sprawdzamy czy nie wstawić elementu przed wszystkimi elementami
            if (head.value >= newNode.value)
            {
                newNode.next = head;
                head = newNode;
                return true;
            }

            //  2) szukamy odpowiedniego miejsca na wstawienie elementu
            for (Node temp = head; temp != null; temp = temp.next)
            {
                Node current = temp;
                Node next = temp.next;
                if (next == null && current.value <= newNode.value) // gdy jest to ostatni element
                {
                    temp.next = newNode;
                    break;
                }
                else if (next != null)
                {
                    if (current.value <= newNode.value && next.value >= newNode.value) // wstawianie pomiedzy
                    {
                        newNode.next = next;
                        current.next = newNode;
                        break;
                    }
                }
            }
            return true;
        }
    }

    class Node
    {
        public int value;
        public Node next;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zbiór na liście");
            ZbiórNaLiscie z1 = new ZbiórNaLiscie(1, 2, 4, 6, 8, 10, 12, 15);
            ZbiórNaLiscie z2 = new ZbiórNaLiscie(2, 4, 5, 7, 8, 9, 0);
            ZbiórNaLiścieUporządkowanej z3 = new ZbiórNaLiścieUporządkowanej(2, 4, 5, 7, 8, 9, 0);

            Console.WriteLine("Zbiór 1: {0}", z1);
            Console.WriteLine("Zbiór 2: {0}", z2);
            Console.WriteLine();

            Console.WriteLine("Suma: {0}", ZbiórNaLiscie.Suma(z1, z2));
            Console.WriteLine("Iloczyn: {0}", ZbiórNaLiscie.Iloczyn(z1, z3));
            Console.WriteLine("Różnica: {0}", ZbiórNaLiścieUporządkowanej.Różnica(z1, z2));

            Console.ReadKey();
        }
    }
}
