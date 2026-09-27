using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using peselCoder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peselCoder.ViewModels
{
    public partial class DecoderViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(DecodePeselCommand))]
        private string _pesel;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Gender))]
        [NotifyPropertyChangedFor(nameof(BirthDate))]
        private Human _human;

        [ObservableProperty]
        private bool _decodeButtonEnabled = false;

        [ObservableProperty]
        private bool iconsVisibilty = false;

        [ObservableProperty]
        private string iconSource = "ok.svg";

        [ObservableProperty]
        private Color iconColor = Colors.Transparent;

        [ObservableProperty]
        private bool peselIsValid;

        private CoderSingleton coder;

        public DecoderViewModel()
        {
            coder = CoderSingleton.GetInstance();
        }

        [ObservableProperty]
        private string gender;

        [ObservableProperty]
        private string birthDate = "00.00.0000";
        [ObservableProperty]
        public int age;
        [ObservableProperty]
        public int nextBirthdayDays;
        [ObservableProperty]
        public string peselValidMessage;
        [ObservableProperty]
        public string genderIconSource;
        partial void OnPeselChanged(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                DecodeButtonEnabled = false;
            else
                DecodeButtonEnabled = true;
            DecodePeselCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand]
        public async Task DecodePesel()
        {
            try
            {
                Human = coder.Decoder(Pesel);
                IconsVisibilty = true;

                DateTime today = DateTime.Today;
                DateTime date = Human.BirthDate;

                BirthDate = Human.BirthDate.ToString("dd.MM.yyyy");

                Age = today.Year - date.Year;
                if (today.Month < date.Month ||
                    (today.Month == date.Month && today.Day < date.Day))
                {
                    Age--;
                }

                Gender = Human.Gender switch
                {
                    Data.Gender.Man => "Mężczyzna",
                    _ => "Kobieta"
                };

                DateTime nextBirthday = new DateTime(today.Year, date.Month, date.Day);

                if (nextBirthday < today)
                    nextBirthday = nextBirthday.AddYears(1);

                NextBirthdayDays = (nextBirthday - today).Days;

                PeselIsValid = Human.peselIsValid;

                if (PeselIsValid)
                {
                    IconSource = "ok.png";
                    IconColor = Colors.Green;
                    PeselValidMessage = "PESEL jest prawidłowy";
                }
                else
                {
                    IconSource = "error.png";
                    IconColor = Colors.Red;
                    PeselValidMessage = "PESEL jest nieprawidłowy";
                }
                if(Human.Gender==Data.Gender.Man)
                {
                    GenderIconSource="male.png";
                }
                else
                {
                    GenderIconSource = "female.png";
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Błąd", ex.Message, "OK");
            }
        }
    }
}


