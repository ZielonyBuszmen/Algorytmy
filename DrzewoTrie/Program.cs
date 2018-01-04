using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrzewoTrie
{

    //Zadanie 3 Lab 9
    // a) Napisz metodę tworzącą drzewo trie (opisane na wykładzie) 
    //    na podstawie listy słów (wzorców)
    // b) Napisz metodę sprawdzającą czy w podanym tekście występują
    //    słowa z listy wzorców (bazującą na algorytmie naiwnym), 
    //    wykorzystując powstałe drzewo. Szkic metody omówionej na 
    //    wykładzie wygląda następująco (przechodzimy przez drzewo 
    //    podobnie jak w porządku pre-order wybierając w węźle tylko
    //    interesującą krawędź, a jeśli takiej krawędzi nie ma to 
    //    znaczy, że wzorca nie znaleziono):
    //    znak = pierwszy znak tekstu
    //    v = korzeń drzewa

    // dopóki prawda 
    // jeśli v jest liściem 
    //   zwróć znaleziony wzorzec (indeks początku wzorca w tekście)
    // w przeciwnym przypadku 
    //   jeśli istnieje krawędź wychodząca z v zawierająca znak, 
    //     przejdź do węzła wyznaczonego przez tę krawędź v=węzeł , znak = następny znak tekstu  
    //   w przeciwnym przypadku 
    //     zwróć informację, że nie znaleziono żadnego wzorca.

    class Node
    {
        public char value;
        public List<Node> children;

        public Node(char value)
        {
            this.value = value;
            this.children = new List<Node>();
        }
    }

    class DrzewoTrie
    {
        public Node root;
        public DrzewoTrie(Node root)
        {
            this.root = root;
        }

        // dodaje słowo do drzewa
        public void AddWord(string word)
        {
            Node temp = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                bool ok = false;
                for (int j = 0; j < temp.children.Count; j++)
                {
                    if (temp.children[j].value == word[i])
                    {
                        temp = temp.children[j];
                        ok = true;
                        break;
                    }
                }
                if (!ok) // nie było takiego znaku dodajemy
                {
                    Node newNode = new Node(word[i]);
                    temp.children.Add(newNode);
                    temp = newNode;
                }
            }
        }

        // wyszukuje słowo w drzewie
        public bool Search(string word)
        {
            Node temp = this.root;
            for (int i = 0; i < word.Length; i++)
            {
                bool isFinded = false;
                for (int j = 0; j < temp.children.Count; j++)
                {
                    if (temp.children[j].value == word[i])
                    {
                        temp = temp.children[j];
                        isFinded = true;
                        break;
                    }
                }
                if (!isFinded) return false;
            }
            return true;
        }
    }

    // UWAGA
    // złożonośc czasowa wyszukiwania nie zależy od wielkości słownika
    // zasadniczo jest ograniczona przez długość wyrazu oraz
    // długośc listy (a więc alfabetu)
    //
    // niestety złożoność pamięciowa drzewa może byc duża

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drzewo Trie\n");

            Node root = new Node(' ');
            DrzewoTrie drzewo = new DrzewoTrie(root);
            drzewo.AddWord("tata");
            drzewo.AddWord("tam");
            drzewo.AddWord("kot");
            drzewo.AddWord("a");
            drzewo.AddWord("to");

            string word = "";

            word = "tata";
            Console.WriteLine("{0} => {1}", word, drzewo.Search(word));

            word = "ta";
            Console.WriteLine("{0} => {1}", word, drzewo.Search(word));

            word = "taca";
            Console.WriteLine("{0} => {1}", word, drzewo.Search(word));

            word = "a";
            Console.WriteLine("{0} => {1}", word, drzewo.Search(word));

            Console.ReadKey();
        }
    }
}
