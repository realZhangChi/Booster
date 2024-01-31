using Castle.DynamicProxy;

namespace Booster.DynamicProxy;

public interface IBoosterMethodInvocation
{
    IInvocation Invocation { get; }
    
    IInvocationProceedInfo ProceedInfo { get; }

    Task ProcessAsync();
}