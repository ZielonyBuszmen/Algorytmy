using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos2_2017_zadanie3
{
    // zadanie 3
    // Mamy jednokierunkową listę dowiązaniową
    // Napisz metodę dublującą na liście wszystkie elementy o podanej wartości klucza, tzn bezpośrednio 
    // za węzłem o podanej wartości klucza należy wstawić kolejny węzeł z tą wartością. 
    // Uwaga: należy napisać program testujący uwzględniający wszystkie przypadki(węzeł na początku, końcu, w środku)
    // Przykładowe dane testowe {1, 1, 1, 2, 3, 5,3,1, 1, 4,3,1,1,4,3,2,1,1,1} 
    class Lista
    {
        class Wezel
        {
            public int dane;
            public Wezel nastepny;
            public Wezel(int wart)
            {
                dane = wart;
            }
        }
        Wezel head;
        public void Dodaj(int liczba)
        {
            Wezel tmp = new Wezel(liczba);
            tmp.nastepny = head;
            head = tmp;
        }
        public void Wyswietl()
        {
            for (Wezel w = head; w != null; w = w.nastepny)
                Console.Write(w.dane + " ");
            Console.WriteLine();
        }
        public void ZdublujWartości(int wartosc)
        {
            for (Wezel w = head; w != null; w = w.nastepny)
                if (w.dane == wartosc)
                {
                    Wezel tmp = new Wezel(wartosc);
                    tmp.nastepny = w.nastepny;
                    w.nastepny = tmp;
                    w = w.nastepny;
                }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab2 = { 1, 1, 1, 2, 3, 5, 3, 1, 1, 4, 3, 1, 1, 4, 3, 2, 1, 1, 1 };
            Lista lista = new Lista();
            foreach (var item in tab2)
                lista.Dodaj(item);
            lista.Wyswietl();
            lista.ZdublujWartości(1);
            lista.Wyswietl();
            Console.WriteLine();

            lista.Wyswietl();
            lista.ZdublujWartości(3);
            lista.Wyswietl();
            Console.WriteLine();

            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }
    }

}
