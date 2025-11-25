using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanBinarny.Models
{
    internal class Trip
    {
        public int Distance { get; init; }
        public DateTime Date { get; init; }

        public Trip(string sciezka)
        {
            string[] temp = sciezka.Split('\t');
            Date = DateTime.Parse(temp[0]);
            Distance = int.Parse(temp[1]);
        }
    }
}