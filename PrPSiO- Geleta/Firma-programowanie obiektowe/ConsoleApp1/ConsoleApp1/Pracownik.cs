using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Pracownik
    {
        public string imie { get; private set; }
        public string nazwisko { get; private set; }
        public Stanowisko stanowisko { get; private set; }
        public int wynagrodzenie { get; private set; }
        public int staz { get; private set; }

        public Pracownik(string imie, string nazwisko, Stanowisko stanowisko, int wynagrodzenie, int staz)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;
            this.wynagrodzenie = wynagrodzenie;
            this.staz = staz;
        }
        public void DajPodwyzke(int podwyzka)
        {
            this.wynagrodzenie += podwyzka;
        }

        public void ZmienStanowisko(Stanowisko noweStanowisko)
        {
            this.stanowisko = noweStanowisko;
        }

        public void Pracuj(Firma f)
        {
            f.wartosc += this.staz * 100 * stanowisko.wspolczynnik;
        }

        public string ToString()
        {
            return "{ imie: "+imie.ToString()+", nazwisko: "+nazwisko.ToString()+", stanowisko: "+stanowisko.nazwa+"}";
        }
    }
}
