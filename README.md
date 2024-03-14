# Code Review
Co Ÿle wp³ywa na program:
```
- W pliku program.cs zosta³a podana z³a nazwa pliku
- Nieu¿ywana zmienna printData
- Dodatkowe pêtle, których czynnoœci mo¿na powpychaæ do innych, dziêki temu kod szybciej siê skompiluje
- Du¿a iloœæ if'ów, kod staje siê nieczytelny
- Przy zczytywaniu danych brakuje sprawdzenia czy wiersz posiada kolumny, st¹d b³¹d index out of range
- Gdy plik w pierwszej linii zawiera informacje o kolumnach, dobr¹ praktyk¹ jest pominiêcie tej linii podczas analizy danych
```
Dodatkowo dane w pliku data.csv s¹ wpisane dosyæ chaotycznie, przez co program odczyta³ np. brak bazy "WideWorldImporters"
Poprawki:
```
- Pokasowa³em puste linijki w pliku data.csv
- Skasowa³em pêtle a instrukcje wklei³em do innych
- Pokasowane niepotrzebne if'y, a w miejscach gdzie tworzy³y siê "schodki", 
powkleja³em warunki do innych, tak aby logika programu zosta³a zachowana
```
Poza tym dobry kod, ³adne wciêcia i dobrze wykorzystany podzia³ kodu na pliki.