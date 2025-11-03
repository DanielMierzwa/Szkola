using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PanBinarny.Models
{
    internal class FuelState
    {
        public double maxLPG {  get; init; }
        public double maxPb95 { get; init; }
        public double LevelLPG { get; private set; }
        public double LevelPb95 { get; private set; }

        public double CombustLPG { get; init; }
        public double CombustPb95 { get; init; }

        public double TankedLitersLPG { get; private set; }
        public double TankedLitersPb95 { get; private set; }

        public int TankedLPG { get; private set; }
        public int TankedPb95 { get; private set; }

        public bool onlyLPG { get; private set; }

        public FuelState()
        {
            maxLPG = 30;
            maxPb95 = 45;
            LevelLPG = maxLPG;
            LevelPb95 = maxPb95;

            CombustLPG = 9;
            CombustPb95 = 6;
            TankedLitersLPG = maxLPG;
            TankedLitersPb95 = maxPb95;
            TankedLPG = 0;
            TankedPb95 = 0;
            onlyLPG = false;
        }

        public void Display()
        {
            Console.WriteLine( LevelLPG + "\t" + LevelPb95.ToString());
        }

        public void CombustFuel(int distance)
        {
            if (LevelLPG > 15)
            {
                LevelLPG -= CombustLPG * distance / 100;
                onlyLPG = true;
            }
            else
            {
                LevelLPG -= CombustLPG * distance /2/ 100;
                LevelPb95 -= CombustPb95 * distance / 2 / 100;
                onlyLPG = false;
            }
            LevelLPG=Math.Round(LevelLPG,2,MidpointRounding.ToEven);
            LevelPb95=Math.Round(LevelPb95,2,MidpointRounding.ToEven);
        }

        public void TankFuel(DateTime date)
        {
            DayOfWeek day=date.DayOfWeek;
            if (day == DayOfWeek.Thursday && LevelPb95<40) 
            {
                TankedLitersPb95 += maxPb95 - LevelPb95;
                LevelPb95=maxPb95;
                TankedPb95++;
            }
            if (LevelLPG < 5)
            {
                TankedLitersLPG += maxLPG - LevelLPG;
                LevelLPG = maxLPG;
                TankedLPG++;
            }
        }
    }
}
