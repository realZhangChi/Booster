using Castle.DynamicProxy;

namespace Booster.DynamicProxy.Castle;

public class CastleInterceptorAdapter<TBoosterInterceptor>(TBoosterInterceptor boosterInterceptor)
    : AsyncInterceptorBase
    where TBoosterInterceptor : IBoosterInterceptor
{
    protected override Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo,
        Func<IInvocation, IInvocationProceedInfo, Task> proceed)
    {
        return boosterInterceptor.InterceptAsync(new BoosterMethodInvocation(invocation, proceedInfo, proceed));
    }

    protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation,
        IInvocationProceedInfo proceedInfo,
        Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
    {
        var adaptor = new BoosterMethodInvocationWithReturn<TResult>(invocation, proceedInfo, proceed);
        await boosterInterceptor.InterceptAsync(adaptor);

        return (TResult)adaptor.ReturnValue;
    }
}