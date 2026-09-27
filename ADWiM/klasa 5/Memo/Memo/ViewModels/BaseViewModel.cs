using CommunityToolkit.Mvvm.ComponentModel;

namespace Memo.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;
}
