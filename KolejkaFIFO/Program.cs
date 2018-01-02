using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkaFIFO
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

    class Kolejka
    {
        Node head;
        Node rear;

        // wstawianie X na koniec kolejki
        public void Enqueue(int x)
        {
            Node newNode = new Node(x);
            if (head == null)
            {
                head = newNode;
                rear = head;
                return;
            }
            rear.next = newNode;
            rear = newNode;
        }

        // usuniecie pierwszego elementu z kolejki 
        public void Dequeue()
        {
            if (this.Empty())
            {
                return;
            }

            if(head==rear)
            {
                head = null;
                rear = null;
                return;
            }

            head = head.next;
        }

        // zwraca true, jesli kolejka pusta
        public bool Empty()
        {
            if (head == null || rear == null)
            {
                return true;
            }
            return false;
        }

        // odczytuje wartość z wierzchołka kolejki
        public int Peek()
        {
            if (this.Empty())
            {
                return 0;
            }

            return head.value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka FIFO");

            Kolejka q = new Kolejka();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.ReadKey();
        }
    }
}
