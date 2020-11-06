namespace ZPLForge.Common
{
    /// <summary>
    /// Provide functionality to access the objects context
    /// </summary>
    /// <typeparam name="T">Type of the context to access</typeparam>
    public interface IContextAccessor<T>
    {
        T Context { get; }
    }
}
