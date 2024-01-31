using Castle.DynamicProxy;

namespace Booster.DynamicProxy.Castle;

public class BoosterMethodInvocation(
    IInvocation invocation,
    IInvocationProceedInfo proceedInfo,
    Func<IInvocation, IInvocationProceedInfo, Task> proceed) : BoosterMethodInvocationBase(invocation, proceedInfo)
{
    public override Task ProcessAsync()
    {
        return proceed(Invocation, ProceedInfo);
    }
}