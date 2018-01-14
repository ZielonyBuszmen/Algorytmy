using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_przyklad_zad1B
{
    class Wielomian
    {
        // <int, int> => <wykladnik, wspolczynnik>
        SortedList<int, int> lista = new SortedList<int, int>();

        // tworzenie wielomianu z tablicy
        public Wielomian(int[] array = null)
        {
            if (array == null) return;
            for (int wykladnik = 0; wykladnik < array.Length; wykladnik++)
            {
                int wspolczynnik = array[wykladnik];
                if (wspolczynnik != 0)
                {
                    // dodawanie na początek listy
                    this.lista.Add(wykladnik, wspolczynnik);
                }
            }
        }

        // Wywietla wielomian w formacie (wspolczynnik; wykladnik) -> (.., ..) -> ...
        public void Show()
        {
            int counter = this.lista.Count;
            string result = "";
            foreach (KeyValuePair<int, int> item in this.lista)
            {
                result = "(" + item.Value + ";" + item.Key + ")" + result;
                counter--;
                if (counter != 0) result = "->" + result;
            }
            Console.WriteLine(result);
        }

        // Dodaje do siebie wielomiany
        public void Dodaj(Wielomian w2)
        {
            foreach (KeyValuePair<int, int> item in w2.lista)
            {
                int wspolczynnik = item.Value;
                int wykladnik = item.Key;
                if (this.lista.ContainsKey(wykladnik)) // dodajemy
                {
                    this.lista[wykladnik] += item.Value;
                    if (this.lista[wykladnik] == 0) // usuwamy element
                    {
                        this.lista.Remove(wykladnik);
                    }
                }
                else
                {
                    this.lista[wykladnik] = item.Value;
                }
            }
        }

        // Odejmuje wielomian this.lista - w2.lista
        public void Odejmij(Wielomian w2)
        {
            foreach (KeyValuePair<int, int> item in w2.lista)
            {
                int wspolczynnik = item.Value;
                int wykladnik = item.Key;
                if (this.lista.ContainsKey(wykladnik)) // dodajemy
                {
                    this.lista[wykladnik] += item.Value * -1;
                    if (this.lista[wykladnik] == 0) // usuwamy element
                    {
                        this.lista.Remove(wykladnik);
                    }
                }
                else
                {
                    this.lista[wykladnik] = item.Value * -1;
                }
            }
        }

        // Różniczkuje wielomian
        public Wielomian Rozniczkoj()
        {
            Wielomian wynik = new Wielomian();
            foreach (KeyValuePair<int, int> item in this.lista)
            {
                int wspolczynnik = item.Key * item.Value;
                int wykladnik = item.Key - 1;
                if (wykladnik >= 0)
                {
                    wynik.lista[wykladnik] = wspolczynnik;
                }
            }
            return wynik;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 5, 0, 0, 8 };
            int[] arr2 = { 3, 0, 4, 6, 0, 0, 10 };
            int[] arr3 = { 4, 0, 5, 6, 3, 4 };
            Wielomian wielomian1 = new Wielomian(arr1);
            Wielomian wielomian2 = new Wielomian(arr2);
            Wielomian wielomian3 = new Wielomian(arr3);
            wielomian1.Show();
            Console.WriteLine();
            wielomian2.Show();
            Console.WriteLine();

            wielomian1.Dodaj(wielomian2);
            wielomian1.Show();

            wielomian1.Odejmij(wielomian3);
            wielomian1.Show();

            Console.WriteLine();
            Console.WriteLine("Przed rozniczka:");
            wielomian2.Show();
            Console.WriteLine("\nPo rozniczkowaniu:");
            Wielomian r = wielomian2.Rozniczkoj();
            wielomian2.Show();
            Console.ReadKey();
        }
    }
}
