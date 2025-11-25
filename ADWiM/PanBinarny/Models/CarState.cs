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

        public int onlyLPGDays { get; private set; }

        private int TripIndex = 0;

        public string dayWhenLPGWasBelow525 { get; private set; }

        public CarState()
        {
            Trips = new List<Trip>();
            Fuel = new FuelState();
            dayWhenLPGWasBelow525 = "";
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
            Trip Trip = Trips[TripIndex];
            if (dayWhenLPGWasBelow525 == "")
            {
                if (Fuel.LevelLPG < 5.25)
                {
                    dayWhenLPGWasBelow525 = Trip.Date.ToString();
                }
            }

            Fuel.Display();
            Fuel.CombustFuel(Trip.Distance);
            Fuel.TankFuel(Trip.Date);
            if (Fuel.onlyLPG)
                onlyLPGDays++;

            TripIndex++;
            return true;
        }
        public bool Drive(bool onlyGas)
        {

            if (TripIndex >= Trips.Count)
                return false;
            Trip Trip = Trips[TripIndex];
            if (dayWhenLPGWasBelow525 == "")
            {
                if (Fuel.LevelLPG < 5.25)
                {
                    dayWhenLPGWasBelow525 = Trip.Date.ToString();
                }
            }

            //Fuel.Display();
            Fuel.CombustFuel(Trip.Distance,onlyGas);
            Fuel.TankFuel(Trip.Date);
            if (Fuel.onlyLPG)
                onlyLPGDays++;

            TripIndex++;
            return true;
        }

    }
}