namespace Booster.ExceptionHandle;

public interface IExceptionNotifier
{
    Task NotifyAsync(Exception exception);
}