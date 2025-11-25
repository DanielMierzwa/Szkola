[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/0RJXYKGM)
# Zadanie 2 – Pan Binarny 🚗💨 ⛽

## Opis problemu

Pan Binarny założył instalację gazową w swoim samochodzie, dzięki czemu może używać dwóch rodzajów paliwa:

| Paliwo | Pojemność zbiornika | Spalanie (na 100 km) |
|:--------|:--------------------|:---------------------|
| **Pb95** | 45 litrów | 6 litrów |
| **LPG**  | 30 litrów | 9 litrów |

W pliku **`lpg.txt`** znajdują się dane niezbędne do wykonania zadania – każda linia zawiera:
- datę wyjazdu,
- liczbę kilometrów przejechanych danego dnia.

Pierwszy wiersz to nagłówek. Dane są rozdzielone tabulatorem (`\t`).

```csv
data    km
2025-01-01  159
2025-01-02  82
2025-01-03  108
```

### Zasady działania programu

1 stycznia 2025 r. oba zbiorniki są pełne (*45 l Pb95, 30 l LPG**).  
Każdego dnia rano Pan Binarny podejmuje decyzję:
- jeśli w zbiorniku **LPG** jest więcej niż **15 l**, to całą trasę pokonuje na **LPG**,
- w przeciwnym razie połowę trasy pokonuje na **LPG**, a połowę na **Pb95**.

**Liczbę zużytych litrów paliwa obliczamy według wzoru:**

```math
zużycie = (spalanie * liczba_kilometrów) / 100
```

gdzie `spalanie` oznacza zużycie paliwa w litrach na 100 km.

**Wyniki zaokrąglamy do dwóch miejsc po przecinku!**

Bez względu na rodzaj paliwa tankowanie wykonywane było po przejechaniu trasy, wieczorem. W każdy czwartek, o ile w zbiorniku z Pb95 znajdowało się poniżej 40 litrów, pan Binarny tankował do pełna Pb95. Paliwo LPG było tankowane do pełna wtedy, gdy w zbiorniku LPG znajdowało się mniej niż 5 litrów tego paliwa i odbywało się niezależnie od dnia tygodnia.

> **Uwaga do zadania**:
>
> Przyjmujemy, że nigdy nie zabrakło mu paliwa na trasie.

---

## Zadania do wykonania

1. Podaj, ile razy Pan Binarny tankował **Pb95**.
2. Podaj, ile razy Pan Binarny tankował **LPG**.
3. Podaj liczbę dni, w których korzystał wyłącznie z paliwa **LPG**.
4. Podaj datę, w której w zbiorniku LPG po raz pierwszy było rano mniej niż **5,25 l**. *(datę zapisz w postaci dd-MM-yyyy, użyj jawnie metody `.ToString("dd-MM-yyyy")`)*

Przyjmując:
- cena 1 l LPG = **2,59 zł**,  
- cena 1 l Pb95 = **5,89 zł**,  
- koszt instalacji gazowej = **3000 zł**,  

oblicz:

5. Podaj koszt eksploatacji samochodu z instalacją gazową (uwzględnij koszt instalacji i zużycie LPG oraz Pb95).
6. Podaj koszt eksploatacji samochodu korzystającego wyłącznie z Pb95.
7. Podaj informację, które rozwiązanie jest korzystniejsze - wyświetl wyłącznie `Pb95` lub `LPG`.

Zaokrąglaj wszystkie wyniki do dwóch miejsc po przecinku.

> **Uwaga:**
>
> - **W zadaniu 5** przyjmij wszystkie opisane założenia dotyczące jazdy i tankowania pana Binarnego - tak, jak zostało to opisane w zadaniu.
> - **W zadaniu 6** przyjmij, że nie ma znaczenia dzień tankowania, liczy się jedynie koszt eksploatacji.

8. Jeżeli użytkownik jako argument wiersza poleceń przekaże wartość, która nie jest liczbą całkowitą, program powinien wyświetlić **dokładnie ten komunikat** i zakończyć działanie:
  ```powershell
  Wprowadzona wartość nie jest liczbą całkowitą 
  ```
9. Jeżeli użytkownik przekaże liczbę całkowitą, ale spoza zakresu 1-7, program powinien wyświetlić **dokładnie ten komunikat** i zakończyć działanie:
  ```powershell
  Nie ma takiego zadania 
  ```

## Wymagania techniczne projektu

- Projekt wykonaj jako **aplikację konsolową .NET 8** w języku C#.

---

## Instrukcja tworzenia projektu w Visual Studio

