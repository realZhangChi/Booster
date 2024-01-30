using Castle.DynamicProxy;

namespace Booster.Core.MVVM;

public class ViewModelAsyncInterceptor : IAsyncInterceptor
{
    public void InterceptSynchronous(IInvocation invocation)
    {
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            throw;
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
            throw;
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
            throw;
        }
    }
}