using System;
using System.Collections.Generic;
using System.Text;

namespace FF.Models
{
    public class FxCalculator
    {
        public static double  CalculateFx(int paramA, int paramB, int paramC, double x)
        {
            return paramA * x * x + paramB * x + paramC;
        }
    }
}
