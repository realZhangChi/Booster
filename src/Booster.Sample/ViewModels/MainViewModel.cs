using Booster.MVVM;
using CommunityToolkit.Mvvm.Input;

namespace Booster.Sample.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [RelayCommand]
    protected virtual Task ButtonClickedAsync()
    {
        throw new Exception("Exception throw by Button clicked");
    }
}