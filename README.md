# Sold Items Manager

Projekt **Sold Items Manager** umożliwia zarządzanie produktami, kategoriami, wydarzeniami i przedmiotami w sklepie. Liczy zysk oraz bierze pod uwagę zniżki. Można również exportować i importować dane.

## Konfiguracja
1. **Sklonuj repozytorium**:

   git clone https://github.com/Nomislaw/Sold-Items-Manager.git

   Otwórz folder Sold-Items-Manager

3. **Połączenie z bazą danych**:

   Łańcuch połączenia do bazy danych jest ustawiony bezpośrednio w kodzie źródłowym, w klasie **AppDbContext**.

   Otwórz plik **AppDbContext.cs** w katalogu **BLL** i znajdź poniższy fragment:
   string ConnectionParameters = "";

   Aby uzyskać łańcuch połączenia z bazą danych należy w katalogu BLL utworzyć bazę danych. Prawym przyciskiem myszy -> Dodaj -> Nowy element -> Baza danych oparta o usługi.
   Kliknąć dwa razy na plik Database.mdf, następnie ukaże się eksplorator serwera i należy wejść we właściwości Database1.mdf i ukażą się parametry połączenia. Skopiować parametry
   połączenia do string Connection Parameters

   
