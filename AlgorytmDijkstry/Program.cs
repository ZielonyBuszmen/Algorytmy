using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmDijkstry
{
    // Algorytm Dijkstry (lab 13 zad 4)

    // Implementacja Karwosia

    class Krawędź
    {
        public int koniec;
        public int waga;
        public Krawędź(int koniec, int waga)
        {
            this.koniec = koniec;
            this.waga = waga;
        }
    }

    class Graf
    {
        // Modyfikujemy metodę z zadania 1
        public static List<List<Krawędź>> MacierzNaListe(int[,] tab)
        {
            List<List<Krawędź>> lista = new List<List<Krawędź>>();
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                lista.Add(new List<Krawędź>());
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] != 0)
                        lista[i].Add(new Krawędź(j, tab[i, j]));
                }
            }
            return lista;
        }

        public static int[] Dijkstra(List<List<Krawędź>> lista)
        {
            //Inicjacja
            //L := {s}; R := V-{s};
            //w[s] := 0;
            int[] w = new int[lista.Count];
            bool[] b = new bool[lista.Count];// domyslnie false czyli nalezy do R       
            int s = 0;
            b[s] = true;// tylko s w zbiorze L
            w[s] = 0;

            //dla każdego v R wykonaj
            //jeżeli (v,s) E to
            //w[v] := w((v, s))
            //w przeciwnym przypadku
            //w[v] := ∞;
            for (int i = 0; i < w.Length; i++)
                if (!b[i])  // nie należy do L
                    w[i] = int.MaxValue;// nieskończoność
                                        // modyfikujemy sasiadów s
            for (int i = 0; i < lista[s].Count; i++)
                if (!b[lista[s][i].koniec])  // nie należy do L
                    w[lista[s][i].koniec] = lista[s][i].waga;

            //właściwe obliczenia
            //dla i := 1 aż do n-1 wykonaj
            for (int i = 1; i < lista.Count; i++)
            {//początek bloku 
             // szukamy wierzcholka w R o najmniejszym w
                int u = -1; // pierwszy wierzcholek jeszcze nie jet wybrany
                            //szukamy minimum sposrod tych z R
                for (int j = 0; j < lista.Count; j++)
                    if (!b[j] && ((u == -1) || (w[j] < w[u]))) u = j;
                //teraz
                //u := wierzchołek z R o minimalnej wadze w[u];          
                b[u] = true; // znaleziony wierzcholek przenosimy do L
                             // czyli
                             //R := R - {u};
                             //L := L + {u};           

                // Modyfikujemy odpowiednio wszystkich sąsiadów u z R
                //dla każdego v N(u) ∩ R wykonaj         
                for (int j = 0; j < lista[u].Count; j++)
                {
                    int v = lista[u][j].koniec;
                    if (!b[v] && (w[v] > w[u] + lista[u][j].waga))//jeżeli w[u] + w((u, v)) < w[v] to
                    {
                        w[v] = w[u] + lista[u][j].waga;            //w[v] := w[u] + w((u, v));
                    }
                }
            }//koniec bloku

            return w;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Algorytm Dijkstry");

            //macierz sąsiedztwa
            int[,] tabA =  { { 0 ,1, 1, 0, 0 },
                         { 1, 0, 1, 1, 0 },
                         { 1, 1, 0, 0, 1 },
                         { 0, 1, 0, 0, 1 },
                         { 0, 0, 1, 1, 0 } };

            int[,] tabB = {  {1, 0, 0, 3, 0, 0, 7},
                         {0, 0, 2, 0, 4, 0, 1},
                         {0, 2, 0, 4, 1, 2, 3},
                         {3, 0, 4, 0, 5, 3, 3},
                         {0, 4, 1, 5, 0, 1, 2},
                         {0, 0, 2, 3, 1, 0, 2},
                         {7, 1, 3, 3, 2, 2, 0} };

            List<List<Krawędź>> lista = Graf.MacierzNaListe(tabA);
            int[] wagi = Graf.Dijkstra(lista);

            for (int i = 0; i < wagi.Length; i++)
                Console.WriteLine(i + " : " + wagi[i]);

            Console.WriteLine();

            lista = Graf.MacierzNaListe(tabB);
            wagi = Graf.Dijkstra(lista);

            for (int i = 0; i < wagi.Length; i++)
                Console.WriteLine(i + " : " + wagi[i]);


            Console.ReadKey();
        }
    }
}
