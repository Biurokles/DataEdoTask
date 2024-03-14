# Code Review
Co �le wp�ywa na program:
```
- W pliku program.cs zosta�a podana z�a nazwa pliku
- Nieu�ywana zmienna printData
- Dodatkowe p�tle, kt�rych czynno�ci mo�na powpycha� do innych, dzi�ki temu kod szybciej si� skompiluje
- Du�a ilo�� if'�w, kod staje si� nieczytelny
- Przy zczytywaniu danych brakuje sprawdzenia czy wiersz posiada kolumny, st�d b��d index out of range
- Gdy plik w pierwszej linii zawiera informacje o kolumnach, dobr� praktyk� jest pomini�cie tej linii podczas analizy danych
```
Dodatkowo dane w pliku data.csv s� wpisane dosy� chaotycznie, przez co program odczyta� np. brak bazy "WideWorldImporters"
Poprawki:
```
- Pokasowa�em puste linijki w pliku data.csv
- Skasowa�em p�tle a instrukcje wklei�em do innych
- Pokasowane niepotrzebne if'y, a w miejscach gdzie tworzy�y si� "schodki", 
powkleja�em warunki do innych, tak aby logika programu zosta�a zachowana
```
Poza tym dobry kod, �adne wci�cia i dobrze wykorzystany podzia� kodu na pliki.