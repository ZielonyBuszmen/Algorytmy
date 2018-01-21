using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_2017_zadanie1
{
    // kładziono na stosie kolejne liczby od 0 do n(w tej kolejności); W mniędzyczasie, pomiędzy położeniami
    // wykonywano zdejmowanie, którego rezultaty wypisywano. Napisz metodę sprawdzającą, czy następujący
    // ciąg mógł zostać wypisany.1 3 2 0 4 5 7 6 8 9 - tak. 1 0 4 6 3 8 7 9 5 2 - nie
    class Program
    {
        static bool SprawdzCzyMoznaToOtrzymac(int[] tab)
        {
            int n = tab.Length;
            int[] kolejne = new int[n];
            for (int i = 0; i < n; i++) kolejne[i] = i;
            int p = 0;
            for (int j = 0; j < n; j++)
            {
                int badany = tab[j];
                if (badany > p) p = badany;
                for (int k = badany + 1; k < p; k++) if (kolejne[k] != -1) return false;
                kolejne[badany] = -1;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[] tabPrawda = { 1, 3, 2, 0, 4, 5, 7, 6, 8, 9 };
            int[] tabFalsz = { 1, 0, 4, 6, 3, 8, 7, 9, 5, 2 };
            int[] tabPrawda2 = { 5, 4, 6, 3, 7, 2, 1, 9, 8, 0 };
            Console.WriteLine(SprawdzCzyMoznaToOtrzymac(tabPrawda));
            Console.WriteLine(SprawdzCzyMoznaToOtrzymac(tabFalsz));
            Console.WriteLine(SprawdzCzyMoznaToOtrzymac(tabPrawda2));

            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }

}
