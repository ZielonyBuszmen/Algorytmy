using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_2017_zadanie4
{

    // Napisz metodę do tworzenia drzewa BST o możliwie najmniejszej wysokości  
    // Na podstawie uporządkowanego rosnąco ciągu kluczy podanych w tablicy
    // np.: {2,4,7,12,15,20,25}
    class Wezel
    {
        public int wartosc;
        public Wezel prawy, lewy;
        public Wezel(int wart)
        {
            wartosc = wart;
        }
    }

    class DrzewoBST
    {
        public Wezel root;
        public void Dodaj(int wart)
        {
            if (root == null) { root = new Wezel(wart); return; }
            dodaj(root, wart);
        }
        private void dodaj(Wezel w, int wartosc)
        {
            if (w == null) return;
            if (w.wartosc > wartosc)
                if (w.lewy == null) { w.lewy = new Wezel(wartosc); return; }
                else dodaj(w.lewy, wartosc);
            else
            {
                if (w.prawy == null) { w.prawy = new Wezel(wartosc); return; }
                else dodaj(w.prawy, wartosc);
            }
        }
        public void DodajZTabllicyNajnizszeDrzewo(int[] tab, int pocz, int kon)
        {
            if (pocz == kon) { Dodaj(tab[pocz]); return; }
            if (pocz > kon) return;
            int srodek = (pocz + kon) / 2;
            Dodaj(tab[srodek]);
            DodajZTabllicyNajnizszeDrzewo(tab, pocz, srodek - 1);
            DodajZTabllicyNajnizszeDrzewo(tab, srodek + 1, kon);
        }
        public void WyswietlPreOrder(Wezel w)
        {
            if (w == null) return;
            Console.Write(w.wartosc + " ");
            WyswietlPreOrder(w.lewy);
            WyswietlPreOrder(w.prawy);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DrzewoBST d = new DrzewoBST();
            int[] tab = { 2, 4, 7, 12, 15, 20, 25 };
            d.DodajZTabllicyNajnizszeDrzewo(tab, 0, tab.Length - 1);
            d.WyswietlPreOrder(d.root);
            Console.WriteLine();

            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }

}
