# **Kolos nr 2** - zima 2017/2018

### Zadanie 1 - **grp A (7)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie1a/Program.cs)

Napisz metodę odwaracającą kolejność elementów na stosie. Przykładowo `[1, 2, 3, 4, 5]` zamieniać na `[5, 4, 3, 2, 1]`. Metoda ma wykorzystywać tylko kolejkę. Mona skorzystać z kolejki i stosu .NET. Zilustruj działanie napisanej metody.

### Zadanie 1 - **grp B (8)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie1b/Program.cs)

Napisz metodę odwracającą kolejność elementów na liście. Przykładowo `[1, 2, 3, 4, 5]` zamianiać na `[5, 4, 3, 2, 1]`. Metoda ma wykorzystywać tylko stos. Można skorzystać ze stosu i kolejki .NET. Zilustruj działanie napisanej metody


### Zadanie 2 - **grp A (7)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie2a/Program.cs)

Napisz klasę **`KolejkaPriorytetowaMax`** (priorytet ma element o **największej** wartości) mającą konstruktor o parametrze int (rozmiar tablicy) oraz następujący interfejs
```csharp
  public int Wielkość; // właściwość, aktualna liczba elementów w kolejce
  public void Wstaw(int wartość)
  public int Usun()
```
Kolejka wewnątrz powinna być oparta o **kopiec binarny maskymalny** zaimplementowany na tablicy o rozmiarze podanym w konstruktorze. Przy metodzie `Usun()` należy wzorować się na sortowaniu kopcowym. Zilustruj działanie metod napisanej klasy. Pseudokod naprawiania potrzebnego przy usuwaniu przedstawiono poniżej.
```csharp
Napraw(w) // w indeks korzenia naprawianego poddrzewa
  n = liczba elementów w całym kopcu
  lewy = 2 * w +1 // indeks lewego dziecka
  prawy = 2 * w +2 // indeks prawego dziecka
    if(lewy< n) // jeżeli są dzieci, chociażby tylko lewe
    największy = w
    if(kopiec[lewy]>kopiec[największy])
      największy = lewy     //Jeżeli lewe dziecko ma wartość większą
    if(prawy < n && kopiec[prawy] > kopiec[największy])
      największy = prawy // Jeżeli prawe dziecko ma wartość większą
    if(największy != w)
      // zamień korzeń z większym dzieckiem
      temp = kopiec[w]
      kopiec[w] = kopiec[największy]
      kopiec[największy] = tmp
      Napraw(największy) // rekurencja
```


### Zadanie 2 - **grp B (8)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie2b/Program.cs)

Napisz klasę **`KolejkaPriorytetowaMin`** (priorytet ma element o **najmniejszej** wartości) mającą konstruktor o parametrze int (rozmiar tablicy) oraz następujący interfejs
```csharp
  public int Wielkość; // właściwość, aktualna liczba elementów w kolejce
  public void Wstaw(int wartość)
  public int Usun()
```
Kolejka wewnątrz powinna być oparta o **kopiec binarny minimalny** zaimplementowany na tablicy o rozmiarze podanym w konstruktorze. Przy metodzie `Usun()` należy wzorować się na sortowaniu kopcowym. Zilustruj działanie metod napisanej klasy. Pseudokod naprawiania potrzebnego przy usuwaniu przedstawiono poniżej.
```csharp
Napraw(w) // w indeks korzenia naprawianego poddrzewa
  n = liczba elementów w całym kopcu
  lewy = 2 * w +1 // indeks lewego dziecka
  prawy = 2 * w +2 // indeks prawego dziecka
    if(lewy< n) // jeżeli są dzieci, chociażby tylko lewe
    najmniejszy = w
    if(kopiec[lewy]>kopiec[najmniejszy])
      najmniejszy = lewy     //Jeżeli lewe dziecko ma wartość mniejszą
    if(prawy < n && kopiec[prawy] > kopiec[najmniejszy])
      najmniejszy = prawy // Jeżeli prawe dziecko ma wartość mniejszą
    if(najmniejszy != w)
      // zamień korzeń z większym dzieckiem
      temp = kopiec[w]
      kopiec[w] = kopiec[najmniejszy]
      kopiec[najmniejszy] = tmp
      Napraw(najmniejszy) // rekurencja
```


