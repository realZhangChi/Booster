using Castle.DynamicProxy;

namespace Booster.DynamicProxy.Castle;

public class BoosterMethodInvocationWithReturn<TResult>(
    IInvocation invocation,
    IInvocationProceedInfo proceedInfo,
    Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
    : BoosterMethodInvocationBase(invocation, proceedInfo)
{
    public object ReturnValue { get; private set; } = default!;

    public override async Task ProcessAsync()
    {
        ReturnValue = (await proceed(Invocation, ProceedInfo))!;
    }
}