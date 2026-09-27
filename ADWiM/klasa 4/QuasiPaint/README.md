[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/D8XSAigx)
﻿# Zadanie 3 - Object Oriented Paint 🖌️ 🖥️

## Opis aplikacji
Celem tego zadania jest stworzenie prostej aplikacji graficznej w stylu Paint, która pozwala użytkownikowi rysować różne kształty na płótnie. 
![Finalny wygląd aplikacji](.github/assets/1.png)

Na powyższym obrazku możesz zobaczyć finalny wygląd aplikacji, którą będziesz tworzyć. Aplikacja powinna umożliwiać rysowanie prostych kształtów, takich jak:
 - Kwadraty
 - Prostokąty
 - Koła
 - Trójkąty

Program powinien reagować na zmianę koloru tła, obrysu i tekstu - które możemy ustawić w sekcji "*Właściwości*". Program pozwala również na zmianę rozmiaru rysowanych kształtów poprzez menu "Ustawienia".
Po wciśnięciu prawego przycisku myszy, kiedy znajduje się ona nad kształtem, w sekcji "*Szczegóły*" pojawią się informacje o danym kształcie, takie jak jego klasa, obwód, pole powierzchni oraz prosty opis.

## Twoje zadanie
Nie musisz przejmować się tworzeniem całej aplikacji od podstaw. Twoim zadaniem jest zaimplementowanie klas reprezentujących różne kształty oraz ich metody. Poniżej znajdziesz szczegółowy opis klas, interfejsów i metod, które musisz zaimplementować - z podziałem na poszczególne etapy.

### Etap 0 - Zapoznaj się z kodem źródłowym
Przejrzyj następujące klasy, i spróbuj zrozumieć zasadę ich działania:
 - **Klasy bazowe**
   - `Data\Geometry\FigureToDrawBase.cs` - klasa abstrakcyjna reprezentująca kształt do narysowania na płótnie.
 - **Interfejsy**
   - `Data\Interfaces\IFigure.cs` - interfejs definiujący metody, które muszą implementować klasy reprezentujące kształty.
   - `Data\Interfaces\IImage.cs` - interfejs definiujący metody, które muszą implementować kształty
   - `Data\Interfaces\IDescribable.cs` - interfejs definiujący metody, które muszą implementować kształty, aby dostarczać opisy.
   - `Data\Interfaces\IRightClickable.cs` - interfejs definiujący metody, które muszą implementować kształty, aby reagować na kliknięcia prawym przyciskiem myszy na kształt.
 - **Klasy pomocnicze**
   - `Data\FigureSettings.cs` - klasa przechowująca ustawienia dotyczące rysowanych kształtów (np. rozmiar).
   - `Data\TextControls.cs` - klasa pomocnicza przechowujące referencje do kontrolek tekstowych, w których wyświetlane są szczegóły dotyczące kształtów.

Zapoznaj się przedewszystkim z klasą **`Services\PaintEngine.cs`**, w tej klasie znajduje się trzon całej aplikacji - znajdziesz tam między innymi metody, które należy uzupełnić aby program działał prawidłowo.

```csharp
public void AddFigure(FigureType figureType)
{
    switch (figureType)
    {
        case FigureType.Square:
            //todo: Dodaj kwadrat
            break;

        case FigureType.Rectangle:
            //todo: Dodaj prostokąt
            break;

        case FigureType.Circle:
            //todo: Dodaj koło
            break;

        case FigureType.Triangle:
            //todo: Dodaj trójkąt
            break;
    }
}

private void AddSquare()
{
    //todo: Utwórz i dodaj kwadrat

    //var square = new Square() { ... };
    //AddFigure(square);
}
```

**Zwróć uwagę na komentarze `//todo:`** w powyższym kodzie - to właśnie tam musisz dodać odpowiednie wywołania do klas, które zaimplementujesz w kolejnych etapach.

> **Wskazówka:**
> 
> **Visual Studio pozwala śledzić listę zadań oznaczonych jako `//todo:`**. Na pasku narzędzi wybierz **Widok** -> **Lista zadań** aby zobaczyć wszystkie miejsca w kodzie, które wymagają Twojej uwagi.
Możesz to zrobić również za pomocą skrótu klawiaturowego `Ctrl + W`, `T`.


### Etap 1 - Klasy reprezentujące kształty

Aplikacja do prawidłowego działania wymaga zaimplementowania klas reprezentujących różne kształty. Twoim zadaniem jest utworzenie następujących klas w przestrzeni nazw `Data\Geometry`:
 - `Square.cs` - klasa reprezentująca kwadrat.
 - `Rectangle.cs` - klasa reprezentująca prostokąt.
 - `Circle.cs` - klasa reprezentująca koło.
 - `Triangle.cs` - klasa reprezentująca trójkąt.

