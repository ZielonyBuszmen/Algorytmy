using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrzewoHuffmana
{
    // Drzewo Huffmana to rodzaj drzewa binarnego
    // TODO

    class Node
    {
        public char character; // znak
        public int occurences; // liczba wystąpień
        public Node left;
        public Node right;

    }

    class DrzewoHuffmana
    {
        // funckja, która liczy wystąpienia danych znaków
        public static void CalculateOccurences(string text)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo Huffmana \n");



            Console.ReadKey();
        }
    }
}
