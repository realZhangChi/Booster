namespace Booster.DynamicProxy;

public abstract class BoosterInterceptor : IBoosterInterceptor
{
    public abstract Task InterceptAsync(IBoosterMethodInvocation invocation);
}