using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string mass;

        [ObservableProperty]
        private string height;

        [ObservableProperty]
        private bool ableToSubmit=false;

        [RelayCommand]
        private async Task GoToResults()
        {
            await Shell.Current.GoToAsync(nameof(ResultsPage),
                                          new Dictionary<string, object>
                                          {
                                              ["Mass"] = Mass,
                                              ["Height"]=Height
                                          });
        }

        partial void OnMassChanged(string value)
        {
            CheckEntrys();
        }

        partial void OnHeightChanged(string value)
        {
            CheckEntrys();
        }

        private void CheckEntrys()
        {
            if (!string.IsNullOrWhiteSpace(Mass) && !string.IsNullOrWhiteSpace(Height))
                AbleToSubmit = true;
            else
                AbleToSubmit = false;
        }
    }
}
