using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Stanowisko
    {
        public string nazwa { get; private set; }
        public double wspolczynnik { get; private set; }

        public Stanowisko(string nazwa, double wspolczynnik)
        {
            this.nazwa = nazwa;
            this.wspolczynnik = wspolczynnik;
        }
    }
}
