using Booster.Core.Dialog;

namespace Booster.Core.MVVM;

public abstract partial class ViewModelBase : ObservableObject, IViewModelBase, IDisposable
{
    private long _isBusy;

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

    [ObservableProperty] private bool _isInitialized;

    protected virtual IServiceProvider ServiceProvider =>
        IPlatformApplication.Current!.Services.GetRequiredService<IServiceProvider>();

    private readonly Lazy<IDialogService> _dialogService =
        new(IPlatformApplication.Current!.Services.GetRequiredService<IDialogService>());

    protected IDialogService DialogService => _dialogService.Value;

    public virtual IAsyncRelayCommand InitializeAsyncCommand { get; }

    protected ViewModelBase()
    {
        InitializeAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    // TODO: Handle Exception
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }

    public void Dispose()
    {
    }
}