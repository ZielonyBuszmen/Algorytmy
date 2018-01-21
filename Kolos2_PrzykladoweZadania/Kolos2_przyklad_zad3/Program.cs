using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Kod autorstwa tmpaccc
/// </summary>
namespace Kolos2_przyklad_zad3
{
    // zadanie 3

    // Napisz metodę (iteracyjną), która za pomocą kolejki wypisuje zawartość drzewa kolejnymi poziomami.
    class Wezel
    {
        public int wartosc;
        public List<Wezel> nastepniki;
        public Wezel(int wart)
        {
            wartosc = wart;
        }
        public void DodajWezel(Wezel dodany)
        {
            if (this.nastepniki == null) this.nastepniki = new List<Wezel>();
            nastepniki.Add(dodany);
        }
    }
    class Drzewo
    {
        public Wezel root;
        public string Show()
        {
            string output = "";
            if (root == null) return "NIE MA NIC W DRZEWIE!";
            Queue<Wezel> kolejka = new Queue<Wezel>();
            Wezel w = root;
            kolejka.Enqueue(w);
            while (kolejka.Count != 0)
            {
                Queue<Wezel> kolejkaPomocnicza = new Queue<Wezel>();
                Wezel pomocniczy = kolejka.Dequeue();
                output += pomocniczy.wartosc + " ";
                if (pomocniczy.nastepniki != null)
                    foreach (var item in pomocniczy.nastepniki)
                        kolejka.Enqueue(item);
            }
            return output;
        }
    }

    class Program
    {
        /*
         * Moje drzewo
         *                  12
         *               /       \
         *             7          20
         *          /  |  \        |
         *         5   2   14     13  
         *                         |
         *                         1
         */
        static void Main(string[] args)
        {
            Drzewo d = new Drzewo();
            Wezel w1 = new Wezel(12);
            d.root = w1;
            Wezel w2 = new Wezel(7);
            Wezel w3 = new Wezel(20);
            Wezel w4 = new Wezel(5);
            Wezel w5 = new Wezel(2);
            Wezel w6 = new Wezel(13);
            Wezel w7 = new Wezel(1);
            Wezel w8 = new Wezel(14);
            w1.DodajWezel(w2);
            w1.DodajWezel(w3);
            w2.DodajWezel(w4);
            w2.DodajWezel(w5);
            w3.DodajWezel(w6);
            w6.DodajWezel(w7);
            w2.DodajWezel(w8);

            Console.WriteLine(d.Show());


            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }

}
