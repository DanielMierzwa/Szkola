using System;
using System.Collections.Generic;
using System.Text;

namespace FF.Models
{
    public class FunctionRoot
    {
        public FunctionRoot(double re, double im = Double.NaN)
        {
            Realis = re;
            Imaginalis = im;
        }

        public double Realis { get; set; }

        public double Imaginalis { get; set; }

        public override string ToString()
        {
            if (Double.IsNaN(Imaginalis)) // <-- Brak części urojonej pierwiastka
            {
                return Math.Round(Realis, 2).ToString(); // <-- Wyświetlanie pierwiastka rzeczywistego
            }

            if (Imaginalis > 0)
                return Math.Round(Realis, 2).ToString() +"+"+ Math.Round(Imaginalis, 2).ToString()+"i";
            else
                return Math.Round(Realis, 2).ToString() + "-" + Math.Round(Math.Abs(Imaginalis), 2).ToString() + "i";

        }
    }
}
