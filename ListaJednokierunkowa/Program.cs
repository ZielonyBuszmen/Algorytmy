using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaJednokierunkowa
{
    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    class ListaJednokierunkowa
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
            head = head.next;
        }

        // usuwa ostatni węzeł
        public void DeleteLastNode()
        {
            if (head == null)
            {
                return;
            }
            for (Node temp = head; temp.next != null; temp = temp.next)
            {
                if (temp.next == rear)
                {
                    temp.next = null;
                    rear = temp;
                    return;
                }
            }
        }

        // usuwa pierwszy węzeł z wartością równą i
        public void DeleteFirstOccurenceOf(int value)
        {
            if (head.value == value)
            {
                this.DeleteFirstNode();
                return;
            }
            if (rear.value == value)
            {
                this.DeleteLastNode();
                return;
            }

            for (Node temp = head; temp.next != null; temp = temp.next)
            {
                // to moze nie zadzialac
                if (temp.next.value == value)
                {
                    temp.next = temp.next.next;
                    return;
                }
            }
        }

        // zamienia wszystkie wartości oldValue na newValue
        public void Change(int oldValue, int newValue)
        {
            for (Node temp = head; temp != null; temp = temp.next)
            {
                if (temp.value == oldValue)
                {
                    temp.value = newValue;
                }
            }
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
            ListaJednokierunkowa lista = new ListaJednokierunkowa();
            lista.AddFront(3);
            lista.AddFront(1);
            lista.AddFront(14);
            lista.AddFront(23);
            lista.AddFront(1);
            lista.AddFront(7);
            lista.ShowList();

            Console.WriteLine("Rozmiar: {0}", lista.GetSize());

            Console.ReadKey();
        }
    }
}
