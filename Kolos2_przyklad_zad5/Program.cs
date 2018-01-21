using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Rozwiązanie by odisei369
/// </summary>
namespace Kolos2_przyklad_zad5
{
    // zadanie 5

    // Napisz metodę, która dla spójnego grafu nieskierowanego, dla którego dane są liczbowe wagi krawędzi,
    // znajduje drzewo rozpinające o maksymalnej wartości.

    class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void add_vertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public Dictionary<char, Dictionary<char, int>> findMaxtree(char start)
        {
            Dictionary<char, Dictionary<char, int>> treeVertices = new Dictionary<char, Dictionary<char, int>>();
            var nodes = new List<char>();
            nodes.Add(start);
            while (nodes.Count != vertices.Count)
            {
                int maxValue = int.MinValue;
                char nextVertice = ' ';
                char pinToVertise = ' ';

                foreach (char includedNode in nodes)
                {
                    foreach (var neighbor in vertices[includedNode])
                    {
                        if (nodes.IndexOf(neighbor.Key) < 0 && neighbor.Value > maxValue)
                        {
                            maxValue = neighbor.Value;
                            nextVertice = neighbor.Key;
                            pinToVertise = includedNode;
                        }
                    }
                }
                if (maxValue == int.MinValue)
                {
                    break;
                }
                nodes.Add(nextVertice);
                if (!treeVertices.ContainsKey(pinToVertise))
                {
                    treeVertices.Add(pinToVertise, new Dictionary<char, int>());
                }
                treeVertices[pinToVertise].Add(nextVertice, maxValue);
                if (!treeVertices.ContainsKey(nextVertice))
                {
                    treeVertices.Add(nextVertice, new Dictionary<char, int>());
                }
                treeVertices[nextVertice].Add(pinToVertise, maxValue);
            }

            return treeVertices;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.add_vertex('A', new Dictionary<char, int>() { { 'B', 1 }, { 'C', 8 }, { 'E', 5 } });
            g.add_vertex('B', new Dictionary<char, int>() { { 'A', 1 }, { 'E', 1 } });
            g.add_vertex('C', new Dictionary<char, int>() { { 'A', 8 }, { 'D', 2 } });
            g.add_vertex('D', new Dictionary<char, int>() { { 'C', 2 }, { 'F', 1 }, { 'E', 2 } });
            g.add_vertex('E', new Dictionary<char, int>() { { 'A', 5 }, { 'B', 1 }, { 'D', 2 } });
            g.add_vertex('F', new Dictionary<char, int>() { { 'D', 1 } });

            Dictionary<char, Dictionary<char, int>> d = g.findMaxtree('A');
            foreach (var item in d)
            {
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item.Key + "-" + item2.Key + " " + item2.Value);
                }
            }

            Console.ReadKey();
        }
    }
}
