using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using to_do.Models;
using to_do.ViewModel;

namespace to_do.View
{
    public partial class PopUpPage : Popup<string>
    {
        public string AddButtonText;
        private bool editing;
        public PopUpPage()
        {
            InitializeComponent();
            AddButtonText = "Dodaj";
            OnPropertyChanged(nameof(AddButtonText));
            editing = false;

        }
        public PopUpPage(TaskObject task)//to jest "przeci¹zenie metody" to s¹ de facto 2 ró¿ne metody, które kompilator rozró¿nia po ró¿nych parametrach
            //to jest wersja na okienko edycyjne
        {
            InitializeComponent();
            AddButtonText = "Edytuj";
            OnPropertyChanged(nameof(AddButtonText));
            editing = true;
            TaskEntry.Text = task.Name;
        }
        async void Add_Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskEntry.Text))
            {
                await CloseAsync(null);
            }
            else
                await CloseAsync(TaskEntry.Text);//tutaj przekazujemy to co chcemy wyci¹gn¹æ w MainViewModel z result.Result
                                             //musi byæ tego samego typu co podany w linijce 7 -> Popup<string>
        }
        async void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            await CloseAsync(null);
        }
    }
}

