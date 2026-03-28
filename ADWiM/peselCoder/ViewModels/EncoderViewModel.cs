using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using peselCoder.Models;
using System.Collections.ObjectModel;

namespace peselCoder.ViewModels
{
    public partial class EncoderViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pesel;

        [ObservableProperty]
        private bool peselVisible = false;

        [ObservableProperty]
        private DateTime birthDate = DateTime.Today;

        [ObservableProperty]
        private bool canGenerate;

        [ObservableProperty]
        private bool canCopy;

        public ObservableCollection<string> Genders { get; } = new()
        {
            "Mężczyzna",
            "Kobieta"
        };

        [ObservableProperty]
        private string selectedGender;

        public DateTime Today => DateTime.Today;

        public EncoderViewModel()
        {
            ValidateForm();
        }

        partial void OnBirthDateChanged(DateTime value)
        {
            ValidateForm();
        }

        partial void OnSelectedGenderChanged(string value)
        {
            ValidateForm();
        }

        partial void OnPeselChanged(string value)
        {
            CanCopy = !string.IsNullOrWhiteSpace(value);
        }

        private void ValidateForm()
        {
            CanGenerate =
                !string.IsNullOrWhiteSpace(SelectedGender) &&
                BirthDate <= DateTime.Today;
        }

        [RelayCommand(CanExecute = nameof(CanGenerate))]
        private void GeneratePesel()
        {
            
            Human human = new(BirthDate,selectedGender=="Mężczyzna" ? Data.Gender.Man : Data.Gender.Woman);
            Pesel = CoderSingleton.GetInstance().Encoder(human);
            PeselVisible = true;
        }

        [RelayCommand(CanExecute = nameof(CanCopy))]
        private async Task CopyPesel()
        {
            await Clipboard.SetTextAsync(Pesel);
            await Shell.Current.DisplayAlert(
                "Skopiowano",
                "PESEL został skopiowany do schowka",
                "OK");
        }
    }
}