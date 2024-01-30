using Castle.DynamicProxy;

namespace Booster.Core.MVVM;

// ReSharper disable once SuggestBaseTypeForParameterInConstructor
public class ViewModelInterceptor(ViewModelAsyncInterceptor asyncInterceptor) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        asyncInterceptor.ToInterceptor().Intercept(invocation);
    }
}