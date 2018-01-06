using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StosLIFO
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

    class Stos
    {
        int counter = 0;
        Node top; // wierzchołek stosu

        // wrzucenie wartości na stos
        public void Push(int value)
        {
            this.counter++;

            Node newNode = new Node(value);
            newNode.next = top;
            top = newNode;
        }

        // zdjęcie wartości ze stosu
        public void Pop()
        {
            if (this.Empty()) { return; }
            this.counter--;
            top = top.next;
        }

        // podejrzenie wierzchołka stosu
        public int Peek()
        {
            return this.top.value;
        }

        // zwrócenie rozmiaru stosu
        public int Size()
        {
            return this.counter;
        }

        // zwraca true, jeśli stos pusty
        public bool Empty()
        {
            return this.counter == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stos LIFO");

            Stos s = new Stos();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            Console.WriteLine(s.Peek());
            s.Pop();

            Console.WriteLine(s.Peek());
            s.Pop();

            Console.WriteLine(s.Peek());
            s.Pop();

            s.Push(123);

            Console.WriteLine(s.Peek());
            s.Pop();

            Console.WriteLine(s.Peek());
            s.Pop();

            Console.ReadKey();
        }
    }
}
