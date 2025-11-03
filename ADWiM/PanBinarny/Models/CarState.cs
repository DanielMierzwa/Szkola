using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanBinarny.Models;

namespace PanBinarny.Models
{
    internal class CarState
    {
        public FuelState Fuel { get; init; }
        public List<Trip> Trips { get; init; }

        private int TripIndex=0;

        public CarState()
        {
            Trips = new List<Trip>();
            Fuel = new FuelState();
            string path = @".\lpg.txt";

            try
            {
                string[] lines = File.ReadAllLines(path);
                bool header = false;
                foreach (string line in lines)
                {
                    if (!header)
                    {
                        header = true;
                        continue;
                    }
                    Trips.Add(new Trip(line));
                    //Console.WriteLine(Trips[Trips.Count-1].Distance.ToString());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Błąd odczytu pliku: " + ex.Message);
            }
        }

        public bool Drive()
        {
            if (TripIndex >= Trips.Count)
                return false;
            Fuel.Display();
            Fuel.CombustFuel(Trips[TripIndex].Distance);
            Fuel.TankFuel(Trips[TripIndex].Date);

            TripIndex++;
            return true;
        }
    
    }
}
