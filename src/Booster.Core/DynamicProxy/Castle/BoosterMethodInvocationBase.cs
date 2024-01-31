using Castle.DynamicProxy;

namespace Booster.DynamicProxy.Castle;

public abstract class BoosterMethodInvocationBase(IInvocation invocation, IInvocationProceedInfo proceedInfo)
    : IBoosterMethodInvocation
{
    public IInvocation Invocation { get; } = invocation;
    public IInvocationProceedInfo ProceedInfo { get; } = proceedInfo;

    public abstract Task ProcessAsync();
}