namespace Booster.MVVM;

public interface IViewModelBase : IQueryAttributable
{
    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; }

    Task InitializeAsync();
}