using System;
using System.Collections.Generic;
using System.Linq;
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

        public FuelState()
        {
            maxLPG = 30;
            maxPb95 = 45;
            LevelLPG = maxLPG;
            LevelPb95 = maxPb95;

            CombustLPG = 9;
            CombustPb95 = 6;
        }

        public void Display()
        {
            Console.WriteLine("LPG:" + LevelLPG.ToString() + "/" + maxLPG + "\tPb95:" + LevelPb95.ToString() + "/" + maxPb95.ToString());
        }

        public void CombustFuel(int distance)
        {
            if (LevelLPG > 15)
            {
                LevelLPG -= CombustLPG * distance / 100;
            }
            else
            {
                LevelLPG -= CombustLPG * distance /2/ 100;
                LevelPb95 -= CombustPb95 * distance / 2 / 100;
            }
            LevelLPG=Math.Round(LevelLPG,2,MidpointRounding.ToEven);
            LevelPb95=Math.Round(LevelPb95,2,MidpointRounding.ToEven);
        }

        public void TankFuel(DateTime date)
        {
            DayOfWeek day=date.DayOfWeek;
            Console.WriteLine(day);
        }
    }
}
