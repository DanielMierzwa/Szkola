using peselCoder.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static peselCoder.Models.Data;

namespace peselCoder.Models
{
    public class CoderSingleton
    {
        private CoderSingleton() { }
        private static CoderSingleton _instance;
        public static CoderSingleton GetInstance()
        {
            if( _instance == null )
                _instance = new CoderSingleton();
            return _instance;
        }

        public Human Decoder(string pesel)
        {
            DateTime birthDate;
            Data.Gender gender = Data.Gender.Unknown;

            if (string.IsNullOrWhiteSpace(pesel) ||
                !pesel.All(char.IsDigit))
            {
                throw new Data.InvalidPeselException();
            }
            if(pesel.Length!=11)
            {
                throw new Data.InvalidPeselLengthException(pesel.Length);
            }

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (pesel[i] - '0') * weights[i];

            int calculatedControlDigit = (10 - (sum % 10)) % 10;

            int givenControlDigit = pesel[10] - '0';


              

            int year = int.Parse(pesel.Substring(0, 2));
            int month = int.Parse(pesel.Substring(2, 2));
            int day = int.Parse(pesel.Substring(4, 2));

            if (month >= 1 && month <= 12)
                year += 1900;
            else if (month >= 21 && month <= 32) { year += 2000; month -= 20; }
            else if (month >= 41 && month <= 52) { year += 2100; month -= 40; }
            else if (month >= 61 && month <= 72) { year += 2200; month -= 60; }
            else if (month >= 81 && month <= 92) { year += 1800; month -= 80; }
            else
                return new Human(DateTime.MinValue, Data.Gender.Unknown);

            if (!DateTime.TryParse($"{year}-{month}-{day}", out birthDate))
                return new Human(DateTime.MinValue, Data.Gender.Unknown);

            int genderDigit = pesel[9] - '0';
            gender = (genderDigit % 2 == 0)
                ? Data.Gender.Woman
                : Data.Gender.Man;

            if (calculatedControlDigit == givenControlDigit)
                return new Human(birthDate, gender);
            else
                return new Human(birthDate, gender, false);
        }

        public string Encoder(Human human)
        {
            DateTime birthDate = human.BirthDate; 
            Data.Gender gender = human.Gender;
            Random random = new Random();

            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;

            if (year >= 2000 && year <= 2099)
                month += 20;
            else if (year >= 2100 && year <= 2199)
                month += 40;
            else if (year >= 2200 && year <= 2299)
                month += 60;
            else if (year >= 1800 && year <= 1899)
                month += 80;

            string pesel =
                (year % 100).ToString("D2") +
                month.ToString("D2") +
                day.ToString("D2");

            for (int i = 0; i < 3; i++)
                pesel += random.Next(0, 10);


            int genderDigit;

            if (gender == Data.Gender.Man)
                genderDigit = random.Next(0, 10) | 1;
            else
                genderDigit = random.Next(0, 10) & ~1;

            pesel += genderDigit.ToString();

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            int sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (pesel[i] - '0') * weights[i];

            int controlDigit = (10 - (sum % 10)) % 10;

            pesel += controlDigit.ToString();

            return pesel;
        }
    }
}
