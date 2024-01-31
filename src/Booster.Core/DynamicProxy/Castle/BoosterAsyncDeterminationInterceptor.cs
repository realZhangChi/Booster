using Castle.DynamicProxy;

namespace Booster.DynamicProxy.Castle;

public class BoosterAsyncDeterminationInterceptor<TInterceptor>(TInterceptor interceptor)
    : AsyncDeterminationInterceptor(new CastleInterceptorAdapter<TInterceptor>(interceptor))
    where TInterceptor : IBoosterInterceptor;