using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    enum TrybSortowania
    {
        Nazwa,
        Rozmiar,
        Data,
        NazwaMalejaco,
        RozmiarMalejaco,
        DataMalejaco
    }

    static TrybSortowania PobierzTrybSortowania(string tryb)
    {
        return tryb.ToLower() switch
        {
            "nazwa" => TrybSortowania.Nazwa,
            "rozmiar" => TrybSortowania.Rozmiar,
            "data" => TrybSortowania.Data,
            "nazwamalejaco" => TrybSortowania.NazwaMalejaco,
            "rozmiarmalejaco" => TrybSortowania.RozmiarMalejaco,
            "datamalejaco" => TrybSortowania.DataMalejaco,
            _ => TrybSortowania.Nazwa,
        };
    }

    static int LiczElementyWKatalogu(DirectoryInfo katalog)
    {
        return katalog.GetFiles().Length + katalog.GetDirectories().Length;
    }

    static string PobierzAtrybutyDostepu(FileSystemInfo element)
    {
        if (element is FileInfo plik)
        {
            string atrybuty = plik.IsReadOnly ? " (Tylko do odczytu)" : "";
            if (plik.Attributes.HasFlag(FileAttributes.Hidden))
                atrybuty += " (Ukryty)";
            return atrybuty;
        }
        return "";
    }

    static string PobierzCzasModyfikacji(FileSystemInfo element)
    {
        return element.LastWriteTime.ToString("yyyy-mm-dd");
    }

    static string OpisPliku(FileInfo plik)
    {
        string opis = $"{plik.Length / 1000.0:F2} KB , {PobierzCzasModyfikacji(plik)}";
        string atrybuty = PobierzAtrybutyDostepu(plik);
        if (!string.IsNullOrEmpty(atrybuty))
            opis += " , " + atrybuty;
        return opis;
    }

    static string OpisKatalogu(DirectoryInfo katalog)
    {
        return $"{LiczElementyWKatalogu(katalog)} elementów , {PobierzCzasModyfikacji(katalog)}";
    }

    static void WyswietlKatalog(string sciezka, string wciecie, TrybSortowania sortowanie)
    {
        DirectoryInfo katalog = new DirectoryInfo(sciezka);

        Console.WriteLine($"{wciecie} {katalog.Name} : {OpisKatalogu(katalog)}");

        var podkatalogi = katalog.GetDirectories().ToList();
        var pliki = katalog.GetFiles().ToList();

        switch (sortowanie)
        {
            case TrybSortowania.Nazwa:
                podkatalogi = podkatalogi.OrderBy(d => d.Name).ToList();
                pliki = pliki.OrderBy(p => p.Name).ToList();
                break;
            case TrybSortowania.NazwaMalejaco:
                podkatalogi = podkatalogi.OrderByDescending(d => d.Name).ToList();
                pliki = pliki.OrderByDescending(p => p.Name).ToList();
                break;
            case TrybSortowania.Rozmiar:
                podkatalogi = podkatalogi.OrderBy(d => LiczElementyWKatalogu(d)).ToList();
                pliki = pliki.OrderBy(p => p.Length).ToList();
                break;
            case TrybSortowania.RozmiarMalejaco:
                podkatalogi = podkatalogi.OrderByDescending(d => LiczElementyWKatalogu(d)).ToList();
                pliki = pliki.OrderByDescending(p => p.Length).ToList();
                break;
            case TrybSortowania.Data:
                podkatalogi = podkatalogi.OrderBy(d => d.LastWriteTime).ToList();
                pliki = pliki.OrderBy(p => p.LastWriteTime).ToList();
                break;
            case TrybSortowania.DataMalejaco:
                podkatalogi = podkatalogi.OrderByDescending(d => d.LastWriteTime).ToList();
                pliki = pliki.OrderByDescending(p => p.LastWriteTime).ToList();
                break;
        }

        foreach (var plik in pliki)
        {
            Console.WriteLine($"{wciecie}     {plik.Name} : {OpisPliku(plik)}");
        }

        foreach (var podkatalog in podkatalogi)
        {
            WyswietlKatalog(podkatalog.FullName, wciecie + "    ", sortowanie);
        }
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Użycie: Program <ścieżka> <tryb sortowania>");
            return;
        }

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string sciezka = args[0];
        string tryb = args[1];

        Console.WriteLine($"Przegląd katalogu: {sciezka}");
        WyswietlKatalog(sciezka, "", PobierzTrybSortowania(tryb));
    }
}
//aby podać argumenty wejdź Właściwości>Debuguj>Interfejs użytkownika otwartych profilów uruchamiania debugowania
//tam w pierszym polu wpisz ścieżkę, a w drugiej linijce tryb sortowania