Nie potrzebujesz mojej podpowiedzi, aby wiedzieć jakie metody i właściwości powinny posiadać te klasy. W pierwszej kolejności skup się na tym, aby klasy dziedziczyły po klasie `FigureToDrawBase`. 
W klasie bazowej znajdują się zarówno metody i właściwości już zaimplementowane, jak i te, które musisz (`abstract`) lub możesz ( `virtual`) nadpisać w klasach pochodnych.

#### Metoda `DrawOnCanvas()`
Jest to metoda **służąca do rysowania danego kształtu na płótnie**, której implementacja będzie się różnić w zależności od kształtu. Dla ułatwienia, poniżej znajdziesz propozycje implementacji tej metody:

##### Implementacja dla klasy `Circle.cs`:
```csharp
public override void DrawOnCanvas(Graphics g)
{
    using (var brush = new SolidBrush(FillingColor))
    {
        using (var pen = new Pen(BorderColor, 2))
        {
            var center = GetCenter();

            //Wskazówka: klasa powinna zawierać właściwość "Radius"
            var rect = new RectangleF(center.X - Radius, center.Y - Radius, Radius * 2, Radius * 2);

            g.FillEllipse(brush, rect);
            g.DrawEllipse(pen, rect);

            DrawInnerText(g, rect);
        }
    }
}
```
Zwróć uwagę, że powyższa implementacja korzysta z właściwości `Radius`, którą musisz dodać do klasy `Circle.cs` - **pozostałe kształty nie będą jej potrzebowały**.

##### Implementacja dla klasy `Triangle.cs`:
```csharp
private PointF _p1 => Location;
private PointF _p2 => new(Location.X + BaseWidth, Location.Y);
private PointF _p3 => new(Location.X, Location.Y + Height);

public override void DrawOnCanvas(Graphics g)
{
    using (var brush = new SolidBrush(FillingColor))
    {
        using (var pen = new Pen(BorderColor, 2))
        {
            var points = new[] { _p1, _p2, _p3 };
            g.FillPolygon(brush, points);
            g.DrawPolygon(pen, points);

            var bounds = RectangleF.FromLTRB(
                Math.Min(Math.Min(_p1.X, _p2.X), _p3.X),
                Math.Min(Math.Min(_p1.Y, _p2.Y), _p3.Y),
                Math.Max(Math.Max(_p1.X, _p2.X), _p3.X),
                Math.Max(Math.Max(_p1.Y, _p2.Y), _p3.Y));

            DrawInnerText(g, bounds);
        }
    }
}
```
Kod tej metody zawiera pewne wskazówki implementacyjne, oprócz punktów `_p1`, `_p2` i `_p3`, które reprezentują wierzchołki trójkąta, będziesz potrzebował jeszcze szerokości podstawy oraz wysokości.

##### Implementacja dla klasy `Rectangle.cs`:
```csharp
public override void DrawOnCanvas(Graphics g)
{
    using (var brush = new SolidBrush(FillingColor))
    {
        using (var pen = new Pen(BorderColor, 2))
        {
            var rect = new RectangleF(Location.X, Location.Y, Width, Height);

            g.FillRectangle(brush, rect);
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

            DrawInnerText(g, rect);
        }
    }
}
```
Jeżeli chodzi o implementecję metody `DrawOnCanvas()` dla klasy `Square.cs`, to możesz skorzystać z implementacji klasy `Rectangle.cs`, ponieważ kwadrat jest szczególnym przypadkiem prostokąta, gdzie szerokość i wysokość są równe.

#### Metoda `GetCenter()`
Metoda dostarcza informacje o środku danego kształtu. Implementacja tej metody będzie się różnić w zależności od kształtu. Poniżej znajdziesz propozycje implementacji tej metody dla trudniejszych kształtów:

##### Implementacja dla klasy `Circle.cs`:
```csharp
public override PointF GetCenter() => Location;
```
Tutaj jest dość prosto, ponieważ środek koła jest po prostu jego lokalizacją.

##### Implementacja dla klasy `Triangle.cs`:
```csharp
public override PointF GetCenter()
{
    return new PointF((_p1.X + _p2.X + _p3.X) / 3f, (_p1.Y + _p2.Y + _p3.Y) / 3f);
}
```
Tutaj obliczamy **środek ciężkości trójkąta**. Jest to punkt, w którym przecinają się środkowe trójkąta. Środek ciężkości to **średnia arytmetyczna** współrzędnych wierzchołków trójkąta.

