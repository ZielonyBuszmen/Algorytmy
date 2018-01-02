using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stos_SprawdzeniePoprawnosciNawiasow
{
    /*
     * Wykorzystując stos napisz metodę sprawdzającą czy wyrażenie ma prawidłowo wpisane nawiasy. (Lab 8 zad 5)
     * Przykład:
     *   "a=)x]i[+5(*y;" -  błąd
     *   "a=(x[i]+5)*y;" -  OK
     *   "a=(x[i)+5]*y;" -  błąd
     *   "a=(x(i]+5]*y;" -  błąd
     */
    class Program
    {
        public static bool CheckBrackets(string expression)
        {
            char[] openBrackets = new char[] { '(', '[', '{' };
            char[] closeBrackets = new char[] { ')', ']', '}' };
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char character = expression[i];
                if (openBrackets.Contains(character)) // czy dany znak to znak z tablicy openBrackets
                {
                    // jeśli tak, to na stos wrzucamy odpowiadający mu znak z closeBrackets
                    int index = Array.IndexOf(openBrackets, character);
                    char closeBrack = closeBrackets[index];
                    stack.Push(closeBrack);
                    continue;
                }

                if (closeBrackets.Contains(character)) // czy dany znak to znak z tablicy closeBrackets
                {
                    if (stack.Count == 0) return false; // jesli stos pusty, to koniec

                    char bracketFromStack = stack.Pop();
                    if (character != bracketFromStack)
                    {
                        return false; // koniec, niepoprawne wyrazenie
                    }
                }

            }

            // na koniec trzeba sprawdzic, ze stos jest pusty (tzn. że zamknięto wszystkie otwarte nawiasy)
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            bool wynik;
            string wyrazenie;

            Console.WriteLine("Sprawdzanie poprawności nawiastów w wyrażeniu");
            Console.WriteLine();

            wyrazenie = "a=)x]i[+5(*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x[i]+5)*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x[i)+5]*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            wyrazenie = "a=(x(i]+5]*y;";
            wynik = CheckBrackets(wyrazenie);
            Console.WriteLine("{0}   ===>>> {1}", wyrazenie, wynik);

            Console.ReadKey();
        }
    }
}
