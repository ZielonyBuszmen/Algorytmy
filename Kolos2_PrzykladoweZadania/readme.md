## [<< WSTECZ](../)

___

# Zadania przykładowe - **kolos nr 2**

### Zadanie 1 
- [Rozwiązanie na własnej liście](Kolos2_przyklad_zad1/Program.cs)
- [Rozwiązanie na typach wbudowanych w C#](Kolos2_przyklad_zad1B/Program.cs) - wielomian budowany jest na **`SortedList<int, int>`**

Chcemy reprezentować wielomiany w postaci listy jednokierunkowej par (współczynnik; wykładnik). Uwaga: przechowujemy tylko współczynniki niezerowe. Napisz zestaw metod do tworzenia takich wielomianów na podstawie tablicy, a także dodawania i odejmowania takich wielomianów oraz różniczkowania.
Np. tworzenie z tablicy {1,2,5,0,0,8} oznacza 8x<sup>5</sup> + 5x<sup>2</sup> + 2x + 1. Odpowiednia lista ma mieć postać (8;5)->(5;2)->(2;1)->(1;0)

### Zadanie 2
Opracuj strukturę danych Zbiór opartą na liście dowiązaniowej. Napisz metodą Suma (mnogościowa) tworzącą listę z elementów dwóch list. Napisz także metodę Iloczyn (mnogościowy) tworzący listę z elementów wspólnych (o takiej samej wartości klucza) z dwóch list. Dodaj metodę Różnica (mnogościowa). Rozważ dwa przypadki listy nieuporządkowane i uporządkowane. Jaka jest złożoność opracowanych algorytmów (metod)? 

### Zadanie 3
- [Rozwiązanie by tmpaccc](Kolos2_przyklad_zad3/Program.cs)

Napisz metodę (iteracyjną), która za pomocą kolejki wypisuje zawartość drzewa kolejnymi poziomami.

### Zadanie 4
- [Rozwiązanie by PKacz](Kolos2_przyklad_zad4/Program.cs)

Drzewo BST odczytano w porządku **pre-order** i otrzymano 6, 3, 1, 2, 4, 5, 7. Czy możemy odtworzyć to drzewo? Napisz metodę odtwarzającą drzewo na podstawie odczytu pre-order, jeżeli drzewa nie można odtworzyć (dane są sprzeczne, np. 6, 3, 1, 2, 4, 7, 5) metoda ma zwracać drzewo puste.

### Zadanie 5
- [Rozwiązanie by odisei369](Kolos2_przyklad_zad5/Program.cs)

Napisz metodę, która dla spójnego grafu nieskierowanego, dla którego dane są liczbowe wagi krawędzi, znajduje drzewo rozpinające o maksymalnej wartości
