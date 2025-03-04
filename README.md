# Sold Items Manager

Projekt **Sold Items Manager** umożliwia zarządzanie produktami, kategoriami, wydarzeniami i przedmiotami w sklepie. Liczy zysk oraz bierze pod uwagę zniżki. Można również exportować i importować dane.

## Konfiguracja

1. **Połączenie z bazą danych**:

   Łańcuch połączenia do bazy danych jest ustawiony bezpośrednio w kodzie źródłowym, w klasie **AppDbContext**.

   Otwórz plik **AppDbContext.cs** w katalogu **BLL** i znajdź poniższy fragment:
   string ConnectionParameters = "";

   Aby uzyskać łańcuch połączenia z bazą danych należy w katalogu BLL kliknąć dwa razy na Database1.mdf, następnie ukaże się eksplorator serwera i należy wejść we właściwości Database1.mdf i ukażą się parametry połączenia.

   
