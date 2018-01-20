using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    // GRAF NIESKIEROWANY
    /*
     * Metody w klasie Graf:
     * - static MacierzWListe(int[,] matrix) - przekształca macierz do listy sąsiedztwa
     * - static ListaWMacierz(List<List<int>> list) - przekształca listę sąsiedztwa w macierz
     * - DFS() - Depth First Search - przechodzi w głąb grafu
     * - BFS() - Breadth First Search - przechodzienie wszerz grafu
     * 
     * W klasie Program znajdują się metody pomocnicze, wyświetlające grafy:
     * - ShowMatrix(int[,] matrix) - wyświetla macierz w postaci tablicy dwu-wymiarowej
     * - ShowListOfMatrix(List<List<int>> list) - wyświetla macierz w postaci list sąsiedztwa
     */

    class Graf
    {
        // Dla prostego grafu nieskierowanego bez wag krawędzi, napisz metodę konwertująca reprezentację 
        // w postaci macierzy sąsiedztw na reprezentację w postaci list sąsiedztwa. 
        public static List<List<int>> MacierzWListe(int[,] matrix)
        {
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                list.Add(new List<int>());
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        list[i].Add(j);
                    }
                }
            }
            return list;
        }

        // Dla prostego grafu nieskierowanego bez wag krawędzi, napisz metodę konwertująca reprezentację 
        // w postaci list sąsiedztwa na reprezentację w postaci macierzy sąsiedztw. 
        public static int[,] ListaWMacierz(List<List<int>> list)
        {
            int[,] result = new int[list.Count, list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    result[i, list[i][j]] = 1;
                }
            }
            return result;
        }

        // DFS - Depth First Search - przechodzi w głąb grafu
        public static List<int> DFS(int[,] matrix)
        {
            int start = 0;
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();
            stack.Push(start); // dodanie pierwszego wierchołka
            bool[] visited = new bool[matrix.GetLength(0)]; // tutaj przechowujemy info, czy wierzchołek był odwiedzony
            while (stack.Count != 0)
            {
                int actual = stack.Pop();
                if (visited[actual] == false)
                {
                    visited[actual] = true;
                    result.Add(actual);
                    for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (matrix[actual, i] != 0)
                        {
                            stack.Push(i);
                        }
                    }
                }
            }
            return result;
        }

        // DFS (Depth First Search)- przechodzi w głąb grafu - wersja na listach sąsiedztwa
        public static List<int> DFS(List<List<int>> list)
        {
            int start = 0;
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();
            stack.Push(start); // dodanie pierwszego wierzchołka
            bool[] visited = new bool[list.Count];
            while (stack.Count != 0)
            {
                int actual = stack.Pop();
                if (visited[actual] == false)
                {
                    visited[actual] = true;
                    result.Add(actual);

                    int graphSize = list[actual].Count;
                    for (int i = graphSize - 1; i >= 0; i--)
                    {
                        stack.Push(list[actual][i]); // od końca
                    }
                }
            }
            return result;
        }

        // BFS - Breadth Firs tSearch - przechodzienie wszerz grafu
        public static List<int> BFS(int[,] matrix)
        {
            int start = 0;
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();
            queue.Enqueue(start); // dodanie pierwszego wierchołka
            bool[] visited = new bool[matrix.GetLength(0)]; // tutaj przechowujemy info, czy wierzchołek był odwiedzony
            while (queue.Count != 0)
            {
                int actualNode = queue.Dequeue();
                if (visited[actualNode] == false)
                {
                    visited[actualNode] = true;
                    result.Add(actualNode);
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (matrix[actualNode, i] != 0)
                        {
                            queue.Enqueue(i);
                        }
                    }
                }
            }
            return result;
        }

    }

    class Program
    {
        // wyświetla macierz
        public static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // wyświetla listę sąsiedztwa
        public static void ShowListOfMatrix(List<List<int>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Graf nieskierowany");

            //macierz sąsiedztwa
            int[,] matrix ={
                {0, 1, 0, 0, 1, 0},
                {1, 0, 1, 0, 1, 0},
                {0, 1, 0, 1, 0, 0},
                {0, 0, 1, 0, 1, 1},
                {1, 1, 0, 1, 0, 0},
                {0, 0, 0, 1, 0 ,0},
            };

            // macierz w postaci list sąsiedztwa - numeracja od 0 
            List<List<int>> listOfMatrix = new List<List<int>>();
            List<int> l1 = new List<int>();
            l1.Add(1); l1.Add(4);
            listOfMatrix.Add(l1);
            List<int> l2 = new List<int>();
            l2.Add(0); l2.Add(2); l2.Add(4);
            listOfMatrix.Add(l2);
            List<int> l3 = new List<int>();
            l3.Add(1); l3.Add(3);
            listOfMatrix.Add(l3);
            List<int> l4 = new List<int>();
            l4.Add(2); l4.Add(4); l4.Add(5);
            listOfMatrix.Add(l4);
            List<int> l5 = new List<int>();
            l5.Add(0); l5.Add(1); l5.Add(3);
            listOfMatrix.Add(l5);
            List<int> l6 = new List<int>();
            l6.Add(3); listOfMatrix.Add(l6);

            Console.WriteLine("Lista sąsiedztwa bezpośrednio");
            ShowListOfMatrix(listOfMatrix);

            List<List<int>> GG = Graf.MacierzWListe(matrix);
            Console.WriteLine("Lista sąsiedztwa z macierzy (konwertowanie Macierz => Lista sasiedztwa)");
            ShowListOfMatrix(GG);

            int[,] tab2 = Graf.ListaWMacierz(listOfMatrix);
            Console.WriteLine("Macierz z listy sąsiedztwa (konwertowanie Lista => Macierz)");
            ShowMatrix(tab2);


            Console.WriteLine("------------------------------------");
            int[,] tabA =  {
                { 0 ,1, 1, 0, 0 },
                { 1, 0, 1, 1, 0 },
                { 1, 1, 0, 0, 1 },
                { 0, 1, 0, 0, 1 },
                { 0, 0, 1, 1, 0 },
            };

            //macierz sąsiedztwa
            int[,] tabB = {
                {1, 0, 0, 3, 0, 0, 7},
                {0, 0, 2, 0, 4, 0, 1},
                {0, 2, 0, 4, 1, 2, 3},
                {3, 0, 4, 0, 5, 3, 3},
                {0, 4, 1, 5, 0, 1, 2},
                {0, 0, 2, 3, 1, 0, 2},
                {7, 1, 3, 3, 2, 2, 0},
            };
            List<int> wyniki = Graf.DFS(tabA);
            foreach (var item in wyniki)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            List<int> wyniki2 = Graf.BFS(tabA);
            foreach (var item in wyniki2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\nDFS na liście sąsiedztwa \n");
            List<List<int>> lista3 = Graf.MacierzWListe(tabA);
            List<int> wyniki3 = Graf.DFS(lista3);
            foreach (var item in wyniki3)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
        }
    }
}
