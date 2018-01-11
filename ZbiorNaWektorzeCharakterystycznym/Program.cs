using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbiorNaWektorzeCharakterystycznym
{
    // Zbiór na tablicy na wektorze charakterystycznym (N = 1000)
    class Set
    {
        private bool[] elements;
        private const int N = 1000;

        public Set()
        {
            this.elements = new bool[N];
            for (int i = 0; i < N; i++)
            {
                this.elements[i] = false;
            }
        }

        // wstawia element
        public bool Insert(int value)
        {
            if (this.elements[value] == false)
            {
                this.elements[value] = true;
                return true;
            }
            return false;
        }

        // usuwa element
        public bool Delete(int value)
        {
            if (this.elements[value] == true)
            {
                this.elements[value] = false;
                return true;
            }
            return false;
        }

        // zwraca true, jeśli element znajduje się w zbiorze. Może nosić nazwę Find()
        public bool Member(int x)
        {
            if (x >= N) return false;
            return this.elements[x];
        }

        // zwraca rozmiar zbioru
        public int Size()
        {
            int size = 0;
            foreach (bool item in this.elements)
            {
                if (item) size++;
            }
            return size;
        }

        //zwraca true, jeśli zbiór jest pusty
        public bool Empty()
        {
            return this.Size() == 0;
        }

        // zwraca najmniejszy element
        public int Min()
        {
            for (int i = 0; i < N; i++)
            {
                if (this.elements[i]) return i;
            }
            return 0;
        }

        // usuwa najmniejszy element
        public void DeleteMin()
        {
            for (int i = 0; i < N; i++)
            {
                if (this.elements[i])
                {
                    this.elements[i] = false;
                    return;
                }
            }
        }

        // Buduje zbiór z podanych elementow, np: BuildSet(2,4,6,7,8,123,144)
        public void BuildSet(params int[] values)
        {
            foreach (int value in values)
            {
                this.elements[value] = true;
            }
        }

        // wyświetla elementy zbioru
        public void Show()
        {
            for (int i = 0; i < N; i++)
            {
                if (this.elements[i])
                {
                    Console.Write("{0}, ", i);
                }
            }
        }

        // Union(s1, s2)  - s1 U s2 - (suma zbiorów)
        public static Set Union(Set s1, Set s2)
        {
            Set set = new Set();
            for (int i = 0; i < N; i++)
            {
                if (s1.elements[i] || s2.elements[i])
                {
                    set.Insert(i);
                }
            }
            return set;
        }

        // Intersection(s1, s2) - s1 ∩ s2 (iloczyn zbiorów, elementy wspólne)
        public static Set Intersection(Set s1, Set s2)
        {
            Set set = new Set();

            for (int i = 0; i < N; i++)
            {
                if (s1.elements[i] == s2.elements[i] && s1.elements[i] == true)
                {
                    set.Insert(i);
                }
            }
            return set;
        }

        // Difference(s1, s2) - s1 \ s2 (różnica zbiorów)
        public static Set Difference(Set s1, Set s2)
        {
            Set set = new Set();
            //tworzymy kopie s1
            for (int i = 0; i < N; i++)
            {
                if (s1.elements[i])
                {
                    set.Insert(i);
                }
            }

            // usuwamy z wyniku elementy z s2
            for (int i = 0; i < N; i++)
            {
                if (s2.elements[i])
                {
                    set.elements[i] = false;
                }
            }
            return set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zbiór na wektorze charakterystycznym");
            Set set1 = new Set();
            Set set2 = new Set();
            set1.BuildSet(1, 3, 4, 5, 7, 8, 9, 10);
            set2.BuildSet(7, 8, 10, 15, 22, 24, 29, 33);

            Console.WriteLine("Najmniejszy element zbioru set2: {0}", set1.Min());
            Console.WriteLine();

            Console.WriteLine("Suma zbiorów set1 , set2");
            Set temp = Set.Union(set1, set2);
            temp.Show();
            Console.WriteLine();

            Console.WriteLine("Iloczyn zbiorów set1 i set2");
            temp = Set.Intersection(set1, set2);
            temp.Show();
            Console.WriteLine();

            Console.WriteLine("Różnica s1 \\ s2");
            temp = Set.Difference(set1, set2);
            temp.Show();
            Console.WriteLine();
            Console.WriteLine("Rozmiar różnicy: {0}", temp.Size());

            Console.ReadKey();
        }
    }
}
