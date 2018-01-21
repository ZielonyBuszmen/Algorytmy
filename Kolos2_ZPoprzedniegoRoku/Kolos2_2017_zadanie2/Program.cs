using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_2017_zadanie2
{
    // Mamy kopiec minimalny, taki, że na jego wierzchołku znajduje się element najmniejszy
    // (dzieci są większe). Napisz metodę sprawdzającą, czy podana tablica jest kopcem minimalnym
    class Program
    {
        static bool CzyKopiecMinimalny(int[] tab)
        {
            int n = tab.Length;
            for (int i = 0; i < (n / 2); i++)
                if (((2 * i + 1) < n && (2 * i + 2) < n))
                    if (tab[i] > tab[2 * i + 1] || tab[i] > tab[2 * i + 2]) return false;
            return true;

        }
        static void Main(string[] args)
        {
            int[] tab1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] tab2 = { 5, 6, 8, 7, 20, 12, 3 };
            Console.WriteLine(CzyKopiecMinimalny(tab1));
            Console.WriteLine(CzyKopiecMinimalny(tab2));

            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }
}
