namespace Booster.DynamicProxy;

public interface IBoosterInterceptor
{
    // Implement as Public
    Task InterceptAsync(IBoosterMethodInvocation invocation);
}