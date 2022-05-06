Program ma kontrolować ilość  plików kopii we wskazanym katalogu.

Składnia :

archiv  

#path  (ścieżka do katalogu z kopiami na dysku lokalnym np.:  #path d:\kopia)

#A  xxx (rozszerzenie nadzorowanego pliku np. *.arj , *.zip,  np.  #A zip )

#L n ( maksymalna  ilość plików n kopii z rozszerzeniem #A  w katalogu  #path  )

 
Archiv usuwa pliki od najstarszego FIFO po przekroczeniu liczby #L

Po komendzie archiv /? lub archiv /h ma się wyświetlić help ze składnią

Archiv  tworzy log z nazwami usuwanych plików. Plik archiv.log tworzy się w katalogu #PATH

Archiv nie przegląda podkatalogów #PATH


Program archiv uruchamiany jest harmonogramem i wtedy wykonuje się jednorazowo .
