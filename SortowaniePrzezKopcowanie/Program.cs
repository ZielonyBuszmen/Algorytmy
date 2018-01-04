using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortowaniePrzezKopcowanie
{
    // Sortowanie przez kopcowanie - Zadanie 4 Lab 10

    class Heap
    {
        // wyświetla kopiec
        public static void Show(int[] heap)
        {
            for (int i = 0; i < heap.Length; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }

        // funkcja naprawiająca kopiec (inaczej downHeap) !Nowy parametr 'lenght (wielkość)'
        public static void Heapify(int[] heap, int node, int length)
        {
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
                Heapify(heap, root, length);
            }
        }

        // budowanie kopca z nieuporządkowanej tablicy elementów (używa funkcji Heapify())
        public static void Build(int[] heap)
        {
            int length = heap.Length;
            for (int i = (length / 2 - 1); i >= 0; i--)
            {
                Heapify(heap, i, heap.Length);
            }
        }

        // Gwóźdź programu - sortowanie przez kopcowanie
        public static void HeapSort(int[] array)
        {
            // 1. Nalezy zbudować kopiec
            Build(array);
            Show(array);

            // 2. Dopiero zaczynamy sortowanie
            int lenght = array.Length; // wielkość
            while (lenght > 1)
            {
                // zamieniamy największy element z ostatnim
                int max = array[0];
                array[0] = array[lenght - 1];
                array[lenght - 1] = max;
                // naprawiamy zmniejszony kopiec
                lenght = lenght - 1;
                Heapify(array, 0, lenght);
                Show(array);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sortowanie przez kopcowanie \n");

            int[] array = { 5, 13, 2, 25, 7, 17, 20, 8, 4 };
            Console.WriteLine("Nieposortowany");
            Heap.Show(array);
            Console.WriteLine();

            Heap.HeapSort(array);
            Console.WriteLine("\nPosortowany");
            Heap.Show(array);

            Console.ReadKey();
        }
    }
}
