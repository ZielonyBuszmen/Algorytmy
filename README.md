# Algorytmy
Materiały na drugi kolos z Algorytmów i Danych Struktur 


## Lab 8 - Lista, Stos, Kolejka
- [Stos (LIFO)](StosLIFO/Program.cs)
    - [Sprawdzenie poprawności nawiasów w wyrażeniu za pomocą stosu](Stos-SprawdzeniePoprawnosciNawiasow/Program.cs)
- [Kolejka (FIFO)](KolejkaFIFO/Program.cs)
    - [Kolejka (zbudowana za pomocą dwóch stosów)](KolejkaNaDwaStosy/Program.cs)
- [Lista jednokierunkowa](ListaJednokierunkowa/Program.cs)
    - [Lista posortowana (jednokierunkowa)](ListaPosortowana/Program.cs)
- [Lista dwukierunkowa](ListaDwukierunkowa/Program.cs)


## Lab 9 - Drzewa, Drzewa binarne
- [Drzewo](Drzewo/Program.cs)
    - [Drzewo potomków Adama](DrzewoPotomkowAdama/Program.cs)
- [Drzewo binarne](DrzewoBinarne/Program.cs)
- [Drzewo Trie](DrzewoTrie/Program.cs)
- *Do dokończenia* [Drzewo Huffmana](DrzewoHuffmana/Program.cs) - [>>ZOBACZ OPIS<<](DrzewoHuffmana/README.md) - rodzaj drzewa binarnego, gdzie znakom które występują najczęściej powinniśmy przyporządkować kody najkrótsze, które występują najrzadziej kody dłuższe.


## Lab 10 - Kopiec binarny
- [Kopiec binarny](KopiecBinarny/Program.cs) - implementacja tablicowa (budowanie kopca, liczenie wysokości, ilości liści, itp)
- [Sortowanie przez kopcowanie](SortowaniePrzezKopcowanie/Program.cs) - implementacja tablicowa
- [Kopiec binarny - implementacja jako drzewo binarne](KopiecBinarnyJakoDrzewo/Program.cs)
- [Kolejka Priorytetowa](KolejkaPriorytetowa/Program.cs)


## Lab 11 - Drzewa BST
- [ to do ](#)


## Lab 12 - Zbiory (?)
- [ to do ](#)


## Lab 13 - Grafy (?)
- [ to do ](#)



# Opisy

## Drzewo
- **Stopień węzła w drzewie** - to liczba jego następników (liczba dzieci)
- **Liść** - węzeł bez następników (bez dzieci)
- **Węzeł wewnętrzny** - to węzeł, który nie jest liściem (czyli ma następników / dzieci)
- **Poziom węzła** - długość ścieżko od korzenia do tego węzła
- **Wysokość drzewa** - to największy poziom węzła w tym drzewie

## Rodzaje drzew binarnych
 - **Regularne drzewo binarne** to takie drzewo binarne, którego węzły mają stopień parzysty (czyli dwa lub zero).
 - **Zupełne drzewo binarne** to drzewo binarne, w którym wszystkie poziomy są wypełnione całkowicie, z wyjątkiem co najwyżej ostatniego - spójnie wypełnionego od lewej strony
 - **Pełne drzewo binarne** - to regularne drzewo binarne, w którym wszystkie liście mają ten sam poziom

## Przechodzenie przez drzewo
- **PRE-ORDER** - najpierw odwiedzamy poprzednik, a następnie jego następniki w kolejności od lewej do prawej.

![foto pre-order](./images/pre-order.png)

- **POST-ORDER** - najpierw odwiedzamy następniki węzła, a dopiero potem sam węzeł

![foto post-order](./images/post-order.png)

- **IN-ORDER** (tylko w drzewie binarnym) -
    - przejdź lewe pod-drzeweo,
    - odwiedź korzeń,
    - przejdź prawe pod-drzewo

## Drzewo Trie
![foto drzewo trie](./images/drzewo-trie.png)

## Drzewo Huffmana [>>Zobacz opis<<](./DrzewoHuffmana/README.md)


## Kopiec binarny
Kopiec binarny (binary heap - stóg, sterta) to zupełne drzewo binarne, spełniające warunek kopca: dla każdego węzła X wartość następnika nie jest większa niż wartość X

- **Warunek istnienia kopca** - dla każdego węzła X, wartość następnika jest nie większa niż wartość X. Jeśli X ma indeks `i` to następniki mają indeksy `2*i+1` oraz `2*i+2`
- **Liczba węzłów** - Na 0-wym poziomie jest jeden węzeł, czyli `2^0`. 
    - Na 1-szym poomie są 2 węzły, bo `2^1`. 
    - ... 
    - Na `(h-1)` poziomie jest `2^(h-1)` węzłów. 
    - Na ostatnim poziomie jest od 1 do `2^h` węzłów
- **Najmniejsza liczba węzłów** 1+2+4+...+ 2^(h-1) +1 = 2^h
- **Największa liczba węzłów**  1+2+4+...+ 2^(h-1) +2^h = 2^(h+1) -1
- **Ilość liści i ilość węzłów wewnętrznych:**
    - Liczba liści jest nie mniejsza niż liczba węzłów wewnętrznych
    - Ale jednocześnie węzłów wewnętrzych nie może być mniej niż liści o więcej niż 1
    - Czyli albo liści jest tyle co wewnętrznych gdy n parzyste
    - Albo liczba liści jest o 1 większa gdy n - nieparyste
- Gdzie w kopcu można znaleźć element najmniejszy? -> **W liściach**
-  Czy tablica, która jest odwrotnie posortowana (tzn. nierosnąco), jest kopcem? -> **Tak**


## Sortowanie przez kopcowanie
![foto sortowanie przez kopcowanie](./images/sortowanie-przez-kopcowanie.png)

