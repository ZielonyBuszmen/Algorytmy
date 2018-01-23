using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_2017_zadanie5
{
    // W algorytmie BFS kolejność przechodzenia wierzchołków wyznacza pewne drzewo (jakieś)
    // Napisz metodę, która jako argumenty pobiera listową reprezentację drzewa i wierzchołków
    // a zwraca listę krawędzie: pary(wierzchołek początkowy, wierzchołek końcowy) drzewa
    // Dla grafu jak na rysunku i wierzchołka 1 zwraca {(1,2), (2,5), (2,3), (3,4), (4,6)}
    /*    6
     *      \
     *        4 --- 5 
     *        |     | \
     *        |     |   1
     *        |     | /
     *        3 --- 2
     */
     
    class Graph
    {
        public Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        public void add(int a, List<int> list)
        {
            graph.Add(a, list);
        }
        public List<Connection> returnTree(int wezel)
        {
            Queue<int> a = new Queue<int>();
            List<Connection> d = new List<Connection>();
            bool[] connected = new bool[graph.Count];
            bool[] wasHere = new bool[graph.Count];
            a.Enqueue(wezel);
            while (a.Count != 0)
            {
                int num = a.Dequeue();
                if (wasHere[num - 1])
                    continue;
                wasHere[num - 1] = true;
                foreach (var item in graph[num])
                {
                    if (!connected[item - 1])
                    {
                        d.Add(new Connection(num, item));
                        connected[item - 1] = true;
                    }
                    a.Enqueue(item);

                }
                connected[num - 1] = true;
            }
            return d;
        }
    }
    class Connection
    {
        public int a;
        public int b;
        public Connection(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
    class Program
    {
        //wydaje się że podany zły przykład, bo przykład pokazuje DFS, nie BFS
        //wiec zrobiony prze ze mnie jest poprawny BFS
        static void Main(string[] args)
        {

            Graph g = new Graph();
            g.add(1, new List<int> { 2, 5 });
            g.add(2, new List<int> { 1, 3, 5 });
            g.add(3, new List<int> { 2, 4 });
            g.add(4, new List<int> { 3, 5, 6 });
            g.add(5, new List<int> { 1, 2, 4 });
            g.add(6, new List<int> { 4 });
            List<Connection> d = g.returnTree(1);
            foreach (var item in d)
            {
                Console.WriteLine(item.a + " " + item.b);
            }
            Console.ReadKey();
        }
    }

}
