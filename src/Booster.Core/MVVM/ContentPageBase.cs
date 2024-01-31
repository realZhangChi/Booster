namespace Booster.MVVM;

public class ContentPageBase : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModelBase vm)
        {
            return;
        }

        await vm.InitializeAsyncCommand.ExecuteAsync(null);
    }
}