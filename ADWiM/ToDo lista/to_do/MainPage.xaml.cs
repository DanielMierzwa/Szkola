using to_do.ViewModel;

namespace to_do
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext=vm;
        }

    }
}
