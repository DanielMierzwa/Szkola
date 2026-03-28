using peselCoder.ViewModels;
namespace peselCoder;
public partial class EncoderPage : ContentPage
{
	public EncoderPage(EncoderViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}