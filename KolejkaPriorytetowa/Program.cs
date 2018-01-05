using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejkaPriorytetowa
{
    /**
     * KOLEJKA PRIORYTETOWA - to struktura danych służąca do przechowywania
     *      zbioru S elementów, z których każdy ma przyporządkowaną wartość zwaną kluczem.
     *      Zbiór S jest podzbiorem zbioru liniowo uporządkowanego
     */
    /*
     * NOWE FUNKCJE
     *  - Insert - wstawia nowy element do kopca jako ostatni liść. Następnie naprawia ten kopiec
     *  - ExtractMax - usuwa element z kopca i go zwraca - tzn. zwraca największy, a na jego miejsce wstawia najmniejszy. Następnie wykonuje naprawę kopca
     *  - Maximum - zwraca (bez usuwania) największy element kopca
     *  
     *  INFO ODNOSNIE PLIKU:
     *  - są dwie klasy - Heap i KolejkaPriorytetowa
     *  - Heap wykonuje operacje na kopcu zapisanym w tablicy (wstawianie elementu, usuwanie elementu, budowa, wyświetlanie kopca)
     *  - KolejkaPriorytetowa - to tylko "obudowana" klasa Heap. Kolejka zawiera tablicę (kopiec) oraz licznik elementów
     **/

    class Heap
    {
        // wyświetla kopiec do elementu o indeksie lenght
        public static void Show(int[] heap, int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }

        // funkcja naprawiająca kopiec (inaczej downHeap)
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
        public static void Build(int[] heap, int length)
        {
            for (int i = (length / 2 - 1); i >= 0; i--)
            {
                Heapify(heap, i, length);
            }
        }

        // Wstawia element do kopca. int lenght - miejsce, gdzie wstawić. int element - element do wstawienia
        public static bool Insert(int[] heap, int lenght, int element)
        {
            if (lenght >= heap.Length) return false;
            heap[lenght] = element;

            // teraz naprawa (budowanie) kopca
            Build(heap, lenght + 1);
            //Heapify(heap, 0, lenght + 1);
            return true;
        }

        // Zwraca i usuwa największy element z kopca. Następnie wypełnia "lukę" najmniejszym elemenetem i naprawia kopiec
        public static int ExtractMax(int[] heap, int length)
        {
            int max = heap[0];
            int min = heap[length - 1];
            heap[length - 1] = 0; // usuwanie najmniejszego elementu
            length = length - 1;

            heap[0] = min; // wypełniamy lukę najmniejszym elementem

            Heapify(heap, 0, length);
            return max;
        }

        // zwraca (ale nie usuwa!) największy element kopca
        public static int Maximum(int[] heap)
        {
            return heap[0];
        }
    }

    // Klasa kolejki priorytetowej, która operuje na kopcu (klasa Heap)
    class KolejkaPriorytetowa
    {
        public int length = 0;
        public int[] heap = new int[100];

        // wstawia element do kolejki
        public void Insert(int element)
        {
            if (this.length >= 100)
            {
                Console.WriteLine("NIE MOZNA JUZ WIECEJ WSTAWIAC!!!");
                return;
            }
            Heap.Insert(this.heap, this.length, element);
            this.length++;
        }

        // zwraca najwiekszy element w kolejce i go usuwa
        public int ExtractMax()
        {
            if (this.length <= 0)
            {
                Console.WriteLine("NIE MA JUZ ELEMENTOW W KOLEJCE!!!");
                return 0;
            }

            int resut = Heap.ExtractMax(this.heap, this.length);
            this.length--;
            return resut;
        }

        // zwraca największe element w kolejce (bez jego usuwania)
        public int Maximum()
        {
            if (this.length <= 0)
            {
                Console.WriteLine("NIE MA ŻADNYCH ELEMENTOW W KOLEJCE!!!");
                return 0;
            }

            return Heap.Maximum(this.heap);
        }

        // wyświetla kolejkę
        public void Show()
        {
            Heap.Show(this.heap, this.length);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kolejka priorytetowa \n");

            KolejkaPriorytetowa kolejka = new KolejkaPriorytetowa();
            // wypełnaimy kolejkę 15 losowymi danymi z przedziału 1 - 50;
            Random rand = new Random();
            kolejka.Insert(1);
            kolejka.Insert(2);
            kolejka.Insert(4);
            kolejka.Insert(5);
            kolejka.Insert(6);
            kolejka.Insert(7);
            kolejka.Insert(8);
            kolejka.Insert(9);
            kolejka.Insert(10);

            Console.WriteLine();
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Dodaję 11 do kolejki");
            kolejka.Insert(11);

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.WriteLine("Dodaję 3 do kolejki");

            kolejka.Insert(3);

            Console.WriteLine("Element maksymalny: {0}", kolejka.ExtractMax());
            Console.WriteLine("Kolejka po zmianach: ");
            kolejka.Show();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
