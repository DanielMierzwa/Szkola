using System;
using System.Collections.Generic;
using System.Text;

namespace peselCoder.Models
{
    
    public class Human
    {
        public DateTime BirthDate { get; private set; }
        public Data.Gender Gender { get; private set; }
        public bool peselIsValid { get; private set; }
        public Human(DateTime birthDate, Data.Gender gender)
        {
            Gender = gender;
            BirthDate = birthDate;
            peselIsValid = true;
        }
        public Human(DateTime birthDate, Data.Gender gender, bool validPesel)
        {
            Gender = gender;
            BirthDate = birthDate;
            peselIsValid = validPesel;
        }
    }

}
