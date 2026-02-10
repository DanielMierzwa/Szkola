using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModel
{
    [QueryProperty(nameof(Mass), "Mass")]
    [QueryProperty(nameof(Height), "Height")]
    public partial class ResultsViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string mass;

        [ObservableProperty]
        public string height;

        [ObservableProperty]
        public string result;

        [ObservableProperty]
        public string colorBMI;

        public void OnAppearing()
        {
            double calculationResult = BMICalculator.CalculateBMI(double.Parse(Mass), double.Parse(Height));
            Result = calculationResult.ToString();
            if (calculationResult < 18.5d)
            {
                ColorBMI = "Orange";
            }
            else if (calculationResult > 30.0d)
            {
                ColorBMI = "Red";
            }
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
