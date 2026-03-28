using peselCoder.ViewModels;

namespace peselCoder
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(DecoderViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
