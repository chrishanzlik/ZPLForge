namespace ZPLForge.Builders.Abstractions
{
    /// <summary>
    /// Element builder contract
    /// </summary>
    /// <typeparam name="T">Type of the element to build</typeparam>
    public interface IElementBuilder<T> where T : LabelContent, new()
    {
        T Build();

        void Reset();
    }
}
