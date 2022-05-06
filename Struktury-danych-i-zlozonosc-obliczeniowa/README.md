# Struktury-danych-i-zlozonosc-obliczeniowa

Projekt w ramach kursu na pwr.

Implementacja wybranych struktur danych bez STL

Należy zaimplementować oraz dokonać pomiaru czasu działania operacji takich jak dodawanie elementu, usunięcie elementu i wyszukanie elementu w następujących strukturach danych: Tablica, Lista, Kopiec binarny, Drzewo czerwono-czarne.

ZASADY:

podstawowym elementem struktur jest 4 bajtowa liczba całkowita ze znakiem

wszystkie struktury danych powinny być alokowane dynamicznie ( w przypadku tablic powinny zajmować jak najmniej miejsca - powinny być relokowane przy dodawaniu/usuwaniu elementu)

w przypadku tablicy i listy rozpatrzeć osobno operacje dodawania i usuwania elementu na następujących pozychach a)początek tab/listy b)koniec tab/listy c)losowe miejsce tablicy/listy

należy pomierzyć czas wykonywania poszczególnych operacji w funkcji rozmiaru danej struktury ( ilości elementów w niej przechowywanych). W przypadku zbyt krótkich czasów można albo zwiększyć ilość danych pomiarowych, albo powtórzyć dany pomiar np. 10 razy. Ponieważ wyniki zaleą także od rozkładu danych, to pomiary dla konkretnego rozmiaru należy wkonać wielokrotnie (np. 100 razy - za każdym razem generując nową populacje) a wynik uśrednić. Ilość przechowywanych elementów należy dobrać eksperymentalnie (np. może to być 1000,2000,5000,100000,20000) w zależności od wydajności sprzętu.

5)Należy mieć na uwadze, że czas wykonywania operacji może zależeć od wartości przechowywanych elementów, co należy uwzględnić w pomiarach i wnioskach

dodatkową funkcje programu musi być możliwość sprawdzenia poprawności zaimplementowanych operacji i zbudowanej struktury (szerzej w daleszej części dokumentu)

sposoby dokładnego pomiaru czasu w systemie Windows podano na stronie http:jaroslaw.mierzwa.staff.iiar.pwr.wroc.pl/debug_and_time.pdf

8). dopuszczalnymi językami są języki kompilowane do kodu natywnego <- wybrany C++

Używanie konienek nie jest wymagane. Nie wpływa to na ocene projektu

NIE WOLNO KORZYSTAĆ Z GOTOWYCH BIBLIOTEK np. STL, BOOST lub innych - wszystkie algorytmy i struktury muszą być zaimplementowane przez studenta (nie kopiować z gotowych rozwiązań)

realizacja zadania powinna być wykonana w formie jednego pliku

kod źródłowy powinien być komentowany

