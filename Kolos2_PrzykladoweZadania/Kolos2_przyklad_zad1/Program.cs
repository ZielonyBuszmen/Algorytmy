using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_przyklad_zad1
{
    /*
     * ZADANIE 1 z przykładowego kolosa nr 2
     *  Zadanie zostało zrobione na własnej liście. Zadanie 1B zostało zrobione na typach wbudowanych
     *
     * Jeśli liczba zadań na kolosie to 5, a czas przeznaczony na kolosa to 80 minut, to na zadanie przypada 16 minut
     * Nie ma żadnych szans, by poniższy kod napisać w tym czasie.
     * 
     */
    // Chcemy reprezentować wielomiany w postaci listy jednokierunkowej par (współczynnik; wykładnik). 
    // Uwaga: przechowujemy tylko współczynniki niezerowe. Napisz zestaw metod do tworzenia takich wielomianów 
    // na podstawie tablicy, a także dodawania i odejmowania takich wielomianów oraz różniczkowania.
    // Np.tworzenie z tablicy {1,2,5,0,0,8}
    // oznacza 8x^5 + 5x^2 + 2x + 1. Odpowiednia lista ma mieć postać(8;5)->(5;2)->(2;1)->(1;0)

    class Node
    {
        public int wspolczynnik;
        public int wykladnik;
        public Node next;

        public Node(int wspolczynnik, int wykladnik)
        {
            this.wspolczynnik = wspolczynnik;
            this.wykladnik = wykladnik;
        }
    }

    class ListaJednokierunkowa
    {
        Node head;
        Node rear;

        // FuNKCJA STATYCZNA - tworzy wielomian z tablicy
        public static ListaJednokierunkowa CreateFromArray(int[] data)
        {
            ListaJednokierunkowa result = new ListaJednokierunkowa();

            for (int wykladnik = 0; wykladnik < data.Length; wykladnik++)
            {
                int wspolczynnik = data[wykladnik];
                if (wspolczynnik == 0) continue;
                result.AddFront(data[wykladnik], wykladnik);
            }
            return result;
        }

        // dodaje element na początku (przed wszystkimi innymi)
        private void AddFront(int wspolczynnik, int wykladnik)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(wspolczynnik, wykladnik);
                return;
            }

            Node newNode = new Node(wspolczynnik, wykladnik);
            newNode.next = head;
            head = newNode;
        }

        // dodaje element na końcu (po wszystkich elementach)
        public void AddEnd(int wspolczynnik, int wykladnik)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(wspolczynnik, wykladnik);
                return;
            }

            Node newNode = new Node(wspolczynnik, wykladnik);
            rear.next = newNode;
            rear = newNode;
        }

        // funkcja prywatna, potrzebna tylko do uzytku wewnetrznego - dodaje pierwszy element (tzn. gdy lista była wcześniej pusta)
        private void AddFirstElement(int wspolczynnik, int wykladnik)
        {
            Node newNode = new Node(wspolczynnik, wykladnik);
            this.head = newNode;
            this.rear = newNode;
        }


        // zwraca rozmiar listy (ilość elementów)
        public int GetSize()
        {
            int counter = 0;
            for (Node temp = head; temp != null; temp = temp.next)
            {
                counter++;
            }
            return counter;
        }

        // wyświetla wszystkie elementy listy w postaci (wspolczynnik -> wykladnik)
        public void Show()
        {
            Console.WriteLine();
            if (head == null)
            {
                Console.WriteLine("PUSTO");
            }

            for (Node temp = head; temp != null; temp = temp.next)
            {
                Console.Write("({0};{1})", temp.wspolczynnik, temp.wykladnik);
                if (temp.next != null) Console.Write("->");
            }
            Console.WriteLine();
        }

        // Dodaje do wielomianu drugi wielomian
        public void Dodaj(ListaJednokierunkowa w2)
        {
            // przechodzimy po w2
            for (Node temp = w2.head; temp != null; temp = temp.next)
            {
                if (this.DejMnieWspolczynnik(temp.wykladnik) != 0) // sumowanie
                {
                    this.DodajDoWspolczynnika(temp.wykladnik, temp.wspolczynnik);
                }
                else // dodawanie nowego
                {
                    this.DodajNowyWykladnik(temp.wykladnik, temp.wspolczynnik);
                }
            }
        }

        // Odejmuje od wielomianu drugi wielomian
        public void Odejmij(ListaJednokierunkowa w2)
        {
            // przechodzimy po this.head
            for (Node temp = w2.head; temp != null; temp = temp.next)
            {
                if (this.DejMnieWspolczynnik(temp.wykladnik) != 0) // odejmowanie
                {
                    this.DodajDoWspolczynnika(temp.wykladnik, temp.wspolczynnik * -1); //tricky mnożenie * -1
                }
                else // dodawanie nowego
                {
                    this.DodajNowyWykladnik(temp.wykladnik, temp.wspolczynnik * -1);
                }
            }
        }

        // Różniczkuje wielomian
        public void Rozniczkoj()
        {
            for (Node temp = this.head; temp != null; temp = temp.next)
            {
                temp.wspolczynnik *= temp.wykladnik;
                temp.wykladnik -= 1;
                if (temp.wykladnik < 0)
                {
                    this.Delete(temp.wykladnik);
                }
            }
        }


        private int DejMnieWspolczynnik(int wykladnik)
        {
            for (Node temp = head; temp != null; temp = temp.next)
            {
                if (temp.wykladnik == wykladnik)
                {
                    return temp.wspolczynnik;
                }
            }
            return 0;
        }

        private void DodajDoWspolczynnika(int wykladnik, int doDodania)
        {
            for (Node temp = head; temp != null; temp = temp.next)
            {
                if (temp.wykladnik == wykladnik)
                {
                    temp.wspolczynnik += doDodania;
                    if (temp.wspolczynnik == 0) // to trzeba dziada usunac
                    {
                        this.Delete(wykladnik);
                    }
                }
            }
        }

        private void DodajNowyWykladnik(int wykladnik, int wspolczynnik)
        {

            for (Node temp = head; temp != null; temp = temp.next)
            {
                // dodaje na koncu
                if (temp.next == null && temp.wykladnik > wykladnik)
                {
                    this.AddEnd(wspolczynnik, wykladnik);
                    return;
                }
                // dodaje na poczatku
                if (temp == head && temp.wykladnik < wykladnik)
                {
                    this.AddFront(wspolczynnik, wykladnik);
                    return;
                }
                // dodaje pomiedzy
                if (temp.wykladnik > wykladnik && temp.next.wykladnik < wykladnik)
                {
                    Node node = new Node(wspolczynnik, wykladnik);
                    node.next = temp.next;
                    temp.next = node;
                }
            }
        }

        // usuwa podany wykladnik
        private void Delete(int wykladnik)
        {
            // usuwanie glowy
            if (this.head.wykladnik == wykladnik)
            {
                head = head.next;
                return;
            }
            Node prev = null;
            for (Node temp = head; temp != null; temp = temp.next)
            {
                // usuwanie ogona
                if (temp.next == null && temp.wykladnik == wykladnik)
                {
                    prev.next = null;
                    return;
                }

                // usuwanie wezla pomiedzy
                if (temp.next != null && temp.next.wykladnik == wykladnik)
                {
                    temp.next = temp.next.next;
                    return;
                }
                if (prev == null) prev = head;
                else prev = prev.next;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 5, 0, 0, 8 };
            int[] arr2 = { 3, 0, 4, 6, 0, 0, 10 };
            int[] arr3 = { 4, 0, 5, 6, 3, 4 };
            ListaJednokierunkowa wielomian1 = ListaJednokierunkowa.CreateFromArray(arr1);
            ListaJednokierunkowa wielomian2 = ListaJednokierunkowa.CreateFromArray(arr2);
            ListaJednokierunkowa wielomian3 = ListaJednokierunkowa.CreateFromArray(arr3);
            wielomian1.Show();
            Console.WriteLine();
            wielomian2.Show();
            Console.WriteLine();

            wielomian1.Dodaj(wielomian2);
            wielomian1.Show();

            wielomian1.Odejmij(wielomian3);
            wielomian1.Show();

            Console.WriteLine();
            Console.Write("Przed rozniczka:");
            wielomian2.Show();
            Console.Write("Po rozniczkowaniu:");
            wielomian2.Rozniczkoj();
            wielomian2.Show();

            Console.ReadKey();
        }
    }
}
