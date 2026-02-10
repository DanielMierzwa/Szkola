using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public static class BMICalculator
    {
        public static double CalculateBMI(double massInKilograms, double heightInCentimeters)
        {
            double heightInMeters= heightInCentimeters / 100.0;
            return massInKilograms / (heightInMeters*heightInMeters);
        }
    }
}
