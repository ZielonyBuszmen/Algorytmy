using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbiorHashowanieZMetLancuchowa
{
    // Zbiór na tablicy z hashowaniem z metoda łańcuchową

    //Napisz implementację zbioru na tablicy z haszowaniem z metoda łańcuchową 
    //(można wykorzystać liste z .NET) wykorzystując do haszowania metodę GetHashCode(). (Zad 2 Lab 12)
    class HashSet
    {
        List<int>[] elements;
        const int N = 100;

        // zwraca pojemność
        public int Capacity
        {
            get { return N; }
        }

        // konstruktor - konstrukcja liniowa O(n)
        public HashSet()
        {
            this.elements = new List<int>[N];
            for (int i = 0; i < N; i++)
            {
                this.elements[i] = new List<int>();
            }
        }
        // złożoność zależy od długości listy 
        // ale ponieważ gdy mamy K elementów w zbiorze
        // a nasza funkcja haszująca rozrzuca równomiernie
        // to średnia długość listy K/n a więc oczekiwana 
        // złożonośc jest stała Θ(1)
        // Dodaje element do zbioru
        public bool Insert(int m)
        {
            if (!this.elements[m.GetHashCode() % N].Contains(m))
            {
                elements[m.GetHashCode() % N].Add(m);
                return true;
            }
            return false;
        }

        // sprawdza, czy element jest w zbiorze - złożoność zależy od długości wewnęrznej listy
        public bool Contains(int m)
        {
            return elements[m.GetHashCode() % N].Contains(m);
        }

        // Usuwa element ze zbioru
        public bool Delete(int m)
        {
            if (elements[m.GetHashCode() % N].Contains(m))
            {
                elements[m.GetHashCode() % N].Remove(m);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < N; i++)
                for (int k = 0; k < elements[i].Count; k++)
                    s += elements[i][k] + " ";

            return s;
        }

        // Union(s1, s2)  - s1 U s2 - (suma zbiorów)
        public static HashSet Union(HashSet s1, HashSet s2)
        {
            HashSet set = new HashSet();
            for (int m = 0; m < N; m++)
            {
                if (s1.elements[m.GetHashCode() % N].Count > 0)
                {
                    foreach (int k in s1.elements[m.GetHashCode() % N])
                    {
                        set.elements[m.GetHashCode() % N].Add(k);
                    }
                }

                if (s2.elements[m.GetHashCode() % N].Count > 0)
                {
                    foreach (int k in s2.elements[m.GetHashCode() % N])
                    {
                        if (!set.elements[m.GetHashCode() % N].Contains(k))
                            set.elements[m.GetHashCode() % N].Add(k);
                    }
                }
            }
            return set;
        }

        // Intersection(s1, s2) - s1 ∩ s2 (iloczyn zbiorów, elementy wspólne)
        public static HashSet Intersection(HashSet s1, HashSet s2)
        {
            HashSet set = new HashSet();
            for (int m = 0; m < N; m++)
            {
                if (s1.elements[m.GetHashCode() % N].Count > 0 && s2.elements[m.GetHashCode() % N].Count > 0)
                {
                    foreach (int k in s1.elements[m.GetHashCode() % N])
                    {
                        if (s2.elements[m.GetHashCode() % N].Contains(k))
                            set.elements[m.GetHashCode() % N].Add(k);
                    }
                }
            }
            return set;
        }
    }

    class Program
    {
        static void ShowSet(HashSet s, string message = "")
        {
            if (message != "")
            {
                Console.WriteLine(message + " ");
            }
            Console.WriteLine(s);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Zbiór na tablicy z hashowaniem z metoda łańcuchową \n");

            HashSet s1 = new HashSet();
            HashSet s2 = new HashSet();

            s1.Insert(22);
            s1.Insert(522);
            s1.Insert(922);
            s1.Insert(677);
            s1.Insert(222);
            s1.Insert(377);

            s2.Insert(122);
            s2.Insert(522);
            s2.Insert(822);
            s2.Insert(677);

            ShowSet(s1, "Zbiór s1 =>  ");
            ShowSet(s2, "Zbiór s2 =>  ");

            s1.Delete(377);
            ShowSet(s1, "Zbiór s1 po usunieciu 377 =>  ");

            HashSet s3 = HashSet.Union(s1, s2);
            ShowSet(s3, "Po Union (sumie) zbioru s1 i s2 =>   ");

            HashSet s4 = HashSet.Intersection(s1, s2);
            ShowSet(s4, "Po operatcji Intersection (część wspólna) zbioru s1 i s2 =>   ");

            Console.ReadKey();
        }
    }
}