### Zadanie 3 - **grp A (7)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie3a/Program.cs)

Drzewo BST odczytano w porządku **post-order** i otrzymano `1 3 2 5 7 6 4`. Czy możemy odtworzyć to drzewo? Napisz metodę odtwarzającą drzewo na podstawie odczytu post-order, jeżeli drzewa nie można odtworzyć (tzn. dane są sprzeczne np `2 3 7 1 5 6 4`) metoda ma zwracać drzewo puste. Zilustruj działanie napisanej metody. <br />
Wskazówka: Zastanów się, gdzie w odczytanym ciągu jest wierzchołek drzewa, gdzie jest lewe poddrzewo, a gdzie prawe?


### Zadanie 3 - **grp B (8)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie3b/Program.cs)

Drzewo BST odczytano w porządku **pre-order** i otrzymano `4 2 1 3 6 5 7`. Czy możemy odtworzyć to drzewo? Napisz metodę odtwarzającą drzewo na podstawie odczytu pre-order, jeżeli drzewa nie można odtworzyć (tzn. dane są sprzeczne np `4 2 3 7 1 5 6`) metoda ma zwracać drzewo puste. Zilustruj działanie napisanej metody. <br />
Wskazówka: Zastanów się, gdzie w odczytanym ciągu jest wierzchołek drzewa, gdzie jest lewe poddrzewo, a gdzie prawe?


### Zadanie 4 - **grp A (7)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie4a/Program.cs)

W algorytmie **BFS** kolejność przechodzenia wierzchołków wyznacza pewnie ścieżki od wierzchołka początkowego do innych wierzchołków (każdy obsługiwany wierzchołek, oprócz pierwszego, znalazł się **w kolejce**, jako sąsiad-następnik wcześniej obsłużonego wierzchołka). Napisz metodę, która jako argumenty pobiera listową reprezentację drzewa i wierzchołek początkowy, a zwraca listę ścieżek: elementy tej listy to listy (wierzchołek początkowy, ..., wierzchołek końcowy). Dla grafu jak na rysunku i wierzchołka 1 zwraca: `{(1,2), (1,2,3), (1,5,4), (1,5), (1,5,4,6)}`. Zilustruj działanie napisanej metody.
```
6
  \
    4 --- 5 
    |     | \
    |     |   1
    |     | /
    3 --- 2
```


### Zadanie 4 - **grp B (8)**
- *Do dokończenia* [Rozwiązanie](Kolos2_2018_zadanie4b/Program.cs)

W algorytmie **DFS** kolejność przechodzenia wierzchołków wyznacza pewnie ścieżki od wierzchołka początkowego do innych wierzchołków (każdy obsługiwany wierzchołek, oprócz pierwszego, znalazł się **na stosie**, jako sąsiad-następnik wcześniej obsłużonego wierzchołka). Napisz metodę, która jako argumenty pobiera listową reprezentację drzewa i wierzchołek początkowy, a zwraca listę ścieżek: elementy tej listy to listy (wierzchołek początkowy, ..., wierzchołek końcowy). Dla grafu jak na rysunku i wierzchołka 1 zwraca: `{(1,2), (1,2,3), (1,2,3,4), (1,2,3,4,5), (1,2,3,4,6)}`. **Uwaga!** Taki mamy wnik gdy w DFS kładziemy na stos elementy od największego indeksu. Zilustruj działanie napisanej metody.
```
6
  \
    4 --- 5 
    |     | \
    |     |   1
    |     | /
    3 --- 2
```