1. Otwórz **Visual Studio**.  
2. Wybierz **Nowy projekt → Aplikacja konsolowa (.NET 8.0)**.  
3. Nadaj nazwę projektu, np. `PanBinarny` lub `MrBinary`.
4. Przy tworzeniu projektu zaznacz opcje:
   - **Umieść rozwiązanie i projekt w tym samym katalogu**
   - **Nie używaj instrukcji najwyższego poziomu**
5. W projekcie zostanie utworzony plik `Program.cs` z metodą `Main()`.  
   W tym miejscu rozpocznij pisanie programu.

---

## Dodanie pliku `lpg.txt` do projektu

1. Skopiuj plik **`lpg.txt`** do katalogu głównego projektu (tam, gdzie jest plik `Program.cs`).  
2. Kliknij prawym przyciskiem myszy na pliku → **Właściwości**.  
3. Ustaw opcję **Kopiuj do katalogu wyjściowego** → `Kopiuj zawsze`.  
4. Dzięki temu w kodzie możesz wczytać dane tak:
   ```csharp
   var lines = File.ReadAllLines("lpg.txt");
   ```

---

## Wczytywanie danych z pliku

Każda linia (poza nagłówkiem) zawiera datę i liczbę kilometrów rozdzielone tabulatorem:

```csv
data    km
2025-01-01    125
2025-01-02    89
...
```

Przykład wczytania danych:
```csharp
var lines = File.ReadAllLines("lpg.txt");
for (var i = 1; i < lines.Length; i++) //pomijamy nagłówek
{
    var parts = lines[i].Split('\t');
    var date = parts[0];
    var distance = Double.Parse(parts[1]);
    // dalsze obliczenia...
}
```

---

## Wskazówki

- Warto stworzyć własne klasy do przechowywania danych, np.:
  ```csharp
  class Trip
  {
      public DateTime Date;
      public double Distance;
  }

  class FuelState
  {
      public double Pb95Level;
      public double LpgLevel;
  }
  ```
- Wykorzystuj metody i obiekty, aby kod był czytelny i logiczny.

---

## Argumenty wiersza poleceń

Program powinien akceptować argument wiersza poleceń z numerem zadania (np. `1`, `2`, itd.).  
Jeśli argument zostanie przekazany – program ma **wyświetlić tylko wynik** (bez jednostek).

Przykład uruchomienia:
```bash
PanBinarny.exe 1
```

➡️ Program powinien wtedy wypisać tylko np.:
```
6
```

Jeśli argumentów **nie przekazano**, program powinien ładnie wypisać wyniki wszystkich zadań (tutaj macie wolną rękę 😉)
```
Zadania 1 i 2:
    - Liczba tankowań Pb95: 6
    - Liczba tankowań LPG: 12

Zadanie 3:
    - Liczba dni tylko na LPG: 2

Zadanie 4:
    - Poziom LPG spadł poniżej 5,25 l w dniu 06-02-2025
    
//itd...
```

### Jak obsłużyć argumenty w `Main()`:
```csharp
static void Main(string[] args)
{
    if (args.Length > 0)
    {
        //Zostały przekazane argumenty...
        var numerZadania = ... // <-- Powinieneś użyć bezpiecznego parsowania - Int32.TryParse(...)
        switch (numerZadania)
        {
            case 1:
                //wyświetl wynik zadania 1
            case 2:
                //wyświetl wynik zadania 2
        }
    }

    else
    {
        //Wyświetl wszystkie wyniki
    }
}
```

---

## Testowanie argumentów przy pomocy `dotnet run`

1. Uruchom **terminal (CMD lub PowerShell)** w katalogu projektu, gdzie znajduje się plik `.csproj`.
2. Aby uruchomić program z argumentem, wpisz:
   ```bash
   dotnet run -- 1
   ```
   *(pamiętaj o dwóch myślnikach `--` – są wymagane do przekazania argumentów do aplikacji)*
3. Aby uruchomić program bez argumentów:
   ```bash
   dotnet run
   ```

---

## Dodatkowe uwagi

- Nie używaj **LINQ** – zadanie ma być rozwiązane przy użyciu tablic i pętli.  
- Zaokrąglaj wszystkie wyniki przy wyświetlaniu do **dwóch miejsc po przecinku**.  
- Kod powinien być podzielony na czytelne fragmenty (klasy, metody).

---

## Struktura projektu

```
PanBinarny/
├── Models/
│   ├── Trip.cs
│   └── FuelState.cs
├── Program.cs
├── lpg.txt
└── README.md
```

---

**Podpowiedź:**  
Przed rozpoczęciem pracy możesz wypisać pierwsze kilka wierszy z `lpg.txt`, aby upewnić się, że plik jest poprawnie wczytywany.
