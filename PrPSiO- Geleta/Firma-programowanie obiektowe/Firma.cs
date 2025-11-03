using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Firma
    {
        public List<Pracownik> pracownicy { get; private set; }
        public Stanowisko[] stanowiska { get; private set; }
        public int wielkosc { get; private set; }
        public double wartosc{ get; set; }

        public Firma(int wartosc)
        {
            pracownicy = new List<Pracownik>();
            stanowiska = new Stanowisko[]{
                                            new Stanowisko("Monter", 1.0),
                                            new Stanowisko("Magazynier", 0.5),
                                            new Stanowisko("Kierowca", 1.5),
                                            new Stanowisko("Menadżer", 4.0)};
            wielkosc = 0;
            this.wartosc = wartosc;
        }

        public void dodajPracownika(string imie_nazwisko, Stanowisko stanowisko, int wynagrodzenie)
        {
            wielkosc++;
            string[] temp=imie_nazwisko.Split(' ');
            string imie=temp[0];
            string nazwisko = temp[1];
            pracownicy.Add(new Pracownik(imie, nazwisko, stanowisko,wynagrodzenie,0));
        }

        public void ZwolnijPracownika(string imie_nazwisko)
        {
            string[] temp = imie_nazwisko.Split(' ');
            string imie = temp[0];
            string nazwisko = temp[1];
            foreach(Pracownik pracownik in pracownicy)
            {
                if(pracownik.imie==imie && pracownik.nazwisko == nazwisko)
                {
                    pracownicy.Remove(pracownik);
                    break;
                }
            }
        }

        public void Pracuj()
        {
            foreach(Pracownik pracownik in pracownicy)
            {
                pracownik.pracuj(this);
            }
        }

        public string ToString()
        {
            return "{wartosc:}";
        }
    }
}
