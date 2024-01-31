namespace Booster.Core.ExceptionHandle;

public interface IExceptionNotifier
{
    Task NotifyAsync(Exception exception);
}