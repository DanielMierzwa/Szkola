using System;
using System.Collections.Generic;
using System.Text;

namespace peselCoder.Models
{
    public class Data
    {
        public enum Gender
        {
            Man, Woman, Unknown
        }

        public class InvalidPeselException : Exception
        {
            public InvalidPeselException() : base("Niespodziwany błąd przy dekodowaniu PESEL") { }
        }

        public class InvalidPeselLengthException : Exception
        {
            public int Length { get; }

            public InvalidPeselLengthException(int length)
                : base($"PESEL ma błędną długość: {length}\nOczekiwano: 11")
            {
                Length = length;
            }
        }
    }
}
