using System;
using System.Collections.Generic;
using System.Collections;


namespace ZbiorHashtable
{
    /*
     * Zaimplementuj Zbiór wykorzystując klasę Hashtable z .NET. (lab 12 zad 5)
     */
    class ZbiórNaHashtable
    {
        Hashtable hashtable = new Hashtable(1000);

        // Zwraca rozmiar naszej hashtable
        public int Count
        {
            get { return hashtable.Count; }
        }

        // Wartości przechowywane przez nasze hashtable
        public ICollection Values
        {
            get { return hashtable.Keys; }
        }

        // Dodaje nową wartość
        public bool Insert(int value)
        {
            if (!this.hashtable.ContainsKey(value))
            {
                this.hashtable.Add(value, value); // wartość taka sama jak klucz
                return true;
            }
            return false;
        }

        // Czy zbiór zawiera daną wartość?
        public bool Contains(int value)
        {
            return this.hashtable.ContainsKey(value);
        }

        // Usuwa element ze zbioru
        public bool Delete(int value)
        {
            if (this.hashtable.ContainsKey(value))
            {
                this.hashtable.Remove(value);
                return true;
            }
            return false;
        }

        // Union(s1, s2)  - s1 U s2 - (suma zbiorów)
        public static ZbiórNaHashtable Union(ZbiórNaHashtable s1, ZbiórNaHashtable s2)
        {
            ZbiórNaHashtable result = new ZbiórNaHashtable();
            foreach (int k in s1.Values)
            {
                result.Insert(k);
            }
            foreach (int k in s2.Values)
            {
                result.Insert(k);
            }
            return result;
        }

        // Intersection(s1, s2) - s1 ∩ s2 (iloczyn zbiorów, elementy wspólne)
        public static ZbiórNaHashtable Intersection(ZbiórNaHashtable s1, ZbiórNaHashtable s2)
        {
            ZbiórNaHashtable result = new ZbiórNaHashtable();
            foreach (int k in s1.Values)
            {
                if (s2.Contains(k))
                {
                    result.Insert(k);
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach (int k in this.Values)
            {
                result += (k + " ");
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zbiór wykorzystujący Hashtable z .NET");

            ZbiórNaHashtable s1 = new ZbiórNaHashtable();
            ZbiórNaHashtable s2 = new ZbiórNaHashtable();

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

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            s1.Delete(377);
            Console.WriteLine(s1);

            ZbiórNaHashtable s3 = ZbiórNaHashtable.Union(s1, s2);
            Console.WriteLine(s3);

            ZbiórNaHashtable s4 = ZbiórNaHashtable.Intersection(s1, s2);
            Console.WriteLine(s4);

            Console.ReadKey();
        }
    }
}
