using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbiorHashowanieZAdresowaniemOtwartym
{
    /*  Zbiór na tablicy z haszowaniem z adresowaniem otwartym (lab 12 zad 4)
     * 
     * Napisz implementację zbioru na tablicy z haszowaniem z adresowaniem otwartym 
     * wykorzystując do haszowania metodę GetHashCode(). 
     * 
     */

    class ZbiórAdresowanieOtwarte
    {
        private int[] elements;
        const int N = 100;
        public ZbiórAdresowanieOtwarte()
        {
            this.elements = new int[N];
            for (int i = 0; i < N; i++)
            {
                elements[i] = -1;
            }
        }

        // wstawia element do zbioru
        public bool Insert(int m)
        {
            int counter = 0; // lcznik
            while (this.elements[(m.GetHashCode() + counter) % N] != -1)
            {
                counter++;
                if (counter == N)
                {
                    throw new ApplicationException("Nie ma juz miejsca");
                }
            }
            elements[(m.GetHashCode() + counter) % N] = m;
            return true;
        }

        // sprawdza, czy zbiór zawiera ten element
        public bool Contains(int m)
        {
            int k = 0;
            while (k < N)
            {
                if (this.elements[(m.GetHashCode() + k) % N] == m)
                {
                    return true;
                }
                k++;
            }
            return false;
        }

        // usuwa element ze zbioru
        public bool Delete(int m)
        {
            int k = 0;
            while (k < N)
            {
                if (this.elements[(m.GetHashCode() + k) % N] == m)
                {
                    this.elements[(m.GetHashCode() + k) % N] = -1;
                    return true;
                }
                k++;
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < N; i++)
            {
                if (elements[i] != -1)
                {
                    result += elements[i] + " ";
                }
            }
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zbiór na tablicy z haszowaniem z adresowaniem otwartym");

            ZbiórAdresowanieOtwarte s1 = new ZbiórAdresowanieOtwarte();
            ZbiórAdresowanieOtwarte s2 = new ZbiórAdresowanieOtwarte();

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

            s1.Delete(677);
            Console.WriteLine(s1);

            Console.ReadKey();
        }
    }
}
