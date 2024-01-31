namespace Booster.DynamicProxy;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class InterceptByAttribute(params Type[]? interceptors) : Attribute
{
    private readonly Type[] _interceptors = interceptors ?? Type.EmptyTypes;

    public IEnumerable<Type> GetInterceptors() => _interceptors;
}