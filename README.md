# Sold Items Manager

Projekt **Sold Items Manager** umożliwia zarządzanie produktami, kategoriami, wydarzeniami i przedmiotami w sklepie. Liczy zysk oraz bierze pod uwagę zniżki. Można również exportować i importować dane.

## Konfiguracja

1. **Połączenie z bazą danych**:

   Łańcuch połączenia do bazy danych jest ustawiony bezpośrednio w kodzie źródłowym, w klasie **AppDbContext**.

   Otwórz plik **AppDbContext.cs** w katalogu **BLL** i znajdź poniższy fragment:
   string ConnectionParameters = "";
