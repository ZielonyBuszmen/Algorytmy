using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDwukierunkowa
{

    class Node
    {
        public int value;
        public Node next;
        public Node prev;

        public Node(int value)
        {
            this.value = value;
        }
    }

    class ListaDwukierunkowa
    {
        Node head;
        Node rear;

        // dodaje element na końcu (po wszystkich elementach)
        public void AddEnd(int value)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(value);
                return;
            }

            Node newNode = new Node(value);
            rear.next = newNode;
            newNode.prev = rear;
            rear = newNode;
        }

        // dodaje element na początku (przed wszystkimi innymi)
        public void AddFront(int value)
        {
            if (head == null || rear == null)
            {
                this.AddFirstElement(value);
                return;
            }

            Node newNode = new Node(value);
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }

        // funkcja prywatna, potrzebna tylko do uzytku wewnetrznego - dodaje pierwszy element (tzn. gdy lista była wcześniej pusta)
        private void AddFirstElement(int value)
        {
            Node newNode = new Node(value);
            this.head = newNode;
            this.rear = newNode;
        }

        // usuwa pierwszy węzeł
        public void DeleteFirstNode()
        {
            if (head == null)
            {
                return;
            }
            if(head.next == null)
            {
                head = null;
                rear = null;
                return;
            }

            head = head.next;
            head.prev = null;
        }

        // usuwa ostatni węzeł
        public void DeleteLastNode()
        {
            if (head == null)
            {
                return;
            }
            if (rear.prev == null)
            {
                head = null;
                rear = null;
                return;
            }

            rear = rear.prev;
            rear.next = null;
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

        // wyświetla wszystkie elementy listy
        public void ShowList()
        {
            Console.WriteLine();
            if (head == null)
            {
                Console.WriteLine("PUSTO");
            }

            for (Node temp = head; temp != null; temp = temp.next)
            {
                Console.Write("{0}, ", temp.value);
            }
            Console.WriteLine();
        }

        // wyświetla wszystkie elementy listy w odwrotny sposob
        public void ShowListReversed()
        {
            Console.WriteLine();
            if (head == null)
            {
                Console.WriteLine("PUSTO");
            }

            for (Node temp = rear; temp != null; temp = temp.prev)
            {
                Console.Write("{0}, ", temp.value);
            }
            Console.WriteLine();
        }

        // zwraca wartość w head
        public int? GetHeadValue()
        {
            if (head == null) return null;
            return head.value;
        }

        // zwraca wartość w rear
        public int? GetRearValue()
        {
            if (rear == null) return null;
            return rear.value;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista dwukierunkowa");

            ListaDwukierunkowa lista = new ListaDwukierunkowa();
            lista.AddFront(1);
            lista.AddEnd(2);
            lista.AddFront(3);
            lista.AddEnd(4);
            lista.AddFront(5);

            lista.ShowList();

            lista.DeleteLastNode();
            lista.DeleteFirstNode();
            lista.AddEnd(7);
            lista.AddFront(100);

            lista.ShowList();
            lista.ShowListReversed();

            Console.WriteLine();
            Console.WriteLine("Rozmiar: {0}", lista.GetSize());
            Console.ReadKey();
        }
    }
}
