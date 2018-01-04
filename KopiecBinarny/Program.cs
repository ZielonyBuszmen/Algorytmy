using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KopiecBinarny
{
    /**
     * TABLICOWA IMPLEMENTACJA KOPCA BINARNEGO  - LAB 10
     */
    /* Spis metod
     * - IsHeap - sprawdza, czy podana tablica jest kopcem
     * - GetHeight - zwraca wysokość kopca dla podanej tablicy
     * - MaxHeapElements - liczy największą liczbę elementów w kopcu o wysokości h
     * - MinHeapElements - liczy najmniejszą liczbę elementów w kopcu o wysokości h
     * - CountLeafNodes - liczy, ile jest liści w kopcu o liczbie węzłów n
     * - CountInnerNodes - liczy, ile jest węzłów wewnętrznych w kopcu o liczbie węzłów n
     * 
     * - ShowHeap - wyświetla kopiec
     * - Heapify - naprawia kopiec, czyli. przywraca mu własności kopca (tzn rodzic ma zawsze mniejszych potomków)
     * - Build - budowanie kopca z nieuporządkowanej tablicy elementów (używa funkcji Heapify())
     */

    class KopiecBinarny
    {
        // sprawdzamy, czy podana tablica to kopiec
        public static bool IsHeap(int[] tab)
        {
            for (int i = 0; i < tab.Length / 2; i++)
            {
                // badamy czy NIE kopiec
                // czy lewe dziecko jest wieksze
                if (2 * i + 1 < tab.Length && tab[i] < tab[2 * i + 1]) return false;
                // czy prawe dziecko jest wieksze
                if (2 * i + 2 < tab.Length && tab[i] < tab[2 * i + 2]) return false;
            }
            return true;
        }

        // zwraca wysokość podanego kopca
        public static int GetHeight(int[] heap)
        {
            int height = 0;

            int i = 1;
            while (i < heap.Length)
            {
                height++;
                i = 2 * i + 1; // pierwszy wierzchołek następnego poziomu
            }
            return height;
        }

        // możemy zauważyć, że wysokośc kopca to część całkowita logarytmu przy podstawie 2 z liczby węzłów
        public static int GetHeight2(int[] tab)
        {
            return (int)Math.Floor(Math.Log(tab.Length, 2));
        }

        // Największa liczba węzłów w kopcu o wysokości height
        public static int MaxHeapElements(int height)
        {
            int result = 0;
            int value = 1;
            // pełne h poziomów
            for (int i = 0; i <= height; i++)
            {
                result += value;
                value = value * 2;
            }
            return result;
        }
        // podejście matematyczne
        public static int MaxHeapElements2(int height)
        {
            return (int)Math.Pow(2, height + 1) - 1;
        }

        // Najmniejsza liczba węzłów w kopcu o wysokości height
        public static int MinHeapElements(int height)
        {
            int result = 0;
            int value = 1;
            // pełne h-1 poziomów
            for (int i = 0; i < height; i++)
            {
                result += value;
                value = value * 2;
            }
            return result + 1; // jeden na ostatnim poziomie
        }
        // podejście matematyczne
        public static int MinHeapElements2(int height)
        {
            return (int)Math.Pow(2, height);
        }

        // liczy, ile jest liści w kopcu o n wierchołkach
        public static int CountLeafNodes(int n)
        {
            return n - (n / 2);
        }

        // liczy, ile jest węzłów wenwętrznych w kopcu o n wierzchołkach
        public static int CountInnerNodes(int n)
        {
            return n / 2;
        }

        // wyświetla kopiec (tablicę)
        public static void ShowHeap(int[] heap)
        {
            for (int i = 0; i < heap.Length; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }

        // funkcja naprawiająca kopiec (inaczej downHeap)
        public static void Heapify(int[] heap, int node)
        {
            ShowHeap(heap); // Wyświetlamy stan kopca w każdym kolejnym kroku
            int length = heap.Length;
            int root = node; // korzeń drzewa
            int left = 2 * node + 1;
            int right = 2 * node + 2;

            // dopóki są dzieci
            if (left < length && heap[left] > heap[root])
            {
                root = left;
            }
            if (right < length && heap[right] > heap[root])
            {
                root = right;
            }

            // robimy zamianę
            if (root != node)
            {
                int temp = heap[node];
                heap[node] = heap[root];
                heap[root] = temp;
                Heapify(heap, root);
            }
        }

        // budowanie kopca z nieuporządkowanej tablicy elementów (używa funkcji Heapify())
        public static void Build(int[] heap)
        {
            int length = heap.Length;
            for (int i = (length / 2 - 1); i >= 0; i--)
            {
                Heapify(heap, i);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kopiec Binarny");
            int[] kopiec0 = { 23, 17, 14, 7, 13, 10, 1, 5, 6, 12 };
            int[] kopiec1 = { 23, 17, 14, 7, 13, 10, 1, 5, 6, 12, 0 };
            int[] kopiec2 = { 23, 17, 14, 7, 13, 10, 1 };
            int[] nieKopiec = { 27, 17, 3, 16, 13, 10, 1, 5, 7, 12, 4, 8, 9, 0 };

            Console.WriteLine("Czy array jest kopcem?");
            Console.WriteLine(KopiecBinarny.IsHeap(kopiec0));
            Console.WriteLine(KopiecBinarny.IsHeap(kopiec1));
            Console.WriteLine(KopiecBinarny.IsHeap(kopiec2));
            Console.WriteLine(KopiecBinarny.IsHeap(nieKopiec));
            Console.WriteLine();

            Console.WriteLine("Wysokość kopca");
            Console.WriteLine(KopiecBinarny.GetHeight(kopiec0));
            Console.WriteLine(KopiecBinarny.GetHeight(kopiec1));
            Console.WriteLine(KopiecBinarny.GetHeight(kopiec2));
            Console.WriteLine(KopiecBinarny.GetHeight2(kopiec0));
            Console.WriteLine(KopiecBinarny.GetHeight2(kopiec1));
            Console.WriteLine(KopiecBinarny.GetHeight2(kopiec2));
            Console.WriteLine();

            Console.WriteLine("Max i min liczba elementów w kopcu");
            Console.WriteLine(KopiecBinarny.MaxHeapElements(3));
            Console.WriteLine(KopiecBinarny.MinHeapElements(3));
            Console.WriteLine(KopiecBinarny.MaxHeapElements2(3));
            Console.WriteLine(KopiecBinarny.MinHeapElements2(3));
            Console.WriteLine();

            Console.WriteLine("Liście i węzły wewnętrzne");
            Console.WriteLine(KopiecBinarny.CountInnerNodes(15));
            Console.WriteLine(KopiecBinarny.CountLeafNodes(15));
            Console.WriteLine(KopiecBinarny.CountInnerNodes(8));
            Console.WriteLine(KopiecBinarny.CountLeafNodes(8));
            Console.WriteLine();

            Console.WriteLine("Budowanie kopca");
            int[] t = { 5, 3, 17, 10, 84, 19, 6, 22, 9 };
            KopiecBinarny.Build(t);
            Console.WriteLine(KopiecBinarny.IsHeap(t));

            Console.ReadKey();
        }
    }
}