##### Pozostałe kształty
Implementacja metody `GetCenter()` dla klas `Rectangle.cs` oraz `Square.cs` jest dość prosta i nie powinieneś mieć trudności z jej implementacją. 🙂

#### Metoda `ContainsPoint()`
Metoda ta sprawdza, czy dany punkt znajduje się wewnątrz kształtu. Poniżej znajdziesz propozycje implementacji tej metody dla trudniejszych kształtów:

##### Implementacja dla klasy `Circle.cs`:
```csharp
public override bool ContainsPoint(PointF p)
{
    var center = GetCenter();

    var dx = p.X - center.X;
    var dy = p.Y - center.Y;

    return dx * dx + dy * dy <= Radius * Radius;
}
```
Punkt `P` należy do koła o środku w punkcie `center` i promieniu `Radius`, jeżeli odległość punktu `P` od środka koła jest mniejsza lub równa promieniowi.

##### Implementacja dla klasy `Triangle.cs`:
```csharp
public override bool ContainsPoint(PointF p)
{
    float area = TriangleArea(_p1, _p2, _p3);
    float a1 = TriangleArea(p, _p2, _p3);
    float a2 = TriangleArea(_p1, p, _p3);
    float a3 = TriangleArea(_p1, _p2, p);

    return Math.Abs(area - (a1 + a2 + a3)) <= 0.5f;
}
```
Tutaj korzystamy z **techniki barycentrycznej**, polegającej na przedstawieniu punktu `P` jako kombinacji liniowej wierzchołków trójkąta. Jeżeli suma pól trzech trójkątów utworzonych przez punkt `P` i pary wierzchołków trójkąta jest równa polu całego trójkąta, to punkt `P` znajduje się wewnątrz trójkąta.

##### Pozostałe kształty
Implementacja metody `ContainsPoint()` dla klas `Rectangle.cs` oraz `Square.cs` jest dość prosta i nie powinieneś mieć trudności z jej implementacją.

#### Podsumowanie
Kiedy stworzysz i zaimplementujesz wszystkie klasy reprezentujące kształty, upewnij się, że w klasie `PaintEngine.cs` w metodzie `AddFigure()` wywołujesz odpowiednie metody dodające kształty do płótna. Metoda `AddFigure()` jest już
podłączona do przycisków Windows Forms, więc po jej poprawnym zaimplementowaniu powinieneś być w stanie dodać kształty do płótna poprzez interfejs użytkownika.

> **Wskazówka:**
>
> Rozmiary oraz kolory dla rysowanych kształtów są dostępne w właściwościach obiektu `FigureSettings`, który jest dostępny w klasie `PaintEngine` poprzez właściwość `FigureSettings`. Możesz z niego korzystać podczas tworzenia nowych kształtów, aby ustawić ich rozmiary i kolory.

### Etap 2 - Ustawienia rysowanych kształtów
Aby nasz program był bardziej funkcjonalny, musimy umożliwić użytkownikowi zmianę rozmiaru i kolorów rysowanych kształtów. W tym celu musisz zaimplementować możliwość zmiany
ustawień rysowanych kształtów:
```csharp
public FigureSettings FigureSettings { get; private set; }

public void UpdateFigureSettings(FigureSettings newSettings)
{
    //todo: Zaktualizuj ustawienia figur
}

public void UpdateCurrentColors(FigureColorTarget target, Color color)
{
    //todo: Zaktualizuj kolor w ustawieniach figur
    //tip: Pamiętaj, że FigureSettings jest niemutowalny (immutable) - zasady kopiowania rekordów
    //tip2: Jako argument dostajemy typ wyliczeniowy, użyj instrukcji switch
}
```
**Zauważ, że klasa `FigureSettings` jest niemutowalna (immutable)**, co oznacza, że nie możesz zmieniać jej właściwości bezpośrednio. Zamiast tego musisz tworzyć nowe instancje
`FigureSettings` z zaktualizowanymi wartościami. Zwróć również uwagę na to, że metoda `UpdateFigureSettings()` modyfikuje wszystkie właściwości dotyczące rozmiaru wszystkich figur.
Metoda `UpdateCurrentColors()` natomiast modyfikuje tylko jeden z kolorów (tło, obrys lub tekst) na podstawie przekazanego argumentu `FigureColorTarget`.

**Implementując te metody, wykorzystaj wiedzę zdobytą podczas lekcji** odnośnie niemutowalnych rekordów w C# oraz sposobu ich kopiowania z modyfikacjami.

