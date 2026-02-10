using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public partial class SettingsViewModel:BaseViewModel
    {
        [ObservableProperty]
        public string mode="Tryb jasny";

        [RelayCommand]
        public void ChangeMode()
        {
            if (mode== "Tryb jasny")
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                Mode = "Tryb ciemny";
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                Mode = "Tryb jasny";
            }
        }


    }
}
