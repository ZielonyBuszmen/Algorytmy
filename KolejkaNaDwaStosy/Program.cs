using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkaNaDwaStosy
{
    /*
     * Lab 8 zad 4
     * 
     * Zaprojektować implementację kolejki wykorzystującej dwa stosy.
     * Napisać metody obsługiwania takiej kolejki (wykorzystując metody stosu). Jaka jest złożoność metod takiej kolejki?
     * */
    class KolejkaNaDwaStosy
    {
        // pomocniczy stos
        Stack stackQueue = new Stack(); // główny stos, gdzie wierzchołek stosu to koniec kolejki

        // Dodanie elementu (na koniec)
        public void Enqueue(int value)
        {
            // przeniesienie danych z glownego stosu na stos pomocniczy (by byly odwrotnie)
            Stack tempStack = new Stack();
            while (!this.stackQueue.Empty())
            {
                int tempValue = this.stackQueue.Peek();
                tempStack.Push(tempValue);
                this.stackQueue.Pop();
            }

            // dodanie elementu
            tempStack.Push(value);

            // przeniesienie danych ze stosu pomocniczego na stos glowny
            while (!tempStack.Empty())
            {
                int tempValue = tempStack.Peek();
                this.stackQueue.Push(tempValue);
                tempStack.Pop();
            }
        }

        // Zdjęcie elementu (z początku)
        public void Dequeue()
        {
            this.stackQueue.Pop();
        }

        public bool Empty()
        {
            return stackQueue.Empty();
        }

        // odczyt początku kolejki
        public int Peek()
        {
            return this.stackQueue.Peek();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka na dwa stosy");

            KolejkaNaDwaStosy q = new KolejkaNaDwaStosy();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            q.Enqueue(100);
            q.Enqueue(200);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.WriteLine(q.Peek());
            q.Dequeue();

            q.Enqueue(300);

            Console.WriteLine(q.Peek());
            q.Dequeue();

            Console.ReadKey();
        }
    }


    // /////////////////////////////////////////////////////////////////////////////////
    // /////////////////////////////////////////////////////////////////////////////////
    // /////////////////////////////////////////////////////////////////////////////////
    // /////////////////////////////////////////////////////////////////////////////////
    // /////////////////////////////////////////////////////////////////////////////////
    // /////////////////////////////////////////////////////////////////////////////////


    class Node
    {
        public int value;
        public Node next;

        public Node(int value)
        {
            this.value = value;
        }
    }

    class Stack
    {
        int counter = 0;
        Node top;

        public void Push(int value)
        {
            this.counter++;

            Node newNode = new Node(value);
            newNode.next = top;
            top = newNode;
        }

        public void Pop()
        {
            if (this.Empty()) { return; }
            this.counter--;
            top = top.next;
        }

        public int Peek()
        {
            return this.top.value;
        }

        public int Size()
        {
            return this.counter;
        }

        public bool Empty()
        {
            return this.counter == 0;
        }
    }
}
