using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbiorZWlasnymHashemZMetLancuchowa
{
    /* Zbiór na tablicy z własną metodą hashująca z metoda łańcuchową
     * 
     * Napisz implementację zbioru na tablicy z haszowaniem z metoda łańcuchową 
     *  (można wykorzystać listę z .NET) wykorzystując do haszowania metody 
     *  przedstawione na wykładzie (zaimplementuj je dla typu int oraz string).
     * 
     * METODA HASHUJĄCA => h(x) = (x mod p) mod m
     */

    class HashSet
    {
        List<int>[] elements;
        const int N = 100;
        int P = 191; // liczba pierwsza

        private int Hash(int m)
        {
            return (m % P) % N;
        }

        public HashSet()
        {
            this.elements = new List<int>[N];
            for (int i = 0; i < N; i++)
            {
                elements[i] = new List<int>();
            }
        }

        // Dodaje element do zbioru
        public bool Insert(int m)
        {
            if (this.elements[Hash(m)] == null)
            {
                List<int> lista = new List<int>();
                lista.Add(m);
                elements[Hash(m)] = lista;
                return true;
            }
            else
            {
                if (!this.elements[Hash(m)].Contains(m))
                {
                    elements[Hash(m)].Add(m);
                }
            }
            return false;
        }

        // Sprawdza, czy element jest w zbiorze
        public bool Contains(int m)
        {
            if (this.elements[Hash(m)] != null)
            {
                return this.elements[Hash(m)].Contains(m);
            }
            else
            {
                return false;
            }
        }

        // Usuwa element ze zbioru
        public bool Delete(int m)
        {
            if (this.elements[Hash(m)] != null)
            {
                this.elements[Hash(m)].Remove(m);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < N; i++)
            {
                for (int k = 0; k < this.elements[i].Count; k++)
                {
                    result += this.elements[i][k] + " ";
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet s1 = new HashSet();
            HashSet s2 = new HashSet();

            s1.Insert(2);
            s1.Insert(912);
            s1.Insert(622);
            s1.Insert(324);

            s2.Insert(2);
            s2.Insert(715);
            s2.Insert(622);
            s2.Insert(52);

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Console.WriteLine(s1.Contains(555));
            Console.WriteLine(s1.Contains(324));

            s1.Delete(324);

            Console.WriteLine(s1.Contains(324));

            Console.WriteLine(s1);

            Console.ReadKey();
        }
    }
}
