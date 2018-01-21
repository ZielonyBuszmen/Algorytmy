# Zadania z poprzedniego roku - **kolos nr 2**

### Zadanie 1
- [Rozwiązanie by `Starszy Rocznik`](Kolos2_2017_zadanie1/Program.cs)

Położono na stosie kolejne liczby od 0 do n (w tej kolejności). W międzyczasie pomiędzy położeniami wykonano zdejmowanie, którego rezultaty wypisywano. Napisz metodę sprawdzającą, czy następujący ciąg mógł zostać wypisany? Przykładowo dla `n = 9` ciąg `1 3 2 0 4 5 7 6 8 9` tak; `1 0 4 6 3 8 7 9 5 2` nie.

### Zadanie 2
- [Rozwiązanie by `Starszy Rocznik`](Kolos2_2017_zadanie2/Program.cs)

Mamy kopiec minimalny taki, że na jego wierzchołku znajduje się element najmniejszy (dzieci są większe). Napisz metodę sprawdzającą, czy podana tablica jest kopcem minimalnym.

### Zadanie 3
- [Rozwiązanie by `Starszy Rocznik`](Kolos2_2017_zadanie3/Program.cs)

Mamy jednokierunkową listę dowiązaniową przechowujacą liczby naturalne.
```csharp
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
  }
```
Napisz metodę dublującą na liście wszystkie elementy o podanej wartości klucza, tzn. bezpośrednio za węzłem o podanej wartości klucza należy wstawić kolejny węzeł z tą wartością. Uwaga: należy napisać program testujący uwzględniający wszystkie przypadki (węzeł na początku, końcu, w środku). Przykładowe dane testowe `{1, 1, 1, 2, 3, 5, 3, 1, 1, 4, 3, 1, 1, 4, 3, 2, 1, 1, 1}`.

### Zadanie 4
- [Rozwiązanie by `Starszy Rocznik`](Kolos2_2017_zadanie4/Program.cs)

Napisz metodę do tworzenia drzewa BST o możliwie najmniejszej wysokości na podstawie uporządkowanego rosnąco ciągu kluczy w tablicy, np: `{2, 4, 7, 12, 15, 20, 25}`

### Zadanie 5
- *Do dokonczenia* [Rozwiązanie](Kolos2_2017_zadanie5/Program.cs)

W algorytmie BFS kolejność przechodzenia wierzchołków wyznacza pewne drzewo (jakieś). Napisz metodę, która jako argumenty pobiera listową reprezetnację drzewa i wierzchołków, a zwraca listę krawędzi: pary (wierzchołek początkowy, wierzchołek końcowy) drzewa.
Dla grafu jak na rysunki i wierzchołka 1 zwraca `{(1,2), (2,5), (2,3), (3,4), (4,6)}`
```
6
  \
    4 --- 5 
    |     | \
    |     |   1
    |     | /
    3 --- 2
```