### Etap 3 - Szczegóły kształtów
W klasie `PaintEngine.cs` znajduje się metoda `SetInfo(IFigure figure)`, która jest wywoływana automatycznie, gdy użytkownik kliknie prawym przyciskiem myszy na dany kształt.
```csharp
/// <summary>
/// Ustawia tekst z polem powierzchni figury.
/// </summary>
/// <param name="figure"></param>
private void SetInfo(IFigure figure)
{
    //todo: Ustaw pole powierzchni figury (u² to skrót od "jednostka (unit) do kwadratu")
    _textControls.AreaLabel.Text = $"{String.Empty} u²";

    //todo: Ustaw obwód figury (u to skrót od "jednostka (unit)")
    _textControls.PerimeterLabel.Text = $"{String.Empty} u";

    //todo: Ustaw nazwę klasy figury
    _textControls.ClassLabel.Text = String.Empty;

    if (figure is IDescribable drawFig)
    {
        //todo: Ustaw opis figury w polu StatementBox (dostępne w zmiennej drawFig)
        _textControls.StatementBox.Text = String.Empty;
    }

    else
    {
        _textControls.StatementBox.Text = "Brak opisu dla tej figury.";
    }
}

private void ClearInfo()
{
    _textControls.AreaLabel.Text = String.Empty;
    _textControls.PerimeterLabel.Text = String.Empty;
    _textControls.ClassLabel.Text = String.Empty;
    _textControls.StatementBox.Text = "Kliknij na figurę, żeby sprawdzić";
}
```

Zauważ, że metoda `SetInfo()` korzysta z interfejsów `IFigure` - oznacza to, że możemy jako argument przekazać dowolny kształt, który zaimplementuje ten interfejs. Wewnątrz metody musisz uzupełnić odpowiednie pola tekstowe w obiekcie `_textControls` na podstawie właściwości i metod dostępnych w interfejsie `IFigure`.

Metoda również pozwala na umieszczenie opisu kształtu, jednakże będzie to działało tylko wtedy, gdy dany kształt zaimplementuje interfejs `IDescribable`. W takim przypadku możesz rzutować przekazany argument `figure` na typ `IDescribable`, aby uzyskać dostęp do właściwości i metod tego interfejsu.

## Etap 4 - Implementacja pozostałych interfejsów
Aby nasza aplikacja obsługiwała wszystkie przewidziane dla niej funkcjonalności, musimy również zaimplementować pozostałe interfejsy w klasach reprezentujących kształty:
 - `IDescribable` - interfejs pozwalający na dostarczenie opisu kształtu.
 - `IRightClickable` - interfejs pozwalający na obsługę kliknięć prawym przyciskiem myszy na kształt.

 Po zaimplementowaniu tych interfejsów w danych klasach reprezentujących kształty, aplikacja automatycznie zyska nowe funkcjonalności dla kształtów, implementujących te interfejsy.

 ## Zadania do wykonania:
 1. Stwórz klasy reprezentujące kształty: `Square`, `Rectangle`, `Circle`, `Triangle`.
 2. Zaimplementuj klasę abstrakcyjną `FigureToDrawBase` w klasach reprezentujących kształty.
 3. Dodaj obsługę zmiany ustawień rysowanych kształtów w klasie `PaintEngine`.
 4. Zaimplementuj interfejs `IDescribable` w klasach reprezentujących kształty, aby dostarczyć opisy kształtów.
    - Niech każda klasa zwraca unikalny opis swojego kształtu.
 5. Zaimplementuj interfejs `IRightClickable` w klasach reprezentujących kształty, aby obsłużyć kliknięcia prawym przyciskiem myszy na kształty.
    - Niech każda klasa wykonuje inną, unikalną akcję po kliknięciu prawym przyciskiem myszy - zachęcam do uruchomienia wyobraźni! 😎

### Zadanie dodatkowe (*opcjonalne*)
Jeżeli chcesz otrzymać ocenę celującą, do interfejsu graficznego dodaj przycisk "Wyczyść", który po kliknięciu usunie wszystkie narysowane kształty z płótna.

### Efekt końcowy:
Po wykonaniu wszystkich powyższych zadań, Twoja aplikacja powinna być w pełni funkcjonalna, umożliwiając użytkownikowi rysowanie różnych kształtów na płótnie, zmianę ich rozmiarów i kolorów, a także wyświetlanie szczegółowych informacji o kształtach po kliknięciu prawym przyciskiem myszy. Gratulacje! 🎉🖌️🖥️