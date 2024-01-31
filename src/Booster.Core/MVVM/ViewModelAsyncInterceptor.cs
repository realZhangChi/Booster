using Booster.Core.ExceptionHandle;
using Castle.DynamicProxy;
using Nito.AsyncEx;

namespace Booster.Core.MVVM;

public class ViewModelAsyncInterceptor(IExceptionNotifier exceptionNotifier) : IAsyncInterceptor
{
    protected virtual IExceptionNotifier ExceptionNotifier { get; } = exceptionNotifier;

    public void InterceptSynchronous(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            // TODO: Test this
            AsyncContext.Run(async () => await ExceptionNotifier.NotifyAsync(e));
        }
    }

    public void InterceptAsynchronous(IInvocation invocation)
    {
        invocation.ReturnValue = InternalInterceptAsynchronous(invocation);
    }

    public void InterceptAsynchronous<TResult>(IInvocation invocation)
    {
        invocation.ReturnValue = InternalInterceptAsynchronous<TResult>(invocation);
    }

    private async Task InternalInterceptAsynchronous(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
            var task = (Task)invocation.ReturnValue;
            await task;
        }
        catch (Exception e)
        {
            await ExceptionNotifier.NotifyAsync(e);
        }
    }

    private async Task<TResult?> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
            var task = (Task<TResult?>)invocation.ReturnValue;
            return await task;
        }
        catch (Exception e)
        {
            await ExceptionNotifier.NotifyAsync(e);

            return default;
        }
    }
}